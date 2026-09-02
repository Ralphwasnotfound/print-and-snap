using AForge.Imaging.Filters;
using FontAwesome.Sharp;
using PdfiumViewer;
using PrintAndSnap.Services;
using PrintAndSnap.Services.PhotoPrinting;
using PrintAndSnap.Services.Printing;
using QRCoder;
using Snap_and_Print.Services;
using Snap_and_Print.Services.PhotoPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Snap_and_Print.Services.PhotoPrinting;


namespace PrintAndSnap
{

    public partial class PrintAndSnap : Form
    {

        // =========================
        // SERVICES
        // =========================
        private UploadServices uploadService = new UploadServices();
        private PhotoUploadServices photoUploadServices;
        private DocumentPrinting documentPrinting = new DocumentPrinting();
        private PrinterManager printerManager = new PrinterManager();
        private PhotoPrinting photoPrinting = new PhotoPrinting();
        private PricingService pricingService = new PricingService();

        private Button activeCaptureButton = null;

        private Image idCaptureAgainOriginalImage;
        private Image funCaptureAgainOriginalImage;
        private Image idContinueOriginalImage;
        private Image funContinueOriginalImage;

        // =========================
        // GLOBAL SYSTEM STATE
        // =========================
        private bool isProcessing = false;
        private bool isResetting = false;
        private bool printingInProgress = false;

        private readonly string BASE_PATH = @"C:\PrintAndSnap";

        // PRINTERS
        private const string DOCUMENT_PRINTER = "Canon MG3000 series";
        private const string PHOTO_PRINTER = "EPSON L3210 Series";

        //MODES
        enum PhotoMode { None, ID, Fun }
        enum SystemMode { None, Docs, Photo }

        private PhotoMode currentMode = PhotoMode.None;
        private SystemMode currentSystemMode = SystemMode.None;

        // =========================
        // DOCS STATE
        // =========================
        private string watchFolder = @"C:\PrintAndSnap\DOCS\uploads";
        private string currentPdfPath;
        private string currentOriginalPath;
        private string currentEditablePath;

        private PdfViewer pdfViewer;

        private int totalPages = 1;
        private bool colorAnalysisDone = false;

        private int uploadDotCount = 0;
        private List<bool> pageIsColored = new List<bool>();


        //FILE WATCHER
        private FileSystemWatcher fileWatcher;
        private HashSet<string> processedFiles = new HashSet<string>();
        private string lastProcessedFile = "";
        private bool fileProcessing = false;

        // =========================
        // PHOTO SHARED STATE
        // =========================
        private CameraService cameraService = new CameraService();
        private PhotoService photoService = new PhotoService();
        private FilterServices filterService = new FilterServices();
        private PhotoLayoutServices layoutService = new PhotoLayoutServices();
        private FrameServices frameService = new FrameServices();
        private BackgroundRemovalService backgroundRemovalService = new BackgroundRemovalService();
        private SuitOverlayService suitOverlayService = new SuitOverlayService();

        private Bitmap currentFrame;
        private Bitmap lastFrame;

        private List<Bitmap> capturedPhotos = new List<Bitmap>();

        private Bitmap selectedPhoto;

        private bool hasUserSelectedPhoto = false;
        bool hasFilter = false;
        bool hasFrame = false;

        // =========================
        // ID MODE STATE
        // =========================
        private string selectedLayout = "2x2";
        private bool isColored = true;
        private bool isMultiple = false;

        // ID BACKGROUND / SUIT OPTION
        private string idBackgroundOption = "none";

        private Bitmap finalIdPrintImage;

        private int totalIdPrice = 0;
        private int lastIdCopiesValue = 1;

        private bool isPhotoRetrievalMode = false;
        private string currentRetrievedIdPath;
        private string uploadedPhotoPath = "";
        private string lastSavedIdFileName;

        // =========================
        // FUN MODE STATE
        // =========================
        private string funFilter = "none";
        private string funLayout = "none";
        private string funFrame = "none";

        private int totalFunPrice = 0;
        private int lastFunCopiesValue = 1;

        private Bitmap finalFunImage;

        private string lastSavedFunFileName;
        private string currentFunRetrievalCode = null;

        private List<Bitmap> cachedFilteredPhotos = new List<Bitmap>();
        private string lastAppliedFilter = "";

        // =========================
        // PAYMENT STATE
        // =========================
        private bool isRetrievalMode = false;
        private bool printSuccess = false;
        private bool billDialogOpen = false;

        private int retrievalAttempts = 0;
        private const int MAX_RETRIEVAL_ATTEMPTS = 3;

        bool allowReset = false;

        //LIMITS
        private const long MAX_UPLOAD_SIZE = 20 * 1024 * 1024;
        private const int MAX_ALLOWED_PAGES = 200;

        // =========================
        // TIMERS
        // =========================
        private System.Windows.Forms.Timer cleanupTimer;
        private System.Windows.Forms.Timer printerStatusTimer;
        private System.Windows.Forms.Timer inactivityTimer;
        private System.Windows.Forms.Timer qrExpireTimer;
        private System.Windows.Forms.Timer uploadStatusTimer;
        private System.Windows.Forms.Timer captureTimer;

        // =========================
        // PATH SHORTCUTS
        // =========================
        private string ID_DOWNLOAD => Path.Combine(BASE_PATH, "ID", "download");
        private string FUN_DOWNLOAD => Path.Combine(BASE_PATH, "FUN", "download");

        // =========================
        // OTHERS
        // =========================
        private bool printerErrorShown = false;
        private bool sessionActive = false;
        private int dotCount = 0;
        private string baseStatusText = "";
        private IntPtr hookID = IntPtr.Zero;
        private int countdown = 3;
        private CancellationTokenSource resetTokenSource;
        private string lastPrinterError = "";
        private DateTime lastFrameTime = DateTime.MinValue;

        private PaymentController paymentController = new PaymentController();

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                // Reduce flickering when switching/painting panels
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED

                return cp;
            }
        }

        private void ShutdownApplication()
        {
            try
            {
                DebugLog("APPLICATION SHUTDOWN STARTED");

                // =========================
                // STOP CAMERA
                // =========================
                try
                {
                    cameraService.StopCamera();
                }
                catch (Exception ex)
                {
                    DebugLog("Camera shutdown error: " + ex.Message);
                }

                // =========================
                // STOP TIMERS
                // =========================
                try { cleanupTimer?.Stop(); } catch { }
                try { printerStatusTimer?.Stop(); } catch { }
                try { inactivityTimer?.Stop(); } catch { }
                try { qrExpireTimer?.Stop(); } catch { }
                try { uploadStatusTimer?.Stop(); } catch { }
                try { captureTimer?.Stop(); } catch { }
                try { receiveTimer?.Stop(); } catch { }

                // =========================
                // STOP FILE WATCHER
                // =========================
                try
                {
                    if (fileWatcher != null)
                    {
                        fileWatcher.EnableRaisingEvents = false;
                        fileWatcher.Dispose();
                        fileWatcher = null;
                    }
                }
                catch (Exception ex)
                {
                    DebugLog("File watcher shutdown error: " + ex.Message);
                }

                // =========================
                // STOP DOWNLOAD SERVER
                // =========================
                try
                {
                    uploadService.StopServer();
                }
                catch (Exception ex)
                {
                    DebugLog("Upload server shutdown error: " + ex.Message);
                }

                // =========================
                // CANCEL BACKGROUND TASKS
                // =========================
                try
                {
                    resetTokenSource?.Cancel();
                    resetTokenSource?.Dispose();
                    resetTokenSource = null;
                }
                catch { }

                // =========================
                // STOP CAMERA IMAGES
                // =========================
                try
                {
                    SafeDisposePictureBox(idCameraFeed);
                    SafeDisposePictureBox(funCameraFeed);

                    SafeDispose(ref currentFrame);
                    SafeDispose(ref lastFrame);
                }
                catch { }

                // =========================
                // CLOSE PDF VIEWER
                // =========================
                try
                {
                    ResetPdfViewer();
                }
                catch { }

                // =========================
                // RELEASE PHOTO MEMORY
                // =========================
                try
                {
                    foreach (var photo in capturedPhotos)
                    {
                        photo?.Dispose();
                    }

                    capturedPhotos.Clear();

                    SafeDispose(ref selectedPhoto);
                    SafeDispose(ref finalIdPrintImage);
                    SafeDispose(ref finalFunImage);

                    foreach (var photo in cachedFilteredPhotos)
                    {
                        photo?.Dispose();
                    }

                    cachedFilteredPhotos.Clear();
                }
                catch { }

                // =========================
                // DISCONNECT COIN ACCEPTOR
                // =========================
                try
                {
                    paymentController.Disconnect();
                }
                catch (Exception ex)
                {
                    DebugLog("Payment controller shutdown error: " + ex.Message);
                }

                // =========================
                // REMOVE WINDOWS HOOK
                // =========================
                try
                {
                    if (hookID != IntPtr.Zero)
                    {
                        UnhookWindowsHookEx(hookID);
                        hookID = IntPtr.Zero;
                    }
                }
                catch { }

                DebugLog("APPLICATION SHUTDOWN CLEANUP COMPLETE");
            }
            catch (Exception ex)
            {
                DebugLog("Shutdown error: " + ex.Message);
            }
            finally
            {
                // Make absolutely sure the application exits
                Application.Exit();
            }
        }

        private void PrintAndSnap_FormClosing(
    object sender,
    FormClosingEventArgs e)
        {
            ShutdownApplication();
        }


        // =========================
        // CONSTRUCTOR
        // =========================
        public PrintAndSnap()
        {
            InitializeComponent();

            idCameraFeed.Paint += idCameraFeed_Paint;

            // =========================
            // SAVE ORIGINAL BUTTON IMAGES
            // =========================

            idCaptureAgainOriginalImage = idCaptureAgainBtn.BackgroundImage;
            funCaptureAgainOriginalImage = funCaptureAgainBtn.BackgroundImage;
            idContinueOriginalImage = idPrintingContinueBtn.BackgroundImage;
            funContinueOriginalImage = funContinueBtn.BackgroundImage;

            // =========================
            // CAMERA INIT
            // =========================
            InitCamera();

            captureTimer = new System.Windows.Forms.Timer();
            captureTimer.Interval = 1000;
            captureTimer.Tick += CaptureTimer_Tick;

            idPrintingContinueBtn.Enabled = false;

            // =========================
            // ID CONTROLS INIT
            // =========================
            numericIdPrintingCopies.Minimum = 1;
            numericIdPrintingCopies.Value = 1;
            numericIdPrintingCopies.Maximum = 5;

            numericIdPrintingCopies.ValueChanged += (s, e) =>
            {
                int current = (int)numericIdPrintingCopies.Value;

                if (current == 5 && lastIdCopiesValue == 5)
                {
                    MessageBox.Show("Maximum 5 copies only.");
                }

                lastIdCopiesValue = current;
                CalculateIdPrice();
            };

            numericIdPrintingCopies.Enabled = false;

            // =========================
            // FUN CONTROLS INIT
            // =========================
            funNumericCopies.Minimum = 1;
            funNumericCopies.Value = 1;
            funNumericCopies.Maximum = 5;

            funNumericCopies.ValueChanged += (s, e) =>
            {
                int current = (int)funNumericCopies.Value;

                if (current == 5 && lastFunCopiesValue == 5)
                {
                    MessageBox.Show("Maximum 5 copies only.");
                }

                lastFunCopiesValue = current;
                CalculateFunPrice();
            };

            // =========================
            // ID DEFAULT SETTINGS
            // =========================
            radioBtn2x2.Checked = true;
            radioBtnSinglePhotoCopies.Checked = true;
            radioBtnPhotoColored.Checked = true;

            selectedLayout = "2x2";
            isMultiple = false;
            isColored = true;

            CalculateIdPrice();

            // =========================
            // FORM UI SETTINGS
            // =========================
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;

            //COMMENT THIS/DELETE FOR PROD
            /*  this.FormBorderStyle = FormBorderStyle.Sizable;
              this.WindowState = FormWindowState.Normal;
              this.StartPosition = FormStartPosition.CenterScreen;*/

            // =========================
            // DOC DEFAULT SETTINGS
            // =========================
            radioPrintAll.Checked = true;
            UpdateModeUI();

            SetupPlaceholder();

            // =========================
            // DOC INPUT EVENTS
            // =========================
            numericCopies.ValueChanged += numericCopies_ValueChanged;
            numericCopies.TextChanged += (s, e) => CalculateTotal();

            numericPageRange.TextChanged += (s, e) => CalculateTotal();

            numericSinglePage.ValueChanged += (s, e) => CalculateTotal();
            numericSinglePage.TextChanged += (s, e) => CalculateTotal();

            photoUploadServices = new PhotoUploadServices();

            photoUploadServices.PhotoUploaded += PhotoUploadServices_PhotoUploaded;

            // =========================
            // DOC RADIO EVENTS
            // =========================
            radioPrintAll.CheckedChanged += (s, e) =>
            {
                if (radioPrintAll.Checked)
                {
                    radioSinglePage.Checked = false;
                    radioPrintRange.Checked = false;
                    UpdateModeUI();
                    CalculateTotal();
                }
            };

            radioSinglePage.CheckedChanged += (s, e) =>
            {
                if (radioSinglePage.Checked)
                {
                    radioPrintAll.Checked = false;
                    radioPrintRange.Checked = false;
                    UpdateModeUI();
                    CalculateTotal();
                }
            };

            radioPrintRange.CheckedChanged += (s, e) =>
            {
                if (radioPrintRange.Checked)
                {
                    radioPrintAll.Checked = false;
                    radioSinglePage.Checked = false;
                    UpdateModeUI();
                    CalculateTotal();
                }
            };

            // =========================
            // DOC COLOR ANALYSIS
            // =========================
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

            // =========================
            // GLOBAL SYSTEM EVENTS
            // =========================
            Application.ApplicationExit += (s, e) =>
            {
                ShowTaskbar();
            };

            Application.ThreadException += (s, e) =>
            {
                MessageBox.Show("Unexpected error: " + e.Exception.Message);
            };

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                MessageBox.Show("Fatal error occurred.");
            };

        }

        // ====================
        // TASKBAR METHODS
        // ====================

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

        // ==================
        // FORM EVENTS
        // ==================
        protected override void OnShown(EventArgs e)
        {
            //if debugging hide the task bar
            //if not show for production and testing
            base.OnShown(e);
            //HideTaskbar();
            //#if !DEBUG
            //              HideTaskbar(); 
            //#endif
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            paymentController.Disconnect();
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

        // ===================
        // WINDOWS(API)
        // SYSTEM
        // =========================

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

        // =======================
        // PRINT AND SNAP LOAD
        // =======================
        private void Print_And_Snap_Load(object sender, EventArgs e)
        {

            //#if !DEBUG
            //            //enable this for production
            //            {
            //                Process.Start("taskkill", "/f /im explorer.exe");
            //            }  
            //#endif

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

            InitializeFolders();

            // Setup timer that waits for uploaded file preview
            receiveTimer = new System.Windows.Forms.Timer();
            receiveTimer.Interval = 3000;

            cleanupTimer = new System.Windows.Forms.Timer();
            cleanupTimer.Interval = 5000; // change this for prod 10minutes
            cleanupTimer.Start();

            printerStatusTimer = new System.Windows.Forms.Timer();
            printerStatusTimer.Interval = 2000;
            printerStatusTimer.Tick += PrinterStatusTimer_Tick;
            printerStatusTimer.Start();

            inactivityTimer = new System.Windows.Forms.Timer();
            inactivityTimer.Interval = 120000; // 12 minutes

            uploadStatusTimer = new System.Windows.Forms.Timer();
            uploadStatusTimer.Interval = 500; // half second
            uploadStatusTimer.Tick += UploadStatusTimer_Tick;

            qrExpireTimer = new System.Windows.Forms.Timer();
            qrExpireTimer.Interval = 60000; // 60 seconds
            qrExpireTimer.Tick += QrExpireTimer_Tick;

            if (paymentController.Connect())
            {
                paymentController.PaymentUpdated += PaymentController_PaymentUpdated;
                paymentController.BillDetected += PaymentController_BillDetected;

                paymentController.CheckHardware();
            }
            else
            {
                MessageBox.Show(
                    "Hardware connection failed!",
                    "Snap and Print",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }

            instructionLabel.Text = "Please select a service to continue";

            instructionLabelPhoto.Text = "Please select a photo service to continue";

            instructionLabelDocs.Text = "Scan the QR Code to continue";

        }

        private void PaymentController_PaymentUpdated()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(PaymentController_PaymentUpdated));
                return;
            }

            // DOCUMENT
            totalDocInserted.Text = paymentController.InsertedPayment.ToString();
            paymentDocBalance.Text = paymentController.Balance.ToString();
            totalDocChange.Text = paymentController.Change.ToString();

            // ID
            paymentInsertedID.Text = paymentController.InsertedPayment.ToString();
            paymentIDBalance.Text = paymentController.Balance.ToString();
            paymentChangeID.Text = paymentController.Change.ToString();

            // FUN
            paymentFunInserted.Text = paymentController.InsertedPayment.ToString();
            paymentFunBalance.Text = paymentController.Balance.ToString();
            paymentFunChange.Text = paymentController.Change.ToString();

            printBtn.Enabled =
            paymentController.InsertedPayment >= paymentController.TotalAmount;

            printBtnPaymentId.Enabled =
                paymentController.InsertedPayment >= paymentController.TotalAmount;

            paymentFunPrintBtn.Enabled =
                paymentController.InsertedPayment >= paymentController.TotalAmount;
        }

        private void PaymentController_BillDetected()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(PaymentController_BillDetected));
                return;
            }

            // ============================================
            // PREVENT MULTIPLE BILL WINDOWS
            // ============================================

            if (billDialogOpen)
                return;

            billDialogOpen = true;

            try
            {
                using (Form billForm = new Form())
                {
                    billForm.Text = "Bill Detected";
                    billForm.StartPosition = FormStartPosition.CenterParent;
                    billForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    billForm.MinimizeBox = false;
                    billForm.MaximizeBox = false;
                    billForm.Width = 420;
                    billForm.Height = 340;

                    // ============================================
                    // TITLE
                    // ============================================

                    Label title = new Label();

                    title.Text = "BILL DETECTED";
                    title.Dock = DockStyle.Top;
                    title.Height = 55;
                    title.TextAlign = ContentAlignment.MiddleCenter;
                    title.Font = new Font(
                        "Segoe UI",
                        16,
                        FontStyle.Bold
                    );

                    // ============================================
                    // MESSAGE
                    // ============================================

                    Label message = new Label();

                    message.Text = "Select the bill denomination:";
                    message.Dock = DockStyle.Top;
                    message.Height = 40;
                    message.TextAlign = ContentAlignment.MiddleCenter;
                    message.Font = new Font(
                        "Segoe UI",
                        11
                    );

                    // ============================================
                    // SELECTED LABEL
                    // ============================================

                    Label selectedLabel = new Label();

                    selectedLabel.Text = "Selected: None";
                    selectedLabel.Dock = DockStyle.Top;
                    selectedLabel.Height = 35;
                    selectedLabel.TextAlign = ContentAlignment.MiddleCenter;
                    selectedLabel.Font = new Font(
                        "Segoe UI",
                        11,
                        FontStyle.Bold
                    );

                    // ============================================
                    // DENOMINATION BUTTONS
                    // ============================================

                    TableLayoutPanel buttons = new TableLayoutPanel();

                    buttons.Dock = DockStyle.Top;
                    buttons.Height = 120;
                    buttons.ColumnCount = 2;
                    buttons.RowCount = 2;
                    buttons.Padding = new Padding(20, 5, 20, 5);

                    buttons.ColumnStyles.Add(
                        new ColumnStyle(SizeType.Percent, 50));

                    buttons.ColumnStyles.Add(
                        new ColumnStyle(SizeType.Percent, 50));

                    buttons.RowStyles.Add(
                        new RowStyle(SizeType.Percent, 50));

                    buttons.RowStyles.Add(
                        new RowStyle(SizeType.Percent, 50));

                    // ============================================
                    // CREATE BUTTONS
                    // ============================================

                    Button btn50 = new Button();
                    btn50.Text = "₱50";
                    btn50.Dock = DockStyle.Fill;
                    btn50.Font = new Font(
                        "Segoe UI",
                        14,
                        FontStyle.Bold
                    );

                    Button btn100 = new Button();
                    btn100.Text = "₱100";
                    btn100.Dock = DockStyle.Fill;
                    btn100.Font = new Font(
                        "Segoe UI",
                        14,
                        FontStyle.Bold
                    );

                    Button btn500 = new Button();
                    btn500.Text = "₱500";
                    btn500.Dock = DockStyle.Fill;
                    btn500.Font = new Font(
                        "Segoe UI",
                        14,
                        FontStyle.Bold
                    );

                    Button btn1000 = new Button();
                    btn1000.Text = "₱1000";
                    btn1000.Dock = DockStyle.Fill;
                    btn1000.Font = new Font(
                        "Segoe UI",
                        14,
                        FontStyle.Bold
                    );

                    // ============================================
                    // CONFIRM / CHANGE
                    // ============================================

                    FlowLayoutPanel actionPanel = new FlowLayoutPanel();

                    actionPanel.Dock = DockStyle.Fill;
                    actionPanel.FlowDirection = FlowDirection.RightToLeft;
                    actionPanel.Padding = new Padding(20, 5, 20, 10);

                    Button confirmButton = new Button();

                    confirmButton.Text = "CONFIRM";
                    confirmButton.Width = 150;
                    confirmButton.Height = 45;
                    confirmButton.Font = new Font(
                        "Segoe UI",
                        11,
                        FontStyle.Bold
                    );

                    Button changeButton = new Button();

                    changeButton.Text = "CHANGE";
                    changeButton.Width = 150;
                    changeButton.Height = 45;
                    changeButton.Font = new Font(
                        "Segoe UI",
                        11,
                        FontStyle.Bold
                    );

                    // ============================================
                    // SELECTED DENOMINATION
                    // ============================================

                    int selectedAmount = 0;

                    // ============================================
                    // LOCK / UNLOCK DENOMINATION BUTTONS
                    // ============================================

                    Action lockDenominationButtons = () =>
                    {
                        btn50.Enabled = false;
                        btn100.Enabled = false;
                        btn500.Enabled = false;
                        btn1000.Enabled = false;

                        changeButton.Enabled = true;
                        confirmButton.Enabled = true;
                    };

                    Action unlockDenominationButtons = () =>
                    {
                        btn50.Enabled = true;
                        btn100.Enabled = true;
                        btn500.Enabled = true;
                        btn1000.Enabled = true;

                        changeButton.Enabled = false;
                        confirmButton.Enabled = false;

                        selectedAmount = 0;

                        selectedLabel.Text = "Selected: None";
                    };

                    // ============================================
                    // DENOMINATION SELECTION
                    // ============================================

                    btn50.Click += (s, e) =>
                    {
                        selectedAmount = 50;

                        selectedLabel.Text = "Selected: ₱50";

                        lockDenominationButtons();
                    };

                    btn100.Click += (s, e) =>
                    {
                        selectedAmount = 100;

                        selectedLabel.Text = "Selected: ₱100";

                        lockDenominationButtons();
                    };

                    btn500.Click += (s, e) =>
                    {
                        selectedAmount = 500;

                        selectedLabel.Text = "Selected: ₱500";

                        lockDenominationButtons();
                    };

                    btn1000.Click += (s, e) =>
                    {
                        selectedAmount = 1000;

                        selectedLabel.Text = "Selected: ₱1000";

                        lockDenominationButtons();
                    };

                    // ============================================
                    // CHANGE BUTTON
                    // ============================================

                    changeButton.Click += (s, e) =>
                    {
                        unlockDenominationButtons();
                    };

                    // ============================================
                    // CONFIRM BUTTON
                    // ============================================

                    confirmButton.Click += (s, e) =>
                    {
                        if (selectedAmount <= 0)
                            return;

                        // ========================================
                        // SEND PAYMENT ONLY ONCE
                        // ========================================

                        paymentController.AddBillPayment(selectedAmount);

                        billForm.DialogResult = DialogResult.OK;
                        billForm.Close();
                    };

                    // ============================================
                    // INITIAL STATE
                    // ============================================

                    changeButton.Enabled = false;
                    confirmButton.Enabled = false;

                    // ============================================
                    // ADD CONTROLS
                    // ============================================

                    buttons.Controls.Add(btn50, 0, 0);
                    buttons.Controls.Add(btn100, 1, 0);
                    buttons.Controls.Add(btn500, 0, 1);
                    buttons.Controls.Add(btn1000, 1, 1);

                    actionPanel.Controls.Add(confirmButton);
                    actionPanel.Controls.Add(changeButton);

                    billForm.Controls.Add(actionPanel);
                    billForm.Controls.Add(buttons);
                    billForm.Controls.Add(selectedLabel);
                    billForm.Controls.Add(message);
                    billForm.Controls.Add(title);

                    // ============================================
                    // SHOW
                    // ============================================

                    billForm.ShowDialog(this);
                }
            }
            finally
            {
                // ============================================
                // ALLOW NEXT BILL AFTER DIALOG CLOSES
                // ============================================

                billDialogOpen = false;
            }
        }

        // =========================
        // FOLDERS
        // =========================

        private void InitializeFolders()
        {
            string basePath = @"C:\PrintAndSnap";

            // =========================
            // BASE
            // =========================
            Directory.CreateDirectory(basePath);

            // =========================
            // DOCS
            // =========================
            Directory.CreateDirectory(Path.Combine(basePath, "DOCS"));
            Directory.CreateDirectory(Path.Combine(basePath, "DOCS", "uploads"));
            Directory.CreateDirectory(Path.Combine(basePath, "DOCS", "preview"));
            Directory.CreateDirectory(Path.Combine(basePath, "DOCS", "archive"));

            // =========================
            // ID
            // =========================
            Directory.CreateDirectory(Path.Combine(basePath, "ID"));
            Directory.CreateDirectory(Path.Combine(basePath, "ID", "temp"));
            Directory.CreateDirectory(Path.Combine(basePath, "ID", "archive"));
            Directory.CreateDirectory(Path.Combine(basePath, "ID", "download"));

            // =========================
            // FUN
            // =========================
            Directory.CreateDirectory(Path.Combine(basePath, "FUN"));
            Directory.CreateDirectory(Path.Combine(basePath, "FUN", "temp"));
            Directory.CreateDirectory(Path.Combine(basePath, "FUN", "archive"));
            Directory.CreateDirectory(Path.Combine(basePath, "FUN", "download"));
        }

        // ===================
        // PANEL METHODS
        // ===================
        private void ShowPhotoPanel(Control mainPanel, Control subPanel = null)
        {
            photoPanel.Visible = true;
            photoPanel.BringToFront();

            // Hide all main panels
            photoMode.Visible = false;
            photoIDPanel.Visible = false;
            retrievalPanelPhoto.Visible = false;
            photoBoothPanel.Visible = false;

            // SHOW MAIN PANEL
            mainPanel.Visible = true;
            mainPanel.BringToFront();

            // HANDLE ID PANEL SUBPANELS
            if (mainPanel == photoIDPanel)
            {
                panelCRMidPrinting.Visible = false;
                idPrintingSettings.Visible = false;
                IDpayment.Visible = false;
                softCopyDownloadId.Visible = false; // 🔥 ADD THIS

                if (subPanel != null)
                {
                    subPanel.Visible = true;
                    subPanel.BringToFront();
                }
            }

            if (mainPanel == photoBoothPanel)
            {
                panelCMRphotoBooth.Visible = false;
                photoBoothSettings.Visible = false;

                if (subPanel != null)
                {
                    subPanel.Visible = true;
                    subPanel.BringToFront();
                }
            }
        }

        private void showPanel(Control panel)
        {
            this.SuspendLayout();

            try
            {
                startPanel.Visible = false;
                printingOptionsPanel.Visible = false;
                uploadPanel.Visible = false;
                continuePanel.Visible = false;
                printingSettingsPanel.Visible = false;
                paymentPanel.Visible = false;
                retrivalPanel.Visible = false;
                photoUploadPanel.Visible = false;

                panel.Visible = true;
                panel.BringToFront();
            }
            finally
            {
                this.ResumeLayout(true);
            }
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

        // =================
        // PHOTO PRRINTING
        // =================
        private void photoPrintingBtn_Click(Object sender, EventArgs e)
        {


            currentSystemMode = SystemMode.Photo;
            photoPanel.Visible = true;
            photoPanel.BringToFront();

            ShowPhotoPanel(photoMode);

        }

        // =========================
        // CAMERA METHODS
        // =========================
        private void InitCamera()
        {
            cameraService.OnFrameCaptured += (frame) =>
            {
                try
                {
                    // LIMIT FPS
                    if ((DateTime.Now - lastFrameTime).TotalMilliseconds < 100)
                        return;

                    lastFrameTime = DateTime.Now;

                    // CLONE FRAME (IMPORTANT - avoid threading issues)
                    Bitmap safeFrame = null;

                    if (frame != null)
                    {
                        lock (frame)
                        {
                            safeFrame = (Bitmap)frame.Clone();
                        }
                    }

                    if (safeFrame == null)
                        return;

                    currentFrame = safeFrame;

                    // =========================
                    // ID CAMERA
                    // =========================
                    if (idCameraFeed.Visible)
                    {
                        if (idCameraFeed.InvokeRequired)
                        {
                            idCameraFeed.Invoke(new Action(() =>
                            {
                                UpdateCameraFrame(safeFrame);
                            }));
                        }
                        else
                        {
                            UpdateCameraFrame(safeFrame);
                        }
                    }

                    // =========================
                    // FUN CAMERA
                    // =========================
                    if (funCameraFeed.Visible)
                    {
                        if (funCameraFeed.InvokeRequired)
                        {
                            funCameraFeed.Invoke(new Action(() =>
                            {
                                FunUpdateCameraFrame(safeFrame);
                            }));
                        }
                        else
                        {
                            FunUpdateCameraFrame(safeFrame);
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugLog("Camera Error: " + ex.Message);
                }
            };
        }

        private void UpdateCameraFrame(Bitmap frame)
        {
            if (lastFrame != null)
                lastFrame.Dispose();

            lastFrame = (Bitmap)frame.Clone();

            idCameraFeed.Image = lastFrame;
            idCameraFeed.SizeMode = PictureBoxSizeMode.StretchImage;

            // Force Paint event
            idCameraFeed.Invalidate();
        }

        private void FunUpdateCameraFrame(Bitmap frame)
        {
            if (lastFrame != null)
                lastFrame.Dispose();

            lastFrame = (Bitmap)frame.Clone();

            funCameraFeed.Image = lastFrame;
            funCameraFeed.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void SafeDispose(ref Bitmap img)
        {
            if (img != null)
            {
                img.Dispose();
                img = null;
            }
        }

        private async void CaptureTimer_Tick(object sender, EventArgs e)
        {
            bool isFunMode = currentMode == PhotoMode.Fun;
            Button captureButton = activeCaptureButton;

            if (captureButton == null)
                return;

            if (countdown > 0)
            {
                captureButton.Text = countdown.ToString();
                countdown--;
                return;
            }

            captureTimer.Stop();
            countdown = -1;
            captureButton.Text = "📸";

            try
            {
                await Task.Delay(500);

                if (countdown != -1 || currentFrame == null)
                    return;

                Bitmap shot = photoService.Capture(currentFrame);

                if (shot == null || shot.Width == 0 || shot.Height == 0)
                {
                    shot?.Dispose();
                    return;
                }

                capturedPhotos.Add(shot);

                if (isFunMode)
                {
                    // =========================
                    // FUN PHOTO SELECTION
                    // SAME BEHAVIOR AS ID
                    // =========================

                    if (capturedPhotos.Count > 1)
                    {
                        if (selectedPhoto != null)
                        {
                            selectedPhoto.Dispose();
                            selectedPhoto = null;
                        }

                        hasUserSelectedPhoto = false;
                    }

                    ShowFunCapturedPhotos();
                    UpdateFunCaptureButtonState();
                }
                else
                {
                    // =========================
                    // ID PHOTO SELECTION
                    // =========================

                    if (capturedPhotos.Count > 1)
                    {
                        if (selectedPhoto != null)
                        {
                            selectedPhoto.Dispose();
                            selectedPhoto = null;
                        }

                        hasUserSelectedPhoto = false;
                    }

                    ShowCapturedPhotos();
                    UpdateCaptureButtonState();
                }
            }
            catch (Exception ex)
            {
                DebugLog("Capture error: " + ex.Message);
            }
            finally
            {
                if (countdown == -1)
                    countdown = 3;

                captureButton.Text = "";

                if (captureButton == idCaptureBtn || captureButton == funCaptureBtn)
                {
                    captureButton.BackgroundImage =
                        global::Snap_and_Print.Properties.Resources.camera_fill;
                }

                if (captureButton == idCaptureBtn)
                {
                    idCaptureBtn.Enabled = capturedPhotos.Count < 4;

                    // Capture Again available only when photos exist
                    idCaptureAgainBtn.Enabled = capturedPhotos.Count > 0;
                }
                else if (captureButton == funCaptureBtn)
                {
                    funCaptureBtn.Enabled = capturedPhotos.Count < 4;

                    // Capture Again available only when photos exist
                    funCaptureAgainBtn.Enabled = capturedPhotos.Count > 0;
                }

                activeCaptureButton = null;
            }
        }

        private void SafeDisposePictureBox(PictureBox box)
        {
            if (box.Image != null)
            {
                box.Image.Dispose();
                box.Image = null;
            }
        }

        // =========================
        // ID MODE METHODS
        // =========================
        private void idModeBtn_Click(object sender, EventArgs e)
        {
            ResetPhotoSession(); // important

            currentMode = PhotoMode.ID; // NEW SYSTEM

            ShowPhotoPanel(photoIDPanel, panelCRMidPrinting);

            if (idCameraFeed.Image != null)
            {
                idCameraFeed.Image.Dispose();
                idCameraFeed.Image = null;
            }

            try
            {
                cameraService.StartCamera();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void idPrintingContinueBtn_Click(object sender, EventArgs args)
        {
            if (isProcessing)
                return;

            if (capturedPhotos.Count == 0)
            {
                MessageBox.Show(
                    "Please capture at least one photo.",
                    "No Photo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // MORE THAN ONE PHOTO = MUST SELECT ONE
            if (capturedPhotos.Count > 1 && !hasUserSelectedPhoto)
            {
                MessageBox.Show(
                    "Please select ONE photo to continue.",
                    "Select Photo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (selectedPhoto == null)
            {
                MessageBox.Show(
                    "Please select one photo to continue.",
                    "Select Photo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            isProcessing = true;
            idPrintingContinueBtn.Enabled = false;

            try
            {
                await Task.Run(() => cameraService.StopCamera());
                await Task.Delay(200);

                UpdateIdSettings();

                ShowPhotoPanel(
                    photoIDPanel,
                    idPrintingSettings
                );

                idBackgroundOption = "none";

                HighlightSelectedPhoto(idSettingsSelectPicture1);

                UpdateIdSettings();

                ShowPhotoPanel(
                    photoIDPanel,
                    idPrintingSettings
                );
            }
            catch (Exception ex)
            {
                DebugLog("ID Continue error: " + ex.Message);

                MessageBox.Show(
                    this,
                    "Unable to continue.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                isProcessing = false;
                idPrintingContinueBtn.Enabled = true;
            }
        }

        private void SelectCapturedIdPhoto_Click(object sender, EventArgs e)
        {
            PictureBox clicked = sender as PictureBox;

            if (clicked == null || clicked.Image == null)
                return;

            int selectedIndex = -1;

            if (clicked == idPreviewPictureBox1)
                selectedIndex = 0;
            else if (clicked == idPreviewPictureBox2)
                selectedIndex = 1;
            else if (clicked == idPreviewPictureBox3)
                selectedIndex = 2;
            else if (clicked == idPreviewPictureBox4)
                selectedIndex = 3;

            if (selectedIndex < 0 || selectedIndex >= capturedPhotos.Count)
                return;

            // Remove previous selected photo
            if (selectedPhoto != null)
            {
                selectedPhoto.Dispose();
                selectedPhoto = null;
            }

            // Save the newly selected photo
            selectedPhoto = (Bitmap)capturedPhotos[selectedIndex].Clone();
            hasUserSelectedPhoto = true;

            // Reset all preview boxes
            PictureBox[] boxes =
            {
        idPreviewPictureBox1,
        idPreviewPictureBox2,
        idPreviewPictureBox3,
        idPreviewPictureBox4
    };

            foreach (PictureBox box in boxes)
            {
                box.BorderStyle = BorderStyle.None;
                box.BackColor = Color.Transparent;
                box.Padding = new Padding(0);
            }

            // Highlight selected photo
            clicked.BorderStyle = BorderStyle.FixedSingle;
            clicked.BackColor = Color.LightSkyBlue;
            clicked.Padding = new Padding(4);

            // Enable Continue because ONE photo is now selected
            idPrintingContinueBtn.Enabled = true;
        }


        private void HighlightSelectedPhoto(PictureBox selectedBox)
        {
            PictureBox[] boxes =
            {
        idSettingsSelectPicture1,
        idSettingsSelectPicture2,
        idSettingsSelectPicture3,
        idSettingsSelectPicture4
    };

            foreach (var box in boxes)
            {
                box.BorderStyle = BorderStyle.None;
                box.BackColor = Color.Transparent;
                box.Padding = new Padding(0);
            }

            // ACTIVE STYLE
            selectedBox.BorderStyle = BorderStyle.FixedSingle;
            selectedBox.BackColor = Color.LightBlue; // glow effect
            selectedBox.Padding = new Padding(3);    // spacing = glow illusion
            selectedBox.BackColor = Color.LightSkyBlue;
        }

        private void ShowCapturedPhotos()
        {
            PictureBox[] boxes =
            {
        idPreviewPictureBox1,
        idPreviewPictureBox2,
        idPreviewPictureBox3,
        idPreviewPictureBox4
    };

            for (int i = 0; i < boxes.Length; i++)
            {
                // Prevent duplicate event handlers
                boxes[i].Click -= SelectCapturedIdPhoto_Click;

                if (i < capturedPhotos.Count)
                {
                    SafeDisposePictureBox(boxes[i]);

                    boxes[i].Image = (Bitmap)capturedPhotos[i].Clone();
                    boxes[i].Visible = true;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;

                    // Reset appearance
                    boxes[i].BorderStyle = BorderStyle.None;
                    boxes[i].BackColor = Color.Transparent;
                    boxes[i].Padding = new Padding(0);

                    // MAKE IT CLICKABLE
                    boxes[i].Click += SelectCapturedIdPhoto_Click;
                }
                else
                {
                    boxes[i].Visible = false;
                }
            }
        }

        private void idCaptureBtn_Click(object sender, EventArgs args)
        {
            if (currentFrame == null)
                return;

            if (captureTimer.Enabled)
                return;

            if (isProcessing)
                return;

            if (capturedPhotos.Count >= 4)
            {
                MessageBox.Show("Maximum of 4 photos only.");
                return;
            }

            activeCaptureButton = idCaptureBtn;

            idCaptureBtn.Enabled = false;
            idPrintingContinueBtn.Enabled = false;
            idCaptureAgainBtn.Enabled = false;

            idCaptureBtn.BackgroundImage = null;

            countdown = 3;
            captureTimer.Start();
        }

        private void UpdateCaptureButtonState()
        {
            // Capture button: maximum 4 photos
            idCaptureBtn.Enabled = capturedPhotos.Count < 4;

            // =========================
            // ONLY ONE PHOTO
            // =========================
            if (capturedPhotos.Count == 1)
            {
                if (selectedPhoto != null)
                {
                    selectedPhoto.Dispose();
                }

                selectedPhoto = (Bitmap)capturedPhotos[0].Clone();
                hasUserSelectedPhoto = true;
            }

            // =========================
            // MORE THAN ONE PHOTO
            // =========================
            else if (capturedPhotos.Count > 1)
            {
                // Do NOT automatically select anything
                idPrintingContinueBtn.Enabled = hasUserSelectedPhoto;
                return;
            }

            // =========================
            // CONTINUE
            // =========================
            idPrintingContinueBtn.Enabled =
                capturedPhotos.Count == 1 ||
                hasUserSelectedPhoto;
        }

        private void UpdateFunCaptureButtonState()
        {
            // Capture button: maximum 4 photos
            funCaptureBtn.Enabled = capturedPhotos.Count < 4;

            // =========================
            // ONLY ONE PHOTO
            // =========================
            if (capturedPhotos.Count == 1)
            {
                if (selectedPhoto != null)
                {
                    selectedPhoto.Dispose();
                }

                selectedPhoto = (Bitmap)capturedPhotos[0].Clone();
                hasUserSelectedPhoto = true;
            }

            // =========================
            // MORE THAN ONE PHOTO
            // =========================
            else if (capturedPhotos.Count > 1)
            {
                // User MUST select one
                funContinueBtn.Enabled = hasUserSelectedPhoto;
                return;
            }

            // =========================
            // CONTINUE
            // =========================
            funContinueBtn.Enabled =
                capturedPhotos.Count == 1 ||
                hasUserSelectedPhoto;
        }

        private void ResetIdPreviewBoxes()
        {
            PictureBox[] boxes =
            {
        idPreviewPictureBox1,
        idPreviewPictureBox2,
        idPreviewPictureBox3,
        idPreviewPictureBox4
    };

            foreach (PictureBox box in boxes)
            {
                // Remove selection event
                box.Click -= SelectCapturedIdPhoto_Click;

                // Dispose old preview image
                if (box.Image != null)
                {
                    Image oldImage = box.Image;
                    box.Image = null;
                    oldImage.Dispose();
                }

                // Reset UI completely
                box.Visible = false;
                box.BorderStyle = BorderStyle.None;
                box.BackColor = Color.Transparent;
                box.Padding = new Padding(0);
            }
        }

        //===========
        // QR TIMER
        //===========
        private void UploadStatusTimer_Tick(object sender, EventArgs e)
        {
            dotCount = (dotCount + 1) % 4;

            fileUploadStatusLabel.Text =
                baseStatusText + new string('.', dotCount);
        }

        private void QrExpireTimer_Tick(object sender, EventArgs e)
        {
            qrExpireTimer.Stop();

            try
            {
                uploadService.GenerateNewToken();

                qrPictureBox.Image = uploadService.GenerateQRCode();
            }
            catch (Exception ex)
            {
                DebugLog("QR Refresh Error: " + ex.Message);
            }
        }

        private void UpdateIdSettings()
        {
            if (selectedPhoto == null)
                return;

            Bitmap processedPhoto = null;
            Bitmap finalPhoto = null;

            try
            {
                // ==========================================
                // BACKGROUND REMOVAL
                // ==========================================

                if (idBackgroundOption == "white" ||
                    idBackgroundOption == "male" ||
                    idBackgroundOption == "female")
                {
                    DebugLog("AI background removal started...");

                    processedPhoto =
                        backgroundRemovalService.RemoveBackground(
                            selectedPhoto
                        );

                    DebugLog("AI background removal completed.");
                }
                else
                {
                    processedPhoto = new Bitmap(selectedPhoto);
                }

                // ==========================================
                // APPLY MALE / FEMALE SUIT
                // ==========================================

                if (idBackgroundOption == "male" ||
                    idBackgroundOption == "female")
                {
                    DebugLog(
                        "Applying " +
                        idBackgroundOption +
                        " suit..."
                    );

                    finalPhoto =
                        suitOverlayService.ApplySuit(
                            processedPhoto,
                            idBackgroundOption
                        );
                }
                else
                {
                    finalPhoto = new Bitmap(processedPhoto);
                }

                // ==========================================
                // GENERATE ID LAYOUT
                // ==========================================

                Bitmap layout =
                    GenerateSingleLayout(finalPhoto);

                if (idSettingsPicturePreview.Image != null)
                {
                    idSettingsPicturePreview.Image.Dispose();
                    idSettingsPicturePreview.Image = null;
                }

                idSettingsPicturePreview.Image = layout;
                idSettingsPicturePreview.SizeMode =
                    PictureBoxSizeMode.Zoom;

                UpdateMiniPreview();
            }
            catch (Exception ex)
            {
                DebugLog(
                    "ID photo processing error: " +
                    ex.Message
                );

                MessageBox.Show(
                    "Unable to process the ID photo.\n\n" +
                    ex.Message,
                    "ID Photo Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            finally
            {
                if (processedPhoto != null)
                    processedPhoto.Dispose();

                if (finalPhoto != null)
                    finalPhoto.Dispose();
            }
        }

        private Bitmap RemoveIdBackground(Bitmap source)
        {
            if (source == null)
                return null;

            Bitmap result = new Bitmap(source.Width, source.Height, PixelFormat.Format32bppArgb);

            result.SetResolution(source.HorizontalResolution, source.VerticalResolution);

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color pixel = source.GetPixel(x, y);

                    // Detect bright/near-white background
                    bool isBackground =
                        pixel.R > 200 &&
                        pixel.G > 200 &&
                        pixel.B > 200;

                    if (isBackground)
                    {
                        // Make background transparent
                        result.SetPixel(x, y, Color.Transparent);
                    }
                    else
                    {
                        // Keep person
                        result.SetPixel(x, y, Color.FromArgb(
                            255,
                            pixel.R,
                            pixel.G,
                            pixel.B
                        ));
                    }
                }
            }

            // Put the transparent result onto a WHITE background
            Bitmap finalImage = new Bitmap(source.Width, source.Height, PixelFormat.Format24bppRgb);
            finalImage.SetResolution(source.HorizontalResolution, source.VerticalResolution);

            using (Graphics g = Graphics.FromImage(finalImage))
            {
                g.Clear(Color.White);

                g.DrawImage(
                    result,
                    new Rectangle(0, 0, finalImage.Width, finalImage.Height)
                );
            }

            result.Dispose();

            return finalImage;
        }

        private void UpdateMiniPreview()
        {
            if (selectedPhoto == null)
                return;

            int baseDpi = 100;

            int pageWidth = (int)(8.27 * baseDpi);
            int pageHeight = (int)(11.69 * baseDpi);

            Bitmap mini = new Bitmap(pageWidth, pageHeight);

            using (Graphics g = Graphics.FromImage(mini))
            {
                g.Clear(Color.White);

                using (Pen pen = new Pen(Color.Gray, 1))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                    Image previewPhoto = isColored
                        ? selectedPhoto
                        : ConvertToGrayscale(selectedPhoto);

                    // SINGLE MODE
                    if (!isMultiple)
                    {
                        int w = pageWidth / 3;
                        int h = pageHeight / 3;

                        int margin = 10;

                        int x = margin;
                        int y = margin;


                        DrawSingleLayout(g, previewPhoto, x, y, w, h, pen);
                    }
                    // MULTIPLE MODE
                    else
                    {
                        int layoutW = pageWidth / 4;
                        int layoutH = pageHeight / 6;

                        int cols = pageWidth / layoutW;
                        int rows = pageHeight / layoutH;

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                int x = col * layoutW;
                                int y = row * layoutH;

                                DrawSingleLayout(g, previewPhoto, x, y, layoutW, layoutH, pen);
                            }
                        }
                    }
                }
            }

            // dispose old
            if (idPrintPreviewMini.Image != null)
                idPrintPreviewMini.Image.Dispose();

            idPrintPreviewMini.Image = mini;

            // AUTO FIT TO PANEL
            idPrintPreviewMini.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void LoadIdRetrieval(string code)
        {
            string folder = @"C:\PrintAndSnap\ID\archive";

            string codeFolder = Path.Combine(folder, code);

            if (!Directory.Exists(codeFolder))
            {
                MessageBox.Show("❌ Invalid or expired code.");
                return;
            }

            // META

            if (!ValidateCode(codeFolder, out int uses, out int maxUses, out DateTime created, out string metaPath))
                return;

            // LOAD ALL PHOTOS
            capturedPhotos.Clear();

            for (int i = 1; i <= 4; i++)
            {
                string photoPath = Path.Combine(codeFolder, $"photo{i}.png");

                if (File.Exists(photoPath))
                {
                    using (var temp = new Bitmap(photoPath))
                    {
                        capturedPhotos.Add(new Bitmap(temp));
                    }
                }
            }

            if (capturedPhotos.Count == 0)
            {
                MessageBox.Show("No photos found.");
                return;
            }

            // NOW UPDATE META (ONLY IF SUCCESS)
            uses++;
            created = DateTime.Now;
            WriteMeta(metaPath, created, uses, maxUses);

            // SHOW INFO MESSAGE
            MessageBox.Show(
                this,
                $"Photos loaded!\n\n" +
                $"Usage: {uses}/{maxUses}\n" +
                $"Expires in 30 minutes after last use",
                "Retrieval Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // SET FIRST AS SELECTED
            selectedPhoto = (Bitmap)capturedPhotos[0].Clone();
            hasUserSelectedPhoto = true;

            //IMPORTANT
            currentRetrievedIdPath = Path.Combine(codeFolder, "photo1.png");
            isPhotoRetrievalMode = true;

            // UI
            ShowPhotoPanel(photoIDPanel, idPrintingSettings);
            
            UpdateIdSettings();

        }

        private void SetLayoutControlsEnabled(bool enabled)
        {
            radioBtn2x2.Enabled = enabled;
            radioBtn2x1.Enabled = enabled;
            radioBtn1x1.Enabled = enabled;
        }

        private void idPrintSettingsContinueBtn_Click(object obj, EventArgs args)
        {
            try
            {
                //==========
                //Printer Check
                //==========

                if (!IsPrinterReady(PHOTO_PRINTER))
                {
                    MessageBox.Show(
                        this,
                "Printer is not ready.\n\nPlease check the printer connection, paper, or printer status.",
                "Printer Not Ready",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
                        );
                    return;
                }
                DebugLog("SelectedPhoto NULL? " + (selectedPhoto == null));
                DebugLog("hasUserSelectedPhoto: " + hasUserSelectedPhoto);

                // =========================
                // VALIDATION FIRST
                // =========================
                if (selectedPhoto == null)
                {
                    DebugLog("ERROR: selectedPhoto is null");
                    MessageBox.Show("No Photo Selected");
                    return;
                }

                if (!hasUserSelectedPhoto)
                {
                    DebugLog("ERROR: user did not select photo");
                    MessageBox.Show(" Please select a photo first.");
                    return;
                }

                // =========================
                // GENERATE LAYOUT (ONLY ONCE)
                // =========================
                DebugLog("Generating layout...");

                Bitmap photoToPrint = null;
                Bitmap processedPhoto = null;

                try
                {
                    // ==========================================
                    // BACKGROUND REMOVAL
                    // ==========================================

                    if (idBackgroundOption == "white" ||
                        idBackgroundOption == "male" ||
                        idBackgroundOption == "female")
                    {
                        processedPhoto =
                            backgroundRemovalService.RemoveBackground(
                                selectedPhoto
                            );
                    }
                    else
                    {
                        processedPhoto =
                            new Bitmap(selectedPhoto);
                    }

                    // ==========================================
                    // APPLY SUIT
                    // ==========================================

                    if (idBackgroundOption == "male" ||
                        idBackgroundOption == "female")
                    {
                        photoToPrint =
                            suitOverlayService.ApplySuit(
                                processedPhoto,
                                idBackgroundOption
                            );
                    }
                    else
                    {
                        photoToPrint =
                            new Bitmap(processedPhoto);
                    }

                    // ==========================================
                    // GENERATE FINAL ID LAYOUT
                    // ==========================================

                    finalIdPrintImage =
                        layoutService.GenerateIdLayout(
                            photoToPrint,
                            selectedLayout,
                            isColored,
                            isMultiple
                        );
                }
                finally
                {
                    if (photoToPrint != null)
                        photoToPrint.Dispose();

                    if (processedPhoto != null)
                        processedPhoto.Dispose();
                }

                if (finalIdPrintImage == null)
                {
                    DebugLog("ERROR: finalIdPrintImage is null");
                    MessageBox.Show("Failed to generate image.");
                    return;
                }

                DebugLog("Layout generated successfully");

                // =========================
                // SAVE TEMP
                // =========================
                string saveFolder = @"C:\PrintAndSnap\ID\temp";
                Directory.CreateDirectory(saveFolder);

                lastSavedIdFileName = "ID_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
                string filePath = Path.Combine(saveFolder, lastSavedIdFileName);

                DebugLog("Saving file: " + filePath);

                finalIdPrintImage.Save(filePath, ImageFormat.Png);

                DebugLog("File saved successfully");

                // =========================
                // PRICE (SAFE PARSE)
                // =========================
                string priceText = idPrintingTotal.Text.Trim();

                if (!int.TryParse(priceText, out totalIdPrice))
                {
                    MessageBox.Show("Invalid price.");
                    return;
                }

                paymentIDTotal.Text = totalIdPrice.ToString();
                paymentController.StartPayment(totalIdPrice);
                printBtn.Enabled = false;
                downloadBtnPaymentId.Enabled = false;

                currentMode = PhotoMode.ID;

                DebugLog("Switching to PAYMENT PANEL...");

                ShowPhotoPanel(photoIDPanel, IDpayment);

                DebugLog("PAYMENT PANEL SHOULD NOW BE VISIBLE");
            }
            catch (Exception ex)
            {
                DebugLog("CRASH: " + ex.Message);
                DebugLog("STACK: " + ex.StackTrace);

                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void idCaptureAgainBtn_Click(object obj, EventArgs args)
        {
            captureTimer.Stop();
            countdown = 3;
            ResetPhotoSession();

            idCaptureBtn.Text = "";
            idCaptureAgainBtn.Text = "";
            idCaptureBtn.BackgroundImage = global::Snap_and_Print.Properties.Resources.camera_fill;
            idCaptureBtn.Enabled = true;
            idCaptureAgainBtn.Enabled = false;
        }

        private void PrinterStatusTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                string printerName = DOCUMENT_PRINTER;

                if (!printerManager.PrinterExists(printerName))
                {
                    printerStatusLabel.Text = "● PRINTER NOT FOUND";
                    printerStatusLabel.ForeColor = Color.Red;
                    return;
                }

                if (!printerManager.IsPrinterOnline(printerName))
                {
                    printerStatusLabel.Text = "● PRINTER OFFLINE";
                    printerStatusLabel.ForeColor = Color.Red;
                    return;
                }

                string status = printerManager.GetPrinterStatus(printerName);

                if (status == "Printer Ready" || status == "Printing")
                {
                    printerStatusLabel.Text = "● PRINTER READY";
                    printerStatusLabel.ForeColor = Color.Green;
                }
                else
                {
                    printerStatusLabel.Text = "● " + status.ToUpper();
                    printerStatusLabel.ForeColor = Color.Orange;
                }
            }
            catch (Exception ex)
            {
                DebugLog("Printer status error: " + ex.Message);

                printerStatusLabel.Text = "● PRINTER ERROR";
                printerStatusLabel.ForeColor = Color.Orange;
            }
        }

        // ID RADIO BUTTONS
        private void radioBtn2x2_click(object obj, EventArgs args)
        {
            selectedLayout = "2x2";
            UpdateIdSettings();
        }

        private void radioBtn1x1_click(object obj, EventArgs args)
        {
            selectedLayout = "1x1";
            UpdateIdSettings();
        }

        private void radioBtn2x1_click(object obj, EventArgs args)
        {
            selectedLayout = "2x1";
            UpdateIdSettings();
        }

        private void radioBtnSinglePhotoCopies_click(object obj, EventArgs args)
        {
            isMultiple = false;

            numericIdPrintingCopies.Value = 1;
            numericIdPrintingCopies.Enabled = false;

            CalculateIdPrice();
            UpdateIdSettings();
        }

        private void radioBtnMultipleCopies_click(object obj, EventArgs args)
        {
            isMultiple = true;

            numericIdPrintingCopies.Enabled = true;

            CalculateIdPrice();
            UpdateIdSettings();
        }

        private void radioBtnPhotoBlack_click(object obj, EventArgs args)
        {
            isColored = false;
            CalculateIdPrice();
            UpdateIdSettings();
        }

        private void radioBtnPhotoColored_click(object obj, EventArgs args)
        {
            isColored = true;
            CalculateIdPrice();
            UpdateIdSettings();
        }

        //ID LOGIC
        private void CalculateIdPrice()
        {
            int copies = (int)numericIdPrintingCopies.Value;

            int pricePerUnit = 0;

            if (!isMultiple) //SINGLE
            {
                if (isColored)
                    pricePerUnit = 15;
                else
                    pricePerUnit = 10;
            }
            else //MULTIPLE (FULL SHEET)
            {
                if (isColored)
                    pricePerUnit = 25;
                else
                    pricePerUnit = 20;
            }

            int total = pricePerUnit * copies;

            idPrintingTotal.Text = total.ToString();
        }

        private Bitmap ConvertToGrayscale(Bitmap original)
        {
            Bitmap gray = new Bitmap(original.Width, original.Height);

            using (Graphics g = Graphics.FromImage(gray))
            {
                ColorMatrix colorMatrix = new ColorMatrix(
                    new float[][]
                    {
                        new float[] {0.3f, 0.3f, 0.3f, 0, 0},
                        new float[] {0.59f, 0.59f, 0.59f, 0, 0},
                        new float[] {0.11f, 0.11f, 0.11f, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {0, 0, 0, 0, 1}
                    });

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(original,
                    new Rectangle(0, 0, original.Width, original.Height),
                    0, 0, original.Width, original.Height,
                    GraphicsUnit.Pixel,
                    attributes);
            }

            return gray;
        }

        private void ResetPhotoSession()
        {
            ResetIdPreviewBoxes();

            //clear photos
            foreach (var img in capturedPhotos)
                img.Dispose();

            capturedPhotos.Clear();

            // reset preview boxes
            PictureBox[] idBoxes =
            {
        idPreviewPictureBox1,
        idPreviewPictureBox2,
        idPreviewPictureBox3,
        idPreviewPictureBox4
    };

            PictureBox[] funBoxes =
            {
        funPreview1,
        funPreview2,
        funPreview3,
        funPreview4
    };

            foreach (var box in idBoxes.Concat(funBoxes))
            {
                if (box.Image != null)
                {
                    box.Image.Dispose();
                    box.Image = null;
                }

                // IMPORTANT:
                // Hide preview boxes when resetting the photo session
                box.Visible = false;

                // Reset selection appearance
                box.BorderStyle = BorderStyle.None;
                box.BackColor = Color.Transparent;
                box.Padding = new Padding(0);
            }

            // reset buttons
            funContinueBtn.Enabled = false;
            idPrintingContinueBtn.Enabled = false;

            // reset selection
            selectedPhoto = null;
            hasUserSelectedPhoto = false;
        }

        private void DebugLog(string message)
        {
            Debug.WriteLine("[DEBUG] " + message);

            try
            {
                File.AppendAllText(@"C:\PrintAndSnap\debug_log.txt",
                    DateTime.Now.ToString("HH:mm:ss") + " - " + message + Environment.NewLine);
            }
            catch { }
        }

        private Bitmap GenerateSingleLayout(Bitmap photo)
        {
            if (photo == null)
                return null;

            int dpi = 300;

            int width = 2 * dpi;
            int height = 2 * dpi;

            if (selectedLayout == "1x1")
            {
                width = 1 * dpi;
                height = 1 * dpi;
            }

            Bitmap canvas = new Bitmap(width, height);
            canvas.SetResolution(300, 300);

            using (Graphics g = Graphics.FromImage(canvas))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.Clear(Color.White);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                DrawSingleLayout(g, isColored ? photo : ConvertToGrayscale(photo), 0, 0, width, height, pen);
            }

            return canvas;
        }

        private void DrawSingleLayout(Graphics g, Image photo, int x, int y, int width, int height, Pen pen)
        {
            int gap = 10; // SPACE BETWEEN PHOTOS

            if (selectedLayout == "2x2")
            {
                int w = (width - gap) / 2;
                int h = (height - gap) / 2;

                for (int r = 0; r < 2; r++)
                {
                    for (int c = 0; c < 2; c++)
                    {
                        int px = x + c * (w + gap);
                        int py = y + r * (h + gap);

                        g.DrawImage(photo, px, py, w, h);
                        g.DrawRectangle(Pens.Black, px, py, w, h);
                    }
                }

                // CUT LINES (center)
                int midX = x + width / 2;
                int midY = y + height / 2;

                g.DrawLine(pen, midX, y, midX, y + height); // vertical
                g.DrawLine(pen, x, midY, x + width, midY); // horizontal
            }

            else if (selectedLayout == "1x1")
            {
                g.DrawImage(photo, x, y, width, height);
                g.DrawRectangle(Pens.Black, x, y, width, height);
            }

            else if (selectedLayout == "2x1")
            {
                int h = (height - gap) / 2;

                for (int i = 0; i < 2; i++)
                {
                    int py = y + i * (h + gap);

                    g.DrawImage(photo, x, py, width, h);
                    g.DrawRectangle(Pens.Black, x, py, width, h);
                }

                // CUT LINE (middle)
                int midY = y + height / 2;
                g.DrawLine(pen, x, midY, x + width, midY);
            }
        }

        // =========================
        // FUN MODE METHODS
        // =========================
        private void funModeBtn_Click(object sender, EventArgs e)
        {
            ResetPhotoSession(); // unified reset

            currentMode = PhotoMode.Fun; // NEW SYSTEM

            ShowPhotoPanel(photoBoothPanel, panelCMRphotoBooth);

            if (funCameraFeed.Image != null)
            {
                funCameraFeed.Image.Dispose();
                funCameraFeed.Image = null;
            }

            try
            {
                cameraService.StartCamera();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            funCameraFeed.Focus();
        }

        private void funCaptureBtn_Click(object sender, EventArgs args)
        {
            if (currentFrame == null)
                return;

            if (captureTimer.Enabled)
                return;

            if (capturedPhotos.Count >= 4)
            {
                MessageBox.Show("Maximum of 4 photos only.");
                return;
            }

            activeCaptureButton = funCaptureBtn;

            // Disable everything while countdown is running
            funCaptureBtn.Enabled = false;
            funCaptureAgainBtn.Enabled = false;
            funContinueBtn.Enabled = false;

            funCaptureBtn.BackgroundImage = null;

            countdown = 3;
            captureTimer.Start();
        }

        private async void funContinueBtn_Click(object sender, EventArgs args)
        {
            if (isProcessing)
                return;

            // =========================
            // VALIDATION
            // =========================

            if (capturedPhotos.Count == 0)
            {
                MessageBox.Show(
                    "Please capture at least one photo.",
                    "No Photo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (capturedPhotos.Count > 1 && !hasUserSelectedPhoto)
            {
                MessageBox.Show(
                    "Please select ONE photo to continue.",
                    "Select Photo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (selectedPhoto == null)
            {
                MessageBox.Show(
                    "Please select one photo to continue.",
                    "Select Photo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            isProcessing = true;
            funContinueBtn.Enabled = false;

            try
            {
                // =========================
                // STOP CAMERA
                // =========================

                await Task.Run(() => cameraService.StopCamera());
                await Task.Delay(200);

                // =========================
                // FUN DEFAULT SETTINGS
                // =========================

                funFilter = "none";
                funLayout = "none";
                funFrame = "none";

                funRadioBtnFilterNone.Checked = true;
                funRadioBtnFrameNone.Checked = true;

                // =========================
                // LOAD SELECTED PHOTO
                // INTO FUN SETTINGS
                // =========================

                UpdateFunSettings();

                // =========================
                // GO TO FUN SETTINGS
                // =========================

                ShowPhotoPanel(
                    photoBoothPanel,
                    photoBoothSettings
                );
            }
            catch (Exception ex)
            {
                DebugLog("FUN Continue error: " + ex.Message);

                MessageBox.Show(
                    this,
                    "Unable to continue.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                isProcessing = false;

                if (capturedPhotos.Count > 0)
                    funContinueBtn.Enabled = true;
            }
        }

        private void ShowFunCapturedPhotos()
        {
            PictureBox[] boxes =
            {
        funPreview1,
        funPreview2,
        funPreview3,
        funPreview4
    };

            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Click -= SelectCapturedFunPhoto_Click;

                if (i < capturedPhotos.Count)
                {
                    SafeDisposePictureBox(boxes[i]);

                    boxes[i].Image = (Bitmap)capturedPhotos[i].Clone();
                    boxes[i].Visible = true;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;

                    // Reset appearance
                    boxes[i].BorderStyle = BorderStyle.None;
                    boxes[i].BackColor = Color.Transparent;
                    boxes[i].Padding = new Padding(0);

                    // Make clickable
                    boxes[i].Click += SelectCapturedFunPhoto_Click;
                }
                else
                {
                    boxes[i].Visible = false;
                }
            }
        }

        private void SelectCapturedFunPhoto_Click(object sender, EventArgs e)
        {
            PictureBox clicked = sender as PictureBox;

            if (clicked == null || clicked.Image == null)
                return;

            int selectedIndex = -1;

            if (clicked == funPreview1)
                selectedIndex = 0;
            else if (clicked == funPreview2)
                selectedIndex = 1;
            else if (clicked == funPreview3)
                selectedIndex = 2;
            else if (clicked == funPreview4)
                selectedIndex = 3;

            if (selectedIndex < 0 || selectedIndex >= capturedPhotos.Count)
                return;

            // Remove previous selected photo
            if (selectedPhoto != null)
            {
                selectedPhoto.Dispose();
                selectedPhoto = null;
            }

            // Save selected photo
            selectedPhoto = (Bitmap)capturedPhotos[selectedIndex].Clone();
            hasUserSelectedPhoto = true;

            // Reset all boxes
            PictureBox[] boxes =
            {
        funPreview1,
        funPreview2,
        funPreview3,
        funPreview4
    };

            foreach (PictureBox box in boxes)
            {
                box.BorderStyle = BorderStyle.None;
                box.BackColor = Color.Transparent;
                box.Padding = new Padding(0);
            }

            // Highlight selected photo
            clicked.BorderStyle = BorderStyle.FixedSingle;
            clicked.BackColor = Color.LightPink;
            clicked.Padding = new Padding(4);

            // Enable Continue
            funContinueBtn.Enabled = true;
        }

        private void LoadFunSelectionPhotos()
        {
            if (capturedPhotos.Count == 0)
                return;

            hasUserSelectedPhoto = false;

            PictureBox[] boxes =
            {
            funSelectPic1,
            funSelectPic2,
            funSelectPic3,
            funSelectPic4
            };

            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i] == null) continue;

                boxes[i].Click -= SelectCapturedFunPhoto_Click;

                if (i < capturedPhotos.Count)
                {
                    if (boxes[i].Image != null)
                        boxes[i].Image.Dispose();

                    boxes[i].Image = (Bitmap)capturedPhotos[i].Clone();
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Visible = true;

                    boxes[i].Click += SelectCapturedFunPhoto_Click;
                }
                else
                {
                    boxes[i].Visible = false;
                }

                CalculateFunPrice();
            }

            // SAFE AUTO SELECT
            if (capturedPhotos.Count > 0 && boxes[0] != null)
            {
                selectedPhoto = (Bitmap)capturedPhotos[0].Clone();
                hasUserSelectedPhoto = true;

                funRadioBtnFilterNone.Checked = true;
                funRadioBtnFrameNone.Checked = true;

                UpdatePrintTypeAvailability();
                HighlightFunSelectedPhoto(boxes[0]);
                UpdateFunSettings();
            }
        }

        private void HighlightFunSelectedPhoto(PictureBox selectedBox)
        {
            PictureBox[] boxes =
            {
            funSelectPic1,
            funSelectPic2,
            funSelectPic3,
            funSelectPic4
            };

            foreach (var box in boxes)
            {
                box.BorderStyle = BorderStyle.None;
                box.BackColor = Color.Transparent;
                box.Padding = new Padding(0);
            }

            selectedBox.BorderStyle = BorderStyle.FixedSingle;
            selectedBox.BackColor = Color.LightPink;
            selectedBox.Padding = new Padding(3);
        }

        private void SelectPhoto_Click(object sender, EventArgs e)
        {
            PictureBox clicked = sender as PictureBox;

            if (clicked == null)
                return;

            if (clicked == idSettingsSelectPicture1)
            {
                idBackgroundOption = "none";
            }
            else if (clicked == idSettingsSelectPicture2)
            {
                idBackgroundOption = "white";
            }
            else if (clicked == idSettingsSelectPicture3)
            {
                idBackgroundOption = "male";
            }
            else if (clicked == idSettingsSelectPicture4)
            {
                idBackgroundOption = "female";
            }
            else
            {
                return;
            }

            // Highlight selected option
            HighlightSelectedPhoto(clicked);

            // Rebuild ID preview
            UpdateIdSettings();
        }

        private void UpdateFunSettings()
        {
            if (selectedPhoto == null)
                return;

            // =========================
            // SMART FILTER CACHE
            // =========================
            if (cachedFilteredPhotos.Count == 0 || lastAppliedFilter != funFilter)
            {
                cachedFilteredPhotos.Clear();

                foreach (var photo in capturedPhotos)
                {
                    cachedFilteredPhotos.Add(filterService.ApplyFunFilter(photo, funFilter));
                }

                lastAppliedFilter = funFilter;
            }

            // =========================
            // BUILD PHOTOS
            // =========================
            List<Bitmap> photosToUse = new List<Bitmap>();

            bool isSingle = funRadioPrintTypeSingle.Checked;

            int needed = (funLayout == "grid") ? 4 : 2;

            if (isSingle)
            {
                Bitmap filteredSelected =
                    filterService.ApplyFunFilter(selectedPhoto, funFilter);

                for (int i = 0; i < needed; i++)
                {
                    photosToUse.Add((Bitmap)filteredSelected.Clone());
                }

                filteredSelected.Dispose();
            }
            else
            {
                int index = 0;

                while (photosToUse.Count < needed)
                {
                    if (cachedFilteredPhotos.Count == 0)
                        break;

                    photosToUse.Add((Bitmap)cachedFilteredPhotos[index % cachedFilteredPhotos.Count].Clone());
                    index++;
                }
            }

            // =========================
            // APPLY FRAME PER PHOTO
            // =========================
            List<Bitmap> framedPhotos = new List<Bitmap>();

            foreach (var photo in photosToUse)
            {
                Bitmap framed = frameService.ApplyFunFrame(photo, funFrame);
                if (framed != null)
                    framedPhotos.Add(framed);
            }

            // =========================
            // APPLY LAYOUT
            // =========================
            Bitmap preview = layoutService.ApplyFunLayout(framedPhotos, funLayout, false);

            if (preview == null)
                return;

            // =========================
            // PREVIEW DISPLAY
            // =========================
            if (funMainPreview.Image != null)
                funMainPreview.Image.Dispose();

            funMainPreview.Image = (Bitmap)preview.Clone();
            funMainPreview.SizeMode = PictureBoxSizeMode.Zoom;

            if (funMiniPreview.Image != null)
                funMiniPreview.Image.Dispose();

            Bitmap miniPreview = layoutService.ApplyFunLayout(framedPhotos, funLayout, true);
            funMiniPreview.Image = miniPreview;
            funMiniPreview.SizeMode = PictureBoxSizeMode.Zoom;

            // =========================
            // CLEANUP
            // =========================
            foreach (var img in photosToUse)
                img.Dispose();

            foreach (var img in framedPhotos)
                img.Dispose();

            preview.Dispose();
        }

        private List<Bitmap> BuildFunPhotos()
        {
            List<Bitmap> photosToUse;

            bool isSingle = funRadioPrintTypeSingle.Checked;

            if (isSingle)
            {
                photosToUse = new List<Bitmap>();

                int needed = (funLayout == "grid") ? 4 : 2;

                Bitmap filteredSelected =
                    filterService.ApplyFunFilter(selectedPhoto, funFilter);

                for (int i = 0; i < needed; i++)
                {
                    photosToUse.Add((Bitmap)filteredSelected.Clone());
                }

                filteredSelected.Dispose();
            }
            else
            {
                photosToUse = new List<Bitmap>();

                int needed = 1;

                if (funLayout == "grid")
                    needed = 4;
                else if (funLayout == "vertical")
                    needed = 2;

                int index = 0;

                while (photosToUse.Count < needed)
                {
                    if (cachedFilteredPhotos.Count == 0)
                        break;

                    photosToUse.Add((Bitmap)cachedFilteredPhotos[index % cachedFilteredPhotos.Count].Clone());
                    index++;
                }
            }

            return photosToUse;
        }

        private void funCaptureAgainBtn_Click(object obj, EventArgs args)
        {
            // Stop any active countdown
            captureTimer.Stop();

            // Reset countdown
            countdown = 3;

            // Reset all captured photos/session
            ResetPhotoSession();

            // Reset Capture button
            funCaptureBtn.Text = "";
            funCaptureBtn.BackgroundImage =
                global::Snap_and_Print.Properties.Resources.camera_fill;
            funCaptureBtn.Enabled = true;

            // Capture Again must be disabled until a photo is captured again
            funCaptureAgainBtn.Text = "";
            funCaptureAgainBtn.Enabled = false;

            // Continue must also be disabled
            funContinueBtn.Enabled = false;

            // Make sure no old active capture button remains
            activeCaptureButton = null;
        }

        private void funSettingsContinueBtn_Click(object sender, EventArgs e)
        {
            //=================
            //PRINTER CHECK
            //=================
            if (!IsPrinterReady(PHOTO_PRINTER))
            {
                MessageBox.Show(
                    this,
                    "Printer is not ready.\n\nPlease check the printer connection, paper, or printer status.",
                    "Printer Not Ready",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (funMainPreview.Image == null)
            {
                MessageBox.Show("⚠️ No preview available.");
                return;
            }

            // USE EXACT PREVIEW (THIS FIXES FRAME ISSUE)
            // rebuild photos (same as preview logic)
            List<Bitmap> photosToUse = BuildFunPhotos();

            // apply frame
            List<Bitmap> framedPhotos = new List<Bitmap>();

            foreach (var photo in photosToUse)
            {
                Bitmap framed = frameService.ApplyFunFrame(photo, funFrame);
                if (framed != null)
                    framedPhotos.Add(framed);
            }

            // FINAL IMAGE WITH CUT LINES (FOR PRINT)
            finalFunImage = layoutService.ApplyFunLayout(framedPhotos, funLayout, true);

            // cleanup
            foreach (var img in photosToUse)
                img.Dispose();

            foreach (var img in framedPhotos)
                img.Dispose();

            if (finalFunImage == null)
            {
                MessageBox.Show("Failed to generate image.");
                return;
            }

            // PRICE
            totalFunPrice = int.Parse(funTotal.Text.Trim());

            paymentFunTotal.Text = totalFunPrice.ToString();
            paymentController.StartPayment(totalFunPrice);

            paymentFunPrintBtn.Enabled = false;

            currentMode = PhotoMode.Fun;

            funDownloadBtn.Enabled = false;

            ShowPhotoPanel(photoBoothPanel, funPaymentPanel);
        }

        //FUN LAYOUT
        private void funRadioBtnVertical_Click(object sender, EventArgs e)
        {
            if (funLayout == "vertical")
            {
                funLayout = "none";
                funRadioBtnVertical.Checked = false;
            }
            else
            {
                funLayout = "vertical";
                funRadioBtnVertical.Checked = true;
                funRadioBtnGridBtn.Checked = false;
            }

            UpdateFunSettings();
            CalculateFunPrice();
        }

        private void funRadioBtnGridBtn_Click(object sender, EventArgs e)
        {
            if (funLayout == "grid")
            {
                funLayout = "none";
                funRadioBtnGridBtn.Checked = false;
            }
            else
            {
                funLayout = "grid";
                funRadioBtnGridBtn.Checked = true;
                funRadioBtnVertical.Checked = false;
            }

            UpdateFunSettings();
            CalculateFunPrice();
        }

        //FUN FRAME
        private void funRadioBtnFrameNone_Click(object sender, EventArgs e)
        {
            funFrame = "none";
            UpdateFunSettings();
        }

        private void funRadioBtnMinimal_Click(object sender, EventArgs e)
        {
            funFrame = "minimal";
            UpdateFunSettings();
        }

        private void funRadioBtnCute_Click(object sender, EventArgs e)
        {
            funFrame = "cute";
            UpdateFunSettings();
        }

        //FUN FILTER
        private void funRadioBtbFilterNone_Click(object sender, EventArgs e)
        {
            funFilter = "none";
            UpdateFunSettings();
        }
        private void funRadioBtnWarm_Click(object sender, EventArgs e)
        {
            funFilter = "warm";
            UpdateFunSettings();
        }

        private void funRadioBtnBlack_Click(object sender, EventArgs e)
        {
            funFilter = "black";
            UpdateFunSettings();
        }

        // FUN PRINT TYPE
        private void funRadioPrintTypeSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (funRadioPrintTypeSingle.Checked)
            {
                // 🔥 ensure a photo is selected
                if (selectedPhoto == null && capturedPhotos.Count > 0)
                {
                    selectedPhoto = (Bitmap)capturedPhotos[0].Clone();
                    hasUserSelectedPhoto = true;
                }

                UpdatePhotoSelectionState();
                UpdateFunSettings();
            }
        }

        private void funRadioPrintTypeAll_CheckedChanged(object sender, EventArgs e)
        {
            if (funRadioPrintTypeAll.Checked)
            {
                UpdatePhotoSelectionState();
                UpdateFunSettings();
            }
        }

        private void UpdatePhotoSelectionState()
        {
            bool isSingle = funRadioPrintTypeSingle.Checked;

            PictureBox[] boxes =
            {
        funSelectPic1,
        funSelectPic2,
        funSelectPic3,
        funSelectPic4
    };

            foreach (var box in boxes)
            {
                box.Enabled = isSingle;
                box.BackColor = isSingle ? Color.Transparent : Color.LightGray;
            }
        }

        private void UpdatePrintTypeAvailability()
        {
            int count = capturedPhotos.Count;

            if (count <= 1)
            {
                // FORCE PRINT ALL
                funRadioPrintTypeAll.Checked = true;
                UpdateFunSettings();

                funRadioPrintTypeSingle.Enabled = false;
                funRadioPrintTypeAll.Enabled = false;

                // optional UI feedback
                funRadioPrintTypeAll.Text = "Print All (Auto)";
            }
            else
            {
                // ENABLE OPTIONS
                funRadioPrintTypeSingle.Enabled = true;
                funRadioPrintTypeAll.Enabled = true;

                funRadioPrintTypeAll.Text = "Print All";
            }
        }

        //FUN LOGIC
        private void CalculateFunPrice()
        {
            int copies = (int)funNumericCopies.Value;

            int pricePerUnit = 10; // default

            // layout affects price
            if (funLayout == "grid")
                pricePerUnit = 15;
            else if (funLayout == "vertical")
                pricePerUnit = 10;
            else
                pricePerUnit = 10;

            int total = pricePerUnit * copies;

            totalFunPrice = total;

            funTotal.Text = total.ToString();
        }

        private void ResetFunCache()
        {
            cachedFilteredPhotos.Clear();
            lastAppliedFilter = "";
        }

        private void LoadFunRetrieval(string code)
        {
            string folder = @"C:\PrintAndSnap\FUN\archive";
            string codeFolder = Path.Combine(folder, code);

            if (!Directory.Exists(codeFolder))
            {
                MessageBox.Show("❌ Invalid or expired code.");
                return;
            }

            if (!ValidateCode(codeFolder, out int uses, out int maxUses, out DateTime created, out string metaPath))
                return;

            // LOAD PHOTOS
            capturedPhotos.Clear();

            for (int i = 1; i <= 4; i++)
            {
                string photoPath = Path.Combine(codeFolder, $"photo{i}.png");

                if (File.Exists(photoPath))
                {
                    using (var temp = new Bitmap(photoPath))
                    {
                        capturedPhotos.Add(new Bitmap(temp));
                    }
                }
            }

            if (capturedPhotos.Count == 0)
            {
                MessageBox.Show("No photos found.");
                return;
            }

            // UPDATE USAGE + RESET TIMER
            uses++;
            created = DateTime.Now;

            // ALWAYS SAVE FIRST (IMPORTANT FIX)
            WriteMeta(metaPath, created, uses, maxUses);

            // DELETE AFTER LAST USE
            if (uses >= maxUses)
            {
                try
                {
                    Directory.Delete(codeFolder, true);
                }
                catch { }

                MessageBox.Show(
                    $"Photos loaded!\n\n" +
                    $"This was your LAST use.\n" +
                    $"Code is now expired."
                );
            }
            else
            {
                MessageBox.Show(
                    $"Photos loaded!\n\n" +
                    $"Usage: {uses}/{maxUses}\n" +
                    $"Remaining: {maxUses - uses}"
                );
            }

            selectedPhoto = (Bitmap)capturedPhotos[0].Clone();
            hasUserSelectedPhoto = true;

            ShowPhotoPanel(photoBoothPanel, photoBoothSettings);
            LoadFunSelectionPhotos();
            UpdateFunSettings();
            UpdatePrintTypeAvailability();

            currentFunRetrievalCode = code;
        }

        // =====================
        // PHOTO META FILE
        // =====================
        private (int uses, int maxUses, DateTime created, string metaPath) ReadMeta(string codeFolder)
        {
            string metaPath = Path.Combine(codeFolder, "meta.txt");

            if (!File.Exists(metaPath))
            {
                // AUTO FIX (no exception)
                DateTime created = DateTime.Now;
                int uses = 0;
                int maxUses = 3;

                WriteMeta(metaPath, created, uses, maxUses);

                Debug.WriteLine("META WAS MISSING → RECREATED");

                return (uses, maxUses, created, metaPath);
            }

            var lines = File.ReadAllLines(metaPath);

            DateTime createdParsed = DateTime.Parse(lines[0].Split('=')[1]);
            int usesParsed = int.Parse(lines[1].Split('=')[1]);
            int maxUsesParsed = int.Parse(lines[2].Split('=')[1]);

            return (usesParsed, maxUsesParsed, createdParsed, metaPath);
        }

        private void WriteMeta(string metaPath, DateTime created, int uses, int maxUses)
        {
            File.WriteAllLines(metaPath, new[]
            {
        $"created={created}",
        $"uses={uses}",
        $"maxUses={maxUses}"
    });
        }

        // =======================
        // RETRIEVAL METHODS
        // =======================
        private void photoBtnRetrieve_Click(object sender, EventArgs e)
        {
            // FORCE HIDE EVERYTHING FIRST
            foreach (Control c in photoPanel.Controls)
            {
                c.Visible = false;
            }

            retrievalPanelPhoto.Visible = true;
            retrievalPanelPhoto.BringToFront();

            PhotoRetrievePanel.Visible = true;
            PhotoRetrievePanel.BringToFront();
        }

        private void photoRetrievalBtn_Click(object sender, EventArgs e)
        {
            string code = photoRetrievalCodeBox.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("Enter retrieval code.");
                return;
            }

            // attempts check stays
            if (retrievalAttempts >= MAX_RETRIEVAL_ATTEMPTS)
            {
                MessageBox.Show("❌ Too many attempts.");
                printingInProgress = false;
                allowReset = true;
                ResetMachine(true);
                return;
            }

            bool exists =
                Directory.Exists(Path.Combine(@"C:\PrintAndSnap\ID\archive", code)) ||
                Directory.Exists(Path.Combine(@"C:\PrintAndSnap\FUN\archive", code));

            if (!exists)
            {
                retrievalAttempts++;
                int remaining = MAX_RETRIEVAL_ATTEMPTS - retrievalAttempts;

                MessageBox.Show($"❌ Invalid code. Attempts left: {remaining}");
                return;
            }

            retrievalAttempts = 0;

            LoadUniversalRetrieval(code);
        }

        private void LoadUniversalRetrieval(string code)
        {
            string idFolder = Path.Combine(@"C:\PrintAndSnap\ID\archive", code);
            string funFolder = Path.Combine(@"C:\PrintAndSnap\FUN\archive", code);

            if (Directory.Exists(idFolder))
            {
                LoadIdRetrieval(code);
                return;
            }

            if (Directory.Exists(funFolder))
            {
                LoadFunRetrieval(code);
                return;
            }

            MessageBox.Show("Invalid or expired code.");
        }

        private bool ValidateCode(string codeFolder, out int uses, out int maxUses, out DateTime created, out string metaPath)
        {
            uses = 0;
            maxUses = 0;
            created = DateTime.MinValue;
            metaPath = "";

            try
            {
                var meta = ReadMeta(codeFolder);

                uses = meta.uses;
                maxUses = meta.maxUses;
                created = meta.created;
                metaPath = meta.metaPath;

                if ((DateTime.Now - created).TotalMinutes > 30)
                {
                    try
                    {
                        Directory.Delete(codeFolder, true);
                    }
                    catch { }

                    MessageBox.Show("❌ Code expired.");
                    return false;
                }

                // LIMIT
                if (uses >= maxUses)
                {
                    try
                    {
                        Directory.Delete(codeFolder, true);
                    }
                    catch { }

                    MessageBox.Show("❌ Code has reached maximum usage.");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message == "META_MISSING")
                {
                    MessageBox.Show("❌ Code data missing. File may be corrupted.");
                }
                else
                {
                    MessageBox.Show("❌ Invalid code.");
                }

                return false;
            }
        }

        private string GenerateRetrievalCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            return new string(Enumerable.Range(0, 6)
                .Select(x => chars[rand.Next(chars.Length)]).ToArray());
        }

        private void LoadRetrievalFile(string code)
        {
            string archiveFolder = @"C:\PrintAndSnap\DOCS\archive";

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

            lastSavedIdFileName = Path.GetFileName(currentRetrievedIdPath);

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

        // ID PAYMENT
        private void printBtnPaymentId_Click(object sender, EventArgs e)
        {
            PrintIdPhoto();
        }

        private async void PrintIdPhoto()
        {

            // BLOCK IF NOT FULLY PAID
            if (paymentController.InsertedPayment < paymentController.TotalAmount)
            {
                MessageBox.Show("Please complete payment first.");
                return;
            }

            if (finalIdPrintImage == null)
            {
                MessageBox.Show("No image to print.");
                return;
            }

            try
            {
                printingInProgress = true;

                printBtnPaymentId.Enabled = false;
                // disable download until done
                downloadBtnPaymentId.Enabled = false;

                Bitmap readyToPrint = finalIdPrintImage;

                string printMode = isMultiple ? "multiple" : "single";

                // STATUS
                idprintingStatusLabel.Text = "Printing...";
                idprintingStatusLabel.Visible = true;


                try
                {
                    photoPrinting.PrintIdPhoto(readyToPrint, PHOTO_PRINTER, false, printMode);
                }
                catch
                {
                    Debug.WriteLine("Printer fallback used.");
                }

                // =========================
                // SMART TIMER (ID)
                // =========================
                int printTime = 0;

                if (!isMultiple) // SINGLE
                {
                    if (selectedLayout == "1x1")
                        printTime = 10000; // 10 sec
                    else if (selectedLayout == "2x1")
                        printTime = 12000; // 15 sec
                    else if (selectedLayout == "2x2")
                        printTime = 20000; // 20 sec
                }
                else // MULTIPLE
                {
                    printTime = 60000; // 70 sec
                }

                // TIMER LOOP
                for (int i = printTime / 1000; i > 0; i--)
                {
                    idprintingStatusLabel.Text = $"Printing... {i}s";

                    // allow cancel
                    if (!printingInProgress)
                    {
                        idprintingStatusLabel.Text = "Cancelled";
                        return;
                    }

                    await Task.Delay(1000);
                }



                idprintingStatusLabel.Text = "Done!";

                // =========================
                // CLEAN TEMP
                // =========================
                string tempFolder = @"C:\PrintAndSnap\ID\temp";
                if (Directory.Exists(tempFolder))
                {
                    foreach (var file in Directory.GetFiles(tempFolder))
                    {
                        try { File.Delete(file); } catch { }
                    }
                }

                // =========================
                // SAVE FILE
                // =========================
                string idArchiveFolder = @"C:\PrintAndSnap\ID\archive";
                string idDownloadFolder = @"C:\PrintAndSnap\ID\download";

                Directory.CreateDirectory(idArchiveFolder);
                Directory.CreateDirectory(idDownloadFolder);

                string code = "";
                string downloadFileName = "";

                if (!isPhotoRetrievalMode)
                {
                    code = "ID-" + GenerateRetrievalCode();

                    string codeFolder = Path.Combine(idArchiveFolder, code);
                    Directory.CreateDirectory(codeFolder);

                    for (int i = 0; i < capturedPhotos.Count; i++)
                    {
                        string photoPath = Path.Combine(codeFolder, $"photo{i + 1}.png");
                        capturedPhotos[i].Save(photoPath, ImageFormat.Png);
                    }

                    downloadFileName = code + ".png";
                    string downloadPath = Path.Combine(idDownloadFolder, downloadFileName);

                    finalIdPrintImage.Save(downloadPath, ImageFormat.Png);
                    lastSavedIdFileName = downloadFileName;

                    File.WriteAllLines(Path.Combine(codeFolder, "meta.txt"), new[]
                    {
                $"created={DateTime.Now}",
                $"uses=0",
                $"maxUses=3"
            });
                }
                else
                {
                    string codeFolder = Path.GetDirectoryName(currentRetrievedIdPath);
                    string codeName = new DirectoryInfo(codeFolder).Name;

                    downloadFileName = codeName + ".png";
                    string downloadPath = Path.Combine(idDownloadFolder, downloadFileName);

                    finalIdPrintImage.Save(downloadPath, ImageFormat.Png);
                    lastSavedIdFileName = downloadFileName;

                    code = codeName;
                }

                // =========================
                // SHOW QR FIRST (IMPORTANT FIX)
                // =========================
                GenerateQrForDownload(downloadFileName);

                uploadService.uploadUsed = false;

                // ENABLE BUTTON FIRST
                this.Invoke(new Action(() =>
                {
                    downloadBtnPaymentId.Enabled = true;
                }));

                printingInProgress = false;

                string path = Path.Combine(ID_DOWNLOAD, downloadFileName);
                StartAutoCleanup(path);

                isPhotoRetrievalMode = false;
                currentRetrievedIdPath = null;

                // =========================
                // SHOW MESSAGE AFTER UI READY (FIXED)
                // =========================
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(
                        this,
                        $"Printed!\n\n" +
                        $"Retrieval Code: {code}\n" +
                        $"Uses: 0/3\n" +
                        $"Expires in 30 minutes",
                        "Print Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }));

            }
            catch (Exception ex)
            {
                printingInProgress = false;
                MessageBox.Show("Print failed: " + ex.Message);
            }
        }

        // FUN  PAYMENT
        private void paymentFunPrintBtn_Click(object sender, EventArgs e)
        {
            PrintFunPhoto();
        }

        private async void PrintFunPhoto()
        {
            // BLOCK IF NOT PAID 
            if (paymentController.InsertedPayment < paymentController.TotalAmount)
            {
                MessageBox.Show("Please complete payment first.");
                return;
            }

            if (finalFunImage == null)
            {
                MessageBox.Show("No image to print.");
                return;
            }

            try
            {
                printingInProgress = true;

                // disable print + download first
                paymentFunPrintBtn.Enabled = false;
                funDownloadBtn.Enabled = false;
                lastSavedFunFileName = null;

                Bitmap readyToPrint = layoutService.ResizeTo4x6(finalFunImage);

                // =========================
                // START PRINT FIRST
                // =========================
                photoPrinting.PrintFunPhoto(readyToPrint, PHOTO_PRINTER);

                // =========================
                // STATUS
                // =========================
                funPrintingStatusLabel.Text = "Printing...";
                funPrintingStatusLabel.Visible = true;

                // =========================
                // TIME CALCULATION
                // =========================
                int basePrintTime = 60000; // 70s base

                int filterTime = hasFilter ? 5000 : 0;
                int frameTime = hasFrame ? 5000 : 0;
                int photoCountTime = capturedPhotos.Count * 1000;

                int funPrintTime = basePrintTime + filterTime + frameTime + photoCountTime;

                // =========================
                // TIMER (THIS WAS MISSING BEFORE)
                // =========================
                for (int i = funPrintTime / 1000; i > 0; i--)
                {
                    funPrintingStatusLabel.Text = $"Printing... {i}s";
                    await Task.Delay(1000);
                }

                // =========================
                // CLEAN TEMP (FUN)
                // =========================
                string tempFolder = @"C:\PrintAndSnap\FUN\temp";

                if (Directory.Exists(tempFolder))
                {
                    foreach (var file in Directory.GetFiles(tempFolder))
                    {
                        try { File.Delete(file); } catch { }
                    }
                }

                // =========================
                // SAVE FILE
                // =========================
                string archiveFolder = @"C:\PrintAndSnap\FUN\archive";
                string downloadFolder = @"C:\PrintAndSnap\FUN\download";

                Directory.CreateDirectory(archiveFolder);
                Directory.CreateDirectory(downloadFolder);

                string code = "";

                if (string.IsNullOrEmpty(currentFunRetrievalCode))
                {
                    code = "FUN-" + GenerateRetrievalCode();

                    string codeFolder = Path.Combine(archiveFolder, code);
                    Directory.CreateDirectory(codeFolder);

                    for (int i = 0; i < capturedPhotos.Count; i++)
                    {
                        string photoPath = Path.Combine(codeFolder, $"photo{i + 1}.png");
                        capturedPhotos[i].Save(photoPath, ImageFormat.Png);
                    }

                    File.WriteAllLines(Path.Combine(codeFolder, "meta.txt"), new[]
                    {
                $"created={DateTime.Now}",
                $"uses=0",
                $"maxUses=3"
            });
                }
                else
                {
                    code = currentFunRetrievalCode;
                }

                string fileName = code + ".png";
                string downloadPath = Path.Combine(downloadFolder, fileName);

                List<Bitmap> photosToUse = BuildFunPhotos();

                Bitmap downloadImage = layoutService.ApplyDownloadLayout(photosToUse, funLayout);
                downloadImage.Save(downloadPath, ImageFormat.Png);

                // cleanup
                foreach (var img in photosToUse)
                    img.Dispose();

                downloadImage.Dispose();

                lastSavedFunFileName = fileName;
                currentFunRetrievalCode = code;

                // =========================
                // AUTO DELETE
                // =========================
                StartAutoCleanup(downloadPath);

                // =========================
                // ENABLE DOWNLOAD
                // =========================
                this.Invoke(new Action(() =>
                {
                    funDownloadBtn.Enabled = true;
                }));

                // =========================
                // FINISH STATE
                // =========================
                printingInProgress = false;

                funPrintingStatusLabel.Text = "Print complete!";

                StartAutoCleanup(downloadPath);

                // =========================
                // MESSAGE
                // =========================
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(
                        this,
                        $"Printed!\n\n" +
                        $"Retrieval Code: {code}\n" +
                        $"Uses: 0/3\n" +
                        $"Expires in 30 minutes",
                        "Print Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }));
            }
            catch (Exception ex)
            {
                printingInProgress = false;
                MessageBox.Show("Print failed: " + ex.Message);
            }
        }

        //DOC PAYMENT
        private async void printBtn_Click(object sender, EventArgs e)
        {
            if (printingInProgress) return;

            receiveTimer.Stop();

            printBtn.Enabled = false;

            printingStatusLabel.Text = "Printing in progress...";
            printingStatusLabel.Visible = true;

            printingInProgress = true;
            allowReset = false;

            try
            {
                _ = Task.Run(() =>
                {
                    try
                    {
                        documentPrinting.PrintDocumentFile(
                            currentPdfPath,
                            DOCUMENT_PRINTER,
                            totalPages,
                            radioSinglePage.Checked,
                            (int)numericSinglePage.Value,
                            radioPrintRange.Checked,
                            numericPageRange.Text,
                            radioColored.Checked,
                            pageIsColored
                        );
                    }
                    catch (Exception ex)
                    {
                        DebugLog("Print error: " + ex.Message);
                    }
                });

                // assume success
                printSuccess = true;
                sessionActive = true;


                // THIS IS THE KEY — WAIT AFTER PRINT
                await WaitForEstimatedPrintTime(
                    totalPages,
                    (int)numericCopies.Value,
                    radioColored.Checked
                );

                if (!printSuccess)
                {
                    printingStatusLabel.Text = "Printing failed.";
                    printingInProgress = false;
                    printBtn.Enabled = true;
                    return;
                }

                // GENERATE CODE
                string code = GenerateRetrievalCode();

                printingStatusLabel.Text = "Printing completed.";

                // MOVE FILE
                string archiveFolder = @"C:\PrintAndSnap\DOCS\archive";
                Directory.CreateDirectory(archiveFolder);

                string newPath = Path.Combine(
                    archiveFolder,
                    code + "_" + Path.GetFileName(currentPdfPath)
                );

                try
                {
                    if (pdfViewer != null)
                    {
                        try
                        {
                            if (pdfViewer.Document != null)
                                pdfViewer.Document.Dispose();

                            previewPanelSettingLayout.Controls.Remove(pdfViewer);
                            pdfViewer.Dispose();
                            pdfViewer = null;
                        }
                        catch { }
                    }

                    if (File.Exists(currentPdfPath))
                    {
                        File.Move(currentPdfPath, newPath);
                    }
                }
                catch (Exception ex)
                {
                    DebugLog("FILE MOVE ERROR: " + ex.Message);
                }

                MessageBox.Show(
                this,
                "Printing completed!\n\n" +
                "Your Retrieval Code: " + code,
                "Printing",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );

                allowReset = true;

                // AFTER USER CLICKS OK → THEN WAIT 10s
                await Task.Delay(10000);

                sessionActive = false;
                ForceResetMachine();
            }
            finally
            {
                printingInProgress = false;
                printBtn.Enabled = true;
            }
        }

        private void ForceResetMachine()
        {
            DebugLog("FORCED RESET");

            try
            {
                ResetDownloads();
                ResetPhoto();
                ResetDocument();
                ResetUI();
            }
            catch (Exception ex)
            {
                DebugLog("Force reset error: " + ex.Message);
            }
        }



        // =========================
        // DOWNLOAD / QR METHODS
        // =========================
        private void GenerateQrForDownload(string fileName)
        {
            try
            {
                string localIP = uploadService.GetLocalIPAdress();
                string url = $"http://{localIP}:3000/download?file={fileName}";

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrData);

                Bitmap qrImage = qrCode.GetGraphic(20);

                this.Invoke(new Action(() =>
                {
                    qrIdPrintingDownload.Image = qrImage;
                    qrIdPrintingDownload.SizeMode = PictureBoxSizeMode.Zoom;

                    qrIdPrintingDownload.Visible = true;
                    qrIdPrintingDownload.BringToFront();

                    IDpayment.Visible = true;
                    IDpayment.BringToFront();
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("QR Error: " + ex.Message);
            }
        }

        private void StartAutoCleanup(string filePath)
        {
            resetTokenSource?.Cancel();
            resetTokenSource = new CancellationTokenSource();
            var token = resetTokenSource.Token;

            _ = Task.Run(async () =>
            {
                try
                {
                    int timeout = 80;

                    for (int i = 0; i < timeout; i++)
                    {
                        if (token.IsCancellationRequested) return;

                        if (uploadService.uploadUsed)
                            break;

                        await Task.Delay(1000, token);
                    }

                    if (token.IsCancellationRequested) return;

                    try
                    {
                        if (File.Exists(filePath))
                        {
                            File.SetAttributes(filePath, FileAttributes.Normal);
                            File.Delete(filePath);
                        }
                    }
                    catch { }

                    await Task.Delay(2000, token);

                    if (token.IsCancellationRequested) return;

                    this.Invoke(new Action(() =>
                    {
                        printingInProgress = false;
                        allowReset = true;
                        ResetMachine(true);
                    }));
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            });
        }

        private void GenerateQrForFunDownload(string fileName)
        {
            try
            {
                string localIP = uploadService.GetLocalIPAdress();
                string url = $"http://{localIP}:3000/download?file={fileName}";

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrData);

                Bitmap qrImage = qrCode.GetGraphic(20);

                // SHOW IN FUN QR BOX
                this.Invoke(new Action(() =>
                {
                    qrSoftCopyDownloadFun.Image = qrImage;
                    qrSoftCopyDownloadFun.SizeMode = PictureBoxSizeMode.Zoom;

                    qrSoftCopyDownloadFun.Visible = true;
                    qrSoftCopyDownloadFun.BringToFront();

                    funSoftCopyDownloadPanel.Visible = true;
                    funSoftCopyDownloadPanel.BringToFront();
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("QR Error: " + ex.Message);
            }
        }

        private async void downloadBtnPaymentId_Click(object sender, EventArgs e)
        {
            try
            {
                downloadBtnPaymentId.Enabled = false;

                string fileToDownload = "";

                if (!string.IsNullOrEmpty(lastSavedIdFileName))
                {
                    fileToDownload = lastSavedIdFileName;
                }
                else if (!string.IsNullOrEmpty(currentRetrievedIdPath))
                {
                    fileToDownload = Path.GetFileName(currentRetrievedIdPath);
                }
                else
                {
                    MessageBox.Show("No file to download.");
                    downloadBtnPaymentId.Enabled = true;
                    return;
                }

                string fullPath = Path.Combine(@"C:\PrintAndSnap\ID\download", fileToDownload);

                if (!File.Exists(fullPath))
                {
                    MessageBox.Show("File not found.");
                    downloadBtnPaymentId.Enabled = true;
                    return;
                }

                // RESET SERVER
                uploadService.StopServer();
                await Task.Delay(500);

                uploadService.GenerateNewToken();

                uploadService.StartUploadServer();
                await Task.Delay(1200);

                GenerateQrForDownload(fileToDownload);

                ShowPhotoPanel(photoIDPanel, softCopyDownloadId);

                // =========================
                // AUTO DELETE AFTER DOWNLOAD
                // =========================
                _ = Task.Run(async () =>
                {
                    string path = Path.Combine(@"C:\PrintAndSnap\ID\download", fileToDownload);

                    int timeout = 60;
                    bool downloaded = false;

                    for (int i = 0; i < timeout; i++)
                    {
                        if (uploadService.uploadUsed)
                        {
                            downloaded = true;

                            try
                            {
                                if (File.Exists(path))
                                    File.Delete(path);
                            }
                            catch { }

                            uploadService.uploadUsed = false;

                            // delay before reset (better UX)
                            await Task.Delay(2000);

                            this.Invoke(new Action(() =>
                            {
                                printingInProgress = false;
                                allowReset = true;
                                ResetMachine(true);
                            }));

                            break;
                        }

                        await Task.Delay(1000);
                    }
                    // IF NOT DOWNLOADED → fallback reset
                    if (!downloaded)
                    {
                        try
                        {
                            if (File.Exists(path))
                                File.Delete(path);
                        }
                        catch { }

                        await Task.Delay(2000);

                        this.Invoke(new Action(() =>
                        {
                            printingInProgress = false;
                            allowReset = true;
                            ResetMachine(true);
                        }));
                    }
                });

                downloadBtnPaymentId.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Download error: " + ex.Message);
                downloadBtnPaymentId.Enabled = true;
            }
        }

        private async void funDownloadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // BLOCK IF NOT READY
                if (printingInProgress || string.IsNullOrEmpty(lastSavedFunFileName))
                {
                    MessageBox.Show("⚠Please print first before downloading.");
                    return;
                }


                funDownloadBtn.Enabled = false;

                string folder = @"C:\PrintAndSnap\FUN\download";
                string fullPath = Path.Combine(folder, lastSavedFunFileName);

                if (!File.Exists(fullPath))
                {
                    MessageBox.Show("File not found.");
                    funDownloadBtn.Enabled = true;
                    return;
                }

                // HARD RESET SERVER (same as ID)
                uploadService.StopServer();
                await Task.Delay(500);

                uploadService.GenerateNewToken();

                uploadService.StartUploadServer();
                await Task.Delay(1200);

                GenerateQrForFunDownload(lastSavedFunFileName);

                ShowPhotoPanel(photoBoothPanel, funSoftCopyDownloadPanel);

                // Re-enable after done
                funDownloadBtn.Enabled = true;

                // =========================
                // AUTO DELETE + RESET
                // =========================
                _ = Task.Run(async () =>
                {
                    string path = Path.Combine(@"C:\PrintAndSnap\FUN\download", lastSavedFunFileName);

                    int timeout = 60;
                    bool downloaded = false;

                    for (int i = 0; i < timeout; i++)
                    {
                        if (uploadService.uploadUsed)
                        {
                            downloaded = true;

                            try
                            {
                                if (File.Exists(path))
                                    File.Delete(path);
                            }
                            catch { }

                            uploadService.uploadUsed = false;

                            await Task.Delay(2000);

                            this.Invoke(new Action(() =>
                            {
                                printingInProgress = false;
                                allowReset = true;
                                ResetMachine(true);
                            }));

                            break;
                        }

                        await Task.Delay(1000);
                    }

                    // fallback delete
                    if (!downloaded)
                    {
                        try
                        {
                            if (File.Exists(path))
                                File.Delete(path);
                        }
                        catch { }

                        await Task.Delay(2000);

                        this.Invoke(new Action(() =>
                        {
                            printingInProgress = false;
                            allowReset = true;
                            ResetMachine(true);
                        }));
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Download error: " + ex.Message);
                funDownloadBtn.Enabled = true;
            }
        }

        private void StopDownloadSession()
        {
            try
            {
                uploadService.StopServer();

                Thread.Sleep(300);

                if (qrIdPrintingDownload.Image != null)
                {
                    qrIdPrintingDownload.Image.Dispose();
                    qrIdPrintingDownload.Image = null;
                }

                if (qrSoftCopyDownloadFun.Image != null)
                {
                    qrSoftCopyDownloadFun.Image.Dispose();
                    qrSoftCopyDownloadFun.Image = null;
                }
            }
            catch { }
        }

        // ======================
        // PHOTO CANCEL BUTTONS
        // ======================
        private void photoModeCancelBtn_Click(object sender, EventArgs e)
        {
            printingInProgress = false;
            allowReset = true;
            ResetMachine(true);
        }

        private void photoCancelRetrievalBtn_Click(object sender, EventArgs e)
        {
            printingInProgress = false;
            allowReset = true;
            ResetMachine(true);
        }

        private void funCancelBtn_Click(object sender, EventArgs e)
        {
            printingInProgress = false;
            allowReset = true;

            // Stop any active countdown
            captureTimer.Stop();
            countdown = 3;
            activeCaptureButton = null;

            // Reset FUN photo capture session
            ResetPhotoSession();

            // Reset FUN buttons
            funCaptureBtn.Enabled = true;
            funCaptureAgainBtn.Enabled = false;
            funContinueBtn.Enabled = false;

            // Reset FUN button appearance
            funCaptureBtn.Text = "";
            funCaptureAgainBtn.Text = "";

            funCaptureBtn.BackgroundImage =
                global::Snap_and_Print.Properties.Resources.camera_fill;

            // Finally reset the machine/panels
            ResetMachine(true);
        }

        private void funSettingsCancelBtn_Click(object sender, EventArgs e)
        {
            printingInProgress = false;
            allowReset = true;

            // Stop any active countdown
            captureTimer.Stop();
            countdown = 3;
            activeCaptureButton = null;

            // Reset FUN photo capture session
            ResetPhotoSession();

            // Reset FUN capture UI
            funCaptureBtn.Enabled = true;
            funCaptureAgainBtn.Enabled = false;
            funContinueBtn.Enabled = false;

            // Reset FUN button appearance
            funCaptureBtn.Text = "";
            funCaptureAgainBtn.Text = "";

            funCaptureBtn.BackgroundImage =
                global::Snap_and_Print.Properties.Resources.camera_fill;

            // Return to the starting UI
            ResetMachine(true);
        }

        private void paymentFunCancelBtn_Click(object sender, EventArgs e)
        {
            printingInProgress = false;
            allowReset = true;
            ResetMachine(true);
        }

        private void funSoftCopyCancelBtn_Click(object sender, EventArgs e)
        {
            StopDownloadSession();
            printingInProgress = false;
            allowReset = true;
            ResetMachine(true);
        }

        private void idPrintingCancelBtn_Click(object sender, EventArgs args)
        {
            printingInProgress = false;
            allowReset = true;
            ResetMachine(true);
        }
        private void idPrintSettingsCancelBtn_Click(object obj, EventArgs args)
        {
            printingInProgress = false;
            allowReset = true;
            ResetMachine(true);
        }

        private void cancelBtnPaymentId_Click(object obj, EventArgs args)
        {
            printingInProgress = false;
            allowReset = true;
            ResetMachine(true);
        }

        private void downloadCancelBtn_Click(object obj, EventArgs args)
        {
            StopDownloadSession();
            printingInProgress = false;
            allowReset = true;
            ResetMachine(true);
        }

        // ===================
        // PHOTO BACK BUTTONS
        // ===================
        private void downloadBackBtn_Click(object obj, EventArgs args)
        {
            StopDownloadSession();
            ShowPhotoPanel(photoIDPanel, IDpayment);
        }

        private void backBtnPaymentId_Click(object obj, EventArgs args)
        {
            ShowPhotoPanel(photoIDPanel, idPrintingSettings);
        }

        private void idPrintSettingsBackBtn_Click(object obj, EventArgs args)
        {
            ShowPhotoPanel(photoIDPanel, photoMode);
        }

        private void funSettingsBackBtn_Click(object obj, EventArgs args)
        {
            ShowPhotoPanel(photoBoothPanel, photoMode);
        }

        private void paymentFunBackBtn_Click(object obj, EventArgs args)
        {
            ShowPhotoPanel(photoBoothPanel, photoBoothSettings);
        }

        private void funSoftCopyBackBtn_Click(object obj, EventArgs args)
        {
            StopDownloadSession();
            ShowPhotoPanel(photoBoothPanel, funPaymentPanel);
        }

        // ========================
        // DOCUMENT  METHODS
        // ========================
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

                printingInProgress = false;
                allowReset = true;
                ResetMachine(true);
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

        private void ConvertWordToPdf(string docPath)
        {
            WaitForFileRelease(docPath);

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            string newPdfPath = Path.Combine(
                @"C:\PrintAndSnap\DOCS\preview",
                Path.GetFileNameWithoutExtension(docPath) + "_preview_" + timestamp + ".pdf"
            );

            Word.Application wordApp = null;
            Word.Document doc = null;

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(newPdfPath));

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

                if (doc == null)
                    throw new InvalidOperationException("Microsoft Word could not open the document.");

                doc.ExportAsFixedFormat(
                    newPdfPath,
                    Word.WdExportFormat.wdExportFormatPDF
                );

                if (!File.Exists(newPdfPath) || new FileInfo(newPdfPath).Length == 0)
                    throw new IOException("Microsoft Word did not create a PDF preview.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Word-to-PDF conversion failed: " + ex);

                Invoke(new Action(() =>
                {
                    uploadStatusTimer.Stop();
                    fileUploadStatusLabel.Text = "Word-to-PDF conversion failed.";
                    MessageBox.Show(
                        "The Word document could not be converted to PDF.\n\n" +
                        "Make sure Microsoft Word is installed and that the document can be opened.\n\n" +
                        ex.Message,
                        "Word Conversion Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }));

                return;
            }
            finally
            {
                if (doc != null)
                {
                    try
                    {
                        doc.Close(false);
                    }
                    catch (Exception cleanupException)
                    {
                        Debug.WriteLine("Unable to close Word document: " + cleanupException);
                    }
                    finally
                    {
                        Marshal.FinalReleaseComObject(doc);
                    }
                }

                if (wordApp != null)
                {
                    try
                    {
                        wordApp.Quit(Word.WdSaveOptions.wdDoNotSaveChanges);
                    }
                    catch (Exception cleanupException)
                    {
                        Debug.WriteLine("Unable to quit Microsoft Word: " + cleanupException);
                    }
                    finally
                    {
                        Marshal.FinalReleaseComObject(wordApp);
                    }
                }

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

            if (totalPages > MAX_ALLOWED_PAGES)
            {
                MessageBox.Show(
                    "This document has " + totalPages + " pages.\n" +
                    "Maximum allowed pages is " + MAX_ALLOWED_PAGES + ".",
                    "Document Too Large",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                printingInProgress = false;
                allowReset = true;
                ResetMachine(true);
                return;
            }

            numericSinglePage.Minimum = 1;
            numericSinglePage.Maximum = totalPages;
            numericSinglePage.Value = 1;
            uploadStatusTimer.Stop();

            if (!isRetrievalMode)
            {
                receiveTimer.Stop();
                showPanel(continuePanel);
            }

            DebugPanelState("LoadNewPreview");
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

        // DOC SETTINGS
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

            totalLabel.Text = total.ToString();
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

        // =========================
        // FILE WATCHER / UPLOAD
        // =========================
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

                        showPanel(continuePanel);
                    }));
                }
                else if (extension == ".docx" || ext == ".doc")
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

        // =====================
        // TIMERS METHODS
        // =====================
        private void ResetInactivityTimer()
        {
            if (inactivityTimer == null)
                return;

            inactivityTimer.Stop();
            inactivityTimer.Start();
        }


        private void CleanFolder(string folder, int minutes, string excludeFile = null)
        {
            if (!Directory.Exists(folder))
                return;

            foreach (var file in Directory.GetFiles(folder))
            {
                try
                {
                    if (excludeFile != null && file == excludeFile)
                        continue;

                    DateTime created = File.GetCreationTime(file);

                    if (DateTime.Now - created > TimeSpan.FromMinutes(minutes))
                    {
                        File.Delete(file);
                    }
                }
                catch { }
            }
        }

        private async Task WaitForEstimatedPrintTime(int totalPages, int copies, bool isColored)
        {
            int pagesToPrint = 0;

            if (radioPrintAll.Checked)
            {
                pagesToPrint = totalPages;
            }
            else if (radioSinglePage.Checked)
            {
                pagesToPrint = 1;
            }
            else if (radioPrintRange.Checked)
            {
                string input = numericPageRange.Text.Trim();

                if (!string.IsNullOrEmpty(input) && input.Contains("-"))
                {
                    string[] parts = input.Split('-');

                    if (parts.Length == 2 &&
                        int.TryParse(parts[0], out int start) &&
                        int.TryParse(parts[1], out int end))
                    {
                        // FIX: normalize values
                        if (start > end)
                        {
                            int temp = start;
                            start = end;
                            end = temp;
                        }

                        // LIMIT to valid pages
                        start = Math.Max(1, start);
                        end = Math.Min(totalPages, end);

                        pagesToPrint = end - start + 1;
                    }
                    else
                    {
                        pagesToPrint = 0;
                    }
                }
            }

            int totalWork = pagesToPrint * copies;

            // TIME SETTINGS
            int perPage = isColored ? 35000 : 25000; // 35s color, 25s B&W
            int baseTime = 3000; // small delay (3 sec)

            int finalTime = baseTime + (totalWork * perPage);

            // DEBUG (optional)
            DebugLog($"PagesToPrint: {pagesToPrint}");
            DebugLog($"TotalWork: {totalWork}");
            DebugLog($"FinalTime(ms): {finalTime}");

            // WAIT
            for (int i = finalTime / 1000; i > 0; i--)
            {
                printingStatusLabel.Text = $"Printing... {i}s";
                await Task.Delay(1000);
            }
        }


        // =========================
        // RESET SYSTEM
        // =========================
        private void ResetMachine(bool force = false)
        {
            if (!force)
            {
                if (printingInProgress) return;
                if (!allowReset) return;
            }

            DebugLog("RESET TRIGGERED");

            if (isResetting)
                return;

            isResetting = true;

            resetTokenSource?.Cancel();

            try
            {
                // =========================
                // STOP PHOTO UPLOAD SERVER
                // =========================
                StopPhotoUploadSession();
                // =========================
                // RESET PAYMENT FIRST
                // =========================
                paymentController.ResetPayment();

                // =========================
                // RESET EVERYTHING ELSE
                // =========================
                ResetDownloads();
                ResetPhoto();
                ResetDocument();
                ResetUI();
            }
            finally
            {
                isResetting = false;
            }
        }

        private void ResetDownloads()
        {
            string[] folders =
            {
                @"C:\PrintAndSnap\ID\download",
                @"C:\PrintAndSnap\FUN\download"
            };

            foreach (var folder in folders)
            {
                if (Directory.Exists(folder))
                {
                    foreach (var file in Directory.GetFiles(folder))
                    {
                        try
                        {
                            File.SetAttributes(file, FileAttributes.Normal);
                            File.Delete(file);
                        }
                        catch { }
                    }
                }
            }
        }

        private void ResetPhoto()
        {
            // =========================
            // STOP CAMERA / CAPTURE
            // =========================

            try
            {
                captureTimer?.Stop();
            }
            catch 
            {
                activeCaptureButton = null;
            }

            countdown = 3;

            try
            {
                cameraService.StopCamera();
            }
            catch { }


            // =========================
            // DISPOSE PHOTO PREVIEWS
            // =========================

            PictureBox[] photoBoxes =
            {
        funPreview1,
        funPreview2,
        funPreview3,
        funPreview4,

        funSelectPic1,
        funSelectPic2,
        funSelectPic3,
        funSelectPic4,

        idPreviewPictureBox1,
        idPreviewPictureBox2,
        idPreviewPictureBox3,
        idPreviewPictureBox4,

        idSettingsSelectPicture1,
        idSettingsSelectPicture2,
        idSettingsSelectPicture3,
        idSettingsSelectPicture4
    };

            foreach (var box in photoBoxes)
            {
                SafeDisposePictureBox(box);
            }


            // =========================
            // CAMERA FEEDS
            // =========================

            SafeDisposePictureBox(funCameraFeed);
            SafeDisposePictureBox(idCameraFeed);

            SafeDispose(ref currentFrame);
            SafeDispose(ref lastFrame);


            // =========================
            // PHOTO PREVIEWS
            // =========================

            SafeDisposePictureBox(funMiniPreview);
            SafeDisposePictureBox(funMainPreview);
            SafeDisposePictureBox(idSettingsPicturePreview);
            SafeDisposePictureBox(idPrintPreviewMini);

            SafeDisposePictureBox(qrIdPrintingDownload);
            SafeDisposePictureBox(qrSoftCopyDownloadFun);


            // =========================
            // FINAL PRINT IMAGES
            // =========================

            SafeDispose(ref finalIdPrintImage);
            SafeDispose(ref finalFunImage);
            SafeDispose(ref selectedPhoto);


            // =========================
            // CAPTURED PHOTOS
            // =========================

            foreach (var img in capturedPhotos)
            {
                try
                {
                    img?.Dispose();
                }
                catch { }
            }

            capturedPhotos.Clear();


            // =========================
            // FILTER CACHE
            // =========================

            foreach (var img in cachedFilteredPhotos)
            {
                try
                {
                    img?.Dispose();
                }
                catch { }
            }

            cachedFilteredPhotos.Clear();

            lastAppliedFilter = "";

            funFilter = "none";
            funLayout = "none";
            funFrame = "none";


            // =========================
            // ID STATE
            // =========================

            selectedLayout = "2x2";
            isColored = true;
            isMultiple = false;
            idBackgroundOption = "none";

            totalIdPrice = 0;
            lastIdCopiesValue = 1;

            hasUserSelectedPhoto = false;

            isPhotoRetrievalMode = false;
            currentRetrievedIdPath = null;
            lastSavedIdFileName = null;


            // =========================
            // FUN STATE
            // =========================

            totalFunPrice = 0;
            lastFunCopiesValue = 1;

            lastSavedFunFileName = null;
            currentFunRetrievalCode = null;


            // =========================
            // RESET PHOTO BUTTONS
            // =========================

            idPrintingContinueBtn.Enabled = false;
            funContinueBtn.Enabled = false;

            idCaptureBtn.Enabled = true;
            idCaptureAgainBtn.Enabled = false;

            funCaptureBtn.Enabled = true;
            funCaptureAgainBtn.Enabled = false;

            idCaptureBtn.Text = "";
            idCaptureAgainBtn.Text = "";

            funCaptureBtn.Text = "";
            funCaptureAgainBtn.Text = "";

            idCaptureBtn.BackgroundImage =
                global::Snap_and_Print.Properties.Resources.camera_fill;

            funCaptureBtn.BackgroundImage =
                global::Snap_and_Print.Properties.Resources.camera_fill;


            // =========================
            // RESET PHOTO RADIO BUTTONS
            // =========================

            radioBtn2x2.Checked = true;
            radioBtnSinglePhotoCopies.Checked = true;
            radioBtnPhotoColored.Checked = true;

            funRadioBtnFilterNone.Checked = true;
            funRadioBtnFrameNone.Checked = true;

            funRadioPrintTypeSingle.Checked = true;

            funRadioBtnVertical.Checked = false;
            funRadioBtnGridBtn.Checked = false;


            // =========================
            // MOST IMPORTANT PART
            // HIDE ALL PHOTO PANELS
            // =========================

            photoPanel.Visible = false;

            photoMode.Visible = false;
            photoIDPanel.Visible = false;
            retrievalPanelPhoto.Visible = false;
            photoBoothPanel.Visible = false;

            panelCRMidPrinting.Visible = false;
            idPrintingSettings.Visible = false;
            IDpayment.Visible = false;
            softCopyDownloadId.Visible = false;

            panelCMRphotoBooth.Visible = false;
            photoBoothSettings.Visible = false;
            funPaymentPanel.Visible = false;
            funSoftCopyDownloadPanel.Visible = false;

            PhotoRetrievePanel.Visible = false;


            // =========================
            // RESET MODE
            // =========================

            currentMode = PhotoMode.None;
            currentSystemMode = SystemMode.None;
        }

        private void ResetDocument()
        {
            uploadService.StopServer();

            uploadStatusTimer?.Stop();
            inactivityTimer?.Stop();
            receiveTimer?.Stop();

            ResetPdfViewer();
            previewPanelSettingLayout.Controls.Clear();

            uploadService.uploadUsed = false;
            processedFiles.Clear();

            currentPdfPath = null;
            currentEditablePath = null;
            currentOriginalPath = null;

            totalLabel.Text = "0";
            paymentDocBalance.Text = "0";
        }

        private void ResetUI()
        {
            // =========================
            // RESET PAYMENT DISPLAY
            // =========================

            totalDocInserted.Text = "0";
            paymentDocBalance.Text = "0";
            totalDocChange.Text = "0";

            paymentInsertedID.Text = "0";
            paymentIDBalance.Text = "0";
            paymentChangeID.Text = "0";

            paymentFunInserted.Text = "0";
            paymentFunBalance.Text = "0";
            paymentFunChange.Text = "0";

            paymentDocTotal.Text = "0";
            paymentIDTotal.Text = "0";
            paymentFunTotal.Text = "0";

            // =========================
            // RESET BUTTONS
            // =========================

            printBtn.Enabled = false;
            printBtnPaymentId.Enabled = false;
            paymentFunPrintBtn.Enabled = false;

            downloadBtnPaymentId.Enabled = false;
            funDownloadBtn.Enabled = false;

            // =========================
            // RESET PANELS
            // =========================

            continuePanel.Visible = false;
            printingSettingsPanel.Visible = false;

            photoPanel.Visible = false;
            photoPanel.SendToBack();

            showPanel(startPanel);
        }

        // =========================
        // BUTTON EVENTS
        // =========================
        public void startBtn_Click(object sender, EventArgs e)
        {

            showPanel(printingOptionsPanel);

            inactivityTimer.Start();
        }

        private void InitializeDocumentPrinting()
        {
            uploadService.GenerateNewToken();

            foreach (var file in Directory.GetFiles(watchFolder))
            {
                try { File.Delete(file); } catch { }
            }

            if (fileWatcher == null)
                StartWatchingFolder();

            fileWatcher.EnableRaisingEvents = false;
            fileWatcher.EnableRaisingEvents = true;

            qrPictureBox.Image = uploadService.GenerateQRCode();

            uploadService.StartUploadServer();

            qrExpireTimer.Start();
            inactivityTimer.Start();

            paymentPanel.Visible = true;
            paymentPanel.BringToFront();

            uploadPanel.Visible = true;
            uploadPanel.BringToFront();

        }

        private void docPrintingBtn_Click(object sender, EventArgs e)
        {
            currentSystemMode = SystemMode.Docs;

            showPanel(printingSettingsPanel);

            InitializeDocumentPrinting();

        }

        private void docPrintingBtn_MouseEnter(object sender, EventArgs e)
        {
            instructionLabel.Text = "Print PDF, Word, and Documents";
        }

        // =========================
        // Printing Options Button Events
        // =========================
        private void photoPrintingBtn_MouseEnter(object sender, EventArgs e)
        {
            instructionLabel.Text = "Print ID Photos and Fun Photos";
        }

        private void docPrintingBtn_MouseLeave(object sender, EventArgs e)
        {
            instructionLabel.Text = "Select a service to continue";
        }

        private void photoPrintingBtn_MouseLeave(object sender, EventArgs e)
        {
            instructionLabel.Text = "Select a service to continue";
        }

        // =========================
        // Printing Photo Options Button Events
        // =========================
        private void photoBtnID_MouseEnter(object sender, EventArgs e)
        {
            instructionLabelPhoto.Text = "Printing ID 2x2, 1x1 and Passport Size";
        }

        private void photoBtnID_MouseLeave(object sender, EventArgs e)
        {
            instructionLabelPhoto.Text = "Select a photo service to continue";
        }

        private void photoBtnFun_MouseEnter(object sender, EventArgs e)
        {
            instructionLabelPhoto.Text = "Printing Fun Photos, Filter and Backgrounds";
        }

        private void photoBtnFun_MouseLeave(object sender, EventArgs e)
        {
            instructionLabelPhoto.Text = "Select a photo service to continue";
        }

        private void photoBtnRetrieve_MouseEnter(object sender, EventArgs e)
        {
            instructionLabelPhoto.Text = "Retrieve your Photos with retrieval code given";
        }

        private void photoBtnRetrieve_MouseLeave(object sender, EventArgs e)
        {
            instructionLabelPhoto.Text = "Select a photo service to continue";
        }

        private void photoModeCancelBtn_MouseEnter(object sender, EventArgs e)
        {
            instructionLabelPhoto.Text = "Cancel back to start";
        }

        private void photoModeCancelBtn_MouseLeave(object sender, EventArgs e)
        {
            instructionLabelPhoto.Text = "Select a photo service to continue";
        }

        // =========================
        // Printing DOCS Options Button Events
        // =========================
        private void retrievalBtn_MouseEnter(object sender, EventArgs e)
        {
            instructionLabelDocs.Text = "Retrieve your Document with retrieval code given";
        }

        private void retrievalBtn_MouseLeave(object sender, EventArgs e)
        {
            instructionLabelDocs.Text = "Scan the QR Code to upload the file";
        }

        private void uploadCancelBtn_MouseEnter(object sender, EventArgs e)
        {
            instructionLabelDocs.Text = "Cancel back to start";
        }

        private void uploadCancelBtn_MouseLeave(object sender, EventArgs e)
        {
            instructionLabelDocs.Text = "Scan the QR Code to upload the file";
        }

        private void qrPictureBox_MouseEnter(object sender, EventArgs e)
        {
            instructionLabelDocs.Text = "Scan Me";
        }

        private void qrPictureBox_MouseLeave(object sender, EventArgs e)
        {
            instructionLabelDocs.Text = "Scan the QR Code to upload the file";
        }

        private void uploadCancelBtn_Click(object sender, EventArgs e)
        {
            printingInProgress = false;
            allowReset = true;
            ResetMachine(true);
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

        // ===============
        // PRINTING STATE
        // ===============
        private void PrintImage(Bitmap image)
        {
            PrintDocument pd = new PrintDocument();

            pd.PrintPage += (s, e) =>
            {
                e.Graphics.DrawImage(image, 0, 0, e.PageBounds.Width, e.PageBounds.Height);
            };

            pd.Print();
        }

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

        private void printSettingsCancelBtn_Click(object sender, EventArgs e)
        {
            printingInProgress = false;
            allowReset = true;
            ResetMachine(true);
        }

        // =========
        // HELPERS
        // =========
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

        // ===================
        // OTHERS / BUTTONS
        // ===================
        private void numericCopies_ValueChanged(Object sender, EventArgs e)
        {
            CalculateTotal();
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

        private void paymentBackBtn_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show(
                    this,
                    "⚠️ Printer is not ready.\n\n" +
                    "Please check the printer connection, paper, or printer status.",
                    "Printer Not Ready",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int total = int.Parse(totalLabel.Text);

            paymentDocTotal.Text = total.ToString();

            paymentController.StartPayment(total);

            printBtn.Enabled = false;

            settingsPanel.Hide();
            paymentPanel.Show();
            paymentPanel.BringToFront();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            printingInProgress = false;
            allowReset = true;
            ResetMachine(true);
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
            printingInProgress = false;
            allowReset = true;
            ResetMachine(true);
        }

        private void retrieveBtn_click(object sender, EventArgs e)
        {
            retrivalCodeTextBox.Text = "";
            showPanel(retrivalPanel);
        }

        private void photoUpload_click(object sender, EventArgs e)
        {
            // =========================
            // START A COMPLETELY NEW
            // PHOTO UPLOAD SESSION
            // =========================

            uploadedPhotoPath = "";

            // Make sure previous upload server is completely stopped
            StopPhotoUploadSession();

            // Small delay so Windows releases port 3001
            Thread.Sleep(300);

            // Generate a fresh token
            photoUploadServices.GenerateNewToken();

            // Start a fresh upload server
            photoUploadServices.StartUploadServer();

            // Generate fresh QR
            photoUploadQr.SizeMode = PictureBoxSizeMode.Zoom;

            if (photoUploadQr.Image != null)
            {
                photoUploadQr.Image.Dispose();
                photoUploadQr.Image = null;
            }

            photoUploadQr.Image =
                photoUploadServices.GenerateQRCode(
                    photoUploadQr.Width,
                    photoUploadQr.Height
                );

            // Reset status
            uploadStatusLabel.Text = "Waiting for photo...";

            StartUploadStatusAnimation();

            uploadPhotoChoose.Visible = false;

            photoUploadPanel.Visible = true;
            photoUploadPanel.BringToFront();

            // ALWAYS START AT UPLOAD PANEL
            showPanel(photoUploadPanel);
        }

        private void StartUploadStatusAnimation()
        {
            uploadDotCount = 0;

            if (uploadStatusTimer != null)
            {
                uploadStatusTimer.Stop();
                uploadStatusTimer.Dispose();
            }

            uploadStatusTimer = new System.Windows.Forms.Timer();
            uploadStatusTimer.Interval = 500;

            uploadStatusTimer.Tick += (s, e) =>
            {
                uploadDotCount++;

                if (uploadDotCount > 3)
                    uploadDotCount = 1;

                uploadStatusLabel.Text =
                    "Waiting for photo" +
                    new string('.', uploadDotCount);
            };

            uploadStatusTimer.Start();
        }

        private void StopUploadStatusAnimation()
        {
            if (uploadStatusTimer != null)
            {
                uploadStatusTimer.Stop();
                uploadStatusTimer.Dispose();
                uploadStatusTimer = null;
            }
        }

        private void PhotoUploadServices_PhotoUploaded(string filePath)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() =>
                {
                    PhotoUploadReceived(filePath);
                }));

                return;
            }

            PhotoUploadReceived(filePath);
        }

        private async void PhotoUploadReceived(string filePath)
        {
            uploadedPhotoPath = filePath;

            // Stop the animated dots
            StopUploadStatusAnimation();

            // Show received message
            uploadStatusLabel.Text = "Picture received! ✓";

            // Give the customer time to see it
            await Task.Delay(1500);

            // Now move to Choose ID / FUN
            ShowPhotoPanel(uploadPhotoChoose);
        }

        private async Task PhotoReceivedSequence()
        {
            uploadStatusLabel.Text = "Picture received!";

            await Task.Delay(1500);

            ShowPhotoPanel(uploadPhotoChoose);
        }

        private void uploadPhotoCancelBtn_click(object sender, EventArgs e)
        {
            printingInProgress = false;
            allowReset = true;

            uploadedPhotoPath = "";

            ResetMachine(true);
        }

        private void uploadPhotoBackBtn_click(object sender, EventArgs e)
        {
            // STOP PHOTO UPLOAD SESSION
            StopPhotoUploadSession();

            // Go back to Photo Mode
            ShowPhotoPanel(photoMode);
        }

        private void photoUploadIDBtn_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uploadedPhotoPath) || !File.Exists(uploadedPhotoPath))
            {
                MessageBox.Show(
                    this,
                    "No uploaded photo found.",
                    "Upload Photo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                // Make sure we are in ID mode
                currentMode = PhotoMode.ID;
                currentSystemMode = SystemMode.Photo;

                // Stop upload session
                StopPhotoUploadSession();

                // Reset previous photo state
                ResetPhotoSession();

                // =========================
                // LOAD UPLOADED PHOTO
                // =========================
                using (Bitmap temp = new Bitmap(uploadedPhotoPath))
                {
                    capturedPhotos.Add(new Bitmap(temp));
                }

                if (capturedPhotos.Count == 0)
                {
                    MessageBox.Show("Failed to load uploaded photo.");
                    return;
                }

                // =========================
                // SELECT UPLOADED PHOTO
                // =========================
                selectedPhoto = (Bitmap)capturedPhotos[0].Clone();
                hasUserSelectedPhoto = true;

                // =========================
                // LOAD INTO ID SETTINGS
                // ========================
                UpdateIdSettings();

                // =========================
                // GO DIRECTLY TO ID SETTINGS
                // =========================
                ShowPhotoPanel(
                    photoIDPanel,
                    idPrintingSettings
                );
            }
            catch (Exception ex)
            {
                DebugLog("Uploaded ID photo error: " + ex.Message);

                MessageBox.Show(
                    this,
                    "Unable to load uploaded photo.\n\n" + ex.Message,
                    "Upload Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void photoUploadFunBtn_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uploadedPhotoPath) || !File.Exists(uploadedPhotoPath))
            {
                MessageBox.Show(
                    this,
                    "No uploaded photo found.",
                    "Upload Photo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                // Make sure we are in FUN mode
                currentMode = PhotoMode.Fun;
                currentSystemMode = SystemMode.Photo;

                // Stop upload session
                StopPhotoUploadSession();

                // Reset previous photo state
                ResetPhotoSession();

                // =========================
                // LOAD UPLOADED PHOTO
                // =========================
                using (Bitmap temp = new Bitmap(uploadedPhotoPath))
                {
                    capturedPhotos.Add(new Bitmap(temp));
                }

                if (capturedPhotos.Count == 0)
                {
                    MessageBox.Show("Failed to load uploaded photo.");
                    return;
                }

                // =========================
                // SELECT UPLOADED PHOTO
                // =========================
                selectedPhoto = (Bitmap)capturedPhotos[0].Clone();
                hasUserSelectedPhoto = true;

                // =========================
                // FUN DEFAULT SETTINGS
                // =========================
                funFilter = "none";
                funLayout = "none";
                funFrame = "none";

                funRadioBtnFilterNone.Checked = true;
                funRadioBtnFrameNone.Checked = true;

                funRadioPrintTypeSingle.Checked = true;

                // =========================
                // LOAD INTO FUN SETTINGS
                // =========================
                ShowFunCapturedPhotos();
                LoadFunSelectionPhotos();

                UpdatePrintTypeAvailability();
                UpdateFunSettings();
                CalculateFunPrice();

                // =========================
                // GO DIRECTLY TO FUN SETTINGS
                // =========================
                ShowPhotoPanel(
                    photoBoothPanel,
                    photoBoothSettings
                );
            }
            catch (Exception ex)
            {
                DebugLog("Uploaded FUN photo error: " + ex.Message);

                MessageBox.Show(
                    this,
                    "Unable to load uploaded photo.\n\n" + ex.Message,
                    "Upload Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void StopPhotoUploadSession()
        {
            try
            {
                if (photoUploadServices != null)
                {
                    photoUploadServices.StopServer();
                }

                if (photoUploadQr != null && photoUploadQr.Image != null)
                {
                    photoUploadQr.Image.Dispose();
                    photoUploadQr.Image = null;
                }

                DebugLog("Photo Upload server stopped.");
            }
            catch (Exception ex)
            {
                DebugLog("Photo Upload cleanup error: " + ex.Message);
            }
        }

        private void photoUploadIDBtn_MouseEnter(object sender, EventArgs e)
        {
            uploadChooseLabel.Text = "Print photo in ID formats such as 2x2, 2x1, or 1x1."; ;
        }

        private void photoUploadIDBtn_MouseLeave(object sender, EventArgs e)
        {
            uploadChooseLabel.Text = "Please Select a printing options";
        }

        private void photoUploadFunBtn_MouseEnter(object sender, EventArgs e)
        {
            uploadChooseLabel.Text = "Print to add filters, colors and themes.";
        }

        private void photoUploadFunBtn_MouseLeave(object sender, EventArgs e)
        {
            uploadChooseLabel.Text = "Please Select a printing options";
        }

        private void photoUploadQr_MouseEnter(object sender, EventArgs e)
        {
            uploadNotifLabel.Text = "Scan me"; ;
        }

        private void photoUploadQr_MouseLeave(object sender, EventArgs e)
        {
            uploadNotifLabel.Text = "Open Qr code Scanner to Scan";
        }

        private void uploadPhotoCancelBtn_MouseEnter(object sender, EventArgs e)
        {
            uploadNotifLabel.Text = "Reset back to start";
        }

        private void uploadPhotoCancelBtn_MouseLeave(object sender, EventArgs e)
        {
            uploadNotifLabel.Text = "Open Qr code Scanner to Scan";
        }

        private void uploadPhotoBackBtn_MouseEnter(object sender, EventArgs e)
        {
            uploadNotifLabel.Text = "Back to Photo Modes";
        }

        private void uploadPhotoBackBtn_MouseLeave(object sender, EventArgs e)
        {
            uploadNotifLabel.Text = "Open Qr code Scanner to Scan";
        }

        private void idCameraFeed_Paint(object sender, PaintEventArgs e)
        {
            PictureBox camera = sender as PictureBox;

            if (camera == null)
                return;

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            int width = camera.ClientSize.Width;
            int height = camera.ClientSize.Height;

            // ==========================================
            // FACE GUIDE
            // LARGE AND MORE VISIBLE
            // ==========================================

            int headWidth = (int)(width * 0.36);
            int headHeight = (int)(height * 0.55);

            int headX = (width - headWidth) / 2;
            int headY = (int)(height * 0.08);

            Rectangle headGuide = new Rectangle(
                headX,
                headY,
                headWidth,
                headHeight
            );

            // ==========================================
            // SHOULDER GUIDE
            // SMALLER - ONLY A LITTLE INSIDE
            // ==========================================

            int shoulderWidth = (int)(width * 0.55);
            int shoulderHeight = (int)(height * 0.30);

            int shoulderX = (width - shoulderWidth) / 2;
            int shoulderY = (int)(height * 0.65);

            Rectangle suitGuide = new Rectangle(
                shoulderX,
                shoulderY,
                shoulderWidth,
                shoulderHeight
            );

            // ==========================================
            // DRAW GUIDE
            // ==========================================

            using (Pen guidePen = new Pen(Color.Lime, 3))
            {
                guidePen.DashStyle = DashStyle.Dash;

                // FACE
                g.DrawEllipse(
                    guidePen,
                    headGuide
                );

                // SHOULDERS
                g.DrawRectangle(
                    guidePen,
                    suitGuide
                );
            }

            // ==========================================
            // CENTER LINE
            // ==========================================

            using (Pen centerPen = new Pen(Color.White, 1))
            {
                centerPen.DashStyle = DashStyle.Dot;

                int centerX = width / 2;

                g.DrawLine(
                    centerPen,
                    centerX,
                    0,
                    centerX,
                    height
                );
            }

            // ==========================================
            // INSTRUCTION
            // ==========================================

            using (Font font = new Font(
                "Arial",
                14,
                FontStyle.Bold))
            using (Brush brush = new SolidBrush(
                Color.White))
            {
                string text =
                    "Align your face inside the guide";

                SizeF textSize =
                    g.MeasureString(text, font);

                float textX =
                    (width - textSize.Width) / 2;

                float textY = 10;

                // Shadow
                using (Brush shadow =
                    new SolidBrush(Color.Black))
                {
                    g.DrawString(
                        text,
                        font,
                        shadow,
                        textX + 2,
                        textY + 2
                    );
                }

                g.DrawString(
                    text,
                    font,
                    brush,
                    textX,
                    textY
                );
            }
        }

        // DEBUG
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

    }
}