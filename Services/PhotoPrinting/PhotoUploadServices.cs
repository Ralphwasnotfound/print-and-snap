using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using QRCoder;


namespace Snap_and_Print.Services.PhotoPrinting
{
    internal class PhotoUploadServices
    {
        // ==========================================
        // SERVER
        // ==========================================

        private HttpListener uploadServer;
        private bool serverRunning = false;

        // ==========================================
        // TOKEN
        // ==========================================

        public string currentPhotoToken = "";
        public bool uploadUsed = false;

        // ==========================================
        // SETTINGS
        // ==========================================

        private const long MAX_UPLOAD_SIZE = 20 * 1024 * 1024;

        private const int PORT = 3001;

        private string basePath = @"C:\PrintAndSnap";

        private string idTempFolder;
        private string funTempFolder;

        public event Action<string> PhotoUploaded;

        public PhotoUploadServices()
        {
            idTempFolder =
                Path.Combine(basePath, "ID", "temp");

            funTempFolder =
                Path.Combine(basePath, "FUN", "temp");

            Directory.CreateDirectory(idTempFolder);
            Directory.CreateDirectory(funTempFolder);
        }

       

        // ==========================================
        // GENERATE TOKEN
        // ==========================================

        public string GenerateNewToken()
        {
            currentPhotoToken = Guid.NewGuid().ToString();

            uploadUsed = false;

            return currentPhotoToken;
        }

        // ==========================================
        // START SERVER
        // ==========================================

        public void StartUploadServer()
        {
            if (serverRunning)
                return;

            try
            {
                uploadServer = new HttpListener();

                uploadServer.Prefixes.Add(
                    $"http://*:{PORT}/"
                );

                uploadServer.Start();

                serverRunning = true;

                System.Diagnostics.Debug.WriteLine(
                    $"Photo Upload Server started on port {PORT}."
                );

                _ = Task.Run(
                    () => HandleUploadRequests()
                );
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    "Photo Upload Server error: " +
                    ex.Message
                );
            }
        }

        // ==========================================
        // HANDLE REQUESTS
        // ==========================================

        private async Task HandleUploadRequests()
        {
            while (serverRunning)
            {
                HttpListenerContext context = null;

                try
                {
                    context =
                        await uploadServer.GetContextAsync();
                }
                catch (ObjectDisposedException)
                {
                    break;
                }
                catch (HttpListenerException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "Photo listener error: " +
                        ex.Message
                    );

                    continue;
                }

                if (context == null)
                    continue;

                try
                {
                    ProcessRequest(context);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "Photo request error: " +
                        ex.Message
                    );

                    try
                    {
                        context.Response.Close();
                    }
                    catch { }
                }
            }
        }

        // ==========================================
        // PROCESS REQUEST
        // ==========================================

        private void ProcessRequest(
            HttpListenerContext context)
        {
            string token =
                context.Request.QueryString["token"];

            System.Diagnostics.Debug.WriteLine(
                $"PHOTO REQUEST: " +
                $"{context.Request.HttpMethod} " +
                $"{context.Request.Url} " +
                $"FROM {context.Request.RemoteEndPoint}"
            );

            // ==========================================
            // WRONG NETWORK CHECK
            // ==========================================

            IPAddress remoteIP =
                context.Request.RemoteEndPoint.Address;

            bool isLocal =
                IPAddress.IsLoopback(remoteIP) ||
                (
                    remoteIP.AddressFamily ==
                    System.Net.Sockets.AddressFamily.InterNetwork
                    &&
                    remoteIP.ToString()
                        .StartsWith("192.168.8.")
                );

            if (!isLocal)
            {
                SendHtml(
                    context,
                    403,
                    @"
<!DOCTYPE html>
<html>

<head>
<meta charset='UTF-8'>
<meta name='viewport'
      content='width=device-width, initial-scale=1.0'>

<style>

body{
    font-family:'Segoe UI',Arial,sans-serif;
    background:#f4f6f9;

    display:flex;
    justify-content:center;
    align-items:center;

    height:100vh;
    margin:0;
}

.card{
    width:90%;
    max-width:420px;

    background:white;

    border-radius:20px;

    padding:40px;

    box-shadow:
        0 15px 40px rgba(0,0,0,.15);

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
}

</style>

</head>

<body>

<div class='card'>

<div class='icon'>⚠️</div>

<h2>Wrong Network</h2>

<p>
Please connect to the
<b>Snap and Print LOCAL Wi-Fi</b>
before uploading your photo.
</p>

</div>

</body>

</html>"
                );

                return;
            }

            // ==========================================
            // TOKEN CHECK
            // ==========================================

            if (string.IsNullOrEmpty(token) ||
                token != currentPhotoToken)
            {
                SendHtml(
                    context,
                    403,
                    @"
<!DOCTYPE html>
<html>

<head>
<meta charset='UTF-8'>
<meta name='viewport'
      content='width=device-width, initial-scale=1.0'>

<style>

body{
    font-family:'Segoe UI',Arial,sans-serif;
    background:#f4f6f9;

    display:flex;
    justify-content:center;
    align-items:center;

    height:100vh;
    margin:0;
}

.card{
    width:90%;
    max-width:420px;

    background:white;

    border-radius:20px;

    padding:40px;

    box-shadow:
        0 15px 40px rgba(0,0,0,.15);

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
}

</style>

</head>

<body>

<div class='card'>

<div class='icon'>🔒</div>

<h2>Upload Locked</h2>

<p>
This photo upload session is no longer valid.
Please return to the kiosk and scan the
new QR code.
</p>

</div>

</body>

</html>"
                );

                return;
            }

            // ==========================================
            // UPLOAD USED CHECK
            // ==========================================

            if (uploadUsed)
            {
                SendHtml(
                    context,
                    403,
                    @"
<!DOCTYPE html>
<html>

<head>
<meta charset='UTF-8'>
<meta name='viewport'
      content='width=device-width, initial-scale=1.0'>

<style>

body{
    font-family:'Segoe UI',Arial,sans-serif;
    background:#f4f6f9;

    display:flex;
    justify-content:center;
    align-items:center;

    height:100vh;
    margin:0;
}

.card{
    width:90%;
    max-width:420px;

    background:white;

    border-radius:20px;

    padding:40px;

    box-shadow:
        0 15px 40px rgba(0,0,0,.15);

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
}

</style>

</head>

<body>

<div class='card'>

<div class='icon'>⛔</div>

<h2>Upload Already Used</h2>

<p>
This photo upload session has already been completed.
Please return to the kiosk to start a new session.
</p>

</div>

</body>

</html>"
                );

                return;
            }

            // ==========================================
            // POST PHOTO
            // ==========================================

            if (context.Request.HttpMethod == "POST")
            {
                ReceivePhoto(context);
                return;
            }

            // ==========================================
            // SHOW PHOTO UPLOAD PAGE
            // ==========================================

            ShowUploadPage(context);
        }

        // ==========================================
        // RECEIVE PHOTO
        // ==========================================

        private void ReceivePhoto(
            HttpListenerContext context)
        {
            string fileName =
                context.Request.Headers["X-File-Name"];

            if (string.IsNullOrEmpty(fileName))
                fileName =
                    "photo_" + DateTime.Now.Ticks + ".jpg";

            fileName =
                Path.GetFileName(fileName);

            string ext =
                Path.GetExtension(fileName)
                    ?.ToLower();

            // ONLY PHOTO FILES

            if (ext != ".jpg" &&
                ext != ".jpeg" &&
                ext != ".png")
            {
                SendHtml(
                    context,
                    400,
                    @"
<!DOCTYPE html>
<html>

<body style='
font-family:Segoe UI,Arial;
text-align:center;
padding:60px;
'>

<h2>📷 Unsupported Photo</h2>

<p>
Please select a JPG, JPEG or PNG image.
</p>

</body>

</html>"
                );

                return;
            }

            // ==========================================
            // TEMP LOCATION
            // ==========================================

            string filePath =
                Path.Combine(
                    idTempFolder,
                    DateTime.Now.Ticks +
                    "_" +
                    fileName
                );

            try
            {
                long totalBytes = 0;

                using (
                    FileStream fs =
                    new FileStream(
                        filePath,
                        FileMode.Create
                    )
                )
                {
                    byte[] buffer =
                        new byte[8192];

                    int bytesRead;

                    while (
                        (bytesRead =
                            context.Request.InputStream
                            .Read(
                                buffer,
                                0,
                                buffer.Length
                            )) > 0
                    )
                    {
                        totalBytes += bytesRead;

                        if (totalBytes >
                            MAX_UPLOAD_SIZE)
                        {
                            fs.Close();

                            File.Delete(filePath);

                            SendHtml(
                                context,
                                400,
                                @"
<h2>📦 Photo Too Large</h2>
<p>Maximum photo size is 20 MB.</p>"
                            );

                            return;
                        }

                        fs.Write(
                            buffer,
                            0,
                            bytesRead
                        );
                    }
                }

                uploadUsed = true;

                SendHtml(
                    context,
                    200,
                    @"
<!DOCTYPE html>
<html>

<body style='
font-family:Segoe UI,Arial;
text-align:center;
padding:60px;
'>

<h2>✅ Photo Uploaded</h2>

<p>
Return to the Snap and Print kiosk
to continue.
</p>

</body>

</html>"
                );

                System.Diagnostics.Debug.WriteLine(
    "PHOTO SAVED: " +
    filePath
);

                // ==========================================
                // NOTIFY MAIN FORM
                // ==========================================

                System.Diagnostics.Debug.WriteLine(
                    "FIRING PhotoUploaded EVENT: " +
                    filePath
                );

                PhotoUploaded?.Invoke(filePath);
            }
            catch (Exception ex)
            {
                try
                {
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                }
                catch { }

                SendHtml(
                    context,
                    500,
                    "<h2>Upload Failed</h2>"
                );

                System.Diagnostics.Debug.WriteLine(
                    "Photo upload error: " +
                    ex.Message
                );
            }
        }

        // ==========================================
        // UPLOAD PAGE
        // ==========================================

        private void ShowUploadPage(
            HttpListenerContext context)
        {
            string html = $@"
<!DOCTYPE html>

<html>

<head>

<meta charset='UTF-8'>

<meta name='viewport'
      content='width=device-width, initial-scale=1.0'>

<style>

body{{
    font-family:'Segoe UI',Arial,sans-serif;
    background:#f4f6f9;

    display:flex;
    justify-content:center;
    align-items:center;

    height:100vh;
    margin:0;
}}

.card{{
    width:90%;
    max-width:420px;

    background:white;

    border-radius:20px;

    padding:40px;

    box-shadow:
        0 15px 40px rgba(0,0,0,.15);

    text-align:center;
}}

h2{{
    color:#222;
}}

input{{
    margin-top:25px;
    width:100%;
    padding:15px;
}}

</style>

</head>

<body>

<div class='card'>

<h2>📷 Send Your Photo</h2>

<p>
Select a photo from your phone.
</p>

<input
    type='file'
    id='photoInput'
    accept='.jpg,.jpeg,.png,image/jpeg,image/png'
/>

</div>

<script>

document
.getElementById('photoInput')
.addEventListener('change', function(){{

    let file = this.files[0];

    if (!file)
        return;

    fetch('/?token={currentPhotoToken}', {{
        method:'POST',

        headers:{{
            'X-File-Name':file.name
        }},

        body:file
    }})

    .then(response => response.text())

    .then(html => {{

        document.open();

        document.write(html);

        document.close();

    }})

    .catch(() => {{

        document.body.innerHTML =
        '<h2>Upload Failed</h2>' +
        '<p>Please try again.</p>';

    }});

}});

</script>

</body>

</html>";

            SendHtml(
                context,
                200,
                html
            );
        }

        // ==========================================
        // SEND HTML
        // ==========================================

        private void SendHtml(
            HttpListenerContext context,
            int statusCode,
            string html)
        {
            byte[] buffer =
                Encoding.UTF8.GetBytes(html);

            context.Response.StatusCode =
                statusCode;

            context.Response.ContentType =
                "text/html; charset=UTF-8";

            context.Response.ContentLength64 =
                buffer.Length;

            context.Response.OutputStream.Write(
                buffer,
                0,
                buffer.Length
            );

            context.Response.OutputStream.Close();
        }

        // ==========================================
        // STOP SERVER
        // ==========================================

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

        public Bitmap GenerateQRCode(int width, int height)
        {
            try
            {
                if (string.IsNullOrEmpty(currentPhotoToken))
                    return null;

                string uploadUrl =
                    $"http://192.168.8.100:{PORT}/?token={currentPhotoToken}";

                using (var qrGenerator = new QRCoder.QRCodeGenerator())
                using (var qrData = qrGenerator.CreateQrCode(
                    uploadUrl,
                    QRCoder.QRCodeGenerator.ECCLevel.Q))
                using (var qrCode = new QRCoder.QRCode(qrData))
                {
                    int size = Math.Min(width, height);

                    return qrCode.GetGraphic(
                        10,
                        Color.Black,
                        Color.White,
                        true
                    );
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    "Photo QR generation error: " + ex.Message
                );

                return null;
            }
        }
    }
}