using AForge.Video.DirectShow;
using Microsoft.Office.Core;
using PdfiumViewer;
using PrintAndSnap.Services;
using PrintAndSnap.Services.PhotoPrinting;
using PrintAndSnap.Services.Printing;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
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
        private string watchFolder = @"C:\PrintAndSnap\DOCS\uploads";
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
        private bool printerErrorShown = false;
        private bool sessionActive = false;

        //UI STATE
        private int dotCount = 0;
        private string baseStatusText = "";

        //SYSTEM HOOK
        private IntPtr hookID = IntPtr.Zero;

        //PHOTO BOOTH
        private CameraService cameraService = new CameraService();
        private PhotoService photoService = new PhotoService();
        private FilterServices filterService = new FilterServices();
        private PhotoLayoutServices layoutService = new PhotoLayoutServices();
        private FrameServices frameService = new FrameServices();

        private Bitmap currentFrame;
        private Bitmap lastFrame;

        private  List<Bitmap> capturedPhotos = new List<Bitmap>();

        private System.Windows.Forms.Timer captureTimer;
        private int countdown = 3;

        private string lastSavedIdFileName;

        private string currentRetrievedIdPath;

        private Bitmap finalFunImage;

        private string lastSavedFunFileName;

        //Global Lock
        private bool isProcessing = false;

        private CancellationTokenSource resetTokenSource;

        // ID SETTINGS STATE
        private string selectedLayout = "2x2";
        private bool isColored = true;
        private bool isMultiple = false;

        private Bitmap finalIdPrintImage;
        private Bitmap selectedPhoto;

        // FUN SETTINGS STATE
        private string funFilter = "none";
        private string funLayout = "none";
        private string funFrame = "none";
        private int totalFunPrice = 0;



        private string currentFunRetrievalCode = null;

        //private int pricePerSheet = 20; // adjust if needed
        private int totalIdPrice = 0;

        private bool hasUserSelectedPhoto = false;

        private bool isPhotoRetrievalMode = false;

        private int retrievalAttempts = 0;
        private const int MAX_RETRIEVAL_ATTEMPTS = 3;

        private int lastIdCopiesValue = 1;

        private int lastFunCopiesValue = 1;

        private List<Bitmap> cachedFilteredPhotos = new List<Bitmap>();
        private string lastAppliedFilter = "";

        private string lastPrinterError = "";

        enum PhotoMode
        {
            None,
            ID,
            Fun
        }

        private PhotoMode currentMode = PhotoMode.None;

        enum SystemMode
        {
            None,
            Docs,
            Photo
        }

        private SystemMode currentSystemMode = SystemMode.None;

        public PrintAndSnap()
        {
            InitializeComponent();

            //PHOTO BOOTH
            InitCamera();
            captureTimer = new System.Windows.Forms.Timer();
            captureTimer.Interval = 1000;
            captureTimer.Tick += CaptureTimer_Tick;
            idPrintingContinueBtn.Enabled = false;

            numericIdPrintingCopies.Minimum = 1;
            numericIdPrintingCopies.Value = 1;
            numericIdPrintingCopies.Maximum = 5;

            numericIdPrintingCopies.ValueChanged += (s, e) =>
            {
                int current = (int)numericIdPrintingCopies.Value;

                // 🔥 detect "trying to go above 5"
                if (current == 5 && lastIdCopiesValue == 5)
                {
                    MessageBox.Show("Maximum 5 copies only.");
                }

                lastIdCopiesValue = current;

                CalculateIdPrice();
            };

            numericIdPrintingCopies.Enabled = false;

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

            //DEFAULT RADIO BUTTONS
            radioBtn2x2.Checked = true;
            radioBtnSinglePhotoCopies.Checked = true;
            radioBtnPhotoColored.Checked = true;

            //DEFAULT STATES (IMPORTANT)
            selectedLayout = "2x2";
            isMultiple = false;
            isColored = true;

            //DEFAULT COPIES
            numericIdPrintingCopies.Minimum = 1;
            numericIdPrintingCopies.Value = 1;
            numericIdPrintingCopies.Maximum = 5;

            //UPDATE UI
            CalculateIdPrice();

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

            Application.ThreadException += (s, e) =>
            {
                MessageBox.Show("Unexpected error: " + e.Exception.Message);
            };

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                MessageBox.Show("Fatal error occurred.");
            };


        }

        //PHOTO BOOTH
        private DateTime lastFrameTime = DateTime.MinValue;

        private void ResetPhotoSession()
        {
            // 🧹 clear photos
            foreach (var img in capturedPhotos)
                img.Dispose();

            capturedPhotos.Clear();

            // 🖼 reset preview boxes
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
            }

            // 🔘 reset buttons
            funContinueBtn.Enabled = false;
            idPrintingContinueBtn.Enabled = false;

            // 📸 reset selection
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

                    // 🔥 CLONE FRAME (IMPORTANT - avoid threading issues)
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
        }

        private void photoPrintingBtn_Click(Object sender, EventArgs e)
        {
            currentSystemMode = SystemMode.Photo;
            photoPanel.Visible = true;
            photoPanel.BringToFront();

            ShowPhotoPanel(photoMode);
        }

        //ID PHOTO PRINTING

        private async void idPrintingContinueBtn_Click(object sender, EventArgs args)
        {
            if (isProcessing) return;
            isProcessing = true;

            idPrintingContinueBtn.Enabled = false;

            try
            {
                if (capturedPhotos.Count == 0)
                {
                    MessageBox.Show("Please capture at least one photo.");
                    return;
                }

                // 🛑 STOP CAMERA
                await Task.Run(() => cameraService.StopCamera());
                await Task.Delay(200);

                // =========================
                // 📁 SAVE TEMP (like FUN)
                // =========================
                string tempFolder = @"C:\PrintAndSnap\ID\temp";
                Directory.CreateDirectory(tempFolder);

                foreach (var file in Directory.GetFiles(tempFolder))
                {
                    try { File.Delete(file); } catch { }
                }

                for (int i = 0; i < capturedPhotos.Count; i++)
                {
                    string path = Path.Combine(tempFolder, $"temp_{i + 1}.png");
                    capturedPhotos[i].Save(path, ImageFormat.Png);
                }

                // =========================
                // 📸 SHOW PHOTOS IN SETTINGS
                // =========================
                ShowCapturedPhotos();          // preview boxes
                LoadIdSelectionPhotos();       // selection UI
                UpdateIdSettings();            // generate preview

                // =========================
                // 🔄 GO TO SETTINGS PANEL
                // =========================
                ShowPhotoPanel(photoIDPanel, idPrintingSettings);
            }
            finally
            {
                isProcessing = false;
            }
        }

        private void LoadIdSelectionPhotos()
        {
            hasUserSelectedPhoto = false;

            PictureBox[] boxes =
            {
        idSettingsSelectPicture1,
        idSettingsSelectPicture2,
        idSettingsSelectPicture3,
        idSettingsSelectPicture4
    };

            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Click -= SelectPhoto_Click;

                if (i < capturedPhotos.Count)
                {
                    if (boxes[i].Image != null)
                        boxes[i].Image.Dispose();

                    boxes[i].Image = (Bitmap)capturedPhotos[i].Clone();
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Visible = true;

                    boxes[i].Click += SelectPhoto_Click;
                }
                else
                {
                    boxes[i].Visible = false;
                }
            }

            // AUTO SELECT FIRST PHOTO
            if (capturedPhotos.Count > 0)
            {
                selectedPhoto = (Bitmap)capturedPhotos[0].Clone();
                hasUserSelectedPhoto = true;

                HighlightSelectedPhoto(boxes[0]); // 🔥 highlight first

                UpdateIdSettings();
            }
        }

        private void SelectPhoto_Click(object sender, EventArgs e)
        {
            PictureBox clicked = sender as PictureBox;

            if (clicked?.Image == null)
                return;

            hasUserSelectedPhoto = true;

            // IMPORTANT: clone to avoid memory issues
            selectedPhoto = (Bitmap)clicked.Image.Clone();

            HighlightSelectedPhoto(clicked);

            UpdateIdSettings();
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
                if (i < capturedPhotos.Count)
                {
                    boxes[i].Image = (Bitmap)capturedPhotos[i].Clone();
                    boxes[i].Visible = true;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
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

            // 🔥 PREVENT SPAM CLICK
            if (captureTimer.Enabled)
                return;

            if (capturedPhotos.Count >= 4)
            {
                MessageBox.Show("Maximum of 4 photos only.");
                return;
            }

            idCaptureBtn.Enabled = false;

            countdown = 3;
            captureTimer.Start();
        }

        private async void CaptureTimer_Tick(object sender, EventArgs e)
        {
            if (countdown > 0)
            {
                if (currentMode == PhotoMode.Fun)
                {
                    funCameraTimer.Text = countdown.ToString();
                    funCameraTimer.Visible = true;
                }
                else if (currentMode == PhotoMode.ID)
                {
                    CameraTimer.Text = countdown.ToString();
                    CameraTimer.Visible = true;
                }

                countdown--;
            }
            else
            {
                captureTimer.Stop();

                // =========================
                // SHOW FLASH ICON
                // =========================
                if (currentMode == PhotoMode.Fun)
                {
                    funCameraTimer.Text = "📸";
                    await Task.Delay(500);
                    funCameraTimer.Visible = false;
                }
                else if (currentMode == PhotoMode.ID)
                {
                    CameraTimer.Text = "📸";
                    await Task.Delay(500);
                    CameraTimer.Visible = false;
                }

                // =========================
                // SAFETY: PREVENT OVERFLOW
                // =========================
                if (capturedPhotos.Count >= 4)
                    return;

                // =========================
                // SAFE FRAME CAPTURE
                // =========================
                Bitmap shot = null;
                Bitmap tempFrame = currentFrame;

                if (tempFrame != null)
                {
                    try
                    {
                        shot = new Bitmap(tempFrame);
                    }
                    catch
                    {
                        return;
                    }
                }

                if (shot == null || shot.Width == 0 || shot.Height == 0)
                    return;

                // =========================
                // STORE SAFE COPY
                // =========================
                capturedPhotos.Add((Bitmap)shot.Clone());

                // =========================
                // SELECT MODE PREVIEW BOXES
                // =========================
                PictureBox[] boxes;

                if (currentMode == PhotoMode.Fun)
                {
                    boxes = new PictureBox[]
                    {
                funPreview1,
                funPreview2,
                funPreview3,
                funPreview4
                    };
                }
                else // ID
                {
                    boxes = new PictureBox[]
                    {
                idPreviewPictureBox1,
                idPreviewPictureBox2,
                idPreviewPictureBox3,
                idPreviewPictureBox4
                    };
                }

                int index = capturedPhotos.Count - 1;

                // =========================
                // INDEX SAFETY
                // =========================
                if (index < 0 || index >= boxes.Length)
                    return;

                if (boxes[index] == null)
                    return;

                // =========================
                // DISPOSE OLD IMAGE
                // =========================
                if (boxes[index].Image != null)
                    boxes[index].Image.Dispose();

                // =========================
                // SET IMAGE
                // =========================
                boxes[index].Image = (Bitmap)shot.Clone();
                boxes[index].SizeMode = PictureBoxSizeMode.StretchImage;
                boxes[index].Visible = true;

                // =========================
                // ENABLE BUTTONS
                // =========================
                if (currentMode == PhotoMode.Fun)
                {
                    funContinueBtn.Enabled = true;
                    funCaptureBtn.Enabled = true;
                }
                else if (currentMode == PhotoMode.ID)
                {
                    idPrintingContinueBtn.Enabled = true;
                    idCaptureBtn.Enabled = true;
                }

                // =========================
                // CLEANUP
                // =========================
                shot.Dispose();
            }
        }

        private (int uses, int maxUses, DateTime created, string metaPath) ReadMeta(string codeFolder)
        {
            string metaPath = Path.Combine(codeFolder, "meta.txt");

            if (!File.Exists(metaPath))
            {
                // 🔥 AUTO FIX (no exception)
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
        //ID SETTINGS
        private void UpdateIdSettings()
        {
            if (selectedPhoto == null)
                return;

            Bitmap layout = GenerateSingleLayout(selectedPhoto);

            if (idSettingsPicturePreview.Image != null)
                idSettingsPicturePreview.Image.Dispose();

            idSettingsPicturePreview.Image = layout;

            idSettingsPicturePreview.SizeMode = PictureBoxSizeMode.Zoom;

            UpdateMiniPreview();
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

            // 🔥 NOW UPDATE META (ONLY IF SUCCESS)
            uses++;
            created = DateTime.Now;
            WriteMeta(metaPath, created, uses, maxUses);

            // 🔥 SHOW INFO MESSAGE
            MessageBox.Show(
                this,
                $"✅ Photos loaded!\n\n" +
                $"Usage: {uses}/{maxUses}\n" +
                $"⏱ Expires in 30 minutes after last use",
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
            LoadIdSelectionPhotos();
            UpdateIdSettings();

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
                ResetMachine();
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
                DebugLog("SelectedPhoto NULL? " + (selectedPhoto == null));
                DebugLog("hasUserSelectedPhoto: " + hasUserSelectedPhoto);

                // =========================
                // ✅ VALIDATION FIRST
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
                    MessageBox.Show("⚠️ Please select a photo first.");
                    return;
                }

                // =========================
                // 🔥 GENERATE LAYOUT (ONLY ONCE)
                // =========================
                DebugLog("Generating layout...");

                finalIdPrintImage = layoutService.GenerateIdLayout(
                    selectedPhoto,
                    selectedLayout,
                    isColored,
                    isMultiple
                );

                if (finalIdPrintImage == null)
                {
                    DebugLog("ERROR: finalIdPrintImage is null");
                    MessageBox.Show("Failed to generate image.");
                    return;
                }

                DebugLog("Layout generated successfully");

                // =========================
                // 💾 SAVE TEMP
                // =========================
                string saveFolder = @"C:\PrintAndSnap\ID\temp";
                Directory.CreateDirectory(saveFolder);

                lastSavedIdFileName = "ID_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
                string filePath = Path.Combine(saveFolder, lastSavedIdFileName);

                DebugLog("Saving file: " + filePath);

                finalIdPrintImage.Save(filePath, ImageFormat.Png);

                DebugLog("File saved successfully");

                // =========================
                // 💰 PRICE (SAFE PARSE 🔥)
                // =========================
                string priceText = idPrintingTotal.Text.Replace("₱", "").Trim();

                if (!int.TryParse(priceText, out totalIdPrice))
                {
                    MessageBox.Show("Invalid price.");
                    return;
                }

                paymentIDprintingTotal.Text = "₱" + totalIdPrice;
                paymentIDprintingBalance.Text = "₱" + totalIdPrice;

                insertedMoney = 0;
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

        private void CalculateIdPrice()
        {
            int copies = (int)numericIdPrintingCopies.Value;

            int pricePerUnit = 0;

            if (!isMultiple) //SINGLE
            {
                if (isColored)
                    pricePerUnit = 50;
                else
                    pricePerUnit = 40;
            }
            else //MULTIPLE (FULL SHEET)
            {
                if (isColored)
                    pricePerUnit = 60;
                else
                    pricePerUnit = 50;
            }

            int total = pricePerUnit * copies;

            idPrintingTotal.Text = "₱" + total.ToString();
        }

        private Bitmap ConvertToGrayscale(Bitmap original)
        {
            Bitmap gray= new Bitmap(original.Width, original.Height);

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


        private void paymentFunPrintBtn_Click(object sender, EventArgs e)
        {
            PrintFunPhoto();
        }

        private void printBtnPaymentId_Click(object sender, EventArgs e)
        {
            PrintIdPhoto();
        }

        private async void PrintIdPhoto()
        {

            // 🔥 BLOCK IF NOT FULLY PAID
            if (insertedMoney < totalIdPrice)
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
                // 🔒 disable download until done
                downloadBtnPaymentId.Enabled = false;

                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = "Canon MG3000 series";

                pd.OriginAtMargins = false;
                pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

                pd.PrintPage += (sender, e) =>
                {
                    Graphics g = e.Graphics;
                    g.PageUnit = GraphicsUnit.Inch;

                    float widthInch = 2f;
                    float heightInch = 2f;

                    if (!isMultiple)
                    {
                        if (selectedLayout == "1x1")
                        {
                            widthInch = 1f;
                            heightInch = 1f;
                        }
                        else if (selectedLayout == "2x2")
                        {
                            widthInch = 4f;
                            heightInch = 4f;
                        }
                        else if (selectedLayout == "2x1")
                        {
                            widthInch = 2f;
                            heightInch = 2f;
                        }
                    }
                    else
                    {
                        widthInch = 8.27f;
                        heightInch = 11.69f;
                    }

                    g.DrawImage(finalIdPrintImage, 0f, 0f, widthInch, heightInch);
                };

                // 🟡 STATUS
                idprintingStatusLabel.Text = "Printing...";
                idprintingStatusLabel.Visible = true;

                pd.Print();

                // 🔥 SAFE WAIT
                await Task.Delay(5000);

                try
                {
                    await WaitForPrinterReady("Canon MG3000 series");
                }
                catch
                {
                    Debug.WriteLine("Printer fallback used.");
                }

                idprintingStatusLabel.Text = "Done!";

                // =========================
                // 🧹 CLEAN TEMP
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
                // 💾 SAVE FILE
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
                // 📱 SHOW QR FIRST (IMPORTANT FIX)
                // =========================
                GenerateQrForDownload(downloadFileName);

                uploadService.uploadUsed = false;

                // ✅ ENABLE BUTTON FIRST
                this.Invoke(new Action(() =>
                {
                    downloadBtnPaymentId.Enabled = true;
                }));

                printingInProgress = false;

                isPhotoRetrievalMode = false;
                currentRetrievedIdPath = null;

                // =========================
                // 🔔 SHOW MESSAGE AFTER UI READY (FIXED)
                // =========================
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(
                        this,
                        $"✅ Printed!\n\n" +
                        $"Retrieval Code: {code}\n" +
                        $"Uses: 0/3\n" +
                        $"⏱ Expires in 30 minutes",
                        "Print Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }));

                // =========================
                // 🔐 AUTO DELETE + RESET
                // =========================

                // 🔥 cancel previous task first
                resetTokenSource?.Cancel();
                resetTokenSource = new CancellationTokenSource();

                var token = resetTokenSource.Token;

                _ = Task.Run(async () =>
                {
                    try
                    {
                        string path = Path.Combine(@"C:\PrintAndSnap\ID\download", downloadFileName);

                        //cahnge the time for prod
                        int timeout = 60;

                        for (int i = 0; i < timeout; i++)
                        {
                            if (token.IsCancellationRequested) return;

                            if (uploadService.uploadUsed)
                                break;

                            try
                            {
                                await Task.Delay(1000, token);
                            }
                            catch (TaskCanceledException)
                            {
                                return; // stop quietly
                            }
                        }

                        if (token.IsCancellationRequested) return;

                        // DELETE
                        try
                        {
                            if (File.Exists(path))
                            {
                                File.SetAttributes(path, FileAttributes.Normal);
                                File.Delete(path);
                            }
                        }
                        catch { }

                        await Task.Delay(2000, token);

                        if (token.IsCancellationRequested) return;

                        this.Invoke(new Action(() =>
                        {
                            ResetMachine();
                        }));
                    }
                    catch (TaskCanceledException)
                    {
                        // 🔥 safe cancel
                    }
                });
            }
            catch (Exception ex)
            {
                printingInProgress = false;
                MessageBox.Show("Print failed: " + ex.Message);
            }
        }

        private void PrintFunPhoto()
        {
            if (finalFunImage == null)
            {
                MessageBox.Show("No image to print.");
                return;
            }

            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = "Canon MG3000 series";

                // ✅ SAME SCALING AS ID
                pd.PrintPage += (sender, e) =>
                {
                    Rectangle m = e.MarginBounds;

                    float ratioX = (float)m.Width / finalFunImage.Width;
                    float ratioY = (float)m.Height / finalFunImage.Height;
                    float ratio = Math.Min(ratioX, ratioY);

                    int width = (int)(finalFunImage.Width * ratio);
                    int height = (int)(finalFunImage.Height * ratio);

                    int x = m.X + (m.Width - width) / 2;
                    int y = m.Y + (m.Height - height) / 2;

                    e.Graphics.DrawImage(finalFunImage, x, y, width, height);
                };

                pd.Print();

                string archiveFolder = @"C:\PrintAndSnap\FUN\archive";
                string downloadFolder = @"C:\PrintAndSnap\FUN\download";

                Directory.CreateDirectory(archiveFolder);
                Directory.CreateDirectory(downloadFolder);

                string code = "";

                if (string.IsNullOrEmpty(currentFunRetrievalCode))
                {
                    // ✅ ALREADY CORRECT
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
                $"uses=1",
                $"maxUses=3"
            });
                }
                else
                {
                    code = currentFunRetrievalCode;
                }

                string fileName = code + ".png";
                string downloadPath = Path.Combine(downloadFolder, fileName);

                finalFunImage.Save(downloadPath, ImageFormat.Png);

                lastSavedFunFileName = fileName;
                currentFunRetrievalCode = code;

                funDownloadBtn.Enabled = true;

                MessageBox.Show($"Printed!\n\nYour Retrieval Code:\n{code}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print failed: " + ex.Message);
            }
        }


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

                // 🔥 FORCE UI THREAD UPDATE
                this.Invoke(new Action(() =>
                {
                    qrIdPrintingDownload.Image = qrImage;
                    qrIdPrintingDownload.SizeMode = PictureBoxSizeMode.Zoom;

                    qrIdPrintingDownload.Visible = true;
                    qrIdPrintingDownload.BringToFront();

                    IDpayment.Visible = true; // 🔥 ENSURE PANEL IS VISIBLE
                    IDpayment.BringToFront();
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

                // 🔥 RESET SERVER
                uploadService.StopServer();
                await Task.Delay(500);

                uploadService.GenerateNewToken();

                uploadService.StartUploadServer();
                await Task.Delay(1200);

                GenerateQrForDownload(fileToDownload);

                ShowPhotoPanel(photoIDPanel, softCopyDownloadId);

                // =========================
                // 🔐 AUTO DELETE AFTER DOWNLOAD
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

                            // 🔥 delay before reset (better UX)
                            await Task.Delay(2000);

                            this.Invoke(new Action(() =>
                            {
                                ResetMachine();
                            }));

                            break;
                        }

                        await Task.Delay(1000);
                    }

                    // 🔥 IF NOT DOWNLOADED → fallback reset
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
                            ResetMachine();
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
            int gap = 10; // 🔥 SPACE BETWEEN PHOTOS

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

                // ✂️ CUT LINES (center)
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

                // ✂️ CUT LINE (middle)
                int midY = y + height / 2;
                g.DrawLine(pen, x, midY, x + width, midY);
            }
        }

        //=============
        //FUN PHOTO
        //=============
        private void FunUpdateCameraFrame(Bitmap frame)
        {
            if (lastFrame != null)
                lastFrame.Dispose();

            lastFrame = (Bitmap)frame.Clone();

            funCameraFeed.Image = lastFrame;
            funCameraFeed.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void funModeBtn_Click(object sender, EventArgs e)
        {
            ResetPhotoSession(); // 🔥 unified reset

            currentMode = PhotoMode.Fun; // ✅ NEW SYSTEM

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

        private void idModeBtn_Click(object sender, EventArgs e)
        {
            ResetPhotoSession(); // 🔥 important

            currentMode = PhotoMode.ID; // ✅ NEW SYSTEM

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

        private void funCaptureAgainBtn_Click(object obj, EventArgs args)
        {
            ResetPhotoSession(); // 🔥 replaces everything

            cameraService.StartCamera();

            ResetFunCache(); // keep this (FUN only)
        }

        private void idCaptureAgainBtn_Click(object obj, EventArgs args)
        {
            ResetPhotoSession(); // 🔥 replaces everything

            cameraService.StartCamera();
        }

        private void funCaptureBtn_Click(object sender, EventArgs args)
        {
            if (currentFrame == null)
                return;

            // 🔥 PREVENT SPAM CLICK
            if (captureTimer.Enabled)
                return;

            if (capturedPhotos.Count >= 4)
            {
                MessageBox.Show("Maximum of 4 photos only.");
                return;
            }

            funCaptureBtn.Enabled = false;

            countdown = 3;
            captureTimer.Start();
        }



        private async void funContinueBtn_Click(object sender, EventArgs args)
        {
            if (isProcessing) return;
            isProcessing = true;

            funContinueBtn.Enabled = false;

            try
            {
                if (capturedPhotos.Count == 0)
                {
                    MessageBox.Show("Please capture at least one photo.");
                    return;
                }

                await Task.Run(() => cameraService.StopCamera());
                await Task.Delay(200);

                string tempFolder = @"C:\PrintAndSnap\FUN\temp";
                Directory.CreateDirectory(tempFolder);

                foreach (var file in Directory.GetFiles(tempFolder))
                {
                    try { File.Delete(file); } catch { }
                }

                for (int i = 0; i < capturedPhotos.Count; i++)
                {
                    string path = Path.Combine(tempFolder, $"temp_{i + 1}.png");
                    capturedPhotos[i].Save(path, ImageFormat.Png);
                }

                ResetFunCache();

                ShowFunCapturedPhotos();

                ShowPhotoPanel(photoBoothPanel, photoBoothSettings);

                LoadFunSelectionPhotos();
            }
            finally
            {
                isProcessing = false;
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
                if (i < capturedPhotos.Count)
                {
                    if (boxes[i].Image != null)
                        boxes[i].Image.Dispose();

                    boxes[i].Image = (Bitmap)capturedPhotos[i].Clone();
                    boxes[i].Visible = true;
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    boxes[i].Visible = false;
                }
            }
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

                boxes[i].Click -= FunSelectPhoto_Click;

                if (i < capturedPhotos.Count)
                {
                    if (boxes[i].Image != null)
                        boxes[i].Image.Dispose();

                    boxes[i].Image = (Bitmap)capturedPhotos[i].Clone();
                    boxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    boxes[i].Visible = true;

                    boxes[i].Click += FunSelectPhoto_Click;
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

                funRadioBtbFilterNone.Checked = true;
                funRadioBtnFrameNone.Checked = true;

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

        private void FunSelectPhoto_Click(object sender, EventArgs e)
        {
            PictureBox clicked = sender as PictureBox;

            if (clicked?.Image == null)
                return;

            hasUserSelectedPhoto = true;

            selectedPhoto = (Bitmap)clicked.Image.Clone();

            HighlightFunSelectedPhoto(clicked);

            UpdateFunSettings(); // ✅ CORRECT
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
                // CLEAN OLD CACHE
                foreach (var img in cachedFilteredPhotos)
                    img.Dispose();

                cachedFilteredPhotos.Clear();

                // REBUILD CACHE
                foreach (var photo in capturedPhotos)
                {
                    cachedFilteredPhotos.Add(filterService.ApplyFunFilter(photo, funFilter));
                }

                lastAppliedFilter = funFilter;
            }

            // =========================
            // APPLY LAYOUT + FRAME
            // =========================
            Bitmap laidOut = layoutService.ApplyFunLayout(cachedFilteredPhotos, funLayout);
            Bitmap preview = frameService.ApplyFunFrame(laidOut, funFrame);

            // =========================
            // MAIN PREVIEW
            // =========================
            if (funMainPreview.Image != null)
                funMainPreview.Image.Dispose();

            funMainPreview.Image = (Bitmap)preview.Clone();
            funMainPreview.SizeMode = PictureBoxSizeMode.Zoom;

            // =========================
            // MINI PREVIEW
            // =========================
            if (funMiniPreview.Image != null)
                funMiniPreview.Image.Dispose();

            funMiniPreview.Image = (Bitmap)preview.Clone();
            funMiniPreview.SizeMode = PictureBoxSizeMode.Zoom;

            // =========================
            // CLEAN TEMP (NOT CACHE)
            // =========================
            laidOut.Dispose();
            preview.Dispose();
        }

        //LAYOUT
        private void funRadioBtnVertical_click(object sender, EventArgs e)
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

        private void funRadioBtnGridBtn_click(object sender, EventArgs e)
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

        //FRAME
        private void funRadioBtnFrameNone_click(object sender, EventArgs e)
        {
            funFrame = "none";
            UpdateFunSettings();
        }

        private void funRadioBtnMinimal_click(object sender, EventArgs e)
        {
            funFrame = "minimal";
            UpdateFunSettings();
        }

        private void funRadioBtnCute_click(object sender, EventArgs e)
        {
            funFrame = "cute";
            UpdateFunSettings();
        }

        //FILTER
        private void funRadioBtbFilterNone_click(object sender, EventArgs e)
        {
            funFilter = "none";
            UpdateFunSettings();
        }
        private void funRadioBtnWarm_click(object sender, EventArgs e)
        {
            funFilter = "warm";
            UpdateFunSettings();
        }

        private void funRadioBtnBlack_click(object sender, EventArgs e)
        {
            funFilter = "black";
            UpdateFunSettings();
        }

        private void StopDownloadSession()
        {
            try
            {
                uploadService.StopServer();

                Thread.Sleep(300); // 🔥 ensure stop

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

        private void ResetFunCache()
        {
            foreach (var img in cachedFilteredPhotos)
                img.Dispose();

            cachedFilteredPhotos.Clear();
            lastAppliedFilter = "";
        }

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

            funTotal.Text = "₱" + total.ToString();
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

            MessageBox.Show("❌ Invalid or expired code.");
        }

        private void PrintFunImage(Bitmap image)
        {
            PrintDocument pd = new PrintDocument();

            pd.PrintPage += (s, e) =>
            {
                e.Graphics.DrawImage(image, 0, 0, e.PageBounds.Width, e.PageBounds.Height);
            };

            pd.Print();
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

            selectedPhoto = (Bitmap)capturedPhotos[0].Clone();
            hasUserSelectedPhoto = true;

            ShowPhotoPanel(photoBoothPanel, photoBoothSettings);
            LoadFunSelectionPhotos();
            UpdateFunSettings();
            currentFunRetrievalCode = code;

            MessageBox.Show(
    $"✅ Photos loaded!\n\n" +
    $"Usage: {uses}/{maxUses}\n" +
    $"Remaining: {maxUses - uses}"
);
        }

        private void funSettingsContinueBtn_Click(object sender, EventArgs e)
        {
            if (selectedPhoto == null || !hasUserSelectedPhoto)
            {
                MessageBox.Show("⚠️ Please select a photo first.");
                return;
            }

            // GENERATE FINAL IMAGE
            Bitmap laidOut = layoutService.ApplyFunLayout(cachedFilteredPhotos, funLayout);
            finalFunImage = frameService.ApplyFunFrame(laidOut, funFrame);
            laidOut.Dispose();

            if (finalFunImage == null)
            {
                MessageBox.Show("Failed to generate image.");
                return;
            }

            // PRICE
            totalFunPrice = int.Parse(funTotal.Text.Replace("₱", ""));

            // ✅ CORRECT UI
            paymentFunTotal.Text = "₱" + totalFunPrice;
            paymentFunBalance.Text = "₱" + totalFunPrice;

            insertedMoney = 0;

            // disable print until paid
            paymentFunPrintBtn.Enabled = false;

            currentMode = PhotoMode.Fun;

            ShowPhotoPanel(photoBoothPanel, funPaymentPanel);
        }

        private async void funDownloadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                funDownloadBtn.Enabled = false; // 🔥 prevent spam

                if (string.IsNullOrEmpty(lastSavedFunFileName))
                {
                    MessageBox.Show("No image to download.");
                    funDownloadBtn.Enabled = true;
                    return;
                }

                string folder = @"C:\PrintAndSnap\FUN\download";
                string fullPath = Path.Combine(folder, lastSavedFunFileName);

                if (!File.Exists(fullPath))
                {
                    MessageBox.Show("File not found.");
                    funDownloadBtn.Enabled = true;
                    return;
                }

                // 🔥 HARD RESET SERVER (same as ID)
                uploadService.StopServer();
                await Task.Delay(500); // 🔥 increased

                uploadService.GenerateNewToken();

                uploadService.StartUploadServer();
                await Task.Delay(1200); // 🔥 ensure server is ready

                GenerateQrForFunDownload(lastSavedFunFileName);

                ShowPhotoPanel(photoBoothPanel, funSoftCopyDownloadPanel);

                funDownloadBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Download error: " + ex.Message);
                funDownloadBtn.Enabled = true;
            }
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

                // 🔥 SHOW IN FUN QR BOX
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

        private void SaveCapturedPhotos(string folder)
        {
            for (int i = 0; i < capturedPhotos.Count; i++)
            {
                string path = Path.Combine(folder, $"photo{i + 1}.png");
                capturedPhotos[i].Save(path, ImageFormat.Png);
            }
        }

        //PHOTO CANCEL BUTTONS
        private void photoModeCancelBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }

        private void photoCancelRetrievalBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }

        private void funCancelBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }

        private void funSettingsCancelBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }

        private void paymentFunCancelBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }

        private void funSoftCopyCancelBtn_Click(object sender, EventArgs e)
        {
            StopDownloadSession();
            ResetMachine();
        }

        private void idPrintingCancelBtn_Click(object sender, EventArgs args)
        {
            ResetMachine();
        }
        private void idPrintSettingsCancelBtn_Click(object obj, EventArgs args)
        {
            ResetMachine();
        }

        private void cancelBtnPaymentId_Click(object obj, EventArgs args)
        {
            ResetMachine();
        }

        private void downloadCancelBtn_Click(object obj, EventArgs args)
        {
            StopDownloadSession();
            ResetMachine();
        }

        //PHOTO BACK BUTTONS
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

        //DOC PRINTING
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

            InitializeFolders();

            // Setup timer that waits for uploaded file preview
            receiveTimer = new System.Windows.Forms.Timer();
            receiveTimer.Interval = 3000;
            receiveTimer.Tick += ReceiveTimer_Tick;

            cleanupTimer = new System.Windows.Forms.Timer();
            cleanupTimer.Interval = 5000; // change this for prod 10minutes
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
        private void ShowPhotoPanel(Control mainPanel, Control subPanel = null)
        {
            photoPanel.Visible = true;
            photoPanel.BringToFront();

            // Hide all main panels
            photoMode.Visible = false;
            photoIDPanel.Visible = false;
            retrievalPanelPhoto.Visible = false;
            photoBoothPanel.Visible = false;

            // 🔥 SHOW MAIN PANEL
            mainPanel.Visible = true;
            mainPanel.BringToFront();

            // 🔥 HANDLE ID PANEL SUBPANELS
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
            // DOC PANELS
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
            // 🔥 DO NOTHING DURING SESSION
            if (sessionActive)
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

            // ✅ LOG ONLY IF CHANGED
    if (error != lastPrinterError)
    {
        DebugLog("Printer Error RAW: " + error);
        lastPrinterError = error;
    }


    if (!string.IsNullOrEmpty(error))
    {
        string err = error.ToLower();

        if (err.Contains("paper") ||
            err.Contains("jam") ||
            err.Contains("offline") ||
            err.Contains("door") ||
            err.Contains("ink") ||
            err.Contains("error")) 
        {
            printerStatusLabel.Text = "Printer: " + error;
            printerStatusLabel.ForeColor = Color.Red;
            continuePaymentBtn.Enabled = false;

            if (!printingInProgress && !printerErrorShown)
            {
                printerErrorShown = true;
                MessageBox.Show("Printer problem detected.\nPlease call staff.");
            }

            return;
        }
    }

    string status = printerManager.GetPrinterStatus(printerName);

    printerStatusLabel.Text = "Printer: " + status;

    if (status.Contains("Ready") || status.Contains("Idle"))
    {
        printerStatusLabel.ForeColor = Color.Green;
        continuePaymentBtn.Enabled = true;
        
    }
    else if (status.Contains("Printing") || status.Contains("Spooling"))
    {
        printerStatusLabel.ForeColor = Color.Blue;
        continuePaymentBtn.Enabled = false;
    }
    else
    {
        printerStatusLabel.ForeColor = Color.OrangeRed;
        continuePaymentBtn.Enabled = true;
    }

    printerErrorShown = false;
}

        private void CleanupTimer_Tick(object sender, EventArgs e)
        {
            if (printingInProgress)
                return;

            // DOC FILES
            CleanFolder(@"C:\PrintAndSnap\DOCS\archive", 30, currentPdfPath);

            // ID FILES
            string archiveFolder = @"C:\PrintAndSnap\ID\archive";

            foreach (var dir in Directory.GetDirectories(archiveFolder))
            {
                Debug.WriteLine($"Checking folder: {dir}");

    
                try
                {
                    string metaPath = Path.Combine(dir, "meta.txt");

                    if (!File.Exists(metaPath))
                        continue;

                    var meta = ReadMeta(dir);
                    Debug.WriteLine($"Created: {meta.created}");
                    Debug.WriteLine($"Now: {DateTime.Now}");
                    Debug.WriteLine($"Minutes diff: {(DateTime.Now - meta.created).TotalMinutes}");
                    DateTime created = meta.created;

                    if ((DateTime.Now - created).TotalMinutes > 1)
                    {
                        try
                        {
                            // 🔥 force GC to release file handles
                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            Directory.Delete(dir, true);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("DELETE FAILED: " + ex.Message);
                        }
                    }
                }
                catch { }


            }
            // ID DOWNLOAD (5 minutes)
            CleanFolder(@"C:\PrintAndSnap\ID\download", 5);

            // PREVIEW
            CleanFolder(@"C:\PrintAndSnap\DOCS\preview", 10, currentPdfPath);


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

        //START/UPLOAD FLOW//

        public void startBtn_Click(object sender, EventArgs e)
        {

            showPanel(printingOptionsPanel);
            
            inactivityTimer.Start();
        }

        private void docPrintingBtn_Click(Object sender, EventArgs e)
        {
            currentSystemMode = SystemMode.Docs;
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
                @"C:\PrintAndSnap\DOCS\preview",
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

            int total = 0;

            // =========================
            // 💰 GET TOTAL BASED ON MODE
            // =========================
            if (currentSystemMode == SystemMode.Docs)
            {
                total = totalPrice;
            }
            else if (currentSystemMode == SystemMode.Photo)
            {
                if (currentMode == PhotoMode.Fun)
                    total = totalFunPrice;
                else if (currentMode == PhotoMode.ID)
                    total = totalIdPrice;
            }

            int remaining = total - insertedMoney;

            if (remaining < 0)
                remaining = 0;

            // =========================
            // 🔘 ENABLE PRINT BUTTON
            // =========================
            if (remaining == 0)
            {
                if (currentSystemMode == SystemMode.Docs)
                {
                    printBtn.Enabled = true;
                }
                else if (currentSystemMode == SystemMode.Photo)
                {
                    if (currentMode == PhotoMode.ID)
                        printBtnPaymentId.Enabled = true;
                    else if (currentMode == PhotoMode.Fun)
                        paymentFunPrintBtn.Enabled = true;
                }
            }
            else
            {
                // disable all print buttons
                printBtn.Enabled = false;
                printBtnPaymentId.Enabled = false;
                paymentFunPrintBtn.Enabled = false;

                if (currentSystemMode == SystemMode.Photo && currentMode == PhotoMode.ID)
                {
                    if (remaining == 0 && !printingInProgress)
                    {
                        printBtnPaymentId.Enabled = true;
                    }
                    else
                    {
                        printBtnPaymentId.Enabled = false;
                    }
                }
            }

            // =========================
            // 🖥 UPDATE UI BALANCE
            // =========================
            if (currentSystemMode == SystemMode.Docs)
            {
                paymentBalance.Text = "₱" + remaining;
            }
            else if (currentSystemMode == SystemMode.Photo)
            {
                if (currentMode == PhotoMode.Fun)
                    paymentFunBalance.Text = "₱" + remaining;
                else if (currentMode == PhotoMode.ID)
                    paymentIDprintingBalance.Text = "₱" + remaining;
            }
        }

        private void PrintImage(Bitmap image)
        {
            PrintDocument pd = new PrintDocument();

            pd.PrintPage += (s, e) =>
            {
                e.Graphics.DrawImage(image, 0, 0, e.PageBounds.Width, e.PageBounds.Height);
            };

            pd.Print();
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
            if (printingInProgress) return;

            printBtn.Enabled = false;

            printingStatusLabel.Text = "Printing in progress...";
            printingStatusLabel.Visible = true;

            printingInProgress = true;
          
            try
            {
                await Task.Run(() =>
                {
                    try
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
                    }
                    catch (Exception ex)
                    {
                        DebugLog("PRINT ERROR: " + ex.Message);
                        printSuccess = false;
                    }
                });

                if (!printSuccess)
                {
                    printingStatusLabel.Text = "Printing failed.";
                    printingInProgress = false;
                    printBtn.Enabled = true;
                    return;
                }
                sessionActive = true;

                // WAIT (SAFE VERSION WITH TIMEOUT)
                await WaitForPrinterReady("Canon MG3000 series");

                // GENERATE CODE
                string code = GenerateRetrievalCode();

                printingStatusLabel.Text = "Printing completed.";

                // ✅ MOVE FILE
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

                // ✅ SHOW CODE (ON TOP)
                MessageBox.Show(
                    this,
                    "🖨 Printing completed!\n\n" +
                    "Your Retrieval Code: " + code,
                    "Printing",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // ✅ BACKGROUND RESET TIMER (NON-BLOCKING)
                _ = Task.Run(async () =>
                {
                    await Task.Delay(120000); // 2 minutes

                    this.Invoke(new Action(() =>
                    {
                        //ResetMachine();
                    }));
                });
            }
            finally
            {
                printingInProgress = false;
                printBtn.Enabled = true;
            }
        }
        private void printSettingsCancelBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }


        //RESET MACHINE
        private void ResetMachine()
        {
            resetTokenSource?.Cancel();

            try
            {
                string downloadFolder = @"C:\PrintAndSnap\ID\download";

                if (Directory.Exists(downloadFolder))
                {
                    foreach (var file in Directory.GetFiles(downloadFolder))
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
            catch { }
            //PHOTOBOOTH

            // =========================
            // RESET PHOTO STATES
            // =========================

            // =========================
            // CLEAR FUN PREVIEW BOXES
            // =========================
            PictureBox[] funBoxes =
            {
    funPreview1,
    funPreview2,
    funPreview3,
    funPreview4,
    funSelectPic1,
    funSelectPic2,
    funSelectPic3,
    funSelectPic4
};

            if (funMiniPreview.Image != null)
            {
                funMiniPreview.Image.Dispose();
                funMiniPreview.Image = null;
            }

            foreach (var box in funBoxes)
            {
                if (box.Image != null)
                {
                    box.Image.Dispose();
                    box.Image = null;
                }
            }

            foreach (var img in cachedFilteredPhotos)
                img.Dispose();

            cachedFilteredPhotos.Clear();
            lastAppliedFilter = "";

            currentFunRetrievalCode = null;
            lastSavedFunFileName = null;
            lastSavedIdFileName = null;

            currentMode = PhotoMode.None;
            hasUserSelectedPhoto = false;
            selectedPhoto = null;

            downloadBtnPaymentId.Enabled = false;
            funDownloadBtn.Enabled = false;
            paymentFunPrintBtn.Enabled = false;
            printBtnPaymentId.Enabled = false;

            qrIdPrintingDownload.Image = null;
            qrSoftCopyDownloadFun.Image = null;

            if (idSettingsPicturePreview.Image != null)
            {
                idSettingsPicturePreview.Image.Dispose();
                idSettingsPicturePreview.Image = null;
            }

            if (funMainPreview.Image != null)
            {
                funMainPreview.Image.Dispose();
                funMainPreview.Image = null;
            }

            if (funCameraFeed.Image != null)
            {
                funCameraFeed.Image.Dispose();
                funCameraFeed.Image = null;
            }

            // reset final images
            if (finalFunImage != null)
            {
                finalFunImage.Dispose();
                finalFunImage = null;
            }

            if (finalIdPrintImage != null)
            {
                finalIdPrintImage.Dispose();
                finalIdPrintImage = null;
            }

            isPhotoRetrievalMode = false;

            // UNLOCK everything again
            radioBtn2x2.Enabled = true;
            radioBtn2x1.Enabled = true;
            radioBtn1x1.Enabled = true;

            radioBtnPhotoColored.Enabled = true;
            radioBtnPhotoBlack.Enabled = true;

            radioBtnMultipleCopies.Enabled = true;
            radioBtnSinglePhotoCopies.Enabled = true;

            numericIdPrintingCopies.Enabled = true;

            cameraService.StopCamera();

            if (idCameraFeed.Image != null)
            {
                idCameraFeed.Image.Dispose();
                idCameraFeed.Image = null;
            }

            //CLEAR PREVIEW BOXES
            PictureBox[] boxes =
            {
                idPreviewPictureBox1,
                idPreviewPictureBox2,
                idPreviewPictureBox3,
                idPreviewPictureBox4
            };

            foreach (var box in boxes)
            {
                if (box.Image != null)
                {
                    box.Image.Dispose();
                    box.Image = null;
                }
            }

            //CLEAR STORED PHOTOS
            foreach (var img in capturedPhotos)
            {
                img.Dispose();
            }
            capturedPhotos.Clear();

            //RESET BUTTON
            idPrintingContinueBtn.Enabled = false;

            //RESET FRAME
            if (currentFrame != null)
            {
                currentFrame.Dispose();
                currentFrame = null;
            }

            sessionActive = false;

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
            string uploadFolder = @"C:\PrintAndSnap\DOCS\uploads";

            if (Directory.Exists(uploadFolder))
            {
                foreach (var file in Directory.GetFiles(uploadFolder))
                {
                    try { File.Delete(file); } catch { }
                }
            }

            // CLEAN PREVIEW FOLDER
            string previewFolder = @"C:\PrintAndSnap\DOCS\preview";

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

        private async Task WaitForPrinterReady(string printerName)
        {
            await Task.Run(() =>
            {
                bool wasPrinting = false;

                while (true)
                {
                    string status = printerManager.GetPrinterStatus(printerName);

                    // detect actual printing
                    if (status.Contains("Printing") || status.Contains("Spooling"))
                    {
                        wasPrinting = true;
                    }

                    // ONLY exit AFTER it has printed AND returned to ready
                    if (wasPrinting &&
                        (status.Contains("Ready") || status.Contains("Idle")))
                    {
                        break;
                    }

                    Thread.Sleep(500);
                }
            });
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


    }
}
