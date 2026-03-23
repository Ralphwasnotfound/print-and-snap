using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrintAndSnap.Services
{
    public class UploadServices
    {
        private HttpListener uploadServer;
        private bool serverRunning = false;

        public string currentUploadToken = "";
        public bool uploadUsed = false;

        private const long MAX_UPLOAD_SIZE = 20 * 1024 * 1024;
        private string watchFolder = @"C:\PrinterVendo\uploads";
        private string idPhotoFolder = @"C:\PrinterVendo\idphotos";
        string idArchiveFolder = @"C:\PrinterVendo\id_archive";
        string idDownloadFolder = @"C:\PrinterVendo\id_download";

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

            uploadServer = new HttpListener();
            uploadServer.Prefixes.Add("http://*:3000/");
            uploadServer.Start();

            serverRunning = true;

            Task.Run(() => HandleUploadRequests());
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
                        Directory.CreateDirectory(idDownloadFolder);

                        string fileName = context.Request.QueryString["file"];

                        if (string.IsNullOrEmpty(fileName))
                        {
                            context.Response.StatusCode = 400;
                            context.Response.Close();
                            return;
                        }

                        string filePath = Path.Combine(idDownloadFolder, fileName);

                        if (!File.Exists(filePath))
                        {
                            context.Response.StatusCode = 404;
                            context.Response.Close();
                            return;
                        }

                        byte[] fileBytes = File.ReadAllBytes(filePath);

                        context.Response.ContentType = "application/octet-stream";
                        context.Response.AddHeader("Content-Disposition", $"attachment; filename=\"{fileName}\"");
                        context.Response.ContentLength64 = fileBytes.Length;

                        context.Response.SendChunked = false;
                        context.Response.KeepAlive = false;

                        using (var output = context.Response.OutputStream)
                        {
                            output.Write(fileBytes, 0, fileBytes.Length);
                            output.Flush();
                        }

                        context.Response.Close();

                        // 🔥 DELETE AFTER DOWNLOAD
                        Task.Run(() =>
                        {
                            try
                            {
                                Thread.Sleep(2000);
                                if (File.Exists(filePath))
                                    File.Delete(filePath);
                            }
                            catch { }
                        });

                        return;
                    }

                    if (token != currentUploadToken)
                    {
                        string htmlLocked = @"
<html>
<body style='font-family:Arial;text-align:center;margin-top:50px'>
<h2>Upload Locked</h2>
<p>Please scan the QR code on the printer machine.</p>
</body>
</html>";

                        byte[] bufferLocked = Encoding.UTF8.GetBytes(htmlLocked);

                        context.Response.ContentLength64 = bufferLocked.Length;
                        context.Response.OutputStream.Write(bufferLocked, 0, bufferLocked.Length);
                        context.Response.OutputStream.Close();
                        continue;
                    }

                    if (context.Request.HttpMethod == "POST")
                    {
                        if (uploadUsed)
                        {
                            string htmlLocked = @"
<html>
<body style='font-family:Arial;text-align:center;margin-top:50px'>
<h2>Upload already used</h2>
<p>This upload session is closed.</p>
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
<html>
<body style='font-family:Arial;text-align:center;margin-top:50px'>
<h2>Unsupported File</h2>
<p>Only PDF and Word documents are allowed.</p>
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
<html>
<body style='font-family:Arial;text-align:center;margin-top:50px'>
<h2>File Too Large</h2>
<p>Maximum allowed file size is 20MB.</p>
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

                        // Optional: prepare next session automatically
                        Task.Delay(2000).ContinueWith(_ =>
                        {
                            GenerateNewToken();
                        });

                        string htmlSuccess = @"
<html>
<body style='font-family:Arial;text-align:center;margin-top:50px'>
<h2>Upload Successful</h2>
<p>Please return to the printer machine.</p>
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
<html>
<body style='font-family:Arial;text-align:center;margin-top:50px'>
<h2>Upload File</h2>
<input type='file' id='fileInput' accept='.pdf,.doc,.docx'/>
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



