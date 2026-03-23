using InTheHand.Net;
using InTheHand.Net.Sockets;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace PrintAndSnap
{
    partial class PrintAndSnap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startPanel = new System.Windows.Forms.Panel();
            this.startText = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.startButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.startBtn = new System.Windows.Forms.Button();
            this.startTitle = new System.Windows.Forms.TableLayoutPanel();
            this.title = new System.Windows.Forms.Label();
            this.startLeft = new System.Windows.Forms.TableLayoutPanel();
            this.startRight = new System.Windows.Forms.TableLayoutPanel();
            this.startBottom = new System.Windows.Forms.TableLayoutPanel();
            this.startTop = new System.Windows.Forms.TableLayoutPanel();
            this.uploadPanel = new System.Windows.Forms.Panel();
            this.uploadInstructionPanel = new System.Windows.Forms.Panel();
            this.uploadMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.qrpanelLayout = new System.Windows.Forms.Panel();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.qrPictureBox = new System.Windows.Forms.PictureBox();
            this.Instructions = new System.Windows.Forms.Panel();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.TableLayoutPanel();
            this.fileUploadStatusLabel = new System.Windows.Forms.Label();
            this.instructionTitle = new System.Windows.Forms.TableLayoutPanel();
            this.uploadFile = new System.Windows.Forms.Label();
            this.uploadQrPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.qrBackBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.qrInstructions = new System.Windows.Forms.TableLayoutPanel();
            this.qrInstruction1 = new System.Windows.Forms.Label();
            this.qrInstruction2 = new System.Windows.Forms.Label();
            this.qrInstruction3 = new System.Windows.Forms.Label();
            this.qrInstruction4 = new System.Windows.Forms.Label();
            this.qrInstruction5 = new System.Windows.Forms.Label();
            this.qrTitleLayout = new System.Windows.Forms.TableLayoutPanel();
            this.qrTitle = new System.Windows.Forms.Label();
            this.uploadBottom = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.uploadCancelBtn = new System.Windows.Forms.Button();
            this.retrievalBtn = new System.Windows.Forms.Button();
            this.continuePanel = new System.Windows.Forms.TableLayoutPanel();
            this.continueBtn = new System.Windows.Forms.Button();
            this.printingSettingsPanel = new System.Windows.Forms.Panel();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.printSettingsPanelLayout = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.numericSinglePage = new System.Windows.Forms.NumericUpDown();
            this.numericPageRange = new System.Windows.Forms.TextBox();
            this.totalPagesLabel = new System.Windows.Forms.Label();
            this.totalPagesLabelLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.copiesLabel = new System.Windows.Forms.Label();
            this.paperColor = new System.Windows.Forms.Label();
            this.selectPageLabel = new System.Windows.Forms.Label();
            this.copiesLayout = new System.Windows.Forms.TableLayoutPanel();
            this.numericCopies = new System.Windows.Forms.NumericUpDown();
            this.totalLabelLabel = new System.Windows.Forms.Label();
            this.printerStatusLabel = new System.Windows.Forms.Label();
            this.printerStatus = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.radioColored = new System.Windows.Forms.RadioButton();
            this.radioBlackWhite = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.radioSinglePage = new System.Windows.Forms.RadioButton();
            this.radioPrintRange = new System.Windows.Forms.RadioButton();
            this.radioPrintAll = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.filePreviewPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.previewPanelSettingLayout = new System.Windows.Forms.Panel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.editBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.labelPreview = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.continuePaymentBtn = new System.Windows.Forms.Button();
            this.settingsBackBtn = new System.Windows.Forms.Button();
            this.printSettingsCancelBtn = new System.Windows.Forms.Button();
            this.paymentPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPayment = new System.Windows.Forms.TableLayoutPanel();
            this.btn20 = new System.Windows.Forms.Button();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.totalPayment = new System.Windows.Forms.Label();
            this.paymentTotalLabel = new System.Windows.Forms.Label();
            this.paymentBalance = new System.Windows.Forms.Label();
            this.balancePaymentLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.cancelPrintBtn = new System.Windows.Forms.Button();
            this.paymentBackBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.paymentTableTitle = new System.Windows.Forms.TableLayoutPanel();
            this.paymentTitle = new System.Windows.Forms.Label();
            this.paymentRight = new System.Windows.Forms.TableLayoutPanel();
            this.paymentLeft = new System.Windows.Forms.TableLayoutPanel();
            this.paymentBottom = new System.Windows.Forms.TableLayoutPanel();
            this.printingStatusLabel = new System.Windows.Forms.Label();
            this.paymentTop = new System.Windows.Forms.TableLayoutPanel();
            this.retrivalPanel = new System.Windows.Forms.Panel();
            this.buttonsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.loadRetrievalBtn = new System.Windows.Forms.Button();
            this.retrieveCancelBtn = new System.Windows.Forms.Button();
            this.retrivalMain = new System.Windows.Forms.TableLayoutPanel();
            this.retrivalCodeTextBox = new System.Windows.Forms.TextBox();
            this.retrivalCodeLabel = new System.Windows.Forms.Label();
            this.retrivalLeft = new System.Windows.Forms.TableLayoutPanel();
            this.retrivalRight = new System.Windows.Forms.TableLayoutPanel();
            this.retrivalBottom = new System.Windows.Forms.TableLayoutPanel();
            this.retrivalTop = new System.Windows.Forms.TableLayoutPanel();
            this.printingOptionsPanel = new System.Windows.Forms.Panel();
            this.printingPanelTitle = new System.Windows.Forms.TableLayoutPanel();
            this.printingTitleLabel = new System.Windows.Forms.Label();
            this.MainPrintingPanel = new System.Windows.Forms.TableLayoutPanel();
            this.docPrintingBtn = new System.Windows.Forms.Button();
            this.photoPrintingBtn = new System.Windows.Forms.Button();
            this.printingPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.printingPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.printingPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.printingPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.printPanel = new System.Windows.Forms.Panel();
            this.photoPanel = new System.Windows.Forms.Panel();
            this.photoIDPanel = new System.Windows.Forms.Panel();
            this.idPrintingSettings = new System.Windows.Forms.Panel();
            this.IDpayment = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel47 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel53 = new System.Windows.Forms.TableLayoutPanel();
            this.label25 = new System.Windows.Forms.Label();
            this.paymentIDprintingTotal = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.paymentIDprintingBalance = new System.Windows.Forms.Label();
            this.tableLayoutPanel52 = new System.Windows.Forms.TableLayoutPanel();
            this.cancelBtnPaymentId = new System.Windows.Forms.Button();
            this.backBtnPaymentId = new System.Windows.Forms.Button();
            this.printBtnPaymentId = new System.Windows.Forms.Button();
            this.downloadBtnPaymentId = new System.Windows.Forms.Button();
            this.tableLayoutPanel51 = new System.Windows.Forms.TableLayoutPanel();
            this.label24 = new System.Windows.Forms.Label();
            this.softCopyDownloadId = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.qrIdPrintingDownload = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel41 = new System.Windows.Forms.TableLayoutPanel();
            this.label28 = new System.Windows.Forms.Label();
            this.tableLayoutPanel39 = new System.Windows.Forms.TableLayoutPanel();
            this.downloadBackBtn = new System.Windows.Forms.Button();
            this.downloadCancelBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel38 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.IDsettings = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel35 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel36 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel43 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtnPhotoColored = new System.Windows.Forms.RadioButton();
            this.radioBtnPhotoBlack = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel42 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtnSinglePhotoCopies = new System.Windows.Forms.RadioButton();
            this.radioBtnMultipleCopies = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel40 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtn2x2 = new System.Windows.Forms.RadioButton();
            this.radioBtn1x1 = new System.Windows.Forms.RadioButton();
            this.radioBtn2x1 = new System.Windows.Forms.RadioButton();
            this.idPrintingCopies = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tableLayoutPanel37 = new System.Windows.Forms.TableLayoutPanel();
            this.numericIdPrintingCopies = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel45 = new System.Windows.Forms.TableLayoutPanel();
            this.idPrintingTotal = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.idSettingsPicturePreview = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.idPrintPreviewMini = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel46 = new System.Windows.Forms.TableLayoutPanel();
            this.idSettingsSelectPicture1 = new System.Windows.Forms.PictureBox();
            this.idSettingsSelectPicture2 = new System.Windows.Forms.PictureBox();
            this.idSettingsSelectPicture3 = new System.Windows.Forms.PictureBox();
            this.idSettingsSelectPicture4 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel34 = new System.Windows.Forms.TableLayoutPanel();
            this.idPrintSettingsCancelBtn = new System.Windows.Forms.Button();
            this.idPrintSettingsBackBtn = new System.Windows.Forms.Button();
            this.idPrintSettingsConintueBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel33 = new System.Windows.Forms.TableLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panelCRMidPrinting = new System.Windows.Forms.Panel();
            this.tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel28 = new System.Windows.Forms.TableLayoutPanel();
            this.idPreviewPictureBox1 = new System.Windows.Forms.PictureBox();
            this.idPreviewPictureBox2 = new System.Windows.Forms.PictureBox();
            this.idPreviewPictureBox3 = new System.Windows.Forms.PictureBox();
            this.idPreviewPictureBox4 = new System.Windows.Forms.PictureBox();
            this.idCameraFeed = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel25 = new System.Windows.Forms.TableLayoutPanel();
            this.photoIDtitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel26 = new System.Windows.Forms.TableLayoutPanel();
            this.idPrintingCancelBtn = new System.Windows.Forms.Button();
            this.idCapctureAgainBtn = new System.Windows.Forms.Button();
            this.idPrintingContinueBtn = new System.Windows.Forms.Button();
            this.idCaptureBtn = new System.Windows.Forms.Button();
            this.CameraTimer = new System.Windows.Forms.Label();
            this.photoMode = new System.Windows.Forms.Panel();
            this.phototop = new System.Windows.Forms.TableLayoutPanel();
            this.photoLabelTitle = new System.Windows.Forms.Label();
            this.buttonLayoutPhoto = new System.Windows.Forms.TableLayoutPanel();
            this.photoBtnRetrieve = new System.Windows.Forms.Button();
            this.photoModeCancelBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            this.photoBtnPhotoBooth = new System.Windows.Forms.Button();
            this.tableLayoutPanel24 = new System.Windows.Forms.TableLayoutPanel();
            this.photoBtnID = new System.Windows.Forms.Button();
            this.photoBoothPanel = new System.Windows.Forms.Panel();
            this.panelCMRphotoBooth = new System.Windows.Forms.Panel();
            this.tableLayoutPanel31 = new System.Windows.Forms.TableLayoutPanel();
            this.photoBoothCameraPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel32 = new System.Windows.Forms.TableLayoutPanel();
            this.photoBoothPreviewPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel29 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.tableLayoutPanel30 = new System.Windows.Forms.TableLayoutPanel();
            this.photoBoothCaptureBtn = new System.Windows.Forms.Button();
            this.photoBoothContinueBtn = new System.Windows.Forms.Button();
            this.photoBoothCancelBtn = new System.Windows.Forms.Button();
            this.photoBoothSettings = new System.Windows.Forms.Panel();
            this.funSettings = new System.Windows.Forms.Panel();
            this.tableLayoutPanel55 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel56 = new System.Windows.Forms.TableLayoutPanel();
            this.label31 = new System.Windows.Forms.Label();
            this.tableLayoutPanel57 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtnVerticalPB = new System.Windows.Forms.RadioButton();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.tableLayoutPanel58 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtnGridBtnPB = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel59 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtnNonePB = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel60 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtnMinimalPB = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel61 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtnCutePB = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel62 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtbFilterNonePB = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel63 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtnBlackAndWhitePB = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel64 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtnWarmPB = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel65 = new System.Windows.Forms.TableLayoutPanel();
            this.photoBoothNumeriCopies = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel66 = new System.Windows.Forms.TableLayoutPanel();
            this.photoBoothTotal = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.photoBoothSettingsPreview = new System.Windows.Forms.Panel();
            this.tableLayoutPanel67 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel54 = new System.Windows.Forms.TableLayoutPanel();
            this.photoBoothSettingContinue = new System.Windows.Forms.Button();
            this.photoBoothSettingsBack = new System.Windows.Forms.Button();
            this.photoBoothSettingsCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel50 = new System.Windows.Forms.TableLayoutPanel();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.funPayment = new System.Windows.Forms.Panel();
            this.tableLayoutPanel71 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel72 = new System.Windows.Forms.TableLayoutPanel();
            this.label39 = new System.Windows.Forms.Label();
            this.paymentPhotoBoothTotal = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.paymentPhotoBoothBal = new System.Windows.Forms.Label();
            this.tableLayoutPanel73 = new System.Windows.Forms.TableLayoutPanel();
            this.qrPaymentPhotoBooth = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel70 = new System.Windows.Forms.TableLayoutPanel();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.tableLayoutPanel69 = new System.Windows.Forms.TableLayoutPanel();
            this.paymentPhotoBoothCancelBtn = new System.Windows.Forms.Button();
            this.paymentPhotoBoothBackBtn = new System.Windows.Forms.Button();
            this.paymentPhotoBoothPrintBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel68 = new System.Windows.Forms.TableLayoutPanel();
            this.label36 = new System.Windows.Forms.Label();
            this.retrievalPanelPhoto = new System.Windows.Forms.Panel();
            this.PhotoRetrievePanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel999 = new System.Windows.Forms.TableLayoutPanel();
            this.photoRetrievalBtn = new System.Windows.Forms.Button();
            this.photoCancelRetrievalBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel75 = new System.Windows.Forms.TableLayoutPanel();
            this.photoRetrievalCodeBox = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tableLayoutPanel76 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel77 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel78 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel79 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.startPanel.SuspendLayout();
            this.startText.SuspendLayout();
            this.startButtonLayout.SuspendLayout();
            this.startTitle.SuspendLayout();
            this.uploadPanel.SuspendLayout();
            this.uploadInstructionPanel.SuspendLayout();
            this.uploadMainLayout.SuspendLayout();
            this.qrpanelLayout.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrPictureBox)).BeginInit();
            this.Instructions.SuspendLayout();
            this.tableLayoutPanel19.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel20.SuspendLayout();
            this.tableLayoutPanel21.SuspendLayout();
            this.statusLabel.SuspendLayout();
            this.instructionTitle.SuspendLayout();
            this.uploadQrPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.qrInstructions.SuspendLayout();
            this.qrTitleLayout.SuspendLayout();
            this.uploadBottom.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.continuePanel.SuspendLayout();
            this.printingSettingsPanel.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.printSettingsPanelLayout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSinglePage)).BeginInit();
            this.copiesLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCopies)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.filePreviewPanel.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.paymentPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPayment.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.paymentTableTitle.SuspendLayout();
            this.paymentBottom.SuspendLayout();
            this.retrivalPanel.SuspendLayout();
            this.buttonsLayout.SuspendLayout();
            this.retrivalMain.SuspendLayout();
            this.printingOptionsPanel.SuspendLayout();
            this.printingPanelTitle.SuspendLayout();
            this.MainPrintingPanel.SuspendLayout();
            this.printPanel.SuspendLayout();
            this.photoPanel.SuspendLayout();
            this.photoIDPanel.SuspendLayout();
            this.idPrintingSettings.SuspendLayout();
            this.IDpayment.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel47.SuspendLayout();
            this.tableLayoutPanel53.SuspendLayout();
            this.tableLayoutPanel52.SuspendLayout();
            this.tableLayoutPanel51.SuspendLayout();
            this.softCopyDownloadId.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrIdPrintingDownload)).BeginInit();
            this.tableLayoutPanel41.SuspendLayout();
            this.tableLayoutPanel39.SuspendLayout();
            this.IDsettings.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel35.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel36.SuspendLayout();
            this.tableLayoutPanel43.SuspendLayout();
            this.tableLayoutPanel42.SuspendLayout();
            this.tableLayoutPanel40.SuspendLayout();
            this.tableLayoutPanel37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericIdPrintingCopies)).BeginInit();
            this.tableLayoutPanel45.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsPicturePreview)).BeginInit();
            this.tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idPrintPreviewMini)).BeginInit();
            this.tableLayoutPanel46.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture4)).BeginInit();
            this.tableLayoutPanel34.SuspendLayout();
            this.tableLayoutPanel33.SuspendLayout();
            this.panelCRMidPrinting.SuspendLayout();
            this.tableLayoutPanel27.SuspendLayout();
            this.tableLayoutPanel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idCameraFeed)).BeginInit();
            this.tableLayoutPanel25.SuspendLayout();
            this.tableLayoutPanel26.SuspendLayout();
            this.photoMode.SuspendLayout();
            this.phototop.SuspendLayout();
            this.buttonLayoutPhoto.SuspendLayout();
            this.tableLayoutPanel22.SuspendLayout();
            this.tableLayoutPanel23.SuspendLayout();
            this.tableLayoutPanel24.SuspendLayout();
            this.photoBoothPanel.SuspendLayout();
            this.panelCMRphotoBooth.SuspendLayout();
            this.tableLayoutPanel31.SuspendLayout();
            this.tableLayoutPanel32.SuspendLayout();
            this.tableLayoutPanel29.SuspendLayout();
            this.tableLayoutPanel30.SuspendLayout();
            this.photoBoothSettings.SuspendLayout();
            this.funSettings.SuspendLayout();
            this.tableLayoutPanel55.SuspendLayout();
            this.tableLayoutPanel56.SuspendLayout();
            this.tableLayoutPanel57.SuspendLayout();
            this.tableLayoutPanel58.SuspendLayout();
            this.tableLayoutPanel59.SuspendLayout();
            this.tableLayoutPanel60.SuspendLayout();
            this.tableLayoutPanel61.SuspendLayout();
            this.tableLayoutPanel62.SuspendLayout();
            this.tableLayoutPanel63.SuspendLayout();
            this.tableLayoutPanel64.SuspendLayout();
            this.tableLayoutPanel65.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoBoothNumeriCopies)).BeginInit();
            this.tableLayoutPanel66.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel54.SuspendLayout();
            this.tableLayoutPanel50.SuspendLayout();
            this.funPayment.SuspendLayout();
            this.tableLayoutPanel71.SuspendLayout();
            this.tableLayoutPanel72.SuspendLayout();
            this.tableLayoutPanel73.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrPaymentPhotoBooth)).BeginInit();
            this.tableLayoutPanel70.SuspendLayout();
            this.tableLayoutPanel69.SuspendLayout();
            this.tableLayoutPanel68.SuspendLayout();
            this.retrievalPanelPhoto.SuspendLayout();
            this.PhotoRetrievePanel.SuspendLayout();
            this.tableLayoutPanel999.SuspendLayout();
            this.tableLayoutPanel75.SuspendLayout();
            this.SuspendLayout();
            // 
            // startPanel
            // 
            this.startPanel.Controls.Add(this.startText);
            this.startPanel.Controls.Add(this.startButtonLayout);
            this.startPanel.Controls.Add(this.startTitle);
            this.startPanel.Controls.Add(this.startLeft);
            this.startPanel.Controls.Add(this.startRight);
            this.startPanel.Controls.Add(this.startBottom);
            this.startPanel.Controls.Add(this.startTop);
            this.startPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startPanel.Location = new System.Drawing.Point(0, 0);
            this.startPanel.Margin = new System.Windows.Forms.Padding(2);
            this.startPanel.Name = "startPanel";
            this.startPanel.Size = new System.Drawing.Size(1488, 729);
            this.startPanel.TabIndex = 0;
            // 
            // startText
            // 
            this.startText.ColumnCount = 3;
            this.startText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.startText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.startText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.startText.Controls.Add(this.label1, 1, 2);
            this.startText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startText.Location = new System.Drawing.Point(150, 229);
            this.startText.Margin = new System.Windows.Forms.Padding(2);
            this.startText.Name = "startText";
            this.startText.RowCount = 3;
            this.startText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.startText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.startText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.startText.Size = new System.Drawing.Size(1188, 318);
            this.startText.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 254);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(708, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click \"Start\" to begin";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startButtonLayout
            // 
            this.startButtonLayout.ColumnCount = 3;
            this.startButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.startButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.startButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.startButtonLayout.Controls.Add(this.startBtn, 1, 0);
            this.startButtonLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.startButtonLayout.Location = new System.Drawing.Point(150, 547);
            this.startButtonLayout.Margin = new System.Windows.Forms.Padding(2);
            this.startButtonLayout.Name = "startButtonLayout";
            this.startButtonLayout.RowCount = 1;
            this.startButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startButtonLayout.Size = new System.Drawing.Size(1188, 101);
            this.startButtonLayout.TabIndex = 5;
            // 
            // startBtn
            // 
            this.startBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(417, 2);
            this.startBtn.Margin = new System.Windows.Forms.Padding(2);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(352, 97);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "START";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // startTitle
            // 
            this.startTitle.ColumnCount = 3;
            this.startTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.startTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.startTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.startTitle.Controls.Add(this.title, 1, 0);
            this.startTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.startTitle.Location = new System.Drawing.Point(150, 81);
            this.startTitle.Margin = new System.Windows.Forms.Padding(2);
            this.startTitle.Name = "startTitle";
            this.startTitle.RowCount = 1;
            this.startTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startTitle.Size = new System.Drawing.Size(1188, 148);
            this.startTitle.TabIndex = 4;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(120, 0);
            this.title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(946, 148);
            this.title.TabIndex = 0;
            this.title.Text = "PRINT AND SNAP";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startLeft
            // 
            this.startLeft.ColumnCount = 1;
            this.startLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.startLeft.Location = new System.Drawing.Point(0, 81);
            this.startLeft.Margin = new System.Windows.Forms.Padding(2);
            this.startLeft.Name = "startLeft";
            this.startLeft.RowCount = 1;
            this.startLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startLeft.Size = new System.Drawing.Size(150, 567);
            this.startLeft.TabIndex = 3;
            // 
            // startRight
            // 
            this.startRight.ColumnCount = 1;
            this.startRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.startRight.Location = new System.Drawing.Point(1338, 81);
            this.startRight.Margin = new System.Windows.Forms.Padding(2);
            this.startRight.Name = "startRight";
            this.startRight.RowCount = 1;
            this.startRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startRight.Size = new System.Drawing.Size(150, 567);
            this.startRight.TabIndex = 2;
            // 
            // startBottom
            // 
            this.startBottom.ColumnCount = 1;
            this.startBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.startBottom.Location = new System.Drawing.Point(0, 648);
            this.startBottom.Margin = new System.Windows.Forms.Padding(2);
            this.startBottom.Name = "startBottom";
            this.startBottom.RowCount = 1;
            this.startBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startBottom.Size = new System.Drawing.Size(1488, 81);
            this.startBottom.TabIndex = 1;
            // 
            // startTop
            // 
            this.startTop.BackColor = System.Drawing.SystemColors.Control;
            this.startTop.ColumnCount = 1;
            this.startTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.startTop.ForeColor = System.Drawing.SystemColors.Control;
            this.startTop.Location = new System.Drawing.Point(0, 0);
            this.startTop.Margin = new System.Windows.Forms.Padding(2);
            this.startTop.Name = "startTop";
            this.startTop.RowCount = 1;
            this.startTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startTop.Size = new System.Drawing.Size(1488, 81);
            this.startTop.TabIndex = 0;
            // 
            // uploadPanel
            // 
            this.uploadPanel.Controls.Add(this.uploadInstructionPanel);
            this.uploadPanel.Controls.Add(this.uploadQrPanel);
            this.uploadPanel.Controls.Add(this.uploadBottom);
            this.uploadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadPanel.Location = new System.Drawing.Point(0, 0);
            this.uploadPanel.Margin = new System.Windows.Forms.Padding(2);
            this.uploadPanel.Name = "uploadPanel";
            this.uploadPanel.Size = new System.Drawing.Size(1488, 729);
            this.uploadPanel.TabIndex = 1;
            // 
            // uploadInstructionPanel
            // 
            this.uploadInstructionPanel.Controls.Add(this.uploadMainLayout);
            this.uploadInstructionPanel.Controls.Add(this.statusLabel);
            this.uploadInstructionPanel.Controls.Add(this.instructionTitle);
            this.uploadInstructionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadInstructionPanel.Location = new System.Drawing.Point(0, 0);
            this.uploadInstructionPanel.Margin = new System.Windows.Forms.Padding(2);
            this.uploadInstructionPanel.Name = "uploadInstructionPanel";
            this.uploadInstructionPanel.Size = new System.Drawing.Size(1488, 648);
            this.uploadInstructionPanel.TabIndex = 4;
            // 
            // uploadMainLayout
            // 
            this.uploadMainLayout.ColumnCount = 2;
            this.uploadMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.uploadMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.uploadMainLayout.Controls.Add(this.qrpanelLayout, 1, 0);
            this.uploadMainLayout.Controls.Add(this.Instructions, 0, 0);
            this.uploadMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadMainLayout.Location = new System.Drawing.Point(0, 112);
            this.uploadMainLayout.Name = "uploadMainLayout";
            this.uploadMainLayout.RowCount = 1;
            this.uploadMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.uploadMainLayout.Size = new System.Drawing.Size(1488, 493);
            this.uploadMainLayout.TabIndex = 4;
            // 
            // qrpanelLayout
            // 
            this.qrpanelLayout.Controls.Add(this.tableLayoutPanel18);
            this.qrpanelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrpanelLayout.Location = new System.Drawing.Point(598, 3);
            this.qrpanelLayout.Name = "qrpanelLayout";
            this.qrpanelLayout.Size = new System.Drawing.Size(887, 487);
            this.qrpanelLayout.TabIndex = 0;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 3;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel18.Controls.Add(this.qrPictureBox, 1, 1);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 3;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(887, 487);
            this.tableLayoutPanel18.TabIndex = 0;
            // 
            // qrPictureBox
            // 
            this.qrPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrPictureBox.Location = new System.Drawing.Point(46, 26);
            this.qrPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.qrPictureBox.Name = "qrPictureBox";
            this.qrPictureBox.Size = new System.Drawing.Size(794, 434);
            this.qrPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.qrPictureBox.TabIndex = 0;
            this.qrPictureBox.TabStop = false;
            // 
            // Instructions
            // 
            this.Instructions.Controls.Add(this.tableLayoutPanel19);
            this.Instructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Instructions.Location = new System.Drawing.Point(3, 3);
            this.Instructions.Name = "Instructions";
            this.Instructions.Size = new System.Drawing.Size(589, 487);
            this.Instructions.TabIndex = 1;
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.ColumnCount = 3;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel19.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel19.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 3;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(589, 487);
            this.tableLayoutPanel19.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel20);
            this.panel3.Controls.Add(this.tableLayoutPanel21);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(32, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(524, 432);
            this.panel3.TabIndex = 0;
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.ColumnCount = 4;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.61905F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.380952F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.380952F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.61905F));
            this.tableLayoutPanel20.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel20.Controls.Add(this.label6, 3, 1);
            this.tableLayoutPanel20.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel20.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel20.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel20.Controls.Add(this.label10, 0, 6);
            this.tableLayoutPanel20.Controls.Add(this.label11, 0, 7);
            this.tableLayoutPanel20.Controls.Add(this.label12, 3, 3);
            this.tableLayoutPanel20.Controls.Add(this.label13, 3, 4);
            this.tableLayoutPanel20.Controls.Add(this.label14, 3, 5);
            this.tableLayoutPanel20.Controls.Add(this.label15, 3, 6);
            this.tableLayoutPanel20.Controls.Add(this.label16, 3, 7);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(0, 39);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 9;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.770404F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.80718F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.616126F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.80718F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.80718F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.80718F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.80718F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.80718F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.770404F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel20.Size = new System.Drawing.Size(524, 393);
            this.tableLayoutPanel20.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 62);
            this.label5.TabIndex = 0;
            this.label5.Text = "QR CODE";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(276, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(245, 62);
            this.label6.TabIndex = 1;
            this.label6.Text = "RETRIVE FILE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(243, 62);
            this.label7.TabIndex = 2;
            this.label7.Text = "OPEN YOUR CAMERA OR QR SCANNER";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(243, 62);
            this.label8.TabIndex = 3;
            this.label8.Text = "SCAN THE QR CODE TO THE SCREEN";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(243, 62);
            this.label9.TabIndex = 4;
            this.label9.Text = "OPEN THE LINK AFTER SCANNING";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(243, 62);
            this.label10.TabIndex = 5;
            this.label10.Text = "UPLOAD THE FILE THAT YOU WANT TO PRINT";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(243, 62);
            this.label11.TabIndex = 6;
            this.label11.Text = "WAIT FOR CONFIRMATION";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(276, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(245, 62);
            this.label12.TabIndex = 15;
            this.label12.Text = "CLICK THE RETRIEVE BUTTON ON THE SCREEN";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(276, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(245, 62);
            this.label13.TabIndex = 16;
            this.label13.Text = "ENTER YOUR RETRIEVAL CODE";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(276, 198);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(245, 62);
            this.label14.TabIndex = 17;
            this.label14.Text = "RETRIEVE FILE";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(276, 260);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(245, 62);
            this.label15.TabIndex = 18;
            this.label15.Text = "WAIT FOR CONFIRMATION";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(276, 322);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(245, 62);
            this.label16.TabIndex = 19;
            this.label16.Text = "PRINT AGAIN";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel21
            // 
            this.tableLayoutPanel21.ColumnCount = 1;
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel21.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel21.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel21.Name = "tableLayoutPanel21";
            this.tableLayoutPanel21.RowCount = 1;
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel21.Size = new System.Drawing.Size(524, 39);
            this.tableLayoutPanel21.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(518, 39);
            this.label4.TabIndex = 0;
            this.label4.Text = "INSTRUCTIONS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLabel
            // 
            this.statusLabel.ColumnCount = 3;
            this.statusLabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.statusLabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.statusLabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.statusLabel.Controls.Add(this.fileUploadStatusLabel, 1, 0);
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusLabel.Location = new System.Drawing.Point(0, 605);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(2);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.RowCount = 1;
            this.statusLabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.statusLabel.Size = new System.Drawing.Size(1488, 43);
            this.statusLabel.TabIndex = 3;
            // 
            // fileUploadStatusLabel
            // 
            this.fileUploadStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileUploadStatusLabel.AutoSize = true;
            this.fileUploadStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileUploadStatusLabel.Location = new System.Drawing.Point(375, 0);
            this.fileUploadStatusLabel.Name = "fileUploadStatusLabel";
            this.fileUploadStatusLabel.Size = new System.Drawing.Size(738, 43);
            this.fileUploadStatusLabel.TabIndex = 0;
            this.fileUploadStatusLabel.Text = "Wating for file...\r\n";
            this.fileUploadStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // instructionTitle
            // 
            this.instructionTitle.ColumnCount = 1;
            this.instructionTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.instructionTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.instructionTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.instructionTitle.Controls.Add(this.uploadFile, 0, 0);
            this.instructionTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.instructionTitle.Location = new System.Drawing.Point(0, 0);
            this.instructionTitle.Margin = new System.Windows.Forms.Padding(2);
            this.instructionTitle.Name = "instructionTitle";
            this.instructionTitle.RowCount = 1;
            this.instructionTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.instructionTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.instructionTitle.Size = new System.Drawing.Size(1488, 112);
            this.instructionTitle.TabIndex = 0;
            // 
            // uploadFile
            // 
            this.uploadFile.AutoSize = true;
            this.uploadFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadFile.Location = new System.Drawing.Point(2, 0);
            this.uploadFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uploadFile.Name = "uploadFile";
            this.uploadFile.Size = new System.Drawing.Size(1484, 112);
            this.uploadFile.TabIndex = 0;
            this.uploadFile.Text = "FILE UPLOAD";
            this.uploadFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uploadQrPanel
            // 
            this.uploadQrPanel.Controls.Add(this.tableLayoutPanel1);
            this.uploadQrPanel.Controls.Add(this.qrInstructions);
            this.uploadQrPanel.Controls.Add(this.qrTitleLayout);
            this.uploadQrPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadQrPanel.Location = new System.Drawing.Point(0, 0);
            this.uploadQrPanel.Margin = new System.Windows.Forms.Padding(2);
            this.uploadQrPanel.Name = "uploadQrPanel";
            this.uploadQrPanel.Size = new System.Drawing.Size(1488, 648);
            this.uploadQrPanel.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.qrBackBtn, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(401, 567);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1087, 81);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // qrBackBtn
            // 
            this.qrBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrBackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrBackBtn.Location = new System.Drawing.Point(762, 2);
            this.qrBackBtn.Margin = new System.Windows.Forms.Padding(2);
            this.qrBackBtn.Name = "qrBackBtn";
            this.qrBackBtn.Size = new System.Drawing.Size(323, 77);
            this.qrBackBtn.TabIndex = 0;
            this.qrBackBtn.Text = "BACK";
            this.qrBackBtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(648, 81);
            this.label3.TabIndex = 1;
            this.label3.Text = "Status: Wating to scan...";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qrInstructions
            // 
            this.qrInstructions.ColumnCount = 1;
            this.qrInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.qrInstructions.Controls.Add(this.qrInstruction1, 0, 1);
            this.qrInstructions.Controls.Add(this.qrInstruction2, 0, 2);
            this.qrInstructions.Controls.Add(this.qrInstruction3, 0, 3);
            this.qrInstructions.Controls.Add(this.qrInstruction4, 0, 4);
            this.qrInstructions.Controls.Add(this.qrInstruction5, 0, 5);
            this.qrInstructions.Dock = System.Windows.Forms.DockStyle.Left;
            this.qrInstructions.Location = new System.Drawing.Point(0, 81);
            this.qrInstructions.Margin = new System.Windows.Forms.Padding(2);
            this.qrInstructions.Name = "qrInstructions";
            this.qrInstructions.RowCount = 10;
            this.qrInstructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.qrInstructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.qrInstructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.qrInstructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.qrInstructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.qrInstructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.qrInstructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.qrInstructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.qrInstructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.qrInstructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.qrInstructions.Size = new System.Drawing.Size(401, 567);
            this.qrInstructions.TabIndex = 1;
            // 
            // qrInstruction1
            // 
            this.qrInstruction1.AutoSize = true;
            this.qrInstruction1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrInstruction1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrInstruction1.Location = new System.Drawing.Point(2, 103);
            this.qrInstruction1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.qrInstruction1.Name = "qrInstruction1";
            this.qrInstruction1.Size = new System.Drawing.Size(397, 51);
            this.qrInstruction1.TabIndex = 0;
            this.qrInstruction1.Text = "1. Open your phone camera  ";
            this.qrInstruction1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qrInstruction2
            // 
            this.qrInstruction2.AutoSize = true;
            this.qrInstruction2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrInstruction2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrInstruction2.Location = new System.Drawing.Point(2, 154);
            this.qrInstruction2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.qrInstruction2.Name = "qrInstruction2";
            this.qrInstruction2.Size = new System.Drawing.Size(397, 51);
            this.qrInstruction2.TabIndex = 1;
            this.qrInstruction2.Text = "2. Scan the QR code on screen ";
            this.qrInstruction2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qrInstruction3
            // 
            this.qrInstruction3.AutoSize = true;
            this.qrInstruction3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrInstruction3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrInstruction3.Location = new System.Drawing.Point(2, 205);
            this.qrInstruction3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.qrInstruction3.Name = "qrInstruction3";
            this.qrInstruction3.Size = new System.Drawing.Size(397, 51);
            this.qrInstruction3.TabIndex = 2;
            this.qrInstruction3.Text = "3. Open the link shown on your phone  ";
            this.qrInstruction3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qrInstruction4
            // 
            this.qrInstruction4.AutoSize = true;
            this.qrInstruction4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrInstruction4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrInstruction4.Location = new System.Drawing.Point(2, 256);
            this.qrInstruction4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.qrInstruction4.Name = "qrInstruction4";
            this.qrInstruction4.Size = new System.Drawing.Size(397, 51);
            this.qrInstruction4.TabIndex = 3;
            this.qrInstruction4.Text = "4. Select your file and upload  ";
            this.qrInstruction4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qrInstruction5
            // 
            this.qrInstruction5.AutoSize = true;
            this.qrInstruction5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrInstruction5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrInstruction5.Location = new System.Drawing.Point(2, 307);
            this.qrInstruction5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.qrInstruction5.Name = "qrInstruction5";
            this.qrInstruction5.Size = new System.Drawing.Size(397, 51);
            this.qrInstruction5.TabIndex = 4;
            this.qrInstruction5.Text = "5. Wait for confirmation";
            this.qrInstruction5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qrTitleLayout
            // 
            this.qrTitleLayout.ColumnCount = 3;
            this.qrTitleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.qrTitleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.qrTitleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.qrTitleLayout.Controls.Add(this.qrTitle, 1, 0);
            this.qrTitleLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.qrTitleLayout.Location = new System.Drawing.Point(0, 0);
            this.qrTitleLayout.Margin = new System.Windows.Forms.Padding(2);
            this.qrTitleLayout.Name = "qrTitleLayout";
            this.qrTitleLayout.RowCount = 1;
            this.qrTitleLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.qrTitleLayout.Size = new System.Drawing.Size(1488, 81);
            this.qrTitleLayout.TabIndex = 0;
            // 
            // qrTitle
            // 
            this.qrTitle.AutoSize = true;
            this.qrTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.qrTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrTitle.Location = new System.Drawing.Point(150, 0);
            this.qrTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.qrTitle.Name = "qrTitle";
            this.qrTitle.Size = new System.Drawing.Size(1186, 73);
            this.qrTitle.TabIndex = 0;
            this.qrTitle.Text = "QR CODE UPLOAD";
            this.qrTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uploadBottom
            // 
            this.uploadBottom.ColumnCount = 1;
            this.uploadBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadBottom.Controls.Add(this.tableLayoutPanel11, 0, 0);
            this.uploadBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uploadBottom.Location = new System.Drawing.Point(0, 648);
            this.uploadBottom.Margin = new System.Windows.Forms.Padding(2);
            this.uploadBottom.Name = "uploadBottom";
            this.uploadBottom.RowCount = 1;
            this.uploadBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadBottom.Size = new System.Drawing.Size(1488, 81);
            this.uploadBottom.TabIndex = 1;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 5;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel11.Controls.Add(this.uploadCancelBtn, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.retrievalBtn, 3, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(1482, 75);
            this.tableLayoutPanel11.TabIndex = 0;
            // 
            // uploadCancelBtn
            // 
            this.uploadCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadCancelBtn.Location = new System.Drawing.Point(188, 3);
            this.uploadCancelBtn.Name = "uploadCancelBtn";
            this.uploadCancelBtn.Size = new System.Drawing.Size(457, 69);
            this.uploadCancelBtn.TabIndex = 1;
            this.uploadCancelBtn.Text = "CANCEL";
            this.uploadCancelBtn.UseVisualStyleBackColor = true;
            this.uploadCancelBtn.Click += new System.EventHandler(this.uploadCancelBtn_Click);
            // 
            // retrievalBtn
            // 
            this.retrievalBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retrievalBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retrievalBtn.Location = new System.Drawing.Point(836, 3);
            this.retrievalBtn.Name = "retrievalBtn";
            this.retrievalBtn.Size = new System.Drawing.Size(457, 69);
            this.retrievalBtn.TabIndex = 0;
            this.retrievalBtn.Text = "RETRIEVE FILE";
            this.retrievalBtn.UseVisualStyleBackColor = true;
            this.retrievalBtn.Click += new System.EventHandler(this.retrieveBtn_click);
            // 
            // continuePanel
            // 
            this.continuePanel.ColumnCount = 3;
            this.continuePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.continuePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.continuePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.continuePanel.Controls.Add(this.continueBtn, 1, 1);
            this.continuePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continuePanel.Location = new System.Drawing.Point(0, 0);
            this.continuePanel.Margin = new System.Windows.Forms.Padding(2);
            this.continuePanel.Name = "continuePanel";
            this.continuePanel.RowCount = 3;
            this.continuePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.continuePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.continuePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.continuePanel.Size = new System.Drawing.Size(1488, 729);
            this.continuePanel.TabIndex = 7;
            // 
            // continueBtn
            // 
            this.continueBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueBtn.Location = new System.Drawing.Point(498, 245);
            this.continueBtn.Margin = new System.Windows.Forms.Padding(2);
            this.continueBtn.Name = "continueBtn";
            this.continueBtn.Size = new System.Drawing.Size(492, 239);
            this.continueBtn.TabIndex = 0;
            this.continueBtn.Text = "CONTINUE";
            this.continueBtn.UseVisualStyleBackColor = true;
            this.continueBtn.Click += new System.EventHandler(this.continueBtn_Click);
            // 
            // printingSettingsPanel
            // 
            this.printingSettingsPanel.Controls.Add(this.settingsPanel);
            this.printingSettingsPanel.Controls.Add(this.paymentPanel);
            this.printingSettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printingSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.printingSettingsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.printingSettingsPanel.Name = "printingSettingsPanel";
            this.printingSettingsPanel.Size = new System.Drawing.Size(1488, 729);
            this.printingSettingsPanel.TabIndex = 2;
            // 
            // settingsPanel
            // 
            this.settingsPanel.Controls.Add(this.tableLayoutPanel2);
            this.settingsPanel.Controls.Add(this.tableLayoutPanel3);
            this.settingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsPanel.Location = new System.Drawing.Point(0, 0);
            this.settingsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(1488, 729);
            this.settingsPanel.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.printSettingsPanelLayout, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.filePreviewPanel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 642F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1488, 642);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // printSettingsPanelLayout
            // 
            this.printSettingsPanelLayout.Controls.Add(this.panel1);
            this.printSettingsPanelLayout.Controls.Add(this.tableLayoutPanel12);
            this.printSettingsPanelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printSettingsPanelLayout.Location = new System.Drawing.Point(3, 3);
            this.printSettingsPanelLayout.Name = "printSettingsPanelLayout";
            this.printSettingsPanelLayout.Size = new System.Drawing.Size(738, 636);
            this.printSettingsPanelLayout.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 556);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.756757F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.05405F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.43243F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.756757F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel7, 2, 5);
            this.tableLayoutPanel4.Controls.Add(this.totalPagesLabel, 2, 10);
            this.tableLayoutPanel4.Controls.Add(this.totalPagesLabelLabel, 1, 10);
            this.tableLayoutPanel4.Controls.Add(this.totalLabel, 2, 13);
            this.tableLayoutPanel4.Controls.Add(this.copiesLabel, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.paperColor, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.selectPageLabel, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.copiesLayout, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.totalLabelLabel, 1, 13);
            this.tableLayoutPanel4.Controls.Add(this.printerStatusLabel, 2, 11);
            this.tableLayoutPanel4.Controls.Add(this.printerStatus, 1, 11);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 8);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 1, 5);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 15;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.515103F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.57552F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.57552F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.515104F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.57552F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.73929F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.515104F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.57552F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.14145F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.515103F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.57552F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.57552F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.515104F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.57552F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.515104F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(738, 556);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel7.Controls.Add(this.numericSinglePage, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.numericPageRange, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(450, 145);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(233, 120);
            this.tableLayoutPanel7.TabIndex = 3;
            // 
            // numericSinglePage
            // 
            this.numericSinglePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericSinglePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericSinglePage.Location = new System.Drawing.Point(2, 42);
            this.numericSinglePage.Margin = new System.Windows.Forms.Padding(2);
            this.numericSinglePage.Name = "numericSinglePage";
            this.numericSinglePage.Size = new System.Drawing.Size(159, 35);
            this.numericSinglePage.TabIndex = 1;
            this.numericSinglePage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericPageRange
            // 
            this.numericPageRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericPageRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericPageRange.Location = new System.Drawing.Point(2, 2);
            this.numericPageRange.Margin = new System.Windows.Forms.Padding(2);
            this.numericPageRange.Name = "numericPageRange";
            this.numericPageRange.Size = new System.Drawing.Size(159, 35);
            this.numericPageRange.TabIndex = 2;
            this.numericPageRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // totalPagesLabel
            // 
            this.totalPagesLabel.AutoSize = true;
            this.totalPagesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalPagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPagesLabel.Location = new System.Drawing.Point(449, 410);
            this.totalPagesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalPagesLabel.Name = "totalPagesLabel";
            this.totalPagesLabel.Size = new System.Drawing.Size(235, 42);
            this.totalPagesLabel.TabIndex = 5;
            this.totalPagesLabel.Text = "[TOTAL PAGES]";
            this.totalPagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // totalPagesLabelLabel
            // 
            this.totalPagesLabelLabel.AutoSize = true;
            this.totalPagesLabelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalPagesLabelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPagesLabelLabel.Location = new System.Drawing.Point(51, 410);
            this.totalPagesLabelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalPagesLabelLabel.Name = "totalPagesLabelLabel";
            this.totalPagesLabelLabel.Size = new System.Drawing.Size(394, 42);
            this.totalPagesLabelLabel.TabIndex = 2;
            this.totalPagesLabelLabel.Text = "TOTAL PAGES";
            this.totalPagesLabelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(449, 502);
            this.totalLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(235, 42);
            this.totalLabel.TabIndex = 6;
            this.totalLabel.Text = "[TOTAL]";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // copiesLabel
            // 
            this.copiesLabel.AutoSize = true;
            this.copiesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copiesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copiesLabel.Location = new System.Drawing.Point(51, 8);
            this.copiesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.copiesLabel.Name = "copiesLabel";
            this.copiesLabel.Size = new System.Drawing.Size(394, 42);
            this.copiesLabel.TabIndex = 0;
            this.copiesLabel.Text = "COPIES";
            this.copiesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // paperColor
            // 
            this.paperColor.AutoSize = true;
            this.paperColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paperColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paperColor.Location = new System.Drawing.Point(51, 276);
            this.paperColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.paperColor.Name = "paperColor";
            this.paperColor.Size = new System.Drawing.Size(394, 42);
            this.paperColor.TabIndex = 8;
            this.paperColor.Text = "PRINT TYPE";
            this.paperColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selectPageLabel
            // 
            this.selectPageLabel.AutoSize = true;
            this.selectPageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPageLabel.Location = new System.Drawing.Point(51, 100);
            this.selectPageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectPageLabel.Name = "selectPageLabel";
            this.selectPageLabel.Size = new System.Drawing.Size(394, 42);
            this.selectPageLabel.TabIndex = 1;
            this.selectPageLabel.Text = "SELECT PAGE";
            this.selectPageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // copiesLayout
            // 
            this.copiesLayout.ColumnCount = 2;
            this.copiesLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.copiesLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.copiesLayout.Controls.Add(this.numericCopies, 1, 0);
            this.copiesLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copiesLayout.Location = new System.Drawing.Point(52, 53);
            this.copiesLayout.Name = "copiesLayout";
            this.copiesLayout.RowCount = 1;
            this.copiesLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.copiesLayout.Size = new System.Drawing.Size(392, 36);
            this.copiesLayout.TabIndex = 5;
            // 
            // numericCopies
            // 
            this.numericCopies.BackColor = System.Drawing.SystemColors.Window;
            this.numericCopies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericCopies.Location = new System.Drawing.Point(119, 2);
            this.numericCopies.Margin = new System.Windows.Forms.Padding(2);
            this.numericCopies.Name = "numericCopies";
            this.numericCopies.Size = new System.Drawing.Size(271, 35);
            this.numericCopies.TabIndex = 0;
            this.numericCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // totalLabelLabel
            // 
            this.totalLabelLabel.AutoSize = true;
            this.totalLabelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalLabelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabelLabel.Location = new System.Drawing.Point(51, 502);
            this.totalLabelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalLabelLabel.Name = "totalLabelLabel";
            this.totalLabelLabel.Size = new System.Drawing.Size(394, 42);
            this.totalLabelLabel.TabIndex = 3;
            this.totalLabelLabel.Text = "TOTAL ";
            this.totalLabelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // printerStatusLabel
            // 
            this.printerStatusLabel.AutoSize = true;
            this.printerStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printerStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printerStatusLabel.Location = new System.Drawing.Point(450, 452);
            this.printerStatusLabel.Name = "printerStatusLabel";
            this.printerStatusLabel.Size = new System.Drawing.Size(233, 42);
            this.printerStatusLabel.TabIndex = 10;
            this.printerStatusLabel.Text = "[PRINTER STATUS]";
            this.printerStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // printerStatus
            // 
            this.printerStatus.AutoSize = true;
            this.printerStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printerStatus.Location = new System.Drawing.Point(52, 452);
            this.printerStatus.Name = "printerStatus";
            this.printerStatus.Size = new System.Drawing.Size(392, 42);
            this.printerStatus.TabIndex = 11;
            this.printerStatus.Text = "PRINTER STATUS";
            this.printerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel5.Controls.Add(this.radioColored, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.radioBlackWhite, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(52, 321);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(392, 78);
            this.tableLayoutPanel5.TabIndex = 12;
            // 
            // radioColored
            // 
            this.radioColored.AutoSize = true;
            this.radioColored.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioColored.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioColored.Location = new System.Drawing.Point(119, 41);
            this.radioColored.Margin = new System.Windows.Forms.Padding(2);
            this.radioColored.Name = "radioColored";
            this.radioColored.Size = new System.Drawing.Size(271, 35);
            this.radioColored.TabIndex = 1;
            this.radioColored.TabStop = true;
            this.radioColored.Text = "COLORED";
            this.radioColored.UseVisualStyleBackColor = true;
            // 
            // radioBlackWhite
            // 
            this.radioBlackWhite.AutoSize = true;
            this.radioBlackWhite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBlackWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBlackWhite.Location = new System.Drawing.Point(119, 2);
            this.radioBlackWhite.Margin = new System.Windows.Forms.Padding(2);
            this.radioBlackWhite.Name = "radioBlackWhite";
            this.radioBlackWhite.Size = new System.Drawing.Size(271, 35);
            this.radioBlackWhite.TabIndex = 0;
            this.radioBlackWhite.TabStop = true;
            this.radioBlackWhite.Text = "BLACK AND WHITE";
            this.radioBlackWhite.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel6.Controls.Add(this.radioSinglePage, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.radioPrintRange, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.radioPrintAll, 1, 2);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(52, 145);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(392, 120);
            this.tableLayoutPanel6.TabIndex = 13;
            // 
            // radioSinglePage
            // 
            this.radioSinglePage.AutoSize = true;
            this.radioSinglePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioSinglePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSinglePage.Location = new System.Drawing.Point(119, 42);
            this.radioSinglePage.Margin = new System.Windows.Forms.Padding(2);
            this.radioSinglePage.Name = "radioSinglePage";
            this.radioSinglePage.Size = new System.Drawing.Size(271, 36);
            this.radioSinglePage.TabIndex = 1;
            this.radioSinglePage.TabStop = true;
            this.radioSinglePage.Text = "SINGLE PAGE";
            this.radioSinglePage.UseVisualStyleBackColor = true;
            // 
            // radioPrintRange
            // 
            this.radioPrintRange.AutoSize = true;
            this.radioPrintRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioPrintRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPrintRange.Location = new System.Drawing.Point(119, 2);
            this.radioPrintRange.Margin = new System.Windows.Forms.Padding(2);
            this.radioPrintRange.Name = "radioPrintRange";
            this.radioPrintRange.Size = new System.Drawing.Size(271, 36);
            this.radioPrintRange.TabIndex = 0;
            this.radioPrintRange.TabStop = true;
            this.radioPrintRange.Text = "PRINT RANGE";
            this.radioPrintRange.UseVisualStyleBackColor = true;
            // 
            // radioPrintAll
            // 
            this.radioPrintAll.AutoSize = true;
            this.radioPrintAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPrintAll.Location = new System.Drawing.Point(119, 82);
            this.radioPrintAll.Margin = new System.Windows.Forms.Padding(2);
            this.radioPrintAll.Name = "radioPrintAll";
            this.radioPrintAll.Size = new System.Drawing.Size(238, 33);
            this.radioPrintAll.TabIndex = 2;
            this.radioPrintAll.TabStop = true;
            this.radioPrintAll.Text = "PRINT ALL PAGES";
            this.radioPrintAll.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 1;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 2;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(738, 80);
            this.tableLayoutPanel12.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(732, 72);
            this.label2.TabIndex = 0;
            this.label2.Text = "PRINT SETTINGS\r\n\r\n\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // filePreviewPanel
            // 
            this.filePreviewPanel.Controls.Add(this.tableLayoutPanel16);
            this.filePreviewPanel.Controls.Add(this.previewPanelSettingLayout);
            this.filePreviewPanel.Controls.Add(this.tableLayoutPanel10);
            this.filePreviewPanel.Controls.Add(this.tableLayoutPanel9);
            this.filePreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filePreviewPanel.Location = new System.Drawing.Point(746, 2);
            this.filePreviewPanel.Margin = new System.Windows.Forms.Padding(2);
            this.filePreviewPanel.Name = "filePreviewPanel";
            this.filePreviewPanel.Size = new System.Drawing.Size(740, 638);
            this.filePreviewPanel.TabIndex = 1;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 3;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel16.Controls.Add(this.fileNameLabel, 1, 1);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(0, 81);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 3;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(740, 32);
            this.tableLayoutPanel16.TabIndex = 3;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameLabel.Location = new System.Drawing.Point(151, 1);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(438, 28);
            this.fileNameLabel.TabIndex = 0;
            this.fileNameLabel.Text = "[FILE NAME]";
            this.fileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewPanelSettingLayout
            // 
            this.previewPanelSettingLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPanelSettingLayout.Location = new System.Drawing.Point(0, 81);
            this.previewPanelSettingLayout.Margin = new System.Windows.Forms.Padding(2);
            this.previewPanelSettingLayout.Name = "previewPanelSettingLayout";
            this.previewPanelSettingLayout.Size = new System.Drawing.Size(740, 476);
            this.previewPanelSettingLayout.TabIndex = 2;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 3;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.Controls.Add(this.editBtn, 1, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 557);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 3;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(740, 81);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // editBtn
            // 
            this.editBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Location = new System.Drawing.Point(187, 6);
            this.editBtn.Margin = new System.Windows.Forms.Padding(2);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(366, 68);
            this.editBtn.TabIndex = 0;
            this.editBtn.Text = "EDIT";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.labelPreview, 0, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(740, 81);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreview.Location = new System.Drawing.Point(2, 8);
            this.labelPreview.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(736, 73);
            this.labelPreview.TabIndex = 0;
            this.labelPreview.Text = "FILE PREVIEW";
            this.labelPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.753652F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.09222F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.030742F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.09222F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.753632F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.58404F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.69349F));
            this.tableLayoutPanel3.Controls.Add(this.continuePaymentBtn, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.settingsBackBtn, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.printSettingsCancelBtn, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 642);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.599224F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.80154F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.599224F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1488, 87);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // continuePaymentBtn
            // 
            this.continuePaymentBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continuePaymentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continuePaymentBtn.Location = new System.Drawing.Point(962, 10);
            this.continuePaymentBtn.Margin = new System.Windows.Forms.Padding(2);
            this.continuePaymentBtn.Name = "continuePaymentBtn";
            this.continuePaymentBtn.Size = new System.Drawing.Size(317, 66);
            this.continuePaymentBtn.TabIndex = 0;
            this.continuePaymentBtn.Text = "CONTINUE";
            this.continuePaymentBtn.UseVisualStyleBackColor = true;
            this.continuePaymentBtn.Click += new System.EventHandler(this.proceedBtn_Click);
            // 
            // settingsBackBtn
            // 
            this.settingsBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsBackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsBackBtn.Location = new System.Drawing.Point(504, 10);
            this.settingsBackBtn.Margin = new System.Windows.Forms.Padding(2);
            this.settingsBackBtn.Name = "settingsBackBtn";
            this.settingsBackBtn.Size = new System.Drawing.Size(309, 66);
            this.settingsBackBtn.TabIndex = 1;
            this.settingsBackBtn.TabStop = false;
            this.settingsBackBtn.Text = "BACK";
            this.settingsBackBtn.UseVisualStyleBackColor = true;
            // 
            // printSettingsCancelBtn
            // 
            this.printSettingsCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printSettingsCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printSettingsCancelBtn.Location = new System.Drawing.Point(88, 11);
            this.printSettingsCancelBtn.Name = "printSettingsCancelBtn";
            this.printSettingsCancelBtn.Size = new System.Drawing.Size(307, 64);
            this.printSettingsCancelBtn.TabIndex = 2;
            this.printSettingsCancelBtn.Text = "CANCEL";
            this.printSettingsCancelBtn.UseVisualStyleBackColor = true;
            this.printSettingsCancelBtn.Click += new System.EventHandler(this.printSettingsCancelBtn_Click);
            // 
            // paymentPanel
            // 
            this.paymentPanel.Controls.Add(this.panel2);
            this.paymentPanel.Controls.Add(this.tableLayoutPanel17);
            this.paymentPanel.Controls.Add(this.paymentTableTitle);
            this.paymentPanel.Controls.Add(this.paymentRight);
            this.paymentPanel.Controls.Add(this.paymentLeft);
            this.paymentPanel.Controls.Add(this.paymentBottom);
            this.paymentPanel.Controls.Add(this.paymentTop);
            this.paymentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentPanel.Location = new System.Drawing.Point(0, 0);
            this.paymentPanel.Margin = new System.Windows.Forms.Padding(2);
            this.paymentPanel.Name = "paymentPanel";
            this.paymentPanel.Size = new System.Drawing.Size(1488, 729);
            this.paymentPanel.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPayment);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(150, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1188, 386);
            this.panel2.TabIndex = 11;
            // 
            // tableLayoutPayment
            // 
            this.tableLayoutPayment.ColumnCount = 3;
            this.tableLayoutPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.81168F));
            this.tableLayoutPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.37665F));
            this.tableLayoutPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.81168F));
            this.tableLayoutPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPayment.Controls.Add(this.btn20, 2, 3);
            this.tableLayoutPayment.Controls.Add(this.btn10, 2, 2);
            this.tableLayoutPayment.Controls.Add(this.btn5, 2, 1);
            this.tableLayoutPayment.Controls.Add(this.totalPayment, 1, 2);
            this.tableLayoutPayment.Controls.Add(this.paymentTotalLabel, 1, 1);
            this.tableLayoutPayment.Controls.Add(this.paymentBalance, 1, 5);
            this.tableLayoutPayment.Controls.Add(this.balancePaymentLabel, 1, 4);
            this.tableLayoutPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPayment.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPayment.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPayment.Name = "tableLayoutPayment";
            this.tableLayoutPayment.RowCount = 7;
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPayment.Size = new System.Drawing.Size(1188, 386);
            this.tableLayoutPayment.TabIndex = 5;
            // 
            // btn20
            // 
            this.btn20.AccessibleName = "";
            this.btn20.Location = new System.Drawing.Point(977, 167);
            this.btn20.Margin = new System.Windows.Forms.Padding(2);
            this.btn20.Name = "btn20";
            this.btn20.Size = new System.Drawing.Size(56, 19);
            this.btn20.TabIndex = 8;
            this.btn20.Text = "20";
            this.btn20.UseVisualStyleBackColor = true;
            this.btn20.Click += new System.EventHandler(this.btn20_Click);
            // 
            // btn10
            // 
            this.btn10.Location = new System.Drawing.Point(977, 112);
            this.btn10.Margin = new System.Windows.Forms.Padding(2);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(56, 19);
            this.btn10.TabIndex = 7;
            this.btn10.Text = "10";
            this.btn10.UseVisualStyleBackColor = true;
            this.btn10.Click += new System.EventHandler(this.btn10_Click);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(977, 57);
            this.btn5.Margin = new System.Windows.Forms.Padding(2);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(56, 19);
            this.btn5.TabIndex = 6;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // totalPayment
            // 
            this.totalPayment.AutoSize = true;
            this.totalPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPayment.Location = new System.Drawing.Point(213, 110);
            this.totalPayment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalPayment.Name = "totalPayment";
            this.totalPayment.Size = new System.Drawing.Size(760, 55);
            this.totalPayment.TabIndex = 4;
            this.totalPayment.Text = "[Total Payment]";
            this.totalPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paymentTotalLabel
            // 
            this.paymentTotalLabel.AutoSize = true;
            this.paymentTotalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentTotalLabel.Location = new System.Drawing.Point(213, 55);
            this.paymentTotalLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.paymentTotalLabel.Name = "paymentTotalLabel";
            this.paymentTotalLabel.Size = new System.Drawing.Size(760, 55);
            this.paymentTotalLabel.TabIndex = 0;
            this.paymentTotalLabel.Text = "TOTAL";
            this.paymentTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paymentBalance
            // 
            this.paymentBalance.AutoSize = true;
            this.paymentBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentBalance.Location = new System.Drawing.Point(213, 275);
            this.paymentBalance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.paymentBalance.Name = "paymentBalance";
            this.paymentBalance.Size = new System.Drawing.Size(760, 55);
            this.paymentBalance.TabIndex = 5;
            this.paymentBalance.Text = "[Payment Balance]";
            this.paymentBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // balancePaymentLabel
            // 
            this.balancePaymentLabel.AutoSize = true;
            this.balancePaymentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.balancePaymentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balancePaymentLabel.Location = new System.Drawing.Point(213, 220);
            this.balancePaymentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.balancePaymentLabel.Name = "balancePaymentLabel";
            this.balancePaymentLabel.Size = new System.Drawing.Size(760, 55);
            this.balancePaymentLabel.TabIndex = 1;
            this.balancePaymentLabel.Text = "BALANCE ";
            this.balancePaymentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 7;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.433962F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.75472F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.433962F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.75472F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.433962F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.75472F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.433962F));
            this.tableLayoutPanel17.Controls.Add(this.cancelPrintBtn, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.paymentBackBtn, 3, 0);
            this.tableLayoutPanel17.Controls.Add(this.printBtn, 5, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(150, 548);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 1;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(1188, 100);
            this.tableLayoutPanel17.TabIndex = 10;
            // 
            // cancelPrintBtn
            // 
            this.cancelPrintBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelPrintBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelPrintBtn.Location = new System.Drawing.Point(114, 2);
            this.cancelPrintBtn.Margin = new System.Windows.Forms.Padding(2);
            this.cancelPrintBtn.Name = "cancelPrintBtn";
            this.cancelPrintBtn.Size = new System.Drawing.Size(242, 96);
            this.cancelPrintBtn.TabIndex = 2;
            this.cancelPrintBtn.Text = "CANCEL";
            this.cancelPrintBtn.UseVisualStyleBackColor = true;
            this.cancelPrintBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // paymentBackBtn
            // 
            this.paymentBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentBackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentBackBtn.Location = new System.Drawing.Point(473, 3);
            this.paymentBackBtn.Name = "paymentBackBtn";
            this.paymentBackBtn.Size = new System.Drawing.Size(240, 94);
            this.paymentBackBtn.TabIndex = 9;
            this.paymentBackBtn.Text = "BACK";
            this.paymentBackBtn.UseVisualStyleBackColor = true;
            this.paymentBackBtn.Click += new System.EventHandler(this.paymentBackBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtn.Location = new System.Drawing.Point(830, 2);
            this.printBtn.Margin = new System.Windows.Forms.Padding(2);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(242, 96);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "PRINT";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // paymentTableTitle
            // 
            this.paymentTableTitle.ColumnCount = 1;
            this.paymentTableTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentTableTitle.Controls.Add(this.paymentTitle, 0, 0);
            this.paymentTableTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.paymentTableTitle.Location = new System.Drawing.Point(150, 81);
            this.paymentTableTitle.Margin = new System.Windows.Forms.Padding(2);
            this.paymentTableTitle.Name = "paymentTableTitle";
            this.paymentTableTitle.RowCount = 1;
            this.paymentTableTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentTableTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.paymentTableTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.paymentTableTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.paymentTableTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.paymentTableTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.paymentTableTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.paymentTableTitle.Size = new System.Drawing.Size(1188, 81);
            this.paymentTableTitle.TabIndex = 4;
            // 
            // paymentTitle
            // 
            this.paymentTitle.AutoSize = true;
            this.paymentTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentTitle.Location = new System.Drawing.Point(2, 0);
            this.paymentTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.paymentTitle.Name = "paymentTitle";
            this.paymentTitle.Size = new System.Drawing.Size(1184, 81);
            this.paymentTitle.TabIndex = 0;
            this.paymentTitle.Text = "PAYMENT";
            this.paymentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paymentRight
            // 
            this.paymentRight.ColumnCount = 1;
            this.paymentRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.paymentRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.paymentRight.Location = new System.Drawing.Point(1338, 81);
            this.paymentRight.Margin = new System.Windows.Forms.Padding(2);
            this.paymentRight.Name = "paymentRight";
            this.paymentRight.RowCount = 1;
            this.paymentRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 567F));
            this.paymentRight.Size = new System.Drawing.Size(150, 567);
            this.paymentRight.TabIndex = 3;
            // 
            // paymentLeft
            // 
            this.paymentLeft.ColumnCount = 1;
            this.paymentLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.paymentLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.paymentLeft.Location = new System.Drawing.Point(0, 81);
            this.paymentLeft.Margin = new System.Windows.Forms.Padding(2);
            this.paymentLeft.Name = "paymentLeft";
            this.paymentLeft.RowCount = 1;
            this.paymentLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 567F));
            this.paymentLeft.Size = new System.Drawing.Size(150, 567);
            this.paymentLeft.TabIndex = 2;
            // 
            // paymentBottom
            // 
            this.paymentBottom.ColumnCount = 1;
            this.paymentBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.paymentBottom.Controls.Add(this.printingStatusLabel, 0, 0);
            this.paymentBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paymentBottom.Location = new System.Drawing.Point(0, 648);
            this.paymentBottom.Margin = new System.Windows.Forms.Padding(2);
            this.paymentBottom.Name = "paymentBottom";
            this.paymentBottom.RowCount = 1;
            this.paymentBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.paymentBottom.Size = new System.Drawing.Size(1488, 81);
            this.paymentBottom.TabIndex = 1;
            // 
            // printingStatusLabel
            // 
            this.printingStatusLabel.AutoSize = true;
            this.printingStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printingStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printingStatusLabel.Location = new System.Drawing.Point(2, 0);
            this.printingStatusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.printingStatusLabel.Name = "printingStatusLabel";
            this.printingStatusLabel.Size = new System.Drawing.Size(1484, 81);
            this.printingStatusLabel.TabIndex = 0;
            this.printingStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paymentTop
            // 
            this.paymentTop.ColumnCount = 1;
            this.paymentTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.paymentTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paymentTop.Location = new System.Drawing.Point(0, 0);
            this.paymentTop.Margin = new System.Windows.Forms.Padding(2);
            this.paymentTop.Name = "paymentTop";
            this.paymentTop.RowCount = 1;
            this.paymentTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.paymentTop.Size = new System.Drawing.Size(1488, 81);
            this.paymentTop.TabIndex = 0;
            // 
            // retrivalPanel
            // 
            this.retrivalPanel.Controls.Add(this.buttonsLayout);
            this.retrivalPanel.Controls.Add(this.retrivalMain);
            this.retrivalPanel.Controls.Add(this.retrivalLeft);
            this.retrivalPanel.Controls.Add(this.retrivalRight);
            this.retrivalPanel.Controls.Add(this.retrivalBottom);
            this.retrivalPanel.Controls.Add(this.retrivalTop);
            this.retrivalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retrivalPanel.Location = new System.Drawing.Point(0, 0);
            this.retrivalPanel.Margin = new System.Windows.Forms.Padding(2);
            this.retrivalPanel.Name = "retrivalPanel";
            this.retrivalPanel.Size = new System.Drawing.Size(1488, 729);
            this.retrivalPanel.TabIndex = 1;
            // 
            // buttonsLayout
            // 
            this.buttonsLayout.ColumnCount = 3;
            this.buttonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.20928F));
            this.buttonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.58143F));
            this.buttonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.20928F));
            this.buttonsLayout.Controls.Add(this.loadRetrievalBtn, 1, 1);
            this.buttonsLayout.Controls.Add(this.retrieveCancelBtn, 1, 3);
            this.buttonsLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsLayout.Location = new System.Drawing.Point(150, 430);
            this.buttonsLayout.Name = "buttonsLayout";
            this.buttonsLayout.RowCount = 5;
            this.buttonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.003002F));
            this.buttonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.04805F));
            this.buttonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.003002F));
            this.buttonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.24324F));
            this.buttonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.702703F));
            this.buttonsLayout.Size = new System.Drawing.Size(1188, 218);
            this.buttonsLayout.TabIndex = 5;
            // 
            // loadRetrievalBtn
            // 
            this.loadRetrievalBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadRetrievalBtn.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadRetrievalBtn.Location = new System.Drawing.Point(289, 8);
            this.loadRetrievalBtn.Margin = new System.Windows.Forms.Padding(2);
            this.loadRetrievalBtn.Name = "loadRetrievalBtn";
            this.loadRetrievalBtn.Size = new System.Drawing.Size(608, 100);
            this.loadRetrievalBtn.TabIndex = 2;
            this.loadRetrievalBtn.Text = "RETRIEVE FILE";
            this.loadRetrievalBtn.UseVisualStyleBackColor = true;
            this.loadRetrievalBtn.Click += new System.EventHandler(this.loadRetrievalBtn_Click);
            // 
            // retrieveCancelBtn
            // 
            this.retrieveCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retrieveCancelBtn.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retrieveCancelBtn.Location = new System.Drawing.Point(289, 118);
            this.retrieveCancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.retrieveCancelBtn.Name = "retrieveCancelBtn";
            this.retrieveCancelBtn.Size = new System.Drawing.Size(608, 90);
            this.retrieveCancelBtn.TabIndex = 3;
            this.retrieveCancelBtn.Text = "CANCEL";
            this.retrieveCancelBtn.UseVisualStyleBackColor = true;
            this.retrieveCancelBtn.Click += new System.EventHandler(this.retrieveCancelBtn_Click);
            // 
            // retrivalMain
            // 
            this.retrivalMain.ColumnCount = 3;
            this.retrivalMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.69052F));
            this.retrivalMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.61897F));
            this.retrivalMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.69051F));
            this.retrivalMain.Controls.Add(this.retrivalCodeTextBox, 1, 3);
            this.retrivalMain.Controls.Add(this.retrivalCodeLabel, 1, 1);
            this.retrivalMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.retrivalMain.Location = new System.Drawing.Point(150, 81);
            this.retrivalMain.Margin = new System.Windows.Forms.Padding(2);
            this.retrivalMain.Name = "retrivalMain";
            this.retrivalMain.RowCount = 4;
            this.retrivalMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.97805F));
            this.retrivalMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.97804F));
            this.retrivalMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.535451F));
            this.retrivalMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.50846F));
            this.retrivalMain.Size = new System.Drawing.Size(1188, 400);
            this.retrivalMain.TabIndex = 4;
            // 
            // retrivalCodeTextBox
            // 
            this.retrivalCodeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.retrivalCodeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retrivalCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retrivalCodeTextBox.Location = new System.Drawing.Point(152, 234);
            this.retrivalCodeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.retrivalCodeTextBox.Name = "retrivalCodeTextBox";
            this.retrivalCodeTextBox.Size = new System.Drawing.Size(882, 116);
            this.retrivalCodeTextBox.TabIndex = 0;
            this.retrivalCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // retrivalCodeLabel
            // 
            this.retrivalCodeLabel.AutoSize = true;
            this.retrivalCodeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retrivalCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retrivalCodeLabel.Location = new System.Drawing.Point(152, 103);
            this.retrivalCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.retrivalCodeLabel.Name = "retrivalCodeLabel";
            this.retrivalCodeLabel.Size = new System.Drawing.Size(882, 103);
            this.retrivalCodeLabel.TabIndex = 1;
            this.retrivalCodeLabel.Text = "ENTER RETRIEVAL CODE";
            this.retrivalCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // retrivalLeft
            // 
            this.retrivalLeft.ColumnCount = 1;
            this.retrivalLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.retrivalLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.retrivalLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.retrivalLeft.Location = new System.Drawing.Point(0, 81);
            this.retrivalLeft.Margin = new System.Windows.Forms.Padding(2);
            this.retrivalLeft.Name = "retrivalLeft";
            this.retrivalLeft.RowCount = 1;
            this.retrivalLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.retrivalLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 567F));
            this.retrivalLeft.Size = new System.Drawing.Size(150, 567);
            this.retrivalLeft.TabIndex = 3;
            // 
            // retrivalRight
            // 
            this.retrivalRight.ColumnCount = 1;
            this.retrivalRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.retrivalRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.retrivalRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.retrivalRight.Location = new System.Drawing.Point(1338, 81);
            this.retrivalRight.Margin = new System.Windows.Forms.Padding(2);
            this.retrivalRight.Name = "retrivalRight";
            this.retrivalRight.RowCount = 1;
            this.retrivalRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.retrivalRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 567F));
            this.retrivalRight.Size = new System.Drawing.Size(150, 567);
            this.retrivalRight.TabIndex = 2;
            // 
            // retrivalBottom
            // 
            this.retrivalBottom.ColumnCount = 1;
            this.retrivalBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.retrivalBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.retrivalBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.retrivalBottom.Location = new System.Drawing.Point(0, 648);
            this.retrivalBottom.Margin = new System.Windows.Forms.Padding(2);
            this.retrivalBottom.Name = "retrivalBottom";
            this.retrivalBottom.RowCount = 1;
            this.retrivalBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.retrivalBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.retrivalBottom.Size = new System.Drawing.Size(1488, 81);
            this.retrivalBottom.TabIndex = 1;
            // 
            // retrivalTop
            // 
            this.retrivalTop.ColumnCount = 1;
            this.retrivalTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.retrivalTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.retrivalTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.retrivalTop.Location = new System.Drawing.Point(0, 0);
            this.retrivalTop.Margin = new System.Windows.Forms.Padding(2);
            this.retrivalTop.Name = "retrivalTop";
            this.retrivalTop.RowCount = 1;
            this.retrivalTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.retrivalTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.retrivalTop.Size = new System.Drawing.Size(1488, 81);
            this.retrivalTop.TabIndex = 0;
            // 
            // printingOptionsPanel
            // 
            this.printingOptionsPanel.Controls.Add(this.printingPanelTitle);
            this.printingOptionsPanel.Controls.Add(this.MainPrintingPanel);
            this.printingOptionsPanel.Controls.Add(this.printingPanelLeft);
            this.printingOptionsPanel.Controls.Add(this.printingPanelRight);
            this.printingOptionsPanel.Controls.Add(this.printingPanelBottom);
            this.printingOptionsPanel.Controls.Add(this.printingPanelTop);
            this.printingOptionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printingOptionsPanel.Location = new System.Drawing.Point(0, 0);
            this.printingOptionsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.printingOptionsPanel.Name = "printingOptionsPanel";
            this.printingOptionsPanel.Size = new System.Drawing.Size(1488, 729);
            this.printingOptionsPanel.TabIndex = 2;
            // 
            // printingPanelTitle
            // 
            this.printingPanelTitle.ColumnCount = 1;
            this.printingPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.printingPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.printingPanelTitle.Controls.Add(this.printingTitleLabel, 0, 0);
            this.printingPanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.printingPanelTitle.Location = new System.Drawing.Point(150, 81);
            this.printingPanelTitle.Name = "printingPanelTitle";
            this.printingPanelTitle.RowCount = 1;
            this.printingPanelTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.printingPanelTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.printingPanelTitle.Size = new System.Drawing.Size(1188, 100);
            this.printingPanelTitle.TabIndex = 5;
            // 
            // printingTitleLabel
            // 
            this.printingTitleLabel.AutoSize = true;
            this.printingTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printingTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printingTitleLabel.Location = new System.Drawing.Point(3, 0);
            this.printingTitleLabel.Name = "printingTitleLabel";
            this.printingTitleLabel.Size = new System.Drawing.Size(1182, 100);
            this.printingTitleLabel.TabIndex = 0;
            this.printingTitleLabel.Text = "PRINT AND SNAP";
            this.printingTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainPrintingPanel
            // 
            this.MainPrintingPanel.ColumnCount = 5;
            this.MainPrintingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.853643F));
            this.MainPrintingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.87626F));
            this.MainPrintingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.540201F));
            this.MainPrintingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.87626F));
            this.MainPrintingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.853643F));
            this.MainPrintingPanel.Controls.Add(this.docPrintingBtn, 1, 1);
            this.MainPrintingPanel.Controls.Add(this.photoPrintingBtn, 3, 1);
            this.MainPrintingPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainPrintingPanel.Location = new System.Drawing.Point(150, 183);
            this.MainPrintingPanel.Name = "MainPrintingPanel";
            this.MainPrintingPanel.RowCount = 3;
            this.MainPrintingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.947441F));
            this.MainPrintingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.1563F));
            this.MainPrintingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.89626F));
            this.MainPrintingPanel.Size = new System.Drawing.Size(1188, 465);
            this.MainPrintingPanel.TabIndex = 4;
            // 
            // docPrintingBtn
            // 
            this.docPrintingBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docPrintingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.docPrintingBtn.Location = new System.Drawing.Point(72, 30);
            this.docPrintingBtn.Name = "docPrintingBtn";
            this.docPrintingBtn.Size = new System.Drawing.Size(479, 315);
            this.docPrintingBtn.TabIndex = 0;
            this.docPrintingBtn.Text = "DOCUMENT PRINTING\r\n(Print words or pdf files)\r\n";
            this.docPrintingBtn.UseVisualStyleBackColor = true;
            this.docPrintingBtn.Click += new System.EventHandler(this.docPrintingBtn_Click);
            // 
            // photoPrintingBtn
            // 
            this.photoPrintingBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoPrintingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoPrintingBtn.Location = new System.Drawing.Point(634, 30);
            this.photoPrintingBtn.Name = "photoPrintingBtn";
            this.photoPrintingBtn.Size = new System.Drawing.Size(479, 315);
            this.photoPrintingBtn.TabIndex = 1;
            this.photoPrintingBtn.Text = "PHOTO PRINTING\r\n(Take pictures and print photos)";
            this.photoPrintingBtn.UseVisualStyleBackColor = true;
            this.photoPrintingBtn.Click += new System.EventHandler(this.photoPrintingBtn_Click);
            // 
            // printingPanelLeft
            // 
            this.printingPanelLeft.ColumnCount = 1;
            this.printingPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.printingPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.printingPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.printingPanelLeft.Location = new System.Drawing.Point(0, 81);
            this.printingPanelLeft.Margin = new System.Windows.Forms.Padding(2);
            this.printingPanelLeft.Name = "printingPanelLeft";
            this.printingPanelLeft.RowCount = 1;
            this.printingPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.printingPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 567F));
            this.printingPanelLeft.Size = new System.Drawing.Size(150, 567);
            this.printingPanelLeft.TabIndex = 3;
            // 
            // printingPanelRight
            // 
            this.printingPanelRight.ColumnCount = 1;
            this.printingPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.printingPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.printingPanelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.printingPanelRight.Location = new System.Drawing.Point(1338, 81);
            this.printingPanelRight.Margin = new System.Windows.Forms.Padding(2);
            this.printingPanelRight.Name = "printingPanelRight";
            this.printingPanelRight.RowCount = 1;
            this.printingPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.printingPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 567F));
            this.printingPanelRight.Size = new System.Drawing.Size(150, 567);
            this.printingPanelRight.TabIndex = 2;
            // 
            // printingPanelBottom
            // 
            this.printingPanelBottom.ColumnCount = 1;
            this.printingPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.printingPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.printingPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.printingPanelBottom.Location = new System.Drawing.Point(0, 648);
            this.printingPanelBottom.Margin = new System.Windows.Forms.Padding(2);
            this.printingPanelBottom.Name = "printingPanelBottom";
            this.printingPanelBottom.RowCount = 1;
            this.printingPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.printingPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.printingPanelBottom.Size = new System.Drawing.Size(1488, 81);
            this.printingPanelBottom.TabIndex = 1;
            // 
            // printingPanelTop
            // 
            this.printingPanelTop.ColumnCount = 1;
            this.printingPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.printingPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.printingPanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.printingPanelTop.Location = new System.Drawing.Point(0, 0);
            this.printingPanelTop.Margin = new System.Windows.Forms.Padding(2);
            this.printingPanelTop.Name = "printingPanelTop";
            this.printingPanelTop.RowCount = 1;
            this.printingPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.printingPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.printingPanelTop.Size = new System.Drawing.Size(1488, 81);
            this.printingPanelTop.TabIndex = 0;
            // 
            // printPanel
            // 
            this.printPanel.Controls.Add(this.uploadPanel);
            this.printPanel.Controls.Add(this.printingSettingsPanel);
            this.printPanel.Controls.Add(this.continuePanel);
            this.printPanel.Controls.Add(this.retrivalPanel);
            this.printPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printPanel.Location = new System.Drawing.Point(0, 0);
            this.printPanel.Name = "printPanel";
            this.printPanel.Size = new System.Drawing.Size(1488, 729);
            this.printPanel.TabIndex = 0;
            // 
            // photoPanel
            // 
            this.photoPanel.Controls.Add(this.photoMode);
            this.photoPanel.Controls.Add(this.photoIDPanel);
            this.photoPanel.Controls.Add(this.photoBoothPanel);
            this.photoPanel.Controls.Add(this.retrievalPanelPhoto);
            this.photoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoPanel.Location = new System.Drawing.Point(0, 0);
            this.photoPanel.Name = "photoPanel";
            this.photoPanel.Size = new System.Drawing.Size(1488, 729);
            this.photoPanel.TabIndex = 0;
            // 
            // photoIDPanel
            // 
            this.photoIDPanel.Controls.Add(this.panelCRMidPrinting);
            this.photoIDPanel.Controls.Add(this.idPrintingSettings);
            this.photoIDPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoIDPanel.Location = new System.Drawing.Point(0, 0);
            this.photoIDPanel.Name = "photoIDPanel";
            this.photoIDPanel.Size = new System.Drawing.Size(1488, 729);
            this.photoIDPanel.TabIndex = 2;
            // 
            // idPrintingSettings
            // 
            this.idPrintingSettings.Controls.Add(this.IDsettings);
            this.idPrintingSettings.Controls.Add(this.IDpayment);
            this.idPrintingSettings.Controls.Add(this.softCopyDownloadId);
            this.idPrintingSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintingSettings.Location = new System.Drawing.Point(0, 0);
            this.idPrintingSettings.Name = "idPrintingSettings";
            this.idPrintingSettings.Size = new System.Drawing.Size(1488, 729);
            this.idPrintingSettings.TabIndex = 2;
            // 
            // IDpayment
            // 
            this.IDpayment.Controls.Add(this.panel4);
            this.IDpayment.Controls.Add(this.tableLayoutPanel52);
            this.IDpayment.Controls.Add(this.tableLayoutPanel51);
            this.IDpayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IDpayment.Location = new System.Drawing.Point(0, 0);
            this.IDpayment.Name = "IDpayment";
            this.IDpayment.Size = new System.Drawing.Size(1488, 729);
            this.IDpayment.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel47);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1488, 529);
            this.panel4.TabIndex = 6;
            // 
            // tableLayoutPanel47
            // 
            this.tableLayoutPanel47.ColumnCount = 1;
            this.tableLayoutPanel47.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel47.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel47.Controls.Add(this.tableLayoutPanel53, 0, 0);
            this.tableLayoutPanel47.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel47.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel47.Name = "tableLayoutPanel47";
            this.tableLayoutPanel47.RowCount = 1;
            this.tableLayoutPanel47.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel47.Size = new System.Drawing.Size(1488, 529);
            this.tableLayoutPanel47.TabIndex = 0;
            // 
            // tableLayoutPanel53
            // 
            this.tableLayoutPanel53.ColumnCount = 3;
            this.tableLayoutPanel53.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.81F));
            this.tableLayoutPanel53.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.38F));
            this.tableLayoutPanel53.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.81F));
            this.tableLayoutPanel53.Controls.Add(this.label25, 1, 1);
            this.tableLayoutPanel53.Controls.Add(this.paymentIDprintingTotal, 1, 2);
            this.tableLayoutPanel53.Controls.Add(this.label27, 1, 4);
            this.tableLayoutPanel53.Controls.Add(this.paymentIDprintingBalance, 1, 5);
            this.tableLayoutPanel53.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel53.Controls.Add(this.button2, 2, 1);
            this.tableLayoutPanel53.Controls.Add(this.button3, 2, 2);
            this.tableLayoutPanel53.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel53.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel53.Name = "tableLayoutPanel53";
            this.tableLayoutPanel53.RowCount = 7;
            this.tableLayoutPanel53.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel53.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel53.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel53.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel53.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel53.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel53.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel53.Size = new System.Drawing.Size(1482, 523);
            this.tableLayoutPanel53.TabIndex = 6;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(266, 74);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(948, 74);
            this.label25.TabIndex = 0;
            this.label25.Text = "TOTAL";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paymentIDprintingTotal
            // 
            this.paymentIDprintingTotal.AutoSize = true;
            this.paymentIDprintingTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentIDprintingTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentIDprintingTotal.Location = new System.Drawing.Point(266, 148);
            this.paymentIDprintingTotal.Name = "paymentIDprintingTotal";
            this.paymentIDprintingTotal.Size = new System.Drawing.Size(948, 74);
            this.paymentIDprintingTotal.TabIndex = 1;
            this.paymentIDprintingTotal.Text = "[TOTAL PAYMENT]";
            this.paymentIDprintingTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(266, 296);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(948, 74);
            this.label27.TabIndex = 2;
            this.label27.Text = "BALANCE";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paymentIDprintingBalance
            // 
            this.paymentIDprintingBalance.AutoSize = true;
            this.paymentIDprintingBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentIDprintingBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentIDprintingBalance.Location = new System.Drawing.Point(266, 370);
            this.paymentIDprintingBalance.Name = "paymentIDprintingBalance";
            this.paymentIDprintingBalance.Size = new System.Drawing.Size(948, 74);
            this.paymentIDprintingBalance.TabIndex = 3;
            this.paymentIDprintingBalance.Text = "[BALANCE]";
            this.paymentIDprintingBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel52
            // 
            this.tableLayoutPanel52.ColumnCount = 9;
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel52.Controls.Add(this.cancelBtnPaymentId, 1, 0);
            this.tableLayoutPanel52.Controls.Add(this.backBtnPaymentId, 3, 0);
            this.tableLayoutPanel52.Controls.Add(this.printBtnPaymentId, 7, 0);
            this.tableLayoutPanel52.Controls.Add(this.downloadBtnPaymentId, 5, 0);
            this.tableLayoutPanel52.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel52.Location = new System.Drawing.Point(0, 629);
            this.tableLayoutPanel52.Name = "tableLayoutPanel52";
            this.tableLayoutPanel52.RowCount = 1;
            this.tableLayoutPanel52.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel52.Size = new System.Drawing.Size(1488, 100);
            this.tableLayoutPanel52.TabIndex = 5;
            // 
            // cancelBtnPaymentId
            // 
            this.cancelBtnPaymentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtnPaymentId.Location = new System.Drawing.Point(117, 3);
            this.cancelBtnPaymentId.Name = "cancelBtnPaymentId";
            this.cancelBtnPaymentId.Size = new System.Drawing.Size(222, 93);
            this.cancelBtnPaymentId.TabIndex = 0;
            this.cancelBtnPaymentId.Text = "CANCEL";
            this.cancelBtnPaymentId.UseVisualStyleBackColor = true;
            // 
            // backBtnPaymentId
            // 
            this.backBtnPaymentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtnPaymentId.Location = new System.Drawing.Point(459, 3);
            this.backBtnPaymentId.Name = "backBtnPaymentId";
            this.backBtnPaymentId.Size = new System.Drawing.Size(222, 93);
            this.backBtnPaymentId.TabIndex = 1;
            this.backBtnPaymentId.Text = "BACK";
            this.backBtnPaymentId.UseVisualStyleBackColor = true;
            // 
            // printBtnPaymentId
            // 
            this.printBtnPaymentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtnPaymentId.Location = new System.Drawing.Point(1143, 3);
            this.printBtnPaymentId.Name = "printBtnPaymentId";
            this.printBtnPaymentId.Size = new System.Drawing.Size(222, 93);
            this.printBtnPaymentId.TabIndex = 2;
            this.printBtnPaymentId.Text = "PRINT";
            this.printBtnPaymentId.UseVisualStyleBackColor = true;
            this.printBtnPaymentId.Click += new System.EventHandler(this.printBtnPaymentId_CLick);
            // 
            // downloadBtnPaymentId
            // 
            this.downloadBtnPaymentId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadBtnPaymentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadBtnPaymentId.Location = new System.Drawing.Point(801, 3);
            this.downloadBtnPaymentId.Name = "downloadBtnPaymentId";
            this.downloadBtnPaymentId.Size = new System.Drawing.Size(222, 94);
            this.downloadBtnPaymentId.TabIndex = 3;
            this.downloadBtnPaymentId.Text = "DOWNLOAD";
            this.downloadBtnPaymentId.UseVisualStyleBackColor = true;
            this.downloadBtnPaymentId.Click += new System.EventHandler(this.downloadBtnPaymentId_Click);
            // 
            // tableLayoutPanel51
            // 
            this.tableLayoutPanel51.ColumnCount = 1;
            this.tableLayoutPanel51.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel51.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel51.Controls.Add(this.label24, 0, 0);
            this.tableLayoutPanel51.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel51.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel51.Name = "tableLayoutPanel51";
            this.tableLayoutPanel51.RowCount = 1;
            this.tableLayoutPanel51.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel51.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel51.Size = new System.Drawing.Size(1488, 100);
            this.tableLayoutPanel51.TabIndex = 4;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(3, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(1482, 100);
            this.label24.TabIndex = 0;
            this.label24.Text = "PAYMENT";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // softCopyDownloadId
            // 
            this.softCopyDownloadId.Controls.Add(this.panel10);
            this.softCopyDownloadId.Controls.Add(this.tableLayoutPanel41);
            this.softCopyDownloadId.Controls.Add(this.tableLayoutPanel39);
            this.softCopyDownloadId.Controls.Add(this.tableLayoutPanel38);
            this.softCopyDownloadId.Controls.Add(this.tableLayoutPanel15);
            this.softCopyDownloadId.Controls.Add(this.tableLayoutPanel14);
            this.softCopyDownloadId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.softCopyDownloadId.Location = new System.Drawing.Point(0, 0);
            this.softCopyDownloadId.Name = "softCopyDownloadId";
            this.softCopyDownloadId.Size = new System.Drawing.Size(1488, 729);
            this.softCopyDownloadId.TabIndex = 4;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.qrIdPrintingDownload);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(200, 200);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1088, 429);
            this.panel10.TabIndex = 5;
            // 
            // qrIdPrintingDownload
            // 
            this.qrIdPrintingDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrIdPrintingDownload.Location = new System.Drawing.Point(0, 0);
            this.qrIdPrintingDownload.Name = "qrIdPrintingDownload";
            this.qrIdPrintingDownload.Size = new System.Drawing.Size(1088, 429);
            this.qrIdPrintingDownload.TabIndex = 0;
            this.qrIdPrintingDownload.TabStop = false;
            // 
            // tableLayoutPanel41
            // 
            this.tableLayoutPanel41.ColumnCount = 1;
            this.tableLayoutPanel41.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel41.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel41.Controls.Add(this.label28, 0, 0);
            this.tableLayoutPanel41.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel41.Location = new System.Drawing.Point(200, 100);
            this.tableLayoutPanel41.Name = "tableLayoutPanel41";
            this.tableLayoutPanel41.RowCount = 1;
            this.tableLayoutPanel41.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel41.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel41.Size = new System.Drawing.Size(1088, 100);
            this.tableLayoutPanel41.TabIndex = 4;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(3, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(1082, 100);
            this.label28.TabIndex = 0;
            this.label28.Text = "SOFT COPY DOWNLOAD";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel39
            // 
            this.tableLayoutPanel39.ColumnCount = 5;
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel39.Controls.Add(this.downloadBackBtn, 1, 0);
            this.tableLayoutPanel39.Controls.Add(this.downloadCancelBtn, 3, 0);
            this.tableLayoutPanel39.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel39.Location = new System.Drawing.Point(200, 629);
            this.tableLayoutPanel39.Name = "tableLayoutPanel39";
            this.tableLayoutPanel39.RowCount = 1;
            this.tableLayoutPanel39.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel39.Size = new System.Drawing.Size(1088, 100);
            this.tableLayoutPanel39.TabIndex = 3;
            // 
            // downloadBackBtn
            // 
            this.downloadBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadBackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadBackBtn.Location = new System.Drawing.Point(158, 3);
            this.downloadBackBtn.Name = "downloadBackBtn";
            this.downloadBackBtn.Size = new System.Drawing.Size(304, 94);
            this.downloadBackBtn.TabIndex = 0;
            this.downloadBackBtn.Text = "BACK";
            this.downloadBackBtn.UseVisualStyleBackColor = true;
            // 
            // downloadCancelBtn
            // 
            this.downloadCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadCancelBtn.Location = new System.Drawing.Point(623, 3);
            this.downloadCancelBtn.Name = "downloadCancelBtn";
            this.downloadCancelBtn.Size = new System.Drawing.Size(304, 94);
            this.downloadCancelBtn.TabIndex = 1;
            this.downloadCancelBtn.Text = "CANCEL";
            this.downloadCancelBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel38
            // 
            this.tableLayoutPanel38.ColumnCount = 1;
            this.tableLayoutPanel38.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel38.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel38.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel38.Location = new System.Drawing.Point(0, 100);
            this.tableLayoutPanel38.Name = "tableLayoutPanel38";
            this.tableLayoutPanel38.RowCount = 1;
            this.tableLayoutPanel38.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel38.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 629F));
            this.tableLayoutPanel38.Size = new System.Drawing.Size(200, 629);
            this.tableLayoutPanel38.TabIndex = 2;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 1;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 1;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(1288, 100);
            this.tableLayoutPanel15.TabIndex = 1;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 1;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(1288, 0);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 729F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(200, 729);
            this.tableLayoutPanel14.TabIndex = 0;
            // 
            // IDsettings
            // 
            this.IDsettings.Controls.Add(this.panel5);
            this.IDsettings.Controls.Add(this.tableLayoutPanel34);
            this.IDsettings.Controls.Add(this.tableLayoutPanel33);
            this.IDsettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IDsettings.Location = new System.Drawing.Point(0, 0);
            this.IDsettings.Name = "IDsettings";
            this.IDsettings.Size = new System.Drawing.Size(1488, 729);
            this.IDsettings.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tableLayoutPanel35);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 100);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1488, 529);
            this.panel5.TabIndex = 2;
            // 
            // tableLayoutPanel35
            // 
            this.tableLayoutPanel35.ColumnCount = 2;
            this.tableLayoutPanel35.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel35.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel35.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel35.Controls.Add(this.panel7, 1, 0);
            this.tableLayoutPanel35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel35.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel35.Name = "tableLayoutPanel35";
            this.tableLayoutPanel35.RowCount = 1;
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 529F));
            this.tableLayoutPanel35.Size = new System.Drawing.Size(1488, 529);
            this.tableLayoutPanel35.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tableLayoutPanel36);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(738, 523);
            this.panel6.TabIndex = 0;
            // 
            // tableLayoutPanel36
            // 
            this.tableLayoutPanel36.ColumnCount = 3;
            this.tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel36.Controls.Add(this.tableLayoutPanel43, 1, 11);
            this.tableLayoutPanel36.Controls.Add(this.tableLayoutPanel42, 1, 8);
            this.tableLayoutPanel36.Controls.Add(this.tableLayoutPanel40, 1, 5);
            this.tableLayoutPanel36.Controls.Add(this.idPrintingCopies, 1, 1);
            this.tableLayoutPanel36.Controls.Add(this.label20, 1, 4);
            this.tableLayoutPanel36.Controls.Add(this.label21, 1, 7);
            this.tableLayoutPanel36.Controls.Add(this.label22, 1, 10);
            this.tableLayoutPanel36.Controls.Add(this.label23, 1, 13);
            this.tableLayoutPanel36.Controls.Add(this.tableLayoutPanel37, 1, 2);
            this.tableLayoutPanel36.Controls.Add(this.tableLayoutPanel45, 1, 14);
            this.tableLayoutPanel36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel36.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel36.Name = "tableLayoutPanel36";
            this.tableLayoutPanel36.RowCount = 16;
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.315692F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.578463F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.578463F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.315692F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.578463F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.73854F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.315692F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.578463F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.15903F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.315692F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.578463F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.15903F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.315692F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.578463F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.578463F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.315692F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel36.Size = new System.Drawing.Size(738, 523);
            this.tableLayoutPanel36.TabIndex = 0;
            // 
            // tableLayoutPanel43
            // 
            this.tableLayoutPanel43.ColumnCount = 2;
            this.tableLayoutPanel43.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel43.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel43.Controls.Add(this.radioBtnPhotoColored, 1, 1);
            this.tableLayoutPanel43.Controls.Add(this.radioBtnPhotoBlack, 1, 0);
            this.tableLayoutPanel43.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel43.Location = new System.Drawing.Point(150, 368);
            this.tableLayoutPanel43.Name = "tableLayoutPanel43";
            this.tableLayoutPanel43.RowCount = 2;
            this.tableLayoutPanel43.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel43.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel43.Size = new System.Drawing.Size(436, 62);
            this.tableLayoutPanel43.TabIndex = 11;
            // 
            // radioBtnPhotoColored
            // 
            this.radioBtnPhotoColored.AutoSize = true;
            this.radioBtnPhotoColored.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnPhotoColored.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnPhotoColored.Location = new System.Drawing.Point(133, 34);
            this.radioBtnPhotoColored.Name = "radioBtnPhotoColored";
            this.radioBtnPhotoColored.Size = new System.Drawing.Size(300, 25);
            this.radioBtnPhotoColored.TabIndex = 0;
            this.radioBtnPhotoColored.TabStop = true;
            this.radioBtnPhotoColored.Text = "COLORED";
            this.radioBtnPhotoColored.UseVisualStyleBackColor = true;
            this.radioBtnPhotoColored.Click += new System.EventHandler(this.radioBtnPhotoColored_click);
            // 
            // radioBtnPhotoBlack
            // 
            this.radioBtnPhotoBlack.AutoSize = true;
            this.radioBtnPhotoBlack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnPhotoBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnPhotoBlack.Location = new System.Drawing.Point(133, 3);
            this.radioBtnPhotoBlack.Name = "radioBtnPhotoBlack";
            this.radioBtnPhotoBlack.Size = new System.Drawing.Size(300, 25);
            this.radioBtnPhotoBlack.TabIndex = 0;
            this.radioBtnPhotoBlack.TabStop = true;
            this.radioBtnPhotoBlack.Text = "BLACK AND WHITE";
            this.radioBtnPhotoBlack.UseVisualStyleBackColor = true;
            this.radioBtnPhotoBlack.Click += new System.EventHandler(this.radioBtnPhotoBlack_click);
            // 
            // tableLayoutPanel42
            // 
            this.tableLayoutPanel42.ColumnCount = 2;
            this.tableLayoutPanel42.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel42.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel42.Controls.Add(this.radioBtnSinglePhotoCopies, 1, 0);
            this.tableLayoutPanel42.Controls.Add(this.radioBtnMultipleCopies, 1, 1);
            this.tableLayoutPanel42.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel42.Location = new System.Drawing.Point(150, 260);
            this.tableLayoutPanel42.Name = "tableLayoutPanel42";
            this.tableLayoutPanel42.RowCount = 2;
            this.tableLayoutPanel42.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel42.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel42.Size = new System.Drawing.Size(436, 62);
            this.tableLayoutPanel42.TabIndex = 10;
            // 
            // radioBtnSinglePhotoCopies
            // 
            this.radioBtnSinglePhotoCopies.AutoSize = true;
            this.radioBtnSinglePhotoCopies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnSinglePhotoCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnSinglePhotoCopies.Location = new System.Drawing.Point(133, 3);
            this.radioBtnSinglePhotoCopies.Name = "radioBtnSinglePhotoCopies";
            this.radioBtnSinglePhotoCopies.Size = new System.Drawing.Size(300, 25);
            this.radioBtnSinglePhotoCopies.TabIndex = 0;
            this.radioBtnSinglePhotoCopies.TabStop = true;
            this.radioBtnSinglePhotoCopies.Text = "SINGLE";
            this.radioBtnSinglePhotoCopies.UseVisualStyleBackColor = true;
            this.radioBtnSinglePhotoCopies.Click += new System.EventHandler(this.radioBtnSinglePhotoCopies_click);
            // 
            // radioBtnMultipleCopies
            // 
            this.radioBtnMultipleCopies.AutoSize = true;
            this.radioBtnMultipleCopies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnMultipleCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnMultipleCopies.Location = new System.Drawing.Point(133, 34);
            this.radioBtnMultipleCopies.Name = "radioBtnMultipleCopies";
            this.radioBtnMultipleCopies.Size = new System.Drawing.Size(300, 25);
            this.radioBtnMultipleCopies.TabIndex = 0;
            this.radioBtnMultipleCopies.TabStop = true;
            this.radioBtnMultipleCopies.Text = "MULTIPLE";
            this.radioBtnMultipleCopies.UseVisualStyleBackColor = true;
            this.radioBtnMultipleCopies.Click += new System.EventHandler(this.radioBtnMultipleCopies_click);
            // 
            // tableLayoutPanel40
            // 
            this.tableLayoutPanel40.ColumnCount = 2;
            this.tableLayoutPanel40.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel40.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel40.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel40.Controls.Add(this.radioBtn2x2, 1, 0);
            this.tableLayoutPanel40.Controls.Add(this.radioBtn1x1, 1, 1);
            this.tableLayoutPanel40.Controls.Add(this.radioBtn2x1, 1, 2);
            this.tableLayoutPanel40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel40.Location = new System.Drawing.Point(150, 117);
            this.tableLayoutPanel40.Name = "tableLayoutPanel40";
            this.tableLayoutPanel40.RowCount = 3;
            this.tableLayoutPanel40.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel40.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel40.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel40.Size = new System.Drawing.Size(436, 97);
            this.tableLayoutPanel40.TabIndex = 8;
            // 
            // radioBtn2x2
            // 
            this.radioBtn2x2.AutoSize = true;
            this.radioBtn2x2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtn2x2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtn2x2.Location = new System.Drawing.Point(133, 3);
            this.radioBtn2x2.Name = "radioBtn2x2";
            this.radioBtn2x2.Size = new System.Drawing.Size(300, 26);
            this.radioBtn2x2.TabIndex = 0;
            this.radioBtn2x2.TabStop = true;
            this.radioBtn2x2.Text = "2x2";
            this.radioBtn2x2.UseVisualStyleBackColor = true;
            this.radioBtn2x2.CheckedChanged += new System.EventHandler(this.radioBtn2x2_click);
            // 
            // radioBtn1x1
            // 
            this.radioBtn1x1.AutoSize = true;
            this.radioBtn1x1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtn1x1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtn1x1.Location = new System.Drawing.Point(133, 35);
            this.radioBtn1x1.Name = "radioBtn1x1";
            this.radioBtn1x1.Size = new System.Drawing.Size(300, 26);
            this.radioBtn1x1.TabIndex = 0;
            this.radioBtn1x1.TabStop = true;
            this.radioBtn1x1.Text = "1x1";
            this.radioBtn1x1.UseVisualStyleBackColor = true;
            this.radioBtn1x1.Click += new System.EventHandler(this.radioBtn1x1_click);
            // 
            // radioBtn2x1
            // 
            this.radioBtn2x1.AutoSize = true;
            this.radioBtn2x1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtn2x1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtn2x1.Location = new System.Drawing.Point(133, 67);
            this.radioBtn2x1.Name = "radioBtn2x1";
            this.radioBtn2x1.Size = new System.Drawing.Size(300, 27);
            this.radioBtn2x1.TabIndex = 0;
            this.radioBtn2x1.TabStop = true;
            this.radioBtn2x1.Text = "2x1";
            this.radioBtn2x1.UseVisualStyleBackColor = true;
            this.radioBtn2x1.Click += new System.EventHandler(this.radioBtn2x1_click);
            // 
            // idPrintingCopies
            // 
            this.idPrintingCopies.AutoSize = true;
            this.idPrintingCopies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintingCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPrintingCopies.Location = new System.Drawing.Point(150, 6);
            this.idPrintingCopies.Name = "idPrintingCopies";
            this.idPrintingCopies.Size = new System.Drawing.Size(436, 34);
            this.idPrintingCopies.TabIndex = 0;
            this.idPrintingCopies.Text = "COPIES";
            this.idPrintingCopies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(150, 80);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(436, 34);
            this.label20.TabIndex = 1;
            this.label20.Text = "PHOTO SIZE";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(150, 223);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(436, 34);
            this.label21.TabIndex = 2;
            this.label21.Text = "LAYOUT";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(150, 331);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(436, 34);
            this.label22.TabIndex = 3;
            this.label22.Text = "PRINT TYPE";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(150, 439);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(436, 34);
            this.label23.TabIndex = 4;
            this.label23.Text = "TOTAL";
            // 
            // tableLayoutPanel37
            // 
            this.tableLayoutPanel37.ColumnCount = 3;
            this.tableLayoutPanel37.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel37.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel37.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel37.Controls.Add(this.numericIdPrintingCopies, 1, 0);
            this.tableLayoutPanel37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel37.Location = new System.Drawing.Point(150, 43);
            this.tableLayoutPanel37.Name = "tableLayoutPanel37";
            this.tableLayoutPanel37.RowCount = 1;
            this.tableLayoutPanel37.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel37.Size = new System.Drawing.Size(436, 28);
            this.tableLayoutPanel37.TabIndex = 5;
            // 
            // numericIdPrintingCopies
            // 
            this.numericIdPrintingCopies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericIdPrintingCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericIdPrintingCopies.Location = new System.Drawing.Point(133, 3);
            this.numericIdPrintingCopies.Name = "numericIdPrintingCopies";
            this.numericIdPrintingCopies.Size = new System.Drawing.Size(168, 38);
            this.numericIdPrintingCopies.TabIndex = 0;
            this.numericIdPrintingCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel45
            // 
            this.tableLayoutPanel45.ColumnCount = 3;
            this.tableLayoutPanel45.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel45.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel45.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel45.Controls.Add(this.idPrintingTotal, 1, 0);
            this.tableLayoutPanel45.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel45.Location = new System.Drawing.Point(150, 476);
            this.tableLayoutPanel45.Name = "tableLayoutPanel45";
            this.tableLayoutPanel45.RowCount = 1;
            this.tableLayoutPanel45.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel45.Size = new System.Drawing.Size(436, 28);
            this.tableLayoutPanel45.TabIndex = 13;
            // 
            // idPrintingTotal
            // 
            this.idPrintingTotal.AutoSize = true;
            this.idPrintingTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintingTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPrintingTotal.Location = new System.Drawing.Point(133, 0);
            this.idPrintingTotal.Name = "idPrintingTotal";
            this.idPrintingTotal.Size = new System.Drawing.Size(212, 28);
            this.idPrintingTotal.TabIndex = 0;
            this.idPrintingTotal.Text = "[TOTAL]";
            this.idPrintingTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tableLayoutPanel8);
            this.panel7.Controls.Add(this.tableLayoutPanel46);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(747, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(738, 523);
            this.panel7.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel8.Controls.Add(this.panel9, 1, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(738, 368);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.idSettingsPicturePreview);
            this.panel9.Controls.Add(this.tableLayoutPanel13);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(39, 21);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(658, 325);
            this.panel9.TabIndex = 0;
            // 
            // idSettingsPicturePreview
            // 
            this.idSettingsPicturePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idSettingsPicturePreview.Location = new System.Drawing.Point(0, 0);
            this.idSettingsPicturePreview.Name = "idSettingsPicturePreview";
            this.idSettingsPicturePreview.Size = new System.Drawing.Size(458, 325);
            this.idSettingsPicturePreview.TabIndex = 0;
            this.idSettingsPicturePreview.TabStop = false;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel13.Controls.Add(this.idPrintPreviewMini, 0, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(458, 0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 2;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(200, 325);
            this.tableLayoutPanel13.TabIndex = 0;
            // 
            // idPrintPreviewMini
            // 
            this.idPrintPreviewMini.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintPreviewMini.Location = new System.Drawing.Point(3, 3);
            this.idPrintPreviewMini.Name = "idPrintPreviewMini";
            this.idPrintPreviewMini.Size = new System.Drawing.Size(194, 156);
            this.idPrintPreviewMini.TabIndex = 0;
            this.idPrintPreviewMini.TabStop = false;
            // 
            // tableLayoutPanel46
            // 
            this.tableLayoutPanel46.ColumnCount = 4;
            this.tableLayoutPanel46.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel46.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel46.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel46.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel46.Controls.Add(this.idSettingsSelectPicture1, 0, 0);
            this.tableLayoutPanel46.Controls.Add(this.idSettingsSelectPicture2, 1, 0);
            this.tableLayoutPanel46.Controls.Add(this.idSettingsSelectPicture3, 2, 0);
            this.tableLayoutPanel46.Controls.Add(this.idSettingsSelectPicture4, 3, 0);
            this.tableLayoutPanel46.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel46.Location = new System.Drawing.Point(0, 368);
            this.tableLayoutPanel46.Name = "tableLayoutPanel46";
            this.tableLayoutPanel46.RowCount = 1;
            this.tableLayoutPanel46.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel46.Size = new System.Drawing.Size(738, 155);
            this.tableLayoutPanel46.TabIndex = 0;
            // 
            // idSettingsSelectPicture1
            // 
            this.idSettingsSelectPicture1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idSettingsSelectPicture1.Location = new System.Drawing.Point(3, 3);
            this.idSettingsSelectPicture1.Name = "idSettingsSelectPicture1";
            this.idSettingsSelectPicture1.Size = new System.Drawing.Size(178, 149);
            this.idSettingsSelectPicture1.TabIndex = 0;
            this.idSettingsSelectPicture1.TabStop = false;
            this.idSettingsSelectPicture1.Click += new System.EventHandler(this.SelectPhoto_Click);
            // 
            // idSettingsSelectPicture2
            // 
            this.idSettingsSelectPicture2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idSettingsSelectPicture2.Location = new System.Drawing.Point(187, 3);
            this.idSettingsSelectPicture2.Name = "idSettingsSelectPicture2";
            this.idSettingsSelectPicture2.Size = new System.Drawing.Size(178, 149);
            this.idSettingsSelectPicture2.TabIndex = 1;
            this.idSettingsSelectPicture2.TabStop = false;
            this.idSettingsSelectPicture2.Click += new System.EventHandler(this.SelectPhoto_Click);
            // 
            // idSettingsSelectPicture3
            // 
            this.idSettingsSelectPicture3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idSettingsSelectPicture3.Location = new System.Drawing.Point(371, 3);
            this.idSettingsSelectPicture3.Name = "idSettingsSelectPicture3";
            this.idSettingsSelectPicture3.Size = new System.Drawing.Size(178, 149);
            this.idSettingsSelectPicture3.TabIndex = 2;
            this.idSettingsSelectPicture3.TabStop = false;
            this.idSettingsSelectPicture3.Click += new System.EventHandler(this.SelectPhoto_Click);
            // 
            // idSettingsSelectPicture4
            // 
            this.idSettingsSelectPicture4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idSettingsSelectPicture4.Location = new System.Drawing.Point(555, 3);
            this.idSettingsSelectPicture4.Name = "idSettingsSelectPicture4";
            this.idSettingsSelectPicture4.Size = new System.Drawing.Size(180, 149);
            this.idSettingsSelectPicture4.TabIndex = 3;
            this.idSettingsSelectPicture4.TabStop = false;
            this.idSettingsSelectPicture4.Click += new System.EventHandler(this.SelectPhoto_Click);
            // 
            // tableLayoutPanel34
            // 
            this.tableLayoutPanel34.ColumnCount = 7;
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel34.Controls.Add(this.idPrintSettingsCancelBtn, 1, 1);
            this.tableLayoutPanel34.Controls.Add(this.idPrintSettingsBackBtn, 3, 1);
            this.tableLayoutPanel34.Controls.Add(this.idPrintSettingsConintueBtn, 5, 1);
            this.tableLayoutPanel34.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel34.Location = new System.Drawing.Point(0, 629);
            this.tableLayoutPanel34.Name = "tableLayoutPanel34";
            this.tableLayoutPanel34.RowCount = 3;
            this.tableLayoutPanel34.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel34.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel34.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel34.Size = new System.Drawing.Size(1488, 100);
            this.tableLayoutPanel34.TabIndex = 1;
            // 
            // idPrintSettingsCancelBtn
            // 
            this.idPrintSettingsCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintSettingsCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPrintSettingsCancelBtn.Location = new System.Drawing.Point(151, 8);
            this.idPrintSettingsCancelBtn.Name = "idPrintSettingsCancelBtn";
            this.idPrintSettingsCancelBtn.Size = new System.Drawing.Size(291, 84);
            this.idPrintSettingsCancelBtn.TabIndex = 0;
            this.idPrintSettingsCancelBtn.Text = "CANCEL";
            this.idPrintSettingsCancelBtn.UseVisualStyleBackColor = true;
            this.idPrintSettingsCancelBtn.Click += new System.EventHandler(this.idPrintSettingsCancelBtn_Click);
            // 
            // idPrintSettingsBackBtn
            // 
            this.idPrintSettingsBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintSettingsBackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPrintSettingsBackBtn.Location = new System.Drawing.Point(596, 8);
            this.idPrintSettingsBackBtn.Name = "idPrintSettingsBackBtn";
            this.idPrintSettingsBackBtn.Size = new System.Drawing.Size(291, 84);
            this.idPrintSettingsBackBtn.TabIndex = 1;
            this.idPrintSettingsBackBtn.Text = "BACK";
            this.idPrintSettingsBackBtn.UseVisualStyleBackColor = true;
            this.idPrintSettingsBackBtn.Click += new System.EventHandler(this.idPrintSettingsBackBtn_Click);
            // 
            // idPrintSettingsConintueBtn
            // 
            this.idPrintSettingsConintueBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintSettingsConintueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPrintSettingsConintueBtn.Location = new System.Drawing.Point(1041, 8);
            this.idPrintSettingsConintueBtn.Name = "idPrintSettingsConintueBtn";
            this.idPrintSettingsConintueBtn.Size = new System.Drawing.Size(291, 84);
            this.idPrintSettingsConintueBtn.TabIndex = 2;
            this.idPrintSettingsConintueBtn.Text = "CONTINUE";
            this.idPrintSettingsConintueBtn.UseVisualStyleBackColor = true;
            this.idPrintSettingsConintueBtn.Click += new System.EventHandler(this.idPrintSettingsContinueBtn_Click);
            // 
            // tableLayoutPanel33
            // 
            this.tableLayoutPanel33.ColumnCount = 2;
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel33.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel33.Controls.Add(this.label19, 1, 0);
            this.tableLayoutPanel33.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel33.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel33.Name = "tableLayoutPanel33";
            this.tableLayoutPanel33.RowCount = 1;
            this.tableLayoutPanel33.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel33.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel33.Size = new System.Drawing.Size(1488, 100);
            this.tableLayoutPanel33.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(738, 100);
            this.label18.TabIndex = 0;
            this.label18.Text = "ID PRINTING SETTINGS";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(747, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(738, 100);
            this.label19.TabIndex = 1;
            this.label19.Text = "PHOTO PREVIEW";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCRMidPrinting
            // 
            this.panelCRMidPrinting.Controls.Add(this.tableLayoutPanel27);
            this.panelCRMidPrinting.Controls.Add(this.tableLayoutPanel25);
            this.panelCRMidPrinting.Controls.Add(this.tableLayoutPanel26);
            this.panelCRMidPrinting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCRMidPrinting.Location = new System.Drawing.Point(0, 0);
            this.panelCRMidPrinting.Name = "panelCRMidPrinting";
            this.panelCRMidPrinting.Size = new System.Drawing.Size(1488, 729);
            this.panelCRMidPrinting.TabIndex = 2;
            // 
            // tableLayoutPanel27
            // 
            this.tableLayoutPanel27.ColumnCount = 7;
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.083333F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.83333F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.083333F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.083333F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.83333F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.083333F));
            this.tableLayoutPanel27.Controls.Add(this.tableLayoutPanel28, 5, 1);
            this.tableLayoutPanel27.Controls.Add(this.idCameraFeed, 3, 1);
            this.tableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel27.Location = new System.Drawing.Point(0, 100);
            this.tableLayoutPanel27.Name = "tableLayoutPanel27";
            this.tableLayoutPanel27.RowCount = 3;
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel27.Size = new System.Drawing.Size(1488, 529);
            this.tableLayoutPanel27.TabIndex = 7;
            // 
            // tableLayoutPanel28
            // 
            this.tableLayoutPanel28.ColumnCount = 1;
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel28.Controls.Add(this.idPreviewPictureBox1, 0, 0);
            this.tableLayoutPanel28.Controls.Add(this.idPreviewPictureBox2, 0, 1);
            this.tableLayoutPanel28.Controls.Add(this.idPreviewPictureBox3, 0, 2);
            this.tableLayoutPanel28.Controls.Add(this.idPreviewPictureBox4, 0, 3);
            this.tableLayoutPanel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel28.Location = new System.Drawing.Point(1146, 13);
            this.tableLayoutPanel28.Name = "tableLayoutPanel28";
            this.tableLayoutPanel28.RowCount = 4;
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel28.Size = new System.Drawing.Size(303, 501);
            this.tableLayoutPanel28.TabIndex = 1;
            // 
            // idPreviewPictureBox1
            // 
            this.idPreviewPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPreviewPictureBox1.Location = new System.Drawing.Point(3, 3);
            this.idPreviewPictureBox1.Name = "idPreviewPictureBox1";
            this.idPreviewPictureBox1.Size = new System.Drawing.Size(297, 119);
            this.idPreviewPictureBox1.TabIndex = 0;
            this.idPreviewPictureBox1.TabStop = false;
            // 
            // idPreviewPictureBox2
            // 
            this.idPreviewPictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPreviewPictureBox2.Location = new System.Drawing.Point(3, 128);
            this.idPreviewPictureBox2.Name = "idPreviewPictureBox2";
            this.idPreviewPictureBox2.Size = new System.Drawing.Size(297, 119);
            this.idPreviewPictureBox2.TabIndex = 1;
            this.idPreviewPictureBox2.TabStop = false;
            // 
            // idPreviewPictureBox3
            // 
            this.idPreviewPictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPreviewPictureBox3.Location = new System.Drawing.Point(3, 253);
            this.idPreviewPictureBox3.Name = "idPreviewPictureBox3";
            this.idPreviewPictureBox3.Size = new System.Drawing.Size(297, 119);
            this.idPreviewPictureBox3.TabIndex = 2;
            this.idPreviewPictureBox3.TabStop = false;
            // 
            // idPreviewPictureBox4
            // 
            this.idPreviewPictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPreviewPictureBox4.Location = new System.Drawing.Point(3, 378);
            this.idPreviewPictureBox4.Name = "idPreviewPictureBox4";
            this.idPreviewPictureBox4.Size = new System.Drawing.Size(297, 120);
            this.idPreviewPictureBox4.TabIndex = 3;
            this.idPreviewPictureBox4.TabStop = false;
            // 
            // idCameraFeed
            // 
            this.idCameraFeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idCameraFeed.Location = new System.Drawing.Point(372, 13);
            this.idCameraFeed.Name = "idCameraFeed";
            this.idCameraFeed.Size = new System.Drawing.Size(738, 501);
            this.idCameraFeed.TabIndex = 2;
            this.idCameraFeed.TabStop = false;
            // 
            // tableLayoutPanel25
            // 
            this.tableLayoutPanel25.ColumnCount = 1;
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel25.Controls.Add(this.photoIDtitle, 0, 0);
            this.tableLayoutPanel25.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel25.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel25.Name = "tableLayoutPanel25";
            this.tableLayoutPanel25.RowCount = 1;
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel25.Size = new System.Drawing.Size(1488, 100);
            this.tableLayoutPanel25.TabIndex = 1;
            // 
            // photoIDtitle
            // 
            this.photoIDtitle.AutoSize = true;
            this.photoIDtitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoIDtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoIDtitle.Location = new System.Drawing.Point(3, 0);
            this.photoIDtitle.Name = "photoIDtitle";
            this.photoIDtitle.Size = new System.Drawing.Size(1482, 100);
            this.photoIDtitle.TabIndex = 0;
            this.photoIDtitle.Text = "ID PHOTO";
            this.photoIDtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel26
            // 
            this.tableLayoutPanel26.ColumnCount = 9;
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.42857F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.571429F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel26.Controls.Add(this.idPrintingCancelBtn, 1, 1);
            this.tableLayoutPanel26.Controls.Add(this.idCapctureAgainBtn, 7, 1);
            this.tableLayoutPanel26.Controls.Add(this.idPrintingContinueBtn, 3, 1);
            this.tableLayoutPanel26.Controls.Add(this.idCaptureBtn, 5, 1);
            this.tableLayoutPanel26.Controls.Add(this.CameraTimer, 4, 1);
            this.tableLayoutPanel26.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel26.Location = new System.Drawing.Point(0, 629);
            this.tableLayoutPanel26.Name = "tableLayoutPanel26";
            this.tableLayoutPanel26.RowCount = 3;
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel26.Size = new System.Drawing.Size(1488, 100);
            this.tableLayoutPanel26.TabIndex = 6;
            // 
            // idPrintingCancelBtn
            // 
            this.idPrintingCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPrintingCancelBtn.Location = new System.Drawing.Point(109, 8);
            this.idPrintingCancelBtn.Name = "idPrintingCancelBtn";
            this.idPrintingCancelBtn.Size = new System.Drawing.Size(206, 83);
            this.idPrintingCancelBtn.TabIndex = 5;
            this.idPrintingCancelBtn.Text = "CANCEL";
            this.idPrintingCancelBtn.UseVisualStyleBackColor = true;
            this.idPrintingCancelBtn.Click += new System.EventHandler(this.idPrintingCancelBtn_Click);
            // 
            // idCapctureAgainBtn
            // 
            this.idCapctureAgainBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idCapctureAgainBtn.Location = new System.Drawing.Point(1169, 8);
            this.idCapctureAgainBtn.Name = "idCapctureAgainBtn";
            this.idCapctureAgainBtn.Size = new System.Drawing.Size(206, 83);
            this.idCapctureAgainBtn.TabIndex = 4;
            this.idCapctureAgainBtn.Text = "CAPTURE AGAIN";
            this.idCapctureAgainBtn.UseVisualStyleBackColor = true;
            this.idCapctureAgainBtn.Click += new System.EventHandler(this.idCaptureAgainBtn_Click);
            // 
            // idPrintingContinueBtn
            // 
            this.idPrintingContinueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPrintingContinueBtn.Location = new System.Drawing.Point(374, 8);
            this.idPrintingContinueBtn.Name = "idPrintingContinueBtn";
            this.idPrintingContinueBtn.Size = new System.Drawing.Size(206, 83);
            this.idPrintingContinueBtn.TabIndex = 3;
            this.idPrintingContinueBtn.Text = "CONTINUE";
            this.idPrintingContinueBtn.UseVisualStyleBackColor = true;
            this.idPrintingContinueBtn.Click += new System.EventHandler(this.idPrintingContinueBtn_Click);
            // 
            // idCaptureBtn
            // 
            this.idCaptureBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idCaptureBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idCaptureBtn.Location = new System.Drawing.Point(904, 8);
            this.idCaptureBtn.Name = "idCaptureBtn";
            this.idCaptureBtn.Size = new System.Drawing.Size(206, 84);
            this.idCaptureBtn.TabIndex = 6;
            this.idCaptureBtn.Text = "CAPTURE";
            this.idCaptureBtn.UseVisualStyleBackColor = true;
            this.idCaptureBtn.Click += new System.EventHandler(this.idCaptureBtn_Click);
            // 
            // CameraTimer
            // 
            this.CameraTimer.AutoSize = true;
            this.CameraTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CameraTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CameraTimer.Location = new System.Drawing.Point(586, 5);
            this.CameraTimer.Name = "CameraTimer";
            this.CameraTimer.Size = new System.Drawing.Size(312, 90);
            this.CameraTimer.TabIndex = 7;
            this.CameraTimer.Text = "[TIMER]";
            this.CameraTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // photoMode
            // 
            this.photoMode.Controls.Add(this.phototop);
            this.photoMode.Controls.Add(this.buttonLayoutPhoto);
            this.photoMode.Controls.Add(this.tableLayoutPanel22);
            this.photoMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoMode.Location = new System.Drawing.Point(0, 0);
            this.photoMode.Name = "photoMode";
            this.photoMode.Size = new System.Drawing.Size(1488, 729);
            this.photoMode.TabIndex = 1;
            // 
            // phototop
            // 
            this.phototop.ColumnCount = 1;
            this.phototop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.phototop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.phototop.Controls.Add(this.photoLabelTitle, 0, 0);
            this.phototop.Dock = System.Windows.Forms.DockStyle.Top;
            this.phototop.Location = new System.Drawing.Point(0, 0);
            this.phototop.Name = "phototop";
            this.phototop.RowCount = 1;
            this.phototop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.phototop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.phototop.Size = new System.Drawing.Size(1488, 100);
            this.phototop.TabIndex = 3;
            // 
            // photoLabelTitle
            // 
            this.photoLabelTitle.AutoSize = true;
            this.photoLabelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoLabelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoLabelTitle.Location = new System.Drawing.Point(3, 0);
            this.photoLabelTitle.Name = "photoLabelTitle";
            this.photoLabelTitle.Size = new System.Drawing.Size(1482, 100);
            this.photoLabelTitle.TabIndex = 0;
            this.photoLabelTitle.Text = "CHOOSE PHOTO MODE";
            this.photoLabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonLayoutPhoto
            // 
            this.buttonLayoutPhoto.ColumnCount = 5;
            this.buttonLayoutPhoto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.29491F));
            this.buttonLayoutPhoto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.24661F));
            this.buttonLayoutPhoto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.99F));
            this.buttonLayoutPhoto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.17356F));
            this.buttonLayoutPhoto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.29491F));
            this.buttonLayoutPhoto.Controls.Add(this.photoBtnRetrieve, 3, 1);
            this.buttonLayoutPhoto.Controls.Add(this.photoModeCancelBtn, 1, 1);
            this.buttonLayoutPhoto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonLayoutPhoto.Location = new System.Drawing.Point(0, 629);
            this.buttonLayoutPhoto.Name = "buttonLayoutPhoto";
            this.buttonLayoutPhoto.RowCount = 3;
            this.buttonLayoutPhoto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.buttonLayoutPhoto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.buttonLayoutPhoto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.buttonLayoutPhoto.Size = new System.Drawing.Size(1488, 100);
            this.buttonLayoutPhoto.TabIndex = 4;
            // 
            // photoBtnRetrieve
            // 
            this.photoBtnRetrieve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBtnRetrieve.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoBtnRetrieve.Location = new System.Drawing.Point(873, 8);
            this.photoBtnRetrieve.Name = "photoBtnRetrieve";
            this.photoBtnRetrieve.Size = new System.Drawing.Size(338, 84);
            this.photoBtnRetrieve.TabIndex = 0;
            this.photoBtnRetrieve.Text = "RETRIEVE PHOTO";
            this.photoBtnRetrieve.UseVisualStyleBackColor = true;
            // 
            // photoModeCancelBtn
            // 
            this.photoModeCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoModeCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoModeCancelBtn.Location = new System.Drawing.Point(275, 8);
            this.photoModeCancelBtn.Name = "photoModeCancelBtn";
            this.photoModeCancelBtn.Size = new System.Drawing.Size(325, 84);
            this.photoModeCancelBtn.TabIndex = 1;
            this.photoModeCancelBtn.Text = "CANCEL";
            this.photoModeCancelBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel22
            // 
            this.tableLayoutPanel22.ColumnCount = 4;
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel22.Controls.Add(this.tableLayoutPanel23, 2, 1);
            this.tableLayoutPanel22.Controls.Add(this.tableLayoutPanel24, 1, 1);
            this.tableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel22.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel22.Name = "tableLayoutPanel22";
            this.tableLayoutPanel22.RowCount = 3;
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel22.Size = new System.Drawing.Size(1488, 729);
            this.tableLayoutPanel22.TabIndex = 5;
            // 
            // tableLayoutPanel23
            // 
            this.tableLayoutPanel23.ColumnCount = 3;
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.21249F));
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.57502F));
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.21249F));
            this.tableLayoutPanel23.Controls.Add(this.photoBtnPhotoBooth, 1, 1);
            this.tableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel23.Location = new System.Drawing.Point(746, 39);
            this.tableLayoutPanel23.Name = "tableLayoutPanel23";
            this.tableLayoutPanel23.RowCount = 3;
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.21249F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.57502F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.21249F));
            this.tableLayoutPanel23.Size = new System.Drawing.Size(663, 650);
            this.tableLayoutPanel23.TabIndex = 0;
            // 
            // photoBtnPhotoBooth
            // 
            this.photoBtnPhotoBooth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBtnPhotoBooth.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoBtnPhotoBooth.Location = new System.Drawing.Point(163, 160);
            this.photoBtnPhotoBooth.Name = "photoBtnPhotoBooth";
            this.photoBtnPhotoBooth.Size = new System.Drawing.Size(335, 329);
            this.photoBtnPhotoBooth.TabIndex = 0;
            this.photoBtnPhotoBooth.Text = "PHOTOBOOTH\r\n(For fun pictures with frame printing)";
            this.photoBtnPhotoBooth.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel24
            // 
            this.tableLayoutPanel24.ColumnCount = 3;
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.21F));
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.58F));
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.21F));
            this.tableLayoutPanel24.Controls.Add(this.photoBtnID, 1, 1);
            this.tableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel24.Location = new System.Drawing.Point(77, 39);
            this.tableLayoutPanel24.Name = "tableLayoutPanel24";
            this.tableLayoutPanel24.RowCount = 3;
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.21F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.58F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.21F));
            this.tableLayoutPanel24.Size = new System.Drawing.Size(663, 650);
            this.tableLayoutPanel24.TabIndex = 1;
            // 
            // photoBtnID
            // 
            this.photoBtnID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBtnID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoBtnID.Location = new System.Drawing.Point(163, 160);
            this.photoBtnID.Name = "photoBtnID";
            this.photoBtnID.Size = new System.Drawing.Size(335, 329);
            this.photoBtnID.TabIndex = 0;
            this.photoBtnID.Text = "ID PHOTO\r\n(For ID picture printing)";
            this.photoBtnID.UseVisualStyleBackColor = true;
            this.photoBtnID.Click += new System.EventHandler(this.idModeBtn_Click);
            // 
            // photoBoothPanel
            // 
            this.photoBoothPanel.Controls.Add(this.panelCMRphotoBooth);
            this.photoBoothPanel.Controls.Add(this.photoBoothSettings);
            this.photoBoothPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothPanel.Location = new System.Drawing.Point(0, 0);
            this.photoBoothPanel.Name = "photoBoothPanel";
            this.photoBoothPanel.Size = new System.Drawing.Size(1488, 729);
            this.photoBoothPanel.TabIndex = 0;
            // 
            // panelCMRphotoBooth
            // 
            this.panelCMRphotoBooth.Controls.Add(this.tableLayoutPanel31);
            this.panelCMRphotoBooth.Controls.Add(this.tableLayoutPanel29);
            this.panelCMRphotoBooth.Controls.Add(this.tableLayoutPanel30);
            this.panelCMRphotoBooth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCMRphotoBooth.Location = new System.Drawing.Point(0, 0);
            this.panelCMRphotoBooth.Name = "panelCMRphotoBooth";
            this.panelCMRphotoBooth.Size = new System.Drawing.Size(1488, 729);
            this.panelCMRphotoBooth.TabIndex = 2;
            // 
            // tableLayoutPanel31
            // 
            this.tableLayoutPanel31.ColumnCount = 7;
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.080416F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.83417F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.080416F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.01F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.080416F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.83417F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.080416F));
            this.tableLayoutPanel31.Controls.Add(this.photoBoothCameraPanel, 3, 1);
            this.tableLayoutPanel31.Controls.Add(this.tableLayoutPanel32, 5, 1);
            this.tableLayoutPanel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel31.Location = new System.Drawing.Point(0, 100);
            this.tableLayoutPanel31.Name = "tableLayoutPanel31";
            this.tableLayoutPanel31.RowCount = 3;
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96F));
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel31.Size = new System.Drawing.Size(1488, 548);
            this.tableLayoutPanel31.TabIndex = 2;
            // 
            // photoBoothCameraPanel
            // 
            this.photoBoothCameraPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothCameraPanel.Location = new System.Drawing.Point(373, 13);
            this.photoBoothCameraPanel.Name = "photoBoothCameraPanel";
            this.photoBoothCameraPanel.Size = new System.Drawing.Size(738, 520);
            this.photoBoothCameraPanel.TabIndex = 0;
            // 
            // tableLayoutPanel32
            // 
            this.tableLayoutPanel32.ColumnCount = 1;
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel32.Controls.Add(this.photoBoothPreviewPanel, 0, 0);
            this.tableLayoutPanel32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel32.Location = new System.Drawing.Point(1147, 13);
            this.tableLayoutPanel32.Name = "tableLayoutPanel32";
            this.tableLayoutPanel32.RowCount = 2;
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel32.Size = new System.Drawing.Size(304, 520);
            this.tableLayoutPanel32.TabIndex = 1;
            // 
            // photoBoothPreviewPanel
            // 
            this.photoBoothPreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothPreviewPanel.Location = new System.Drawing.Point(3, 3);
            this.photoBoothPreviewPanel.Name = "photoBoothPreviewPanel";
            this.photoBoothPreviewPanel.Size = new System.Drawing.Size(298, 254);
            this.photoBoothPreviewPanel.TabIndex = 0;
            // 
            // tableLayoutPanel29
            // 
            this.tableLayoutPanel29.ColumnCount = 1;
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel29.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel29.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel29.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel29.Name = "tableLayoutPanel29";
            this.tableLayoutPanel29.RowCount = 1;
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel29.Size = new System.Drawing.Size(1488, 100);
            this.tableLayoutPanel29.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(3, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(1482, 100);
            this.label17.TabIndex = 0;
            this.label17.Text = "PHOTO BOOTH";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel30
            // 
            this.tableLayoutPanel30.ColumnCount = 7;
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel30.Controls.Add(this.photoBoothCaptureBtn, 5, 1);
            this.tableLayoutPanel30.Controls.Add(this.photoBoothContinueBtn, 3, 1);
            this.tableLayoutPanel30.Controls.Add(this.photoBoothCancelBtn, 1, 1);
            this.tableLayoutPanel30.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel30.Location = new System.Drawing.Point(0, 648);
            this.tableLayoutPanel30.Name = "tableLayoutPanel30";
            this.tableLayoutPanel30.RowCount = 3;
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel30.Size = new System.Drawing.Size(1488, 81);
            this.tableLayoutPanel30.TabIndex = 1;
            // 
            // photoBoothCaptureBtn
            // 
            this.photoBoothCaptureBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothCaptureBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoBoothCaptureBtn.Location = new System.Drawing.Point(1041, 7);
            this.photoBoothCaptureBtn.Name = "photoBoothCaptureBtn";
            this.photoBoothCaptureBtn.Size = new System.Drawing.Size(291, 66);
            this.photoBoothCaptureBtn.TabIndex = 0;
            this.photoBoothCaptureBtn.Text = "CAPTURE AGAIN";
            this.photoBoothCaptureBtn.UseVisualStyleBackColor = true;
            // 
            // photoBoothContinueBtn
            // 
            this.photoBoothContinueBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothContinueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoBoothContinueBtn.Location = new System.Drawing.Point(596, 7);
            this.photoBoothContinueBtn.Name = "photoBoothContinueBtn";
            this.photoBoothContinueBtn.Size = new System.Drawing.Size(291, 66);
            this.photoBoothContinueBtn.TabIndex = 1;
            this.photoBoothContinueBtn.Text = "CONTINUE";
            this.photoBoothContinueBtn.UseVisualStyleBackColor = true;
            // 
            // photoBoothCancelBtn
            // 
            this.photoBoothCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoBoothCancelBtn.Location = new System.Drawing.Point(151, 7);
            this.photoBoothCancelBtn.Name = "photoBoothCancelBtn";
            this.photoBoothCancelBtn.Size = new System.Drawing.Size(291, 66);
            this.photoBoothCancelBtn.TabIndex = 2;
            this.photoBoothCancelBtn.Text = "CANCEL";
            this.photoBoothCancelBtn.UseVisualStyleBackColor = true;
            // 
            // photoBoothSettings
            // 
            this.photoBoothSettings.Controls.Add(this.funSettings);
            this.photoBoothSettings.Controls.Add(this.funPayment);
            this.photoBoothSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothSettings.Location = new System.Drawing.Point(0, 0);
            this.photoBoothSettings.Name = "photoBoothSettings";
            this.photoBoothSettings.Size = new System.Drawing.Size(1488, 729);
            this.photoBoothSettings.TabIndex = 2;
            // 
            // funSettings
            // 
            this.funSettings.Controls.Add(this.tableLayoutPanel55);
            this.funSettings.Controls.Add(this.tableLayoutPanel54);
            this.funSettings.Controls.Add(this.tableLayoutPanel50);
            this.funSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funSettings.Location = new System.Drawing.Point(0, 0);
            this.funSettings.Name = "funSettings";
            this.funSettings.Size = new System.Drawing.Size(1488, 729);
            this.funSettings.TabIndex = 0;
            // 
            // tableLayoutPanel55
            // 
            this.tableLayoutPanel55.ColumnCount = 2;
            this.tableLayoutPanel55.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel55.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel55.Controls.Add(this.tableLayoutPanel56, 0, 0);
            this.tableLayoutPanel55.Controls.Add(this.panel8, 1, 0);
            this.tableLayoutPanel55.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel55.Location = new System.Drawing.Point(0, 100);
            this.tableLayoutPanel55.Name = "tableLayoutPanel55";
            this.tableLayoutPanel55.RowCount = 1;
            this.tableLayoutPanel55.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel55.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 529F));
            this.tableLayoutPanel55.Size = new System.Drawing.Size(1488, 529);
            this.tableLayoutPanel55.TabIndex = 2;
            // 
            // tableLayoutPanel56
            // 
            this.tableLayoutPanel56.ColumnCount = 3;
            this.tableLayoutPanel56.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel56.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel56.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel56.Controls.Add(this.label31, 1, 1);
            this.tableLayoutPanel56.Controls.Add(this.tableLayoutPanel57, 1, 2);
            this.tableLayoutPanel56.Controls.Add(this.label32, 1, 5);
            this.tableLayoutPanel56.Controls.Add(this.label33, 1, 10);
            this.tableLayoutPanel56.Controls.Add(this.label34, 1, 15);
            this.tableLayoutPanel56.Controls.Add(this.label35, 1, 18);
            this.tableLayoutPanel56.Controls.Add(this.tableLayoutPanel58, 1, 3);
            this.tableLayoutPanel56.Controls.Add(this.tableLayoutPanel59, 1, 6);
            this.tableLayoutPanel56.Controls.Add(this.tableLayoutPanel60, 1, 7);
            this.tableLayoutPanel56.Controls.Add(this.tableLayoutPanel61, 1, 8);
            this.tableLayoutPanel56.Controls.Add(this.tableLayoutPanel62, 1, 11);
            this.tableLayoutPanel56.Controls.Add(this.tableLayoutPanel63, 1, 12);
            this.tableLayoutPanel56.Controls.Add(this.tableLayoutPanel64, 1, 13);
            this.tableLayoutPanel56.Controls.Add(this.tableLayoutPanel65, 1, 16);
            this.tableLayoutPanel56.Controls.Add(this.tableLayoutPanel66, 1, 19);
            this.tableLayoutPanel56.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel56.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel56.Name = "tableLayoutPanel56";
            this.tableLayoutPanel56.RowCount = 21;
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.014275F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.014275F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.014275F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.014275F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.014275F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.260958F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.014275F));
            this.tableLayoutPanel56.Size = new System.Drawing.Size(738, 523);
            this.tableLayoutPanel56.TabIndex = 0;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(149, 5);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(438, 32);
            this.label31.TabIndex = 0;
            this.label31.Text = "LAYOUT";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel57
            // 
            this.tableLayoutPanel57.ColumnCount = 3;
            this.tableLayoutPanel57.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel57.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel57.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel57.Controls.Add(this.radioBtnVerticalPB, 1, 0);
            this.tableLayoutPanel57.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel57.Location = new System.Drawing.Point(149, 39);
            this.tableLayoutPanel57.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel57.Name = "tableLayoutPanel57";
            this.tableLayoutPanel57.RowCount = 1;
            this.tableLayoutPanel57.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel57.Size = new System.Drawing.Size(438, 28);
            this.tableLayoutPanel57.TabIndex = 1;
            // 
            // radioBtnVerticalPB
            // 
            this.radioBtnVerticalPB.AutoSize = true;
            this.radioBtnVerticalPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnVerticalPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnVerticalPB.Location = new System.Drawing.Point(133, 2);
            this.radioBtnVerticalPB.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnVerticalPB.Name = "radioBtnVerticalPB";
            this.radioBtnVerticalPB.Size = new System.Drawing.Size(215, 24);
            this.radioBtnVerticalPB.TabIndex = 0;
            this.radioBtnVerticalPB.TabStop = true;
            this.radioBtnVerticalPB.Text = "VERTIVAL STRIP";
            this.radioBtnVerticalPB.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(149, 106);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(438, 32);
            this.label32.TabIndex = 1;
            this.label32.Text = "FRAME";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(149, 239);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(438, 32);
            this.label33.TabIndex = 2;
            this.label33.Text = "FILTER";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(149, 372);
            this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(438, 32);
            this.label34.TabIndex = 3;
            this.label34.Text = "COPIES";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(149, 441);
            this.label35.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(438, 32);
            this.label35.TabIndex = 4;
            this.label35.Text = "TOTAL";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel58
            // 
            this.tableLayoutPanel58.ColumnCount = 3;
            this.tableLayoutPanel58.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel58.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel58.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel58.Controls.Add(this.radioBtnGridBtnPB, 1, 0);
            this.tableLayoutPanel58.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel58.Location = new System.Drawing.Point(149, 71);
            this.tableLayoutPanel58.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel58.Name = "tableLayoutPanel58";
            this.tableLayoutPanel58.RowCount = 1;
            this.tableLayoutPanel58.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel58.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel58.Size = new System.Drawing.Size(438, 28);
            this.tableLayoutPanel58.TabIndex = 5;
            // 
            // radioBtnGridBtnPB
            // 
            this.radioBtnGridBtnPB.AutoSize = true;
            this.radioBtnGridBtnPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnGridBtnPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnGridBtnPB.Location = new System.Drawing.Point(133, 2);
            this.radioBtnGridBtnPB.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnGridBtnPB.Name = "radioBtnGridBtnPB";
            this.radioBtnGridBtnPB.Size = new System.Drawing.Size(215, 24);
            this.radioBtnGridBtnPB.TabIndex = 0;
            this.radioBtnGridBtnPB.TabStop = true;
            this.radioBtnGridBtnPB.Text = "GRID (2x2)";
            this.radioBtnGridBtnPB.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel59
            // 
            this.tableLayoutPanel59.ColumnCount = 3;
            this.tableLayoutPanel59.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel59.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel59.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel59.Controls.Add(this.radioBtnNonePB, 1, 0);
            this.tableLayoutPanel59.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel59.Location = new System.Drawing.Point(149, 140);
            this.tableLayoutPanel59.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel59.Name = "tableLayoutPanel59";
            this.tableLayoutPanel59.RowCount = 1;
            this.tableLayoutPanel59.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel59.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel59.Size = new System.Drawing.Size(438, 28);
            this.tableLayoutPanel59.TabIndex = 6;
            // 
            // radioBtnNonePB
            // 
            this.radioBtnNonePB.AutoSize = true;
            this.radioBtnNonePB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnNonePB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnNonePB.Location = new System.Drawing.Point(133, 2);
            this.radioBtnNonePB.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnNonePB.Name = "radioBtnNonePB";
            this.radioBtnNonePB.Size = new System.Drawing.Size(215, 24);
            this.radioBtnNonePB.TabIndex = 0;
            this.radioBtnNonePB.TabStop = true;
            this.radioBtnNonePB.Text = "NONE";
            this.radioBtnNonePB.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel60
            // 
            this.tableLayoutPanel60.ColumnCount = 3;
            this.tableLayoutPanel60.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel60.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel60.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel60.Controls.Add(this.radioBtnMinimalPB, 1, 0);
            this.tableLayoutPanel60.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel60.Location = new System.Drawing.Point(149, 172);
            this.tableLayoutPanel60.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel60.Name = "tableLayoutPanel60";
            this.tableLayoutPanel60.RowCount = 1;
            this.tableLayoutPanel60.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel60.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel60.Size = new System.Drawing.Size(438, 28);
            this.tableLayoutPanel60.TabIndex = 7;
            // 
            // radioBtnMinimalPB
            // 
            this.radioBtnMinimalPB.AutoSize = true;
            this.radioBtnMinimalPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnMinimalPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnMinimalPB.Location = new System.Drawing.Point(133, 2);
            this.radioBtnMinimalPB.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnMinimalPB.Name = "radioBtnMinimalPB";
            this.radioBtnMinimalPB.Size = new System.Drawing.Size(215, 24);
            this.radioBtnMinimalPB.TabIndex = 0;
            this.radioBtnMinimalPB.TabStop = true;
            this.radioBtnMinimalPB.Text = "MINIMAL";
            this.radioBtnMinimalPB.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel61
            // 
            this.tableLayoutPanel61.ColumnCount = 3;
            this.tableLayoutPanel61.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel61.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel61.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel61.Controls.Add(this.radioBtnCutePB, 1, 0);
            this.tableLayoutPanel61.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel61.Location = new System.Drawing.Point(149, 204);
            this.tableLayoutPanel61.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel61.Name = "tableLayoutPanel61";
            this.tableLayoutPanel61.RowCount = 1;
            this.tableLayoutPanel61.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel61.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel61.Size = new System.Drawing.Size(438, 28);
            this.tableLayoutPanel61.TabIndex = 8;
            // 
            // radioBtnCutePB
            // 
            this.radioBtnCutePB.AutoSize = true;
            this.radioBtnCutePB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnCutePB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnCutePB.Location = new System.Drawing.Point(133, 2);
            this.radioBtnCutePB.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnCutePB.Name = "radioBtnCutePB";
            this.radioBtnCutePB.Size = new System.Drawing.Size(215, 24);
            this.radioBtnCutePB.TabIndex = 0;
            this.radioBtnCutePB.TabStop = true;
            this.radioBtnCutePB.Text = "CUTE";
            this.radioBtnCutePB.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel62
            // 
            this.tableLayoutPanel62.ColumnCount = 3;
            this.tableLayoutPanel62.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel62.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel62.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel62.Controls.Add(this.radioBtbFilterNonePB, 1, 0);
            this.tableLayoutPanel62.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel62.Location = new System.Drawing.Point(149, 273);
            this.tableLayoutPanel62.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel62.Name = "tableLayoutPanel62";
            this.tableLayoutPanel62.RowCount = 1;
            this.tableLayoutPanel62.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel62.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel62.Size = new System.Drawing.Size(438, 28);
            this.tableLayoutPanel62.TabIndex = 9;
            // 
            // radioBtbFilterNonePB
            // 
            this.radioBtbFilterNonePB.AutoSize = true;
            this.radioBtbFilterNonePB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtbFilterNonePB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtbFilterNonePB.Location = new System.Drawing.Point(133, 2);
            this.radioBtbFilterNonePB.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtbFilterNonePB.Name = "radioBtbFilterNonePB";
            this.radioBtbFilterNonePB.Size = new System.Drawing.Size(215, 24);
            this.radioBtbFilterNonePB.TabIndex = 0;
            this.radioBtbFilterNonePB.TabStop = true;
            this.radioBtbFilterNonePB.Text = "NONE";
            this.radioBtbFilterNonePB.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel63
            // 
            this.tableLayoutPanel63.ColumnCount = 2;
            this.tableLayoutPanel63.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel63.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel63.Controls.Add(this.radioBtnBlackAndWhitePB, 1, 0);
            this.tableLayoutPanel63.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel63.Location = new System.Drawing.Point(149, 305);
            this.tableLayoutPanel63.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel63.Name = "tableLayoutPanel63";
            this.tableLayoutPanel63.RowCount = 1;
            this.tableLayoutPanel63.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel63.Size = new System.Drawing.Size(438, 28);
            this.tableLayoutPanel63.TabIndex = 10;
            // 
            // radioBtnBlackAndWhitePB
            // 
            this.radioBtnBlackAndWhitePB.AutoSize = true;
            this.radioBtnBlackAndWhitePB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnBlackAndWhitePB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnBlackAndWhitePB.Location = new System.Drawing.Point(133, 2);
            this.radioBtnBlackAndWhitePB.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnBlackAndWhitePB.Name = "radioBtnBlackAndWhitePB";
            this.radioBtnBlackAndWhitePB.Size = new System.Drawing.Size(303, 24);
            this.radioBtnBlackAndWhitePB.TabIndex = 0;
            this.radioBtnBlackAndWhitePB.TabStop = true;
            this.radioBtnBlackAndWhitePB.Text = "BLACK AND WHITE";
            this.radioBtnBlackAndWhitePB.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel64
            // 
            this.tableLayoutPanel64.ColumnCount = 3;
            this.tableLayoutPanel64.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel64.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel64.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel64.Controls.Add(this.radioBtnWarmPB, 1, 0);
            this.tableLayoutPanel64.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel64.Location = new System.Drawing.Point(149, 337);
            this.tableLayoutPanel64.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel64.Name = "tableLayoutPanel64";
            this.tableLayoutPanel64.RowCount = 1;
            this.tableLayoutPanel64.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel64.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel64.Size = new System.Drawing.Size(438, 28);
            this.tableLayoutPanel64.TabIndex = 11;
            // 
            // radioBtnWarmPB
            // 
            this.radioBtnWarmPB.AutoSize = true;
            this.radioBtnWarmPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnWarmPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnWarmPB.Location = new System.Drawing.Point(133, 2);
            this.radioBtnWarmPB.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnWarmPB.Name = "radioBtnWarmPB";
            this.radioBtnWarmPB.Size = new System.Drawing.Size(215, 24);
            this.radioBtnWarmPB.TabIndex = 0;
            this.radioBtnWarmPB.TabStop = true;
            this.radioBtnWarmPB.Text = "WARM";
            this.radioBtnWarmPB.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel65
            // 
            this.tableLayoutPanel65.ColumnCount = 3;
            this.tableLayoutPanel65.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel65.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel65.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel65.Controls.Add(this.photoBoothNumeriCopies, 1, 0);
            this.tableLayoutPanel65.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel65.Location = new System.Drawing.Point(149, 406);
            this.tableLayoutPanel65.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel65.Name = "tableLayoutPanel65";
            this.tableLayoutPanel65.RowCount = 1;
            this.tableLayoutPanel65.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel65.Size = new System.Drawing.Size(438, 28);
            this.tableLayoutPanel65.TabIndex = 12;
            // 
            // photoBoothNumeriCopies
            // 
            this.photoBoothNumeriCopies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothNumeriCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoBoothNumeriCopies.Location = new System.Drawing.Point(133, 2);
            this.photoBoothNumeriCopies.Margin = new System.Windows.Forms.Padding(2);
            this.photoBoothNumeriCopies.Name = "photoBoothNumeriCopies";
            this.photoBoothNumeriCopies.Size = new System.Drawing.Size(171, 35);
            this.photoBoothNumeriCopies.TabIndex = 0;
            this.photoBoothNumeriCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel66
            // 
            this.tableLayoutPanel66.ColumnCount = 3;
            this.tableLayoutPanel66.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel66.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel66.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel66.Controls.Add(this.photoBoothTotal, 1, 0);
            this.tableLayoutPanel66.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel66.Location = new System.Drawing.Point(149, 475);
            this.tableLayoutPanel66.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel66.Name = "tableLayoutPanel66";
            this.tableLayoutPanel66.RowCount = 1;
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel66.Size = new System.Drawing.Size(438, 28);
            this.tableLayoutPanel66.TabIndex = 13;
            // 
            // photoBoothTotal
            // 
            this.photoBoothTotal.AutoSize = true;
            this.photoBoothTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoBoothTotal.Location = new System.Drawing.Point(133, 0);
            this.photoBoothTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.photoBoothTotal.Name = "photoBoothTotal";
            this.photoBoothTotal.Size = new System.Drawing.Size(215, 28);
            this.photoBoothTotal.TabIndex = 0;
            this.photoBoothTotal.Text = "[TOTAL]";
            this.photoBoothTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.photoBoothSettingsPreview);
            this.panel8.Controls.Add(this.tableLayoutPanel67);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(747, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(738, 523);
            this.panel8.TabIndex = 3;
            // 
            // photoBoothSettingsPreview
            // 
            this.photoBoothSettingsPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothSettingsPreview.Location = new System.Drawing.Point(0, 0);
            this.photoBoothSettingsPreview.Name = "photoBoothSettingsPreview";
            this.photoBoothSettingsPreview.Size = new System.Drawing.Size(738, 475);
            this.photoBoothSettingsPreview.TabIndex = 1;
            // 
            // tableLayoutPanel67
            // 
            this.tableLayoutPanel67.ColumnCount = 1;
            this.tableLayoutPanel67.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel67.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel67.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel67.Location = new System.Drawing.Point(0, 475);
            this.tableLayoutPanel67.Name = "tableLayoutPanel67";
            this.tableLayoutPanel67.RowCount = 1;
            this.tableLayoutPanel67.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel67.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel67.Size = new System.Drawing.Size(738, 48);
            this.tableLayoutPanel67.TabIndex = 0;
            // 
            // tableLayoutPanel54
            // 
            this.tableLayoutPanel54.ColumnCount = 7;
            this.tableLayoutPanel54.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel54.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel54.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel54.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel54.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel54.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel54.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel54.Controls.Add(this.photoBoothSettingContinue, 5, 1);
            this.tableLayoutPanel54.Controls.Add(this.photoBoothSettingsBack, 3, 1);
            this.tableLayoutPanel54.Controls.Add(this.photoBoothSettingsCancel, 1, 1);
            this.tableLayoutPanel54.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel54.Location = new System.Drawing.Point(0, 629);
            this.tableLayoutPanel54.Name = "tableLayoutPanel54";
            this.tableLayoutPanel54.RowCount = 3;
            this.tableLayoutPanel54.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel54.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98F));
            this.tableLayoutPanel54.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel54.Size = new System.Drawing.Size(1488, 100);
            this.tableLayoutPanel54.TabIndex = 1;
            // 
            // photoBoothSettingContinue
            // 
            this.photoBoothSettingContinue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothSettingContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoBoothSettingContinue.Location = new System.Drawing.Point(1041, 4);
            this.photoBoothSettingContinue.Name = "photoBoothSettingContinue";
            this.photoBoothSettingContinue.Size = new System.Drawing.Size(291, 92);
            this.photoBoothSettingContinue.TabIndex = 2;
            this.photoBoothSettingContinue.Text = "CONTINUE";
            this.photoBoothSettingContinue.UseVisualStyleBackColor = true;
            // 
            // photoBoothSettingsBack
            // 
            this.photoBoothSettingsBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothSettingsBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoBoothSettingsBack.Location = new System.Drawing.Point(596, 4);
            this.photoBoothSettingsBack.Name = "photoBoothSettingsBack";
            this.photoBoothSettingsBack.Size = new System.Drawing.Size(291, 92);
            this.photoBoothSettingsBack.TabIndex = 0;
            this.photoBoothSettingsBack.Text = "BACK";
            this.photoBoothSettingsBack.UseVisualStyleBackColor = true;
            // 
            // photoBoothSettingsCancel
            // 
            this.photoBoothSettingsCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothSettingsCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoBoothSettingsCancel.Location = new System.Drawing.Point(151, 4);
            this.photoBoothSettingsCancel.Name = "photoBoothSettingsCancel";
            this.photoBoothSettingsCancel.Size = new System.Drawing.Size(291, 92);
            this.photoBoothSettingsCancel.TabIndex = 1;
            this.photoBoothSettingsCancel.Text = "CANCEL";
            this.photoBoothSettingsCancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel50
            // 
            this.tableLayoutPanel50.ColumnCount = 2;
            this.tableLayoutPanel50.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel50.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel50.Controls.Add(this.label29, 0, 0);
            this.tableLayoutPanel50.Controls.Add(this.label30, 1, 0);
            this.tableLayoutPanel50.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel50.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel50.Name = "tableLayoutPanel50";
            this.tableLayoutPanel50.RowCount = 1;
            this.tableLayoutPanel50.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel50.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel50.Size = new System.Drawing.Size(1488, 100);
            this.tableLayoutPanel50.TabIndex = 0;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(3, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(738, 100);
            this.label29.TabIndex = 0;
            this.label29.Text = "PHOTO BOOTH SETTINGS";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(747, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(738, 100);
            this.label30.TabIndex = 1;
            this.label30.Text = "PHOTO PREVIEW";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // funPayment
            // 
            this.funPayment.Controls.Add(this.tableLayoutPanel71);
            this.funPayment.Controls.Add(this.tableLayoutPanel70);
            this.funPayment.Controls.Add(this.tableLayoutPanel69);
            this.funPayment.Controls.Add(this.tableLayoutPanel68);
            this.funPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funPayment.Location = new System.Drawing.Point(0, 0);
            this.funPayment.Name = "funPayment";
            this.funPayment.Size = new System.Drawing.Size(1488, 729);
            this.funPayment.TabIndex = 1;
            // 
            // tableLayoutPanel71
            // 
            this.tableLayoutPanel71.ColumnCount = 2;
            this.tableLayoutPanel71.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel71.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel71.Controls.Add(this.tableLayoutPanel72, 0, 0);
            this.tableLayoutPanel71.Controls.Add(this.tableLayoutPanel73, 1, 0);
            this.tableLayoutPanel71.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel71.Location = new System.Drawing.Point(0, 162);
            this.tableLayoutPanel71.Name = "tableLayoutPanel71";
            this.tableLayoutPanel71.RowCount = 1;
            this.tableLayoutPanel71.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel71.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 467F));
            this.tableLayoutPanel71.Size = new System.Drawing.Size(1488, 467);
            this.tableLayoutPanel71.TabIndex = 3;
            // 
            // tableLayoutPanel72
            // 
            this.tableLayoutPanel72.ColumnCount = 3;
            this.tableLayoutPanel72.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel72.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel72.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel72.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel72.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel72.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel72.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel72.Controls.Add(this.label39, 1, 1);
            this.tableLayoutPanel72.Controls.Add(this.paymentPhotoBoothTotal, 1, 2);
            this.tableLayoutPanel72.Controls.Add(this.label41, 1, 4);
            this.tableLayoutPanel72.Controls.Add(this.paymentPhotoBoothBal, 1, 5);
            this.tableLayoutPanel72.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel72.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel72.Name = "tableLayoutPanel72";
            this.tableLayoutPanel72.RowCount = 7;
            this.tableLayoutPanel72.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel72.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel72.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel72.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel72.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel72.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel72.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel72.Size = new System.Drawing.Size(738, 461);
            this.tableLayoutPanel72.TabIndex = 0;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(150, 65);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(436, 65);
            this.label39.TabIndex = 0;
            this.label39.Text = "TOTAL";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paymentPhotoBoothTotal
            // 
            this.paymentPhotoBoothTotal.AutoSize = true;
            this.paymentPhotoBoothTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentPhotoBoothTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentPhotoBoothTotal.Location = new System.Drawing.Point(150, 130);
            this.paymentPhotoBoothTotal.Name = "paymentPhotoBoothTotal";
            this.paymentPhotoBoothTotal.Size = new System.Drawing.Size(436, 65);
            this.paymentPhotoBoothTotal.TabIndex = 1;
            this.paymentPhotoBoothTotal.Text = "[TOTAL]";
            this.paymentPhotoBoothTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(150, 260);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(436, 65);
            this.label41.TabIndex = 2;
            this.label41.Text = "BALANCE";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paymentPhotoBoothBal
            // 
            this.paymentPhotoBoothBal.AutoSize = true;
            this.paymentPhotoBoothBal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentPhotoBoothBal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentPhotoBoothBal.Location = new System.Drawing.Point(150, 325);
            this.paymentPhotoBoothBal.Name = "paymentPhotoBoothBal";
            this.paymentPhotoBoothBal.Size = new System.Drawing.Size(436, 65);
            this.paymentPhotoBoothBal.TabIndex = 3;
            this.paymentPhotoBoothBal.Text = "[BALANCE]";
            this.paymentPhotoBoothBal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel73
            // 
            this.tableLayoutPanel73.ColumnCount = 3;
            this.tableLayoutPanel73.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel73.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 98F));
            this.tableLayoutPanel73.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel73.Controls.Add(this.qrPaymentPhotoBooth, 1, 1);
            this.tableLayoutPanel73.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel73.Location = new System.Drawing.Point(747, 3);
            this.tableLayoutPanel73.Name = "tableLayoutPanel73";
            this.tableLayoutPanel73.RowCount = 3;
            this.tableLayoutPanel73.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel73.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98F));
            this.tableLayoutPanel73.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel73.Size = new System.Drawing.Size(738, 461);
            this.tableLayoutPanel73.TabIndex = 1;
            // 
            // qrPaymentPhotoBooth
            // 
            this.qrPaymentPhotoBooth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrPaymentPhotoBooth.Location = new System.Drawing.Point(10, 7);
            this.qrPaymentPhotoBooth.Name = "qrPaymentPhotoBooth";
            this.qrPaymentPhotoBooth.Size = new System.Drawing.Size(717, 445);
            this.qrPaymentPhotoBooth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.qrPaymentPhotoBooth.TabIndex = 0;
            this.qrPaymentPhotoBooth.TabStop = false;
            // 
            // tableLayoutPanel70
            // 
            this.tableLayoutPanel70.ColumnCount = 5;
            this.tableLayoutPanel70.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel70.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.tableLayoutPanel70.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel70.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.tableLayoutPanel70.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel70.Controls.Add(this.label43, 3, 0);
            this.tableLayoutPanel70.Controls.Add(this.label44, 1, 0);
            this.tableLayoutPanel70.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel70.Location = new System.Drawing.Point(0, 100);
            this.tableLayoutPanel70.Name = "tableLayoutPanel70";
            this.tableLayoutPanel70.RowCount = 1;
            this.tableLayoutPanel70.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel70.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel70.Size = new System.Drawing.Size(1488, 62);
            this.tableLayoutPanel70.TabIndex = 2;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(783, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(626, 62);
            this.label43.TabIndex = 0;
            this.label43.Text = "SOFT COPY DOWNLOAD";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(77, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(626, 62);
            this.label44.TabIndex = 1;
            this.label44.Text = "HARD COPY PRINTING";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel69
            // 
            this.tableLayoutPanel69.ColumnCount = 7;
            this.tableLayoutPanel69.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel69.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel69.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel69.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel69.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel69.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel69.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel69.Controls.Add(this.paymentPhotoBoothCancelBtn, 1, 1);
            this.tableLayoutPanel69.Controls.Add(this.paymentPhotoBoothBackBtn, 3, 1);
            this.tableLayoutPanel69.Controls.Add(this.paymentPhotoBoothPrintBtn, 5, 1);
            this.tableLayoutPanel69.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel69.Location = new System.Drawing.Point(0, 629);
            this.tableLayoutPanel69.Name = "tableLayoutPanel69";
            this.tableLayoutPanel69.RowCount = 3;
            this.tableLayoutPanel69.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel69.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98F));
            this.tableLayoutPanel69.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel69.Size = new System.Drawing.Size(1488, 100);
            this.tableLayoutPanel69.TabIndex = 1;
            // 
            // paymentPhotoBoothCancelBtn
            // 
            this.paymentPhotoBoothCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentPhotoBoothCancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentPhotoBoothCancelBtn.Location = new System.Drawing.Point(151, 4);
            this.paymentPhotoBoothCancelBtn.Name = "paymentPhotoBoothCancelBtn";
            this.paymentPhotoBoothCancelBtn.Size = new System.Drawing.Size(291, 92);
            this.paymentPhotoBoothCancelBtn.TabIndex = 0;
            this.paymentPhotoBoothCancelBtn.Text = "CANCEL";
            this.paymentPhotoBoothCancelBtn.UseVisualStyleBackColor = true;
            // 
            // paymentPhotoBoothBackBtn
            // 
            this.paymentPhotoBoothBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentPhotoBoothBackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentPhotoBoothBackBtn.Location = new System.Drawing.Point(596, 4);
            this.paymentPhotoBoothBackBtn.Name = "paymentPhotoBoothBackBtn";
            this.paymentPhotoBoothBackBtn.Size = new System.Drawing.Size(291, 92);
            this.paymentPhotoBoothBackBtn.TabIndex = 1;
            this.paymentPhotoBoothBackBtn.Text = "BACK";
            this.paymentPhotoBoothBackBtn.UseVisualStyleBackColor = true;
            // 
            // paymentPhotoBoothPrintBtn
            // 
            this.paymentPhotoBoothPrintBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentPhotoBoothPrintBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentPhotoBoothPrintBtn.Location = new System.Drawing.Point(1041, 4);
            this.paymentPhotoBoothPrintBtn.Name = "paymentPhotoBoothPrintBtn";
            this.paymentPhotoBoothPrintBtn.Size = new System.Drawing.Size(291, 92);
            this.paymentPhotoBoothPrintBtn.TabIndex = 2;
            this.paymentPhotoBoothPrintBtn.Text = "PRINT";
            this.paymentPhotoBoothPrintBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel68
            // 
            this.tableLayoutPanel68.ColumnCount = 1;
            this.tableLayoutPanel68.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel68.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel68.Controls.Add(this.label36, 0, 0);
            this.tableLayoutPanel68.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel68.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel68.Name = "tableLayoutPanel68";
            this.tableLayoutPanel68.RowCount = 1;
            this.tableLayoutPanel68.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel68.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel68.Size = new System.Drawing.Size(1488, 100);
            this.tableLayoutPanel68.TabIndex = 0;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(3, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(1482, 100);
            this.label36.TabIndex = 0;
            this.label36.Text = "PAYMENT";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // retrievalPanelPhoto
            // 
            this.retrievalPanelPhoto.Controls.Add(this.PhotoRetrievePanel);
            this.retrievalPanelPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retrievalPanelPhoto.Location = new System.Drawing.Point(0, 0);
            this.retrievalPanelPhoto.Name = "retrievalPanelPhoto";
            this.retrievalPanelPhoto.Size = new System.Drawing.Size(1488, 729);
            this.retrievalPanelPhoto.TabIndex = 2;
            // 
            // PhotoRetrievePanel
            // 
            this.PhotoRetrievePanel.Controls.Add(this.tableLayoutPanel999);
            this.PhotoRetrievePanel.Controls.Add(this.tableLayoutPanel75);
            this.PhotoRetrievePanel.Controls.Add(this.tableLayoutPanel76);
            this.PhotoRetrievePanel.Controls.Add(this.tableLayoutPanel77);
            this.PhotoRetrievePanel.Controls.Add(this.tableLayoutPanel78);
            this.PhotoRetrievePanel.Controls.Add(this.tableLayoutPanel79);
            this.PhotoRetrievePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PhotoRetrievePanel.Location = new System.Drawing.Point(0, 0);
            this.PhotoRetrievePanel.Margin = new System.Windows.Forms.Padding(2);
            this.PhotoRetrievePanel.Name = "PhotoRetrievePanel";
            this.PhotoRetrievePanel.Size = new System.Drawing.Size(1488, 729);
            this.PhotoRetrievePanel.TabIndex = 2;
            this.PhotoRetrievePanel.Visible = false;
            // 
            // tableLayoutPanel999
            // 
            this.tableLayoutPanel999.ColumnCount = 3;
            this.tableLayoutPanel999.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.20928F));
            this.tableLayoutPanel999.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.58143F));
            this.tableLayoutPanel999.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.20928F));
            this.tableLayoutPanel999.Controls.Add(this.photoRetrievalBtn, 1, 1);
            this.tableLayoutPanel999.Controls.Add(this.photoCancelRetrievalBtn, 1, 3);
            this.tableLayoutPanel999.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel999.Location = new System.Drawing.Point(150, 430);
            this.tableLayoutPanel999.Name = "tableLayoutPanel999";
            this.tableLayoutPanel999.RowCount = 5;
            this.tableLayoutPanel999.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.003002F));
            this.tableLayoutPanel999.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.04805F));
            this.tableLayoutPanel999.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.003002F));
            this.tableLayoutPanel999.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.24324F));
            this.tableLayoutPanel999.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.702703F));
            this.tableLayoutPanel999.Size = new System.Drawing.Size(1188, 218);
            this.tableLayoutPanel999.TabIndex = 5;
            // 
            // photoRetrievalBtn
            // 
            this.photoRetrievalBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoRetrievalBtn.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoRetrievalBtn.Location = new System.Drawing.Point(289, 8);
            this.photoRetrievalBtn.Margin = new System.Windows.Forms.Padding(2);
            this.photoRetrievalBtn.Name = "photoRetrievalBtn";
            this.photoRetrievalBtn.Size = new System.Drawing.Size(608, 100);
            this.photoRetrievalBtn.TabIndex = 2;
            this.photoRetrievalBtn.Text = "RETRIEVE FILE";
            this.photoRetrievalBtn.UseVisualStyleBackColor = true;
            // 
            // photoCancelRetrievalBtn
            // 
            this.photoCancelRetrievalBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoCancelRetrievalBtn.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoCancelRetrievalBtn.Location = new System.Drawing.Point(289, 118);
            this.photoCancelRetrievalBtn.Margin = new System.Windows.Forms.Padding(2);
            this.photoCancelRetrievalBtn.Name = "photoCancelRetrievalBtn";
            this.photoCancelRetrievalBtn.Size = new System.Drawing.Size(608, 90);
            this.photoCancelRetrievalBtn.TabIndex = 3;
            this.photoCancelRetrievalBtn.Text = "CANCEL";
            this.photoCancelRetrievalBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel75
            // 
            this.tableLayoutPanel75.ColumnCount = 3;
            this.tableLayoutPanel75.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.69052F));
            this.tableLayoutPanel75.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.61897F));
            this.tableLayoutPanel75.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.69051F));
            this.tableLayoutPanel75.Controls.Add(this.photoRetrievalCodeBox, 1, 3);
            this.tableLayoutPanel75.Controls.Add(this.label26, 1, 1);
            this.tableLayoutPanel75.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel75.Location = new System.Drawing.Point(150, 81);
            this.tableLayoutPanel75.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel75.Name = "tableLayoutPanel75";
            this.tableLayoutPanel75.RowCount = 4;
            this.tableLayoutPanel75.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.97805F));
            this.tableLayoutPanel75.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.97804F));
            this.tableLayoutPanel75.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.535451F));
            this.tableLayoutPanel75.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.50846F));
            this.tableLayoutPanel75.Size = new System.Drawing.Size(1188, 400);
            this.tableLayoutPanel75.TabIndex = 4;
            // 
            // photoRetrievalCodeBox
            // 
            this.photoRetrievalCodeBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.photoRetrievalCodeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoRetrievalCodeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoRetrievalCodeBox.Location = new System.Drawing.Point(152, 234);
            this.photoRetrievalCodeBox.Margin = new System.Windows.Forms.Padding(2);
            this.photoRetrievalCodeBox.Name = "photoRetrievalCodeBox";
            this.photoRetrievalCodeBox.Size = new System.Drawing.Size(882, 116);
            this.photoRetrievalCodeBox.TabIndex = 0;
            this.photoRetrievalCodeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(152, 103);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(882, 103);
            this.label26.TabIndex = 1;
            this.label26.Text = "ENTER RETRIEVAL CODE";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel76
            // 
            this.tableLayoutPanel76.ColumnCount = 1;
            this.tableLayoutPanel76.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel76.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel76.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel76.Location = new System.Drawing.Point(0, 81);
            this.tableLayoutPanel76.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel76.Name = "tableLayoutPanel76";
            this.tableLayoutPanel76.RowCount = 1;
            this.tableLayoutPanel76.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel76.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 567F));
            this.tableLayoutPanel76.Size = new System.Drawing.Size(150, 567);
            this.tableLayoutPanel76.TabIndex = 3;
            // 
            // tableLayoutPanel77
            // 
            this.tableLayoutPanel77.ColumnCount = 1;
            this.tableLayoutPanel77.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel77.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel77.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel77.Location = new System.Drawing.Point(1338, 81);
            this.tableLayoutPanel77.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel77.Name = "tableLayoutPanel77";
            this.tableLayoutPanel77.RowCount = 1;
            this.tableLayoutPanel77.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel77.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 567F));
            this.tableLayoutPanel77.Size = new System.Drawing.Size(150, 567);
            this.tableLayoutPanel77.TabIndex = 2;
            // 
            // tableLayoutPanel78
            // 
            this.tableLayoutPanel78.ColumnCount = 1;
            this.tableLayoutPanel78.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel78.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel78.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel78.Location = new System.Drawing.Point(0, 648);
            this.tableLayoutPanel78.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel78.Name = "tableLayoutPanel78";
            this.tableLayoutPanel78.RowCount = 1;
            this.tableLayoutPanel78.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel78.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel78.Size = new System.Drawing.Size(1488, 81);
            this.tableLayoutPanel78.TabIndex = 1;
            // 
            // tableLayoutPanel79
            // 
            this.tableLayoutPanel79.ColumnCount = 1;
            this.tableLayoutPanel79.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel79.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel79.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel79.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel79.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel79.Name = "tableLayoutPanel79";
            this.tableLayoutPanel79.RowCount = 1;
            this.tableLayoutPanel79.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel79.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel79.Size = new System.Drawing.Size(1488, 81);
            this.tableLayoutPanel79.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1220, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "5";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn5_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1220, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "10";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn10_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1220, 151);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "20";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btn20_Click);
            // 
            // PrintAndSnap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 729);
            this.Controls.Add(this.startPanel);
            this.Controls.Add(this.printingOptionsPanel);
            this.Controls.Add(this.photoPanel);
            this.Controls.Add(this.printPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PrintAndSnap";
            this.Text = "Printer Vendo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Print_And_Snap_Load);
            this.startPanel.ResumeLayout(false);
            this.startText.ResumeLayout(false);
            this.startText.PerformLayout();
            this.startButtonLayout.ResumeLayout(false);
            this.startTitle.ResumeLayout(false);
            this.startTitle.PerformLayout();
            this.uploadPanel.ResumeLayout(false);
            this.uploadInstructionPanel.ResumeLayout(false);
            this.uploadMainLayout.ResumeLayout(false);
            this.qrpanelLayout.ResumeLayout(false);
            this.tableLayoutPanel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qrPictureBox)).EndInit();
            this.Instructions.ResumeLayout(false);
            this.tableLayoutPanel19.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel20.ResumeLayout(false);
            this.tableLayoutPanel20.PerformLayout();
            this.tableLayoutPanel21.ResumeLayout(false);
            this.tableLayoutPanel21.PerformLayout();
            this.statusLabel.ResumeLayout(false);
            this.statusLabel.PerformLayout();
            this.instructionTitle.ResumeLayout(false);
            this.instructionTitle.PerformLayout();
            this.uploadQrPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.qrInstructions.ResumeLayout(false);
            this.qrInstructions.PerformLayout();
            this.qrTitleLayout.ResumeLayout(false);
            this.qrTitleLayout.PerformLayout();
            this.uploadBottom.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.continuePanel.ResumeLayout(false);
            this.printingSettingsPanel.ResumeLayout(false);
            this.settingsPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.printSettingsPanelLayout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSinglePage)).EndInit();
            this.copiesLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericCopies)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.filePreviewPanel.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.paymentPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPayment.ResumeLayout(false);
            this.tableLayoutPayment.PerformLayout();
            this.tableLayoutPanel17.ResumeLayout(false);
            this.paymentTableTitle.ResumeLayout(false);
            this.paymentTableTitle.PerformLayout();
            this.paymentBottom.ResumeLayout(false);
            this.paymentBottom.PerformLayout();
            this.retrivalPanel.ResumeLayout(false);
            this.buttonsLayout.ResumeLayout(false);
            this.retrivalMain.ResumeLayout(false);
            this.retrivalMain.PerformLayout();
            this.printingOptionsPanel.ResumeLayout(false);
            this.printingPanelTitle.ResumeLayout(false);
            this.printingPanelTitle.PerformLayout();
            this.MainPrintingPanel.ResumeLayout(false);
            this.printPanel.ResumeLayout(false);
            this.photoPanel.ResumeLayout(false);
            this.photoIDPanel.ResumeLayout(false);
            this.idPrintingSettings.ResumeLayout(false);
            this.IDpayment.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel47.ResumeLayout(false);
            this.tableLayoutPanel53.ResumeLayout(false);
            this.tableLayoutPanel53.PerformLayout();
            this.tableLayoutPanel52.ResumeLayout(false);
            this.tableLayoutPanel51.ResumeLayout(false);
            this.tableLayoutPanel51.PerformLayout();
            this.softCopyDownloadId.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qrIdPrintingDownload)).EndInit();
            this.tableLayoutPanel41.ResumeLayout(false);
            this.tableLayoutPanel41.PerformLayout();
            this.tableLayoutPanel39.ResumeLayout(false);
            this.IDsettings.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel35.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel36.ResumeLayout(false);
            this.tableLayoutPanel36.PerformLayout();
            this.tableLayoutPanel43.ResumeLayout(false);
            this.tableLayoutPanel43.PerformLayout();
            this.tableLayoutPanel42.ResumeLayout(false);
            this.tableLayoutPanel42.PerformLayout();
            this.tableLayoutPanel40.ResumeLayout(false);
            this.tableLayoutPanel40.PerformLayout();
            this.tableLayoutPanel37.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericIdPrintingCopies)).EndInit();
            this.tableLayoutPanel45.ResumeLayout(false);
            this.tableLayoutPanel45.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsPicturePreview)).EndInit();
            this.tableLayoutPanel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idPrintPreviewMini)).EndInit();
            this.tableLayoutPanel46.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture4)).EndInit();
            this.tableLayoutPanel34.ResumeLayout(false);
            this.tableLayoutPanel33.ResumeLayout(false);
            this.tableLayoutPanel33.PerformLayout();
            this.panelCRMidPrinting.ResumeLayout(false);
            this.tableLayoutPanel27.ResumeLayout(false);
            this.tableLayoutPanel28.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idCameraFeed)).EndInit();
            this.tableLayoutPanel25.ResumeLayout(false);
            this.tableLayoutPanel25.PerformLayout();
            this.tableLayoutPanel26.ResumeLayout(false);
            this.tableLayoutPanel26.PerformLayout();
            this.photoMode.ResumeLayout(false);
            this.phototop.ResumeLayout(false);
            this.phototop.PerformLayout();
            this.buttonLayoutPhoto.ResumeLayout(false);
            this.tableLayoutPanel22.ResumeLayout(false);
            this.tableLayoutPanel23.ResumeLayout(false);
            this.tableLayoutPanel24.ResumeLayout(false);
            this.photoBoothPanel.ResumeLayout(false);
            this.panelCMRphotoBooth.ResumeLayout(false);
            this.tableLayoutPanel31.ResumeLayout(false);
            this.tableLayoutPanel32.ResumeLayout(false);
            this.tableLayoutPanel29.ResumeLayout(false);
            this.tableLayoutPanel29.PerformLayout();
            this.tableLayoutPanel30.ResumeLayout(false);
            this.photoBoothSettings.ResumeLayout(false);
            this.funSettings.ResumeLayout(false);
            this.tableLayoutPanel55.ResumeLayout(false);
            this.tableLayoutPanel56.ResumeLayout(false);
            this.tableLayoutPanel56.PerformLayout();
            this.tableLayoutPanel57.ResumeLayout(false);
            this.tableLayoutPanel57.PerformLayout();
            this.tableLayoutPanel58.ResumeLayout(false);
            this.tableLayoutPanel58.PerformLayout();
            this.tableLayoutPanel59.ResumeLayout(false);
            this.tableLayoutPanel59.PerformLayout();
            this.tableLayoutPanel60.ResumeLayout(false);
            this.tableLayoutPanel60.PerformLayout();
            this.tableLayoutPanel61.ResumeLayout(false);
            this.tableLayoutPanel61.PerformLayout();
            this.tableLayoutPanel62.ResumeLayout(false);
            this.tableLayoutPanel62.PerformLayout();
            this.tableLayoutPanel63.ResumeLayout(false);
            this.tableLayoutPanel63.PerformLayout();
            this.tableLayoutPanel64.ResumeLayout(false);
            this.tableLayoutPanel64.PerformLayout();
            this.tableLayoutPanel65.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.photoBoothNumeriCopies)).EndInit();
            this.tableLayoutPanel66.ResumeLayout(false);
            this.tableLayoutPanel66.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.tableLayoutPanel54.ResumeLayout(false);
            this.tableLayoutPanel50.ResumeLayout(false);
            this.tableLayoutPanel50.PerformLayout();
            this.funPayment.ResumeLayout(false);
            this.tableLayoutPanel71.ResumeLayout(false);
            this.tableLayoutPanel72.ResumeLayout(false);
            this.tableLayoutPanel72.PerformLayout();
            this.tableLayoutPanel73.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qrPaymentPhotoBooth)).EndInit();
            this.tableLayoutPanel70.ResumeLayout(false);
            this.tableLayoutPanel70.PerformLayout();
            this.tableLayoutPanel69.ResumeLayout(false);
            this.tableLayoutPanel68.ResumeLayout(false);
            this.tableLayoutPanel68.PerformLayout();
            this.retrievalPanelPhoto.ResumeLayout(false);
            this.PhotoRetrievePanel.ResumeLayout(false);
            this.tableLayoutPanel999.ResumeLayout(false);
            this.tableLayoutPanel75.ResumeLayout(false);
            this.tableLayoutPanel75.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel startPanel;
        private System.Windows.Forms.TableLayoutPanel startTop;
        private System.Windows.Forms.Panel uploadPanel;
        private System.Windows.Forms.Panel printingSettingsPanel;
        private System.Windows.Forms.TableLayoutPanel startRight;
        private System.Windows.Forms.TableLayoutPanel startBottom;
        private System.Windows.Forms.TableLayoutPanel startButtonLayout;
        private System.Windows.Forms.TableLayoutPanel startTitle;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TableLayoutPanel startLeft;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TableLayoutPanel startText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel uploadQrPanel;
        private System.Windows.Forms.Panel uploadInstructionPanel;
        private System.Windows.Forms.TableLayoutPanel uploadBottom;
        private System.Windows.Forms.TableLayoutPanel continuePanel;
        private System.Windows.Forms.Button continueBtn;
        private System.Windows.Forms.TableLayoutPanel instructionTitle;
        private System.Windows.Forms.Label uploadFile;
        private System.Windows.Forms.TableLayoutPanel statusLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button qrBackBtn;
        private System.Windows.Forms.TableLayoutPanel qrInstructions;
        private System.Windows.Forms.TableLayoutPanel qrTitleLayout;
        private System.Windows.Forms.Label qrTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label qrInstruction1;
        private System.Windows.Forms.Label qrInstruction2;
        private System.Windows.Forms.Label qrInstruction3;
        private System.Windows.Forms.Label qrInstruction4;
        private System.Windows.Forms.Label qrInstruction5;
        private System.Windows.Forms.Timer receiveTimer;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Panel paymentPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button continuePaymentBtn;
        private System.Windows.Forms.Button settingsBackBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label copiesLabel;
        private System.Windows.Forms.Label selectPageLabel;
        private System.Windows.Forms.Label totalPagesLabelLabel;
        private System.Windows.Forms.Label totalLabelLabel;
        private System.Windows.Forms.NumericUpDown numericCopies;
        private System.Windows.Forms.Label totalPagesLabel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.NumericUpDown numericSinglePage;
        private System.Windows.Forms.TextBox numericPageRange;
        private System.Windows.Forms.Label paperColor;
        private System.Windows.Forms.RadioButton radioBlackWhite;
        private System.Windows.Forms.RadioButton radioColored;
        private System.Windows.Forms.Panel filePreviewPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.Panel previewPanelSettingLayout;
        private System.Windows.Forms.PictureBox qrPictureBox;
        private System.Windows.Forms.TableLayoutPanel paymentBottom;
        private System.Windows.Forms.TableLayoutPanel paymentTop;
        private System.Windows.Forms.TableLayoutPanel paymentTableTitle;
        private System.Windows.Forms.TableLayoutPanel paymentRight;
        private System.Windows.Forms.TableLayoutPanel paymentLeft;
        private System.Windows.Forms.Label paymentTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPayment;
        private System.Windows.Forms.Label balancePaymentLabel;
        private System.Windows.Forms.Label paymentTotalLabel;
        private System.Windows.Forms.Button cancelPrintBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Label totalPayment;
        private System.Windows.Forms.Label paymentBalance;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Button btn20;
        private System.Windows.Forms.Label printingStatusLabel;
        private System.Windows.Forms.Panel retrivalPanel;
        private System.Windows.Forms.TableLayoutPanel retrivalMain;
        private System.Windows.Forms.TableLayoutPanel retrivalLeft;
        private System.Windows.Forms.TableLayoutPanel retrivalRight;
        private System.Windows.Forms.TableLayoutPanel retrivalBottom;
        private System.Windows.Forms.TableLayoutPanel retrivalTop;
        private System.Windows.Forms.Label retrivalCodeLabel;
        private System.Windows.Forms.Button loadRetrievalBtn;
        private System.Windows.Forms.Button retrieveCancelBtn;
        private System.Windows.Forms.Label printerStatusLabel;
        private System.Windows.Forms.Button paymentBackBtn;
        private System.Windows.Forms.Button printSettingsCancelBtn;
        private System.Windows.Forms.Label fileUploadStatusLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Button uploadCancelBtn;
        private System.Windows.Forms.Panel printingOptionsPanel;
        private System.Windows.Forms.TableLayoutPanel printingPanelLeft;
        private System.Windows.Forms.TableLayoutPanel printingPanelRight;
        private System.Windows.Forms.TableLayoutPanel printingPanelBottom;
        private System.Windows.Forms.TableLayoutPanel printingPanelTop;
        private System.Windows.Forms.TableLayoutPanel MainPrintingPanel;
        private System.Windows.Forms.Button docPrintingBtn;
        private System.Windows.Forms.Button photoPrintingBtn;
        private System.Windows.Forms.TableLayoutPanel printingPanelTitle;
        private System.Windows.Forms.Label printingTitleLabel;
        private System.Windows.Forms.Panel printPanel;
        private System.Windows.Forms.Panel photoPanel;
        private System.Windows.Forms.Button retrievalBtn;
        private System.Windows.Forms.TableLayoutPanel buttonsLayout;
        private System.Windows.Forms.TextBox retrivalCodeTextBox;
        private System.Windows.Forms.Panel printSettingsPanelLayout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel copiesLayout;
        private System.Windows.Forms.Label printerStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel uploadMainLayout;
        private System.Windows.Forms.Panel qrpanelLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.Panel Instructions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel21;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel20;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TableLayoutPanel phototop;
        private System.Windows.Forms.TableLayoutPanel buttonLayoutPhoto;
        private System.Windows.Forms.Button photoBtnRetrieve;
        private System.Windows.Forms.Button photoModeCancelBtn;
        private System.Windows.Forms.Label photoLabelTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel22;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel23;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel24;
        private System.Windows.Forms.Button photoBtnPhotoBooth;
        private System.Windows.Forms.Button photoBtnID;
        private System.Windows.Forms.Panel photoIDPanel;
        private System.Windows.Forms.Panel photoBoothPanel;
        private System.Windows.Forms.Panel photoMode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel25;
        private System.Windows.Forms.Label photoIDtitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel26;
        private System.Windows.Forms.Button idPrintingCancelBtn;
        private System.Windows.Forms.Button idCapctureAgainBtn;
        private System.Windows.Forms.Button idPrintingContinueBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel27;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel29;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel30;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel28;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel31;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button photoBoothCaptureBtn;
        private System.Windows.Forms.Button photoBoothContinueBtn;
        private System.Windows.Forms.Button photoBoothCancelBtn;
        private System.Windows.Forms.Panel photoBoothCameraPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel32;
        private System.Windows.Forms.Panel photoBoothPreviewPanel;
        private System.Windows.Forms.Panel panelCRMidPrinting;
        private System.Windows.Forms.Panel panelCMRphotoBooth;
        private System.Windows.Forms.Panel idPrintingSettings;
        private System.Windows.Forms.Panel IDsettings;
        private System.Windows.Forms.Panel photoBoothSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel34;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel33;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel35;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel36;
        private System.Windows.Forms.Label idPrintingCopies;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel37;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel40;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel42;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel43;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel45;
        private System.Windows.Forms.NumericUpDown numericIdPrintingCopies;
        private System.Windows.Forms.RadioButton radioBtn2x2;
        private System.Windows.Forms.RadioButton radioBtn1x1;
        private System.Windows.Forms.RadioButton radioBtn2x1;
        private System.Windows.Forms.RadioButton radioBtnSinglePhotoCopies;
        private System.Windows.Forms.RadioButton radioBtnMultipleCopies;
        private System.Windows.Forms.RadioButton radioBtnPhotoBlack;
        private System.Windows.Forms.RadioButton radioBtnPhotoColored;
        private System.Windows.Forms.Label idPrintingTotal;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel46;
        private System.Windows.Forms.Button idPrintSettingsCancelBtn;
        private System.Windows.Forms.Button idPrintSettingsBackBtn;
        private System.Windows.Forms.Button idPrintSettingsConintueBtn;
        private System.Windows.Forms.Panel IDpayment;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel51;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel52;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel47;
        private System.Windows.Forms.Button cancelBtnPaymentId;
        private System.Windows.Forms.Button backBtnPaymentId;
        private System.Windows.Forms.Button printBtnPaymentId;
        private System.Windows.Forms.Panel funPayment;
        private System.Windows.Forms.Panel funSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel54;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel50;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel55;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel56;
        private System.Windows.Forms.Button photoBoothSettingsBack;
        private System.Windows.Forms.Button photoBoothSettingsCancel;
        private System.Windows.Forms.Button photoBoothSettingContinue;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel57;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel58;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel59;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel60;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel61;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel62;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel63;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel64;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel65;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel66;
        private System.Windows.Forms.NumericUpDown photoBoothNumeriCopies;
        private System.Windows.Forms.Label photoBoothTotal;
        private System.Windows.Forms.RadioButton radioBtnVerticalPB;
        private System.Windows.Forms.RadioButton radioBtnGridBtnPB;
        private System.Windows.Forms.RadioButton radioBtnNonePB;
        private System.Windows.Forms.RadioButton radioBtnMinimalPB;
        private System.Windows.Forms.RadioButton radioBtnCutePB;
        private System.Windows.Forms.RadioButton radioBtbFilterNonePB;
        private System.Windows.Forms.RadioButton radioBtnBlackAndWhitePB;
        private System.Windows.Forms.RadioButton radioBtnWarmPB;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel photoBoothSettingsPreview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel67;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel69;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel68;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button paymentPhotoBoothCancelBtn;
        private System.Windows.Forms.Button paymentPhotoBoothBackBtn;
        private System.Windows.Forms.Button paymentPhotoBoothPrintBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel70;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel71;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel72;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel73;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label paymentPhotoBoothTotal;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label paymentPhotoBoothBal;
        private System.Windows.Forms.PictureBox qrPaymentPhotoBooth;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Panel retrievalPanelPhoto;
        private System.Windows.Forms.Panel PhotoRetrievePanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel999;
        private System.Windows.Forms.Button photoRetrievalBtn;
        private System.Windows.Forms.Button photoCancelRetrievalBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel75;
        private System.Windows.Forms.TextBox photoRetrievalCodeBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel76;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel77;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel78;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel79;
        private System.Windows.Forms.RadioButton radioSinglePage;
        private System.Windows.Forms.RadioButton radioPrintRange;
        private System.Windows.Forms.RadioButton radioPrintAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.PictureBox idPreviewPictureBox1;
        private System.Windows.Forms.PictureBox idCameraFeed;
        private System.Windows.Forms.Button idCaptureBtn;
        private System.Windows.Forms.PictureBox idPreviewPictureBox2;
        private System.Windows.Forms.PictureBox idPreviewPictureBox3;
        private System.Windows.Forms.PictureBox idPreviewPictureBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.PictureBox idSettingsPicturePreview;
        private System.Windows.Forms.PictureBox idSettingsSelectPicture1;
        private System.Windows.Forms.PictureBox idSettingsSelectPicture2;
        private System.Windows.Forms.PictureBox idSettingsSelectPicture3;
        private System.Windows.Forms.PictureBox idSettingsSelectPicture4;
        private System.Windows.Forms.Label CameraTimer;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.PictureBox idPrintPreviewMini;
        private System.Windows.Forms.Panel softCopyDownloadId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel53;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label paymentIDprintingTotal;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label paymentIDprintingBalance;
        private System.Windows.Forms.Button downloadBtnPaymentId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel41;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel39;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel38;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.PictureBox qrIdPrintingDownload;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button downloadBackBtn;
        private System.Windows.Forms.Button downloadCancelBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}