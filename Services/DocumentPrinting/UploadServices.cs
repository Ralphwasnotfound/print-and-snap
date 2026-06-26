using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintAndSnap.Services
{
    public class UploadServices
    {
        private const bool DEV_MODE = true;

        private HttpListener uploadServer;
        private bool serverRunning = false;

        public string currentUploadToken = "";
        public bool uploadUsed = false;

        private const long MAX_UPLOAD_SIZE = 20 * 1024 * 1024;
        
        private string basePath = @"C:\PrintAndSnap";

        private string watchFolder;
        private string idDownloadFolder;
        private string funDownloadFolder;

        public UploadServices()
        {
            watchFolder = Path.Combine(basePath, "DOCS", "uploads");
            idDownloadFolder = Path.Combine(basePath, "ID", "download");
            funDownloadFolder = Path.Combine(basePath, "FUN", "download");
        }
        public Bitmap GenerateQRCode()
        {
            string localIP = GetLocalIPAdress();
            string uploadUrl = "http://" + localIP + ":3000/?token=" + currentUploadToken;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(uploadUrl, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            return qrCode.GetGraphic(20);
        }

        public void ResetUploadFolder()
        {
            if (!Directory.Exists(watchFolder))
                return;

            foreach (var file in Directory.GetFiles(watchFolder))
            {
                try { File.Delete(file); } catch { }
            }
        }

        public void StopServer()
        {
            serverRunning = false;

            try
            {
                if (uploadServer != null)
                {
                    uploadServer.Stop();
                    uploadServer.Close();
                    uploadServer = null;
                }

            }
            catch { }
        }

        public void StartUploadServer()
        {

            if (serverRunning) return;

                Directory.CreateDirectory(idDownloadFolder);
                Directory.CreateDirectory(funDownloadFolder);

                uploadServer = new HttpListener();
                uploadServer.Prefixes.Add("http://*:3000/");
                uploadServer.Start();

                serverRunning = true;

                _ = Task.Run(() => HandleUploadRequests());
          
        }

        private async Task HandleUploadRequests()
        {
            while (true)
            {
                if (!serverRunning || uploadServer == null)
                    break;

                HttpListenerContext context = null;

                try
                {
                    context = await uploadServer.GetContextAsync();
                }
                catch (ObjectDisposedException)
                {
                    break; // server closed
                }
                catch (HttpListenerException)
                {
                    break; // listener stopped
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Listener error: " + ex.Message);
                    continue;
                }

                try
                {
                    string token = context.Request.QueryString["token"];

                    if (context.Request.Url.AbsolutePath.StartsWith("/download"))
                    {
                        string fileName = context.Request.QueryString["file"];

                        if (string.IsNullOrEmpty(fileName))
                        {
                            context.Response.StatusCode = 400;
                            context.Response.Close();
                            continue;
                        }

                        string baseFolder = fileName.StartsWith("FUN-")
                            ? funDownloadFolder
                            : idDownloadFolder;

                        string filePath = Path.Combine(baseFolder, fileName);

                        if (!File.Exists(filePath))
                        {
                            context.Response.StatusCode = 404;
                            context.Response.Close();
                            continue;
                        }

                        byte[] fileBytes = File.ReadAllBytes(filePath);

                        context.Response.ContentType = "application/octet-stream";
                        context.Response.AddHeader("Content-Disposition", $"attachment; filename=\"{fileName}\"");
                        context.Response.ContentLength64 = fileBytes.Length;

                        context.Response.OutputStream.Write(fileBytes, 0, fileBytes.Length);

                        uploadUsed = true;

                        context.Response.OutputStream.Flush();
                        context.Response.OutputStream.Close();
                        context.Response.Close();

                        // delete after download
                        _ = Task.Run(async () =>
                        {
                            await Task.Delay(2000);
                            try
                            {
                                if (File.Exists(filePath))
                                    File.Delete(filePath);
                            }
                            catch { }
                        });

                        continue; 
                    }

                    bool isLocal =
    context.Request.RemoteEndPoint.Address.Equals(IPAddress.Loopback) ||
    context.Request.RemoteEndPoint.Address.Equals(IPAddress.IPv6Loopback);

                    if (!isLocal && token != currentUploadToken)
                    {
                        string htmlLocked = @"
<!DOCTYPE html>
<html>

<head>

<meta charset='UTF-8'>
<meta name='viewport' content='width=device-width, initial-scale=1.0'>

<style>

*{
    margin:0;
    padding:0;
    box-sizing:border-box;
}

body{
    font-family:'Segoe UI',Arial,sans-serif;
    background:#f4f6f9;
    display:flex;
    justify-content:center;
    align-items:center;
    height:100vh;
}

.card{
    width:90%;
    max-width:420px;
    background:white;
    border-radius:20px;
    padding:40px;
    box-shadow:0 15px 40px rgba(0,0,0,.15);
    text-align:center;
}

.icon{
    font-size:55px;
    margin-bottom:20px;
}

h2{
    color:#222;
    margin-bottom:15px;
    font-size:30px;
}

p{
    color:#666;
    line-height:1.7;
    margin-bottom:30px;
}

.footer{
    color:#999;
    font-size:14px;
}

</style>

</head>

<body>

<div class='card'>

<div class='icon'>🔒</div>

<h2>Upload Locked</h2>

<p>
Please scan the QR code displayed on the
<b>Snap and Print</b> kiosk to begin your upload session.
</p>

<div class='footer'>
Snap and Print
</div>

</div>

</body>

</html>";

                        byte[] bufferLocked = Encoding.UTF8.GetBytes(htmlLocked);

                        context.Response.ContentLength64 = bufferLocked.Length;
                        context.Response.OutputStream.Write(bufferLocked, 0, bufferLocked.Length);
                        context.Response.OutputStream.Close();
                        continue;
                    }

                    //                    if (token != currentUploadToken)
                    //                    {
                    //                        string htmlLocked = @"
                    //<html>
                    //<body style='font-family:Arial;text-align:center;margin-top:50px'>
                    //<h2>Upload Locked</h2>
                    //<p>Please scan the QR code on the printer machine.</p>
                    //</body>
                    //</html>";

                    //                        byte[] bufferLocked = Encoding.UTF8.GetBytes(htmlLocked);

                    //                        context.Response.ContentLength64 = bufferLocked.Length;
                    //                        context.Response.OutputStream.Write(bufferLocked, 0, bufferLocked.Length);
                    //                        context.Response.OutputStream.Close();
                    //                        continue;
                    //                    }

                    if (context.Request.HttpMethod == "POST")
                    {
                        if (uploadUsed)
                        {
                            string htmlLocked = @"
<!DOCTYPE html>
<html>
<head>
<meta charset='UTF-8'>
<meta name='viewport' content='width=device-width, initial-scale=1.0'>

<style>

*{margin:0;padding:0;box-sizing:border-box;}

body{
font-family:'Segoe UI',Arial,sans-serif;
background:#f4f6f9;
display:flex;
justify-content:center;
align-items:center;
height:100vh;
}

.card{
width:90%;
max-width:420px;
background:#fff;
padding:40px;
border-radius:20px;
box-shadow:0 15px 40px rgba(0,0,0,.15);
text-align:center;
}

.icon{
font-size:60px;
margin-bottom:20px;
}

h2{
color:#222;
margin-bottom:15px;
}

p{
color:#666;
line-height:1.7;
margin-bottom:25px;
}

.footer{
color:#999;
font-size:14px;
}

</style>
</head>

<body>

<div class='card'>

<div class='icon'>⛔</div>

<h2>Upload Already Used</h2>

<p>
This upload session has already been completed.
Please return to the kiosk to begin a new session.
</p>

<div class='footer'>
Snap and Print
</div>

</div>

</body>
</html>";

                            byte[] buffer = Encoding.UTF8.GetBytes(htmlLocked);

                            context.Response.ContentLength64 = buffer.Length;
                            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                            context.Response.OutputStream.Close();
                            continue;
                        }

                        string fileName = context.Request.Headers["X-File-Name"];

                        if (string.IsNullOrEmpty(fileName))
                            fileName = "upload_" + DateTime.Now.Ticks;

                        fileName = Path.GetFileName(fileName);

                        string ext = Path.GetExtension(fileName)?.ToLower();

                        if (ext != ".pdf" && ext != ".doc" && ext != ".docx")
                        {
                            string htmlError = @"
<!DOCTYPE html>
<html>
<head>
<meta charset='UTF-8'>
<meta name='viewport' content='width=device-width, initial-scale=1.0'>

<style>

*{margin:0;padding:0;box-sizing:border-box;}

body{
font-family:'Segoe UI',Arial,sans-serif;
background:#f4f6f9;
display:flex;
justify-content:center;
align-items:center;
height:100vh;
}

.card{
width:90%;
max-width:420px;
background:#fff;
padding:40px;
border-radius:20px;
box-shadow:0 15px 40px rgba(0,0,0,.15);
text-align:center;
}

.icon{
font-size:60px;
margin-bottom:20px;
}

h2{
margin-bottom:15px;
color:#222;
}

p{
line-height:1.7;
color:#666;
margin-bottom:20px;
}

.footer{
color:#999;
font-size:14px;
}

</style>
</head>

<body>

<div class='card'>

<div class='icon'>📄</div>

<h2>Unsupported File</h2>

<p>
Only PDF, DOC and DOCX files are supported.
Please select a supported document.
</p>

<div class='footer'>
Snap and Print
</div>

</div>

</body>
</html>";

                            byte[] bufferError = Encoding.UTF8.GetBytes(htmlError);

                            context.Response.ContentLength64 = bufferError.Length;
                            context.Response.OutputStream.Write(bufferError, 0, bufferError.Length);
                            context.Response.OutputStream.Close();
                            continue;
                        }

                        if (string.IsNullOrEmpty(fileName))
                            fileName = "upload_" + DateTime.Now.Ticks;

                        Directory.CreateDirectory(watchFolder);
                        string filePath = Path.Combine(watchFolder, DateTime.Now.Ticks + "_" + fileName);

                        long totalBytes = 0;

                        using (var fs = new FileStream(filePath, FileMode.Create))
                        {
                            byte[] buffer = new byte[8192];
                            int bytesRead;

                            while ((bytesRead = await context.Request.InputStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                totalBytes += bytesRead;

                                if (totalBytes > MAX_UPLOAD_SIZE)
                                {
                                    fs.Close();
                                    File.Delete(filePath);

                                    string htmlError = @"
<!DOCTYPE html>
<html>
<head>
<meta charset='UTF-8'>
<meta name='viewport' content='width=device-width, initial-scale=1.0'>

<style>

*{margin:0;padding:0;box-sizing:border-box;}

body{
font-family:'Segoe UI',Arial,sans-serif;
background:#f4f6f9;
display:flex;
justify-content:center;
align-items:center;
height:100vh;
}

.card{
width:90%;
max-width:420px;
background:#fff;
padding:40px;
border-radius:20px;
box-shadow:0 15px 40px rgba(0,0,0,.15);
text-align:center;
}

.icon{
font-size:60px;
margin-bottom:20px;
}

h2{
margin-bottom:15px;
}

p{
color:#666;
line-height:1.7;
margin-bottom:20px;
}

.footer{
color:#999;
font-size:14px;
}

</style>
</head>

<body>

<div class='card'>

<div class='icon'>📦</div>

<h2>File Too Large</h2>

<p>
Maximum file size is <b>20 MB</b>.
Please choose a smaller document.
</p>

<div class='footer'>
Snap and Print
</div>

</div>

</body>
</html>";

                                    byte[] errorBuffer = Encoding.UTF8.GetBytes(htmlError);

                                    context.Response.ContentLength64 = errorBuffer.Length;
                                    context.Response.OutputStream.Write(errorBuffer, 0, errorBuffer.Length);
                                    context.Response.OutputStream.Close();

                                    return;
                                }

                                await fs.WriteAsync(buffer, 0, bytesRead);
                            }
                        }

                        uploadUsed = true;

                        _ = Task.Delay(2000).ContinueWith(_ =>
                        {
                            GenerateNewToken();
                        });

                        string htmlSuccess = @"
<!DOCTYPE html>
<html>
<head>
<meta charset='UTF-8'>
<meta name='viewport' content='width=device-width, initial-scale=1.0'>

<style>

*{margin:0;padding:0;box-sizing:border-box;}

body{
font-family:'Segoe UI',Arial,sans-serif;
background:#f4f6f9;
display:flex;
justify-content:center;
align-items:center;
height:100vh;
}

.card{
width:90%;
max-width:420px;
background:#fff;
padding:40px;
border-radius:20px;
box-shadow:0 15px 40px rgba(0,0,0,.15);
text-align:center;
}

.icon{
font-size:65px;
margin-bottom:20px;
}

h2{
color:#222;
margin-bottom:15px;
}

p{
color:#666;
line-height:1.8;
margin-bottom:25px;
}

.footer{
color:#999;
font-size:14px;
}

</style>
</head>

<body>

<div class='card'>

<div class='icon'>✅</div>

<h2>Upload Successful</h2>

<p>
Your document has been uploaded successfully.

<br><br>

Please return to the <b>Snap and Print</b> kiosk to continue printing.
</p>

<div class='footer'>
Thank you for using Snap and Print
</div>

</div>

</body>
</html>";

                        byte[] bufferSuccess = Encoding.UTF8.GetBytes(htmlSuccess);

                        context.Response.ContentLength64 = bufferSuccess.Length;
                        context.Response.OutputStream.Write(bufferSuccess, 0, bufferSuccess.Length);
                        context.Response.OutputStream.Close();
                    }
                    else
                    {
                        string htmlUpload = $@"
<!DOCTYPE html>
<html>

<head>
<meta charset='UTF-8'>
<meta name='viewport' content='width=device-width, initial-scale=1.0'>

<style>

*{{
    margin:0;
    padding:0;
    box-sizing:border-box;
}}

body{{
    font-family:'Segoe UI',Arial,sans-serif;
    background:#f4f6f9;
    display:flex;
    justify-content:center;
    align-items:center;
    height:100vh;
}}

.card{{
    width:420px;
    background:white;
    border-radius:20px;
    padding:40px;
    box-shadow:0 15px 40px rgba(0,0,0,.15);
    text-align:center;
}}

.logo{{
    font-size:38px;
    margin-bottom:10px;
}}

h2{{
    font-size:32px;
    margin-bottom:10px;
    color:#222;
}}

.subtitle{{
    color:#666;
    margin-bottom:30px;
    line-height:1.6;
}}

input[type=file]{{
    width:100%;
    padding:15px;
    border:2px dashed #bdbdbd;
    border-radius:15px;
    background:#fafafa;
    cursor:pointer;
    transition:.25s;
}}

input[type=file]:hover{{
    border-color:#111;
    background:#f2f2f2;
}}

.footer{{
    margin-top:30px;
    color:#888;
    font-size:14px;
    line-height:1.8;
}}

.footer strong{{
    color:#222;
}}

</style>

</head>

<body>

<div class='card'>

<div class='logo'>🖨️</div>

<h2>Snap and Print</h2>

<p class='subtitle'>
Upload your document from your phone.<br>
Supported files: PDF, DOC and DOCX.
</p>

<input
type='file'
id='fileInput'
accept='.pdf,.doc,.docx'
/>

<div class='footer'>
<strong>Maximum file size:</strong> 20 MB
</div>

</div>

<script>
document.getElementById('fileInput').addEventListener('change', function(){{
    let file = this.files[0];

    fetch('/?token={currentUploadToken}', {{
        method: 'POST',
        headers: {{ 'X-File-Name': file.name }},
        body: file
    }})
    .then(response => response.text())
    .then(html => {{
        document.open();
        document.write(html);
        document.close();
    }})
    .catch(() => {{
        document.body.innerHTML =
        '<h2>Upload Failed</h2><p>Please try again.</p>';
    }});
}});
</script>

</body>
</html>";

                        byte[] bufferUpload = Encoding.UTF8.GetBytes(htmlUpload);

                        context.Response.ContentLength64 = bufferUpload.Length;
                        context.Response.OutputStream.Write(bufferUpload, 0, bufferUpload.Length);
                        context.Response.OutputStream.Close();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Processing error: " + ex.Message);
                }
            }
        }

        public string GetLocalIPAdress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No IPv4 address found.");
        }
        public string GenerateNewToken()
        {
            currentUploadToken = Guid.NewGuid().ToString();
            uploadUsed = false;
            return currentUploadToken;
        }
    }
}



