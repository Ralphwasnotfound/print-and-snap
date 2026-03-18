using PdfiumViewer;
using PrintAndSnap.Services;
using PrintAndSnap.Services.Printing;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Word = Microsoft.Office.Interop.Word;


namespace PrintAndSnap
{

    public partial class PrintAndSnap : Form
    {
        //SERVICES
        private UploadServices uploadService = new UploadServices();
        private DocumentPrinting documentPrinting = new DocumentPrinting();
        private PrinterManager printerManager = new PrinterManager();
        private PricingService pricingService = new PricingService();

        //FILE + DOCUMENTS STATE
        private string watchFolder = @"C:\PrinterVendo\uploads";
        private string currentPdfPath;
        private string currentOriginalPath;
        private string currentEditablePath;
        private PdfViewer pdfViewer;

        private int totalPages = 1;
        private bool colorAnalysisDone = false;
        private List<bool> pageIsColored = new List<bool>();
        
        //FILE WATCHER
        private FileSystemWatcher fileWatcher;
        private HashSet<string> processedFiles = new HashSet<string>();
        private string lastProcessedFile = "";
        private bool fileProcessing = false;

        //PAYMENT + PRINTING STATE
        private int totalPrice = 0;
        private int insertedMoney = 0;
        private bool printingInProgress = false;
        private bool isRetrievalMode = false;
        private bool printSuccess = false;

        //LIMITS
        private const long MAX_UPLOAD_SIZE = 20 * 1024 * 1024;
        private const int MAX_ALLOWED_PAGES = 50;

        //TIMERS
        private System.Windows.Forms.Timer cleanupTimer;
        private System.Windows.Forms.Timer printerStatusTimer;
        private System.Windows.Forms.Timer inactivityTimer;
        private System.Windows.Forms.Timer qrExpireTimer;
        private System.Windows.Forms.Timer uploadStatusTimer;

        //UI STATE
        private int dotCount = 0;
        private string baseStatusText = "";

        //SYSTEM HOOK
        private IntPtr hookID = IntPtr.Zero;


        public PrintAndSnap()
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
                    if (!string.IsNullOrEmpty(currentPdfPath))
                    {
                        pageIsColored = pricingService.AnalyzeDocumentColors(currentPdfPath);
                        colorAnalysisDone = true;
                    }
                }

                CalculateTotal();
            };

            Application.ApplicationExit += (s, e) =>
            {
                ShowTaskbar();
            };
        }

        //WINDOWS API(DLL IMPORTS)
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


        //LOAD
        private void Print_And_Snap_Load(object sender, EventArgs e)
        {
#if !DEBUG
            //enable this for production
            {
                Process.Start("taskkill", "/f /im explorer.exe");
            }  
#endif
            printerManager.ClearPrinterQueue();
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


        //TASKBAR METHODS
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


        //PANEL METHODS
        private void showPanel(Panel panel)
        {
            // ONLY hide known panels (SAFE)
            startPanel.Visible = false;
            printingOptionsPanel.Visible = false;
            uploadPanel.Visible = false;
            continuePanel.Visible = false;
            printingSettingsPanel.Visible = false;
            paymentPanel.Visible = false;
            retrivalPanel.Visible = false;

            // SHOW target
            panel.Visible = true;
            panel.BringToFront();
        }

        private void HidePanelsRecursive(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Panel)
                    c.Visible = false;

                if (c.HasChildren)
                    HidePanelsRecursive(c);
            }
        }


        //FORM EVENTS//
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
        protected override void OnMouseDown(MouseEventArgs e)
        {
            ResetInactivityTimer();
            base.OnMouseDown(e);
        }


        //INPUT BLOCKING / HOOK //
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


        // TIMERS//
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

            if (!uploadService.uploadUsed)
            {
                fileUploadStatusLabel.Text = "QR Code expired. Please press Start again.";
                ResetMachine();
            }
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

            showPanel(continuePanel);

            DebugPanelState("Timer Fired");
        }
        private void PrinterStatusTimer_Tick(object sender, EventArgs e)
        {
            string printerName = "Canon MG3000 series";

            if (!printerManager.PrinterExists(printerName))
            {
                printerStatusLabel.Text = "Printer: Not Detected";
                printerStatusLabel.ForeColor = Color.Red;
                continuePaymentBtn.Enabled = false;
                return;
            }

            if (!printerManager.IsPrinterOnline(printerName))
            {
                printerStatusLabel.Text = "Printer: Offline";
                printerStatusLabel.ForeColor = Color.Red;
                continuePaymentBtn.Enabled = false;
                return;
            }

            string error = printerManager.GetDetailedPrinterError(printerName);

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

            string status = printerManager.GetPrinterStatus(printerName);

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


       
        //START/UPLOAD FLOW//
  
        public void startBtn_Click(object sender, EventArgs e)
        {

            showPanel(printingOptionsPanel);
            
            inactivityTimer.Start();
        }

        private void docPrintingBtn_Click(Object sender, EventArgs e)
        {
            showPanel(printPanel);

            uploadService.GenerateNewToken();

            //CLEAN UPLOAD FOLDER
            foreach (var file in Directory.GetFiles(watchFolder))
            {
                try { File.Delete(file); } catch { } 
            }

            //START WATCHER
            if (fileWatcher == null)
                StartWatchingFolder();

            fileWatcher.EnableRaisingEvents = false;
            fileWatcher.EnableRaisingEvents = true;

            //QR
            qrPictureBox.Image = uploadService.GenerateQRCode();

            uploadService.StartUploadServer();

            qrExpireTimer.Start();
            inactivityTimer.Start();

            uploadPanel.Visible = true;
        }

        private void photoPrintingBtn_Click(Object sender, EventArgs e)
        {
            showPanel(photoPanel);

            photoMode.Visible = true;
        }

        private void uploadCancelBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }

        private void StartWatchingFolder()
        {
            if (fileWatcher != null)
                return;

            Directory.CreateDirectory(watchFolder);

            fileWatcher = new FileSystemWatcher(watchFolder);

            fileWatcher.Path = watchFolder;
            fileWatcher.Filter = "*.*";
            fileWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size;

            fileWatcher.Created += OnFileReceived;
            fileWatcher.Changed += OnFileReceived;

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


        //DOCUMENT PROCESSING
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
                if (!string.IsNullOrEmpty(currentPdfPath))
                {
                    pageIsColored = pricingService.AnalyzeDocumentColors(currentPdfPath);
                    colorAnalysisDone = true;
                }

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
                showPanel(continuePanel);
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


        //PRINT SETTINGS
        private void numericCopies_ValueChanged(Object sender, EventArgs e)
        {
            CalculateTotal();
        }
        private void CalculateTotal()
        {
            int total = pricingService.CalculateTotal(
                totalPages,
                (int)numericCopies.Value,
                radioPrintAll.Checked,
                radioSinglePage.Checked,
                (int)numericSinglePage.Value,
                radioPrintRange.Checked,
                numericPageRange.Text,
                radioColored.Checked,
                pageIsColored
            );

            totalPrice = total;
            totalLabel.Text = "₱" + total;
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


        //PAYMENT
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
        private void proceedBtn_Click(object sender, EventArgs e)
        {

            string printerName = "Canon MG3000 series";

            if (!printerManager.IsPrinterReady(printerName))
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


        //PRINTING
        private bool IsPrinterReady(string printerName)
        {
            if (!printerManager.PrinterExists(printerName))
                return false;

            if (!printerManager.IsPrinterOnline(printerName))
                return false;

            string status = printerManager.GetPrinterStatus(printerName);

            if (status == "Printer Ready" || status == "Printing")
                return true;

            return false;
        }
        private async void printBtn_Click(object sender, EventArgs e)
        {
            printBtn.Enabled = false;

            printingStatusLabel.Text = "Printing in progress...";
            printingStatusLabel.Visible = true;

            printingInProgress = true;

            await Task.Run(() =>
            {
                bool success = documentPrinting.PrintDocumentFile(
                    currentPdfPath,
                    "Canon MG3000 series",
                    totalPages,
                    radioSinglePage.Checked,
                    (int)numericSinglePage.Value,
                    radioPrintRange.Checked,
                    numericPageRange.Text,
                    radioColored.Checked,
                    pageIsColored
                );

                printSuccess = success;
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
        private void printSettingsCancelBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }


        //RESET MACHINE METHODS
        private void ResetMachine()
        {
            //STOP SERVER
            uploadService.StopServer();

            //UPLOAD STATUS
            uploadStatusTimer.Stop();
            fileUploadStatusLabel.Text = "";
            baseStatusText = "";
            dotCount = 0;

            // STOP TIMERS
            inactivityTimer.Stop();
            receiveTimer.Stop();

            // CLEAR PREVIEW
            ResetPdfViewer();
            previewPanelSettingLayout.Controls.Clear();
            pageIsColored.Clear();
            isRetrievalMode = false;

            // RESET FILE PATHS
            currentPdfPath = null;
            currentEditablePath = null;
            currentOriginalPath = null;
            uploadService.currentUploadToken = "";
            lastProcessedFile = "";

            // RESET UPLOAD SESSION
            uploadService.uploadUsed = false;
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

            // RESET RADIO BUTTONS
            radioPrintAll.Checked = true;
            radioSinglePage.Checked = false;
            radioPrintRange.Checked = false;
            radioColored.Checked = false;

            // RESET INPUTS
            numericCopies.Value = 1;
            numericSinglePage.Value = 1;
            numericPageRange.Text = "e.g. 1-5";
            numericPageRange.ForeColor = Color.Gray;

            // UPDATE UI
            UpdateModeUI();
            CalculateTotal();

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
            showPanel(startPanel);
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }
        

        //RETRIEVAL SYSTEM
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
                showPanel(printingSettingsPanel);

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
        private void retrievalCodeTextBox_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
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
            showPanel(retrivalPanel);
        }



        //OTHERS
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
        private void continueBtn_Click(object sender, EventArgs e)
        {

            Debug.WriteLine("CONTINUE BUTTON CLICKED");

            receiveTimer.Stop();

            showPanel(printingSettingsPanel);

            settingsPanel.Visible = true;
            settingsPanel.BringToFront();

            numericCopies.Value = 1;
            radioPrintAll.Checked = true;

            UpdateModeUI();
            CalculateTotal();
        }

        private void radioPrintRange_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioBlackWhite_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
