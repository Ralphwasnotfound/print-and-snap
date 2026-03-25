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

        //UI STATE
        private int dotCount = 0;
        private string baseStatusText = "";

        //SYSTEM HOOK
        private IntPtr hookID = IntPtr.Zero;

        //PHOTO BOOTH
        private CameraService cameraService = new CameraService();
        private PhotoService photoService = new PhotoService();

        private Bitmap currentFrame;
        private Bitmap lastFrame;

        private  List<Bitmap> capturedPhotos = new List<Bitmap>();

        private System.Windows.Forms.Timer captureTimer;
        private int countdown = 3;

        private string lastSavedIdFileName;

        private string currentRetrievedIdPath;

        private Bitmap finalFunImage;

        private string lastSavedFunFileName;

        // ID SETTINGS STATE
        private string selectedLayout = "2x2";
        private bool isColored = true;
        private bool isMultiple = false;

        private Bitmap finalIdPrintImage;
        private Bitmap selectedPhoto;

        private bool isFunMode = false;

        // FUN SETTINGS STATE
        private string funFilter = "none";
        private string funLayout = "none";
        private string funFrame = "none";
        private int totalFunPrice = 0;

        private string currentFunRetrievalCode = null;

        //private int pricePerSheet = 20; // adjust if needed
        private int totalIdPrice = 0;

        private bool isIdMode = false;

        private bool hasUserSelectedPhoto = false;

        private bool isPhotoRetrievalMode = false;

        private int retrievalAttempts = 0;
        private const int MAX_RETRIEVAL_ATTEMPTS = 3;

        private int lastIdCopiesValue = 1;

        private int lastFunCopiesValue = 1;
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
        }

        //PHOTO BOOTH
        private DateTime lastFrameTime = DateTime.MinValue;

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
            photoPanel.Visible = true;
            photoPanel.BringToFront();

            ShowPhotoPanel(photoMode);
        }

        //ID PHOTO PRINTING
        private void idModeBtn_Click(object sender, EventArgs e)
        {
            ShowPhotoPanel(photoIDPanel, panelCRMidPrinting);

            isFunMode = false;


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

        private void photoModeCancelBtn_Click(object sender, EventArgs e)
        {
            ResetMachine();
        }

        private void idPrintingCancelBtn_Click(object sender, EventArgs args)
        {
            ResetMachine();
        }

        private async void idPrintingContinueBtn_Click(object sender, EventArgs args)
        {
            idPrintingContinueBtn.Enabled = false;

            if (capturedPhotos.Count == 0)
            {
                MessageBox.Show("Please capture at least one photo.");
                return;
            }

            cameraService.StopCamera();

            await Task.Delay(200);

            ShowCapturedPhotos();

            ShowPhotoPanel(photoIDPanel, idPrintingSettings);

            LoadIdSelectionPhotos();
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
                if (isFunMode)
                {
                    funCameraTimer.Text = countdown.ToString();
                    funCameraTimer.Visible = true;
                }
                else
                {
                    CameraTimer.Text = countdown.ToString();
                    CameraTimer.Visible = true;
                }

                countdown--;
            }
            else
            {
                captureTimer.Stop();

                if (isFunMode)
                {
                    funCameraTimer.Text = "📸";
                    await Task.Delay(500);
                    funCameraTimer.Visible = false;
                }
                else
                {
                    CameraTimer.Text = "📸";
                    await Task.Delay(500);
                    CameraTimer.Visible = false;
                }

                // =========================
                // SAFE FRAME CAPTURE
                // =========================
                Bitmap shot = null;
                Bitmap tempFrame = currentFrame;

                if (tempFrame != null)
                {
                    try
                    {
                        shot = new Bitmap(tempFrame); // SAFE COPY
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
                // SELECT MODE
                // =========================
                PictureBox[] boxes;

                if (isFunMode)
                {
                    boxes = new PictureBox[]
                    {
                funPreview1,
                funPreview2,
                funPreview3,
                funPreview4
                    };
                }
                else
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
                // SET IMAGE SAFELY
                // =========================
                boxes[index].Image = (Bitmap)shot.Clone();
                boxes[index].SizeMode = PictureBoxSizeMode.StretchImage;
                boxes[index].Visible = true;

                // =========================
                // ENABLE BUTTONS
                // =========================
                if (isFunMode)
                {
                    funContinueBtn.Enabled = true;
                    funCaptureBtn.Enabled = true;
                }
                else
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

        private void idCaptureAgainBtn_Click(object obj, EventArgs args)
        {
            PictureBox[] boxes =
            {
                idPreviewPictureBox1,
                idPreviewPictureBox2,
                idPreviewPictureBox3,
                idPreviewPictureBox4
            };

            foreach (var box in boxes)
            {
                if (box.Image  != null)
                {
                    box.Image.Dispose();
                    box.Image = null;
                }
            }

            foreach (var img in capturedPhotos)
                img.Dispose();

            capturedPhotos.Clear();

            cameraService.StartCamera();

            idPrintingContinueBtn.Enabled = false;
        }

        private (int uses, int maxUses, DateTime created, string metaPath) ReadMeta(string codeFolder)
        {
            string metaPath = Path.Combine(codeFolder, "meta.txt");

            var lines = File.ReadAllLines(metaPath);

            DateTime created = DateTime.Parse(lines[0].Split('=')[1]);
            int uses = int.Parse(lines[1].Split('=')[1]);
            int maxUses = int.Parse(lines[2].Split('=')[1]);

            return (uses, maxUses, created, metaPath);
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
            string metaPath = Path.Combine(codeFolder, "meta.txt");

            if (!File.Exists(metaPath))
            {
                MessageBox.Show("❌ Code data missing.");
                return;
            }

            var lines = File.ReadAllLines(metaPath);

            DateTime created = DateTime.Parse(lines[0].Split('=')[1]);
            int uses = int.Parse(lines[1].Split('=')[1]);
            int maxUses = int.Parse(lines[2].Split('=')[1]);

            // EXPIRY
            if ((DateTime.Now - created).TotalMinutes > 60)
            {
                MessageBox.Show("❌ Code expired.");
                return;
            }

            // USAGE
            if (uses >= maxUses)
            {
                MessageBox.Show("❌ Code already used 3 times.");
                return;
            }

            // LOAD ALL PHOTOS
            capturedPhotos.Clear();

            for (int i = 1; i <= 4; i++)
            {
                string photoPath = Path.Combine(codeFolder, $"photo{i}.png");

                if (File.Exists(photoPath))
                {
                    capturedPhotos.Add(new Bitmap(photoPath));
                }
            }

            if (capturedPhotos.Count == 0)
            {
                MessageBox.Show("No photos found.");
                return;
            }

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

            MessageBox.Show(
    $"✅ Photos loaded!\n\n" +
    $"Usage: {uses}/{maxUses}\n" +
    $"Remaining: {maxUses - uses}"
);
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

        private void idPrintSettingsCancelBtn_Click(object obj, EventArgs args )
        {
            ResetMachine();
        }

        private void idPrintSettingsBackBtn_Click(object obj, EventArgs args)
        {

        }

        private void idPrintSettingsContinueBtn_Click(object obj, EventArgs args)
        {
            DebugLog("=== CONTINUE BUTTON CLICKED ===");

            try
            {
                DebugLog("SelectedPhoto NULL? " + (selectedPhoto == null));
                DebugLog("hasUserSelectedPhoto: " + hasUserSelectedPhoto);

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

                DebugLog("Generating layout...");

                finalIdPrintImage = GenerateLayout(selectedPhoto);

                if (finalIdPrintImage == null)
                {
                    DebugLog("ERROR: finalIdPrintImage is null");
                    MessageBox.Show("Failed to generate image.");
                    return;
                }

                DebugLog("Layout generated successfully");

                string saveFolder = @"C:\PrintAndSnap\ID\temp";
                Directory.CreateDirectory(saveFolder);

                lastSavedIdFileName = "ID_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
                string filePath = Path.Combine(saveFolder, lastSavedIdFileName);

                DebugLog("Saving file: " + filePath);

                finalIdPrintImage.Save(filePath, ImageFormat.Png);

                DebugLog("File saved successfully");

                // PRICE
                DebugLog("Reading price label: " + idPrintingTotal.Text);

                totalIdPrice = int.Parse(idPrintingTotal.Text.Replace("₱", ""));

                paymentIDprintingTotal.Text = "₱" + totalIdPrice;
                paymentIDprintingBalance.Text = "₱" + totalIdPrice;

                insertedMoney = 0;
                printBtn.Enabled = false;
                downloadBtnPaymentId.Enabled = false;

                isIdMode = true;

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

        private Bitmap GenerateLayout(Bitmap photo)
        {
            if (photo == null)
                return null;

            int dpi = 300;

            Func<Bitmap, Image> processPhoto = (img) =>
            {
                if (!isColored)
                    return ConvertToGrayscale(img);

                return img;
            };

            int spacing = 20; // 🔥 SPACE BETWEEN PHOTOS (pixels)

            // 📌 SINGLE MODE
            if (!isMultiple)
            {
                int layoutWidth = 2 * dpi;
                int layoutHeight = 2 * dpi;

                if (selectedLayout == "1x1")
                {
                    layoutWidth = 1 * dpi;
                    layoutHeight = 1 * dpi;
                }

                Bitmap canvas = new Bitmap(layoutWidth + spacing * 2, layoutHeight + spacing * 2);
                canvas.SetResolution(300, 300);

                using (Graphics g = Graphics.FromImage(canvas))
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    g.Clear(Color.White);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;


                    DrawSingleLayout(
                        g,
                        processPhoto(photo),
                        spacing,
                        spacing,
                        layoutWidth,
                        layoutHeight,
                        pen
                    );
                }

                return canvas;
            }

            // 📌 MULTIPLE MODE (FULL PAGE)
            int pageWidth = (int)(8.27 * dpi);
            int pageHeight = (int)(11.69 * dpi);

            Bitmap sheet = new Bitmap(pageWidth, pageHeight);
            sheet.SetResolution(300, 300);

            using (Graphics g = Graphics.FromImage(sheet))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                g.Clear(Color.White);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                int layoutWidth = 2 * dpi;
                int layoutHeight = 2 * dpi;

                if (selectedLayout == "1x1")
                {
                    layoutWidth = 1 * dpi;
                    layoutHeight = 1 * dpi;
                }

                // include spacing
                int totalW = layoutWidth + spacing;
                int totalH = layoutHeight + spacing;

                int cols = pageWidth / totalW;
                int rows = pageHeight / totalH;

                // 🔥 center grid on page
                int offsetX = (pageWidth - (cols * totalW)) / 2;
                int offsetY = (pageHeight - (rows * totalH)) / 2;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        int x = offsetX + col * totalW;
                        int y = offsetY + row * totalH;

                        DrawSingleLayout(
                            g,
                            processPhoto(photo),
                            x,
                            y,
                            layoutWidth,
                            layoutHeight,
                            pen
                        );
                    }
                }
            }

            return sheet;
        }

        private void PrintIdPhoto()
        {
            if (finalIdPrintImage == null)
            {
                MessageBox.Show("No image to print.");
                return;
            }

            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = "Canon MG3000 series";

                pd.PrintPage += (s, ev) =>
                {
                    Rectangle m = ev.MarginBounds;

                    int x = m.X + (m.Width - finalIdPrintImage.Width) / 2;
                    int y = m.Y + (m.Height - finalIdPrintImage.Height) / 2;

                    ev.Graphics.DrawImage(finalIdPrintImage, x, y);
                };

                // pd.Print(); // enable in production
                MessageBox.Show("Printing Simulated successfully!");

                string idArchiveFolder = @"C:\PrintAndSnap\ID\archive";
                Directory.CreateDirectory(idArchiveFolder);

                string idDownloadFolder = @"C:\PrintAndSnap\ID\download";
                Directory.CreateDirectory(idDownloadFolder);

                string code = "";

                // =========================
                // 🟢 FIRST PRINT
                // =========================
                if (!isPhotoRetrievalMode)
                {
                    code = GenerateRetrievalCode();

                    string codeFolder = Path.Combine(idArchiveFolder, code);
                    Directory.CreateDirectory(codeFolder);

                    // SAVE ORIGINAL PHOTOS
                    for (int i = 0; i < capturedPhotos.Count; i++)
                    {
                        string photoPath = Path.Combine(codeFolder, $"photo{i + 1}.png");
                        capturedPhotos[i].Save(photoPath, ImageFormat.Png);
                    }

                    // SAVE LAYOUT (ARCHIVE)
                    string layoutPath = Path.Combine(codeFolder, "layout.png");
                    finalIdPrintImage.Save(layoutPath, ImageFormat.Png);

                    // SAVE FOR DOWNLOAD
                    string downloadFileName = code + ".png";
                    string downloadPath = Path.Combine(idDownloadFolder, downloadFileName);

                    finalIdPrintImage.Save(downloadPath, ImageFormat.Png);

                    lastSavedIdFileName = downloadFileName;

                    GenerateQrForDownload(downloadFileName);

                    // META
                    string metaPath = Path.Combine(codeFolder, "meta.txt");

                    File.WriteAllLines(metaPath, new[]
                    {
                $"created={DateTime.Now}",
                $"uses=0",
                $"maxUses=3"
            });

                    MessageBox.Show($"Printed!\n\nYour Retrieval Code:\n{code}");

                    this.Invoke(new Action(() =>
                    {
                        downloadBtnPaymentId.Enabled = true;
                    }));
                }

                // =========================
                // 🔵 RETRIEVAL MODE
                // =========================
                else
                {
                    string codeFolder = Path.GetDirectoryName(currentRetrievedIdPath);

                    if (codeFolder == null || !Directory.Exists(codeFolder))
                    {
                        MessageBox.Show("Retrieval folder missing.");
                        return;
                    }

                    string metaPath = Path.Combine(codeFolder, "meta.txt");

                    if (!File.Exists(metaPath))
                    {
                        MessageBox.Show("Meta file missing.");
                        return;
                    }

                    var lines = File.ReadAllLines(metaPath);

                    DateTime created = DateTime.Parse(lines[0].Split('=')[1]);
                    int uses = int.Parse(lines[1].Split('=')[1]);
                    int maxUses = int.Parse(lines[2].Split('=')[1]);

                    // EXPIRY CHECK
                    if ((DateTime.Now - created).TotalMinutes > 60)
                    {
                        MessageBox.Show("❌ Code expired.");
                        return;
                    }

                    // USAGE CHECK
                    if (uses >= maxUses)
                    {
                        MessageBox.Show("❌ Code already used 3 times.");
                        return;
                    }

                    // UPDATE USAGE
                    uses++;

                    File.WriteAllLines(metaPath, new[]
                    {
                $"created={created}",
                $"uses={uses}",
                $"maxUses={maxUses}"
            });

                    // 🔥 ALWAYS CREATE NEW DOWNLOAD IMAGE (UPDATED LAYOUT)
                    string codeName = new DirectoryInfo(codeFolder).Name;

                    string downloadFileName = codeName + ".png";
                    string downloadPath = Path.Combine(@"C:\PrintAndSnap\ID\download", downloadFileName);

                    finalIdPrintImage.Save(downloadPath, ImageFormat.Png);

                    lastSavedIdFileName = downloadFileName;

                    GenerateQrForDownload(downloadFileName);


                    MessageBox.Show(
                        $"Printed again!\n\n" +
                        $"Your Code: {codeName}\n" +
                        $"Usage: {uses}/{maxUses}"
                    );

                    this.Invoke(new Action(() =>
                    {
                        downloadBtnPaymentId.Enabled = true;
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print failed: " + ex.Message);
            }

            // =========================
            // CLEAN TEMP
            // =========================
            try
            {
                string tempFolder = @"C:\PrintAndSnap\ID\temp";

                if (Directory.Exists(tempFolder))
                {
                    foreach (var file in Directory.GetFiles(tempFolder))
                    {
                        try { File.Delete(file); } catch { }
                    }
                }
            }
            catch { }
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
        private void printBtnPaymentId_CLick(object sender, EventArgs e)
        {
            PrintIdPhoto();
        }

        private async void downloadBtnPaymentId_Click(object sender, EventArgs e)
        {
            try
            {

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
                    DebugLog("ERROR: No file to download");
                    return;
                }

                DebugLog("File to download: " + fileToDownload);

                string fullPath = Path.Combine(@"C:\PrintAndSnap\ID\download", fileToDownload);

                if (!File.Exists(fullPath))
                {
                    DebugLog("ERROR: FILE NOT FOUND -> " + fullPath);
                    return;
                }

                uploadService.StartUploadServer();
                DebugLog("Server started");

                await Task.Delay(500); 

                GenerateQrForDownload(fileToDownload);
                DebugLog("QR generated");

                ShowPhotoPanel(photoIDPanel, softCopyDownloadId);
                DebugLog("Download panel shown");
            }
            catch (Exception ex)
            {
                DebugLog("DOWNLOAD ERROR: " + ex.Message);
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
            ShowPhotoPanel(photoBoothPanel, panelCMRphotoBooth);

            isFunMode = true;

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
        }

        private void funCaptureBtn_Click(object sender, EventArgs args)
        {
            if (currentFrame == null)
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

        private void funCaptureAgainBtn_Click(object obj, EventArgs args)
        {
            PictureBox[] boxes =
            {
                funPreview1,
                funPreview2,
                funPreview3,
                funPreview4
            };

            foreach (var box in boxes)
            {
                if (box.Image != null)
                {
                    box.Image.Dispose();
                    box.Image = null;
                }
            }

            foreach (var img in capturedPhotos)
                img.Dispose();

            capturedPhotos.Clear();

            cameraService.StartCamera();

            funContinueBtn.Enabled = false;
        }

        private async void funContinueBtn_Click(object sender, EventArgs args)
        {
            funContinueBtn.Enabled = false;

            if (capturedPhotos.Count == 0)
            {
                MessageBox.Show("Please capture at least one photo.");
                return;
            }

            await Task.Run(() =>
            {
                cameraService.StopCamera();
            });

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

            ShowFunCapturedPhotos();

            ShowPhotoPanel(photoBoothPanel, photoBoothSettings);

            LoadFunSelectionPhotos();
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
            // PROCESS IMAGE (PIPELINE)
            // =========================
            Bitmap filtered = ApplyFunFilter(selectedPhoto);
            Bitmap laidOut = ApplyFunLayout(filtered);
            Bitmap preview = ApplyFunFrame(laidOut);

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

            // CLEAN MEMORY
            filtered.Dispose();
            laidOut.Dispose();
            preview.Dispose();
        }

        private Bitmap ApplyFunFrame(Bitmap photo)
        {
            if (photo == null)
                return null;

            Bitmap canvas = new Bitmap(photo.Width, photo.Height);

            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                // ALWAYS DRAW PHOTO FIRST
                g.DrawImage(photo, 0, 0, photo.Width, photo.Height);

                // =====================
                // FRAME (optional)
                // =====================
                if (funFrame == "minimal")
                {
                    using (Pen pen = new Pen(Color.Black, 5))
                    {
                        g.DrawRectangle(pen, 5, 5, canvas.Width - 10, canvas.Height - 10);
                    }
                }
                else if (funFrame == "cute")
                {
                    using (Pen pen = new Pen(Color.Pink, 8))
                    {
                        g.DrawRectangle(pen, 5, 5, canvas.Width - 10, canvas.Height - 10);
                    }

                    using (Brush b = new SolidBrush(Color.Pink))
                    {
                        g.FillEllipse(b, 5, 5, 20, 20);
                        g.FillEllipse(b, canvas.Width - 25, 5, 20, 20);
                        g.FillEllipse(b, 5, canvas.Height - 25, 20, 20);
                        g.FillEllipse(b, canvas.Width - 25, canvas.Height - 25, 20, 20);
                    }
                }

                // "none" → just skip frame (but photo is already drawn)
            }

            return canvas;
        }

        private Bitmap ApplyFunLayout(Bitmap photo)
        {
            if (photo == null)
                return null;

            int width = funMainPreview.Width;
            int height = funMainPreview.Height;

            Bitmap canvas = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                // QUALITY
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // =========================
                // BASE DRAW AREA (FULL WITH MARGIN)
                // =========================
                int margin = 20;

                Rectangle drawArea = new Rectangle(
                    margin,
                    margin,
                    width - margin * 2,
                    height - margin * 2
                );

                // =========================
                // VERTICAL STRIP (REAL PHOTOBOOTH)
                // =========================
                if (funLayout == "vertical")
                {
                    int count = 2;

                    int photoHeight = drawArea.Height / count;

                    for (int i = 0; i < count; i++)
                    {
                        int y = drawArea.Y + i * photoHeight;

                        Bitmap img;

                        if (capturedPhotos.Count > i)
                            img = ApplyFunFilter(capturedPhotos[i]); // 🔥 APPLY FILTER HERE
                        else
                            img = ApplyFunFilter(photo);

                        g.DrawImage(img,
                            drawArea.X,
                            y,
                            drawArea.Width,
                            photoHeight);

                        img.Dispose(); // cleanup
                    }
                }

                // =========================
                // GRID (2x2)
                // =========================
                else if (funLayout == "grid")
                {
                    int cols = 2;
                    int rows = 2;

                    int cellW = drawArea.Width / cols;
                    int cellH = drawArea.Height / rows;

                    int index = 0;

                    for (int r = 0; r < rows; r++)
                    {
                        for (int c = 0; c < cols; c++)
                        {
                            int x = drawArea.X + c * cellW;
                            int y = drawArea.Y + r * cellH;

                            Bitmap img;

                            if (capturedPhotos.Count > index)
                                img = ApplyFunFilter(capturedPhotos[index]); // 🔥 APPLY FILTER HERE
                            else
                                img = ApplyFunFilter(photo);

                            Rectangle destRect = new Rectangle(x, y, cellW, cellH);

                            // keep aspect ratio
                            float ratio = Math.Min(
                                (float)cellW / img.Width,
                                (float)cellH / img.Height
                            );

                            int newW = (int)(img.Width * ratio);
                            int newH = (int)(img.Height * ratio);

                            int posX = x + (cellW - newW) / 2;
                            int posY = y + (cellH - newH) / 2;

                            g.DrawImage(img, posX, posY, newW, newH);

                            img.Dispose(); // cleanup

                            index++;
                        }
                    }
                }

                // =========================
                // DEFAULT (SAFE FALLBACK)
                // =========================
                else
                {
                    g.DrawImage(photo, drawArea);
                }
            }

            return canvas;
        }

        private Bitmap ApplyFunFilter(Bitmap original)
        {
            if (original == null)
                return null;

            if (funFilter == "none")
                return (Bitmap)original.Clone();

            if (funFilter == "black")
                return ConvertToGrayscale(original);

            if (funFilter == "warm")
            {
                Bitmap warm = new Bitmap(original.Width, original.Height);

                using (Graphics g = Graphics.FromImage(warm))
                {
                    float[][] matrix =
                    {
                new float[] {1.1f, 0, 0, 0, 0},
                new float[] {0, 1.0f, 0, 0, 0},
                new float[] {0, 0, 0.9f, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0.05f, 0.02f, 0, 0, 1}
            };

                    ColorMatrix cm = new ColorMatrix(matrix);
                    ImageAttributes ia = new ImageAttributes();
                    ia.SetColorMatrix(cm);

                    g.DrawImage(original,
                        new Rectangle(0, 0, original.Width, original.Height),
                        0, 0, original.Width, original.Height,
                        GraphicsUnit.Pixel,
                        ia);
                }

                return warm;
            }

            return (Bitmap)original.Clone();
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

        private Bitmap GenerateFunFinalImage()
        {
            if (selectedPhoto == null)
                return null;

            int width = 1200;   // fixed print size
            int height = 1800;  // portrait strip

            Bitmap canvas = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);

                Bitmap filtered = ApplyFunFilter(selectedPhoto);

                // =====================
                // LAYOUT
                // =====================
                if (funLayout == "vertical")
                {
                    g.DrawImage(filtered, 200, 50, 800, 1600);
                }
                else if (funLayout == "grid")
                {
                    g.DrawImage(filtered, 100, 100, 450, 700);
                    g.DrawImage(filtered, 650, 100, 450, 700);
                    g.DrawImage(filtered, 100, 900, 450, 700);
                    g.DrawImage(filtered, 650, 900, 450, 700);
                }

                // =====================
                // FRAME
                // =====================
                if (funFrame == "minimal")
                {
                    using (Pen pen = new Pen(Color.Black, 10))
                    {
                        g.DrawRectangle(pen, 10, 10, width - 20, height - 20);
                    }
                }
                else if (funFrame == "cute")
                {
                    using (Pen pen = new Pen(Color.Pink, 15))
                    {
                        g.DrawRectangle(pen, 10, 10, width - 20, height - 20);
                    }
                }

                filtered.Dispose();
            }

            return canvas;
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

        private Bitmap GenerateFunPrintImage()
        {
            if (selectedPhoto == null)
                return null;

            int width = 1200;
            int height = 1800;

            Bitmap canvas = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);

                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                // HIGH QUALITY
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int margin = 40;

                Rectangle drawArea = new Rectangle(
                    margin,
                    margin,
                    width - margin * 2,
                    height - margin * 2
                );

                // =========================
                // 🔥 APPLY LAYOUT + FILTER
                // =========================
                if (funLayout == "vertical")
                {
                    int count = 2;
                    int photoHeight = drawArea.Height / count;

                    for (int i = 0; i < count; i++)
                    {
                        int y = drawArea.Y + i * photoHeight;

                        Bitmap img = (capturedPhotos.Count > i)
                            ? ApplyFunFilter(capturedPhotos[i])
                            : ApplyFunFilter(selectedPhoto);

                        g.DrawImage(img, drawArea.X, y, drawArea.Width, photoHeight);

                        img.Dispose();
                    }
                }
                else if (funLayout == "grid")
                {
                    int cols = 2;
                    int rows = 2;

                    int cellW = drawArea.Width / cols;
                    int cellH = drawArea.Height / rows;

                    int index = 0;

                    for (int r = 0; r < rows; r++)
                    {
                        for (int c = 0; c < cols; c++)
                        {
                            int x = drawArea.X + c * cellW;
                            int y = drawArea.Y + r * cellH;

                            Bitmap img = (capturedPhotos.Count > index)
                                ? ApplyFunFilter(capturedPhotos[index])
                                : ApplyFunFilter(selectedPhoto);

                            g.DrawImage(img, x, y, cellW, cellH);

                            img.Dispose();
                            index++;
                        }
                    }
                }
                else
                {
                    Bitmap img = ApplyFunFilter(selectedPhoto);
                    g.DrawImage(img, drawArea);
                    img.Dispose();
                }

                // =========================
                // APPLY FRAME (LAST)
                // =========================
                if (funFrame == "minimal")
                {
                    using (Pen pen = new Pen(Color.Black, 10))
                    {
                        g.DrawRectangle(pen, 5, 5, width - 10, height - 10);
                    }
                }
                else if (funFrame == "cute")
                {
                    using (Pen pen = new Pen(Color.Pink, 15))
                    {
                        g.DrawRectangle(pen, 5, 5, width - 10, height - 10);
                    }
                }
            }

            return canvas;
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

        private void paymentFunPrintBtn_Click(object sender, EventArgs e)
        {
            if (finalFunImage == null)
            {
                MessageBox.Show("No image to print.");
                return;
            }

            if (capturedPhotos.Count == 0)
            {
                MessageBox.Show("No captured photos found.");
                return;
            }

            int copies = (int)funNumericCopies.Value;

            MessageBox.Show($"Printing simulated! Copies: {copies}");

            // =========================
            // DOWNLOAD
            // =========================
            string downloadFolder = @"C:\PrintAndSnap\FUN\download";
            Directory.CreateDirectory(downloadFolder);

            string fileName = "FUN_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            string downloadPath = Path.Combine(downloadFolder, fileName);

            finalFunImage.Save(downloadPath, ImageFormat.Png);

            lastSavedFunFileName = fileName;
            funDownloadBtn.Enabled = true;

            // =========================
            // ARCHIVE
            // =========================
            string archiveFolder = @"C:\PrintAndSnap\FUN\archive";
            Directory.CreateDirectory(archiveFolder);

            string code = !string.IsNullOrEmpty(currentFunRetrievalCode)
                ? currentFunRetrievalCode
                : "FUN-" + GenerateRetrievalCode();

            string codeFolder = Path.Combine(archiveFolder, code);

            int uses = 0;
            int maxUses = 3;
            DateTime created;

            string metaPath = Path.Combine(codeFolder, "meta.txt");

            // =========================
            // 🟢 FIRST TIME
            // =========================
            if (!Directory.Exists(codeFolder))
            {
                Directory.CreateDirectory(codeFolder);

                // SAVE PHOTOS
                for (int i = 0; i < capturedPhotos.Count; i++)
                {
                    string photoPath = Path.Combine(codeFolder, $"photo{i + 1}.png");
                    capturedPhotos[i].Save(photoPath, ImageFormat.Png);
                }

                created = DateTime.Now;
                uses = 1;

                File.WriteAllLines(metaPath, new[]
                {
            $"created={created}",
            $"uses={uses}",
            $"maxUses={maxUses}"
        });
            }
            // =========================
            // 🔵 RETRIEVAL MODE
            // =========================
            else
            {
                if (!File.Exists(metaPath))
                {
                    MessageBox.Show("Meta file missing.");
                    return;
                }

                var lines = File.ReadAllLines(metaPath);

                created = DateTime.Parse(lines[0].Split('=')[1]);
                uses = int.Parse(lines[1].Split('=')[1]);
                maxUses = int.Parse(lines[2].Split('=')[1]);

                // EXPIRY
                if ((DateTime.Now - created).TotalMinutes > 60)
                {
                    MessageBox.Show("❌ Code expired.");
                    return;
                }

                // LIMIT
                if (uses >= maxUses)
                {
                    MessageBox.Show("❌ Code already used 3 times.");
                    return;
                }

                uses++;

                File.WriteAllLines(metaPath, new[]
                {
            $"created={created}",
            $"uses={uses}",
            $"maxUses={maxUses}"
        });
            }

            // =========================
            // FINAL MESSAGE (NOW WORKS)
            // =========================
            MessageBox.Show(
                $"Printed!\n\n" +
                $"Your Code: {code}\n" +
                $"Usage: {uses}/{maxUses}"
            );

            // CLEAN TEMP
            string tempFolder = @"C:\PrintAndSnap\FUN\temp";

            if (Directory.Exists(tempFolder))
            {
                foreach (var file in Directory.GetFiles(tempFolder))
                {
                    try { File.Delete(file); } catch { }
                }
            }

            currentFunRetrievalCode = null;
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

            string metaPath = Path.Combine(codeFolder, "meta.txt");

            if (!File.Exists(metaPath))
            {
                MessageBox.Show("❌ Code data missing.");
                return;
            }

            var lines = File.ReadAllLines(metaPath);

            DateTime created = DateTime.Parse(lines[0].Split('=')[1]);
            int uses = int.Parse(lines[1].Split('=')[1]);
            int maxUses = int.Parse(lines[2].Split('=')[1]);

            // EXPIRY
            if ((DateTime.Now - created).TotalMinutes > 60)
            {
                MessageBox.Show("❌ Code expired.");
                return;
            }

            if (uses >= maxUses)
            {
                MessageBox.Show("❌ Code already used 3 times.");
                return;
            }

            // LOAD PHOTOS
            capturedPhotos.Clear();

            for (int i = 1; i <= 4; i++)
            {
                string photoPath = Path.Combine(codeFolder, $"photo{i}.png");

                if (File.Exists(photoPath))
                {
                    capturedPhotos.Add(new Bitmap(photoPath));
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
            finalFunImage = GenerateFunPrintImage();

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

            isFunMode = true;
            isIdMode = false;

            ShowPhotoPanel(photoBoothPanel, funPaymentPanel);
        }

        private async void funDownloadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lastSavedFunFileName))
                {
                    MessageBox.Show("No image to download.");
                    return;
                }

                string folder = @"C:\PrintAndSnap\FUN\download";
                string fullPath = Path.Combine(folder, lastSavedFunFileName);

                if (!File.Exists(fullPath))
                {
                    MessageBox.Show("File not found.");
                    return;
                }

                // 🔥 ENSURE FRESH SERVER SESSION
                uploadService.StopServer();
                await Task.Delay(200);

                uploadService.GenerateNewToken(); // not required for download but keeps system clean

                uploadService.StartUploadServer();

                // 🔥 WAIT LONGER (IMPORTANT)
                await Task.Delay(1000);

                // 🔥 NOW SAFE TO GENERATE QR
                GenerateQrForFunDownload(lastSavedFunFileName);

                // 🔥 SHOW PANEL AFTER EVERYTHING READY
                ShowPhotoPanel(photoBoothPanel, funSoftCopyDownloadPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Download error: " + ex.Message);
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

            // DOC FILES
            CleanFolder(@"C:\PrintAndSnap\DOCS\archive", 30, currentPdfPath);

            // ID FILES
            CleanFolder(@"C:\PrintAndSnap\ID\archive", 60);
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

            int total;

            if (isFunMode)
                total = totalFunPrice;
            else if (isIdMode)
                total = totalIdPrice;
            else
                total = totalPrice;

            int remaining = total - insertedMoney;

            if (remaining <= 0)
            {
                if (isFunMode)
                    paymentFunPrintBtn.Enabled = true;
                else if (isIdMode)
                    printBtnPaymentId.Enabled = true;
            }

            if (remaining < 0)
                remaining = 0;

            // UPDATE UI
            if (isFunMode)
                paymentFunBalance.Text = "₱" + remaining;
            else if (isIdMode)
                paymentIDprintingBalance.Text = "₱" + remaining;
            else
                paymentBalance.Text = "₱" + remaining;

            // ENABLE PRINT ONLY
            if (remaining == 0)
            {
                printBtn.Enabled = true;
            }
            else
            {
                printBtn.Enabled = false;

                if (isIdMode)
                    downloadBtnPaymentId.Enabled = false;
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

            string code = "ID-" + GenerateRetrievalCode();

            string archiveFolder = @"C:\PrintAndSnap\DOCS\archive";
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

                string previewFolder = @"C:\PrintAndSnap\DOCS\preview";

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
            //PHOTOBOOTH

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
