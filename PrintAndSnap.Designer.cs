using InTheHand.Net;
using InTheHand.Net.Sockets;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using FontAwesome.Sharp;

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
            this.panel13 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel73 = new System.Windows.Forms.TableLayoutPanel();
            this.label = new System.Windows.Forms.Label();
            this.tableLayoutPanel67 = new System.Windows.Forms.TableLayoutPanel();
            this.startBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel64 = new System.Windows.Forms.TableLayoutPanel();
            this.printingOptionsPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel74 = new System.Windows.Forms.TableLayoutPanel();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.MainPrintingPanel = new System.Windows.Forms.TableLayoutPanel();
            this.photoPrintingBtn = new System.Windows.Forms.Button();
            this.docPrintingBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.printPanel = new System.Windows.Forms.Panel();
            this.printingSettingsPanel = new System.Windows.Forms.Panel();
            this.paymentPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPayment = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel104 = new System.Windows.Forms.TableLayoutPanel();
            this.cancelPrintBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.paymentBackBtn = new System.Windows.Forms.Button();
            this.panel22 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel103 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel102 = new System.Windows.Forms.TableLayoutPanel();
            this.printingStatusLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel101 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel100 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel98 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel105 = new System.Windows.Forms.TableLayoutPanel();
            this.paymentDocTotal = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.tableLayoutPanel106 = new System.Windows.Forms.TableLayoutPanel();
            this.paymentDocBalance = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tableLayoutPanel107 = new System.Windows.Forms.TableLayoutPanel();
            this.totalDocInserted = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.tableLayoutPanel140 = new System.Windows.Forms.TableLayoutPanel();
            this.totalDocChange = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uploadPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.instructionLabelDocs = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.qrPictureBox = new System.Windows.Forms.PictureBox();
            this.uploadMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.uploadCancelBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.fileUploadStatusLabel = new System.Windows.Forms.Label();
            this.retrievalBtn = new System.Windows.Forms.Button();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.numericPageRange = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.numericSinglePage = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel93 = new System.Windows.Forms.TableLayoutPanel();
            this.radioColored = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel94 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel81 = new System.Windows.Forms.TableLayoutPanel();
            this.radioSinglePage = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.numericCopies = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel80 = new System.Windows.Forms.TableLayoutPanel();
            this.radioPrintRange = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel86 = new System.Windows.Forms.TableLayoutPanel();
            this.selectPageLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.radioPrintAll = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel87 = new System.Windows.Forms.TableLayoutPanel();
            this.paperColor = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel95 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel96 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel85 = new System.Windows.Forms.TableLayoutPanel();
            this.copiesLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioBlackWhite = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel90 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel88 = new System.Windows.Forms.TableLayoutPanel();
            this.totalLabelLabel = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel91 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            this.printerStatus = new System.Windows.Forms.Label();
            this.printerStatusLabel = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel24 = new System.Windows.Forms.TableLayoutPanel();
            this.totalPagesLabel = new System.Windows.Forms.Label();
            this.totalPagesLabelLabel = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel89 = new System.Windows.Forms.TableLayoutPanel();
            this.totalLabel = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel92 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel83 = new System.Windows.Forms.TableLayoutPanel();
            this.editBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel82 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel84 = new System.Windows.Forms.TableLayoutPanel();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pagesPreviewLabel = new System.Windows.Forms.Label();
            this.filesizepreview = new System.Windows.Forms.Label();
            this.previewPanelSettingLayout = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.continuePaymentBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel77 = new System.Windows.Forms.TableLayoutPanel();
            this.settingsBackBtn = new System.Windows.Forms.Button();
            this.printSettingsCancelBtn = new System.Windows.Forms.Button();
            this.retrivalPanel = new System.Windows.Forms.Panel();
            this.retrivalMain = new System.Windows.Forms.TableLayoutPanel();
            this.retrivalCodeLabel = new System.Windows.Forms.Label();
            this.retrivalCodeTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel97 = new System.Windows.Forms.TableLayoutPanel();
            this.retrieveCancelBtn = new System.Windows.Forms.Button();
            this.loadRetrievalBtn = new System.Windows.Forms.Button();
            this.continuePanel = new System.Windows.Forms.TableLayoutPanel();
            this.continueBtn = new System.Windows.Forms.Button();
            this.photoPanel = new System.Windows.Forms.Panel();
            this.photoIDPanel = new System.Windows.Forms.Panel();
            this.IDpayment = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel51 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel47 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel53 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel125 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel52 = new System.Windows.Forms.TableLayoutPanel();
            this.cancelBtnPaymentId = new System.Windows.Forms.Button();
            this.backBtnPaymentId = new System.Windows.Forms.Button();
            this.downloadBtnPaymentId = new System.Windows.Forms.Button();
            this.printBtnPaymentId = new System.Windows.Forms.Button();
            this.panel20 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel126 = new System.Windows.Forms.TableLayoutPanel();
            this.idprintingStatusLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel123 = new System.Windows.Forms.TableLayoutPanel();
            this.label27 = new System.Windows.Forms.Label();
            this.paymentIDBalance = new System.Windows.Forms.Label();
            this.tableLayoutPanel127 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel113 = new System.Windows.Forms.TableLayoutPanel();
            this.paymentIDTotal = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tableLayoutPanel128 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel129 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel130 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel131 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLayoutPanel124 = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.paymentInsertedID = new System.Windows.Forms.Label();
            this.tableLayoutPanel132 = new System.Windows.Forms.TableLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.paymentChangeID = new System.Windows.Forms.Label();
            this.panelCRMidPrinting = new System.Windows.Forms.Panel();
            this.tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel28 = new System.Windows.Forms.TableLayoutPanel();
            this.idCameraFeed = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel25 = new System.Windows.Forms.TableLayoutPanel();
            this.idPreviewPictureBox4 = new System.Windows.Forms.PictureBox();
            this.idPreviewPictureBox3 = new System.Windows.Forms.PictureBox();
            this.idPreviewPictureBox2 = new System.Windows.Forms.PictureBox();
            this.idPreviewPictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel26 = new System.Windows.Forms.TableLayoutPanel();
            this.idPrintingCancelBtn = new System.Windows.Forms.Button();
            this.idCaptureBtn = new System.Windows.Forms.Button();
            this.idPrintingContinueBtn = new System.Windows.Forms.Button();
            this.idCapctureAgainBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel32 = new System.Windows.Forms.TableLayoutPanel();
            this.idPrintingSettings = new System.Windows.Forms.Panel();
            this.IDsettings = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel36 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel37 = new System.Windows.Forms.TableLayoutPanel();
            this.idPrintPreviewMini = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.idSettingsPicturePreview = new System.Windows.Forms.PictureBox();
            this.panel21 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel33 = new System.Windows.Forms.TableLayoutPanel();
            this.idSettingsSelectPicture4 = new System.Windows.Forms.PictureBox();
            this.idSettingsSelectPicture3 = new System.Windows.Forms.PictureBox();
            this.idSettingsSelectPicture2 = new System.Windows.Forms.PictureBox();
            this.idSettingsSelectPicture1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel35 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel38 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel41 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel46 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel70 = new System.Windows.Forms.TableLayoutPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.tableLayoutPanel133 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtn2x1 = new System.Windows.Forms.RadioButton();
            this.radioBtn1x1 = new System.Windows.Forms.RadioButton();
            this.radioBtn2x2 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel134 = new System.Windows.Forms.TableLayoutPanel();
            this.label21 = new System.Windows.Forms.Label();
            this.tableLayoutPanel135 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtnMultipleCopies = new System.Windows.Forms.RadioButton();
            this.radioBtnSinglePhotoCopies = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel136 = new System.Windows.Forms.TableLayoutPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.tableLayoutPanel137 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtnPhotoColored = new System.Windows.Forms.RadioButton();
            this.radioBtnPhotoBlack = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel139 = new System.Windows.Forms.TableLayoutPanel();
            this.numericIdPrintingCopies = new System.Windows.Forms.NumericUpDown();
            this.idPrintingCopies = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.idPrintingTotal = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tableLayoutPanel34 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel40 = new System.Windows.Forms.TableLayoutPanel();
            this.idPrintSettingsCancelBtn = new System.Windows.Forms.Button();
            this.idPrintSettingsBackBtn = new System.Windows.Forms.Button();
            this.idPrintSettingsConintueBtn = new System.Windows.Forms.Button();
            this.softCopyDownloadId = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel39 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.downloadBackBtn = new System.Windows.Forms.Button();
            this.downloadCancelBtn = new System.Windows.Forms.Button();
            this.qrIdPrintingDownload = new System.Windows.Forms.PictureBox();
            this.label28 = new System.Windows.Forms.Label();
            this.photoBoothPanel = new System.Windows.Forms.Panel();
            this.funPaymentPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel111 = new System.Windows.Forms.TableLayoutPanel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel72 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel114 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel71 = new System.Windows.Forms.TableLayoutPanel();
            this.funDownloadBtn = new System.Windows.Forms.Button();
            this.paymentFunBackBtn = new System.Windows.Forms.Button();
            this.paymentFunPrintBtn = new System.Windows.Forms.Button();
            this.paymentFunCancelBtn = new System.Windows.Forms.Button();
            this.panel19 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel115 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel116 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel69 = new System.Windows.Forms.TableLayoutPanel();
            this.label41 = new System.Windows.Forms.Label();
            this.paymentFunBalance = new System.Windows.Forms.Label();
            this.tableLayoutPanel68 = new System.Windows.Forms.TableLayoutPanel();
            this.label39 = new System.Windows.Forms.Label();
            this.paymentFunTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel117 = new System.Windows.Forms.TableLayoutPanel();
            this.funPrintingStatusLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel118 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel119 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel120 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel121 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.paymentFunInserted = new System.Windows.Forms.Label();
            this.tableLayoutPanel122 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.paymentFunChange = new System.Windows.Forms.Label();
            this.panelCMRphotoBooth = new System.Windows.Forms.Panel();
            this.tableLayoutPanel31 = new System.Windows.Forms.TableLayoutPanel();
            this.funCaptureAgainBtn = new System.Windows.Forms.Button();
            this.funCameraFeed = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel29 = new System.Windows.Forms.TableLayoutPanel();
            this.funPreview4 = new System.Windows.Forms.PictureBox();
            this.funPreview3 = new System.Windows.Forms.PictureBox();
            this.funPreview2 = new System.Windows.Forms.PictureBox();
            this.funPreview1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel30 = new System.Windows.Forms.TableLayoutPanel();
            this.funCaptureBtn = new System.Windows.Forms.Button();
            this.funCancelBtn = new System.Windows.Forms.Button();
            this.funContinueBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel79 = new System.Windows.Forms.TableLayoutPanel();
            this.photoBoothSettings = new System.Windows.Forms.Panel();
            this.funSettings = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel58 = new System.Windows.Forms.TableLayoutPanel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel59 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel60 = new System.Windows.Forms.TableLayoutPanel();
            this.funMiniPreview = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.funMainPreview = new System.Windows.Forms.PictureBox();
            this.panel18 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel112 = new System.Windows.Forms.TableLayoutPanel();
            this.funSelectPic4 = new System.Windows.Forms.PictureBox();
            this.funSelectPic1 = new System.Windows.Forms.PictureBox();
            this.funSelectPic3 = new System.Windows.Forms.PictureBox();
            this.funSelectPic2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel56 = new System.Windows.Forms.TableLayoutPanel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel66 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel62 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel61 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel43 = new System.Windows.Forms.TableLayoutPanel();
            this.funRadioBtnWarm = new System.Windows.Forms.RadioButton();
            this.funRadioBtnBlack = new System.Windows.Forms.RadioButton();
            this.funRadioBtnFilterNone = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel57 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel55 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel63 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel138 = new System.Windows.Forms.TableLayoutPanel();
            this.funRadioPrintTypeSingle = new System.Windows.Forms.RadioButton();
            this.funRadioPrintTypeAll = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel78 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel109 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel49 = new System.Windows.Forms.TableLayoutPanel();
            this.funRadioBtnCute = new System.Windows.Forms.RadioButton();
            this.funRadioBtnMinimal = new System.Windows.Forms.RadioButton();
            this.funRadioBtnFrameNone = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel45 = new System.Windows.Forms.TableLayoutPanel();
            this.funRadioBtnVertical = new System.Windows.Forms.RadioButton();
            this.funRadioBtnGridBtn = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel141 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel143 = new System.Windows.Forms.TableLayoutPanel();
            this.funNumericCopies = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel50 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel110 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel65 = new System.Windows.Forms.TableLayoutPanel();
            this.funTotal = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel54 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel42 = new System.Windows.Forms.TableLayoutPanel();
            this.funSettingsCancelBtn = new System.Windows.Forms.Button();
            this.funSettingsBackBtn = new System.Windows.Forms.Button();
            this.funSettingContinueBtn = new System.Windows.Forms.Button();
            this.funSoftCopyDownloadPanel = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel48 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel44 = new System.Windows.Forms.TableLayoutPanel();
            this.funSoftCopyBackBtn = new System.Windows.Forms.Button();
            this.funSoftCopyCancelBtn = new System.Windows.Forms.Button();
            this.qrSoftCopyDownloadFun = new System.Windows.Forms.PictureBox();
            this.label24 = new System.Windows.Forms.Label();
            this.photoMode = new System.Windows.Forms.Panel();
            this.tableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            this.instructionLabelPhoto = new System.Windows.Forms.Label();
            this.tableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            this.photoBtnFun = new System.Windows.Forms.Button();
            this.photoBtnID = new System.Windows.Forms.Button();
            this.photoModeCancelBtn = new System.Windows.Forms.Button();
            this.photoBtnRetrieve = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.retrievalPanelPhoto = new System.Windows.Forms.Panel();
            this.PhotoRetrievePanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel75 = new System.Windows.Forms.TableLayoutPanel();
            this.label26 = new System.Windows.Forms.Label();
            this.tableLayoutPanel76 = new System.Windows.Forms.TableLayoutPanel();
            this.photoCancelRetrievalBtn = new System.Windows.Forms.Button();
            this.photoRetrievalBtn = new System.Windows.Forms.Button();
            this.photoRetrievalCodeBox = new System.Windows.Forms.TextBox();
            this.startPanel.SuspendLayout();
            this.panel13.SuspendLayout();
            this.tableLayoutPanel73.SuspendLayout();
            this.tableLayoutPanel67.SuspendLayout();
            this.printingOptionsPanel.SuspendLayout();
            this.tableLayoutPanel74.SuspendLayout();
            this.MainPrintingPanel.SuspendLayout();
            this.printPanel.SuspendLayout();
            this.printingSettingsPanel.SuspendLayout();
            this.paymentPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPayment.SuspendLayout();
            this.tableLayoutPanel104.SuspendLayout();
            this.panel22.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.tableLayoutPanel105.SuspendLayout();
            this.tableLayoutPanel106.SuspendLayout();
            this.tableLayoutPanel107.SuspendLayout();
            this.tableLayoutPanel140.SuspendLayout();
            this.uploadPanel.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrPictureBox)).BeginInit();
            this.uploadMainLayout.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSinglePage)).BeginInit();
            this.tableLayoutPanel81.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCopies)).BeginInit();
            this.tableLayoutPanel80.SuspendLayout();
            this.tableLayoutPanel86.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel87.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tableLayoutPanel85.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel88.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.tableLayoutPanel20.SuspendLayout();
            this.tableLayoutPanel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.tableLayoutPanel19.SuspendLayout();
            this.tableLayoutPanel24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tableLayoutPanel89.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.tableLayoutPanel16.SuspendLayout();
            this.panel14.SuspendLayout();
            this.tableLayoutPanel92.SuspendLayout();
            this.tableLayoutPanel83.SuspendLayout();
            this.tableLayoutPanel82.SuspendLayout();
            this.tableLayoutPanel84.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel77.SuspendLayout();
            this.retrivalPanel.SuspendLayout();
            this.retrivalMain.SuspendLayout();
            this.tableLayoutPanel97.SuspendLayout();
            this.continuePanel.SuspendLayout();
            this.photoPanel.SuspendLayout();
            this.photoIDPanel.SuspendLayout();
            this.IDpayment.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel51.SuspendLayout();
            this.tableLayoutPanel47.SuspendLayout();
            this.tableLayoutPanel53.SuspendLayout();
            this.tableLayoutPanel125.SuspendLayout();
            this.tableLayoutPanel52.SuspendLayout();
            this.panel20.SuspendLayout();
            this.tableLayoutPanel126.SuspendLayout();
            this.tableLayoutPanel123.SuspendLayout();
            this.tableLayoutPanel113.SuspendLayout();
            this.tableLayoutPanel124.SuspendLayout();
            this.tableLayoutPanel132.SuspendLayout();
            this.panelCRMidPrinting.SuspendLayout();
            this.tableLayoutPanel27.SuspendLayout();
            this.panel15.SuspendLayout();
            this.tableLayoutPanel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idCameraFeed)).BeginInit();
            this.tableLayoutPanel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox1)).BeginInit();
            this.tableLayoutPanel26.SuspendLayout();
            this.idPrintingSettings.SuspendLayout();
            this.IDsettings.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tableLayoutPanel36.SuspendLayout();
            this.tableLayoutPanel37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idPrintPreviewMini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsPicturePreview)).BeginInit();
            this.panel21.SuspendLayout();
            this.tableLayoutPanel33.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture1)).BeginInit();
            this.tableLayoutPanel15.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel35.SuspendLayout();
            this.tableLayoutPanel70.SuspendLayout();
            this.tableLayoutPanel133.SuspendLayout();
            this.tableLayoutPanel134.SuspendLayout();
            this.tableLayoutPanel135.SuspendLayout();
            this.tableLayoutPanel136.SuspendLayout();
            this.tableLayoutPanel137.SuspendLayout();
            this.tableLayoutPanel139.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericIdPrintingCopies)).BeginInit();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel34.SuspendLayout();
            this.tableLayoutPanel40.SuspendLayout();
            this.softCopyDownloadId.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tableLayoutPanel39.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrIdPrintingDownload)).BeginInit();
            this.photoBoothPanel.SuspendLayout();
            this.funPaymentPanel.SuspendLayout();
            this.tableLayoutPanel111.SuspendLayout();
            this.tableLayoutPanel72.SuspendLayout();
            this.tableLayoutPanel114.SuspendLayout();
            this.tableLayoutPanel71.SuspendLayout();
            this.panel19.SuspendLayout();
            this.tableLayoutPanel115.SuspendLayout();
            this.tableLayoutPanel69.SuspendLayout();
            this.tableLayoutPanel68.SuspendLayout();
            this.tableLayoutPanel121.SuspendLayout();
            this.tableLayoutPanel122.SuspendLayout();
            this.panelCMRphotoBooth.SuspendLayout();
            this.tableLayoutPanel31.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.funCameraFeed)).BeginInit();
            this.tableLayoutPanel29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.funPreview4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funPreview3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funPreview2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funPreview1)).BeginInit();
            this.tableLayoutPanel30.SuspendLayout();
            this.photoBoothSettings.SuspendLayout();
            this.funSettings.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel58.SuspendLayout();
            this.panel12.SuspendLayout();
            this.tableLayoutPanel59.SuspendLayout();
            this.tableLayoutPanel60.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.funMiniPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funMainPreview)).BeginInit();
            this.panel18.SuspendLayout();
            this.tableLayoutPanel112.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.funSelectPic4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funSelectPic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funSelectPic3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funSelectPic2)).BeginInit();
            this.tableLayoutPanel56.SuspendLayout();
            this.panel16.SuspendLayout();
            this.tableLayoutPanel66.SuspendLayout();
            this.tableLayoutPanel43.SuspendLayout();
            this.tableLayoutPanel63.SuspendLayout();
            this.tableLayoutPanel138.SuspendLayout();
            this.tableLayoutPanel78.SuspendLayout();
            this.tableLayoutPanel109.SuspendLayout();
            this.tableLayoutPanel49.SuspendLayout();
            this.tableLayoutPanel45.SuspendLayout();
            this.tableLayoutPanel141.SuspendLayout();
            this.tableLayoutPanel143.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.funNumericCopies)).BeginInit();
            this.panel17.SuspendLayout();
            this.tableLayoutPanel50.SuspendLayout();
            this.tableLayoutPanel110.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.tableLayoutPanel65.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            this.tableLayoutPanel54.SuspendLayout();
            this.tableLayoutPanel42.SuspendLayout();
            this.funSoftCopyDownloadPanel.SuspendLayout();
            this.panel11.SuspendLayout();
            this.tableLayoutPanel48.SuspendLayout();
            this.tableLayoutPanel44.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrSoftCopyDownloadFun)).BeginInit();
            this.photoMode.SuspendLayout();
            this.tableLayoutPanel22.SuspendLayout();
            this.tableLayoutPanel23.SuspendLayout();
            this.retrievalPanelPhoto.SuspendLayout();
            this.PhotoRetrievePanel.SuspendLayout();
            this.tableLayoutPanel75.SuspendLayout();
            this.tableLayoutPanel76.SuspendLayout();
            this.SuspendLayout();
            // 
            // startPanel
            // 
            this.startPanel.BackColor = System.Drawing.Color.Transparent;
            this.startPanel.BackgroundImage = global::Snap_and_Print.Properties.Resources.SnapAndPrintBg;
            this.startPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startPanel.Controls.Add(this.panel13);
            this.startPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startPanel.Location = new System.Drawing.Point(0, 0);
            this.startPanel.Margin = new System.Windows.Forms.Padding(2);
            this.startPanel.Name = "startPanel";
            this.startPanel.Size = new System.Drawing.Size(1456, 729);
            this.startPanel.TabIndex = 0;
            // 
            // panel13
            // 
            this.panel13.BackgroundImage = global::Snap_and_Print.Properties.Resources.SnapAndPrintBg;
            this.panel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel13.Controls.Add(this.tableLayoutPanel73);
            this.panel13.Controls.Add(this.tableLayoutPanel67);
            this.panel13.Controls.Add(this.tableLayoutPanel64);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Margin = new System.Windows.Forms.Padding(2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1456, 729);
            this.panel13.TabIndex = 6;
            // 
            // tableLayoutPanel73
            // 
            this.tableLayoutPanel73.ColumnCount = 3;
            this.tableLayoutPanel73.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel73.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel73.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel73.Controls.Add(this.label, 1, 0);
            this.tableLayoutPanel73.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel73.Location = new System.Drawing.Point(0, 482);
            this.tableLayoutPanel73.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel73.Name = "tableLayoutPanel73";
            this.tableLayoutPanel73.RowCount = 1;
            this.tableLayoutPanel73.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel73.Size = new System.Drawing.Size(1456, 56);
            this.tableLayoutPanel73.TabIndex = 2;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.DimGray;
            this.label.Location = new System.Drawing.Point(584, 0);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(287, 56);
            this.label.TabIndex = 0;
            this.label.Text = "Click \'START\' to begin";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel67
            // 
            this.tableLayoutPanel67.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel67.ColumnCount = 3;
            this.tableLayoutPanel67.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel67.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel67.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel67.Controls.Add(this.startBtn, 1, 0);
            this.tableLayoutPanel67.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel67.Location = new System.Drawing.Point(0, 538);
            this.tableLayoutPanel67.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel67.Name = "tableLayoutPanel67";
            this.tableLayoutPanel67.RowCount = 1;
            this.tableLayoutPanel67.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel67.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel67.Size = new System.Drawing.Size(1456, 110);
            this.tableLayoutPanel67.TabIndex = 1;
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.Silver;
            this.startBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.startBtn.FlatAppearance.BorderSize = 2;
            this.startBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.startBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.startBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startBtn.Font = new System.Drawing.Font("Segoe UI Black", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(512, 3);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(430, 104);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "START";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // tableLayoutPanel64
            // 
            this.tableLayoutPanel64.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel64.ColumnCount = 1;
            this.tableLayoutPanel64.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel64.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel64.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel64.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel64.Location = new System.Drawing.Point(0, 648);
            this.tableLayoutPanel64.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel64.Name = "tableLayoutPanel64";
            this.tableLayoutPanel64.RowCount = 1;
            this.tableLayoutPanel64.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel64.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel64.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel64.Size = new System.Drawing.Size(1456, 81);
            this.tableLayoutPanel64.TabIndex = 0;
            // 
            // printingOptionsPanel
            // 
            this.printingOptionsPanel.BackgroundImage = global::Snap_and_Print.Properties.Resources.SnapAndPrintBg;
            this.printingOptionsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.printingOptionsPanel.Controls.Add(this.tableLayoutPanel74);
            this.printingOptionsPanel.Controls.Add(this.MainPrintingPanel);
            this.printingOptionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printingOptionsPanel.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printingOptionsPanel.ForeColor = System.Drawing.Color.DimGray;
            this.printingOptionsPanel.Location = new System.Drawing.Point(0, 0);
            this.printingOptionsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.printingOptionsPanel.Name = "printingOptionsPanel";
            this.printingOptionsPanel.Size = new System.Drawing.Size(1456, 729);
            this.printingOptionsPanel.TabIndex = 2;
            // 
            // tableLayoutPanel74
            // 
            this.tableLayoutPanel74.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel74.ColumnCount = 3;
            this.tableLayoutPanel74.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel74.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel74.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel74.Controls.Add(this.instructionLabel, 1, 0);
            this.tableLayoutPanel74.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel74.Location = new System.Drawing.Point(0, 379);
            this.tableLayoutPanel74.Name = "tableLayoutPanel74";
            this.tableLayoutPanel74.RowCount = 1;
            this.tableLayoutPanel74.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel74.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel74.Size = new System.Drawing.Size(1456, 49);
            this.tableLayoutPanel74.TabIndex = 5;
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.BackColor = System.Drawing.Color.Transparent;
            this.instructionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instructionLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instructionLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabel.ForeColor = System.Drawing.Color.DimGray;
            this.instructionLabel.Location = new System.Drawing.Point(367, 0);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(722, 49);
            this.instructionLabel.TabIndex = 0;
            this.instructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainPrintingPanel
            // 
            this.MainPrintingPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPrintingPanel.ColumnCount = 4;
            this.MainPrintingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainPrintingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainPrintingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainPrintingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainPrintingPanel.Controls.Add(this.photoPrintingBtn, 2, 0);
            this.MainPrintingPanel.Controls.Add(this.docPrintingBtn, 1, 0);
            this.MainPrintingPanel.Controls.Add(this.label1, 2, 1);
            this.MainPrintingPanel.Controls.Add(this.label40, 1, 1);
            this.MainPrintingPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainPrintingPanel.Location = new System.Drawing.Point(0, 428);
            this.MainPrintingPanel.Margin = new System.Windows.Forms.Padding(80, 20, 80, 20);
            this.MainPrintingPanel.Name = "MainPrintingPanel";
            this.MainPrintingPanel.RowCount = 2;
            this.MainPrintingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.MainPrintingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainPrintingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPrintingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPrintingPanel.Size = new System.Drawing.Size(1456, 301);
            this.MainPrintingPanel.TabIndex = 4;
            // 
            // photoPrintingBtn
            // 
            this.photoPrintingBtn.BackColor = System.Drawing.Color.Silver;
            this.photoPrintingBtn.BackgroundImage = global::Snap_and_Print.Properties.Resources.camera;
            this.photoPrintingBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.photoPrintingBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.photoPrintingBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoPrintingBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.photoPrintingBtn.FlatAppearance.BorderSize = 2;
            this.photoPrintingBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.photoPrintingBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.photoPrintingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.photoPrintingBtn.ForeColor = System.Drawing.Color.White;
            this.photoPrintingBtn.Location = new System.Drawing.Point(807, 20);
            this.photoPrintingBtn.Margin = new System.Windows.Forms.Padding(80, 20, 80, 20);
            this.photoPrintingBtn.Name = "photoPrintingBtn";
            this.photoPrintingBtn.Padding = new System.Windows.Forms.Padding(20);
            this.photoPrintingBtn.Size = new System.Drawing.Size(276, 200);
            this.photoPrintingBtn.TabIndex = 0;
            this.photoPrintingBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.photoPrintingBtn.UseVisualStyleBackColor = false;
            this.photoPrintingBtn.Click += new System.EventHandler(this.photoPrintingBtn_Click);
            this.photoPrintingBtn.MouseEnter += new System.EventHandler(this.photoPrintingBtn_MouseEnter);
            this.photoPrintingBtn.MouseLeave += new System.EventHandler(this.photoPrintingBtn_MouseLeave);
            // 
            // docPrintingBtn
            // 
            this.docPrintingBtn.BackColor = System.Drawing.Color.Silver;
            this.docPrintingBtn.BackgroundImage = global::Snap_and_Print.Properties.Resources.printer;
            this.docPrintingBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.docPrintingBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.docPrintingBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docPrintingBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.docPrintingBtn.FlatAppearance.BorderSize = 2;
            this.docPrintingBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.docPrintingBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.docPrintingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docPrintingBtn.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.docPrintingBtn.ForeColor = System.Drawing.Color.White;
            this.docPrintingBtn.Location = new System.Drawing.Point(371, 20);
            this.docPrintingBtn.Margin = new System.Windows.Forms.Padding(80, 20, 80, 20);
            this.docPrintingBtn.Name = "docPrintingBtn";
            this.docPrintingBtn.Padding = new System.Windows.Forms.Padding(20);
            this.docPrintingBtn.Size = new System.Drawing.Size(276, 200);
            this.docPrintingBtn.TabIndex = 1;
            this.docPrintingBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.docPrintingBtn.UseVisualStyleBackColor = false;
            this.docPrintingBtn.Click += new System.EventHandler(this.docPrintingBtn_Click);
            this.docPrintingBtn.MouseEnter += new System.EventHandler(this.docPrintingBtn_MouseEnter);
            this.docPrintingBtn.MouseLeave += new System.EventHandler(this.docPrintingBtn_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(730, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Photo Printing";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Dock = System.Windows.Forms.DockStyle.Top;
            this.label40.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(294, 240);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(430, 32);
            this.label40.TabIndex = 3;
            this.label40.Text = "Document Printing";
            this.label40.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // printPanel
            // 
            this.printPanel.BackColor = System.Drawing.Color.Transparent;
            this.printPanel.BackgroundImage = global::Snap_and_Print.Properties.Resources.SnapAndPrintBg;
            this.printPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.printPanel.Controls.Add(this.printingSettingsPanel);
            this.printPanel.Controls.Add(this.retrivalPanel);
            this.printPanel.Controls.Add(this.continuePanel);
            this.printPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printPanel.Location = new System.Drawing.Point(0, 0);
            this.printPanel.Name = "printPanel";
            this.printPanel.Size = new System.Drawing.Size(1456, 729);
            this.printPanel.TabIndex = 0;
            // 
            // printingSettingsPanel
            // 
            this.printingSettingsPanel.BackgroundImage = global::Snap_and_Print.Properties.Resources.SnapAndPrintBg;
            this.printingSettingsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.printingSettingsPanel.Controls.Add(this.paymentPanel);
            this.printingSettingsPanel.Controls.Add(this.uploadPanel);
            this.printingSettingsPanel.Controls.Add(this.settingsPanel);
            this.printingSettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printingSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.printingSettingsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.printingSettingsPanel.Name = "printingSettingsPanel";
            this.printingSettingsPanel.Size = new System.Drawing.Size(1456, 729);
            this.printingSettingsPanel.TabIndex = 2;
            // 
            // paymentPanel
            // 
            this.paymentPanel.BackgroundImage = global::Snap_and_Print.Properties.Resources.SnapAndPrintBg;
            this.paymentPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.paymentPanel.Controls.Add(this.panel2);
            this.paymentPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.paymentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentPanel.Location = new System.Drawing.Point(0, 0);
            this.paymentPanel.Margin = new System.Windows.Forms.Padding(2);
            this.paymentPanel.Name = "paymentPanel";
            this.paymentPanel.Size = new System.Drawing.Size(1456, 729);
            this.paymentPanel.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPayment);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1456, 729);
            this.panel2.TabIndex = 11;
            // 
            // tableLayoutPayment
            // 
            this.tableLayoutPayment.ColumnCount = 3;
            this.tableLayoutPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPayment.Controls.Add(this.tableLayoutPanel104, 1, 1);
            this.tableLayoutPayment.Controls.Add(this.panel22, 1, 0);
            this.tableLayoutPayment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPayment.Location = new System.Drawing.Point(0, 274);
            this.tableLayoutPayment.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPayment.Name = "tableLayoutPayment";
            this.tableLayoutPayment.RowCount = 2;
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPayment.Size = new System.Drawing.Size(1456, 455);
            this.tableLayoutPayment.TabIndex = 5;
            // 
            // tableLayoutPanel104
            // 
            this.tableLayoutPanel104.ColumnCount = 3;
            this.tableLayoutPanel104.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel104.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel104.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel104.Controls.Add(this.cancelPrintBtn, 0, 0);
            this.tableLayoutPanel104.Controls.Add(this.printBtn, 2, 0);
            this.tableLayoutPanel104.Controls.Add(this.paymentBackBtn, 1, 0);
            this.tableLayoutPanel104.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel104.Location = new System.Drawing.Point(294, 367);
            this.tableLayoutPanel104.Name = "tableLayoutPanel104";
            this.tableLayoutPanel104.RowCount = 1;
            this.tableLayoutPanel104.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel104.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel104.Size = new System.Drawing.Size(867, 85);
            this.tableLayoutPanel104.TabIndex = 8;
            // 
            // cancelPrintBtn
            // 
            this.cancelPrintBtn.BackColor = System.Drawing.Color.Silver;
            this.cancelPrintBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelPrintBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelPrintBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.cancelPrintBtn.FlatAppearance.BorderSize = 2;
            this.cancelPrintBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.cancelPrintBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.cancelPrintBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelPrintBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelPrintBtn.Image = global::Snap_and_Print.Properties.Resources.printCancel;
            this.cancelPrintBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelPrintBtn.Location = new System.Drawing.Point(50, 10);
            this.cancelPrintBtn.Margin = new System.Windows.Forms.Padding(50, 10, 50, 10);
            this.cancelPrintBtn.Name = "cancelPrintBtn";
            this.cancelPrintBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.cancelPrintBtn.Size = new System.Drawing.Size(189, 65);
            this.cancelPrintBtn.TabIndex = 2;
            this.cancelPrintBtn.Text = "CANCEL";
            this.cancelPrintBtn.UseVisualStyleBackColor = false;
            this.cancelPrintBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.BackColor = System.Drawing.Color.Silver;
            this.printBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.printBtn.FlatAppearance.BorderSize = 2;
            this.printBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.printBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.printBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtn.Image = global::Snap_and_Print.Properties.Resources.printer_fill;
            this.printBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.printBtn.Location = new System.Drawing.Point(628, 10);
            this.printBtn.Margin = new System.Windows.Forms.Padding(50, 10, 50, 10);
            this.printBtn.Name = "printBtn";
            this.printBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.printBtn.Size = new System.Drawing.Size(189, 65);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "PRINT";
            this.printBtn.UseVisualStyleBackColor = false;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // paymentBackBtn
            // 
            this.paymentBackBtn.BackColor = System.Drawing.Color.Silver;
            this.paymentBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.paymentBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentBackBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.paymentBackBtn.FlatAppearance.BorderSize = 2;
            this.paymentBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.paymentBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.paymentBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paymentBackBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentBackBtn.Image = global::Snap_and_Print.Properties.Resources.printBack;
            this.paymentBackBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentBackBtn.Location = new System.Drawing.Point(339, 10);
            this.paymentBackBtn.Margin = new System.Windows.Forms.Padding(50, 10, 50, 10);
            this.paymentBackBtn.Name = "paymentBackBtn";
            this.paymentBackBtn.Padding = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.paymentBackBtn.Size = new System.Drawing.Size(189, 65);
            this.paymentBackBtn.TabIndex = 9;
            this.paymentBackBtn.Text = "BACK";
            this.paymentBackBtn.UseVisualStyleBackColor = false;
            this.paymentBackBtn.Click += new System.EventHandler(this.paymentBackBtn_Click);
            // 
            // panel22
            // 
            this.panel22.BackColor = System.Drawing.Color.Silver;
            this.panel22.Controls.Add(this.tableLayoutPanel17);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(431, 10);
            this.panel22.Margin = new System.Windows.Forms.Padding(140, 10, 140, 10);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(593, 344);
            this.panel22.TabIndex = 9;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 1;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel103, 0, 9);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel102, 0, 7);
            this.tableLayoutPanel17.Controls.Add(this.printingStatusLabel, 0, 10);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel101, 0, 5);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel100, 0, 3);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel98, 0, 1);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel105, 0, 2);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel106, 0, 4);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel107, 0, 6);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel140, 0, 8);
            this.tableLayoutPanel17.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 11;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.111111F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.111111F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.111111F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.111111F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.111111F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(593, 344);
            this.tableLayoutPanel17.TabIndex = 0;
            // 
            // tableLayoutPanel103
            // 
            this.tableLayoutPanel103.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel103.ColumnCount = 1;
            this.tableLayoutPanel103.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel103.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel103.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel103.Location = new System.Drawing.Point(150, 300);
            this.tableLayoutPanel103.Margin = new System.Windows.Forms.Padding(150, 3, 150, 3);
            this.tableLayoutPanel103.Name = "tableLayoutPanel103";
            this.tableLayoutPanel103.RowCount = 1;
            this.tableLayoutPanel103.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel103.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel103.Size = new System.Drawing.Size(293, 1);
            this.tableLayoutPanel103.TabIndex = 4;
            // 
            // tableLayoutPanel102
            // 
            this.tableLayoutPanel102.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel102.ColumnCount = 1;
            this.tableLayoutPanel102.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel102.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel102.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel102.Location = new System.Drawing.Point(80, 240);
            this.tableLayoutPanel102.Margin = new System.Windows.Forms.Padding(80, 3, 80, 3);
            this.tableLayoutPanel102.Name = "tableLayoutPanel102";
            this.tableLayoutPanel102.RowCount = 1;
            this.tableLayoutPanel102.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel102.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel102.Size = new System.Drawing.Size(433, 1);
            this.tableLayoutPanel102.TabIndex = 3;
            // 
            // printingStatusLabel
            // 
            this.printingStatusLabel.AutoSize = true;
            this.printingStatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.printingStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printingStatusLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printingStatusLabel.ForeColor = System.Drawing.Color.DimGray;
            this.printingStatusLabel.Location = new System.Drawing.Point(150, 310);
            this.printingStatusLabel.Margin = new System.Windows.Forms.Padding(150, 10, 150, 10);
            this.printingStatusLabel.Name = "printingStatusLabel";
            this.printingStatusLabel.Size = new System.Drawing.Size(293, 24);
            this.printingStatusLabel.TabIndex = 11;
            this.printingStatusLabel.Text = "[Status]";
            this.printingStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel101
            // 
            this.tableLayoutPanel101.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel101.ColumnCount = 1;
            this.tableLayoutPanel101.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel101.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel101.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel101.Location = new System.Drawing.Point(80, 180);
            this.tableLayoutPanel101.Margin = new System.Windows.Forms.Padding(80, 3, 80, 3);
            this.tableLayoutPanel101.Name = "tableLayoutPanel101";
            this.tableLayoutPanel101.RowCount = 1;
            this.tableLayoutPanel101.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel101.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel101.Size = new System.Drawing.Size(433, 1);
            this.tableLayoutPanel101.TabIndex = 2;
            // 
            // tableLayoutPanel100
            // 
            this.tableLayoutPanel100.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel100.ColumnCount = 1;
            this.tableLayoutPanel100.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel100.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel100.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel100.Location = new System.Drawing.Point(80, 120);
            this.tableLayoutPanel100.Margin = new System.Windows.Forms.Padding(80, 3, 80, 3);
            this.tableLayoutPanel100.Name = "tableLayoutPanel100";
            this.tableLayoutPanel100.RowCount = 1;
            this.tableLayoutPanel100.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel100.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel100.Size = new System.Drawing.Size(433, 1);
            this.tableLayoutPanel100.TabIndex = 1;
            // 
            // tableLayoutPanel98
            // 
            this.tableLayoutPanel98.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel98.ColumnCount = 1;
            this.tableLayoutPanel98.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel98.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel98.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel98.Location = new System.Drawing.Point(110, 60);
            this.tableLayoutPanel98.Margin = new System.Windows.Forms.Padding(110, 3, 110, 3);
            this.tableLayoutPanel98.Name = "tableLayoutPanel98";
            this.tableLayoutPanel98.RowCount = 1;
            this.tableLayoutPanel98.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel98.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel98.Size = new System.Drawing.Size(373, 1);
            this.tableLayoutPanel98.TabIndex = 0;
            // 
            // tableLayoutPanel105
            // 
            this.tableLayoutPanel105.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel105.ColumnCount = 2;
            this.tableLayoutPanel105.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel105.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel105.Controls.Add(this.paymentDocTotal, 1, 0);
            this.tableLayoutPanel105.Controls.Add(this.label29, 0, 0);
            this.tableLayoutPanel105.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel105.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanel105.Name = "tableLayoutPanel105";
            this.tableLayoutPanel105.RowCount = 1;
            this.tableLayoutPanel105.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel105.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel105.Size = new System.Drawing.Size(587, 51);
            this.tableLayoutPanel105.TabIndex = 5;
            // 
            // paymentDocTotal
            // 
            this.paymentDocTotal.AutoSize = true;
            this.paymentDocTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentDocTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentDocTotal.Image = global::Snap_and_Print.Properties.Resources.peso__1_;
            this.paymentDocTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentDocTotal.Location = new System.Drawing.Point(295, 2);
            this.paymentDocTotal.Margin = new System.Windows.Forms.Padding(2);
            this.paymentDocTotal.Name = "paymentDocTotal";
            this.paymentDocTotal.Padding = new System.Windows.Forms.Padding(3, 3, 150, 3);
            this.paymentDocTotal.Size = new System.Drawing.Size(290, 47);
            this.paymentDocTotal.TabIndex = 4;
            this.paymentDocTotal.Text = "[0]";
            this.paymentDocTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(3, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(287, 51);
            this.label29.TabIndex = 5;
            this.label29.Text = "Total Amount :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel106
            // 
            this.tableLayoutPanel106.ColumnCount = 2;
            this.tableLayoutPanel106.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel106.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel106.Controls.Add(this.paymentDocBalance, 1, 0);
            this.tableLayoutPanel106.Controls.Add(this.label30, 0, 0);
            this.tableLayoutPanel106.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel106.Location = new System.Drawing.Point(3, 123);
            this.tableLayoutPanel106.Name = "tableLayoutPanel106";
            this.tableLayoutPanel106.RowCount = 1;
            this.tableLayoutPanel106.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel106.Size = new System.Drawing.Size(587, 51);
            this.tableLayoutPanel106.TabIndex = 6;
            // 
            // paymentDocBalance
            // 
            this.paymentDocBalance.AutoSize = true;
            this.paymentDocBalance.BackColor = System.Drawing.Color.Transparent;
            this.paymentDocBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentDocBalance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentDocBalance.Image = global::Snap_and_Print.Properties.Resources.peso__1_;
            this.paymentDocBalance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentDocBalance.Location = new System.Drawing.Point(295, 2);
            this.paymentDocBalance.Margin = new System.Windows.Forms.Padding(2);
            this.paymentDocBalance.Name = "paymentDocBalance";
            this.paymentDocBalance.Padding = new System.Windows.Forms.Padding(3, 3, 150, 3);
            this.paymentDocBalance.Size = new System.Drawing.Size(290, 47);
            this.paymentDocBalance.TabIndex = 5;
            this.paymentDocBalance.Text = "[0]";
            this.paymentDocBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(3, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(287, 51);
            this.label30.TabIndex = 6;
            this.label30.Text = "Balance :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel107
            // 
            this.tableLayoutPanel107.ColumnCount = 2;
            this.tableLayoutPanel107.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel107.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel107.Controls.Add(this.totalDocInserted, 1, 0);
            this.tableLayoutPanel107.Controls.Add(this.label31, 0, 0);
            this.tableLayoutPanel107.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel107.Location = new System.Drawing.Point(3, 183);
            this.tableLayoutPanel107.Name = "tableLayoutPanel107";
            this.tableLayoutPanel107.RowCount = 1;
            this.tableLayoutPanel107.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel107.Size = new System.Drawing.Size(587, 51);
            this.tableLayoutPanel107.TabIndex = 7;
            // 
            // totalDocInserted
            // 
            this.totalDocInserted.AutoSize = true;
            this.totalDocInserted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalDocInserted.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDocInserted.Image = global::Snap_and_Print.Properties.Resources.peso__1_;
            this.totalDocInserted.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.totalDocInserted.Location = new System.Drawing.Point(296, 0);
            this.totalDocInserted.Name = "totalDocInserted";
            this.totalDocInserted.Padding = new System.Windows.Forms.Padding(3, 3, 150, 3);
            this.totalDocInserted.Size = new System.Drawing.Size(288, 51);
            this.totalDocInserted.TabIndex = 0;
            this.totalDocInserted.Text = "[0]";
            this.totalDocInserted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(3, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(287, 51);
            this.label31.TabIndex = 1;
            this.label31.Text = "Payment Inserted :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel140
            // 
            this.tableLayoutPanel140.ColumnCount = 2;
            this.tableLayoutPanel140.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel140.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel140.Controls.Add(this.totalDocChange, 1, 0);
            this.tableLayoutPanel140.Controls.Add(this.label32, 0, 0);
            this.tableLayoutPanel140.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel140.Location = new System.Drawing.Point(3, 243);
            this.tableLayoutPanel140.Name = "tableLayoutPanel140";
            this.tableLayoutPanel140.RowCount = 1;
            this.tableLayoutPanel140.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel140.Size = new System.Drawing.Size(587, 51);
            this.tableLayoutPanel140.TabIndex = 8;
            // 
            // totalDocChange
            // 
            this.totalDocChange.AutoSize = true;
            this.totalDocChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalDocChange.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDocChange.Image = global::Snap_and_Print.Properties.Resources.peso__1_;
            this.totalDocChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.totalDocChange.Location = new System.Drawing.Point(296, 0);
            this.totalDocChange.Name = "totalDocChange";
            this.totalDocChange.Padding = new System.Windows.Forms.Padding(3, 3, 150, 3);
            this.totalDocChange.Size = new System.Drawing.Size(288, 51);
            this.totalDocChange.TabIndex = 0;
            this.totalDocChange.Text = "[0]";
            this.totalDocChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(3, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(287, 51);
            this.label32.TabIndex = 1;
            this.label32.Text = "Change :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(587, 57);
            this.label2.TabIndex = 9;
            this.label2.Text = "Payment";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uploadPanel
            // 
            this.uploadPanel.BackColor = System.Drawing.Color.Transparent;
            this.uploadPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uploadPanel.Controls.Add(this.tableLayoutPanel18);
            this.uploadPanel.Controls.Add(this.tableLayoutPanel1);
            this.uploadPanel.Controls.Add(this.uploadMainLayout);
            this.uploadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadPanel.Location = new System.Drawing.Point(0, 0);
            this.uploadPanel.Margin = new System.Windows.Forms.Padding(2);
            this.uploadPanel.Name = "uploadPanel";
            this.uploadPanel.Size = new System.Drawing.Size(1456, 729);
            this.uploadPanel.TabIndex = 1;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 3;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel18.Controls.Add(this.instructionLabelDocs, 1, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(0, 270);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 1;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(1456, 40);
            this.tableLayoutPanel18.TabIndex = 6;
            // 
            // instructionLabelDocs
            // 
            this.instructionLabelDocs.AutoSize = true;
            this.instructionLabelDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instructionLabelDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instructionLabelDocs.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabelDocs.ForeColor = System.Drawing.Color.DimGray;
            this.instructionLabelDocs.Location = new System.Drawing.Point(294, 0);
            this.instructionLabelDocs.Name = "instructionLabelDocs";
            this.instructionLabelDocs.Size = new System.Drawing.Size(867, 40);
            this.instructionLabelDocs.TabIndex = 0;
            this.instructionLabelDocs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Controls.Add(this.qrPictureBox, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 310);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1456, 312);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // qrPictureBox
            // 
            this.qrPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.qrPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrPictureBox.Location = new System.Drawing.Point(486, 2);
            this.qrPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.qrPictureBox.Name = "qrPictureBox";
            this.qrPictureBox.Size = new System.Drawing.Size(481, 308);
            this.qrPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.qrPictureBox.TabIndex = 0;
            this.qrPictureBox.TabStop = false;
            this.qrPictureBox.MouseEnter += new System.EventHandler(this.qrPictureBox_MouseEnter);
            this.qrPictureBox.MouseLeave += new System.EventHandler(this.retrievalBtn_MouseLeave);
            // 
            // uploadMainLayout
            // 
            this.uploadMainLayout.ColumnCount = 5;
            this.uploadMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.uploadMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uploadMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.uploadMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.uploadMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.uploadMainLayout.Controls.Add(this.uploadCancelBtn, 1, 0);
            this.uploadMainLayout.Controls.Add(this.tableLayoutPanel11, 2, 0);
            this.uploadMainLayout.Controls.Add(this.retrievalBtn, 3, 0);
            this.uploadMainLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uploadMainLayout.Location = new System.Drawing.Point(0, 622);
            this.uploadMainLayout.Name = "uploadMainLayout";
            this.uploadMainLayout.RowCount = 2;
            this.uploadMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.uploadMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.uploadMainLayout.Size = new System.Drawing.Size(1456, 107);
            this.uploadMainLayout.TabIndex = 4;
            // 
            // uploadCancelBtn
            // 
            this.uploadCancelBtn.BackColor = System.Drawing.Color.Silver;
            this.uploadCancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uploadCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadCancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.uploadCancelBtn.FlatAppearance.BorderSize = 2;
            this.uploadCancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.uploadCancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.uploadCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadCancelBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadCancelBtn.ForeColor = System.Drawing.Color.Black;
            this.uploadCancelBtn.Image = global::Snap_and_Print.Properties.Resources.printCancel;
            this.uploadCancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uploadCancelBtn.Location = new System.Drawing.Point(298, 20);
            this.uploadCancelBtn.Margin = new System.Windows.Forms.Padding(80, 20, 80, 10);
            this.uploadCancelBtn.Name = "uploadCancelBtn";
            this.uploadCancelBtn.Padding = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.uploadCancelBtn.Size = new System.Drawing.Size(204, 55);
            this.uploadCancelBtn.TabIndex = 1;
            this.uploadCancelBtn.Text = "CANCEL";
            this.uploadCancelBtn.UseVisualStyleBackColor = false;
            this.uploadCancelBtn.Click += new System.EventHandler(this.uploadCancelBtn_Click);
            this.uploadCancelBtn.MouseEnter += new System.EventHandler(this.uploadCancelBtn_MouseEnter);
            this.uploadCancelBtn.MouseLeave += new System.EventHandler(this.uploadCancelBtn_MouseLeave);
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.fileUploadStatusLabel, 0, 1);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(585, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(285, 79);
            this.tableLayoutPanel11.TabIndex = 1;
            // 
            // fileUploadStatusLabel
            // 
            this.fileUploadStatusLabel.AutoSize = true;
            this.fileUploadStatusLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileUploadStatusLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileUploadStatusLabel.ForeColor = System.Drawing.Color.Black;
            this.fileUploadStatusLabel.Location = new System.Drawing.Point(3, 39);
            this.fileUploadStatusLabel.Name = "fileUploadStatusLabel";
            this.fileUploadStatusLabel.Size = new System.Drawing.Size(279, 30);
            this.fileUploadStatusLabel.TabIndex = 0;
            this.fileUploadStatusLabel.Text = "Wating for file...\r\n";
            this.fileUploadStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // retrievalBtn
            // 
            this.retrievalBtn.BackColor = System.Drawing.Color.Silver;
            this.retrievalBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.retrievalBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retrievalBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.retrievalBtn.FlatAppearance.BorderSize = 2;
            this.retrievalBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.retrievalBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.retrievalBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.retrievalBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retrievalBtn.ForeColor = System.Drawing.Color.Black;
            this.retrievalBtn.Image = global::Snap_and_Print.Properties.Resources.folder_history_fill;
            this.retrievalBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.retrievalBtn.Location = new System.Drawing.Point(933, 20);
            this.retrievalBtn.Margin = new System.Windows.Forms.Padding(60, 20, 60, 10);
            this.retrievalBtn.Name = "retrievalBtn";
            this.retrievalBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.retrievalBtn.Size = new System.Drawing.Size(244, 55);
            this.retrievalBtn.TabIndex = 0;
            this.retrievalBtn.Text = "RETRIEVE FILE";
            this.retrievalBtn.UseVisualStyleBackColor = false;
            this.retrievalBtn.Click += new System.EventHandler(this.retrieveBtn_click);
            this.retrievalBtn.MouseEnter += new System.EventHandler(this.retrievalBtn_MouseEnter);
            this.retrievalBtn.MouseLeave += new System.EventHandler(this.retrievalBtn_MouseLeave);
            // 
            // settingsPanel
            // 
            this.settingsPanel.BackgroundImage = global::Snap_and_Print.Properties.Resources.PRNTSTNGBG;
            this.settingsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingsPanel.Controls.Add(this.tableLayoutPanel2);
            this.settingsPanel.Controls.Add(this.tableLayoutPanel3);
            this.settingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsPanel.Location = new System.Drawing.Point(0, 0);
            this.settingsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(1456, 729);
            this.settingsPanel.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.18182F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.63636F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.18182F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel16, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1456, 642);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(622, 636);
            this.tableLayoutPanel9.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 147);
            this.panel1.Margin = new System.Windows.Forms.Padding(20, 20, 30, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 288);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel5, 1, 4);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel4, 1, 5);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel93, 1, 1);
            this.tableLayoutPanel10.Controls.Add(this.radioColored, 1, 8);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel94, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel81, 0, 5);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel80, 0, 4);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel86, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel7, 0, 3);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel87, 0, 7);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel95, 1, 6);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel96, 0, 6);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel85, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.radioBlackWhite, 0, 8);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 9;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.20029F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5036154F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2003F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2003F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2003F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2003F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5036154F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.99564F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.99564F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(570, 286);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.numericPageRange, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(288, 124);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(279, 34);
            this.tableLayoutPanel5.TabIndex = 10;
            // 
            // numericPageRange
            // 
            this.numericPageRange.BackColor = System.Drawing.Color.DarkGray;
            this.numericPageRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericPageRange.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericPageRange.Location = new System.Drawing.Point(2, 2);
            this.numericPageRange.Margin = new System.Windows.Forms.Padding(2);
            this.numericPageRange.Name = "numericPageRange";
            this.numericPageRange.Size = new System.Drawing.Size(135, 33);
            this.numericPageRange.TabIndex = 2;
            this.numericPageRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.numericSinglePage, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(288, 164);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(279, 34);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // numericSinglePage
            // 
            this.numericSinglePage.BackColor = System.Drawing.Color.DarkGray;
            this.numericSinglePage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericSinglePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericSinglePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericSinglePage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericSinglePage.Location = new System.Drawing.Point(2, 2);
            this.numericSinglePage.Margin = new System.Windows.Forms.Padding(2);
            this.numericSinglePage.Name = "numericSinglePage";
            this.numericSinglePage.Size = new System.Drawing.Size(135, 33);
            this.numericSinglePage.TabIndex = 1;
            this.numericSinglePage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel93
            // 
            this.tableLayoutPanel93.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel93.ColumnCount = 2;
            this.tableLayoutPanel93.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel93.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel93.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel93.Location = new System.Drawing.Point(285, 43);
            this.tableLayoutPanel93.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tableLayoutPanel93.Name = "tableLayoutPanel93";
            this.tableLayoutPanel93.RowCount = 2;
            this.tableLayoutPanel93.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel93.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel93.Size = new System.Drawing.Size(282, 1);
            this.tableLayoutPanel93.TabIndex = 0;
            // 
            // radioColored
            // 
            this.radioColored.AutoSize = true;
            this.radioColored.BackColor = System.Drawing.Color.Transparent;
            this.radioColored.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioColored.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioColored.FlatAppearance.BorderSize = 0;
            this.radioColored.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioColored.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioColored.Location = new System.Drawing.Point(295, 244);
            this.radioColored.Margin = new System.Windows.Forms.Padding(10, 2, 2, 2);
            this.radioColored.Name = "radioColored";
            this.radioColored.Size = new System.Drawing.Size(273, 40);
            this.radioColored.TabIndex = 1;
            this.radioColored.Text = "Colored";
            this.radioColored.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel94
            // 
            this.tableLayoutPanel94.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel94.ColumnCount = 1;
            this.tableLayoutPanel94.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel94.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel94.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel94.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel94.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tableLayoutPanel94.Name = "tableLayoutPanel94";
            this.tableLayoutPanel94.RowCount = 1;
            this.tableLayoutPanel94.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel94.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel94.Size = new System.Drawing.Size(282, 1);
            this.tableLayoutPanel94.TabIndex = 1;
            // 
            // tableLayoutPanel81
            // 
            this.tableLayoutPanel81.ColumnCount = 2;
            this.tableLayoutPanel81.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel81.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel81.Controls.Add(this.radioSinglePage, 1, 0);
            this.tableLayoutPanel81.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel81.Location = new System.Drawing.Point(3, 164);
            this.tableLayoutPanel81.Name = "tableLayoutPanel81";
            this.tableLayoutPanel81.RowCount = 1;
            this.tableLayoutPanel81.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel81.Size = new System.Drawing.Size(279, 34);
            this.tableLayoutPanel81.TabIndex = 4;
            // 
            // radioSinglePage
            // 
            this.radioSinglePage.AutoSize = true;
            this.radioSinglePage.BackColor = System.Drawing.Color.Transparent;
            this.radioSinglePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioSinglePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioSinglePage.FlatAppearance.BorderSize = 0;
            this.radioSinglePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioSinglePage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSinglePage.ForeColor = System.Drawing.Color.Black;
            this.radioSinglePage.Location = new System.Drawing.Point(113, 2);
            this.radioSinglePage.Margin = new System.Windows.Forms.Padding(2);
            this.radioSinglePage.Name = "radioSinglePage";
            this.radioSinglePage.Size = new System.Drawing.Size(164, 30);
            this.radioSinglePage.TabIndex = 1;
            this.radioSinglePage.TabStop = true;
            this.radioSinglePage.Text = "Single Page";
            this.radioSinglePage.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.numericCopies, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(288, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(279, 34);
            this.tableLayoutPanel6.TabIndex = 11;
            // 
            // numericCopies
            // 
            this.numericCopies.BackColor = System.Drawing.Color.DarkGray;
            this.numericCopies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericCopies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericCopies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericCopies.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericCopies.ForeColor = System.Drawing.Color.Black;
            this.numericCopies.Location = new System.Drawing.Point(2, 2);
            this.numericCopies.Margin = new System.Windows.Forms.Padding(2);
            this.numericCopies.Name = "numericCopies";
            this.numericCopies.Size = new System.Drawing.Size(135, 33);
            this.numericCopies.TabIndex = 0;
            this.numericCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel80
            // 
            this.tableLayoutPanel80.ColumnCount = 2;
            this.tableLayoutPanel80.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel80.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel80.Controls.Add(this.radioPrintRange, 1, 0);
            this.tableLayoutPanel80.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel80.Location = new System.Drawing.Point(3, 124);
            this.tableLayoutPanel80.Name = "tableLayoutPanel80";
            this.tableLayoutPanel80.RowCount = 1;
            this.tableLayoutPanel80.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel80.Size = new System.Drawing.Size(279, 34);
            this.tableLayoutPanel80.TabIndex = 4;
            // 
            // radioPrintRange
            // 
            this.radioPrintRange.AutoSize = true;
            this.radioPrintRange.BackColor = System.Drawing.Color.Transparent;
            this.radioPrintRange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioPrintRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioPrintRange.FlatAppearance.BorderSize = 0;
            this.radioPrintRange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioPrintRange.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPrintRange.ForeColor = System.Drawing.Color.Black;
            this.radioPrintRange.Location = new System.Drawing.Point(113, 2);
            this.radioPrintRange.Margin = new System.Windows.Forms.Padding(2);
            this.radioPrintRange.Name = "radioPrintRange";
            this.radioPrintRange.Size = new System.Drawing.Size(164, 30);
            this.radioPrintRange.TabIndex = 0;
            this.radioPrintRange.TabStop = true;
            this.radioPrintRange.Text = "Page Range";
            this.radioPrintRange.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel86
            // 
            this.tableLayoutPanel86.ColumnCount = 2;
            this.tableLayoutPanel86.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel86.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel86.Controls.Add(this.selectPageLabel, 1, 0);
            this.tableLayoutPanel86.Controls.Add(this.pictureBox2, 0, 0);
            this.tableLayoutPanel86.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel86.Location = new System.Drawing.Point(3, 44);
            this.tableLayoutPanel86.Name = "tableLayoutPanel86";
            this.tableLayoutPanel86.RowCount = 1;
            this.tableLayoutPanel86.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel86.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel86.Size = new System.Drawing.Size(279, 34);
            this.tableLayoutPanel86.TabIndex = 2;
            // 
            // selectPageLabel
            // 
            this.selectPageLabel.AutoSize = true;
            this.selectPageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectPageLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPageLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectPageLabel.Location = new System.Drawing.Point(75, 0);
            this.selectPageLabel.Margin = new System.Windows.Forms.Padding(20, 0, 2, 0);
            this.selectPageLabel.Name = "selectPageLabel";
            this.selectPageLabel.Size = new System.Drawing.Size(202, 34);
            this.selectPageLabel.TabIndex = 1;
            this.selectPageLabel.Text = "Select Page";
            this.selectPageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::Snap_and_Print.Properties.Resources.file_text_line;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel7.Controls.Add(this.radioPrintAll, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 84);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(279, 34);
            this.tableLayoutPanel7.TabIndex = 12;
            // 
            // radioPrintAll
            // 
            this.radioPrintAll.AutoSize = true;
            this.radioPrintAll.BackColor = System.Drawing.Color.Transparent;
            this.radioPrintAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioPrintAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioPrintAll.FlatAppearance.BorderSize = 0;
            this.radioPrintAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioPrintAll.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPrintAll.Location = new System.Drawing.Point(113, 2);
            this.radioPrintAll.Margin = new System.Windows.Forms.Padding(2);
            this.radioPrintAll.Name = "radioPrintAll";
            this.radioPrintAll.Size = new System.Drawing.Size(164, 30);
            this.radioPrintAll.TabIndex = 2;
            this.radioPrintAll.TabStop = true;
            this.radioPrintAll.Text = "All Pages";
            this.radioPrintAll.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel87
            // 
            this.tableLayoutPanel87.ColumnCount = 2;
            this.tableLayoutPanel87.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel87.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel87.Controls.Add(this.paperColor, 1, 0);
            this.tableLayoutPanel87.Controls.Add(this.pictureBox3, 0, 0);
            this.tableLayoutPanel87.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel87.Location = new System.Drawing.Point(3, 205);
            this.tableLayoutPanel87.Name = "tableLayoutPanel87";
            this.tableLayoutPanel87.RowCount = 1;
            this.tableLayoutPanel87.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel87.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel87.Size = new System.Drawing.Size(279, 34);
            this.tableLayoutPanel87.TabIndex = 2;
            // 
            // paperColor
            // 
            this.paperColor.AutoSize = true;
            this.paperColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paperColor.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paperColor.Location = new System.Drawing.Point(75, 0);
            this.paperColor.Margin = new System.Windows.Forms.Padding(20, 0, 2, 0);
            this.paperColor.Name = "paperColor";
            this.paperColor.Size = new System.Drawing.Size(202, 34);
            this.paperColor.TabIndex = 8;
            this.paperColor.Text = "Print Type";
            this.paperColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = global::Snap_and_Print.Properties.Resources.printer_line;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // tableLayoutPanel95
            // 
            this.tableLayoutPanel95.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel95.ColumnCount = 1;
            this.tableLayoutPanel95.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel95.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel95.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel95.Location = new System.Drawing.Point(285, 204);
            this.tableLayoutPanel95.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tableLayoutPanel95.Name = "tableLayoutPanel95";
            this.tableLayoutPanel95.RowCount = 1;
            this.tableLayoutPanel95.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel95.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel95.Size = new System.Drawing.Size(282, 1);
            this.tableLayoutPanel95.TabIndex = 2;
            // 
            // tableLayoutPanel96
            // 
            this.tableLayoutPanel96.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel96.ColumnCount = 1;
            this.tableLayoutPanel96.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel96.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel96.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel96.Location = new System.Drawing.Point(3, 204);
            this.tableLayoutPanel96.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tableLayoutPanel96.Name = "tableLayoutPanel96";
            this.tableLayoutPanel96.RowCount = 1;
            this.tableLayoutPanel96.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel96.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel96.Size = new System.Drawing.Size(282, 1);
            this.tableLayoutPanel96.TabIndex = 3;
            // 
            // tableLayoutPanel85
            // 
            this.tableLayoutPanel85.ColumnCount = 2;
            this.tableLayoutPanel85.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel85.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel85.Controls.Add(this.copiesLabel, 1, 0);
            this.tableLayoutPanel85.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel85.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel85.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel85.Name = "tableLayoutPanel85";
            this.tableLayoutPanel85.RowCount = 1;
            this.tableLayoutPanel85.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel85.Size = new System.Drawing.Size(279, 34);
            this.tableLayoutPanel85.TabIndex = 2;
            // 
            // copiesLabel
            // 
            this.copiesLabel.AutoSize = true;
            this.copiesLabel.BackColor = System.Drawing.Color.Transparent;
            this.copiesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copiesLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copiesLabel.ForeColor = System.Drawing.Color.Black;
            this.copiesLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.copiesLabel.Location = new System.Drawing.Point(75, 0);
            this.copiesLabel.Margin = new System.Windows.Forms.Padding(20, 0, 2, 0);
            this.copiesLabel.Name = "copiesLabel";
            this.copiesLabel.Size = new System.Drawing.Size(202, 34);
            this.copiesLabel.TabIndex = 0;
            this.copiesLabel.Text = "Copies";
            this.copiesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Snap_and_Print.Properties.Resources.printer_cloud_line;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // radioBlackWhite
            // 
            this.radioBlackWhite.AutoSize = true;
            this.radioBlackWhite.BackColor = System.Drawing.Color.Transparent;
            this.radioBlackWhite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioBlackWhite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBlackWhite.FlatAppearance.BorderSize = 0;
            this.radioBlackWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioBlackWhite.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBlackWhite.ForeColor = System.Drawing.Color.Black;
            this.radioBlackWhite.Location = new System.Drawing.Point(110, 244);
            this.radioBlackWhite.Margin = new System.Windows.Forms.Padding(110, 2, 2, 2);
            this.radioBlackWhite.Name = "radioBlackWhite";
            this.radioBlackWhite.Size = new System.Drawing.Size(173, 40);
            this.radioBlackWhite.TabIndex = 0;
            this.radioBlackWhite.Text = "Black and White";
            this.radioBlackWhite.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tableLayoutPanel12);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(20, 455);
            this.panel3.Margin = new System.Windows.Forms.Padding(20, 10, 30, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(572, 171);
            this.panel3.TabIndex = 1;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.Controls.Add(this.tableLayoutPanel90, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.tableLayoutPanel88, 0, 2);
            this.tableLayoutPanel12.Controls.Add(this.tableLayoutPanel91, 1, 1);
            this.tableLayoutPanel12.Controls.Add(this.tableLayoutPanel20, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.tableLayoutPanel19, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.tableLayoutPanel89, 1, 2);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 3;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.49995F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.000107F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.49994F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(570, 169);
            this.tableLayoutPanel12.TabIndex = 0;
            // 
            // tableLayoutPanel90
            // 
            this.tableLayoutPanel90.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel90.ColumnCount = 1;
            this.tableLayoutPanel90.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel90.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel90.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel90.Location = new System.Drawing.Point(3, 86);
            this.tableLayoutPanel90.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tableLayoutPanel90.Name = "tableLayoutPanel90";
            this.tableLayoutPanel90.RowCount = 1;
            this.tableLayoutPanel90.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel90.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel90.Size = new System.Drawing.Size(282, 1);
            this.tableLayoutPanel90.TabIndex = 0;
            // 
            // tableLayoutPanel88
            // 
            this.tableLayoutPanel88.ColumnCount = 2;
            this.tableLayoutPanel88.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel88.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel88.Controls.Add(this.totalLabelLabel, 1, 0);
            this.tableLayoutPanel88.Controls.Add(this.pictureBox6, 0, 0);
            this.tableLayoutPanel88.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel88.Location = new System.Drawing.Point(3, 87);
            this.tableLayoutPanel88.Name = "tableLayoutPanel88";
            this.tableLayoutPanel88.RowCount = 1;
            this.tableLayoutPanel88.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel88.Size = new System.Drawing.Size(279, 79);
            this.tableLayoutPanel88.TabIndex = 2;
            // 
            // totalLabelLabel
            // 
            this.totalLabelLabel.AutoSize = true;
            this.totalLabelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalLabelLabel.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabelLabel.ForeColor = System.Drawing.Color.Black;
            this.totalLabelLabel.Location = new System.Drawing.Point(85, 0);
            this.totalLabelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalLabelLabel.Name = "totalLabelLabel";
            this.totalLabelLabel.Size = new System.Drawing.Size(192, 79);
            this.totalLabelLabel.TabIndex = 3;
            this.totalLabelLabel.Text = "TOTAL :";
            this.totalLabelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox6.Image = global::Snap_and_Print.Properties.Resources.cash_line;
            this.pictureBox6.Location = new System.Drawing.Point(20, 10);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(20, 10, 0, 10);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(63, 59);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 4;
            this.pictureBox6.TabStop = false;
            // 
            // tableLayoutPanel91
            // 
            this.tableLayoutPanel91.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel91.ColumnCount = 1;
            this.tableLayoutPanel91.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel91.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel91.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel91.Location = new System.Drawing.Point(285, 86);
            this.tableLayoutPanel91.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tableLayoutPanel91.Name = "tableLayoutPanel91";
            this.tableLayoutPanel91.RowCount = 1;
            this.tableLayoutPanel91.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel91.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel91.Size = new System.Drawing.Size(282, 1);
            this.tableLayoutPanel91.TabIndex = 1;
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.ColumnCount = 2;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel20.Controls.Add(this.tableLayoutPanel21, 1, 0);
            this.tableLayoutPanel20.Controls.Add(this.pictureBox5, 0, 0);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(288, 3);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 1;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.Size = new System.Drawing.Size(279, 77);
            this.tableLayoutPanel20.TabIndex = 1;
            // 
            // tableLayoutPanel21
            // 
            this.tableLayoutPanel21.ColumnCount = 1;
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel21.Controls.Add(this.printerStatus, 0, 0);
            this.tableLayoutPanel21.Controls.Add(this.printerStatusLabel, 0, 1);
            this.tableLayoutPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel21.Location = new System.Drawing.Point(86, 3);
            this.tableLayoutPanel21.Name = "tableLayoutPanel21";
            this.tableLayoutPanel21.RowCount = 2;
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel21.Size = new System.Drawing.Size(190, 71);
            this.tableLayoutPanel21.TabIndex = 0;
            // 
            // printerStatus
            // 
            this.printerStatus.AutoSize = true;
            this.printerStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printerStatus.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printerStatus.ForeColor = System.Drawing.Color.Black;
            this.printerStatus.Location = new System.Drawing.Point(3, 0);
            this.printerStatus.Name = "printerStatus";
            this.printerStatus.Size = new System.Drawing.Size(184, 35);
            this.printerStatus.TabIndex = 11;
            this.printerStatus.Text = "Printer Status";
            this.printerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // printerStatusLabel
            // 
            this.printerStatusLabel.AutoSize = true;
            this.printerStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printerStatusLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printerStatusLabel.ForeColor = System.Drawing.Color.Black;
            this.printerStatusLabel.Location = new System.Drawing.Point(3, 35);
            this.printerStatusLabel.Name = "printerStatusLabel";
            this.printerStatusLabel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.printerStatusLabel.Size = new System.Drawing.Size(184, 36);
            this.printerStatusLabel.TabIndex = 10;
            this.printerStatusLabel.Text = "[Ready]";
            this.printerStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox5.Image = global::Snap_and_Print.Properties.Resources.printer_line;
            this.pictureBox5.Location = new System.Drawing.Point(20, 10);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(20, 10, 0, 10);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(63, 57);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 1;
            this.pictureBox5.TabStop = false;
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.ColumnCount = 2;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel24, 1, 0);
            this.tableLayoutPanel19.Controls.Add(this.pictureBox4, 0, 0);
            this.tableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel19.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 1;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(279, 77);
            this.tableLayoutPanel19.TabIndex = 0;
            // 
            // tableLayoutPanel24
            // 
            this.tableLayoutPanel24.ColumnCount = 1;
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel24.Controls.Add(this.totalPagesLabel, 0, 1);
            this.tableLayoutPanel24.Controls.Add(this.totalPagesLabelLabel, 0, 0);
            this.tableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel24.Location = new System.Drawing.Point(86, 3);
            this.tableLayoutPanel24.Name = "tableLayoutPanel24";
            this.tableLayoutPanel24.RowCount = 2;
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel24.Size = new System.Drawing.Size(190, 71);
            this.tableLayoutPanel24.TabIndex = 0;
            // 
            // totalPagesLabel
            // 
            this.totalPagesLabel.AutoSize = true;
            this.totalPagesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalPagesLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPagesLabel.ForeColor = System.Drawing.Color.Black;
            this.totalPagesLabel.Location = new System.Drawing.Point(2, 35);
            this.totalPagesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalPagesLabel.Name = "totalPagesLabel";
            this.totalPagesLabel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.totalPagesLabel.Size = new System.Drawing.Size(186, 36);
            this.totalPagesLabel.TabIndex = 5;
            this.totalPagesLabel.Text = "[0]";
            this.totalPagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalPagesLabelLabel
            // 
            this.totalPagesLabelLabel.AutoSize = true;
            this.totalPagesLabelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalPagesLabelLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPagesLabelLabel.ForeColor = System.Drawing.Color.Black;
            this.totalPagesLabelLabel.Location = new System.Drawing.Point(2, 0);
            this.totalPagesLabelLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalPagesLabelLabel.Name = "totalPagesLabelLabel";
            this.totalPagesLabelLabel.Size = new System.Drawing.Size(186, 35);
            this.totalPagesLabelLabel.TabIndex = 2;
            this.totalPagesLabelLabel.Text = "Total Pages";
            this.totalPagesLabelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Image = global::Snap_and_Print.Properties.Resources.file_copy_2_line;
            this.pictureBox4.Location = new System.Drawing.Point(20, 10);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(20, 10, 0, 10);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(63, 57);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // tableLayoutPanel89
            // 
            this.tableLayoutPanel89.ColumnCount = 2;
            this.tableLayoutPanel89.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel89.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel89.Controls.Add(this.totalLabel, 1, 0);
            this.tableLayoutPanel89.Controls.Add(this.pictureBox8, 0, 0);
            this.tableLayoutPanel89.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel89.Location = new System.Drawing.Point(288, 87);
            this.tableLayoutPanel89.Name = "tableLayoutPanel89";
            this.tableLayoutPanel89.RowCount = 1;
            this.tableLayoutPanel89.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel89.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel89.Size = new System.Drawing.Size(279, 79);
            this.tableLayoutPanel89.TabIndex = 2;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalLabel.Font = new System.Drawing.Font("Segoe UI Black", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.Color.Black;
            this.totalLabel.Location = new System.Drawing.Point(85, 0);
            this.totalLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.totalLabel.Size = new System.Drawing.Size(192, 79);
            this.totalLabel.TabIndex = 6;
            this.totalLabel.Text = "[Pesos]";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox8.Image = global::Snap_and_Print.Properties.Resources.peso;
            this.pictureBox8.Location = new System.Drawing.Point(20, 10);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(20, 10, 0, 10);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(63, 59);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 7;
            this.pictureBox8.TabStop = false;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 1;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Controls.Add(this.panel14, 0, 1);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(829, 3);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 2;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(624, 636);
            this.tableLayoutPanel16.TabIndex = 3;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Silver;
            this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel14.Controls.Add(this.tableLayoutPanel92);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(20, 147);
            this.panel14.Margin = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(5);
            this.panel14.Size = new System.Drawing.Size(584, 479);
            this.panel14.TabIndex = 2;
            // 
            // tableLayoutPanel92
            // 
            this.tableLayoutPanel92.ColumnCount = 1;
            this.tableLayoutPanel92.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel92.Controls.Add(this.tableLayoutPanel83, 0, 2);
            this.tableLayoutPanel92.Controls.Add(this.tableLayoutPanel82, 0, 0);
            this.tableLayoutPanel92.Controls.Add(this.previewPanelSettingLayout, 0, 1);
            this.tableLayoutPanel92.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel92.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel92.Name = "tableLayoutPanel92";
            this.tableLayoutPanel92.RowCount = 3;
            this.tableLayoutPanel92.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel92.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82F));
            this.tableLayoutPanel92.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel92.Size = new System.Drawing.Size(572, 467);
            this.tableLayoutPanel92.TabIndex = 0;
            // 
            // tableLayoutPanel83
            // 
            this.tableLayoutPanel83.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel83.ColumnCount = 3;
            this.tableLayoutPanel83.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel83.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel83.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel83.Controls.Add(this.editBtn, 2, 0);
            this.tableLayoutPanel83.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel83.Location = new System.Drawing.Point(0, 419);
            this.tableLayoutPanel83.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tableLayoutPanel83.Name = "tableLayoutPanel83";
            this.tableLayoutPanel83.RowCount = 1;
            this.tableLayoutPanel83.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel83.Size = new System.Drawing.Size(572, 45);
            this.tableLayoutPanel83.TabIndex = 2;
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.Silver;
            this.editBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.editBtn.FlatAppearance.BorderSize = 2;
            this.editBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.editBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.editBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Image = global::Snap_and_Print.Properties.Resources.edit_circle_line;
            this.editBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editBtn.Location = new System.Drawing.Point(425, 5);
            this.editBtn.Margin = new System.Windows.Forms.Padding(25, 5, 25, 5);
            this.editBtn.Name = "editBtn";
            this.editBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.editBtn.Size = new System.Drawing.Size(122, 35);
            this.editBtn.TabIndex = 0;
            this.editBtn.Text = "EDIT";
            this.editBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // tableLayoutPanel82
            // 
            this.tableLayoutPanel82.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel82.ColumnCount = 3;
            this.tableLayoutPanel82.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel82.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel82.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel82.Controls.Add(this.tableLayoutPanel84, 0, 0);
            this.tableLayoutPanel82.Controls.Add(this.pagesPreviewLabel, 1, 0);
            this.tableLayoutPanel82.Controls.Add(this.filesizepreview, 2, 0);
            this.tableLayoutPanel82.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel82.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel82.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tableLayoutPanel82.Name = "tableLayoutPanel82";
            this.tableLayoutPanel82.RowCount = 1;
            this.tableLayoutPanel82.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel82.Size = new System.Drawing.Size(572, 34);
            this.tableLayoutPanel82.TabIndex = 1;
            // 
            // tableLayoutPanel84
            // 
            this.tableLayoutPanel84.ColumnCount = 2;
            this.tableLayoutPanel84.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel84.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel84.Controls.Add(this.fileNameLabel, 1, 0);
            this.tableLayoutPanel84.Controls.Add(this.pictureBox7, 0, 0);
            this.tableLayoutPanel84.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel84.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel84.Name = "tableLayoutPanel84";
            this.tableLayoutPanel84.RowCount = 1;
            this.tableLayoutPanel84.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel84.Size = new System.Drawing.Size(337, 28);
            this.tableLayoutPanel84.TabIndex = 1;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileNameLabel.ForeColor = System.Drawing.Color.Silver;
            this.fileNameLabel.Location = new System.Drawing.Point(70, 0);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(264, 28);
            this.fileNameLabel.TabIndex = 0;
            this.fileNameLabel.Text = "File Name";
            this.fileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox7.Image = global::Snap_and_Print.Properties.Resources.printPreviewFile;
            this.pictureBox7.Location = new System.Drawing.Point(3, 3);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(61, 22);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 1;
            this.pictureBox7.TabStop = false;
            // 
            // pagesPreviewLabel
            // 
            this.pagesPreviewLabel.AutoSize = true;
            this.pagesPreviewLabel.BackColor = System.Drawing.Color.Transparent;
            this.pagesPreviewLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pagesPreviewLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagesPreviewLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagesPreviewLabel.ForeColor = System.Drawing.Color.Silver;
            this.pagesPreviewLabel.Location = new System.Drawing.Point(346, 3);
            this.pagesPreviewLabel.Margin = new System.Windows.Forms.Padding(3);
            this.pagesPreviewLabel.Name = "pagesPreviewLabel";
            this.pagesPreviewLabel.Size = new System.Drawing.Size(108, 28);
            this.pagesPreviewLabel.TabIndex = 2;
            this.pagesPreviewLabel.Text = "0 Pages";
            this.pagesPreviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // filesizepreview
            // 
            this.filesizepreview.AutoSize = true;
            this.filesizepreview.BackColor = System.Drawing.Color.Transparent;
            this.filesizepreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filesizepreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesizepreview.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesizepreview.ForeColor = System.Drawing.Color.Silver;
            this.filesizepreview.Location = new System.Drawing.Point(460, 3);
            this.filesizepreview.Margin = new System.Windows.Forms.Padding(3);
            this.filesizepreview.Name = "filesizepreview";
            this.filesizepreview.Size = new System.Drawing.Size(109, 28);
            this.filesizepreview.TabIndex = 3;
            this.filesizepreview.Text = "0 kb";
            this.filesizepreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewPanelSettingLayout
            // 
            this.previewPanelSettingLayout.BackColor = System.Drawing.Color.Transparent;
            this.previewPanelSettingLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPanelSettingLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPanelSettingLayout.Location = new System.Drawing.Point(0, 37);
            this.previewPanelSettingLayout.Margin = new System.Windows.Forms.Padding(0);
            this.previewPanelSettingLayout.Name = "previewPanelSettingLayout";
            this.previewPanelSettingLayout.Size = new System.Drawing.Size(572, 382);
            this.previewPanelSettingLayout.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.Controls.Add(this.continuePaymentBtn, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel77, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 642);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1456, 87);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // continuePaymentBtn
            // 
            this.continuePaymentBtn.BackColor = System.Drawing.Color.Silver;
            this.continuePaymentBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.continuePaymentBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continuePaymentBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.continuePaymentBtn.FlatAppearance.BorderSize = 2;
            this.continuePaymentBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.continuePaymentBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.continuePaymentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continuePaymentBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continuePaymentBtn.ForeColor = System.Drawing.Color.Black;
            this.continuePaymentBtn.Image = global::Snap_and_Print.Properties.Resources.printContinue;
            this.continuePaymentBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.continuePaymentBtn.Location = new System.Drawing.Point(1105, 10);
            this.continuePaymentBtn.Margin = new System.Windows.Forms.Padding(135, 10, 135, 10);
            this.continuePaymentBtn.Name = "continuePaymentBtn";
            this.continuePaymentBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.continuePaymentBtn.Size = new System.Drawing.Size(216, 67);
            this.continuePaymentBtn.TabIndex = 0;
            this.continuePaymentBtn.Text = "CONTINUE";
            this.continuePaymentBtn.UseVisualStyleBackColor = false;
            this.continuePaymentBtn.Click += new System.EventHandler(this.proceedBtn_Click);
            // 
            // tableLayoutPanel77
            // 
            this.tableLayoutPanel77.ColumnCount = 2;
            this.tableLayoutPanel77.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel77.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel77.Controls.Add(this.settingsBackBtn, 1, 0);
            this.tableLayoutPanel77.Controls.Add(this.printSettingsCancelBtn, 0, 0);
            this.tableLayoutPanel77.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel77.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel77.Name = "tableLayoutPanel77";
            this.tableLayoutPanel77.RowCount = 1;
            this.tableLayoutPanel77.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel77.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel77.Size = new System.Drawing.Size(479, 81);
            this.tableLayoutPanel77.TabIndex = 4;
            // 
            // settingsBackBtn
            // 
            this.settingsBackBtn.BackColor = System.Drawing.Color.Silver;
            this.settingsBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsBackBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.settingsBackBtn.FlatAppearance.BorderSize = 2;
            this.settingsBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.settingsBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.settingsBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsBackBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsBackBtn.ForeColor = System.Drawing.Color.Black;
            this.settingsBackBtn.Image = global::Snap_and_Print.Properties.Resources.printBack;
            this.settingsBackBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsBackBtn.Location = new System.Drawing.Point(269, 10);
            this.settingsBackBtn.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.settingsBackBtn.Name = "settingsBackBtn";
            this.settingsBackBtn.Padding = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.settingsBackBtn.Size = new System.Drawing.Size(180, 60);
            this.settingsBackBtn.TabIndex = 1;
            this.settingsBackBtn.TabStop = false;
            this.settingsBackBtn.Text = "BACK";
            this.settingsBackBtn.UseVisualStyleBackColor = false;
            // 
            // printSettingsCancelBtn
            // 
            this.printSettingsCancelBtn.BackColor = System.Drawing.Color.Silver;
            this.printSettingsCancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printSettingsCancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.printSettingsCancelBtn.FlatAppearance.BorderSize = 2;
            this.printSettingsCancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.printSettingsCancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.printSettingsCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printSettingsCancelBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printSettingsCancelBtn.ForeColor = System.Drawing.Color.Black;
            this.printSettingsCancelBtn.Image = global::Snap_and_Print.Properties.Resources.printCancel;
            this.printSettingsCancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.printSettingsCancelBtn.Location = new System.Drawing.Point(30, 10);
            this.printSettingsCancelBtn.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.printSettingsCancelBtn.Name = "printSettingsCancelBtn";
            this.printSettingsCancelBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.printSettingsCancelBtn.Size = new System.Drawing.Size(179, 60);
            this.printSettingsCancelBtn.TabIndex = 2;
            this.printSettingsCancelBtn.Text = "CANCEL";
            this.printSettingsCancelBtn.UseVisualStyleBackColor = false;
            this.printSettingsCancelBtn.Click += new System.EventHandler(this.printSettingsCancelBtn_Click);
            // 
            // retrivalPanel
            // 
            this.retrivalPanel.Controls.Add(this.retrivalMain);
            this.retrivalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retrivalPanel.Location = new System.Drawing.Point(0, 0);
            this.retrivalPanel.Margin = new System.Windows.Forms.Padding(2);
            this.retrivalPanel.Name = "retrivalPanel";
            this.retrivalPanel.Size = new System.Drawing.Size(1456, 729);
            this.retrivalPanel.TabIndex = 1;
            // 
            // retrivalMain
            // 
            this.retrivalMain.ColumnCount = 3;
            this.retrivalMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.69052F));
            this.retrivalMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.61897F));
            this.retrivalMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.69051F));
            this.retrivalMain.Controls.Add(this.retrivalCodeLabel, 1, 0);
            this.retrivalMain.Controls.Add(this.retrivalCodeTextBox, 1, 1);
            this.retrivalMain.Controls.Add(this.tableLayoutPanel97, 1, 3);
            this.retrivalMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.retrivalMain.Location = new System.Drawing.Point(0, 274);
            this.retrivalMain.Margin = new System.Windows.Forms.Padding(2);
            this.retrivalMain.Name = "retrivalMain";
            this.retrivalMain.RowCount = 4;
            this.retrivalMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.97805F));
            this.retrivalMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.97804F));
            this.retrivalMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.535451F));
            this.retrivalMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.50846F));
            this.retrivalMain.Size = new System.Drawing.Size(1456, 455);
            this.retrivalMain.TabIndex = 4;
            // 
            // retrivalCodeLabel
            // 
            this.retrivalCodeLabel.AutoSize = true;
            this.retrivalCodeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retrivalCodeLabel.Font = new System.Drawing.Font("Segoe UI Black", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retrivalCodeLabel.ForeColor = System.Drawing.Color.Black;
            this.retrivalCodeLabel.Location = new System.Drawing.Point(186, 50);
            this.retrivalCodeLabel.Margin = new System.Windows.Forms.Padding(2, 50, 2, 0);
            this.retrivalCodeLabel.Name = "retrivalCodeLabel";
            this.retrivalCodeLabel.Size = new System.Drawing.Size(1082, 68);
            this.retrivalCodeLabel.TabIndex = 1;
            this.retrivalCodeLabel.Text = "ENTER RETRIEVAL CODE";
            this.retrivalCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // retrivalCodeTextBox
            // 
            this.retrivalCodeTextBox.BackColor = System.Drawing.Color.Silver;
            this.retrivalCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.retrivalCodeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.retrivalCodeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retrivalCodeTextBox.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retrivalCodeTextBox.ForeColor = System.Drawing.Color.Black;
            this.retrivalCodeTextBox.Location = new System.Drawing.Point(484, 138);
            this.retrivalCodeTextBox.Margin = new System.Windows.Forms.Padding(300, 20, 300, 2);
            this.retrivalCodeTextBox.Name = "retrivalCodeTextBox";
            this.retrivalCodeTextBox.Size = new System.Drawing.Size(486, 71);
            this.retrivalCodeTextBox.TabIndex = 0;
            this.retrivalCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel97
            // 
            this.tableLayoutPanel97.ColumnCount = 2;
            this.tableLayoutPanel97.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel97.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel97.Controls.Add(this.retrieveCancelBtn, 0, 0);
            this.tableLayoutPanel97.Controls.Add(this.loadRetrievalBtn, 1, 0);
            this.tableLayoutPanel97.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel97.Location = new System.Drawing.Point(187, 268);
            this.tableLayoutPanel97.Name = "tableLayoutPanel97";
            this.tableLayoutPanel97.RowCount = 1;
            this.tableLayoutPanel97.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel97.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanel97.Size = new System.Drawing.Size(1080, 184);
            this.tableLayoutPanel97.TabIndex = 4;
            // 
            // retrieveCancelBtn
            // 
            this.retrieveCancelBtn.BackColor = System.Drawing.Color.Silver;
            this.retrieveCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retrieveCancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.retrieveCancelBtn.FlatAppearance.BorderSize = 2;
            this.retrieveCancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.retrieveCancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.retrieveCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.retrieveCancelBtn.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retrieveCancelBtn.Image = global::Snap_and_Print.Properties.Resources.printCancel;
            this.retrieveCancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.retrieveCancelBtn.Location = new System.Drawing.Point(200, 10);
            this.retrieveCancelBtn.Margin = new System.Windows.Forms.Padding(200, 10, 50, 100);
            this.retrieveCancelBtn.Name = "retrieveCancelBtn";
            this.retrieveCancelBtn.Padding = new System.Windows.Forms.Padding(50, 0, 30, 0);
            this.retrieveCancelBtn.Size = new System.Drawing.Size(290, 74);
            this.retrieveCancelBtn.TabIndex = 3;
            this.retrieveCancelBtn.Text = "CANCEL";
            this.retrieveCancelBtn.UseVisualStyleBackColor = false;
            this.retrieveCancelBtn.Click += new System.EventHandler(this.retrieveCancelBtn_Click);
            // 
            // loadRetrievalBtn
            // 
            this.loadRetrievalBtn.BackColor = System.Drawing.Color.Silver;
            this.loadRetrievalBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadRetrievalBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.loadRetrievalBtn.FlatAppearance.BorderSize = 2;
            this.loadRetrievalBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.loadRetrievalBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.loadRetrievalBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadRetrievalBtn.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadRetrievalBtn.Image = global::Snap_and_Print.Properties.Resources.folder_received_fill;
            this.loadRetrievalBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadRetrievalBtn.Location = new System.Drawing.Point(590, 10);
            this.loadRetrievalBtn.Margin = new System.Windows.Forms.Padding(50, 10, 200, 100);
            this.loadRetrievalBtn.Name = "loadRetrievalBtn";
            this.loadRetrievalBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.loadRetrievalBtn.Size = new System.Drawing.Size(290, 74);
            this.loadRetrievalBtn.TabIndex = 2;
            this.loadRetrievalBtn.Text = "RETRIEVE FILE";
            this.loadRetrievalBtn.UseVisualStyleBackColor = false;
            this.loadRetrievalBtn.Click += new System.EventHandler(this.loadRetrievalBtn_Click);
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
            this.continuePanel.Size = new System.Drawing.Size(1456, 729);
            this.continuePanel.TabIndex = 7;
            // 
            // continueBtn
            // 
            this.continueBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueBtn.Location = new System.Drawing.Point(487, 245);
            this.continueBtn.Margin = new System.Windows.Forms.Padding(2);
            this.continueBtn.Name = "continueBtn";
            this.continueBtn.Size = new System.Drawing.Size(481, 239);
            this.continueBtn.TabIndex = 0;
            this.continueBtn.Text = "CONTINUE";
            this.continueBtn.UseVisualStyleBackColor = true;
            this.continueBtn.Click += new System.EventHandler(this.continueBtn_Click);
            // 
            // photoPanel
            // 
            this.photoPanel.BackColor = System.Drawing.Color.Transparent;
            this.photoPanel.BackgroundImage = global::Snap_and_Print.Properties.Resources.SnapAndPrintBg;
            this.photoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.photoPanel.Controls.Add(this.photoIDPanel);
            this.photoPanel.Controls.Add(this.photoBoothPanel);
            this.photoPanel.Controls.Add(this.photoMode);
            this.photoPanel.Controls.Add(this.retrievalPanelPhoto);
            this.photoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoPanel.Location = new System.Drawing.Point(0, 0);
            this.photoPanel.Margin = new System.Windows.Forms.Padding(50, 10, 200, 100);
            this.photoPanel.Name = "photoPanel";
            this.photoPanel.Size = new System.Drawing.Size(1456, 729);
            this.photoPanel.TabIndex = 0;
            // 
            // photoIDPanel
            // 
            this.photoIDPanel.BackColor = System.Drawing.Color.Transparent;
            this.photoIDPanel.BackgroundImage = global::Snap_and_Print.Properties.Resources.IDphotoBg1;
            this.photoIDPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.photoIDPanel.Controls.Add(this.IDpayment);
            this.photoIDPanel.Controls.Add(this.panelCRMidPrinting);
            this.photoIDPanel.Controls.Add(this.idPrintingSettings);
            this.photoIDPanel.Controls.Add(this.softCopyDownloadId);
            this.photoIDPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoIDPanel.Location = new System.Drawing.Point(0, 0);
            this.photoIDPanel.Name = "photoIDPanel";
            this.photoIDPanel.Size = new System.Drawing.Size(1456, 729);
            this.photoIDPanel.TabIndex = 2;
            // 
            // IDpayment
            // 
            this.IDpayment.Controls.Add(this.panel4);
            this.IDpayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IDpayment.Location = new System.Drawing.Point(0, 0);
            this.IDpayment.Name = "IDpayment";
            this.IDpayment.Size = new System.Drawing.Size(1456, 729);
            this.IDpayment.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel51);
            this.panel4.Controls.Add(this.tableLayoutPanel47);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1456, 729);
            this.panel4.TabIndex = 6;
            // 
            // tableLayoutPanel51
            // 
            this.tableLayoutPanel51.ColumnCount = 1;
            this.tableLayoutPanel51.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel51.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel51.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel51.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanel51.Controls.Add(this.button3, 0, 2);
            this.tableLayoutPanel51.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel51.Location = new System.Drawing.Point(1256, 0);
            this.tableLayoutPanel51.Name = "tableLayoutPanel51";
            this.tableLayoutPanel51.RowCount = 3;
            this.tableLayoutPanel51.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel51.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel51.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel51.Size = new System.Drawing.Size(200, 230);
            this.tableLayoutPanel51.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "5";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "10";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 155);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "20";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel47
            // 
            this.tableLayoutPanel47.ColumnCount = 1;
            this.tableLayoutPanel47.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel47.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel47.Controls.Add(this.tableLayoutPanel53, 0, 0);
            this.tableLayoutPanel47.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel47.Location = new System.Drawing.Point(0, 230);
            this.tableLayoutPanel47.Name = "tableLayoutPanel47";
            this.tableLayoutPanel47.RowCount = 1;
            this.tableLayoutPanel47.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel47.Size = new System.Drawing.Size(1456, 499);
            this.tableLayoutPanel47.TabIndex = 0;
            // 
            // tableLayoutPanel53
            // 
            this.tableLayoutPanel53.ColumnCount = 3;
            this.tableLayoutPanel53.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel53.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel53.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel53.Controls.Add(this.tableLayoutPanel125, 1, 0);
            this.tableLayoutPanel53.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel53.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel53.Name = "tableLayoutPanel53";
            this.tableLayoutPanel53.RowCount = 1;
            this.tableLayoutPanel53.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel53.Size = new System.Drawing.Size(1450, 493);
            this.tableLayoutPanel53.TabIndex = 6;
            // 
            // tableLayoutPanel125
            // 
            this.tableLayoutPanel125.ColumnCount = 1;
            this.tableLayoutPanel125.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel125.Controls.Add(this.tableLayoutPanel52, 0, 1);
            this.tableLayoutPanel125.Controls.Add(this.panel20, 0, 0);
            this.tableLayoutPanel125.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel125.Location = new System.Drawing.Point(293, 3);
            this.tableLayoutPanel125.Name = "tableLayoutPanel125";
            this.tableLayoutPanel125.RowCount = 2;
            this.tableLayoutPanel125.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel125.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel125.Size = new System.Drawing.Size(864, 487);
            this.tableLayoutPanel125.TabIndex = 0;
            // 
            // tableLayoutPanel52
            // 
            this.tableLayoutPanel52.ColumnCount = 4;
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel52.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel52.Controls.Add(this.cancelBtnPaymentId, 0, 0);
            this.tableLayoutPanel52.Controls.Add(this.backBtnPaymentId, 1, 0);
            this.tableLayoutPanel52.Controls.Add(this.downloadBtnPaymentId, 3, 0);
            this.tableLayoutPanel52.Controls.Add(this.printBtnPaymentId, 2, 0);
            this.tableLayoutPanel52.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel52.Location = new System.Drawing.Point(3, 392);
            this.tableLayoutPanel52.Name = "tableLayoutPanel52";
            this.tableLayoutPanel52.RowCount = 1;
            this.tableLayoutPanel52.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel52.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel52.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel52.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel52.Size = new System.Drawing.Size(858, 92);
            this.tableLayoutPanel52.TabIndex = 2;
            // 
            // cancelBtnPaymentId
            // 
            this.cancelBtnPaymentId.BackColor = System.Drawing.Color.DarkGray;
            this.cancelBtnPaymentId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelBtnPaymentId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelBtnPaymentId.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.cancelBtnPaymentId.FlatAppearance.BorderSize = 2;
            this.cancelBtnPaymentId.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cancelBtnPaymentId.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.cancelBtnPaymentId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtnPaymentId.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtnPaymentId.Image = global::Snap_and_Print.Properties.Resources.printCancel;
            this.cancelBtnPaymentId.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtnPaymentId.Location = new System.Drawing.Point(20, 10);
            this.cancelBtnPaymentId.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.cancelBtnPaymentId.Name = "cancelBtnPaymentId";
            this.cancelBtnPaymentId.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.cancelBtnPaymentId.Size = new System.Drawing.Size(174, 72);
            this.cancelBtnPaymentId.TabIndex = 0;
            this.cancelBtnPaymentId.Text = "CANCEL";
            this.cancelBtnPaymentId.UseVisualStyleBackColor = false;
            this.cancelBtnPaymentId.Click += new System.EventHandler(this.cancelBtnPaymentId_Click);
            // 
            // backBtnPaymentId
            // 
            this.backBtnPaymentId.BackColor = System.Drawing.Color.DarkGray;
            this.backBtnPaymentId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backBtnPaymentId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backBtnPaymentId.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.backBtnPaymentId.FlatAppearance.BorderSize = 2;
            this.backBtnPaymentId.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.backBtnPaymentId.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.backBtnPaymentId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtnPaymentId.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtnPaymentId.Image = global::Snap_and_Print.Properties.Resources.printBack;
            this.backBtnPaymentId.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.backBtnPaymentId.Location = new System.Drawing.Point(234, 10);
            this.backBtnPaymentId.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.backBtnPaymentId.Name = "backBtnPaymentId";
            this.backBtnPaymentId.Padding = new System.Windows.Forms.Padding(30, 0, 10, 0);
            this.backBtnPaymentId.Size = new System.Drawing.Size(174, 72);
            this.backBtnPaymentId.TabIndex = 1;
            this.backBtnPaymentId.Text = "BACK";
            this.backBtnPaymentId.UseVisualStyleBackColor = false;
            this.backBtnPaymentId.Click += new System.EventHandler(this.backBtnPaymentId_Click);
            // 
            // downloadBtnPaymentId
            // 
            this.downloadBtnPaymentId.BackColor = System.Drawing.Color.DarkGray;
            this.downloadBtnPaymentId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadBtnPaymentId.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.downloadBtnPaymentId.FlatAppearance.BorderSize = 2;
            this.downloadBtnPaymentId.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.downloadBtnPaymentId.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.downloadBtnPaymentId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadBtnPaymentId.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadBtnPaymentId.Image = global::Snap_and_Print.Properties.Resources.mail_download_fill;
            this.downloadBtnPaymentId.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.downloadBtnPaymentId.Location = new System.Drawing.Point(662, 10);
            this.downloadBtnPaymentId.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.downloadBtnPaymentId.Name = "downloadBtnPaymentId";
            this.downloadBtnPaymentId.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.downloadBtnPaymentId.Size = new System.Drawing.Size(176, 72);
            this.downloadBtnPaymentId.TabIndex = 3;
            this.downloadBtnPaymentId.Text = "DOWNLOAD";
            this.downloadBtnPaymentId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.downloadBtnPaymentId.UseVisualStyleBackColor = false;
            this.downloadBtnPaymentId.Click += new System.EventHandler(this.downloadBtnPaymentId_Click);
            // 
            // printBtnPaymentId
            // 
            this.printBtnPaymentId.BackColor = System.Drawing.Color.DarkGray;
            this.printBtnPaymentId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printBtnPaymentId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printBtnPaymentId.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.printBtnPaymentId.FlatAppearance.BorderSize = 2;
            this.printBtnPaymentId.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.printBtnPaymentId.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.printBtnPaymentId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printBtnPaymentId.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtnPaymentId.Image = global::Snap_and_Print.Properties.Resources.printer_fill;
            this.printBtnPaymentId.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.printBtnPaymentId.Location = new System.Drawing.Point(448, 10);
            this.printBtnPaymentId.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.printBtnPaymentId.Name = "printBtnPaymentId";
            this.printBtnPaymentId.Padding = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.printBtnPaymentId.Size = new System.Drawing.Size(174, 72);
            this.printBtnPaymentId.TabIndex = 2;
            this.printBtnPaymentId.Text = "PRINT";
            this.printBtnPaymentId.UseVisualStyleBackColor = false;
            this.printBtnPaymentId.Click += new System.EventHandler(this.printBtnPaymentId_Click);
            // 
            // panel20
            // 
            this.panel20.BackColor = System.Drawing.Color.Silver;
            this.panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel20.Controls.Add(this.tableLayoutPanel126);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel20.Location = new System.Drawing.Point(160, 10);
            this.panel20.Margin = new System.Windows.Forms.Padding(160, 10, 160, 10);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(544, 369);
            this.panel20.TabIndex = 0;
            // 
            // tableLayoutPanel126
            // 
            this.tableLayoutPanel126.ColumnCount = 1;
            this.tableLayoutPanel126.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel126.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel126.Controls.Add(this.idprintingStatusLabel, 0, 10);
            this.tableLayoutPanel126.Controls.Add(this.tableLayoutPanel123, 0, 4);
            this.tableLayoutPanel126.Controls.Add(this.tableLayoutPanel127, 0, 1);
            this.tableLayoutPanel126.Controls.Add(this.tableLayoutPanel113, 0, 2);
            this.tableLayoutPanel126.Controls.Add(this.tableLayoutPanel128, 0, 3);
            this.tableLayoutPanel126.Controls.Add(this.tableLayoutPanel129, 0, 5);
            this.tableLayoutPanel126.Controls.Add(this.tableLayoutPanel130, 0, 7);
            this.tableLayoutPanel126.Controls.Add(this.tableLayoutPanel131, 0, 9);
            this.tableLayoutPanel126.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel126.Controls.Add(this.tableLayoutPanel124, 0, 6);
            this.tableLayoutPanel126.Controls.Add(this.tableLayoutPanel132, 0, 8);
            this.tableLayoutPanel126.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel126.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel126.Name = "tableLayoutPanel126";
            this.tableLayoutPanel126.RowCount = 11;
            this.tableLayoutPanel126.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.79802F));
            this.tableLayoutPanel126.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9899009F));
            this.tableLayoutPanel126.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.33837F));
            this.tableLayoutPanel126.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9899009F));
            this.tableLayoutPanel126.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.33837F));
            this.tableLayoutPanel126.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9899009F));
            this.tableLayoutPanel126.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.33837F));
            this.tableLayoutPanel126.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9899009F));
            this.tableLayoutPanel126.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.33837F));
            this.tableLayoutPanel126.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9899009F));
            this.tableLayoutPanel126.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.89901F));
            this.tableLayoutPanel126.Size = new System.Drawing.Size(542, 367);
            this.tableLayoutPanel126.TabIndex = 0;
            // 
            // idprintingStatusLabel
            // 
            this.idprintingStatusLabel.AutoSize = true;
            this.idprintingStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idprintingStatusLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idprintingStatusLabel.ForeColor = System.Drawing.Color.Black;
            this.idprintingStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.idprintingStatusLabel.Location = new System.Drawing.Point(160, 328);
            this.idprintingStatusLabel.Margin = new System.Windows.Forms.Padding(160, 5, 160, 5);
            this.idprintingStatusLabel.Name = "idprintingStatusLabel";
            this.idprintingStatusLabel.Size = new System.Drawing.Size(222, 34);
            this.idprintingStatusLabel.TabIndex = 7;
            this.idprintingStatusLabel.Text = "...";
            this.idprintingStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel123
            // 
            this.tableLayoutPanel123.ColumnCount = 2;
            this.tableLayoutPanel123.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel123.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel123.Controls.Add(this.label27, 0, 0);
            this.tableLayoutPanel123.Controls.Add(this.paymentIDBalance, 1, 0);
            this.tableLayoutPanel123.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel123.Location = new System.Drawing.Point(3, 140);
            this.tableLayoutPanel123.Name = "tableLayoutPanel123";
            this.tableLayoutPanel123.RowCount = 1;
            this.tableLayoutPanel123.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel123.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel123.Size = new System.Drawing.Size(536, 53);
            this.tableLayoutPanel123.TabIndex = 8;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(3, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(262, 53);
            this.label27.TabIndex = 2;
            this.label27.Text = "Balance :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // paymentIDBalance
            // 
            this.paymentIDBalance.AutoSize = true;
            this.paymentIDBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentIDBalance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentIDBalance.Image = global::Snap_and_Print.Properties.Resources.peso__1_;
            this.paymentIDBalance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentIDBalance.Location = new System.Drawing.Point(271, 0);
            this.paymentIDBalance.Name = "paymentIDBalance";
            this.paymentIDBalance.Padding = new System.Windows.Forms.Padding(0, 0, 140, 0);
            this.paymentIDBalance.Size = new System.Drawing.Size(262, 53);
            this.paymentIDBalance.TabIndex = 3;
            this.paymentIDBalance.Text = "[0]";
            this.paymentIDBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel127
            // 
            this.tableLayoutPanel127.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel127.ColumnCount = 1;
            this.tableLayoutPanel127.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel127.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel127.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel127.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tableLayoutPanel127.Location = new System.Drawing.Point(120, 75);
            this.tableLayoutPanel127.Margin = new System.Windows.Forms.Padding(120, 3, 120, 3);
            this.tableLayoutPanel127.Name = "tableLayoutPanel127";
            this.tableLayoutPanel127.RowCount = 1;
            this.tableLayoutPanel127.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel127.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel127.Size = new System.Drawing.Size(302, 1);
            this.tableLayoutPanel127.TabIndex = 0;
            // 
            // tableLayoutPanel113
            // 
            this.tableLayoutPanel113.ColumnCount = 2;
            this.tableLayoutPanel113.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel113.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel113.Controls.Add(this.paymentIDTotal, 1, 0);
            this.tableLayoutPanel113.Controls.Add(this.label25, 0, 0);
            this.tableLayoutPanel113.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel113.Location = new System.Drawing.Point(3, 78);
            this.tableLayoutPanel113.Name = "tableLayoutPanel113";
            this.tableLayoutPanel113.RowCount = 1;
            this.tableLayoutPanel113.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel113.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel113.Size = new System.Drawing.Size(536, 53);
            this.tableLayoutPanel113.TabIndex = 3;
            // 
            // paymentIDTotal
            // 
            this.paymentIDTotal.AutoSize = true;
            this.paymentIDTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentIDTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentIDTotal.Image = global::Snap_and_Print.Properties.Resources.peso__1_;
            this.paymentIDTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentIDTotal.Location = new System.Drawing.Point(271, 0);
            this.paymentIDTotal.Name = "paymentIDTotal";
            this.paymentIDTotal.Padding = new System.Windows.Forms.Padding(0, 0, 140, 0);
            this.paymentIDTotal.Size = new System.Drawing.Size(262, 53);
            this.paymentIDTotal.TabIndex = 1;
            this.paymentIDTotal.Text = "[0]";
            this.paymentIDTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(3, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(262, 53);
            this.label25.TabIndex = 0;
            this.label25.Text = "Total Payment :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel128
            // 
            this.tableLayoutPanel128.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel128.ColumnCount = 1;
            this.tableLayoutPanel128.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel128.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel128.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel128.Location = new System.Drawing.Point(80, 137);
            this.tableLayoutPanel128.Margin = new System.Windows.Forms.Padding(80, 3, 80, 3);
            this.tableLayoutPanel128.Name = "tableLayoutPanel128";
            this.tableLayoutPanel128.RowCount = 1;
            this.tableLayoutPanel128.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel128.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel128.Size = new System.Drawing.Size(382, 1);
            this.tableLayoutPanel128.TabIndex = 1;
            // 
            // tableLayoutPanel129
            // 
            this.tableLayoutPanel129.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel129.ColumnCount = 1;
            this.tableLayoutPanel129.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel129.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel129.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel129.Location = new System.Drawing.Point(80, 199);
            this.tableLayoutPanel129.Margin = new System.Windows.Forms.Padding(80, 3, 80, 3);
            this.tableLayoutPanel129.Name = "tableLayoutPanel129";
            this.tableLayoutPanel129.RowCount = 1;
            this.tableLayoutPanel129.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel129.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel129.Size = new System.Drawing.Size(382, 1);
            this.tableLayoutPanel129.TabIndex = 2;
            // 
            // tableLayoutPanel130
            // 
            this.tableLayoutPanel130.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel130.ColumnCount = 1;
            this.tableLayoutPanel130.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel130.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel130.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel130.Location = new System.Drawing.Point(80, 261);
            this.tableLayoutPanel130.Margin = new System.Windows.Forms.Padding(80, 3, 80, 3);
            this.tableLayoutPanel130.Name = "tableLayoutPanel130";
            this.tableLayoutPanel130.RowCount = 1;
            this.tableLayoutPanel130.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel130.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel130.Size = new System.Drawing.Size(382, 1);
            this.tableLayoutPanel130.TabIndex = 3;
            // 
            // tableLayoutPanel131
            // 
            this.tableLayoutPanel131.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel131.ColumnCount = 1;
            this.tableLayoutPanel131.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel131.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel131.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel131.Location = new System.Drawing.Point(150, 323);
            this.tableLayoutPanel131.Margin = new System.Windows.Forms.Padding(150, 3, 150, 3);
            this.tableLayoutPanel131.Name = "tableLayoutPanel131";
            this.tableLayoutPanel131.RowCount = 1;
            this.tableLayoutPanel131.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel131.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel131.Size = new System.Drawing.Size(242, 1);
            this.tableLayoutPanel131.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(536, 72);
            this.label14.TabIndex = 8;
            this.label14.Text = "Payment";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel124
            // 
            this.tableLayoutPanel124.ColumnCount = 2;
            this.tableLayoutPanel124.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel124.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel124.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel124.Controls.Add(this.paymentInsertedID, 1, 0);
            this.tableLayoutPanel124.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel124.Location = new System.Drawing.Point(3, 202);
            this.tableLayoutPanel124.Name = "tableLayoutPanel124";
            this.tableLayoutPanel124.RowCount = 1;
            this.tableLayoutPanel124.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel124.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel124.Size = new System.Drawing.Size(536, 53);
            this.tableLayoutPanel124.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(262, 53);
            this.label15.TabIndex = 0;
            this.label15.Text = "Payment Inserted :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // paymentInsertedID
            // 
            this.paymentInsertedID.AutoSize = true;
            this.paymentInsertedID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentInsertedID.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentInsertedID.Image = global::Snap_and_Print.Properties.Resources.peso__1_;
            this.paymentInsertedID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentInsertedID.Location = new System.Drawing.Point(271, 0);
            this.paymentInsertedID.Name = "paymentInsertedID";
            this.paymentInsertedID.Padding = new System.Windows.Forms.Padding(0, 0, 140, 0);
            this.paymentInsertedID.Size = new System.Drawing.Size(262, 53);
            this.paymentInsertedID.TabIndex = 1;
            this.paymentInsertedID.Text = "[0]";
            this.paymentInsertedID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel132
            // 
            this.tableLayoutPanel132.ColumnCount = 2;
            this.tableLayoutPanel132.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel132.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel132.Controls.Add(this.label16, 0, 0);
            this.tableLayoutPanel132.Controls.Add(this.paymentChangeID, 1, 0);
            this.tableLayoutPanel132.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel132.Location = new System.Drawing.Point(3, 264);
            this.tableLayoutPanel132.Name = "tableLayoutPanel132";
            this.tableLayoutPanel132.RowCount = 1;
            this.tableLayoutPanel132.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel132.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel132.Size = new System.Drawing.Size(536, 53);
            this.tableLayoutPanel132.TabIndex = 10;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(262, 53);
            this.label16.TabIndex = 0;
            this.label16.Text = "Change :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // paymentChangeID
            // 
            this.paymentChangeID.AutoSize = true;
            this.paymentChangeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentChangeID.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentChangeID.Image = global::Snap_and_Print.Properties.Resources.peso__1_;
            this.paymentChangeID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentChangeID.Location = new System.Drawing.Point(271, 0);
            this.paymentChangeID.Name = "paymentChangeID";
            this.paymentChangeID.Padding = new System.Windows.Forms.Padding(0, 0, 140, 0);
            this.paymentChangeID.Size = new System.Drawing.Size(262, 53);
            this.paymentChangeID.TabIndex = 1;
            this.paymentChangeID.Text = "[0]";
            this.paymentChangeID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCRMidPrinting
            // 
            this.panelCRMidPrinting.Controls.Add(this.tableLayoutPanel27);
            this.panelCRMidPrinting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCRMidPrinting.Location = new System.Drawing.Point(0, 0);
            this.panelCRMidPrinting.Name = "panelCRMidPrinting";
            this.panelCRMidPrinting.Size = new System.Drawing.Size(1456, 729);
            this.panelCRMidPrinting.TabIndex = 2;
            // 
            // tableLayoutPanel27
            // 
            this.tableLayoutPanel27.ColumnCount = 3;
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.54546F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel27.Controls.Add(this.panel15, 1, 0);
            this.tableLayoutPanel27.Controls.Add(this.tableLayoutPanel26, 1, 2);
            this.tableLayoutPanel27.Controls.Add(this.idCapctureAgainBtn, 2, 2);
            this.tableLayoutPanel27.Controls.Add(this.tableLayoutPanel32, 1, 1);
            this.tableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel27.Location = new System.Drawing.Point(0, 206);
            this.tableLayoutPanel27.Name = "tableLayoutPanel27";
            this.tableLayoutPanel27.RowCount = 3;
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.20792F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.990099F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.80198F));
            this.tableLayoutPanel27.Size = new System.Drawing.Size(1456, 523);
            this.tableLayoutPanel27.TabIndex = 7;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.tableLayoutPanel28);
            this.panel15.Controls.Add(this.tableLayoutPanel25);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(333, 3);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(788, 408);
            this.panel15.TabIndex = 6;
            // 
            // tableLayoutPanel28
            // 
            this.tableLayoutPanel28.ColumnCount = 1;
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel28.Controls.Add(this.idCameraFeed, 0, 0);
            this.tableLayoutPanel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel28.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel28.Name = "tableLayoutPanel28";
            this.tableLayoutPanel28.RowCount = 1;
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 308F));
            this.tableLayoutPanel28.Size = new System.Drawing.Size(788, 308);
            this.tableLayoutPanel28.TabIndex = 6;
            // 
            // idCameraFeed
            // 
            this.idCameraFeed.BackColor = System.Drawing.Color.DarkGray;
            this.idCameraFeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idCameraFeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idCameraFeed.Location = new System.Drawing.Point(190, 10);
            this.idCameraFeed.Margin = new System.Windows.Forms.Padding(190, 10, 190, 10);
            this.idCameraFeed.Name = "idCameraFeed";
            this.idCameraFeed.Padding = new System.Windows.Forms.Padding(3);
            this.idCameraFeed.Size = new System.Drawing.Size(408, 288);
            this.idCameraFeed.TabIndex = 2;
            this.idCameraFeed.TabStop = false;
            // 
            // tableLayoutPanel25
            // 
            this.tableLayoutPanel25.ColumnCount = 4;
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel25.Controls.Add(this.idPreviewPictureBox4, 3, 0);
            this.tableLayoutPanel25.Controls.Add(this.idPreviewPictureBox3, 2, 0);
            this.tableLayoutPanel25.Controls.Add(this.idPreviewPictureBox2, 1, 0);
            this.tableLayoutPanel25.Controls.Add(this.idPreviewPictureBox1, 0, 0);
            this.tableLayoutPanel25.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel25.Location = new System.Drawing.Point(0, 308);
            this.tableLayoutPanel25.Name = "tableLayoutPanel25";
            this.tableLayoutPanel25.RowCount = 1;
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel25.Size = new System.Drawing.Size(788, 100);
            this.tableLayoutPanel25.TabIndex = 5;
            // 
            // idPreviewPictureBox4
            // 
            this.idPreviewPictureBox4.BackColor = System.Drawing.Color.DarkGray;
            this.idPreviewPictureBox4.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.idPreviewPictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.idPreviewPictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idPreviewPictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idPreviewPictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPreviewPictureBox4.Location = new System.Drawing.Point(611, 5);
            this.idPreviewPictureBox4.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.idPreviewPictureBox4.Name = "idPreviewPictureBox4";
            this.idPreviewPictureBox4.Padding = new System.Windows.Forms.Padding(3);
            this.idPreviewPictureBox4.Size = new System.Drawing.Size(157, 90);
            this.idPreviewPictureBox4.TabIndex = 3;
            this.idPreviewPictureBox4.TabStop = false;
            // 
            // idPreviewPictureBox3
            // 
            this.idPreviewPictureBox3.BackColor = System.Drawing.Color.DarkGray;
            this.idPreviewPictureBox3.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.idPreviewPictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.idPreviewPictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idPreviewPictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idPreviewPictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPreviewPictureBox3.Location = new System.Drawing.Point(414, 5);
            this.idPreviewPictureBox3.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.idPreviewPictureBox3.Name = "idPreviewPictureBox3";
            this.idPreviewPictureBox3.Padding = new System.Windows.Forms.Padding(3);
            this.idPreviewPictureBox3.Size = new System.Drawing.Size(157, 90);
            this.idPreviewPictureBox3.TabIndex = 2;
            this.idPreviewPictureBox3.TabStop = false;
            // 
            // idPreviewPictureBox2
            // 
            this.idPreviewPictureBox2.BackColor = System.Drawing.Color.DarkGray;
            this.idPreviewPictureBox2.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.idPreviewPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.idPreviewPictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idPreviewPictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idPreviewPictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPreviewPictureBox2.Location = new System.Drawing.Point(217, 5);
            this.idPreviewPictureBox2.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.idPreviewPictureBox2.Name = "idPreviewPictureBox2";
            this.idPreviewPictureBox2.Padding = new System.Windows.Forms.Padding(3);
            this.idPreviewPictureBox2.Size = new System.Drawing.Size(157, 90);
            this.idPreviewPictureBox2.TabIndex = 1;
            this.idPreviewPictureBox2.TabStop = false;
            // 
            // idPreviewPictureBox1
            // 
            this.idPreviewPictureBox1.BackColor = System.Drawing.Color.DarkGray;
            this.idPreviewPictureBox1.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.idPreviewPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.idPreviewPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idPreviewPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idPreviewPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPreviewPictureBox1.Location = new System.Drawing.Point(20, 5);
            this.idPreviewPictureBox1.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.idPreviewPictureBox1.Name = "idPreviewPictureBox1";
            this.idPreviewPictureBox1.Padding = new System.Windows.Forms.Padding(3);
            this.idPreviewPictureBox1.Size = new System.Drawing.Size(157, 90);
            this.idPreviewPictureBox1.TabIndex = 0;
            this.idPreviewPictureBox1.TabStop = false;
            // 
            // tableLayoutPanel26
            // 
            this.tableLayoutPanel26.ColumnCount = 3;
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel26.Controls.Add(this.idPrintingCancelBtn, 0, 0);
            this.tableLayoutPanel26.Controls.Add(this.idCaptureBtn, 1, 0);
            this.tableLayoutPanel26.Controls.Add(this.idPrintingContinueBtn, 2, 0);
            this.tableLayoutPanel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel26.Location = new System.Drawing.Point(333, 422);
            this.tableLayoutPanel26.Name = "tableLayoutPanel26";
            this.tableLayoutPanel26.RowCount = 1;
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel26.Size = new System.Drawing.Size(788, 98);
            this.tableLayoutPanel26.TabIndex = 4;
            // 
            // idPrintingCancelBtn
            // 
            this.idPrintingCancelBtn.BackColor = System.Drawing.Color.DarkGray;
            this.idPrintingCancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idPrintingCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintingCancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.idPrintingCancelBtn.FlatAppearance.BorderSize = 2;
            this.idPrintingCancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.idPrintingCancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.idPrintingCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idPrintingCancelBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPrintingCancelBtn.Image = global::Snap_and_Print.Properties.Resources.printCancel;
            this.idPrintingCancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.idPrintingCancelBtn.Location = new System.Drawing.Point(30, 10);
            this.idPrintingCancelBtn.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.idPrintingCancelBtn.Name = "idPrintingCancelBtn";
            this.idPrintingCancelBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.idPrintingCancelBtn.Size = new System.Drawing.Size(202, 78);
            this.idPrintingCancelBtn.TabIndex = 5;
            this.idPrintingCancelBtn.Text = "CANCEL";
            this.idPrintingCancelBtn.UseVisualStyleBackColor = false;
            this.idPrintingCancelBtn.Click += new System.EventHandler(this.idPrintingCancelBtn_Click);
            // 
            // idCaptureBtn
            // 
            this.idCaptureBtn.BackColor = System.Drawing.Color.DarkGray;
            this.idCaptureBtn.BackgroundImage = global::Snap_and_Print.Properties.Resources.camera_fill;
            this.idCaptureBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.idCaptureBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idCaptureBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idCaptureBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.idCaptureBtn.FlatAppearance.BorderSize = 2;
            this.idCaptureBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.idCaptureBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.idCaptureBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idCaptureBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idCaptureBtn.Location = new System.Drawing.Point(342, 5);
            this.idCaptureBtn.Margin = new System.Windows.Forms.Padding(80, 5, 80, 5);
            this.idCaptureBtn.Name = "idCaptureBtn";
            this.idCaptureBtn.Size = new System.Drawing.Size(102, 88);
            this.idCaptureBtn.TabIndex = 6;
            this.idCaptureBtn.UseVisualStyleBackColor = false;
            this.idCaptureBtn.Click += new System.EventHandler(this.idCaptureBtn_Click);
            // 
            // idPrintingContinueBtn
            // 
            this.idPrintingContinueBtn.BackColor = System.Drawing.Color.DarkGray;
            this.idPrintingContinueBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idPrintingContinueBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintingContinueBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.idPrintingContinueBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.idPrintingContinueBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.idPrintingContinueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idPrintingContinueBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPrintingContinueBtn.Image = global::Snap_and_Print.Properties.Resources.printContinue;
            this.idPrintingContinueBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.idPrintingContinueBtn.Location = new System.Drawing.Point(554, 10);
            this.idPrintingContinueBtn.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.idPrintingContinueBtn.Name = "idPrintingContinueBtn";
            this.idPrintingContinueBtn.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.idPrintingContinueBtn.Size = new System.Drawing.Size(204, 78);
            this.idPrintingContinueBtn.TabIndex = 3;
            this.idPrintingContinueBtn.Text = "CONTINUE";
            this.idPrintingContinueBtn.UseVisualStyleBackColor = false;
            this.idPrintingContinueBtn.Click += new System.EventHandler(this.idPrintingContinueBtn_Click);
            // 
            // idCapctureAgainBtn
            // 
            this.idCapctureAgainBtn.BackColor = System.Drawing.Color.Silver;
            this.idCapctureAgainBtn.BackgroundImage = global::Snap_and_Print.Properties.Resources.reset_left_fill;
            this.idCapctureAgainBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.idCapctureAgainBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idCapctureAgainBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idCapctureAgainBtn.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.idCapctureAgainBtn.FlatAppearance.BorderSize = 2;
            this.idCapctureAgainBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.idCapctureAgainBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.idCapctureAgainBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idCapctureAgainBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idCapctureAgainBtn.ForeColor = System.Drawing.Color.Black;
            this.idCapctureAgainBtn.Location = new System.Drawing.Point(1244, 429);
            this.idCapctureAgainBtn.Margin = new System.Windows.Forms.Padding(120, 10, 120, 10);
            this.idCapctureAgainBtn.Name = "idCapctureAgainBtn";
            this.idCapctureAgainBtn.Size = new System.Drawing.Size(92, 84);
            this.idCapctureAgainBtn.TabIndex = 4;
            this.idCapctureAgainBtn.UseVisualStyleBackColor = false;
            this.idCapctureAgainBtn.Click += new System.EventHandler(this.idCaptureAgainBtn_Click);
            // 
            // tableLayoutPanel32
            // 
            this.tableLayoutPanel32.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel32.ColumnCount = 1;
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel32.Location = new System.Drawing.Point(333, 417);
            this.tableLayoutPanel32.Name = "tableLayoutPanel32";
            this.tableLayoutPanel32.RowCount = 1;
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel32.Size = new System.Drawing.Size(788, 1);
            this.tableLayoutPanel32.TabIndex = 7;
            // 
            // idPrintingSettings
            // 
            this.idPrintingSettings.BackgroundImage = global::Snap_and_Print.Properties.Resources.IDPBSBG;
            this.idPrintingSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.idPrintingSettings.Controls.Add(this.IDsettings);
            this.idPrintingSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintingSettings.Location = new System.Drawing.Point(0, 0);
            this.idPrintingSettings.Name = "idPrintingSettings";
            this.idPrintingSettings.Size = new System.Drawing.Size(1456, 729);
            this.idPrintingSettings.TabIndex = 2;
            // 
            // IDsettings
            // 
            this.IDsettings.Controls.Add(this.panel5);
            this.IDsettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IDsettings.Location = new System.Drawing.Point(0, 0);
            this.IDsettings.Name = "IDsettings";
            this.IDsettings.Size = new System.Drawing.Size(1456, 729);
            this.IDsettings.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tableLayoutPanel8);
            this.panel5.Controls.Add(this.tableLayoutPanel15);
            this.panel5.Controls.Add(this.tableLayoutPanel34);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1456, 729);
            this.panel5.TabIndex = 2;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Controls.Add(this.panel9, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.panel21, 0, 2);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(803, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(653, 629);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Silver;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.tableLayoutPanel36);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(20, 167);
            this.panel9.Margin = new System.Windows.Forms.Padding(20, 10, 25, 10);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(608, 357);
            this.panel9.TabIndex = 2;
            // 
            // tableLayoutPanel36
            // 
            this.tableLayoutPanel36.ColumnCount = 2;
            this.tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel36.Controls.Add(this.tableLayoutPanel37, 1, 0);
            this.tableLayoutPanel36.Controls.Add(this.idSettingsPicturePreview, 0, 0);
            this.tableLayoutPanel36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel36.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel36.Name = "tableLayoutPanel36";
            this.tableLayoutPanel36.RowCount = 1;
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel36.Size = new System.Drawing.Size(606, 355);
            this.tableLayoutPanel36.TabIndex = 0;
            // 
            // tableLayoutPanel37
            // 
            this.tableLayoutPanel37.ColumnCount = 1;
            this.tableLayoutPanel37.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel37.Controls.Add(this.idPrintPreviewMini, 0, 0);
            this.tableLayoutPanel37.Controls.Add(this.pictureBox16, 0, 1);
            this.tableLayoutPanel37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel37.Location = new System.Drawing.Point(427, 3);
            this.tableLayoutPanel37.Name = "tableLayoutPanel37";
            this.tableLayoutPanel37.RowCount = 2;
            this.tableLayoutPanel37.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel37.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel37.Size = new System.Drawing.Size(176, 349);
            this.tableLayoutPanel37.TabIndex = 0;
            // 
            // idPrintPreviewMini
            // 
            this.idPrintPreviewMini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idPrintPreviewMini.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintPreviewMini.Location = new System.Drawing.Point(3, 3);
            this.idPrintPreviewMini.Name = "idPrintPreviewMini";
            this.idPrintPreviewMini.Size = new System.Drawing.Size(170, 133);
            this.idPrintPreviewMini.TabIndex = 0;
            this.idPrintPreviewMini.TabStop = false;
            // 
            // pictureBox16
            // 
            this.pictureBox16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox16.Image = global::Snap_and_Print.Properties.Resources.camera_lens_ai_line;
            this.pictureBox16.Location = new System.Drawing.Point(3, 142);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(170, 204);
            this.pictureBox16.TabIndex = 1;
            this.pictureBox16.TabStop = false;
            // 
            // idSettingsPicturePreview
            // 
            this.idSettingsPicturePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idSettingsPicturePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idSettingsPicturePreview.Location = new System.Drawing.Point(3, 3);
            this.idSettingsPicturePreview.Name = "idSettingsPicturePreview";
            this.idSettingsPicturePreview.Size = new System.Drawing.Size(418, 349);
            this.idSettingsPicturePreview.TabIndex = 0;
            this.idSettingsPicturePreview.TabStop = false;
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.Silver;
            this.panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel21.Controls.Add(this.tableLayoutPanel33);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel21.Location = new System.Drawing.Point(20, 537);
            this.panel21.Margin = new System.Windows.Forms.Padding(20, 3, 25, 10);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(608, 82);
            this.panel21.TabIndex = 3;
            // 
            // tableLayoutPanel33
            // 
            this.tableLayoutPanel33.ColumnCount = 4;
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel33.Controls.Add(this.idSettingsSelectPicture4, 3, 0);
            this.tableLayoutPanel33.Controls.Add(this.idSettingsSelectPicture3, 2, 0);
            this.tableLayoutPanel33.Controls.Add(this.idSettingsSelectPicture2, 1, 0);
            this.tableLayoutPanel33.Controls.Add(this.idSettingsSelectPicture1, 0, 0);
            this.tableLayoutPanel33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel33.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel33.Name = "tableLayoutPanel33";
            this.tableLayoutPanel33.RowCount = 1;
            this.tableLayoutPanel33.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel33.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel33.Size = new System.Drawing.Size(606, 80);
            this.tableLayoutPanel33.TabIndex = 1;
            // 
            // idSettingsSelectPicture4
            // 
            this.idSettingsSelectPicture4.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.idSettingsSelectPicture4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.idSettingsSelectPicture4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idSettingsSelectPicture4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idSettingsSelectPicture4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idSettingsSelectPicture4.Location = new System.Drawing.Point(456, 3);
            this.idSettingsSelectPicture4.Name = "idSettingsSelectPicture4";
            this.idSettingsSelectPicture4.Size = new System.Drawing.Size(147, 74);
            this.idSettingsSelectPicture4.TabIndex = 3;
            this.idSettingsSelectPicture4.TabStop = false;
            this.idSettingsSelectPicture4.Click += new System.EventHandler(this.SelectPhoto_Click);
            // 
            // idSettingsSelectPicture3
            // 
            this.idSettingsSelectPicture3.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.idSettingsSelectPicture3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.idSettingsSelectPicture3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idSettingsSelectPicture3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idSettingsSelectPicture3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idSettingsSelectPicture3.Location = new System.Drawing.Point(305, 3);
            this.idSettingsSelectPicture3.Name = "idSettingsSelectPicture3";
            this.idSettingsSelectPicture3.Size = new System.Drawing.Size(145, 74);
            this.idSettingsSelectPicture3.TabIndex = 2;
            this.idSettingsSelectPicture3.TabStop = false;
            this.idSettingsSelectPicture3.Click += new System.EventHandler(this.SelectPhoto_Click);
            // 
            // idSettingsSelectPicture2
            // 
            this.idSettingsSelectPicture2.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.idSettingsSelectPicture2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.idSettingsSelectPicture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idSettingsSelectPicture2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idSettingsSelectPicture2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idSettingsSelectPicture2.Location = new System.Drawing.Point(154, 3);
            this.idSettingsSelectPicture2.Name = "idSettingsSelectPicture2";
            this.idSettingsSelectPicture2.Size = new System.Drawing.Size(145, 74);
            this.idSettingsSelectPicture2.TabIndex = 1;
            this.idSettingsSelectPicture2.TabStop = false;
            this.idSettingsSelectPicture2.Click += new System.EventHandler(this.SelectPhoto_Click);
            // 
            // idSettingsSelectPicture1
            // 
            this.idSettingsSelectPicture1.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.idSettingsSelectPicture1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.idSettingsSelectPicture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idSettingsSelectPicture1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idSettingsSelectPicture1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idSettingsSelectPicture1.Location = new System.Drawing.Point(3, 3);
            this.idSettingsSelectPicture1.Name = "idSettingsSelectPicture1";
            this.idSettingsSelectPicture1.Size = new System.Drawing.Size(145, 74);
            this.idSettingsSelectPicture1.TabIndex = 0;
            this.idSettingsSelectPicture1.TabStop = false;
            this.idSettingsSelectPicture1.Click += new System.EventHandler(this.SelectPhoto_Click);
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 1;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.Controls.Add(this.panel6, 0, 1);
            this.tableLayoutPanel15.Controls.Add(this.panel7, 0, 2);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 3;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(652, 629);
            this.tableLayoutPanel15.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Silver;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.tableLayoutPanel35);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(20, 167);
            this.panel6.Margin = new System.Windows.Forms.Padding(20, 10, 25, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(607, 388);
            this.panel6.TabIndex = 0;
            // 
            // tableLayoutPanel35
            // 
            this.tableLayoutPanel35.ColumnCount = 1;
            this.tableLayoutPanel35.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel35.Controls.Add(this.tableLayoutPanel38, 0, 2);
            this.tableLayoutPanel35.Controls.Add(this.tableLayoutPanel41, 0, 5);
            this.tableLayoutPanel35.Controls.Add(this.tableLayoutPanel46, 0, 8);
            this.tableLayoutPanel35.Controls.Add(this.tableLayoutPanel70, 0, 0);
            this.tableLayoutPanel35.Controls.Add(this.tableLayoutPanel133, 0, 1);
            this.tableLayoutPanel35.Controls.Add(this.tableLayoutPanel134, 0, 3);
            this.tableLayoutPanel35.Controls.Add(this.tableLayoutPanel135, 0, 4);
            this.tableLayoutPanel35.Controls.Add(this.tableLayoutPanel136, 0, 6);
            this.tableLayoutPanel35.Controls.Add(this.tableLayoutPanel137, 0, 7);
            this.tableLayoutPanel35.Controls.Add(this.tableLayoutPanel139, 0, 9);
            this.tableLayoutPanel35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel35.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel35.Name = "tableLayoutPanel35";
            this.tableLayoutPanel35.RowCount = 10;
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86139F));
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86139F));
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.990099F));
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86139F));
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86139F));
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.990099F));
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86139F));
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86139F));
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.990099F));
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.86139F));
            this.tableLayoutPanel35.Size = new System.Drawing.Size(605, 386);
            this.tableLayoutPanel35.TabIndex = 0;
            // 
            // tableLayoutPanel38
            // 
            this.tableLayoutPanel38.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel38.ColumnCount = 1;
            this.tableLayoutPanel38.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel38.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel38.Location = new System.Drawing.Point(50, 109);
            this.tableLayoutPanel38.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.tableLayoutPanel38.Name = "tableLayoutPanel38";
            this.tableLayoutPanel38.RowCount = 1;
            this.tableLayoutPanel38.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel38.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel38.Size = new System.Drawing.Size(505, 1);
            this.tableLayoutPanel38.TabIndex = 0;
            // 
            // tableLayoutPanel41
            // 
            this.tableLayoutPanel41.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel41.ColumnCount = 1;
            this.tableLayoutPanel41.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel41.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel41.Location = new System.Drawing.Point(50, 218);
            this.tableLayoutPanel41.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.tableLayoutPanel41.Name = "tableLayoutPanel41";
            this.tableLayoutPanel41.RowCount = 1;
            this.tableLayoutPanel41.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel41.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel41.Size = new System.Drawing.Size(505, 1);
            this.tableLayoutPanel41.TabIndex = 1;
            // 
            // tableLayoutPanel46
            // 
            this.tableLayoutPanel46.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel46.ColumnCount = 1;
            this.tableLayoutPanel46.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel46.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel46.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel46.Location = new System.Drawing.Point(50, 327);
            this.tableLayoutPanel46.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.tableLayoutPanel46.Name = "tableLayoutPanel46";
            this.tableLayoutPanel46.RowCount = 1;
            this.tableLayoutPanel46.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel46.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel46.Size = new System.Drawing.Size(505, 1);
            this.tableLayoutPanel46.TabIndex = 2;
            // 
            // tableLayoutPanel70
            // 
            this.tableLayoutPanel70.ColumnCount = 2;
            this.tableLayoutPanel70.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel70.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel70.Controls.Add(this.label20, 0, 0);
            this.tableLayoutPanel70.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel70.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel70.Name = "tableLayoutPanel70";
            this.tableLayoutPanel70.RowCount = 1;
            this.tableLayoutPanel70.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel70.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel70.Size = new System.Drawing.Size(599, 47);
            this.tableLayoutPanel70.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Image = global::Snap_and_Print.Properties.Resources.aspect_ratio_line;
            this.label20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label20.Location = new System.Drawing.Point(20, 3);
            this.label20.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.label20.Size = new System.Drawing.Size(276, 41);
            this.label20.TabIndex = 1;
            this.label20.Text = "Photo Size";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel133
            // 
            this.tableLayoutPanel133.ColumnCount = 4;
            this.tableLayoutPanel133.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel133.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel133.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel133.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel133.Controls.Add(this.radioBtn2x1, 3, 0);
            this.tableLayoutPanel133.Controls.Add(this.radioBtn1x1, 2, 0);
            this.tableLayoutPanel133.Controls.Add(this.radioBtn2x2, 1, 0);
            this.tableLayoutPanel133.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel133.Location = new System.Drawing.Point(3, 56);
            this.tableLayoutPanel133.Name = "tableLayoutPanel133";
            this.tableLayoutPanel133.RowCount = 1;
            this.tableLayoutPanel133.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel133.Size = new System.Drawing.Size(599, 47);
            this.tableLayoutPanel133.TabIndex = 5;
            // 
            // radioBtn2x1
            // 
            this.radioBtn2x1.AutoSize = true;
            this.radioBtn2x1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioBtn2x1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtn2x1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtn2x1.Location = new System.Drawing.Point(450, 3);
            this.radioBtn2x1.Name = "radioBtn2x1";
            this.radioBtn2x1.Size = new System.Drawing.Size(146, 41);
            this.radioBtn2x1.TabIndex = 0;
            this.radioBtn2x1.TabStop = true;
            this.radioBtn2x1.Text = "2x1";
            this.radioBtn2x1.UseVisualStyleBackColor = true;
            this.radioBtn2x1.Click += new System.EventHandler(this.radioBtn2x1_click);
            // 
            // radioBtn1x1
            // 
            this.radioBtn1x1.AutoSize = true;
            this.radioBtn1x1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioBtn1x1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtn1x1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtn1x1.Location = new System.Drawing.Point(301, 3);
            this.radioBtn1x1.Name = "radioBtn1x1";
            this.radioBtn1x1.Size = new System.Drawing.Size(143, 41);
            this.radioBtn1x1.TabIndex = 0;
            this.radioBtn1x1.TabStop = true;
            this.radioBtn1x1.Text = "1x1";
            this.radioBtn1x1.UseVisualStyleBackColor = true;
            this.radioBtn1x1.Click += new System.EventHandler(this.radioBtn1x1_click);
            // 
            // radioBtn2x2
            // 
            this.radioBtn2x2.AutoSize = true;
            this.radioBtn2x2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioBtn2x2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtn2x2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtn2x2.Location = new System.Drawing.Point(152, 3);
            this.radioBtn2x2.Name = "radioBtn2x2";
            this.radioBtn2x2.Size = new System.Drawing.Size(143, 41);
            this.radioBtn2x2.TabIndex = 0;
            this.radioBtn2x2.TabStop = true;
            this.radioBtn2x2.Text = "2x2";
            this.radioBtn2x2.UseVisualStyleBackColor = true;
            this.radioBtn2x2.CheckedChanged += new System.EventHandler(this.radioBtn2x2_click);
            // 
            // tableLayoutPanel134
            // 
            this.tableLayoutPanel134.ColumnCount = 2;
            this.tableLayoutPanel134.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel134.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel134.Controls.Add(this.label21, 0, 0);
            this.tableLayoutPanel134.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel134.Location = new System.Drawing.Point(3, 112);
            this.tableLayoutPanel134.Name = "tableLayoutPanel134";
            this.tableLayoutPanel134.RowCount = 1;
            this.tableLayoutPanel134.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel134.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel134.Size = new System.Drawing.Size(599, 47);
            this.tableLayoutPanel134.TabIndex = 6;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Image = global::Snap_and_Print.Properties.Resources.layout_4_line;
            this.label21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label21.Location = new System.Drawing.Point(20, 3);
            this.label21.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.label21.Name = "label21";
            this.label21.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label21.Size = new System.Drawing.Size(276, 41);
            this.label21.TabIndex = 2;
            this.label21.Text = "Photo Layout";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel135
            // 
            this.tableLayoutPanel135.ColumnCount = 3;
            this.tableLayoutPanel135.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel135.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel135.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel135.Controls.Add(this.radioBtnMultipleCopies, 2, 0);
            this.tableLayoutPanel135.Controls.Add(this.radioBtnSinglePhotoCopies, 1, 0);
            this.tableLayoutPanel135.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel135.Location = new System.Drawing.Point(3, 165);
            this.tableLayoutPanel135.Name = "tableLayoutPanel135";
            this.tableLayoutPanel135.RowCount = 1;
            this.tableLayoutPanel135.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel135.Size = new System.Drawing.Size(599, 47);
            this.tableLayoutPanel135.TabIndex = 7;
            // 
            // radioBtnMultipleCopies
            // 
            this.radioBtnMultipleCopies.AutoSize = true;
            this.radioBtnMultipleCopies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioBtnMultipleCopies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnMultipleCopies.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnMultipleCopies.Location = new System.Drawing.Point(361, 3);
            this.radioBtnMultipleCopies.Name = "radioBtnMultipleCopies";
            this.radioBtnMultipleCopies.Size = new System.Drawing.Size(235, 41);
            this.radioBtnMultipleCopies.TabIndex = 0;
            this.radioBtnMultipleCopies.TabStop = true;
            this.radioBtnMultipleCopies.Text = "Multiple";
            this.radioBtnMultipleCopies.UseVisualStyleBackColor = true;
            this.radioBtnMultipleCopies.Click += new System.EventHandler(this.radioBtnMultipleCopies_click);
            // 
            // radioBtnSinglePhotoCopies
            // 
            this.radioBtnSinglePhotoCopies.AutoSize = true;
            this.radioBtnSinglePhotoCopies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioBtnSinglePhotoCopies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnSinglePhotoCopies.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnSinglePhotoCopies.Location = new System.Drawing.Point(122, 3);
            this.radioBtnSinglePhotoCopies.Name = "radioBtnSinglePhotoCopies";
            this.radioBtnSinglePhotoCopies.Size = new System.Drawing.Size(233, 41);
            this.radioBtnSinglePhotoCopies.TabIndex = 0;
            this.radioBtnSinglePhotoCopies.TabStop = true;
            this.radioBtnSinglePhotoCopies.Text = "Single";
            this.radioBtnSinglePhotoCopies.UseVisualStyleBackColor = true;
            this.radioBtnSinglePhotoCopies.Click += new System.EventHandler(this.radioBtnSinglePhotoCopies_click);
            // 
            // tableLayoutPanel136
            // 
            this.tableLayoutPanel136.ColumnCount = 2;
            this.tableLayoutPanel136.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel136.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel136.Controls.Add(this.label22, 0, 0);
            this.tableLayoutPanel136.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel136.Location = new System.Drawing.Point(3, 221);
            this.tableLayoutPanel136.Name = "tableLayoutPanel136";
            this.tableLayoutPanel136.RowCount = 1;
            this.tableLayoutPanel136.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel136.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel136.Size = new System.Drawing.Size(599, 47);
            this.tableLayoutPanel136.TabIndex = 8;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Cursor = System.Windows.Forms.Cursors.Default;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Image = global::Snap_and_Print.Properties.Resources.printer_line__1_;
            this.label22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label22.Location = new System.Drawing.Point(20, 3);
            this.label22.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.label22.Name = "label22";
            this.label22.Padding = new System.Windows.Forms.Padding(20, 0, 30, 0);
            this.label22.Size = new System.Drawing.Size(276, 41);
            this.label22.TabIndex = 3;
            this.label22.Text = "Print Type";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel137
            // 
            this.tableLayoutPanel137.ColumnCount = 3;
            this.tableLayoutPanel137.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel137.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel137.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel137.Controls.Add(this.radioBtnPhotoColored, 2, 0);
            this.tableLayoutPanel137.Controls.Add(this.radioBtnPhotoBlack, 1, 0);
            this.tableLayoutPanel137.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel137.Location = new System.Drawing.Point(3, 274);
            this.tableLayoutPanel137.Name = "tableLayoutPanel137";
            this.tableLayoutPanel137.RowCount = 1;
            this.tableLayoutPanel137.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel137.Size = new System.Drawing.Size(599, 47);
            this.tableLayoutPanel137.TabIndex = 9;
            // 
            // radioBtnPhotoColored
            // 
            this.radioBtnPhotoColored.AutoSize = true;
            this.radioBtnPhotoColored.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioBtnPhotoColored.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnPhotoColored.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnPhotoColored.Location = new System.Drawing.Point(361, 3);
            this.radioBtnPhotoColored.Name = "radioBtnPhotoColored";
            this.radioBtnPhotoColored.Size = new System.Drawing.Size(235, 41);
            this.radioBtnPhotoColored.TabIndex = 0;
            this.radioBtnPhotoColored.TabStop = true;
            this.radioBtnPhotoColored.Text = "Colored";
            this.radioBtnPhotoColored.UseVisualStyleBackColor = true;
            this.radioBtnPhotoColored.Click += new System.EventHandler(this.radioBtnPhotoColored_click);
            // 
            // radioBtnPhotoBlack
            // 
            this.radioBtnPhotoBlack.AutoSize = true;
            this.radioBtnPhotoBlack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioBtnPhotoBlack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBtnPhotoBlack.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtnPhotoBlack.Location = new System.Drawing.Point(122, 3);
            this.radioBtnPhotoBlack.Name = "radioBtnPhotoBlack";
            this.radioBtnPhotoBlack.Size = new System.Drawing.Size(233, 41);
            this.radioBtnPhotoBlack.TabIndex = 0;
            this.radioBtnPhotoBlack.TabStop = true;
            this.radioBtnPhotoBlack.Text = "Black and White";
            this.radioBtnPhotoBlack.UseVisualStyleBackColor = true;
            this.radioBtnPhotoBlack.Click += new System.EventHandler(this.radioBtnPhotoBlack_click);
            // 
            // tableLayoutPanel139
            // 
            this.tableLayoutPanel139.ColumnCount = 2;
            this.tableLayoutPanel139.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel139.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel139.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel139.Controls.Add(this.numericIdPrintingCopies, 1, 0);
            this.tableLayoutPanel139.Controls.Add(this.idPrintingCopies, 0, 0);
            this.tableLayoutPanel139.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel139.Location = new System.Drawing.Point(3, 330);
            this.tableLayoutPanel139.Name = "tableLayoutPanel139";
            this.tableLayoutPanel139.RowCount = 1;
            this.tableLayoutPanel139.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel139.Size = new System.Drawing.Size(599, 53);
            this.tableLayoutPanel139.TabIndex = 11;
            // 
            // numericIdPrintingCopies
            // 
            this.numericIdPrintingCopies.BackColor = System.Drawing.Color.DarkGray;
            this.numericIdPrintingCopies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericIdPrintingCopies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericIdPrintingCopies.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericIdPrintingCopies.Location = new System.Drawing.Point(302, 3);
            this.numericIdPrintingCopies.Margin = new System.Windows.Forms.Padding(3, 3, 120, 3);
            this.numericIdPrintingCopies.Name = "numericIdPrintingCopies";
            this.numericIdPrintingCopies.Size = new System.Drawing.Size(177, 50);
            this.numericIdPrintingCopies.TabIndex = 0;
            this.numericIdPrintingCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // idPrintingCopies
            // 
            this.idPrintingCopies.AutoSize = true;
            this.idPrintingCopies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintingCopies.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPrintingCopies.Image = global::Snap_and_Print.Properties.Resources.file_copy_2_line__1_;
            this.idPrintingCopies.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.idPrintingCopies.Location = new System.Drawing.Point(120, 3);
            this.idPrintingCopies.Margin = new System.Windows.Forms.Padding(120, 3, 3, 3);
            this.idPrintingCopies.Name = "idPrintingCopies";
            this.idPrintingCopies.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.idPrintingCopies.Size = new System.Drawing.Size(176, 47);
            this.idPrintingCopies.TabIndex = 0;
            this.idPrintingCopies.Text = "Copies";
            this.idPrintingCopies.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Silver;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.tableLayoutPanel13);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(20, 570);
            this.panel7.Margin = new System.Windows.Forms.Padding(20, 5, 25, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(607, 54);
            this.panel7.TabIndex = 1;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel13.ColumnCount = 2;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.Controls.Add(this.idPrintingTotal, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.label23, 0, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(605, 52);
            this.tableLayoutPanel13.TabIndex = 1;
            // 
            // idPrintingTotal
            // 
            this.idPrintingTotal.AutoSize = true;
            this.idPrintingTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintingTotal.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPrintingTotal.Image = global::Snap_and_Print.Properties.Resources.peso__1_;
            this.idPrintingTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.idPrintingTotal.Location = new System.Drawing.Point(305, 3);
            this.idPrintingTotal.Margin = new System.Windows.Forms.Padding(3);
            this.idPrintingTotal.Name = "idPrintingTotal";
            this.idPrintingTotal.Padding = new System.Windows.Forms.Padding(0, 0, 120, 0);
            this.idPrintingTotal.Size = new System.Drawing.Size(297, 46);
            this.idPrintingTotal.TabIndex = 0;
            this.idPrintingTotal.Text = "[0]";
            this.idPrintingTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Image = global::Snap_and_Print.Properties.Resources.cash_line__1_;
            this.label23.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label23.Location = new System.Drawing.Point(3, 3);
            this.label23.Margin = new System.Windows.Forms.Padding(3);
            this.label23.Name = "label23";
            this.label23.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.label23.Size = new System.Drawing.Size(296, 46);
            this.label23.TabIndex = 4;
            this.label23.Text = "TOTAL :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel34
            // 
            this.tableLayoutPanel34.ColumnCount = 3;
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel34.Controls.Add(this.tableLayoutPanel40, 0, 1);
            this.tableLayoutPanel34.Controls.Add(this.idPrintSettingsConintueBtn, 2, 1);
            this.tableLayoutPanel34.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel34.Location = new System.Drawing.Point(0, 629);
            this.tableLayoutPanel34.Name = "tableLayoutPanel34";
            this.tableLayoutPanel34.RowCount = 3;
            this.tableLayoutPanel34.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel34.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel34.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel34.Size = new System.Drawing.Size(1456, 100);
            this.tableLayoutPanel34.TabIndex = 1;
            // 
            // tableLayoutPanel40
            // 
            this.tableLayoutPanel40.ColumnCount = 2;
            this.tableLayoutPanel40.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel40.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel40.Controls.Add(this.idPrintSettingsCancelBtn, 0, 0);
            this.tableLayoutPanel40.Controls.Add(this.idPrintSettingsBackBtn, 1, 0);
            this.tableLayoutPanel40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel40.Location = new System.Drawing.Point(3, 8);
            this.tableLayoutPanel40.Name = "tableLayoutPanel40";
            this.tableLayoutPanel40.RowCount = 1;
            this.tableLayoutPanel40.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel40.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel40.Size = new System.Drawing.Size(479, 84);
            this.tableLayoutPanel40.TabIndex = 3;
            // 
            // idPrintSettingsCancelBtn
            // 
            this.idPrintSettingsCancelBtn.BackColor = System.Drawing.Color.DarkGray;
            this.idPrintSettingsCancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idPrintSettingsCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintSettingsCancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.idPrintSettingsCancelBtn.FlatAppearance.BorderSize = 2;
            this.idPrintSettingsCancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.idPrintSettingsCancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.idPrintSettingsCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idPrintSettingsCancelBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPrintSettingsCancelBtn.Image = global::Snap_and_Print.Properties.Resources.printCancel;
            this.idPrintSettingsCancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.idPrintSettingsCancelBtn.Location = new System.Drawing.Point(30, 10);
            this.idPrintSettingsCancelBtn.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.idPrintSettingsCancelBtn.Name = "idPrintSettingsCancelBtn";
            this.idPrintSettingsCancelBtn.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.idPrintSettingsCancelBtn.Size = new System.Drawing.Size(179, 64);
            this.idPrintSettingsCancelBtn.TabIndex = 0;
            this.idPrintSettingsCancelBtn.Text = "CANCEL";
            this.idPrintSettingsCancelBtn.UseVisualStyleBackColor = false;
            this.idPrintSettingsCancelBtn.Click += new System.EventHandler(this.idPrintSettingsCancelBtn_Click);
            // 
            // idPrintSettingsBackBtn
            // 
            this.idPrintSettingsBackBtn.BackColor = System.Drawing.Color.DarkGray;
            this.idPrintSettingsBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idPrintSettingsBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintSettingsBackBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.idPrintSettingsBackBtn.FlatAppearance.BorderSize = 2;
            this.idPrintSettingsBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.idPrintSettingsBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.idPrintSettingsBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idPrintSettingsBackBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPrintSettingsBackBtn.Image = global::Snap_and_Print.Properties.Resources.printBack;
            this.idPrintSettingsBackBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.idPrintSettingsBackBtn.Location = new System.Drawing.Point(269, 10);
            this.idPrintSettingsBackBtn.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.idPrintSettingsBackBtn.Name = "idPrintSettingsBackBtn";
            this.idPrintSettingsBackBtn.Padding = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.idPrintSettingsBackBtn.Size = new System.Drawing.Size(180, 64);
            this.idPrintSettingsBackBtn.TabIndex = 1;
            this.idPrintSettingsBackBtn.Text = "BACK";
            this.idPrintSettingsBackBtn.UseVisualStyleBackColor = false;
            this.idPrintSettingsBackBtn.Click += new System.EventHandler(this.idPrintSettingsBackBtn_Click);
            // 
            // idPrintSettingsConintueBtn
            // 
            this.idPrintSettingsConintueBtn.BackColor = System.Drawing.Color.DarkGray;
            this.idPrintSettingsConintueBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.idPrintSettingsConintueBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idPrintSettingsConintueBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.idPrintSettingsConintueBtn.FlatAppearance.BorderSize = 2;
            this.idPrintSettingsConintueBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.idPrintSettingsConintueBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.idPrintSettingsConintueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.idPrintSettingsConintueBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idPrintSettingsConintueBtn.Image = global::Snap_and_Print.Properties.Resources.printContinue;
            this.idPrintSettingsConintueBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.idPrintSettingsConintueBtn.Location = new System.Drawing.Point(1120, 15);
            this.idPrintSettingsConintueBtn.Margin = new System.Windows.Forms.Padding(150, 10, 150, 10);
            this.idPrintSettingsConintueBtn.Name = "idPrintSettingsConintueBtn";
            this.idPrintSettingsConintueBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.idPrintSettingsConintueBtn.Size = new System.Drawing.Size(186, 70);
            this.idPrintSettingsConintueBtn.TabIndex = 2;
            this.idPrintSettingsConintueBtn.Text = "CONTINUE";
            this.idPrintSettingsConintueBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.idPrintSettingsConintueBtn.UseVisualStyleBackColor = false;
            this.idPrintSettingsConintueBtn.Click += new System.EventHandler(this.idPrintSettingsContinueBtn_Click);
            // 
            // softCopyDownloadId
            // 
            this.softCopyDownloadId.Controls.Add(this.panel10);
            this.softCopyDownloadId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.softCopyDownloadId.Location = new System.Drawing.Point(0, 0);
            this.softCopyDownloadId.Name = "softCopyDownloadId";
            this.softCopyDownloadId.Size = new System.Drawing.Size(1456, 729);
            this.softCopyDownloadId.TabIndex = 4;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.tableLayoutPanel39);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1456, 729);
            this.panel10.TabIndex = 5;
            // 
            // tableLayoutPanel39
            // 
            this.tableLayoutPanel39.ColumnCount = 3;
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel39.Controls.Add(this.tableLayoutPanel14, 1, 3);
            this.tableLayoutPanel39.Controls.Add(this.qrIdPrintingDownload, 1, 2);
            this.tableLayoutPanel39.Controls.Add(this.label28, 1, 1);
            this.tableLayoutPanel39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel39.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel39.Name = "tableLayoutPanel39";
            this.tableLayoutPanel39.RowCount = 4;
            this.tableLayoutPanel39.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel39.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel39.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel39.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel39.Size = new System.Drawing.Size(1456, 729);
            this.tableLayoutPanel39.TabIndex = 3;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.Controls.Add(this.downloadBackBtn, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.downloadCancelBtn, 1, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(367, 658);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(722, 68);
            this.tableLayoutPanel14.TabIndex = 2;
            // 
            // downloadBackBtn
            // 
            this.downloadBackBtn.BackColor = System.Drawing.Color.DarkGray;
            this.downloadBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadBackBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.downloadBackBtn.FlatAppearance.BorderSize = 2;
            this.downloadBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.downloadBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.downloadBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadBackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadBackBtn.Location = new System.Drawing.Point(120, 10);
            this.downloadBackBtn.Margin = new System.Windows.Forms.Padding(120, 10, 10, 10);
            this.downloadBackBtn.Name = "downloadBackBtn";
            this.downloadBackBtn.Size = new System.Drawing.Size(231, 48);
            this.downloadBackBtn.TabIndex = 0;
            this.downloadBackBtn.Text = "BACK";
            this.downloadBackBtn.UseVisualStyleBackColor = false;
            this.downloadBackBtn.Click += new System.EventHandler(this.downloadBackBtn_Click);
            // 
            // downloadCancelBtn
            // 
            this.downloadCancelBtn.BackColor = System.Drawing.Color.DarkGray;
            this.downloadCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadCancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.downloadCancelBtn.FlatAppearance.BorderSize = 2;
            this.downloadCancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.downloadCancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.downloadCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadCancelBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadCancelBtn.Image = global::Snap_and_Print.Properties.Resources.printCancel;
            this.downloadCancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.downloadCancelBtn.Location = new System.Drawing.Point(371, 10);
            this.downloadCancelBtn.Margin = new System.Windows.Forms.Padding(10, 10, 120, 10);
            this.downloadCancelBtn.Name = "downloadCancelBtn";
            this.downloadCancelBtn.Padding = new System.Windows.Forms.Padding(40, 0, 20, 0);
            this.downloadCancelBtn.Size = new System.Drawing.Size(231, 48);
            this.downloadCancelBtn.TabIndex = 1;
            this.downloadCancelBtn.Text = "CANCEL";
            this.downloadCancelBtn.UseVisualStyleBackColor = false;
            this.downloadCancelBtn.Click += new System.EventHandler(this.downloadCancelBtn_Click);
            // 
            // qrIdPrintingDownload
            // 
            this.qrIdPrintingDownload.BackColor = System.Drawing.Color.Silver;
            this.qrIdPrintingDownload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qrIdPrintingDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrIdPrintingDownload.Location = new System.Drawing.Point(444, 337);
            this.qrIdPrintingDownload.Margin = new System.Windows.Forms.Padding(80, 10, 80, 10);
            this.qrIdPrintingDownload.Name = "qrIdPrintingDownload";
            this.qrIdPrintingDownload.Size = new System.Drawing.Size(568, 308);
            this.qrIdPrintingDownload.TabIndex = 0;
            this.qrIdPrintingDownload.TabStop = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(367, 255);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(722, 72);
            this.label28.TabIndex = 3;
            this.label28.Text = "Softcopy Download";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // photoBoothPanel
            // 
            this.photoBoothPanel.BackgroundImage = global::Snap_and_Print.Properties.Resources.PhotoBooth;
            this.photoBoothPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.photoBoothPanel.Controls.Add(this.funPaymentPanel);
            this.photoBoothPanel.Controls.Add(this.panelCMRphotoBooth);
            this.photoBoothPanel.Controls.Add(this.photoBoothSettings);
            this.photoBoothPanel.Controls.Add(this.funSoftCopyDownloadPanel);
            this.photoBoothPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothPanel.Location = new System.Drawing.Point(0, 0);
            this.photoBoothPanel.Name = "photoBoothPanel";
            this.photoBoothPanel.Size = new System.Drawing.Size(1456, 729);
            this.photoBoothPanel.TabIndex = 0;
            // 
            // funPaymentPanel
            // 
            this.funPaymentPanel.Controls.Add(this.tableLayoutPanel111);
            this.funPaymentPanel.Controls.Add(this.tableLayoutPanel72);
            this.funPaymentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funPaymentPanel.Location = new System.Drawing.Point(0, 0);
            this.funPaymentPanel.Name = "funPaymentPanel";
            this.funPaymentPanel.Size = new System.Drawing.Size(1456, 729);
            this.funPaymentPanel.TabIndex = 1;
            // 
            // tableLayoutPanel111
            // 
            this.tableLayoutPanel111.ColumnCount = 1;
            this.tableLayoutPanel111.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel111.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel111.Controls.Add(this.button6, 0, 2);
            this.tableLayoutPanel111.Controls.Add(this.button5, 0, 1);
            this.tableLayoutPanel111.Controls.Add(this.button4, 0, 0);
            this.tableLayoutPanel111.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel111.Location = new System.Drawing.Point(1256, 0);
            this.tableLayoutPanel111.Name = "tableLayoutPanel111";
            this.tableLayoutPanel111.RowCount = 3;
            this.tableLayoutPanel111.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel111.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel111.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel111.Size = new System.Drawing.Size(200, 235);
            this.tableLayoutPanel111.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Location = new System.Drawing.Point(3, 159);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(194, 73);
            this.button6.TabIndex = 6;
            this.button6.Text = "20";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(3, 81);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(194, 72);
            this.button5.TabIndex = 5;
            this.button5.Text = "10";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(3, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(194, 72);
            this.button4.TabIndex = 4;
            this.button4.Text = "5";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel72
            // 
            this.tableLayoutPanel72.ColumnCount = 3;
            this.tableLayoutPanel72.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel72.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel72.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel72.Controls.Add(this.tableLayoutPanel114, 1, 0);
            this.tableLayoutPanel72.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel72.Location = new System.Drawing.Point(0, 235);
            this.tableLayoutPanel72.Name = "tableLayoutPanel72";
            this.tableLayoutPanel72.RowCount = 1;
            this.tableLayoutPanel72.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel72.Size = new System.Drawing.Size(1456, 494);
            this.tableLayoutPanel72.TabIndex = 0;
            // 
            // tableLayoutPanel114
            // 
            this.tableLayoutPanel114.ColumnCount = 1;
            this.tableLayoutPanel114.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel114.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel114.Controls.Add(this.tableLayoutPanel71, 0, 1);
            this.tableLayoutPanel114.Controls.Add(this.panel19, 0, 0);
            this.tableLayoutPanel114.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel114.Location = new System.Drawing.Point(294, 3);
            this.tableLayoutPanel114.Name = "tableLayoutPanel114";
            this.tableLayoutPanel114.RowCount = 2;
            this.tableLayoutPanel114.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel114.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel114.Size = new System.Drawing.Size(867, 488);
            this.tableLayoutPanel114.TabIndex = 0;
            // 
            // tableLayoutPanel71
            // 
            this.tableLayoutPanel71.ColumnCount = 4;
            this.tableLayoutPanel71.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel71.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel71.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel71.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel71.Controls.Add(this.funDownloadBtn, 3, 0);
            this.tableLayoutPanel71.Controls.Add(this.paymentFunBackBtn, 1, 0);
            this.tableLayoutPanel71.Controls.Add(this.paymentFunPrintBtn, 2, 0);
            this.tableLayoutPanel71.Controls.Add(this.paymentFunCancelBtn, 0, 0);
            this.tableLayoutPanel71.Location = new System.Drawing.Point(3, 393);
            this.tableLayoutPanel71.Name = "tableLayoutPanel71";
            this.tableLayoutPanel71.RowCount = 1;
            this.tableLayoutPanel71.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel71.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel71.Size = new System.Drawing.Size(861, 91);
            this.tableLayoutPanel71.TabIndex = 10;
            // 
            // funDownloadBtn
            // 
            this.funDownloadBtn.BackColor = System.Drawing.Color.DarkGray;
            this.funDownloadBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funDownloadBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funDownloadBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.funDownloadBtn.FlatAppearance.BorderSize = 2;
            this.funDownloadBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.funDownloadBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.funDownloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.funDownloadBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funDownloadBtn.Image = global::Snap_and_Print.Properties.Resources.mail_download_fill;
            this.funDownloadBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.funDownloadBtn.Location = new System.Drawing.Point(665, 10);
            this.funDownloadBtn.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.funDownloadBtn.Name = "funDownloadBtn";
            this.funDownloadBtn.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.funDownloadBtn.Size = new System.Drawing.Size(176, 71);
            this.funDownloadBtn.TabIndex = 3;
            this.funDownloadBtn.Text = "DOWNLOAD";
            this.funDownloadBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.funDownloadBtn.UseVisualStyleBackColor = false;
            this.funDownloadBtn.Click += new System.EventHandler(this.funDownloadBtn_Click);
            // 
            // paymentFunBackBtn
            // 
            this.paymentFunBackBtn.BackColor = System.Drawing.Color.DarkGray;
            this.paymentFunBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.paymentFunBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentFunBackBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.paymentFunBackBtn.FlatAppearance.BorderSize = 2;
            this.paymentFunBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.paymentFunBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.paymentFunBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paymentFunBackBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentFunBackBtn.Image = global::Snap_and_Print.Properties.Resources.printBack;
            this.paymentFunBackBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentFunBackBtn.Location = new System.Drawing.Point(235, 10);
            this.paymentFunBackBtn.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.paymentFunBackBtn.Name = "paymentFunBackBtn";
            this.paymentFunBackBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.paymentFunBackBtn.Size = new System.Drawing.Size(175, 71);
            this.paymentFunBackBtn.TabIndex = 1;
            this.paymentFunBackBtn.Text = "BACK";
            this.paymentFunBackBtn.UseVisualStyleBackColor = false;
            this.paymentFunBackBtn.Click += new System.EventHandler(this.paymentFunBackBtn_Click);
            // 
            // paymentFunPrintBtn
            // 
            this.paymentFunPrintBtn.BackColor = System.Drawing.Color.DarkGray;
            this.paymentFunPrintBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.paymentFunPrintBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentFunPrintBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.paymentFunPrintBtn.FlatAppearance.BorderSize = 2;
            this.paymentFunPrintBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.paymentFunPrintBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.paymentFunPrintBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paymentFunPrintBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentFunPrintBtn.Image = global::Snap_and_Print.Properties.Resources.printer_fill;
            this.paymentFunPrintBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentFunPrintBtn.Location = new System.Drawing.Point(450, 10);
            this.paymentFunPrintBtn.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.paymentFunPrintBtn.Name = "paymentFunPrintBtn";
            this.paymentFunPrintBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.paymentFunPrintBtn.Size = new System.Drawing.Size(175, 71);
            this.paymentFunPrintBtn.TabIndex = 2;
            this.paymentFunPrintBtn.Text = "PRINT";
            this.paymentFunPrintBtn.UseVisualStyleBackColor = false;
            this.paymentFunPrintBtn.Click += new System.EventHandler(this.paymentFunPrintBtn_Click);
            // 
            // paymentFunCancelBtn
            // 
            this.paymentFunCancelBtn.BackColor = System.Drawing.Color.DarkGray;
            this.paymentFunCancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.paymentFunCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentFunCancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.paymentFunCancelBtn.FlatAppearance.BorderSize = 2;
            this.paymentFunCancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.paymentFunCancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.paymentFunCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paymentFunCancelBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentFunCancelBtn.Image = global::Snap_and_Print.Properties.Resources.printCancel;
            this.paymentFunCancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentFunCancelBtn.Location = new System.Drawing.Point(20, 10);
            this.paymentFunCancelBtn.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.paymentFunCancelBtn.Name = "paymentFunCancelBtn";
            this.paymentFunCancelBtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.paymentFunCancelBtn.Size = new System.Drawing.Size(175, 71);
            this.paymentFunCancelBtn.TabIndex = 0;
            this.paymentFunCancelBtn.Text = "CANCEL";
            this.paymentFunCancelBtn.UseVisualStyleBackColor = false;
            this.paymentFunCancelBtn.Click += new System.EventHandler(this.paymentFunCancelBtn_Click);
            // 
            // panel19
            // 
            this.panel19.BackColor = System.Drawing.Color.Silver;
            this.panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel19.Controls.Add(this.tableLayoutPanel115);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel19.Location = new System.Drawing.Point(160, 10);
            this.panel19.Margin = new System.Windows.Forms.Padding(160, 10, 160, 10);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(547, 370);
            this.panel19.TabIndex = 0;
            // 
            // tableLayoutPanel115
            // 
            this.tableLayoutPanel115.ColumnCount = 1;
            this.tableLayoutPanel115.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel115.Controls.Add(this.tableLayoutPanel116, 0, 1);
            this.tableLayoutPanel115.Controls.Add(this.tableLayoutPanel69, 0, 4);
            this.tableLayoutPanel115.Controls.Add(this.tableLayoutPanel68, 0, 2);
            this.tableLayoutPanel115.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel115.Controls.Add(this.tableLayoutPanel117, 0, 3);
            this.tableLayoutPanel115.Controls.Add(this.funPrintingStatusLabel, 0, 10);
            this.tableLayoutPanel115.Controls.Add(this.tableLayoutPanel118, 0, 5);
            this.tableLayoutPanel115.Controls.Add(this.tableLayoutPanel119, 0, 7);
            this.tableLayoutPanel115.Controls.Add(this.tableLayoutPanel120, 0, 9);
            this.tableLayoutPanel115.Controls.Add(this.tableLayoutPanel121, 0, 6);
            this.tableLayoutPanel115.Controls.Add(this.tableLayoutPanel122, 0, 8);
            this.tableLayoutPanel115.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel115.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel115.Name = "tableLayoutPanel115";
            this.tableLayoutPanel115.RowCount = 11;
            this.tableLayoutPanel115.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.80198F));
            this.tableLayoutPanel115.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.990099F));
            this.tableLayoutPanel115.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.33663F));
            this.tableLayoutPanel115.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.990099F));
            this.tableLayoutPanel115.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.33663F));
            this.tableLayoutPanel115.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.990099F));
            this.tableLayoutPanel115.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.33663F));
            this.tableLayoutPanel115.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.990099F));
            this.tableLayoutPanel115.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.33663F));
            this.tableLayoutPanel115.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.990099F));
            this.tableLayoutPanel115.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.90099F));
            this.tableLayoutPanel115.Size = new System.Drawing.Size(545, 368);
            this.tableLayoutPanel115.TabIndex = 0;
            // 
            // tableLayoutPanel116
            // 
            this.tableLayoutPanel116.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel116.ColumnCount = 1;
            this.tableLayoutPanel116.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel116.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel116.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel116.Location = new System.Drawing.Point(120, 75);
            this.tableLayoutPanel116.Margin = new System.Windows.Forms.Padding(120, 3, 120, 3);
            this.tableLayoutPanel116.Name = "tableLayoutPanel116";
            this.tableLayoutPanel116.RowCount = 1;
            this.tableLayoutPanel116.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel116.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel116.Size = new System.Drawing.Size(305, 1);
            this.tableLayoutPanel116.TabIndex = 0;
            // 
            // tableLayoutPanel69
            // 
            this.tableLayoutPanel69.ColumnCount = 2;
            this.tableLayoutPanel69.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel69.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel69.Controls.Add(this.label41, 0, 0);
            this.tableLayoutPanel69.Controls.Add(this.paymentFunBalance, 1, 0);
            this.tableLayoutPanel69.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel69.Location = new System.Drawing.Point(3, 141);
            this.tableLayoutPanel69.Name = "tableLayoutPanel69";
            this.tableLayoutPanel69.RowCount = 1;
            this.tableLayoutPanel69.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel69.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel69.Size = new System.Drawing.Size(539, 54);
            this.tableLayoutPanel69.TabIndex = 9;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label41.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(3, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(263, 54);
            this.label41.TabIndex = 2;
            this.label41.Text = "Balance :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // paymentFunBalance
            // 
            this.paymentFunBalance.AutoSize = true;
            this.paymentFunBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentFunBalance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentFunBalance.Image = global::Snap_and_Print.Properties.Resources.peso__1_;
            this.paymentFunBalance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentFunBalance.Location = new System.Drawing.Point(272, 0);
            this.paymentFunBalance.Name = "paymentFunBalance";
            this.paymentFunBalance.Padding = new System.Windows.Forms.Padding(0, 0, 140, 0);
            this.paymentFunBalance.Size = new System.Drawing.Size(264, 54);
            this.paymentFunBalance.TabIndex = 3;
            this.paymentFunBalance.Text = "[0]";
            this.paymentFunBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel68
            // 
            this.tableLayoutPanel68.ColumnCount = 2;
            this.tableLayoutPanel68.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel68.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel68.Controls.Add(this.label39, 0, 0);
            this.tableLayoutPanel68.Controls.Add(this.paymentFunTotal, 1, 0);
            this.tableLayoutPanel68.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel68.Location = new System.Drawing.Point(3, 78);
            this.tableLayoutPanel68.Name = "tableLayoutPanel68";
            this.tableLayoutPanel68.RowCount = 1;
            this.tableLayoutPanel68.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel68.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel68.Size = new System.Drawing.Size(539, 54);
            this.tableLayoutPanel68.TabIndex = 8;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label39.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(3, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(263, 54);
            this.label39.TabIndex = 0;
            this.label39.Text = "Total Amount :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // paymentFunTotal
            // 
            this.paymentFunTotal.AutoSize = true;
            this.paymentFunTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentFunTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentFunTotal.Image = global::Snap_and_Print.Properties.Resources.peso__1_;
            this.paymentFunTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentFunTotal.Location = new System.Drawing.Point(272, 0);
            this.paymentFunTotal.Name = "paymentFunTotal";
            this.paymentFunTotal.Padding = new System.Windows.Forms.Padding(0, 0, 140, 0);
            this.paymentFunTotal.Size = new System.Drawing.Size(264, 54);
            this.paymentFunTotal.TabIndex = 1;
            this.paymentFunTotal.Text = "[0]";
            this.paymentFunTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(539, 72);
            this.label9.TabIndex = 11;
            this.label9.Text = "Payment";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel117
            // 
            this.tableLayoutPanel117.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel117.ColumnCount = 1;
            this.tableLayoutPanel117.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel117.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel117.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel117.Location = new System.Drawing.Point(80, 138);
            this.tableLayoutPanel117.Margin = new System.Windows.Forms.Padding(80, 3, 80, 3);
            this.tableLayoutPanel117.Name = "tableLayoutPanel117";
            this.tableLayoutPanel117.RowCount = 1;
            this.tableLayoutPanel117.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel117.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel117.Size = new System.Drawing.Size(385, 1);
            this.tableLayoutPanel117.TabIndex = 2;
            // 
            // funPrintingStatusLabel
            // 
            this.funPrintingStatusLabel.AutoSize = true;
            this.funPrintingStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funPrintingStatusLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funPrintingStatusLabel.Location = new System.Drawing.Point(160, 332);
            this.funPrintingStatusLabel.Margin = new System.Windows.Forms.Padding(160, 5, 160, 5);
            this.funPrintingStatusLabel.Name = "funPrintingStatusLabel";
            this.funPrintingStatusLabel.Size = new System.Drawing.Size(225, 31);
            this.funPrintingStatusLabel.TabIndex = 12;
            this.funPrintingStatusLabel.Text = "...";
            this.funPrintingStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel118
            // 
            this.tableLayoutPanel118.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel118.ColumnCount = 1;
            this.tableLayoutPanel118.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel118.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel118.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel118.Location = new System.Drawing.Point(80, 201);
            this.tableLayoutPanel118.Margin = new System.Windows.Forms.Padding(80, 3, 80, 3);
            this.tableLayoutPanel118.Name = "tableLayoutPanel118";
            this.tableLayoutPanel118.RowCount = 1;
            this.tableLayoutPanel118.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel118.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel118.Size = new System.Drawing.Size(385, 1);
            this.tableLayoutPanel118.TabIndex = 3;
            // 
            // tableLayoutPanel119
            // 
            this.tableLayoutPanel119.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel119.ColumnCount = 1;
            this.tableLayoutPanel119.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel119.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel119.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel119.Location = new System.Drawing.Point(80, 264);
            this.tableLayoutPanel119.Margin = new System.Windows.Forms.Padding(80, 3, 80, 3);
            this.tableLayoutPanel119.Name = "tableLayoutPanel119";
            this.tableLayoutPanel119.RowCount = 1;
            this.tableLayoutPanel119.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel119.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel119.Size = new System.Drawing.Size(385, 1);
            this.tableLayoutPanel119.TabIndex = 4;
            // 
            // tableLayoutPanel120
            // 
            this.tableLayoutPanel120.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel120.ColumnCount = 1;
            this.tableLayoutPanel120.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel120.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel120.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel120.Location = new System.Drawing.Point(150, 327);
            this.tableLayoutPanel120.Margin = new System.Windows.Forms.Padding(150, 3, 150, 3);
            this.tableLayoutPanel120.Name = "tableLayoutPanel120";
            this.tableLayoutPanel120.RowCount = 1;
            this.tableLayoutPanel120.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel120.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel120.Size = new System.Drawing.Size(245, 1);
            this.tableLayoutPanel120.TabIndex = 5;
            // 
            // tableLayoutPanel121
            // 
            this.tableLayoutPanel121.ColumnCount = 2;
            this.tableLayoutPanel121.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel121.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel121.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel121.Controls.Add(this.paymentFunInserted, 1, 0);
            this.tableLayoutPanel121.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel121.Location = new System.Drawing.Point(3, 204);
            this.tableLayoutPanel121.Name = "tableLayoutPanel121";
            this.tableLayoutPanel121.RowCount = 1;
            this.tableLayoutPanel121.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel121.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel121.Size = new System.Drawing.Size(539, 54);
            this.tableLayoutPanel121.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(263, 54);
            this.label10.TabIndex = 0;
            this.label10.Text = "Payment Inserted :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // paymentFunInserted
            // 
            this.paymentFunInserted.AutoSize = true;
            this.paymentFunInserted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentFunInserted.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentFunInserted.Image = global::Snap_and_Print.Properties.Resources.peso__1_;
            this.paymentFunInserted.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentFunInserted.Location = new System.Drawing.Point(272, 0);
            this.paymentFunInserted.Name = "paymentFunInserted";
            this.paymentFunInserted.Padding = new System.Windows.Forms.Padding(0, 0, 140, 0);
            this.paymentFunInserted.Size = new System.Drawing.Size(264, 54);
            this.paymentFunInserted.TabIndex = 1;
            this.paymentFunInserted.Text = "[0]";
            this.paymentFunInserted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel122
            // 
            this.tableLayoutPanel122.ColumnCount = 2;
            this.tableLayoutPanel122.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel122.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel122.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel122.Controls.Add(this.paymentFunChange, 1, 0);
            this.tableLayoutPanel122.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel122.Location = new System.Drawing.Point(3, 267);
            this.tableLayoutPanel122.Name = "tableLayoutPanel122";
            this.tableLayoutPanel122.RowCount = 1;
            this.tableLayoutPanel122.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel122.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel122.Size = new System.Drawing.Size(539, 54);
            this.tableLayoutPanel122.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(263, 54);
            this.label11.TabIndex = 0;
            this.label11.Text = "Change :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // paymentFunChange
            // 
            this.paymentFunChange.AutoSize = true;
            this.paymentFunChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentFunChange.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentFunChange.Image = global::Snap_and_Print.Properties.Resources.peso__1_;
            this.paymentFunChange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.paymentFunChange.Location = new System.Drawing.Point(272, 0);
            this.paymentFunChange.Name = "paymentFunChange";
            this.paymentFunChange.Padding = new System.Windows.Forms.Padding(0, 0, 140, 0);
            this.paymentFunChange.Size = new System.Drawing.Size(264, 54);
            this.paymentFunChange.TabIndex = 1;
            this.paymentFunChange.Text = "[0]";
            this.paymentFunChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCMRphotoBooth
            // 
            this.panelCMRphotoBooth.Controls.Add(this.tableLayoutPanel31);
            this.panelCMRphotoBooth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCMRphotoBooth.Location = new System.Drawing.Point(0, 0);
            this.panelCMRphotoBooth.Name = "panelCMRphotoBooth";
            this.panelCMRphotoBooth.Size = new System.Drawing.Size(1456, 729);
            this.panelCMRphotoBooth.TabIndex = 2;
            // 
            // tableLayoutPanel31
            // 
            this.tableLayoutPanel31.ColumnCount = 3;
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72529F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.54942F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72529F));
            this.tableLayoutPanel31.Controls.Add(this.funCaptureAgainBtn, 2, 2);
            this.tableLayoutPanel31.Controls.Add(this.funCameraFeed, 1, 0);
            this.tableLayoutPanel31.Controls.Add(this.tableLayoutPanel29, 0, 0);
            this.tableLayoutPanel31.Controls.Add(this.tableLayoutPanel30, 1, 2);
            this.tableLayoutPanel31.Controls.Add(this.tableLayoutPanel79, 1, 1);
            this.tableLayoutPanel31.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel31.Location = new System.Drawing.Point(0, 203);
            this.tableLayoutPanel31.Name = "tableLayoutPanel31";
            this.tableLayoutPanel31.RowCount = 3;
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.20792F));
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.990099F));
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.80198F));
            this.tableLayoutPanel31.Size = new System.Drawing.Size(1456, 526);
            this.tableLayoutPanel31.TabIndex = 2;
            // 
            // funCaptureAgainBtn
            // 
            this.funCaptureAgainBtn.BackColor = System.Drawing.Color.Silver;
            this.funCaptureAgainBtn.BackgroundImage = global::Snap_and_Print.Properties.Resources.reset_left_fill;
            this.funCaptureAgainBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.funCaptureAgainBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funCaptureAgainBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funCaptureAgainBtn.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.funCaptureAgainBtn.FlatAppearance.BorderSize = 2;
            this.funCaptureAgainBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.funCaptureAgainBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.funCaptureAgainBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.funCaptureAgainBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funCaptureAgainBtn.Location = new System.Drawing.Point(1244, 431);
            this.funCaptureAgainBtn.Margin = new System.Windows.Forms.Padding(120, 10, 120, 10);
            this.funCaptureAgainBtn.Name = "funCaptureAgainBtn";
            this.funCaptureAgainBtn.Size = new System.Drawing.Size(92, 85);
            this.funCaptureAgainBtn.TabIndex = 0;
            this.funCaptureAgainBtn.UseVisualStyleBackColor = false;
            // 
            // funCameraFeed
            // 
            this.funCameraFeed.BackColor = System.Drawing.Color.DarkGray;
            this.funCameraFeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funCameraFeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funCameraFeed.Location = new System.Drawing.Point(480, 10);
            this.funCameraFeed.Margin = new System.Windows.Forms.Padding(150, 10, 150, 10);
            this.funCameraFeed.Name = "funCameraFeed";
            this.funCameraFeed.Padding = new System.Windows.Forms.Padding(3);
            this.funCameraFeed.Size = new System.Drawing.Size(494, 396);
            this.funCameraFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.funCameraFeed.TabIndex = 2;
            this.funCameraFeed.TabStop = false;
            // 
            // tableLayoutPanel29
            // 
            this.tableLayoutPanel29.ColumnCount = 2;
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel29.Controls.Add(this.funPreview4, 1, 1);
            this.tableLayoutPanel29.Controls.Add(this.funPreview3, 0, 1);
            this.tableLayoutPanel29.Controls.Add(this.funPreview2, 1, 0);
            this.tableLayoutPanel29.Controls.Add(this.funPreview1, 0, 0);
            this.tableLayoutPanel29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel29.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel29.Name = "tableLayoutPanel29";
            this.tableLayoutPanel29.RowCount = 2;
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel29.Size = new System.Drawing.Size(324, 410);
            this.tableLayoutPanel29.TabIndex = 3;
            // 
            // funPreview4
            // 
            this.funPreview4.BackColor = System.Drawing.Color.Silver;
            this.funPreview4.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.funPreview4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.funPreview4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funPreview4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funPreview4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funPreview4.Location = new System.Drawing.Point(167, 209);
            this.funPreview4.Margin = new System.Windows.Forms.Padding(5);
            this.funPreview4.Name = "funPreview4";
            this.funPreview4.Padding = new System.Windows.Forms.Padding(3);
            this.funPreview4.Size = new System.Drawing.Size(152, 196);
            this.funPreview4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.funPreview4.TabIndex = 3;
            this.funPreview4.TabStop = false;
            // 
            // funPreview3
            // 
            this.funPreview3.BackColor = System.Drawing.Color.Silver;
            this.funPreview3.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.funPreview3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.funPreview3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funPreview3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funPreview3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funPreview3.Location = new System.Drawing.Point(5, 209);
            this.funPreview3.Margin = new System.Windows.Forms.Padding(5);
            this.funPreview3.Name = "funPreview3";
            this.funPreview3.Padding = new System.Windows.Forms.Padding(3);
            this.funPreview3.Size = new System.Drawing.Size(152, 196);
            this.funPreview3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.funPreview3.TabIndex = 2;
            this.funPreview3.TabStop = false;
            // 
            // funPreview2
            // 
            this.funPreview2.BackColor = System.Drawing.Color.Silver;
            this.funPreview2.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.funPreview2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.funPreview2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funPreview2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funPreview2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funPreview2.Location = new System.Drawing.Point(167, 5);
            this.funPreview2.Margin = new System.Windows.Forms.Padding(5);
            this.funPreview2.Name = "funPreview2";
            this.funPreview2.Padding = new System.Windows.Forms.Padding(3);
            this.funPreview2.Size = new System.Drawing.Size(152, 194);
            this.funPreview2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.funPreview2.TabIndex = 1;
            this.funPreview2.TabStop = false;
            // 
            // funPreview1
            // 
            this.funPreview1.BackColor = System.Drawing.Color.Silver;
            this.funPreview1.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.funPreview1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.funPreview1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funPreview1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funPreview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funPreview1.Location = new System.Drawing.Point(5, 5);
            this.funPreview1.Margin = new System.Windows.Forms.Padding(5);
            this.funPreview1.Name = "funPreview1";
            this.funPreview1.Padding = new System.Windows.Forms.Padding(3);
            this.funPreview1.Size = new System.Drawing.Size(152, 194);
            this.funPreview1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.funPreview1.TabIndex = 0;
            this.funPreview1.TabStop = false;
            // 
            // tableLayoutPanel30
            // 
            this.tableLayoutPanel30.ColumnCount = 3;
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel30.Controls.Add(this.funCaptureBtn, 1, 0);
            this.tableLayoutPanel30.Controls.Add(this.funCancelBtn, 0, 0);
            this.tableLayoutPanel30.Controls.Add(this.funContinueBtn, 2, 0);
            this.tableLayoutPanel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel30.Location = new System.Drawing.Point(333, 424);
            this.tableLayoutPanel30.Name = "tableLayoutPanel30";
            this.tableLayoutPanel30.RowCount = 1;
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel30.Size = new System.Drawing.Size(788, 99);
            this.tableLayoutPanel30.TabIndex = 4;
            // 
            // funCaptureBtn
            // 
            this.funCaptureBtn.BackColor = System.Drawing.Color.DarkGray;
            this.funCaptureBtn.BackgroundImage = global::Snap_and_Print.Properties.Resources.camera_fill;
            this.funCaptureBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.funCaptureBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funCaptureBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funCaptureBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.funCaptureBtn.FlatAppearance.BorderSize = 2;
            this.funCaptureBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.funCaptureBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.funCaptureBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.funCaptureBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funCaptureBtn.Location = new System.Drawing.Point(342, 10);
            this.funCaptureBtn.Margin = new System.Windows.Forms.Padding(80, 10, 80, 10);
            this.funCaptureBtn.Name = "funCaptureBtn";
            this.funCaptureBtn.Size = new System.Drawing.Size(102, 79);
            this.funCaptureBtn.TabIndex = 0;
            this.funCaptureBtn.UseVisualStyleBackColor = false;
            this.funCaptureBtn.Click += new System.EventHandler(this.funCaptureBtn_Click);
            // 
            // funCancelBtn
            // 
            this.funCancelBtn.BackColor = System.Drawing.Color.DarkGray;
            this.funCancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funCancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.funCancelBtn.FlatAppearance.BorderSize = 2;
            this.funCancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.funCancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.funCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.funCancelBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funCancelBtn.Image = global::Snap_and_Print.Properties.Resources.printCancel;
            this.funCancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.funCancelBtn.Location = new System.Drawing.Point(30, 10);
            this.funCancelBtn.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.funCancelBtn.Name = "funCancelBtn";
            this.funCancelBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.funCancelBtn.Size = new System.Drawing.Size(202, 79);
            this.funCancelBtn.TabIndex = 0;
            this.funCancelBtn.Text = "CANCEL";
            this.funCancelBtn.UseVisualStyleBackColor = false;
            this.funCancelBtn.Click += new System.EventHandler(this.funCancelBtn_Click);
            // 
            // funContinueBtn
            // 
            this.funContinueBtn.BackColor = System.Drawing.Color.DarkGray;
            this.funContinueBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funContinueBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funContinueBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.funContinueBtn.FlatAppearance.BorderSize = 2;
            this.funContinueBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.funContinueBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.funContinueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.funContinueBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funContinueBtn.Image = global::Snap_and_Print.Properties.Resources.printContinue;
            this.funContinueBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.funContinueBtn.Location = new System.Drawing.Point(554, 10);
            this.funContinueBtn.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.funContinueBtn.Name = "funContinueBtn";
            this.funContinueBtn.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.funContinueBtn.Size = new System.Drawing.Size(204, 79);
            this.funContinueBtn.TabIndex = 3;
            this.funContinueBtn.Text = "CONTINUE";
            this.funContinueBtn.UseVisualStyleBackColor = false;
            this.funContinueBtn.Click += new System.EventHandler(this.funContinueBtn_Click);
            // 
            // tableLayoutPanel79
            // 
            this.tableLayoutPanel79.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel79.ColumnCount = 1;
            this.tableLayoutPanel79.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel79.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel79.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel79.Location = new System.Drawing.Point(380, 421);
            this.tableLayoutPanel79.Margin = new System.Windows.Forms.Padding(50, 5, 50, 5);
            this.tableLayoutPanel79.Name = "tableLayoutPanel79";
            this.tableLayoutPanel79.RowCount = 1;
            this.tableLayoutPanel79.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel79.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel79.Size = new System.Drawing.Size(694, 1);
            this.tableLayoutPanel79.TabIndex = 5;
            // 
            // photoBoothSettings
            // 
            this.photoBoothSettings.BackgroundImage = global::Snap_and_Print.Properties.Resources.PBSBG1;
            this.photoBoothSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.photoBoothSettings.Controls.Add(this.funSettings);
            this.photoBoothSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBoothSettings.Location = new System.Drawing.Point(0, 0);
            this.photoBoothSettings.Name = "photoBoothSettings";
            this.photoBoothSettings.Size = new System.Drawing.Size(1456, 729);
            this.photoBoothSettings.TabIndex = 2;
            // 
            // funSettings
            // 
            this.funSettings.Controls.Add(this.panel8);
            this.funSettings.Controls.Add(this.tableLayoutPanel56);
            this.funSettings.Controls.Add(this.tableLayoutPanel54);
            this.funSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funSettings.Location = new System.Drawing.Point(0, 0);
            this.funSettings.Name = "funSettings";
            this.funSettings.Size = new System.Drawing.Size(1456, 729);
            this.funSettings.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.tableLayoutPanel58);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(823, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(633, 642);
            this.panel8.TabIndex = 3;
            // 
            // tableLayoutPanel58
            // 
            this.tableLayoutPanel58.ColumnCount = 1;
            this.tableLayoutPanel58.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel58.Controls.Add(this.panel12, 0, 1);
            this.tableLayoutPanel58.Controls.Add(this.panel18, 0, 2);
            this.tableLayoutPanel58.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel58.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel58.Name = "tableLayoutPanel58";
            this.tableLayoutPanel58.RowCount = 3;
            this.tableLayoutPanel58.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel58.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel58.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel58.Size = new System.Drawing.Size(633, 642);
            this.tableLayoutPanel58.TabIndex = 0;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Silver;
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.tableLayoutPanel59);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(20, 170);
            this.panel12.Margin = new System.Windows.Forms.Padding(20, 10, 25, 10);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(588, 333);
            this.panel12.TabIndex = 0;
            // 
            // tableLayoutPanel59
            // 
            this.tableLayoutPanel59.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel59.ColumnCount = 2;
            this.tableLayoutPanel59.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel59.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel59.Controls.Add(this.tableLayoutPanel60, 1, 0);
            this.tableLayoutPanel59.Controls.Add(this.funMainPreview, 0, 0);
            this.tableLayoutPanel59.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel59.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel59.Name = "tableLayoutPanel59";
            this.tableLayoutPanel59.RowCount = 1;
            this.tableLayoutPanel59.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 99.99999F));
            this.tableLayoutPanel59.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 331F));
            this.tableLayoutPanel59.Size = new System.Drawing.Size(586, 331);
            this.tableLayoutPanel59.TabIndex = 0;
            // 
            // tableLayoutPanel60
            // 
            this.tableLayoutPanel60.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel60.ColumnCount = 1;
            this.tableLayoutPanel60.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel60.Controls.Add(this.funMiniPreview, 0, 0);
            this.tableLayoutPanel60.Controls.Add(this.pictureBox15, 0, 1);
            this.tableLayoutPanel60.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel60.Location = new System.Drawing.Point(442, 3);
            this.tableLayoutPanel60.Name = "tableLayoutPanel60";
            this.tableLayoutPanel60.RowCount = 2;
            this.tableLayoutPanel60.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel60.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel60.Size = new System.Drawing.Size(141, 325);
            this.tableLayoutPanel60.TabIndex = 0;
            // 
            // funMiniPreview
            // 
            this.funMiniPreview.BackColor = System.Drawing.Color.Silver;
            this.funMiniPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funMiniPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funMiniPreview.Location = new System.Drawing.Point(0, 3);
            this.funMiniPreview.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.funMiniPreview.Name = "funMiniPreview";
            this.funMiniPreview.Padding = new System.Windows.Forms.Padding(2);
            this.funMiniPreview.Size = new System.Drawing.Size(138, 124);
            this.funMiniPreview.TabIndex = 0;
            this.funMiniPreview.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox15.Image = global::Snap_and_Print.Properties.Resources.camera_lens_ai_line;
            this.pictureBox15.Location = new System.Drawing.Point(0, 133);
            this.pictureBox15.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Padding = new System.Windows.Forms.Padding(2);
            this.pictureBox15.Size = new System.Drawing.Size(141, 189);
            this.pictureBox15.TabIndex = 1;
            this.pictureBox15.TabStop = false;
            // 
            // funMainPreview
            // 
            this.funMainPreview.BackColor = System.Drawing.Color.Silver;
            this.funMainPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funMainPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funMainPreview.Location = new System.Drawing.Point(5, 5);
            this.funMainPreview.Margin = new System.Windows.Forms.Padding(5);
            this.funMainPreview.Name = "funMainPreview";
            this.funMainPreview.Padding = new System.Windows.Forms.Padding(2);
            this.funMainPreview.Size = new System.Drawing.Size(429, 321);
            this.funMainPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.funMainPreview.TabIndex = 1;
            this.funMainPreview.TabStop = false;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.Silver;
            this.panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel18.Controls.Add(this.tableLayoutPanel112);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel18.Location = new System.Drawing.Point(20, 518);
            this.panel18.Margin = new System.Windows.Forms.Padding(20, 5, 25, 5);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(588, 119);
            this.panel18.TabIndex = 1;
            // 
            // tableLayoutPanel112
            // 
            this.tableLayoutPanel112.ColumnCount = 4;
            this.tableLayoutPanel112.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel112.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel112.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel112.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel112.Controls.Add(this.funSelectPic4, 3, 0);
            this.tableLayoutPanel112.Controls.Add(this.funSelectPic1, 0, 0);
            this.tableLayoutPanel112.Controls.Add(this.funSelectPic3, 2, 0);
            this.tableLayoutPanel112.Controls.Add(this.funSelectPic2, 1, 0);
            this.tableLayoutPanel112.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel112.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel112.Name = "tableLayoutPanel112";
            this.tableLayoutPanel112.RowCount = 1;
            this.tableLayoutPanel112.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel112.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel112.Size = new System.Drawing.Size(586, 117);
            this.tableLayoutPanel112.TabIndex = 0;
            // 
            // funSelectPic4
            // 
            this.funSelectPic4.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.funSelectPic4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.funSelectPic4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funSelectPic4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funSelectPic4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funSelectPic4.Location = new System.Drawing.Point(443, 5);
            this.funSelectPic4.Margin = new System.Windows.Forms.Padding(5);
            this.funSelectPic4.Name = "funSelectPic4";
            this.funSelectPic4.Size = new System.Drawing.Size(138, 107);
            this.funSelectPic4.TabIndex = 0;
            this.funSelectPic4.TabStop = false;
            this.funSelectPic4.Click += new System.EventHandler(this.FunSelectPhoto_Click);
            // 
            // funSelectPic1
            // 
            this.funSelectPic1.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.funSelectPic1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.funSelectPic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funSelectPic1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funSelectPic1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funSelectPic1.Location = new System.Drawing.Point(5, 5);
            this.funSelectPic1.Margin = new System.Windows.Forms.Padding(5);
            this.funSelectPic1.Name = "funSelectPic1";
            this.funSelectPic1.Size = new System.Drawing.Size(136, 107);
            this.funSelectPic1.TabIndex = 3;
            this.funSelectPic1.TabStop = false;
            this.funSelectPic1.Click += new System.EventHandler(this.FunSelectPhoto_Click);
            // 
            // funSelectPic3
            // 
            this.funSelectPic3.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.funSelectPic3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.funSelectPic3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funSelectPic3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funSelectPic3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funSelectPic3.Location = new System.Drawing.Point(297, 5);
            this.funSelectPic3.Margin = new System.Windows.Forms.Padding(5);
            this.funSelectPic3.Name = "funSelectPic3";
            this.funSelectPic3.Size = new System.Drawing.Size(136, 107);
            this.funSelectPic3.TabIndex = 1;
            this.funSelectPic3.TabStop = false;
            this.funSelectPic3.Click += new System.EventHandler(this.FunSelectPhoto_Click);
            // 
            // funSelectPic2
            // 
            this.funSelectPic2.BackgroundImage = global::Snap_and_Print.Properties.Resources.file_user_line;
            this.funSelectPic2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.funSelectPic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.funSelectPic2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funSelectPic2.Location = new System.Drawing.Point(151, 5);
            this.funSelectPic2.Margin = new System.Windows.Forms.Padding(5);
            this.funSelectPic2.Name = "funSelectPic2";
            this.funSelectPic2.Size = new System.Drawing.Size(136, 107);
            this.funSelectPic2.TabIndex = 2;
            this.funSelectPic2.TabStop = false;
            this.funSelectPic2.Click += new System.EventHandler(this.FunSelectPhoto_Click);
            // 
            // tableLayoutPanel56
            // 
            this.tableLayoutPanel56.ColumnCount = 1;
            this.tableLayoutPanel56.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel56.Controls.Add(this.panel16, 0, 1);
            this.tableLayoutPanel56.Controls.Add(this.panel17, 0, 2);
            this.tableLayoutPanel56.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel56.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel56.Name = "tableLayoutPanel56";
            this.tableLayoutPanel56.RowCount = 3;
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel56.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel56.Size = new System.Drawing.Size(632, 642);
            this.tableLayoutPanel56.TabIndex = 0;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.Silver;
            this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel16.Controls.Add(this.tableLayoutPanel66);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(25, 170);
            this.panel16.Margin = new System.Windows.Forms.Padding(25, 10, 20, 10);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(587, 397);
            this.panel16.TabIndex = 0;
            // 
            // tableLayoutPanel66
            // 
            this.tableLayoutPanel66.ColumnCount = 1;
            this.tableLayoutPanel66.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel66.Controls.Add(this.tableLayoutPanel62, 0, 11);
            this.tableLayoutPanel66.Controls.Add(this.tableLayoutPanel61, 0, 8);
            this.tableLayoutPanel66.Controls.Add(this.tableLayoutPanel43, 0, 7);
            this.tableLayoutPanel66.Controls.Add(this.tableLayoutPanel57, 0, 5);
            this.tableLayoutPanel66.Controls.Add(this.tableLayoutPanel55, 0, 2);
            this.tableLayoutPanel66.Controls.Add(this.tableLayoutPanel63, 0, 0);
            this.tableLayoutPanel66.Controls.Add(this.tableLayoutPanel138, 0, 10);
            this.tableLayoutPanel66.Controls.Add(this.tableLayoutPanel78, 0, 3);
            this.tableLayoutPanel66.Controls.Add(this.tableLayoutPanel109, 0, 6);
            this.tableLayoutPanel66.Controls.Add(this.tableLayoutPanel49, 0, 4);
            this.tableLayoutPanel66.Controls.Add(this.tableLayoutPanel45, 0, 1);
            this.tableLayoutPanel66.Controls.Add(this.tableLayoutPanel141, 0, 9);
            this.tableLayoutPanel66.Controls.Add(this.tableLayoutPanel143, 0, 12);
            this.tableLayoutPanel66.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel66.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel66.Name = "tableLayoutPanel66";
            this.tableLayoutPanel66.RowCount = 13;
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.67961F));
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.67961F));
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9708738F));
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.67961F));
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.67961F));
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9708738F));
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.67961F));
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.67961F));
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9708738F));
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.67961F));
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.67961F));
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9708738F));
            this.tableLayoutPanel66.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.67961F));
            this.tableLayoutPanel66.Size = new System.Drawing.Size(585, 395);
            this.tableLayoutPanel66.TabIndex = 0;
            // 
            // tableLayoutPanel62
            // 
            this.tableLayoutPanel62.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel62.ColumnCount = 1;
            this.tableLayoutPanel62.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel62.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel62.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel62.Location = new System.Drawing.Point(50, 348);
            this.tableLayoutPanel62.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.tableLayoutPanel62.Name = "tableLayoutPanel62";
            this.tableLayoutPanel62.RowCount = 1;
            this.tableLayoutPanel62.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel62.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel62.Size = new System.Drawing.Size(485, 1);
            this.tableLayoutPanel62.TabIndex = 3;
            // 
            // tableLayoutPanel61
            // 
            this.tableLayoutPanel61.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel61.ColumnCount = 1;
            this.tableLayoutPanel61.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel61.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel61.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel61.Location = new System.Drawing.Point(50, 261);
            this.tableLayoutPanel61.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.tableLayoutPanel61.Name = "tableLayoutPanel61";
            this.tableLayoutPanel61.RowCount = 1;
            this.tableLayoutPanel61.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel61.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel61.Size = new System.Drawing.Size(485, 1);
            this.tableLayoutPanel61.TabIndex = 2;
            // 
            // tableLayoutPanel43
            // 
            this.tableLayoutPanel43.ColumnCount = 4;
            this.tableLayoutPanel43.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel43.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel43.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel43.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel43.Controls.Add(this.funRadioBtnWarm, 3, 0);
            this.tableLayoutPanel43.Controls.Add(this.funRadioBtnBlack, 2, 0);
            this.tableLayoutPanel43.Controls.Add(this.funRadioBtnFilterNone, 1, 0);
            this.tableLayoutPanel43.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel43.Location = new System.Drawing.Point(3, 219);
            this.tableLayoutPanel43.Name = "tableLayoutPanel43";
            this.tableLayoutPanel43.RowCount = 1;
            this.tableLayoutPanel43.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel43.Size = new System.Drawing.Size(579, 36);
            this.tableLayoutPanel43.TabIndex = 2;
            // 
            // funRadioBtnWarm
            // 
            this.funRadioBtnWarm.AutoSize = true;
            this.funRadioBtnWarm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funRadioBtnWarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funRadioBtnWarm.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funRadioBtnWarm.Location = new System.Drawing.Point(434, 2);
            this.funRadioBtnWarm.Margin = new System.Windows.Forms.Padding(2);
            this.funRadioBtnWarm.Name = "funRadioBtnWarm";
            this.funRadioBtnWarm.Size = new System.Drawing.Size(143, 32);
            this.funRadioBtnWarm.TabIndex = 0;
            this.funRadioBtnWarm.TabStop = true;
            this.funRadioBtnWarm.Text = "Warm";
            this.funRadioBtnWarm.UseVisualStyleBackColor = true;
            this.funRadioBtnWarm.Click += new System.EventHandler(this.funRadioBtnWarm_Click);
            // 
            // funRadioBtnBlack
            // 
            this.funRadioBtnBlack.AutoSize = true;
            this.funRadioBtnBlack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funRadioBtnBlack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funRadioBtnBlack.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funRadioBtnBlack.Location = new System.Drawing.Point(290, 2);
            this.funRadioBtnBlack.Margin = new System.Windows.Forms.Padding(2);
            this.funRadioBtnBlack.Name = "funRadioBtnBlack";
            this.funRadioBtnBlack.Size = new System.Drawing.Size(140, 32);
            this.funRadioBtnBlack.TabIndex = 0;
            this.funRadioBtnBlack.TabStop = true;
            this.funRadioBtnBlack.Text = "Black and White";
            this.funRadioBtnBlack.UseVisualStyleBackColor = true;
            this.funRadioBtnBlack.Click += new System.EventHandler(this.funRadioBtnBlack_Click);
            // 
            // funRadioBtnFilterNone
            // 
            this.funRadioBtnFilterNone.AutoSize = true;
            this.funRadioBtnFilterNone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funRadioBtnFilterNone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funRadioBtnFilterNone.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funRadioBtnFilterNone.Location = new System.Drawing.Point(146, 2);
            this.funRadioBtnFilterNone.Margin = new System.Windows.Forms.Padding(2);
            this.funRadioBtnFilterNone.Name = "funRadioBtnFilterNone";
            this.funRadioBtnFilterNone.Size = new System.Drawing.Size(140, 32);
            this.funRadioBtnFilterNone.TabIndex = 0;
            this.funRadioBtnFilterNone.TabStop = true;
            this.funRadioBtnFilterNone.Text = "None";
            this.funRadioBtnFilterNone.UseVisualStyleBackColor = true;
            this.funRadioBtnFilterNone.Click += new System.EventHandler(this.funRadioBtbFilterNone_Click);
            // 
            // tableLayoutPanel57
            // 
            this.tableLayoutPanel57.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel57.ColumnCount = 1;
            this.tableLayoutPanel57.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel57.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel57.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel57.Location = new System.Drawing.Point(50, 174);
            this.tableLayoutPanel57.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.tableLayoutPanel57.Name = "tableLayoutPanel57";
            this.tableLayoutPanel57.RowCount = 1;
            this.tableLayoutPanel57.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel57.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel57.Size = new System.Drawing.Size(485, 1);
            this.tableLayoutPanel57.TabIndex = 1;
            // 
            // tableLayoutPanel55
            // 
            this.tableLayoutPanel55.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel55.ColumnCount = 1;
            this.tableLayoutPanel55.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel55.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel55.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel55.Location = new System.Drawing.Point(50, 87);
            this.tableLayoutPanel55.Margin = new System.Windows.Forms.Padding(50, 3, 50, 3);
            this.tableLayoutPanel55.Name = "tableLayoutPanel55";
            this.tableLayoutPanel55.RowCount = 1;
            this.tableLayoutPanel55.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel55.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel55.Size = new System.Drawing.Size(485, 1);
            this.tableLayoutPanel55.TabIndex = 0;
            // 
            // tableLayoutPanel63
            // 
            this.tableLayoutPanel63.ColumnCount = 2;
            this.tableLayoutPanel63.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel63.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel63.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel63.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel63.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel63.Name = "tableLayoutPanel63";
            this.tableLayoutPanel63.RowCount = 1;
            this.tableLayoutPanel63.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel63.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel63.Size = new System.Drawing.Size(579, 36);
            this.tableLayoutPanel63.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::Snap_and_Print.Properties.Resources.layout_2_line;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(20, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(20, 3, 30, 3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(60, 0, 50, 0);
            this.label3.Size = new System.Drawing.Size(239, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Layout";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel138
            // 
            this.tableLayoutPanel138.ColumnCount = 4;
            this.tableLayoutPanel138.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel138.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel138.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel138.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel138.Controls.Add(this.funRadioPrintTypeSingle, 2, 0);
            this.tableLayoutPanel138.Controls.Add(this.funRadioPrintTypeAll, 1, 0);
            this.tableLayoutPanel138.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel138.Location = new System.Drawing.Point(3, 306);
            this.tableLayoutPanel138.Name = "tableLayoutPanel138";
            this.tableLayoutPanel138.RowCount = 1;
            this.tableLayoutPanel138.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel138.Size = new System.Drawing.Size(579, 36);
            this.tableLayoutPanel138.TabIndex = 8;
            // 
            // funRadioPrintTypeSingle
            // 
            this.funRadioPrintTypeSingle.AutoSize = true;
            this.funRadioPrintTypeSingle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funRadioPrintTypeSingle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funRadioPrintTypeSingle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funRadioPrintTypeSingle.Location = new System.Drawing.Point(291, 3);
            this.funRadioPrintTypeSingle.Name = "funRadioPrintTypeSingle";
            this.funRadioPrintTypeSingle.Size = new System.Drawing.Size(138, 30);
            this.funRadioPrintTypeSingle.TabIndex = 1;
            this.funRadioPrintTypeSingle.TabStop = true;
            this.funRadioPrintTypeSingle.Text = "Single Print";
            this.funRadioPrintTypeSingle.UseVisualStyleBackColor = true;
            this.funRadioPrintTypeSingle.Click += new System.EventHandler(this.funRadioPrintTypeSingle_CheckedChanged);
            // 
            // funRadioPrintTypeAll
            // 
            this.funRadioPrintTypeAll.AutoSize = true;
            this.funRadioPrintTypeAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funRadioPrintTypeAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funRadioPrintTypeAll.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funRadioPrintTypeAll.Location = new System.Drawing.Point(147, 3);
            this.funRadioPrintTypeAll.Name = "funRadioPrintTypeAll";
            this.funRadioPrintTypeAll.Size = new System.Drawing.Size(138, 30);
            this.funRadioPrintTypeAll.TabIndex = 0;
            this.funRadioPrintTypeAll.TabStop = true;
            this.funRadioPrintTypeAll.Text = "Print All";
            this.funRadioPrintTypeAll.UseVisualStyleBackColor = true;
            this.funRadioPrintTypeAll.Click += new System.EventHandler(this.funRadioPrintTypeAll_CheckedChanged);
            // 
            // tableLayoutPanel78
            // 
            this.tableLayoutPanel78.ColumnCount = 2;
            this.tableLayoutPanel78.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel78.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel78.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel78.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel78.Location = new System.Drawing.Point(3, 90);
            this.tableLayoutPanel78.Name = "tableLayoutPanel78";
            this.tableLayoutPanel78.RowCount = 1;
            this.tableLayoutPanel78.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel78.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel78.Size = new System.Drawing.Size(579, 36);
            this.tableLayoutPanel78.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = global::Snap_and_Print.Properties.Resources.rounded_corner;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(20, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(20, 3, 30, 3);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(60, 0, 60, 0);
            this.label4.Size = new System.Drawing.Size(239, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Frame";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel109
            // 
            this.tableLayoutPanel109.ColumnCount = 2;
            this.tableLayoutPanel109.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel109.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel109.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel109.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel109.Location = new System.Drawing.Point(3, 177);
            this.tableLayoutPanel109.Name = "tableLayoutPanel109";
            this.tableLayoutPanel109.RowCount = 1;
            this.tableLayoutPanel109.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel109.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel109.Size = new System.Drawing.Size(579, 36);
            this.tableLayoutPanel109.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = global::Snap_and_Print.Properties.Resources.color_filter_ai_line;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(20, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(20, 3, 30, 3);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(60, 0, 70, 0);
            this.label5.Size = new System.Drawing.Size(239, 30);
            this.label5.TabIndex = 4;
            this.label5.Text = "Filter";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel49
            // 
            this.tableLayoutPanel49.ColumnCount = 4;
            this.tableLayoutPanel49.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel49.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel49.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel49.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel49.Controls.Add(this.funRadioBtnCute, 3, 0);
            this.tableLayoutPanel49.Controls.Add(this.funRadioBtnMinimal, 2, 0);
            this.tableLayoutPanel49.Controls.Add(this.funRadioBtnFrameNone, 1, 0);
            this.tableLayoutPanel49.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel49.Location = new System.Drawing.Point(3, 132);
            this.tableLayoutPanel49.Name = "tableLayoutPanel49";
            this.tableLayoutPanel49.RowCount = 1;
            this.tableLayoutPanel49.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel49.Size = new System.Drawing.Size(579, 36);
            this.tableLayoutPanel49.TabIndex = 7;
            // 
            // funRadioBtnCute
            // 
            this.funRadioBtnCute.AutoSize = true;
            this.funRadioBtnCute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funRadioBtnCute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funRadioBtnCute.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funRadioBtnCute.Location = new System.Drawing.Point(434, 2);
            this.funRadioBtnCute.Margin = new System.Windows.Forms.Padding(2);
            this.funRadioBtnCute.Name = "funRadioBtnCute";
            this.funRadioBtnCute.Size = new System.Drawing.Size(143, 32);
            this.funRadioBtnCute.TabIndex = 0;
            this.funRadioBtnCute.TabStop = true;
            this.funRadioBtnCute.Text = "Cute";
            this.funRadioBtnCute.UseVisualStyleBackColor = true;
            this.funRadioBtnCute.Click += new System.EventHandler(this.funRadioBtnCute_Click);
            // 
            // funRadioBtnMinimal
            // 
            this.funRadioBtnMinimal.AutoSize = true;
            this.funRadioBtnMinimal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funRadioBtnMinimal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funRadioBtnMinimal.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funRadioBtnMinimal.Location = new System.Drawing.Point(290, 2);
            this.funRadioBtnMinimal.Margin = new System.Windows.Forms.Padding(2);
            this.funRadioBtnMinimal.Name = "funRadioBtnMinimal";
            this.funRadioBtnMinimal.Size = new System.Drawing.Size(140, 32);
            this.funRadioBtnMinimal.TabIndex = 0;
            this.funRadioBtnMinimal.TabStop = true;
            this.funRadioBtnMinimal.Text = "Minimal";
            this.funRadioBtnMinimal.UseVisualStyleBackColor = true;
            this.funRadioBtnMinimal.Click += new System.EventHandler(this.funRadioBtnMinimal_Click);
            // 
            // funRadioBtnFrameNone
            // 
            this.funRadioBtnFrameNone.AutoSize = true;
            this.funRadioBtnFrameNone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funRadioBtnFrameNone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funRadioBtnFrameNone.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funRadioBtnFrameNone.Location = new System.Drawing.Point(146, 2);
            this.funRadioBtnFrameNone.Margin = new System.Windows.Forms.Padding(2);
            this.funRadioBtnFrameNone.Name = "funRadioBtnFrameNone";
            this.funRadioBtnFrameNone.Size = new System.Drawing.Size(140, 32);
            this.funRadioBtnFrameNone.TabIndex = 0;
            this.funRadioBtnFrameNone.TabStop = true;
            this.funRadioBtnFrameNone.Text = "None";
            this.funRadioBtnFrameNone.UseVisualStyleBackColor = true;
            this.funRadioBtnFrameNone.Click += new System.EventHandler(this.funRadioBtnFrameNone_Click);
            // 
            // tableLayoutPanel45
            // 
            this.tableLayoutPanel45.ColumnCount = 4;
            this.tableLayoutPanel45.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel45.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel45.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel45.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel45.Controls.Add(this.funRadioBtnVertical, 1, 0);
            this.tableLayoutPanel45.Controls.Add(this.funRadioBtnGridBtn, 2, 0);
            this.tableLayoutPanel45.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel45.Location = new System.Drawing.Point(3, 45);
            this.tableLayoutPanel45.Name = "tableLayoutPanel45";
            this.tableLayoutPanel45.RowCount = 1;
            this.tableLayoutPanel45.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel45.Size = new System.Drawing.Size(579, 36);
            this.tableLayoutPanel45.TabIndex = 6;
            // 
            // funRadioBtnVertical
            // 
            this.funRadioBtnVertical.AutoSize = true;
            this.funRadioBtnVertical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funRadioBtnVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funRadioBtnVertical.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funRadioBtnVertical.Location = new System.Drawing.Point(146, 2);
            this.funRadioBtnVertical.Margin = new System.Windows.Forms.Padding(2);
            this.funRadioBtnVertical.Name = "funRadioBtnVertical";
            this.funRadioBtnVertical.Size = new System.Drawing.Size(140, 32);
            this.funRadioBtnVertical.TabIndex = 0;
            this.funRadioBtnVertical.TabStop = true;
            this.funRadioBtnVertical.Text = "Vertical Strip";
            this.funRadioBtnVertical.UseVisualStyleBackColor = true;
            this.funRadioBtnVertical.Click += new System.EventHandler(this.funRadioBtnVertical_Click);
            // 
            // funRadioBtnGridBtn
            // 
            this.funRadioBtnGridBtn.AutoSize = true;
            this.funRadioBtnGridBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funRadioBtnGridBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funRadioBtnGridBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funRadioBtnGridBtn.Location = new System.Drawing.Point(290, 2);
            this.funRadioBtnGridBtn.Margin = new System.Windows.Forms.Padding(2);
            this.funRadioBtnGridBtn.Name = "funRadioBtnGridBtn";
            this.funRadioBtnGridBtn.Size = new System.Drawing.Size(140, 32);
            this.funRadioBtnGridBtn.TabIndex = 0;
            this.funRadioBtnGridBtn.TabStop = true;
            this.funRadioBtnGridBtn.Text = "Grid (2x2)";
            this.funRadioBtnGridBtn.UseVisualStyleBackColor = true;
            this.funRadioBtnGridBtn.Click += new System.EventHandler(this.funRadioBtnGridBtn_Click);
            // 
            // tableLayoutPanel141
            // 
            this.tableLayoutPanel141.ColumnCount = 2;
            this.tableLayoutPanel141.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel141.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel141.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel141.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel141.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel141.Location = new System.Drawing.Point(3, 264);
            this.tableLayoutPanel141.Name = "tableLayoutPanel141";
            this.tableLayoutPanel141.RowCount = 1;
            this.tableLayoutPanel141.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel141.Size = new System.Drawing.Size(579, 36);
            this.tableLayoutPanel141.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Image = global::Snap_and_Print.Properties.Resources.printer_line__1_;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(20, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(20, 3, 0, 3);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(60, 0, 50, 0);
            this.label6.Size = new System.Drawing.Size(269, 30);
            this.label6.TabIndex = 5;
            this.label6.Text = "Print Type";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel143
            // 
            this.tableLayoutPanel143.ColumnCount = 2;
            this.tableLayoutPanel143.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel143.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel143.Controls.Add(this.funNumericCopies, 1, 0);
            this.tableLayoutPanel143.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel143.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel143.Location = new System.Drawing.Point(3, 351);
            this.tableLayoutPanel143.Name = "tableLayoutPanel143";
            this.tableLayoutPanel143.RowCount = 1;
            this.tableLayoutPanel143.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel143.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel143.Size = new System.Drawing.Size(579, 41);
            this.tableLayoutPanel143.TabIndex = 12;
            // 
            // funNumericCopies
            // 
            this.funNumericCopies.BackColor = System.Drawing.Color.DarkGray;
            this.funNumericCopies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funNumericCopies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funNumericCopies.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funNumericCopies.Location = new System.Drawing.Point(292, 3);
            this.funNumericCopies.Margin = new System.Windows.Forms.Padding(3, 3, 120, 3);
            this.funNumericCopies.Name = "funNumericCopies";
            this.funNumericCopies.Size = new System.Drawing.Size(167, 39);
            this.funNumericCopies.TabIndex = 0;
            this.funNumericCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Image = global::Snap_and_Print.Properties.Resources.file_copy_2_line__1_;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(20, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(20, 3, 30, 3);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(120, 0, 0, 0);
            this.label7.Size = new System.Drawing.Size(239, 35);
            this.label7.TabIndex = 1;
            this.label7.Text = "Copies";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.Silver;
            this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel17.Controls.Add(this.tableLayoutPanel50);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(25, 582);
            this.panel17.Margin = new System.Windows.Forms.Padding(25, 5, 20, 5);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(587, 55);
            this.panel17.TabIndex = 1;
            // 
            // tableLayoutPanel50
            // 
            this.tableLayoutPanel50.ColumnCount = 2;
            this.tableLayoutPanel50.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel50.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel50.Controls.Add(this.tableLayoutPanel110, 0, 0);
            this.tableLayoutPanel50.Controls.Add(this.tableLayoutPanel65, 1, 0);
            this.tableLayoutPanel50.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel50.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel50.Name = "tableLayoutPanel50";
            this.tableLayoutPanel50.RowCount = 1;
            this.tableLayoutPanel50.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel50.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel50.Size = new System.Drawing.Size(585, 53);
            this.tableLayoutPanel50.TabIndex = 0;
            // 
            // tableLayoutPanel110
            // 
            this.tableLayoutPanel110.ColumnCount = 2;
            this.tableLayoutPanel110.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel110.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel110.Controls.Add(this.pictureBox14, 0, 0);
            this.tableLayoutPanel110.Controls.Add(this.label8, 1, 0);
            this.tableLayoutPanel110.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel110.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel110.Name = "tableLayoutPanel110";
            this.tableLayoutPanel110.RowCount = 1;
            this.tableLayoutPanel110.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel110.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel110.Size = new System.Drawing.Size(286, 47);
            this.tableLayoutPanel110.TabIndex = 1;
            // 
            // pictureBox14
            // 
            this.pictureBox14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox14.Image = global::Snap_and_Print.Properties.Resources.cash_line;
            this.pictureBox14.Location = new System.Drawing.Point(60, 3);
            this.pictureBox14.Margin = new System.Windows.Forms.Padding(60, 3, 0, 3);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pictureBox14.Size = new System.Drawing.Size(83, 41);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox14.TabIndex = 0;
            this.pictureBox14.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(146, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 47);
            this.label8.TabIndex = 1;
            this.label8.Text = "TOTAL :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel65
            // 
            this.tableLayoutPanel65.ColumnCount = 2;
            this.tableLayoutPanel65.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel65.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel65.Controls.Add(this.funTotal, 1, 0);
            this.tableLayoutPanel65.Controls.Add(this.pictureBox13, 0, 0);
            this.tableLayoutPanel65.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel65.Location = new System.Drawing.Point(295, 3);
            this.tableLayoutPanel65.Name = "tableLayoutPanel65";
            this.tableLayoutPanel65.RowCount = 1;
            this.tableLayoutPanel65.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel65.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel65.Size = new System.Drawing.Size(287, 47);
            this.tableLayoutPanel65.TabIndex = 2;
            // 
            // funTotal
            // 
            this.funTotal.AutoSize = true;
            this.funTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funTotal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funTotal.Location = new System.Drawing.Point(145, 0);
            this.funTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.funTotal.Name = "funTotal";
            this.funTotal.Size = new System.Drawing.Size(140, 47);
            this.funTotal.TabIndex = 0;
            this.funTotal.Text = "[0]";
            this.funTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox13
            // 
            this.pictureBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox13.Image = global::Snap_and_Print.Properties.Resources.peso;
            this.pictureBox13.Location = new System.Drawing.Point(60, 3);
            this.pictureBox13.Margin = new System.Windows.Forms.Padding(60, 3, 0, 3);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(83, 41);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox13.TabIndex = 0;
            this.pictureBox13.TabStop = false;
            // 
            // tableLayoutPanel54
            // 
            this.tableLayoutPanel54.ColumnCount = 3;
            this.tableLayoutPanel54.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel54.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel54.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel54.Controls.Add(this.tableLayoutPanel42, 0, 1);
            this.tableLayoutPanel54.Controls.Add(this.funSettingContinueBtn, 2, 1);
            this.tableLayoutPanel54.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel54.Location = new System.Drawing.Point(0, 642);
            this.tableLayoutPanel54.Name = "tableLayoutPanel54";
            this.tableLayoutPanel54.RowCount = 3;
            this.tableLayoutPanel54.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel54.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98F));
            this.tableLayoutPanel54.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel54.Size = new System.Drawing.Size(1456, 87);
            this.tableLayoutPanel54.TabIndex = 1;
            // 
            // tableLayoutPanel42
            // 
            this.tableLayoutPanel42.ColumnCount = 2;
            this.tableLayoutPanel42.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel42.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel42.Controls.Add(this.funSettingsCancelBtn, 0, 0);
            this.tableLayoutPanel42.Controls.Add(this.funSettingsBackBtn, 1, 0);
            this.tableLayoutPanel42.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel42.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel42.Name = "tableLayoutPanel42";
            this.tableLayoutPanel42.RowCount = 1;
            this.tableLayoutPanel42.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel42.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel42.Size = new System.Drawing.Size(479, 79);
            this.tableLayoutPanel42.TabIndex = 4;
            // 
            // funSettingsCancelBtn
            // 
            this.funSettingsCancelBtn.BackColor = System.Drawing.Color.DarkGray;
            this.funSettingsCancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funSettingsCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funSettingsCancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.funSettingsCancelBtn.FlatAppearance.BorderSize = 2;
            this.funSettingsCancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.funSettingsCancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.funSettingsCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.funSettingsCancelBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funSettingsCancelBtn.Image = global::Snap_and_Print.Properties.Resources.printCancel;
            this.funSettingsCancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.funSettingsCancelBtn.Location = new System.Drawing.Point(30, 10);
            this.funSettingsCancelBtn.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.funSettingsCancelBtn.Name = "funSettingsCancelBtn";
            this.funSettingsCancelBtn.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.funSettingsCancelBtn.Size = new System.Drawing.Size(179, 59);
            this.funSettingsCancelBtn.TabIndex = 1;
            this.funSettingsCancelBtn.Text = "CANCEL";
            this.funSettingsCancelBtn.UseVisualStyleBackColor = false;
            this.funSettingsCancelBtn.Click += new System.EventHandler(this.funSettingsCancelBtn_Click);
            // 
            // funSettingsBackBtn
            // 
            this.funSettingsBackBtn.BackColor = System.Drawing.Color.DarkGray;
            this.funSettingsBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funSettingsBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funSettingsBackBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.funSettingsBackBtn.FlatAppearance.BorderSize = 2;
            this.funSettingsBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.funSettingsBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.funSettingsBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.funSettingsBackBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funSettingsBackBtn.Image = global::Snap_and_Print.Properties.Resources.printBack;
            this.funSettingsBackBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.funSettingsBackBtn.Location = new System.Drawing.Point(269, 10);
            this.funSettingsBackBtn.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.funSettingsBackBtn.Name = "funSettingsBackBtn";
            this.funSettingsBackBtn.Padding = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.funSettingsBackBtn.Size = new System.Drawing.Size(180, 59);
            this.funSettingsBackBtn.TabIndex = 0;
            this.funSettingsBackBtn.Text = "BACK";
            this.funSettingsBackBtn.UseVisualStyleBackColor = false;
            this.funSettingsBackBtn.Click += new System.EventHandler(this.funSettingsBackBtn_Click);
            // 
            // funSettingContinueBtn
            // 
            this.funSettingContinueBtn.BackColor = System.Drawing.Color.DarkGray;
            this.funSettingContinueBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funSettingContinueBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funSettingContinueBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.funSettingContinueBtn.FlatAppearance.BorderSize = 2;
            this.funSettingContinueBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.funSettingContinueBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.funSettingContinueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.funSettingContinueBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funSettingContinueBtn.Image = global::Snap_and_Print.Properties.Resources.printContinue;
            this.funSettingContinueBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.funSettingContinueBtn.Location = new System.Drawing.Point(1110, 10);
            this.funSettingContinueBtn.Margin = new System.Windows.Forms.Padding(140, 10, 140, 10);
            this.funSettingContinueBtn.Name = "funSettingContinueBtn";
            this.funSettingContinueBtn.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.funSettingContinueBtn.Size = new System.Drawing.Size(206, 65);
            this.funSettingContinueBtn.TabIndex = 2;
            this.funSettingContinueBtn.Text = "CONTINUE";
            this.funSettingContinueBtn.UseVisualStyleBackColor = false;
            this.funSettingContinueBtn.Click += new System.EventHandler(this.funSettingsContinueBtn_Click);
            // 
            // funSoftCopyDownloadPanel
            // 
            this.funSoftCopyDownloadPanel.Controls.Add(this.panel11);
            this.funSoftCopyDownloadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funSoftCopyDownloadPanel.Location = new System.Drawing.Point(0, 0);
            this.funSoftCopyDownloadPanel.Name = "funSoftCopyDownloadPanel";
            this.funSoftCopyDownloadPanel.Size = new System.Drawing.Size(1456, 729);
            this.funSoftCopyDownloadPanel.TabIndex = 4;
            this.funSoftCopyDownloadPanel.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.tableLayoutPanel48);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1456, 729);
            this.panel11.TabIndex = 2;
            // 
            // tableLayoutPanel48
            // 
            this.tableLayoutPanel48.ColumnCount = 3;
            this.tableLayoutPanel48.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel48.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel48.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel48.Controls.Add(this.tableLayoutPanel44, 1, 3);
            this.tableLayoutPanel48.Controls.Add(this.qrSoftCopyDownloadFun, 1, 2);
            this.tableLayoutPanel48.Controls.Add(this.label24, 1, 1);
            this.tableLayoutPanel48.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel48.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel48.Name = "tableLayoutPanel48";
            this.tableLayoutPanel48.RowCount = 4;
            this.tableLayoutPanel48.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel48.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel48.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel48.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel48.Size = new System.Drawing.Size(1456, 729);
            this.tableLayoutPanel48.TabIndex = 2;
            // 
            // tableLayoutPanel44
            // 
            this.tableLayoutPanel44.ColumnCount = 2;
            this.tableLayoutPanel44.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel44.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel44.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel44.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel44.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel44.Controls.Add(this.funSoftCopyBackBtn, 0, 0);
            this.tableLayoutPanel44.Controls.Add(this.funSoftCopyCancelBtn, 1, 0);
            this.tableLayoutPanel44.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel44.Location = new System.Drawing.Point(367, 658);
            this.tableLayoutPanel44.Name = "tableLayoutPanel44";
            this.tableLayoutPanel44.RowCount = 1;
            this.tableLayoutPanel44.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel44.Size = new System.Drawing.Size(722, 68);
            this.tableLayoutPanel44.TabIndex = 1;
            // 
            // funSoftCopyBackBtn
            // 
            this.funSoftCopyBackBtn.BackColor = System.Drawing.Color.DarkGray;
            this.funSoftCopyBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funSoftCopyBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funSoftCopyBackBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.funSoftCopyBackBtn.FlatAppearance.BorderSize = 2;
            this.funSoftCopyBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.funSoftCopyBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.funSoftCopyBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.funSoftCopyBackBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funSoftCopyBackBtn.Image = global::Snap_and_Print.Properties.Resources.printBack;
            this.funSoftCopyBackBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.funSoftCopyBackBtn.Location = new System.Drawing.Point(120, 10);
            this.funSoftCopyBackBtn.Margin = new System.Windows.Forms.Padding(120, 10, 40, 10);
            this.funSoftCopyBackBtn.Name = "funSoftCopyBackBtn";
            this.funSoftCopyBackBtn.Padding = new System.Windows.Forms.Padding(40, 0, 20, 0);
            this.funSoftCopyBackBtn.Size = new System.Drawing.Size(201, 48);
            this.funSoftCopyBackBtn.TabIndex = 0;
            this.funSoftCopyBackBtn.Text = "BACK";
            this.funSoftCopyBackBtn.UseVisualStyleBackColor = false;
            this.funSoftCopyBackBtn.Click += new System.EventHandler(this.funSoftCopyBackBtn_Click);
            // 
            // funSoftCopyCancelBtn
            // 
            this.funSoftCopyCancelBtn.BackColor = System.Drawing.Color.DarkGray;
            this.funSoftCopyCancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.funSoftCopyCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funSoftCopyCancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.funSoftCopyCancelBtn.FlatAppearance.BorderSize = 2;
            this.funSoftCopyCancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.funSoftCopyCancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.funSoftCopyCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.funSoftCopyCancelBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funSoftCopyCancelBtn.Image = global::Snap_and_Print.Properties.Resources.printCancel;
            this.funSoftCopyCancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.funSoftCopyCancelBtn.Location = new System.Drawing.Point(401, 10);
            this.funSoftCopyCancelBtn.Margin = new System.Windows.Forms.Padding(40, 10, 120, 10);
            this.funSoftCopyCancelBtn.Name = "funSoftCopyCancelBtn";
            this.funSoftCopyCancelBtn.Padding = new System.Windows.Forms.Padding(20, 0, 10, 0);
            this.funSoftCopyCancelBtn.Size = new System.Drawing.Size(201, 48);
            this.funSoftCopyCancelBtn.TabIndex = 0;
            this.funSoftCopyCancelBtn.Text = "CANCEL";
            this.funSoftCopyCancelBtn.UseVisualStyleBackColor = false;
            this.funSoftCopyCancelBtn.Click += new System.EventHandler(this.funSoftCopyCancelBtn_Click);
            // 
            // qrSoftCopyDownloadFun
            // 
            this.qrSoftCopyDownloadFun.BackColor = System.Drawing.Color.Silver;
            this.qrSoftCopyDownloadFun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qrSoftCopyDownloadFun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrSoftCopyDownloadFun.Location = new System.Drawing.Point(444, 337);
            this.qrSoftCopyDownloadFun.Margin = new System.Windows.Forms.Padding(80, 10, 80, 10);
            this.qrSoftCopyDownloadFun.Name = "qrSoftCopyDownloadFun";
            this.qrSoftCopyDownloadFun.Size = new System.Drawing.Size(568, 308);
            this.qrSoftCopyDownloadFun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.qrSoftCopyDownloadFun.TabIndex = 0;
            this.qrSoftCopyDownloadFun.TabStop = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(367, 255);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(722, 72);
            this.label24.TabIndex = 2;
            this.label24.Text = "Softcopy Download";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // photoMode
            // 
            this.photoMode.Controls.Add(this.tableLayoutPanel22);
            this.photoMode.Controls.Add(this.tableLayoutPanel23);
            this.photoMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoMode.Location = new System.Drawing.Point(0, 0);
            this.photoMode.Name = "photoMode";
            this.photoMode.Size = new System.Drawing.Size(1456, 729);
            this.photoMode.TabIndex = 1;
            // 
            // tableLayoutPanel22
            // 
            this.tableLayoutPanel22.ColumnCount = 3;
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel22.Controls.Add(this.instructionLabelPhoto, 1, 0);
            this.tableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel22.Location = new System.Drawing.Point(0, 326);
            this.tableLayoutPanel22.Name = "tableLayoutPanel22";
            this.tableLayoutPanel22.RowCount = 1;
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel22.Size = new System.Drawing.Size(1456, 49);
            this.tableLayoutPanel22.TabIndex = 1;
            // 
            // instructionLabelPhoto
            // 
            this.instructionLabelPhoto.AutoSize = true;
            this.instructionLabelPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instructionLabelPhoto.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabelPhoto.ForeColor = System.Drawing.Color.DimGray;
            this.instructionLabelPhoto.Location = new System.Drawing.Point(367, 0);
            this.instructionLabelPhoto.Name = "instructionLabelPhoto";
            this.instructionLabelPhoto.Size = new System.Drawing.Size(722, 49);
            this.instructionLabelPhoto.TabIndex = 0;
            this.instructionLabelPhoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel23
            // 
            this.tableLayoutPanel23.ColumnCount = 4;
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel23.Controls.Add(this.photoBtnFun, 2, 0);
            this.tableLayoutPanel23.Controls.Add(this.photoBtnID, 1, 0);
            this.tableLayoutPanel23.Controls.Add(this.photoModeCancelBtn, 1, 2);
            this.tableLayoutPanel23.Controls.Add(this.photoBtnRetrieve, 2, 2);
            this.tableLayoutPanel23.Controls.Add(this.label42, 1, 1);
            this.tableLayoutPanel23.Controls.Add(this.label43, 2, 1);
            this.tableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel23.Location = new System.Drawing.Point(0, 375);
            this.tableLayoutPanel23.Name = "tableLayoutPanel23";
            this.tableLayoutPanel23.RowCount = 4;
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel23.Size = new System.Drawing.Size(1456, 354);
            this.tableLayoutPanel23.TabIndex = 0;
            // 
            // photoBtnFun
            // 
            this.photoBtnFun.BackgroundImage = global::Snap_and_Print.Properties.Resources.FunPhoto;
            this.photoBtnFun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.photoBtnFun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.photoBtnFun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBtnFun.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.photoBtnFun.FlatAppearance.BorderSize = 2;
            this.photoBtnFun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.photoBtnFun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.photoBtnFun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.photoBtnFun.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoBtnFun.Location = new System.Drawing.Point(807, 20);
            this.photoBtnFun.Margin = new System.Windows.Forms.Padding(80, 20, 80, 20);
            this.photoBtnFun.Name = "photoBtnFun";
            this.photoBtnFun.Size = new System.Drawing.Size(276, 172);
            this.photoBtnFun.TabIndex = 0;
            this.photoBtnFun.UseVisualStyleBackColor = true;
            this.photoBtnFun.Click += new System.EventHandler(this.funModeBtn_Click);
            this.photoBtnFun.MouseEnter += new System.EventHandler(this.photoBtnFun_MouseEnter);
            this.photoBtnFun.MouseLeave += new System.EventHandler(this.photoBtnFun_MouseLeave);
            // 
            // photoBtnID
            // 
            this.photoBtnID.BackgroundImage = global::Snap_and_Print.Properties.Resources.IDPhoto;
            this.photoBtnID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.photoBtnID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.photoBtnID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBtnID.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.photoBtnID.FlatAppearance.BorderSize = 2;
            this.photoBtnID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.photoBtnID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.photoBtnID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.photoBtnID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoBtnID.Location = new System.Drawing.Point(371, 20);
            this.photoBtnID.Margin = new System.Windows.Forms.Padding(80, 20, 80, 20);
            this.photoBtnID.Name = "photoBtnID";
            this.photoBtnID.Size = new System.Drawing.Size(276, 172);
            this.photoBtnID.TabIndex = 0;
            this.photoBtnID.UseVisualStyleBackColor = true;
            this.photoBtnID.Click += new System.EventHandler(this.idModeBtn_Click);
            this.photoBtnID.MouseEnter += new System.EventHandler(this.photoBtnID_MouseEnter);
            this.photoBtnID.MouseLeave += new System.EventHandler(this.photoBtnID_MouseLeave);
            // 
            // photoModeCancelBtn
            // 
            this.photoModeCancelBtn.BackColor = System.Drawing.Color.Silver;
            this.photoModeCancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.photoModeCancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoModeCancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.photoModeCancelBtn.FlatAppearance.BorderSize = 2;
            this.photoModeCancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.photoModeCancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.photoModeCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.photoModeCancelBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoModeCancelBtn.ForeColor = System.Drawing.Color.Black;
            this.photoModeCancelBtn.Image = global::Snap_and_Print.Properties.Resources.printCancel;
            this.photoModeCancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.photoModeCancelBtn.Location = new System.Drawing.Point(371, 275);
            this.photoModeCancelBtn.Margin = new System.Windows.Forms.Padding(80, 10, 80, 10);
            this.photoModeCancelBtn.Name = "photoModeCancelBtn";
            this.photoModeCancelBtn.Padding = new System.Windows.Forms.Padding(60, 0, 30, 0);
            this.photoModeCancelBtn.Size = new System.Drawing.Size(276, 50);
            this.photoModeCancelBtn.TabIndex = 1;
            this.photoModeCancelBtn.Text = "CANCEL";
            this.photoModeCancelBtn.UseVisualStyleBackColor = false;
            this.photoModeCancelBtn.Click += new System.EventHandler(this.photoModeCancelBtn_Click);
            this.photoModeCancelBtn.MouseEnter += new System.EventHandler(this.photoModeCancelBtn_MouseEnter);
            this.photoModeCancelBtn.MouseLeave += new System.EventHandler(this.photoModeCancelBtn_MouseLeave);
            // 
            // photoBtnRetrieve
            // 
            this.photoBtnRetrieve.BackColor = System.Drawing.Color.Silver;
            this.photoBtnRetrieve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.photoBtnRetrieve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoBtnRetrieve.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.photoBtnRetrieve.FlatAppearance.BorderSize = 2;
            this.photoBtnRetrieve.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.photoBtnRetrieve.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.photoBtnRetrieve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.photoBtnRetrieve.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoBtnRetrieve.ForeColor = System.Drawing.Color.Black;
            this.photoBtnRetrieve.Image = global::Snap_and_Print.Properties.Resources.folder_history_fill;
            this.photoBtnRetrieve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.photoBtnRetrieve.Location = new System.Drawing.Point(807, 275);
            this.photoBtnRetrieve.Margin = new System.Windows.Forms.Padding(80, 10, 80, 10);
            this.photoBtnRetrieve.Name = "photoBtnRetrieve";
            this.photoBtnRetrieve.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.photoBtnRetrieve.Size = new System.Drawing.Size(276, 50);
            this.photoBtnRetrieve.TabIndex = 0;
            this.photoBtnRetrieve.Text = "RETRIEVE PHOTO";
            this.photoBtnRetrieve.UseVisualStyleBackColor = false;
            this.photoBtnRetrieve.Click += new System.EventHandler(this.photoBtnRetrieve_Click);
            this.photoBtnRetrieve.MouseEnter += new System.EventHandler(this.photoBtnRetrieve_MouseEnter);
            this.photoBtnRetrieve.MouseLeave += new System.EventHandler(this.photoBtnRetrieve_MouseLeave);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Dock = System.Windows.Forms.DockStyle.Top;
            this.label42.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.Color.DimGray;
            this.label42.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label42.Location = new System.Drawing.Point(294, 212);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(430, 32);
            this.label42.TabIndex = 2;
            this.label42.Text = "ID Printing";
            this.label42.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Dock = System.Windows.Forms.DockStyle.Top;
            this.label43.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.DimGray;
            this.label43.Location = new System.Drawing.Point(730, 212);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(430, 32);
            this.label43.TabIndex = 3;
            this.label43.Text = "Photobooth Printing";
            this.label43.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // retrievalPanelPhoto
            // 
            this.retrievalPanelPhoto.Controls.Add(this.PhotoRetrievePanel);
            this.retrievalPanelPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.retrievalPanelPhoto.Location = new System.Drawing.Point(0, 0);
            this.retrievalPanelPhoto.Name = "retrievalPanelPhoto";
            this.retrievalPanelPhoto.Size = new System.Drawing.Size(1456, 729);
            this.retrievalPanelPhoto.TabIndex = 2;
            // 
            // PhotoRetrievePanel
            // 
            this.PhotoRetrievePanel.Controls.Add(this.tableLayoutPanel75);
            this.PhotoRetrievePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PhotoRetrievePanel.Location = new System.Drawing.Point(0, 0);
            this.PhotoRetrievePanel.Margin = new System.Windows.Forms.Padding(2);
            this.PhotoRetrievePanel.Name = "PhotoRetrievePanel";
            this.PhotoRetrievePanel.Size = new System.Drawing.Size(1456, 729);
            this.PhotoRetrievePanel.TabIndex = 2;
            this.PhotoRetrievePanel.Visible = false;
            // 
            // tableLayoutPanel75
            // 
            this.tableLayoutPanel75.ColumnCount = 3;
            this.tableLayoutPanel75.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.69052F));
            this.tableLayoutPanel75.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.61897F));
            this.tableLayoutPanel75.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.69051F));
            this.tableLayoutPanel75.Controls.Add(this.label26, 1, 0);
            this.tableLayoutPanel75.Controls.Add(this.tableLayoutPanel76, 1, 3);
            this.tableLayoutPanel75.Controls.Add(this.photoRetrievalCodeBox, 1, 1);
            this.tableLayoutPanel75.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel75.Location = new System.Drawing.Point(0, 276);
            this.tableLayoutPanel75.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel75.Name = "tableLayoutPanel75";
            this.tableLayoutPanel75.RowCount = 4;
            this.tableLayoutPanel75.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.97805F));
            this.tableLayoutPanel75.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.97804F));
            this.tableLayoutPanel75.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.535451F));
            this.tableLayoutPanel75.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.50846F));
            this.tableLayoutPanel75.Size = new System.Drawing.Size(1456, 453);
            this.tableLayoutPanel75.TabIndex = 4;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label26.Font = new System.Drawing.Font("Segoe UI Black", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(186, 50);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 50, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(1082, 67);
            this.label26.TabIndex = 1;
            this.label26.Text = "ENTER RETRIEVAL CODE";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel76
            // 
            this.tableLayoutPanel76.ColumnCount = 2;
            this.tableLayoutPanel76.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel76.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel76.Controls.Add(this.photoCancelRetrievalBtn, 0, 0);
            this.tableLayoutPanel76.Controls.Add(this.photoRetrievalBtn, 1, 0);
            this.tableLayoutPanel76.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel76.Location = new System.Drawing.Point(187, 266);
            this.tableLayoutPanel76.Name = "tableLayoutPanel76";
            this.tableLayoutPanel76.RowCount = 1;
            this.tableLayoutPanel76.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel76.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanel76.Size = new System.Drawing.Size(1080, 184);
            this.tableLayoutPanel76.TabIndex = 4;
            // 
            // photoCancelRetrievalBtn
            // 
            this.photoCancelRetrievalBtn.BackColor = System.Drawing.Color.Silver;
            this.photoCancelRetrievalBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.photoCancelRetrievalBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoCancelRetrievalBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.photoCancelRetrievalBtn.FlatAppearance.BorderSize = 2;
            this.photoCancelRetrievalBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.photoCancelRetrievalBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.photoCancelRetrievalBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.photoCancelRetrievalBtn.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoCancelRetrievalBtn.ForeColor = System.Drawing.Color.Black;
            this.photoCancelRetrievalBtn.Image = global::Snap_and_Print.Properties.Resources.printCancel;
            this.photoCancelRetrievalBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.photoCancelRetrievalBtn.Location = new System.Drawing.Point(200, 10);
            this.photoCancelRetrievalBtn.Margin = new System.Windows.Forms.Padding(200, 10, 50, 100);
            this.photoCancelRetrievalBtn.Name = "photoCancelRetrievalBtn";
            this.photoCancelRetrievalBtn.Padding = new System.Windows.Forms.Padding(50, 0, 30, 0);
            this.photoCancelRetrievalBtn.Size = new System.Drawing.Size(290, 74);
            this.photoCancelRetrievalBtn.TabIndex = 3;
            this.photoCancelRetrievalBtn.Text = "CANCEL";
            this.photoCancelRetrievalBtn.UseVisualStyleBackColor = false;
            this.photoCancelRetrievalBtn.Click += new System.EventHandler(this.photoCancelRetrievalBtn_Click);
            // 
            // photoRetrievalBtn
            // 
            this.photoRetrievalBtn.BackColor = System.Drawing.Color.Silver;
            this.photoRetrievalBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.photoRetrievalBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoRetrievalBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.photoRetrievalBtn.FlatAppearance.BorderSize = 2;
            this.photoRetrievalBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.photoRetrievalBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.photoRetrievalBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.photoRetrievalBtn.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoRetrievalBtn.ForeColor = System.Drawing.Color.Black;
            this.photoRetrievalBtn.Image = global::Snap_and_Print.Properties.Resources.folder_received_fill;
            this.photoRetrievalBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.photoRetrievalBtn.Location = new System.Drawing.Point(590, 10);
            this.photoRetrievalBtn.Margin = new System.Windows.Forms.Padding(50, 10, 200, 100);
            this.photoRetrievalBtn.Name = "photoRetrievalBtn";
            this.photoRetrievalBtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.photoRetrievalBtn.Size = new System.Drawing.Size(290, 74);
            this.photoRetrievalBtn.TabIndex = 2;
            this.photoRetrievalBtn.Text = "RETRIEVE FILE";
            this.photoRetrievalBtn.UseVisualStyleBackColor = false;
            this.photoRetrievalBtn.Click += new System.EventHandler(this.photoRetrievalBtn_Click);
            // 
            // photoRetrievalCodeBox
            // 
            this.photoRetrievalCodeBox.BackColor = System.Drawing.Color.Silver;
            this.photoRetrievalCodeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.photoRetrievalCodeBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.photoRetrievalCodeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoRetrievalCodeBox.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.photoRetrievalCodeBox.ForeColor = System.Drawing.Color.Black;
            this.photoRetrievalCodeBox.Location = new System.Drawing.Point(484, 137);
            this.photoRetrievalCodeBox.Margin = new System.Windows.Forms.Padding(300, 20, 300, 2);
            this.photoRetrievalCodeBox.Name = "photoRetrievalCodeBox";
            this.photoRetrievalCodeBox.Size = new System.Drawing.Size(486, 71);
            this.photoRetrievalCodeBox.TabIndex = 0;
            this.photoRetrievalCodeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PrintAndSnap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 729);
            this.Controls.Add(this.printPanel);
            this.Controls.Add(this.printingOptionsPanel);
            this.Controls.Add(this.photoPanel);
            this.Controls.Add(this.startPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PrintAndSnap";
            this.Text = "Printer Vendo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Print_And_Snap_Load);
            this.startPanel.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.tableLayoutPanel73.ResumeLayout(false);
            this.tableLayoutPanel73.PerformLayout();
            this.tableLayoutPanel67.ResumeLayout(false);
            this.printingOptionsPanel.ResumeLayout(false);
            this.tableLayoutPanel74.ResumeLayout(false);
            this.tableLayoutPanel74.PerformLayout();
            this.MainPrintingPanel.ResumeLayout(false);
            this.MainPrintingPanel.PerformLayout();
            this.printPanel.ResumeLayout(false);
            this.printingSettingsPanel.ResumeLayout(false);
            this.paymentPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPayment.ResumeLayout(false);
            this.tableLayoutPanel104.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.tableLayoutPanel105.ResumeLayout(false);
            this.tableLayoutPanel105.PerformLayout();
            this.tableLayoutPanel106.ResumeLayout(false);
            this.tableLayoutPanel106.PerformLayout();
            this.tableLayoutPanel107.ResumeLayout(false);
            this.tableLayoutPanel107.PerformLayout();
            this.tableLayoutPanel140.ResumeLayout(false);
            this.tableLayoutPanel140.PerformLayout();
            this.uploadPanel.ResumeLayout(false);
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qrPictureBox)).EndInit();
            this.uploadMainLayout.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.settingsPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericSinglePage)).EndInit();
            this.tableLayoutPanel81.ResumeLayout(false);
            this.tableLayoutPanel81.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericCopies)).EndInit();
            this.tableLayoutPanel80.ResumeLayout(false);
            this.tableLayoutPanel80.PerformLayout();
            this.tableLayoutPanel86.ResumeLayout(false);
            this.tableLayoutPanel86.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel87.ResumeLayout(false);
            this.tableLayoutPanel87.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tableLayoutPanel85.ResumeLayout(false);
            this.tableLayoutPanel85.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel88.ResumeLayout(false);
            this.tableLayoutPanel88.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.tableLayoutPanel20.ResumeLayout(false);
            this.tableLayoutPanel21.ResumeLayout(false);
            this.tableLayoutPanel21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel24.ResumeLayout(false);
            this.tableLayoutPanel24.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tableLayoutPanel89.ResumeLayout(false);
            this.tableLayoutPanel89.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.tableLayoutPanel16.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.tableLayoutPanel92.ResumeLayout(false);
            this.tableLayoutPanel83.ResumeLayout(false);
            this.tableLayoutPanel82.ResumeLayout(false);
            this.tableLayoutPanel82.PerformLayout();
            this.tableLayoutPanel84.ResumeLayout(false);
            this.tableLayoutPanel84.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel77.ResumeLayout(false);
            this.retrivalPanel.ResumeLayout(false);
            this.retrivalMain.ResumeLayout(false);
            this.retrivalMain.PerformLayout();
            this.tableLayoutPanel97.ResumeLayout(false);
            this.continuePanel.ResumeLayout(false);
            this.photoPanel.ResumeLayout(false);
            this.photoIDPanel.ResumeLayout(false);
            this.IDpayment.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel51.ResumeLayout(false);
            this.tableLayoutPanel47.ResumeLayout(false);
            this.tableLayoutPanel53.ResumeLayout(false);
            this.tableLayoutPanel125.ResumeLayout(false);
            this.tableLayoutPanel52.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.tableLayoutPanel126.ResumeLayout(false);
            this.tableLayoutPanel126.PerformLayout();
            this.tableLayoutPanel123.ResumeLayout(false);
            this.tableLayoutPanel123.PerformLayout();
            this.tableLayoutPanel113.ResumeLayout(false);
            this.tableLayoutPanel113.PerformLayout();
            this.tableLayoutPanel124.ResumeLayout(false);
            this.tableLayoutPanel124.PerformLayout();
            this.tableLayoutPanel132.ResumeLayout(false);
            this.tableLayoutPanel132.PerformLayout();
            this.panelCRMidPrinting.ResumeLayout(false);
            this.tableLayoutPanel27.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.tableLayoutPanel28.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idCameraFeed)).EndInit();
            this.tableLayoutPanel25.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idPreviewPictureBox1)).EndInit();
            this.tableLayoutPanel26.ResumeLayout(false);
            this.idPrintingSettings.ResumeLayout(false);
            this.IDsettings.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.tableLayoutPanel36.ResumeLayout(false);
            this.tableLayoutPanel37.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idPrintPreviewMini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsPicturePreview)).EndInit();
            this.panel21.ResumeLayout(false);
            this.tableLayoutPanel33.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idSettingsSelectPicture1)).EndInit();
            this.tableLayoutPanel15.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel35.ResumeLayout(false);
            this.tableLayoutPanel70.ResumeLayout(false);
            this.tableLayoutPanel70.PerformLayout();
            this.tableLayoutPanel133.ResumeLayout(false);
            this.tableLayoutPanel133.PerformLayout();
            this.tableLayoutPanel134.ResumeLayout(false);
            this.tableLayoutPanel134.PerformLayout();
            this.tableLayoutPanel135.ResumeLayout(false);
            this.tableLayoutPanel135.PerformLayout();
            this.tableLayoutPanel136.ResumeLayout(false);
            this.tableLayoutPanel136.PerformLayout();
            this.tableLayoutPanel137.ResumeLayout(false);
            this.tableLayoutPanel137.PerformLayout();
            this.tableLayoutPanel139.ResumeLayout(false);
            this.tableLayoutPanel139.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericIdPrintingCopies)).EndInit();
            this.panel7.ResumeLayout(false);
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tableLayoutPanel34.ResumeLayout(false);
            this.tableLayoutPanel40.ResumeLayout(false);
            this.softCopyDownloadId.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.tableLayoutPanel39.ResumeLayout(false);
            this.tableLayoutPanel39.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qrIdPrintingDownload)).EndInit();
            this.photoBoothPanel.ResumeLayout(false);
            this.funPaymentPanel.ResumeLayout(false);
            this.tableLayoutPanel111.ResumeLayout(false);
            this.tableLayoutPanel72.ResumeLayout(false);
            this.tableLayoutPanel114.ResumeLayout(false);
            this.tableLayoutPanel71.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.tableLayoutPanel115.ResumeLayout(false);
            this.tableLayoutPanel115.PerformLayout();
            this.tableLayoutPanel69.ResumeLayout(false);
            this.tableLayoutPanel69.PerformLayout();
            this.tableLayoutPanel68.ResumeLayout(false);
            this.tableLayoutPanel68.PerformLayout();
            this.tableLayoutPanel121.ResumeLayout(false);
            this.tableLayoutPanel121.PerformLayout();
            this.tableLayoutPanel122.ResumeLayout(false);
            this.tableLayoutPanel122.PerformLayout();
            this.panelCMRphotoBooth.ResumeLayout(false);
            this.tableLayoutPanel31.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.funCameraFeed)).EndInit();
            this.tableLayoutPanel29.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.funPreview4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funPreview3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funPreview2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funPreview1)).EndInit();
            this.tableLayoutPanel30.ResumeLayout(false);
            this.photoBoothSettings.ResumeLayout(false);
            this.funSettings.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.tableLayoutPanel58.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.tableLayoutPanel59.ResumeLayout(false);
            this.tableLayoutPanel60.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.funMiniPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funMainPreview)).EndInit();
            this.panel18.ResumeLayout(false);
            this.tableLayoutPanel112.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.funSelectPic4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funSelectPic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funSelectPic3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funSelectPic2)).EndInit();
            this.tableLayoutPanel56.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.tableLayoutPanel66.ResumeLayout(false);
            this.tableLayoutPanel43.ResumeLayout(false);
            this.tableLayoutPanel43.PerformLayout();
            this.tableLayoutPanel63.ResumeLayout(false);
            this.tableLayoutPanel63.PerformLayout();
            this.tableLayoutPanel138.ResumeLayout(false);
            this.tableLayoutPanel138.PerformLayout();
            this.tableLayoutPanel78.ResumeLayout(false);
            this.tableLayoutPanel78.PerformLayout();
            this.tableLayoutPanel109.ResumeLayout(false);
            this.tableLayoutPanel109.PerformLayout();
            this.tableLayoutPanel49.ResumeLayout(false);
            this.tableLayoutPanel49.PerformLayout();
            this.tableLayoutPanel45.ResumeLayout(false);
            this.tableLayoutPanel45.PerformLayout();
            this.tableLayoutPanel141.ResumeLayout(false);
            this.tableLayoutPanel141.PerformLayout();
            this.tableLayoutPanel143.ResumeLayout(false);
            this.tableLayoutPanel143.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.funNumericCopies)).EndInit();
            this.panel17.ResumeLayout(false);
            this.tableLayoutPanel50.ResumeLayout(false);
            this.tableLayoutPanel110.ResumeLayout(false);
            this.tableLayoutPanel110.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.tableLayoutPanel65.ResumeLayout(false);
            this.tableLayoutPanel65.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            this.tableLayoutPanel54.ResumeLayout(false);
            this.tableLayoutPanel42.ResumeLayout(false);
            this.funSoftCopyDownloadPanel.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.tableLayoutPanel48.ResumeLayout(false);
            this.tableLayoutPanel48.PerformLayout();
            this.tableLayoutPanel44.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qrSoftCopyDownloadFun)).EndInit();
            this.photoMode.ResumeLayout(false);
            this.tableLayoutPanel22.ResumeLayout(false);
            this.tableLayoutPanel22.PerformLayout();
            this.tableLayoutPanel23.ResumeLayout(false);
            this.tableLayoutPanel23.PerformLayout();
            this.retrievalPanelPhoto.ResumeLayout(false);
            this.PhotoRetrievePanel.ResumeLayout(false);
            this.tableLayoutPanel75.ResumeLayout(false);
            this.tableLayoutPanel75.PerformLayout();
            this.tableLayoutPanel76.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel startPanel;
        private System.Windows.Forms.Panel uploadPanel;
        private System.Windows.Forms.Panel printingSettingsPanel;
        private System.Windows.Forms.TableLayoutPanel continuePanel;
        private System.Windows.Forms.Button continueBtn;
        private System.Windows.Forms.Timer receiveTimer;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Panel paymentPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button continuePaymentBtn;
        private System.Windows.Forms.Button settingsBackBtn;
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
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.PictureBox qrPictureBox;
        private System.Windows.Forms.Panel retrivalPanel;
        private System.Windows.Forms.TableLayoutPanel retrivalMain;
        private System.Windows.Forms.Label retrivalCodeLabel;
        private System.Windows.Forms.Button loadRetrievalBtn;
        private System.Windows.Forms.Button retrieveCancelBtn;
        private System.Windows.Forms.Label printerStatusLabel;
        private System.Windows.Forms.Button printSettingsCancelBtn;
        private System.Windows.Forms.Button uploadCancelBtn;
        private System.Windows.Forms.Panel printingOptionsPanel;
        private System.Windows.Forms.TableLayoutPanel MainPrintingPanel;
        private System.Windows.Forms.Panel printPanel;
        private System.Windows.Forms.Panel photoPanel;
        private System.Windows.Forms.Button retrievalBtn;
        private System.Windows.Forms.TextBox retrivalCodeTextBox;
        private System.Windows.Forms.Label printerStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.TableLayoutPanel uploadMainLayout;
        private System.Windows.Forms.Button photoModeCancelBtn;
        private System.Windows.Forms.Panel photoIDPanel;
        private System.Windows.Forms.Panel photoBoothPanel;
        private System.Windows.Forms.Panel photoMode;
        private System.Windows.Forms.Button idPrintingCancelBtn;
        private System.Windows.Forms.Button idCapctureAgainBtn;
        private System.Windows.Forms.Button idPrintingContinueBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel27;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel31;
        private System.Windows.Forms.Button funCaptureAgainBtn;
        private System.Windows.Forms.Button funContinueBtn;
        private System.Windows.Forms.Button funCancelBtn;
        private System.Windows.Forms.Panel panelCRMidPrinting;
        private System.Windows.Forms.Panel panelCMRphotoBooth;
        private System.Windows.Forms.Panel idPrintingSettings;
        private System.Windows.Forms.Panel IDsettings;
        private System.Windows.Forms.Panel photoBoothSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel34;
        private System.Windows.Forms.Label idPrintingCopies;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericIdPrintingCopies;
        private System.Windows.Forms.RadioButton radioBtn2x2;
        private System.Windows.Forms.RadioButton radioBtn1x1;
        private System.Windows.Forms.RadioButton radioBtn2x1;
        private System.Windows.Forms.RadioButton radioBtnSinglePhotoCopies;
        private System.Windows.Forms.RadioButton radioBtnMultipleCopies;
        private System.Windows.Forms.RadioButton radioBtnPhotoBlack;
        private System.Windows.Forms.RadioButton radioBtnPhotoColored;
        private System.Windows.Forms.Label idPrintingTotal;
        private System.Windows.Forms.Button idPrintSettingsCancelBtn;
        private System.Windows.Forms.Button idPrintSettingsBackBtn;
        private System.Windows.Forms.Button idPrintSettingsConintueBtn;
        private System.Windows.Forms.Panel IDpayment;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel47;
        private System.Windows.Forms.Button cancelBtnPaymentId;
        private System.Windows.Forms.Button backBtnPaymentId;
        private System.Windows.Forms.Button printBtnPaymentId;
        private System.Windows.Forms.Panel funPaymentPanel;
        private System.Windows.Forms.Panel funSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel54;
        private System.Windows.Forms.Button funSettingsBackBtn;
        private System.Windows.Forms.Button funSettingsCancelBtn;
        private System.Windows.Forms.Button funSettingContinueBtn;
        private System.Windows.Forms.NumericUpDown funNumericCopies;
        private System.Windows.Forms.Label funTotal;
        private System.Windows.Forms.RadioButton funRadioBtnVertical;
        private System.Windows.Forms.RadioButton funRadioBtnGridBtn;
        private System.Windows.Forms.RadioButton funRadioBtnFrameNone;
        private System.Windows.Forms.RadioButton funRadioBtnMinimal;
        private System.Windows.Forms.RadioButton funRadioBtnCute;
        private System.Windows.Forms.RadioButton funRadioBtnFilterNone;
        private System.Windows.Forms.RadioButton funRadioBtnBlack;
        private System.Windows.Forms.RadioButton funRadioBtnWarm;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button paymentFunCancelBtn;
        private System.Windows.Forms.Button paymentFunBackBtn;
        private System.Windows.Forms.Button paymentFunPrintBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel72;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label paymentFunTotal;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label paymentFunBalance;
        private System.Windows.Forms.PictureBox qrSoftCopyDownloadFun;
        private System.Windows.Forms.Panel retrievalPanelPhoto;
        private System.Windows.Forms.Panel PhotoRetrievePanel;
        private System.Windows.Forms.Button photoRetrievalBtn;
        private System.Windows.Forms.Button photoCancelRetrievalBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel75;
        private System.Windows.Forms.TextBox photoRetrievalCodeBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.RadioButton radioSinglePage;
        private System.Windows.Forms.RadioButton radioPrintRange;
        private System.Windows.Forms.RadioButton radioPrintAll;
        private System.Windows.Forms.PictureBox idPreviewPictureBox1;
        private System.Windows.Forms.PictureBox idCameraFeed;
        private System.Windows.Forms.Button idCaptureBtn;
        private System.Windows.Forms.PictureBox idPreviewPictureBox2;
        private System.Windows.Forms.PictureBox idPreviewPictureBox3;
        private System.Windows.Forms.PictureBox idPreviewPictureBox4;
        private System.Windows.Forms.PictureBox idSettingsPicturePreview;
        private System.Windows.Forms.PictureBox idSettingsSelectPicture1;
        private System.Windows.Forms.PictureBox idSettingsSelectPicture2;
        private System.Windows.Forms.PictureBox idSettingsSelectPicture3;
        private System.Windows.Forms.PictureBox idSettingsSelectPicture4;
        private System.Windows.Forms.PictureBox idPrintPreviewMini;
        private System.Windows.Forms.Panel softCopyDownloadId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel53;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label paymentIDTotal;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label paymentIDBalance;
        private System.Windows.Forms.Button downloadBtnPaymentId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel39;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.PictureBox qrIdPrintingDownload;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel funSoftCopyDownloadPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel44;
        private System.Windows.Forms.Button funSoftCopyCancelBtn;
        private System.Windows.Forms.Button funSoftCopyBackBtn;
        private System.Windows.Forms.PictureBox funMainPreview;
        private System.Windows.Forms.PictureBox funSelectPic4;
        private System.Windows.Forms.PictureBox funSelectPic3;
        private System.Windows.Forms.PictureBox funSelectPic2;
        private System.Windows.Forms.PictureBox funSelectPic1;
        private System.Windows.Forms.PictureBox funPreview1;
        private System.Windows.Forms.PictureBox funPreview2;
        private System.Windows.Forms.PictureBox funPreview3;
        private System.Windows.Forms.PictureBox funPreview4;
        private System.Windows.Forms.PictureBox funCameraFeed;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button funCaptureBtn;
        private System.Windows.Forms.Button funDownloadBtn;
        private System.Windows.Forms.Label idprintingStatusLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel56;
        private System.Windows.Forms.RadioButton funRadioPrintTypeAll;
        private System.Windows.Forms.RadioButton funRadioPrintTypeSingle;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel67;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel64;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel73;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button photoPrintingBtn;
        private System.Windows.Forms.Button docPrintingBtn;
        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel74;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel23;
        private System.Windows.Forms.Button photoBtnFun;
        private System.Windows.Forms.Button photoBtnID;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel22;
        private System.Windows.Forms.Label instructionLabelPhoto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Label fileUploadStatusLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.Label instructionLabelDocs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel24;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel20;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel21;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel80;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel81;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel82;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel83;
        private System.Windows.Forms.Panel previewPanelSettingLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel84;
        private System.Windows.Forms.Label pagesPreviewLabel;
        private System.Windows.Forms.Label filesizepreview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel85;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel87;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel86;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel88;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel89;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel90;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel91;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel93;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel94;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel95;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel96;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel92;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel97;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label paymentDocBalance;
        private System.Windows.Forms.Label paymentDocTotal;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Button photoBtnRetrieve;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel76;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel29;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel30;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel79;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel26;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel25;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel28;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel32;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel66;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel50;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel110;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel65;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel58;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel59;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel60;
        private System.Windows.Forms.PictureBox funMiniPreview;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel112;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel68;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel111;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel69;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel71;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label funPrintingStatusLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel114;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel115;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel116;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel117;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel118;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel119;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel120;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel121;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel122;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label paymentFunInserted;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label paymentFunChange;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel51;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel52;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel113;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel123;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel125;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel126;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel128;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel129;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel130;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel131;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel127;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel124;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel132;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label paymentInsertedID;
        private System.Windows.Forms.Label paymentChangeID;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel48;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button downloadBackBtn;
        private System.Windows.Forms.Button downloadCancelBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel33;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel35;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel38;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel41;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel46;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel70;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel133;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel134;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel135;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel136;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel137;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel139;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel36;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel37;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel40;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel43;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel45;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel49;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel138;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel55;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel62;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel61;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel57;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel63;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel78;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel109;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel141;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel143;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel42;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel77;
        private System.Windows.Forms.Label printingStatusLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPayment;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button paymentBackBtn;
        private System.Windows.Forms.Button cancelPrintBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel104;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel98;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel100;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel103;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel102;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel101;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel105;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel106;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel107;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel140;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label totalDocInserted;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label totalDocChange;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button startBtn;
    }
}