using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;
using PdfiumViewer;
using QRCoder;
using System.Net;
using System.Net.Http;
using System.Windows.Forms.VisualStyles;
using System.Linq.Expressions;
using System.Management;


namespace Printer_Vendo
{

    public partial class PrinterPhotoVendo : Form
    {
        private string watchFolder = @"C:\PrinterVendo\uploads";
        private string currentPdfPath;
        private int totalPages = 1;
        private bool colorAnalysisDone = false;
        private List<bool> pageIsColored = new List<bool>();
        private string currentOriginalPath;
        private PdfViewer pdfViewer;
        private string currentEditablePath;
        private int bwPrice = 5;
        private int colorPrice = 10;
        private HttpListener uploadServer;
        private bool serverRunning = false;
        private string currentUploadToken = "";
        private bool uploadUsed = false;
        private FileSystemWatcher fileWatcher;
        private HashSet<string> processedFiles = new HashSet<string>();
        private string lastProcessedFile = "";
        private System.Windows.Forms.Timer cleanupTimer;
        private System.Windows.Forms.Timer printerStatusTimer;
        private System.Windows.Forms.Timer inactivityTimer;
        private System.Windows.Forms.Timer qrExpireTimer;
        private int totalPrice = 0;
        private int insertedMoney = 0;
        private bool printingInProgress = false;
        private bool isRetrievalMode = false;
        private bool fileProcessing = false;
        private bool printSuccess = false;
        private const long MAX_UPLOAD_SIZE = 20 * 1024 * 1024;
        private const int MAX_ALLOWED_PAGES = 50;
        private System.Windows.Forms.Timer uploadStatusTimer;
        private int dotCount = 0;
        private string baseStatusText = "";
        private bool editingDocument = false;
        private IntPtr hookID = IntPtr.Zero;

        public PrinterPhotoVendo()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;

            radioPrintAll.Checked = true;
            UpdateModeUI();

            SetupPlaceholder();

            numericCopies.ValueChanged += numericCopies_ValueChanged;
            numericCopies.TextChanged += (s, e) => CalculateTotal();
            numericPageRange.TextChanged += (s, e) => CalculateTotal();
            numericSinglePage.ValueChanged += (s, e) => CalculateTotal();
            numericSinglePage.TextChanged += (s, e) => CalculateTotal();

            radioPrintAll.CheckedChanged += (s, e) => { UpdateModeUI(); CalculateTotal(); };
            radioSinglePage.CheckedChanged += (s, e) => { UpdateModeUI(); CalculateTotal(); };
            radioPrintRange.CheckedChanged += (s, e) => { UpdateModeUI(); CalculateTotal(); };

            radioColored.CheckedChanged += (s, e) =>
            {
                if (radioColored.Checked && !colorAnalysisDone)
                {
                    totalLabel.Text = "Analyzing...";
                    Application.DoEvents();
                    AnalyzeDocumentColors();
                }

                CalculateTotal();
            };

            Application.ApplicationExit += (s, e) =>
            {
                ShowTaskbar();
            };
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook,
    LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr hhk,
            int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);


        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        private void HideTaskbar()
        {
            IntPtr taskbarHandle = FindWindow("Shell_TrayWnd", null);
            ShowWindow(taskbarHandle, SW_HIDE);
        }

        private void ShowTaskbar()
        {
            IntPtr taskbarHandle = FindWindow("Shell_TrayWnd", null);
            ShowWindow(taskbarHandle, SW_SHOW);
        }

        private void showPanel(Panel panel)
        {
            settingsPanel.Visible = false;
            paymentPanel.Visible = false;

            panel.Visible = true;
        }

        protected override void OnShown(EventArgs e)
        {
            //if debugging hide the task bar
            //if not show for production and testing
            base.OnShown(e);
            //HideTaskbar();
#if !DEBUG
              HideTaskbar(); 
#endif
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ShowTaskbar();
            base.OnFormClosed(e);
        }

        private void ShowPanel(Control panel)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel)
                    c.Visible = false;
            }

            panel.Visible = true;
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            ResetInactivityTimer();
            base.OnMouseDown(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ResetInactivityTimer();

            // BLOCK ALT + TAB
            if (keyData == (Keys.Alt | Keys.Tab))
                return true;

            // BLOCK ALT + F4
            if (keyData == (Keys.Alt | Keys.F4))
                return true;

            // BLOCK CTRL + ESC
            if (keyData == (Keys.Control | Keys.Escape))
                return true;

            // BLOCK WINDOWS KEY
            if (keyData == Keys.LWin || keyData == Keys.RWin)
                return true;
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool PrinterExists(string printerName)
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (printer.Equals(printerName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(13, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                // BLOCK WINDOWS KEY
                if (vkCode == 0x5B || vkCode == 0x5C)
                    return (IntPtr)1;
            }

            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }
        private bool IsPrinterReady(string printerName)
        {
            if (!PrinterExists(printerName))
                return false;

            if (!IsPrinterOnline(printerName))
                return false;

            string status = GetPrinterStatus(printerName);

            if (status == "Printer Ready" || status == "Printing")
                return true;

            return false;
        }
        private bool IsPrinterOnline(string printerName)
        {
            string query = $"SELECT * FROM Win32_Printer WHERE Name = '{printerName}'";

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject printer in searcher.Get())
                {
                    bool offline = printer["WorkOffline"] != null && (bool)printer["WorkOffline"];
                    return !offline;
                }
            }

            return false;
        }
        private string GetPrinterStatus(string printerName)
        {
            string query = $"SELECT * FROM Win32_Printer WHERE Name = '{printerName}'";

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject printer in searcher.Get())
                {
                    if (printer["WorkOffline"] != null && (bool)printer["WorkOffline"])
                        return "Printer Offline";

                    if (printer["PrinterStatus"] != null)
                    {
                        int status = Convert.ToInt32(printer["PrinterStatus"]);

                        switch (status)
                        {
                            case 3:
                                return "Printer Ready";
                            case 4:
                                return "Printing";
                            case 5:
                                return "Printer Warming Up";
                            case 6:
                                return "Printer Stopped";
                            case 7:
                                return "Printer Offline";
                            default:
                                return "Printer Error";
                        }
                    }
                }
            }

            return "Printer Not Found";
        }
        private string GetDetailedPrinterError(string printerName)
        {
            string query = $"SELECT * FROM Win32_Printer WHERE Name = '{printerName}'";

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject printer in searcher.Get())
                {
                    if (printer["DetectedErrorState"] != null)
                    {
                        int error = Convert.ToInt32(printer["DetectedErrorState"]);

                        switch (error)
                        {
                            case 0: return "No Error";
                            case 3: return "Paper Jam";
                            case 4: return "Out of Paper";
                            case 5: return "Paper Problem";
                            case 6: return "Printer Door Open";
                            case 7: return "Printer Offline";
                            case 8: return "Out of Toner / Ink";
                            case 9: return "Low Toner / Ink";
                            case 10: return "Printer Error";
                            default: return "Unknown Printer Error";
                        }
                    }
                }
            }

            return "No Error";
        }
        private void ClearPrinterQueue(string printerName)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c net stop spooler && del /Q /F %systemroot%\\System32\\spool\\PRINTERS\\*.* && net start spooler";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit();
            }
            catch { }
        }
        private void ResetInactivityTimer()
        {
            if (inactivityTimer == null)
                return;

            inactivityTimer.Stop();
            inactivityTimer.Start();
        }
        private void UploadStatusTimer_Tick(object sender, EventArgs e)
        {
            dotCount++;

            if (dotCount > 3)
                dotCount = 1;

            fileUploadStatusLabel.Text = baseStatusText + new string('.', dotCount);
        }
        private void QrExpireTimer_Tick(object sender, EventArgs e)
        {
            qrExpireTimer.Stop();

            if (!uploadUsed)
            {
                fileUploadStatusLabel.Text = "QR Code expired. Please press Start again.";
                ResetMachine();
            }
        }

        private void Printer_Vendo_Load(object sender, EventArgs e)
        {
#if !DEBUG
            //enable this for production
            {
                Process.Start("taskkill", "/f /im explorer.exe");
            }
            
#endif


            ClearPrinterQueue("Canon MG3000 series");
            numericCopies.Minimum = 1;
            numericCopies.Maximum = 50;
            // Show only start panel when program starts
            startPanel.Visible = true;
            uploadPanel.Visible = false;
            printingSettingsPanel.Visible = false;
            continuePanel.Visible = false;
            paymentPanel.Visible = false;
            retrivalPanel.Visible = false;

            Directory.CreateDirectory(@"C:\PrinterVendo\uploads");
            Directory.CreateDirectory(@"C:\PrinterVendo\preview");
            Directory.CreateDirectory(@"C:\PrinterVendo\archive");

            // Setup timer that waits for uploaded file preview
            receiveTimer = new System.Windows.Forms.Timer();
            receiveTimer.Interval = 3000;
            receiveTimer.Tick += ReceiveTimer_Tick;

            cleanupTimer = new System.Windows.Forms.Timer();
            cleanupTimer.Interval = 600000; // 10 minutes
            cleanupTimer.Tick += CleanupTimer_Tick;
            cleanupTimer.Start();

            printerStatusTimer = new System.Windows.Forms.Timer();
            printerStatusTimer.Interval = 2000;
            printerStatusTimer.Tick += PrinterStatusTimer_Tick;
            printerStatusTimer.Start();

            inactivityTimer = new System.Windows.Forms.Timer();
            inactivityTimer.Interval = 120000; // 12 minutes
            inactivityTimer.Tick += InactivityTimer_Tick;

            uploadStatusTimer = new System.Windows.Forms.Timer();
            uploadStatusTimer.Interval = 500; // half second
            uploadStatusTimer.Tick += UploadStatusTimer_Tick;

            qrExpireTimer = new System.Windows.Forms.Timer();
            qrExpireTimer.Interval = 60000; // 60 seconds
            qrExpireTimer.Tick += QrExpireTimer_Tick;
        }

        private void DebugPanelState(string location)
        {
            Debug.WriteLine("===== PANEL STATE (" + location + ") =====");

            Debug.WriteLine("startPanel: " + startPanel.Visible);
            Debug.WriteLine("uploadPanel: " + uploadPanel.Visible);
            Debug.WriteLine("continuePanel: " + continuePanel.Visible);
            Debug.WriteLine("printingSettingsPanel: " + printingSettingsPanel.Visible);
            Debug.WriteLine("paymentPanel: " + paymentPanel.Visible);
            Debug.WriteLine("retrivalPanel: " + retrivalPanel.Visible);

            Debug.WriteLine("receiveTimer enabled: " + receiveTimer.Enabled);
        }

        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            if (printingInProgress)
                return;

            inactivityTimer.Stop();

            ResetMachine();
        }

        private void ReceiveTimer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("CONTINUE TIMER FIRED");

            receiveTimer.Stop();

            // DO NOT override if settings already open
            if (printingSettingsPanel.Visible)
                return;

            if (isRetrievalMode)
                return;

            ShowPanel(continuePanel);

            DebugPanelState("Timer Fired");
        }

        private void PrinterStatusTimer_Tick(object sender, EventArgs e)
        {
            string printerName = "Canon MG3000 series";

            if (!PrinterExists(printerName))
            {
                printerStatusLabel.Text = "Printer: Not Detected";
                printerStatusLabel.ForeColor = Color.Red;
                continuePaymentBtn.Enabled = false;
                return;
            }

            if (!IsPrinterOnline(printerName))
            {
                printerStatusLabel.Text = "Printer: Offline";
                printerStatusLabel.ForeColor = Color.Red;
                continuePaymentBtn.Enabled = false;
                return;
            }

            string error = GetDetailedPrinterError(printerName);

            if (error != "No Error")
            {
                printerStatusLabel.Text = "Printer: " + error;
                printerStatusLabel.ForeColor = Color.Red;
                continuePaymentBtn.Enabled = false;

                if (paymentPanel.Visible)
                {
                    MessageBox.Show("Printer problem detected. \nPlease call staff.");
                    ResetMachine();
                }

                return;
            }

            string status = GetPrinterStatus(printerName);

            printerStatusLabel.Text = "Printer: " + status;

            if (status == "Printer Ready")
            {
                printerStatusLabel.ForeColor = Color.Green;
                continuePaymentBtn.Enabled = true;
            }
            else if (status == "Printing")
            {
                printerStatusLabel.ForeColor = Color.Blue;
                continuePaymentBtn.Enabled = false;
            }
            else
            {
                printerStatusLabel.ForeColor = Color.OrangeRed;
                continuePaymentBtn.Enabled = false;
            }
        }

        public void startBtn_Click(object sender, EventArgs e)
        {
            currentUploadToken = Guid.NewGuid().ToString();
            uploadUsed = false;

            ShowPanel(uploadPanel);

            Directory.CreateDirectory(watchFolder);

            // CLEAN UPLOAD FOLDER FIRST
            foreach (var file in Directory.GetFiles(watchFolder))
            {
                try { File.Delete(file); } catch { }
            }

            if (fileWatcher == null)
                StartWatchingFolder();

            StartUploadServer();

            fileWatcher.EnableRaisingEvents = true;

            GenerateQRCode();
            qrExpireTimer.Start();
            inactivityTimer.Start();
        }

        //AFTER START QRCODE SCANNING

        private void GenerateQRCode()
        {
            string localIP = GetLocalIPAdress();
            string uploadUrl = "http://" + localIP + ":3000/print&snap_upload?token=" + currentUploadToken;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(uploadUrl, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrImage = qrCode.GetGraphic(20);

            qrPictureBox.Image = qrImage;

        }
        private string GetLocalIPAdress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with am IPv4 address found.");
        }

        private void StartUploadServer()
        {
            if (serverRunning) return;

            uploadServer = new HttpListener();
            uploadServer.Prefixes.Add("http://*:3000/");
            uploadServer.Start();

            serverRunning = true;

            Task.Run(() => HandleUploadRequests());
        }

        private async Task HandleUploadRequests()
        {
            while (serverRunning)
            {
                try
                {
                    var context = await uploadServer.GetContextAsync();

                    string token = context.Request.QueryString["token"];

                    // BLOCK ACCESS IF TOKEN INVALID
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

                    // HANDLE FILE UPLOAD
                    if (context.Request.HttpMethod == "POST")
                    {
                        // BLOCK DUPLICATE UPLOAD
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

                        string ext = Path.GetExtension(fileName).ToLower();

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

                        string filePath = Path.Combine(watchFolder, fileName);

                        long totalBytes = 0;

                        using (var fs = new FileStream(filePath, FileMode.Create))
                        {
                            byte[] buffer = new byte[8192];
                            int bytesRead;

                            while ((bytesRead = await context.Request.InputStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                totalBytes += bytesRead;

                                // FILE TOO LARGE PROTECTION
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

                                    continue;
                                }

                                await fs.WriteAsync(buffer, 0, bytesRead);
                            }
                        }

                        // LOCK SESSION AFTER SUCCESSFUL UPLOAD
                        uploadUsed = true;
                        currentUploadToken = "";

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
                        // BLOCK UPLOAD IF MACHINE BUSY
                        if (printingInProgress)
                        {
                            string htmlBusy = @"
<html>
<body style='font-family:Arial;text-align:center;margin-top:50px'>
<h2>Printer Busy</h2>
<p>The machine is currently printing.<br>Please wait for the next session.</p>
</body>
</html>";

                            byte[] bufferBusy = Encoding.UTF8.GetBytes(htmlBusy);

                            context.Response.ContentLength64 = bufferBusy.Length;
                            context.Response.OutputStream.Write(bufferBusy, 0, bufferBusy.Length);
                            context.Response.OutputStream.Close();

                            continue;
                        }

                        // BLOCK UPLOAD IF EDITING
                        if (editingDocument)
                        {
                            string htmlBusy = @"
<html>
<body style='font-family:Arial;text-align:center;margin-top:50px'>
<h2>Editing In Progress</h2>
<p>The document is currently being edited.<br>Please finish editing first.</p>
</body>
</html>";

                            byte[] bufferBusy = Encoding.UTF8.GetBytes(htmlBusy);

                            context.Response.ContentLength64 = bufferBusy.Length;
                            context.Response.OutputStream.Write(bufferBusy, 0, bufferBusy.Length);
                            context.Response.OutputStream.Close();

                            continue;
                        }

                        string htmlUpload = $@"
<html>
<head>
<meta name='viewport' content='width=device-width, initial-scale=1'>
</head>

<body style='font-family:Arial;text-align:center;margin-top:50px'>

<h2>Upload File</h2>

<input type='file' id='fileInput' accept='.pdf,.doc,.docx'/>

<script>
document.getElementById('fileInput').addEventListener('change', function(){{
    let file = this.files[0];

    fetch('/?token={currentUploadToken}', {{
        method: 'POST',
        headers: {{
            'X-File-Name': file.name
        }},
        body: file
    }}).then(() => {{
        document.body.innerHTML =
        '<h2>Upload Successful</h2><p>Please return to the printer machine.</p>';
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

                    Debug.WriteLine("Upload server error: " + ex.Message);
                }
            }
        }

        private void uploadCancelBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }

        private string DetectFileType(string path)
        {
            byte[] header = new byte[4];

            bool opened = false;

            while (!opened)
            {
                try
                {
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        fs.Read(header, 0, 4);
                    }

                    opened = true;
                }
                catch
                {
                    Thread.Sleep(300);
                }
            }

            // PDF
            if (header[0] == 0x25 && header[1] == 0x50)
                return ".pdf";

            // DOCX
            if (header[0] == 0x50 && header[1] == 0x4B)
                return ".docx";

            return "";
        }
        private void StartWatchingFolder()
        {
            if (fileWatcher != null)
                return;

            Directory.CreateDirectory(watchFolder);

            fileWatcher = new FileSystemWatcher(watchFolder);

            fileWatcher.Path = watchFolder;
            fileWatcher.Filter = "*";
            fileWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size;

            fileWatcher.Created += OnFileReceived;

            fileWatcher.EnableRaisingEvents = true;
        }

        private void OnFileReceived(object sender, FileSystemEventArgs e)
        {
            lock (processedFiles)
            {
                if (processedFiles.Contains(e.FullPath))
                {
                    Debug.WriteLine("Duplicate watcher event ignored.");
                    return;
                }

                processedFiles.Add(e.FullPath);
            }

            if (fileProcessing)
                return;

            fileProcessing = true;

            if (fileWatcher != null)
                fileWatcher.EnableRaisingEvents = false;

            Debug.WriteLine("FILE DETECTED: " + e.FullPath);

            Invoke(new Action(() =>
            {
                baseStatusText = "Preparing document";
                dotCount = 0;
                uploadStatusTimer.Start();
            }));

            lastProcessedFile = e.FullPath;

            try
            {
                string fileName = Path.GetFileName(e.FullPath);

                string ext = Path.GetExtension(fileName).ToLower();

                if (ext != ".pdf" && ext != ".docx" && ext != ".doc")
                {
                    Debug.WriteLine("Unsupported file ignored.");
                    return;
                }

                // Ignore temporary upload files
                if (fileName.EndsWith(".tmp") ||
                    fileName.StartsWith("~$") ||
                    fileName.Contains(".crdownload"))
                {
                    fileProcessing = false;
                    return;
                }

                if (fileName.StartsWith("~$") || fileName.Contains("_edit"))
                {
                    fileProcessing = false;
                    return;
                }

                WaitForFileComplete(e.FullPath);

                Thread.Sleep(1000);

                string extension = DetectFileType(e.FullPath);

                string finalPath = e.FullPath;

                if (extension != "")
                {
                    if (!e.FullPath.EndsWith(extension))
                    {
                        finalPath = e.FullPath + extension;
                        File.Move(e.FullPath, finalPath);
                    }
                }

                currentOriginalPath = finalPath;

                if (extension == ".pdf")
                {
                    currentPdfPath = finalPath;

                    Invoke(new Action(() =>
                    {
                        uploadStatusTimer.Stop();
                        fileUploadStatusLabel.Text = "PDF received successfully.";

                        editBtn.Enabled = false;
                        ProcessPdf(currentPdfPath);

                        receiveTimer.Start();
                        ShowPanel(continuePanel);
                    }));
                }
                else if (extension == ".docx")
                {
                    Invoke(new Action(() =>
                    {
                        baseStatusText = "Converting Word document";
                        dotCount = 0;
                        uploadStatusTimer.Start();
                    }));

                    editBtn.Enabled = true;

                    currentEditablePath = finalPath;

                    currentPdfPath = Path.Combine(
                        Path.GetDirectoryName(currentEditablePath),
                        Path.GetFileNameWithoutExtension(currentEditablePath) + "_preview.pdf"
                    );

                    Thread staThread = new Thread(() =>
                    {
                        ConvertWordToPdf(currentEditablePath);
                    });

                    staThread.SetApartmentState(ApartmentState.STA);
                    staThread.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Watcher error: " + ex.Message);

                Invoke(new Action(() =>
                {
                    fileUploadStatusLabel.Text = "Error processing file.";
                }));
            }
            finally
            {
                fileProcessing = false;

                try
                {
                    if (File.Exists(e.FullPath) && e.FullPath != currentOriginalPath)
                        File.Delete(e.FullPath);
                }
                catch { }

            }
            Invoke(new Action(() =>
            {
                ResetInactivityTimer();
            }));
        }

        private void ConvertWordToPdf(string docPath)
        {
            WaitForFileRelease(docPath);

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            string newPdfPath = Path.Combine(
                @"C:\PrinterVendo\preview",
                Path.GetFileNameWithoutExtension(docPath) + "_preview_" + timestamp + ".pdf"
            );

            Word.Application wordApp = null;
            Word.Document doc = null;

            try
            {
                // REMOVE READ-ONLY ATTRIBUTE
                File.SetAttributes(docPath, FileAttributes.Normal);

                // DELETE OLD PREVIEW IF EXISTS
                if (File.Exists(newPdfPath))
                {
                    File.Delete(newPdfPath);
                }

                wordApp = new Word.Application();
                wordApp.Visible = false;
                wordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;

                // OPEN WORD FILE AS READONLY
                doc = wordApp.Documents.Open(docPath, ReadOnly: true, Visible: false);

                doc.ExportAsFixedFormat(
                    newPdfPath,
                    Word.WdExportFormat.wdExportFormatPDF
                );
            }
            finally
            {
                try
                {
                    if (doc != null)
                    {
                        doc.Close(false);
                        Marshal.ReleaseComObject(doc);
                    }

                    if (wordApp != null)
                    {
                        wordApp.Quit();
                        Marshal.ReleaseComObject(wordApp);
                    }
                }
                catch { }

                doc = null;
                wordApp = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            Invoke(new Action(() =>
            {
                LoadNewPreview(newPdfPath);
            }));
        }

        private void WaitForFileRelease(string path)
        {
            bool ready = false;

            while (!ready)
            {
                try
                {
                    using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        ready = true;
                    }
                }
                catch
                {
                    Thread.Sleep(500);
                }
            }
        }

        private void WaitForFileComplete(string path)
        {
            long lastSize = -1;

            while (true)
            {
                try
                {
                    FileInfo file = new FileInfo(path);

                    if (file.Length == lastSize)
                        break;

                    lastSize = file.Length;

                    Thread.Sleep(500);
                }
                catch 
                {
                    Thread.Sleep(500);
                }
            }

            Thread.Sleep(500);
        }

        //PrintSettings

        private void LoadNewPreview(string newPdfPath)
        {
            Debug.WriteLine("PDF PREVIEW LOADED");

            ResetPdfViewer();

            pdfViewer = new PdfViewer();
            pdfViewer.Dock = DockStyle.Fill;

            previewPanelSettingLayout.Controls.Add(pdfViewer);

            var newDoc = PdfDocument.Load(newPdfPath);

            pdfViewer.Document = newDoc;

            currentPdfPath = newPdfPath;

            totalPages = newDoc.PageCount;
            totalPagesLabel.Text = totalPages.ToString();

            if (!isRetrievalMode && !printingSettingsPanel.Visible)
            {
                receiveTimer.Start();
                ShowPanel(continuePanel);
            }
            else if (printingSettingsPanel.Visible)
            {
                MessageBox.Show(
                    "Document Updated successfully.",
                    "File updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            DebugPanelState("LoadNewPreview");
        }


        private void UnblockFile(String filePath)
        {
            try
            {
                string zoneFile = filePath + ":Zone.Identifier";
                if (File.Exists(zoneFile))
                {
                    File.Delete(zoneFile);
                }
            }
            catch { }
        }
        private void ProcessPdf(string filePath)
        {
            Debug.WriteLine("PROCESS PDF: " + filePath);

            currentPdfPath = filePath;

            ResetPdfViewer(); // ensure old viewer is gone

            pdfViewer = new PdfViewer();
            pdfViewer.Dock = DockStyle.Fill;

            previewPanelSettingLayout.Controls.Clear();
            previewPanelSettingLayout.Controls.Add(pdfViewer);

            byte[] pdfBytes = File.ReadAllBytes(filePath);
            var newDoc = PdfDocument.Load(new MemoryStream(pdfBytes));

            pdfViewer.Document = newDoc;

            totalPages = newDoc.PageCount;
            totalPagesLabel.Text = totalPages.ToString();

            // BLOCK VERY LARGE DOCUMENTS
            if (totalPages > MAX_ALLOWED_PAGES)
            {
                MessageBox.Show(
                    "This document has " + totalPages + " pages.\n" +
                    "Maximum allowed pages is " + MAX_ALLOWED_PAGES + ".",
                    "Document Too Large",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                ResetMachine();
                return;
            }

            if (!colorAnalysisDone)
            {
                baseStatusText = "Analyzing document colors";
                dotCount = 0;
                uploadStatusTimer.Start();

                Application.DoEvents();
                AnalyzeDocumentColors();

                uploadStatusTimer.Stop();
            }

            numericSinglePage.Minimum = 1;
            numericSinglePage.Maximum = totalPages;
            numericSinglePage.Value = 1;
        }

        private void ResetPdfViewer()
        {
            try
            {
                if (pdfViewer != null)
                {
                    if (pdfViewer.Document != null)
                    {
                        pdfViewer.Document.Dispose();
                        pdfViewer.Document = null;
                    }

                    previewPanelSettingLayout.Controls.Remove(pdfViewer);
                    pdfViewer.Dispose();
                    pdfViewer = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch { }
        }

        private void numericCopies_ValueChanged(Object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            int copies = (int)numericCopies.Value;
            int pagesToPrint = totalPages;

            if (radioPrintAll.Checked)
                pagesToPrint = totalPages;
            else if (radioSinglePage.Checked)
                pagesToPrint = 1;
            else if (radioPrintRange.Checked)
                pagesToPrint = CountSelectedPages(numericPageRange.Text);

            int total = 0;

            if (radioBlackWhite.Checked)
            {
                total = pagesToPrint * copies * bwPrice;

            }
            else if (radioColored.Checked)
            {
                int selectedTotal = 0;

                if (radioPrintAll.Checked)
                {
                    for (int i = 0; i < pageIsColored.Count; i++)
                    {
                        selectedTotal += pageIsColored[i] ? colorPrice : bwPrice;
                    }
                }
                else if (radioSinglePage.Checked)
                {
                    int pageIndex = (int)numericSinglePage.Value - 1;

                    if (pageIndex >= 0 && pageIndex < pageIsColored.Count)
                        selectedTotal = pageIsColored[pageIndex] ? 10 : 5;
                }
                else if (radioPrintRange.Checked)
                {
                    if (string.IsNullOrWhiteSpace(numericPageRange.Text) ||
                        !numericPageRange.Text.Contains("-"))
                        return;

                    var parts = numericPageRange.Text.Split('-');

                    if (parts.Length != 2)
                        return;

                    if (!int.TryParse(parts[0], out int start) ||
                        !int.TryParse(parts[1], out int end))
                        return;

                    start -= 1;
                    end -= 1;

                    if (start < 0 || end >= pageIsColored.Count || start > end)
                        return;

                    for (int i = start; i <= end; i++)
                    {
                        selectedTotal += pageIsColored[i] ? 10 : 5;
                    }
                }

                total = selectedTotal * copies;
            }
            totalPrice = total;
            totalLabel.Text = "₱" + total.ToString();
        }
        private void AnalyzeDocumentColors()
        {
            pageIsColored.Clear();

            using (var document = PdfDocument.Load(currentPdfPath))
            {
                for (int i = 0; i < document.PageCount; i++)
                {
                    using (var img = document.Render(i, 50, 50, true))
                    using (var bmp = new Bitmap(img))
                    {
                        bool hasColor = PageHasColorFast(bmp);
                        pageIsColored.Add(hasColor);
                    }
                }
            }

            colorAnalysisDone = true;
        }

        private bool PageHasColorFast(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            //Sample every 5 pixels (much faster)
            for (int x = 0; x < width; x += 5)
            {
                for (int y = 0; y < height; y += 5)
                {
                    Color pixel = bitmap.GetPixel(x, y);

                    // check if pixel is not grayscale
                    if (pixel.R != pixel.G || pixel.G != pixel.B)
                    {
                        return true;
                    }
                } 
            }

            return false;
        }

        private void UpdateModeUI()
        {
            numericSinglePage.Enabled = radioSinglePage.Checked;
            numericPageRange.Enabled = radioPrintRange.Checked;

            if (!radioPrintRange.Checked)
            {
                numericPageRange.ForeColor = Color.Gray;
                numericPageRange.Text = "e.g. 1-5";
            }
        }

        private int CountSelectedPages(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input == "e.g. 1-5")
                return 0;

            try
            {
                if (input.Contains("-"))
                {
                    var parts = input.Replace(" ", "").Split('-');

                    if (parts.Length != 2)
                        return 0;

                    if (!int.TryParse(parts[0], out int start) ||
                        !int.TryParse(parts[1], out int end))
                        return 0;

                    if (start >= 1 && end <= totalPages && start <= end)
                        return end - start + 1;
                }
                else
                {
                    if (int.TryParse(input, out int single))
                    {
                        if (single >= 1 && single <= totalPages)
                            return 1;
                    }
                }
            }
            catch { }

            return 0;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentEditablePath))
                return;

            this.TopMost = false;

            editingDocument = true;

            Process wordProcess = Process.Start(currentEditablePath);
            wordProcess.WaitForExit();

            editingDocument = false;

            this.TopMost = true;

            Thread staThread = new Thread(() =>
            {
                ConvertWordToPdf(currentEditablePath);
            });

            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
        }

        private void SetupPlaceholder()
        {
            numericPageRange.Text = "e.g. 1-5";
            numericPageRange.ForeColor = Color.Gray;

            numericPageRange.Enter += (s, e) =>
            {
                if (numericPageRange.Text == "e.g. 1-5")
                {
                    numericPageRange.Text = "";
                    numericPageRange.ForeColor = Color.Black;
                }
            };

            numericPageRange.Leave += (s, e) =>
            {
                if (numericPageRange.Text == "")
                {
                    numericPageRange.Text = "e.g. 1-5";
                    numericPageRange.ForeColor = Color.Gray;
                }
            };
        }

        //Cancel Button Print Settings

        private void printSettingsCancelBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }

        //Continue Button to Print Settings

        private void continueBtn_Click(object sender, EventArgs e)
        {

            Debug.WriteLine("CONTINUE BUTTON CLICKED");

            receiveTimer.Stop();

            ShowPanel(printingSettingsPanel);

            settingsPanel.Visible = true;
            settingsPanel.BringToFront();

            numericCopies.Value = 1;
            radioPrintAll.Checked = true;

            UpdateModeUI();
            CalculateTotal();
        }

        //Payment

        private void proceedBtn_Click(object sender, EventArgs e)
        {

            string printerName = "Canon MG3000 series";

            if (!IsPrinterReady(printerName))
            {
                MessageBox.Show("Printer is not ready.\nPlease check paper or printer connection.");
                return;
            }

            totalPayment.Text = "₱" + totalPrice.ToString();

            insertedMoney = 0;
            paymentBalance.Text = "₱" + totalPrice.ToString();

            printBtn.Enabled = false;

            settingsPanel.Hide();
            paymentPanel.Show();
            paymentPanel.BringToFront();
        }

        //PaymentButtons for test remove later if the payment method is here

        private void btn5_Click(object sender, EventArgs e)
        {
            AddMoney(5);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            AddMoney(10);
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            AddMoney(20);
        }

        private void AddMoney(int amount)
        {

            insertedMoney += amount;

            int remaining = totalPrice - insertedMoney;

            if (remaining < 0)
                remaining = 0;

            paymentBalance.Text = "₱" + remaining.ToString();

            if (remaining == 0)
            {
                printBtn.Enabled = true;
            }
            else
            {
                printBtn.Enabled = false;
            }
        }

        private void PrintDocumentFile()
        {
            printSuccess = false;

            try
            {
                string printerName = "Canon MG3000 series";

                if (!PrinterExists(printerName) || !IsPrinterOnline(printerName))
                {
                    ClearPrinterQueue(printerName);

                    Invoke(new Action(() =>
                    {
                        printingStatusLabel.Text = "Printer not available. Please call staff.";
                        printBtn.Enabled = true;
                    }));
                    return;
                }

                if (!File.Exists(currentPdfPath))
                {
                    MessageBox.Show("File not found.");
                    return;
                }

                using (var document = PdfDocument.Load(currentPdfPath))
                {
                    int startPage = 1;
                    int endPage = totalPages;

                    // SINGLE PAGE
                    if (radioSinglePage.Checked)
                    {
                        startPage = (int)numericSinglePage.Value;
                        endPage = startPage;
                    }

                    // RANGE
                    else if (radioPrintRange.Checked && numericPageRange.Text.Contains("-"))
                    {
                        var parts = numericPageRange.Text.Split('-');

                        startPage = int.Parse(parts[0]);
                        endPage = int.Parse(parts[1]);
                    }

                    // PRINT PAGE BY PAGE
                    for (int page = startPage; page <= endPage; page++)
                    {
                        var printDoc = document.CreatePrintDocument();

                        printDoc.PrinterSettings.PrinterName = printerName;

                        printDoc.PrintController =
                            new System.Drawing.Printing.StandardPrintController();

                        printDoc.PrinterSettings.PrintRange =
                            System.Drawing.Printing.PrintRange.SomePages;

                        printDoc.PrinterSettings.FromPage = page;
                        printDoc.PrinterSettings.ToPage = page;

                        // COLOR OR BW
                        if (radioColored.Checked && pageIsColored.Count >= page)
                        {
                            bool isColor = pageIsColored[page - 1];
                            printDoc.DefaultPageSettings.Color = isColor;
                        }
                        else
                        {
                            printDoc.DefaultPageSettings.Color = false;
                        }

                        printDoc.Print();
                    }

                    printSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ClearPrinterQueue("Canon MG3000 series");

                Invoke(new Action(() =>
                {
                    printingStatusLabel.Text = "Printing error.";
                }));

                MessageBox.Show("Printing error: " + ex.Message);
            }
        }

        private async void printBtn_Click(object sender, EventArgs e)
        {
            printBtn.Enabled = false;

            printingStatusLabel.Text = "Printing in progress...";
            printingStatusLabel.Visible = true;

            printingInProgress = true;

            await Task.Run(() =>
            {
                PrintDocumentFile();
            });

            printingInProgress = false;

            if (printSuccess)
            {
                printingStatusLabel.Text = "Printing completed.";
            }
            else
            {
                printingStatusLabel.Text = "Printing failed.";
                return;
            }

            string code = GenerateRetrivalCode();

            string archiveFolder = @"C:\PrinterVendo\archive";
            Directory.CreateDirectory(archiveFolder);

            string newPath = Path.Combine(
                archiveFolder,
                code + "_" + Path.GetFileName(currentPdfPath)
            );

            try
            {
                // RELEASE PDF VIEWER FIRST
                if (pdfViewer != null)
                {
                    try
                    {
                        if (pdfViewer.Document != null)
                        {
                            pdfViewer.Document.Dispose();
                        }

                        previewPanelSettingLayout.Controls.Remove(pdfViewer);
                        pdfViewer.Dispose();
                        pdfViewer = null;
                    }
                    catch { }
                }

                // small delay so Windows releases the file lock
                Thread.Sleep(3000);

                // MOVE FILE TO ARCHIVE
                if (File.Exists(currentPdfPath))
                {
                    File.Move(currentPdfPath, newPath);
                }

                string previewFolder = @"C:\PrinterVendo\preview";

                foreach (var file in Directory.GetFiles(previewFolder))
                {
                    File.Delete(file);
                }

                if (!string.IsNullOrEmpty(currentOriginalPath) && File.Exists(currentOriginalPath))
                {
                    File.Delete(currentOriginalPath);
                }
            }
            catch { }

            MessageBox.Show("Retrieval Code: " + code + "\nYou can reprint within 30 minutes.");

            await Task.Delay(2000);

            ResetMachine();
        }
        private void ResetMachine()
        {
            // STOP TIMERS
            inactivityTimer.Stop();
            receiveTimer.Stop();

            // CLEAR PREVIEW
            ResetPdfViewer();
            previewPanelSettingLayout.Controls.Clear();

            isRetrievalMode = false;

            // RESET FILE PATHS
            currentPdfPath = null;
            currentEditablePath = null;
            currentOriginalPath = null;
            currentUploadToken = null;
            lastProcessedFile = "";

            // RESET UPLOAD SESSION
            uploadUsed = false;
            processedFiles.Clear();

            // RESET PRINT DATA
            totalPrice = 0;
            insertedMoney = 0;
            totalPages = 1;
            colorAnalysisDone = false;

            // RESET LABELS
            totalLabel.Text = "₱0";
            paymentBalance.Text = "₱0";
            totalPagesLabel.Text = "0";

            // RESET BUTTONS
            printBtn.Enabled = false;

            // RESTART WATCHER
            if (fileWatcher != null)
                fileWatcher.EnableRaisingEvents = true;

            // CLEAN UPLOAD FOLDER
            string uploadFolder = @"C:\PrinterVendo\uploads";

            if (Directory.Exists(uploadFolder))
            {
                foreach (var file in Directory.GetFiles(uploadFolder))
                {
                    try { File.Delete(file); } catch { }
                }
            }

            // CLEAN PREVIEW FOLDER
            string previewFolder = @"C:\PrinterVendo\preview";

            if (Directory.Exists(previewFolder))
            {
                foreach (var file in Directory.GetFiles(previewFolder))
                {
                    try { File.Delete(file); } catch { }
                }
            }

            // HIDE PANELS
            continuePanel.Visible = false;
            printingSettingsPanel.Visible = false;

            // RETURN TO START SCREEN
            ShowPanel(startPanel);
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }

        private void paymentBackBtn_Click(object sender, EventArgs e)
        {
            insertedMoney = 0;

            paymentBalance.Text = "₱" + totalPrice.ToString();
            printBtn.Enabled = false;

            CalculateTotal();

            paymentPanel.Hide();
            settingsPanel.Show();
            settingsPanel.BringToFront();
        }

        //RETRIVAL
        private string GenerateRetrivalCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            return new string(Enumerable.Range(0, 6)
                .Select(x => chars[rand.Next(chars.Length)]).ToArray());
        }
        private void LoadRetrievalFile(string code)
        {
            string archiveFolder = @"C:\PrinterVendo\archive";

            if (!Directory.Exists(archiveFolder))
            {
                MessageBox.Show("Archive folder not found.");
                return;
            }

            var file = Directory.GetFiles(archiveFolder)
                .FirstOrDefault(f => Path.GetFileName(f).StartsWith(code + "_"));

            if (file == null)
            {
                MessageBox.Show("Invalid or expired retrieval code.");
                return;
            }

            try
            {
                isRetrievalMode = true;

                receiveTimer.Stop();

                if (fileWatcher != null)
                    fileWatcher.EnableRaisingEvents = false;

                currentPdfPath = file;

                // SHOW PRINT SETTINGS SCREEN
                ShowPanel(printingSettingsPanel);

                // IMPORTANT FIX
                paymentPanel.Visible = false;
                settingsPanel.Visible = true;
                settingsPanel.BringToFront();

                ProcessPdf(currentPdfPath);

                numericCopies.Value = 1;
                radioPrintAll.Checked = true;

                UpdateModeUI();
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Retrieval error: " + ex.Message);
            }
        }
        private void loadRetrievalBtn_Click(object sender, EventArgs e)
        {

            string code = retrivalCodeTextBox.Text.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Please enter a retrieval code.");
                return;
            }

            LoadRetrievalFile(code);
        }
        private void CleanupTimer_Tick(object sender, EventArgs e)
        {
            if (printingInProgress)
                return;

            string archiveFolder = @"C:\PrinterVendo\archive";
            string previewFolder = @"C:\PrinterVendo\preview";

            // CLEAN ARCHIVE (30 minutes)
            if (Directory.Exists(archiveFolder))
            {
                foreach (var file in Directory.GetFiles(archiveFolder))
                {
                    try
                    {
                        if (file == currentPdfPath)
                            continue;

                        DateTime created = File.GetCreationTime(file);

                        if (DateTime.Now - created > TimeSpan.FromMinutes(30))
                        {
                            File.Delete(file);
                        }
                    }
                    catch { }
                }
            }

            // CLEAN PREVIEW (10 minutes)
            if (Directory.Exists(previewFolder))
            {
                foreach (var file in Directory.GetFiles(previewFolder))
                {
                    try
                    {
                        if (file == currentPdfPath)
                            continue;

                        DateTime created = File.GetCreationTime(file);

                        if (DateTime.Now - created > TimeSpan.FromMinutes(10))
                        {
                            File.Delete(file);
                        }
                    }
                    catch { }
                }
            }
        }
        private void retrievalCodeTextBox_Keypress(object sender, KeyPressEventArgs e)
        {
            if  (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void retrieveCancelBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }
        private void retrieveBtn_click(object sender, EventArgs e)
        {
            retrivalCodeTextBox.Text = "";
            ShowPanel(retrivalPanel);
        }
    }
}
