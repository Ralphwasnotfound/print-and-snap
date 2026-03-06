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

namespace Printer_Vendo
{

    public partial class PrinterPhotoVendo : Form
    {
        private string watchFolder = @"C:\PrinterVendo";
        private string currentPdfPath;
        private int totalPages = 1;
        private int pricePerPage = 5;
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


        private void ShowPanel(Panel panel)
        {
            startPanel.Visible = false;
            uploadPanel.Visible = false;
            printingSettingsPanel.Visible = false;
            paymentPanel.Visible = false;

            panel.Visible = true;
            panel.BringToFront();
        }

        private void Printer_Vendo_Load(object sender, EventArgs e)
        {
            uploadPanel.Visible = false;
            printingSettingsPanel.Visible = false;
            continuePanel.Visible = false;
            startPanel.Visible = true;

            receiveTimer = new System.Windows.Forms.Timer();
            receiveTimer.Interval = 3000;
            receiveTimer.Tick += ReceiveTimer_Tick;

        }

        private void ReceiveTimer_Tick(object sender, EventArgs e)
        {
            receiveTimer.Stop();

            // After 5 seconds go to Continue panel
            continuePanel.Visible = true;
            continuePanel.BringToFront();
        }

        public void startBtn_Click(object sender, EventArgs e)
        {
            currentUploadToken = Guid.NewGuid().ToString();
            uploadUsed = false;

            ShowPanel(uploadPanel);

            Directory.CreateDirectory(watchFolder);

            foreach (var file in Directory.GetFiles(watchFolder))
            {
                try { File.Delete(file); } catch { }
            }

            StartUploadServer();
            StartWatchingFolder();

            GenerateQRCode();
        }

        //AFTER START QRCODE SCANNING

        private void GenerateQRCode()
        {
            string localIP = GetLocalIPAdress();
            string uploadUrl = "http://" + localIP + ":8080/print&snap_upload?token=" + currentUploadToken;

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
            uploadServer.Prefixes.Add("http://*:8080/");
            uploadServer.Start();

            serverRunning = true;

            Task.Run(() => HandleUploadRequests());
        }

        private async Task HandleUploadRequests()
        {
            while (serverRunning)
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
                    string fileName = context.Request.Headers["X-File-Name"];

                    if (string.IsNullOrEmpty(fileName))
                        fileName = "upload_" + DateTime.Now.Ticks;

                    string filePath = Path.Combine(watchFolder, fileName);

                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await context.Request.InputStream.CopyToAsync(fs);
                    }

                    // LOCK SESSION
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
            Directory.CreateDirectory(watchFolder);

            fileWatcher = new FileSystemWatcher(watchFolder);
            fileWatcher.Path = watchFolder;
            fileWatcher.Filter = "*.*";
            fileWatcher.Created += OnFileReceived;
            fileWatcher.EnableRaisingEvents = true;

        }

        private void OnFileReceived(object sender, FileSystemEventArgs e)
        {

            string fileName = Path.GetFileName(e.FullPath);

            if (fileName.StartsWith("~$") || fileName.Contains("_edit"))
            {
                return;
            }

            bool ready = false;

            while (!ready)
            {
                try
                {
                    FileInfo file = new FileInfo(e.FullPath);
                    if (file.Length > 0)
                    {
                        ready = true;
                    }
                }
                catch
                {
                    Thread.Sleep(500);
                }
            }

            Thread.Sleep(1000);

            string extension = DetectFileType(e.FullPath);

            string finalPath = e.FullPath;

            if (extension != "")
            {
                finalPath = e.FullPath + extension;
                File.Move(e.FullPath, finalPath);
            }

            currentOriginalPath = finalPath;

            if (extension == ".pdf")
            {
                currentPdfPath = finalPath;
                editBtn.Enabled = false;
                ProcessPdf(currentPdfPath);
            }
            else if (extension == ".docx")
            {
                editBtn.Enabled = true;

                currentEditablePath = finalPath;

                // Preview PDF path
                currentPdfPath = Path.Combine(
                    Path.GetDirectoryName(currentEditablePath),
                    Path.GetFileNameWithoutExtension(currentEditablePath) + "_preview.pdf"
                );

                Invoke(new Action(() =>
                {

                }));

                Thread staThread = new Thread(() =>
                {
                    ConvertWordToPdf(currentEditablePath);
                });

                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start();
            }
        }

        private void ConvertWordToPdf(string docPath)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            string newPdfPath = Path.Combine(
                Path.GetDirectoryName(docPath),
                Path.GetFileNameWithoutExtension(docPath) + "_preview_" + timestamp + ".pdf"
            );

            Word.Application wordApp = null;
            Word.Document doc = null;

            try
            {
                wordApp = new Word.Application();
                wordApp.Visible = false;
                wordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;

                doc = wordApp.Documents.Open(docPath, ReadOnly: false, Visible: false);

                doc.ExportAsFixedFormat(
                    newPdfPath,
                    Word.WdExportFormat.wdExportFormatPDF
                );

                doc.Close(false);
                wordApp.Quit();
            }
            finally
            {
                if (doc != null) Marshal.ReleaseComObject(doc);
                if (wordApp != null) Marshal.ReleaseComObject(wordApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            Invoke(new Action(() =>
            {
                LoadNewPreview(newPdfPath);
            }));
        }

        //PrintSettings

        private void LoadNewPreview(string newPdfPath)
        {
            if (pdfViewer == null)
            {
                pdfViewer = new PdfViewer();
                pdfViewer.Dock = DockStyle.Fill;
                previewPanel.Controls.Add(pdfViewer);
            }

            var newDoc = PdfDocument.Load(newPdfPath);

            if (pdfViewer.Document != null)
            {
                pdfViewer.Document.Dispose();

                // delete old preview file
                try
                {
                    File.Delete(currentPdfPath);
                }
                catch { }
            }

            pdfViewer.Document = newDoc;

            currentPdfPath = newPdfPath;

            totalPages = newDoc.PageCount;
            totalPagesLabel.Text = totalPages.ToString();


            receiveTimer.Start();
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
            Invoke(new Action(() =>
            {
                currentPdfPath = filePath;

                if (pdfViewer == null)
                {
                    pdfViewer = new PdfViewer();
                    pdfViewer.Dock = DockStyle.Fill;
                    previewPanel.Controls.Add(pdfViewer);
                }

                var newDoc = PdfDocument.Load(filePath);

                if (pdfViewer.Document != null)
                {
                    pdfViewer.Document.Dispose();
                }

                pdfViewer.Document = newDoc;

                totalPages = newDoc.PageCount;
                totalPagesLabel.Text = totalPages.ToString();

                numericSinglePage.Minimum = 1;
                numericSinglePage.Maximum = totalPages;
                numericSinglePage.Value = 1;


                receiveTimer.Start();
            }));
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
            totalLabel.Text = "₱" + total.ToString();
        }
        private void AnalyzeDocumentColors()
        {
            pageIsColored.Clear();

            using (var document = PdfDocument.Load(currentPdfPath))
            {
                for (int i = 0; i < document.PageCount; i++)
                {
                    using (var img = document.Render(i, 100, 100, true))
                    using (var bmp = new Bitmap(img))
                    {
                        bool hasColor = PageHasColor(bmp);
                        pageIsColored.Add(hasColor);
                    }
                }
            }
            //DEBUG MESSAGE HERE
            int coloredCount = pageIsColored.Count(p => p);
            int bwCount = pageIsColored.Count - coloredCount;

            Debug.WriteLine($"Colored: {coloredCount}, BW: {bwCount}");

            colorAnalysisDone = true;
        }

        private bool PageHasColor(Bitmap bitmap)
        {
            for (int x = 0; x < bitmap.Width; x += 5)
            {
                for (int y = 0; y < bitmap.Height; y += 5)
                {
                    Color pixel = bitmap.GetPixel(x, y);

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
            if (input == "e.g. 1-5")
                return 0;

            try
            {
                if (input.Contains("-"))
                {
                    var parts = input.Split('-');
                    int start = int.Parse(parts[0]);
                    int end = int.Parse(parts[1]);

                    if (start >= 1 && end <= totalPages && start <= end)
                        return end - start + 1;
                }
                else
                {
                    int single = int.Parse(input);
                    if (single >= 1 && single <= totalPages)
                        return 1;
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

            Process wordProcess = Process.Start(currentEditablePath);
            wordProcess.WaitForExit();

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

        //Continue Button to Print Settings

        private void continueBtn_Click(object sender, EventArgs e)
        {
            continuePanel.Visible = false;
            ShowPanel(printingSettingsPanel);


            numericCopies.Value = 1;

            radioPrintAll.Checked = true;

            UpdateModeUI();

            CalculateTotal();

        }

        //Payment

        private void proceedBtn_Click(object sender, EventArgs e)
        {
            paymentTotalLabel.Text = totalLabel.Text;

            ShowPanel(paymentPanel);
        }

        private void PrintDocumentFile()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = currentPdfPath;
            psi.Verb = "print";
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            PrintDocumentFile();

            MessageBox.Show("Printing...");

            ResetMachine();
        }

        private void ResetMachine()
        {
            currentPdfPath = null;
            currentEditablePath = null;
            currentUploadToken = null;
            colorAnalysisDone  = false;

            if (pdfViewer != null && pdfViewer.Document != null)
            {
                pdfViewer.Document.Dispose();
            }

            ShowPanel(startPanel);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }

        private void uploadPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void settingsLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void settingsTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void totalPagesLabel_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void previewPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void paymentBottom_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
