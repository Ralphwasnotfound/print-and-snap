using InTheHand.Net;
using InTheHand.Net.Sockets;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Printer_Vendo
{
    partial class PrinterPhotoVendo
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
            this.buttonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.qrPictureBox = new System.Windows.Forms.PictureBox();
            this.buttonLayoutLeft = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLayoutRight = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLayoutBottom = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLayoutTop = new System.Windows.Forms.TableLayoutPanel();
            this.instructions = new System.Windows.Forms.TableLayoutPanel();
            this.howToUpload = new System.Windows.Forms.Label();
            this.instruction1 = new System.Windows.Forms.Label();
            this.instruction2 = new System.Windows.Forms.Label();
            this.instruction3 = new System.Windows.Forms.Label();
            this.instructionTitle = new System.Windows.Forms.TableLayoutPanel();
            this.uploadFile = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.continuePanel = new System.Windows.Forms.TableLayoutPanel();
            this.continueBtn = new System.Windows.Forms.Button();
            this.uploadLeft = new System.Windows.Forms.TableLayoutPanel();
            this.uploadRight = new System.Windows.Forms.TableLayoutPanel();
            this.uploadBottom = new System.Windows.Forms.TableLayoutPanel();
            this.uploadTop = new System.Windows.Forms.TableLayoutPanel();
            this.printingSettingsPanel = new System.Windows.Forms.Panel();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.continuePaymentBtn = new System.Windows.Forms.Button();
            this.settingsBackBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.numericCopies = new System.Windows.Forms.NumericUpDown();
            this.copiesLabel = new System.Windows.Forms.Label();
            this.selectPageLabel = new System.Windows.Forms.Label();
            this.totalPagesLabelLabel = new System.Windows.Forms.Label();
            this.totalPagesLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.radioPrintRange = new System.Windows.Forms.RadioButton();
            this.radioSinglePage = new System.Windows.Forms.RadioButton();
            this.radioPrintAll = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.numericSinglePage = new System.Windows.Forms.NumericUpDown();
            this.numericPageRange = new System.Windows.Forms.TextBox();
            this.totalLabelLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.paperColor = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBlackWhite = new System.Windows.Forms.RadioButton();
            this.radioColored = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.editBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.labelPreview = new System.Windows.Forms.Label();
            this.paymentPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPayment = new System.Windows.Forms.TableLayoutPanel();
            this.balancePaymentLabel = new System.Windows.Forms.Label();
            this.paymentTotalLabel = new System.Windows.Forms.Label();
            this.cancelPrintBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.totalPayment = new System.Windows.Forms.Label();
            this.paymentBalance = new System.Windows.Forms.Label();
            this.paymentTableTitle = new System.Windows.Forms.TableLayoutPanel();
            this.paymentTitle = new System.Windows.Forms.Label();
            this.paymentRight = new System.Windows.Forms.TableLayoutPanel();
            this.paymentLeft = new System.Windows.Forms.TableLayoutPanel();
            this.paymentBottom = new System.Windows.Forms.TableLayoutPanel();
            this.paymentTop = new System.Windows.Forms.TableLayoutPanel();
            this.settingsTop = new System.Windows.Forms.TableLayoutPanel();
            this.startPanel.SuspendLayout();
            this.startText.SuspendLayout();
            this.startButtonLayout.SuspendLayout();
            this.startTitle.SuspendLayout();
            this.uploadPanel.SuspendLayout();
            this.uploadInstructionPanel.SuspendLayout();
            this.buttonLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrPictureBox)).BeginInit();
            this.instructions.SuspendLayout();
            this.instructionTitle.SuspendLayout();
            this.uploadQrPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.qrInstructions.SuspendLayout();
            this.qrTitleLayout.SuspendLayout();
            this.continuePanel.SuspendLayout();
            this.printingSettingsPanel.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCopies)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSinglePage)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.paymentPanel.SuspendLayout();
            this.tableLayoutPayment.SuspendLayout();
            this.paymentTableTitle.SuspendLayout();
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
            this.startPanel.Name = "startPanel";
            this.startPanel.Size = new System.Drawing.Size(1844, 842);
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
            this.startText.Location = new System.Drawing.Point(200, 282);
            this.startText.Name = "startText";
            this.startText.RowCount = 3;
            this.startText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.startText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.startText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.startText.Size = new System.Drawing.Size(1444, 336);
            this.startText.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Roboto", 19.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(291, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(860, 68);
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
            this.startButtonLayout.Location = new System.Drawing.Point(200, 618);
            this.startButtonLayout.Name = "startButtonLayout";
            this.startButtonLayout.RowCount = 1;
            this.startButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startButtonLayout.Size = new System.Drawing.Size(1444, 124);
            this.startButtonLayout.TabIndex = 5;
            // 
            // startBtn
            // 
            this.startBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startBtn.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(508, 3);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(427, 118);
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
            this.startTitle.Location = new System.Drawing.Point(200, 100);
            this.startTitle.Name = "startTitle";
            this.startTitle.RowCount = 1;
            this.startTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startTitle.Size = new System.Drawing.Size(1444, 182);
            this.startTitle.TabIndex = 4;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.title.Font = new System.Drawing.Font("Roboto", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(147, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(1149, 182);
            this.title.TabIndex = 0;
            this.title.Text = "PRINTER VENDO";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startLeft
            // 
            this.startLeft.ColumnCount = 1;
            this.startLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.startLeft.Location = new System.Drawing.Point(0, 100);
            this.startLeft.Name = "startLeft";
            this.startLeft.RowCount = 1;
            this.startLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startLeft.Size = new System.Drawing.Size(200, 642);
            this.startLeft.TabIndex = 3;
            // 
            // startRight
            // 
            this.startRight.ColumnCount = 1;
            this.startRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.startRight.Location = new System.Drawing.Point(1644, 100);
            this.startRight.Name = "startRight";
            this.startRight.RowCount = 1;
            this.startRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startRight.Size = new System.Drawing.Size(200, 642);
            this.startRight.TabIndex = 2;
            // 
            // startBottom
            // 
            this.startBottom.ColumnCount = 1;
            this.startBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.startBottom.Location = new System.Drawing.Point(0, 742);
            this.startBottom.Name = "startBottom";
            this.startBottom.RowCount = 1;
            this.startBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startBottom.Size = new System.Drawing.Size(1844, 100);
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
            this.startTop.Name = "startTop";
            this.startTop.RowCount = 1;
            this.startTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startTop.Size = new System.Drawing.Size(1844, 100);
            this.startTop.TabIndex = 0;
            // 
            // uploadPanel
            // 
            this.uploadPanel.Controls.Add(this.uploadInstructionPanel);
            this.uploadPanel.Controls.Add(this.uploadQrPanel);
            this.uploadPanel.Controls.Add(this.continuePanel);
            this.uploadPanel.Controls.Add(this.uploadLeft);
            this.uploadPanel.Controls.Add(this.uploadRight);
            this.uploadPanel.Controls.Add(this.uploadBottom);
            this.uploadPanel.Controls.Add(this.uploadTop);
            this.uploadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadPanel.Location = new System.Drawing.Point(0, 0);
            this.uploadPanel.Name = "uploadPanel";
            this.uploadPanel.Size = new System.Drawing.Size(1844, 842);
            this.uploadPanel.TabIndex = 1;
            this.uploadPanel.Visible = false;
            this.uploadPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.uploadPanel_Paint);
            // 
            // uploadInstructionPanel
            // 
            this.uploadInstructionPanel.Controls.Add(this.buttonLayout);
            this.uploadInstructionPanel.Controls.Add(this.buttonLayoutLeft);
            this.uploadInstructionPanel.Controls.Add(this.buttonLayoutRight);
            this.uploadInstructionPanel.Controls.Add(this.buttonLayoutBottom);
            this.uploadInstructionPanel.Controls.Add(this.buttonLayoutTop);
            this.uploadInstructionPanel.Controls.Add(this.instructions);
            this.uploadInstructionPanel.Controls.Add(this.instructionTitle);
            this.uploadInstructionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadInstructionPanel.Location = new System.Drawing.Point(200, 100);
            this.uploadInstructionPanel.Name = "uploadInstructionPanel";
            this.uploadInstructionPanel.Size = new System.Drawing.Size(1444, 642);
            this.uploadInstructionPanel.TabIndex = 4;
            // 
            // buttonLayout
            // 
            this.buttonLayout.ColumnCount = 1;
            this.buttonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.buttonLayout.Controls.Add(this.qrPictureBox, 0, 0);
            this.buttonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLayout.Location = new System.Drawing.Point(685, 240);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.RowCount = 1;
            this.buttonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonLayout.Size = new System.Drawing.Size(559, 302);
            this.buttonLayout.TabIndex = 6;
            // 
            // qrPictureBox
            // 
            this.qrPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrPictureBox.Location = new System.Drawing.Point(3, 3);
            this.qrPictureBox.Name = "qrPictureBox";
            this.qrPictureBox.Size = new System.Drawing.Size(553, 296);
            this.qrPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.qrPictureBox.TabIndex = 0;
            this.qrPictureBox.TabStop = false;
            // 
            // buttonLayoutLeft
            // 
            this.buttonLayoutLeft.ColumnCount = 1;
            this.buttonLayoutLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayoutLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayoutLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonLayoutLeft.Location = new System.Drawing.Point(485, 240);
            this.buttonLayoutLeft.Name = "buttonLayoutLeft";
            this.buttonLayoutLeft.RowCount = 1;
            this.buttonLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayoutLeft.Size = new System.Drawing.Size(200, 302);
            this.buttonLayoutLeft.TabIndex = 5;
            // 
            // buttonLayoutRight
            // 
            this.buttonLayoutRight.ColumnCount = 1;
            this.buttonLayoutRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayoutRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayoutRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonLayoutRight.Location = new System.Drawing.Point(1244, 240);
            this.buttonLayoutRight.Name = "buttonLayoutRight";
            this.buttonLayoutRight.RowCount = 1;
            this.buttonLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayoutRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayoutRight.Size = new System.Drawing.Size(200, 302);
            this.buttonLayoutRight.TabIndex = 4;
            // 
            // buttonLayoutBottom
            // 
            this.buttonLayoutBottom.ColumnCount = 1;
            this.buttonLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayoutBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonLayoutBottom.Location = new System.Drawing.Point(485, 542);
            this.buttonLayoutBottom.Name = "buttonLayoutBottom";
            this.buttonLayoutBottom.RowCount = 1;
            this.buttonLayoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayoutBottom.Size = new System.Drawing.Size(959, 100);
            this.buttonLayoutBottom.TabIndex = 3;
            // 
            // buttonLayoutTop
            // 
            this.buttonLayoutTop.ColumnCount = 1;
            this.buttonLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.buttonLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.buttonLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.buttonLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.buttonLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.buttonLayoutTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.buttonLayoutTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLayoutTop.Location = new System.Drawing.Point(485, 140);
            this.buttonLayoutTop.Name = "buttonLayoutTop";
            this.buttonLayoutTop.RowCount = 1;
            this.buttonLayoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.buttonLayoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.buttonLayoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.buttonLayoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.buttonLayoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.buttonLayoutTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.buttonLayoutTop.Size = new System.Drawing.Size(959, 100);
            this.buttonLayoutTop.TabIndex = 2;
            // 
            // instructions
            // 
            this.instructions.ColumnCount = 1;
            this.instructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.instructions.Controls.Add(this.howToUpload, 0, 0);
            this.instructions.Controls.Add(this.instruction1, 0, 1);
            this.instructions.Controls.Add(this.instruction2, 0, 2);
            this.instructions.Controls.Add(this.instruction3, 0, 3);
            this.instructions.Dock = System.Windows.Forms.DockStyle.Left;
            this.instructions.Location = new System.Drawing.Point(0, 140);
            this.instructions.Name = "instructions";
            this.instructions.RowCount = 10;
            this.instructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.instructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.instructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.instructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.instructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.instructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.instructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.instructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.instructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.instructions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.instructions.Size = new System.Drawing.Size(485, 502);
            this.instructions.TabIndex = 1;
            // 
            // howToUpload
            // 
            this.howToUpload.AutoSize = true;
            this.howToUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.howToUpload.Font = new System.Drawing.Font("Roboto", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howToUpload.Location = new System.Drawing.Point(3, 0);
            this.howToUpload.Name = "howToUpload";
            this.howToUpload.Size = new System.Drawing.Size(479, 91);
            this.howToUpload.TabIndex = 0;
            this.howToUpload.Text = "How to upload:";
            this.howToUpload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // instruction1
            // 
            this.instruction1.AutoSize = true;
            this.instruction1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instruction1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instruction1.Location = new System.Drawing.Point(3, 91);
            this.instruction1.Name = "instruction1";
            this.instruction1.Size = new System.Drawing.Size(479, 45);
            this.instruction1.TabIndex = 1;
            this.instruction1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // instruction2
            // 
            this.instruction2.AutoSize = true;
            this.instruction2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instruction2.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instruction2.Location = new System.Drawing.Point(3, 136);
            this.instruction2.Name = "instruction2";
            this.instruction2.Size = new System.Drawing.Size(479, 45);
            this.instruction2.TabIndex = 2;
            this.instruction2.Text = "2. Follow the furture instructions";
            this.instruction2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // instruction3
            // 
            this.instruction3.AutoSize = true;
            this.instruction3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instruction3.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instruction3.Location = new System.Drawing.Point(3, 181);
            this.instruction3.Name = "instruction3";
            this.instruction3.Size = new System.Drawing.Size(479, 45);
            this.instruction3.TabIndex = 3;
            this.instruction3.Text = "3. Wait while your file is being processed";
            this.instruction3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // instructionTitle
            // 
            this.instructionTitle.ColumnCount = 3;
            this.instructionTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.instructionTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.instructionTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.instructionTitle.Controls.Add(this.uploadFile, 1, 0);
            this.instructionTitle.Controls.Add(this.label2, 1, 1);
            this.instructionTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.instructionTitle.Location = new System.Drawing.Point(0, 0);
            this.instructionTitle.Name = "instructionTitle";
            this.instructionTitle.RowCount = 2;
            this.instructionTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.instructionTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.instructionTitle.Size = new System.Drawing.Size(1444, 140);
            this.instructionTitle.TabIndex = 0;
            // 
            // uploadFile
            // 
            this.uploadFile.AutoSize = true;
            this.uploadFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadFile.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadFile.Location = new System.Drawing.Point(147, 0);
            this.uploadFile.Name = "uploadFile";
            this.uploadFile.Size = new System.Drawing.Size(1149, 84);
            this.uploadFile.TabIndex = 0;
            this.uploadFile.Text = "FILE UPLOAD";
            this.uploadFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(147, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1149, 56);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose a method to begin";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // uploadQrPanel
            // 
            this.uploadQrPanel.Controls.Add(this.tableLayoutPanel1);
            this.uploadQrPanel.Controls.Add(this.qrInstructions);
            this.uploadQrPanel.Controls.Add(this.qrTitleLayout);
            this.uploadQrPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uploadQrPanel.Location = new System.Drawing.Point(200, 100);
            this.uploadQrPanel.Name = "uploadQrPanel";
            this.uploadQrPanel.Size = new System.Drawing.Size(1444, 642);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(535, 542);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(909, 100);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // qrBackBtn
            // 
            this.qrBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrBackBtn.Font = new System.Drawing.Font("Roboto", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrBackBtn.Location = new System.Drawing.Point(638, 3);
            this.qrBackBtn.Name = "qrBackBtn";
            this.qrBackBtn.Size = new System.Drawing.Size(268, 94);
            this.qrBackBtn.TabIndex = 0;
            this.qrBackBtn.Text = "BACK";
            this.qrBackBtn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Roboto", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(539, 100);
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
            this.qrInstructions.Location = new System.Drawing.Point(0, 100);
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
            this.qrInstructions.Size = new System.Drawing.Size(535, 542);
            this.qrInstructions.TabIndex = 1;
            // 
            // qrInstruction1
            // 
            this.qrInstruction1.AutoSize = true;
            this.qrInstruction1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrInstruction1.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrInstruction1.Location = new System.Drawing.Point(3, 98);
            this.qrInstruction1.Name = "qrInstruction1";
            this.qrInstruction1.Size = new System.Drawing.Size(529, 49);
            this.qrInstruction1.TabIndex = 0;
            this.qrInstruction1.Text = "1. Open your phone camera  ";
            this.qrInstruction1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qrInstruction2
            // 
            this.qrInstruction2.AutoSize = true;
            this.qrInstruction2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrInstruction2.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrInstruction2.Location = new System.Drawing.Point(3, 147);
            this.qrInstruction2.Name = "qrInstruction2";
            this.qrInstruction2.Size = new System.Drawing.Size(529, 49);
            this.qrInstruction2.TabIndex = 1;
            this.qrInstruction2.Text = "2. Scan the QR code on screen ";
            this.qrInstruction2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qrInstruction3
            // 
            this.qrInstruction3.AutoSize = true;
            this.qrInstruction3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrInstruction3.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrInstruction3.Location = new System.Drawing.Point(3, 196);
            this.qrInstruction3.Name = "qrInstruction3";
            this.qrInstruction3.Size = new System.Drawing.Size(529, 49);
            this.qrInstruction3.TabIndex = 2;
            this.qrInstruction3.Text = "3. Open the link shown on your phone  ";
            this.qrInstruction3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qrInstruction4
            // 
            this.qrInstruction4.AutoSize = true;
            this.qrInstruction4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrInstruction4.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrInstruction4.Location = new System.Drawing.Point(3, 245);
            this.qrInstruction4.Name = "qrInstruction4";
            this.qrInstruction4.Size = new System.Drawing.Size(529, 49);
            this.qrInstruction4.TabIndex = 3;
            this.qrInstruction4.Text = "4. Select your file and upload  ";
            this.qrInstruction4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // qrInstruction5
            // 
            this.qrInstruction5.AutoSize = true;
            this.qrInstruction5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qrInstruction5.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrInstruction5.Location = new System.Drawing.Point(3, 294);
            this.qrInstruction5.Name = "qrInstruction5";
            this.qrInstruction5.Size = new System.Drawing.Size(529, 49);
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
            this.qrTitleLayout.Name = "qrTitleLayout";
            this.qrTitleLayout.RowCount = 1;
            this.qrTitleLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.qrTitleLayout.Size = new System.Drawing.Size(1444, 100);
            this.qrTitleLayout.TabIndex = 0;
            // 
            // qrTitle
            // 
            this.qrTitle.AutoSize = true;
            this.qrTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.qrTitle.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qrTitle.Location = new System.Drawing.Point(147, 0);
            this.qrTitle.Name = "qrTitle";
            this.qrTitle.Size = new System.Drawing.Size(1149, 96);
            this.qrTitle.TabIndex = 0;
            this.qrTitle.Text = "QR CODE UPLOAD";
            this.qrTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // continuePanel
            // 
            this.continuePanel.ColumnCount = 3;
            this.continuePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.continuePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.continuePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.continuePanel.Controls.Add(this.continueBtn, 1, 1);
            this.continuePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continuePanel.Location = new System.Drawing.Point(200, 100);
            this.continuePanel.Name = "continuePanel";
            this.continuePanel.RowCount = 3;
            this.continuePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.continuePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.continuePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.continuePanel.Size = new System.Drawing.Size(1444, 642);
            this.continuePanel.TabIndex = 7;
            // 
            // continueBtn
            // 
            this.continueBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continueBtn.Font = new System.Drawing.Font("Roboto", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueBtn.Location = new System.Drawing.Point(484, 217);
            this.continueBtn.Name = "continueBtn";
            this.continueBtn.Size = new System.Drawing.Size(475, 208);
            this.continueBtn.TabIndex = 0;
            this.continueBtn.Text = "CONTINUE";
            this.continueBtn.UseVisualStyleBackColor = true;
            this.continueBtn.Click += new System.EventHandler(this.continueBtn_Click);
            // 
            // uploadLeft
            // 
            this.uploadLeft.ColumnCount = 1;
            this.uploadLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.uploadLeft.Location = new System.Drawing.Point(0, 100);
            this.uploadLeft.Name = "uploadLeft";
            this.uploadLeft.RowCount = 1;
            this.uploadLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadLeft.Size = new System.Drawing.Size(200, 642);
            this.uploadLeft.TabIndex = 3;
            // 
            // uploadRight
            // 
            this.uploadRight.ColumnCount = 1;
            this.uploadRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.uploadRight.Location = new System.Drawing.Point(1644, 100);
            this.uploadRight.Name = "uploadRight";
            this.uploadRight.RowCount = 1;
            this.uploadRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadRight.Size = new System.Drawing.Size(200, 642);
            this.uploadRight.TabIndex = 2;
            // 
            // uploadBottom
            // 
            this.uploadBottom.ColumnCount = 1;
            this.uploadBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uploadBottom.Location = new System.Drawing.Point(0, 742);
            this.uploadBottom.Name = "uploadBottom";
            this.uploadBottom.RowCount = 1;
            this.uploadBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadBottom.Size = new System.Drawing.Size(1844, 100);
            this.uploadBottom.TabIndex = 1;
            // 
            // uploadTop
            // 
            this.uploadTop.ColumnCount = 1;
            this.uploadTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.uploadTop.Location = new System.Drawing.Point(0, 0);
            this.uploadTop.Name = "uploadTop";
            this.uploadTop.RowCount = 1;
            this.uploadTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uploadTop.Size = new System.Drawing.Size(1844, 100);
            this.uploadTop.TabIndex = 0;
            // 
            // printingSettingsPanel
            // 
            this.printingSettingsPanel.Controls.Add(this.settingsPanel);
            this.printingSettingsPanel.Controls.Add(this.paymentPanel);
            this.printingSettingsPanel.Controls.Add(this.settingsTop);
            this.printingSettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printingSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.printingSettingsPanel.Name = "printingSettingsPanel";
            this.printingSettingsPanel.Size = new System.Drawing.Size(1844, 842);
            this.printingSettingsPanel.TabIndex = 2;
            this.printingSettingsPanel.Visible = false;
            // 
            // settingsPanel
            // 
            this.settingsPanel.Controls.Add(this.tableLayoutPanel3);
            this.settingsPanel.Controls.Add(this.tableLayoutPanel2);
            this.settingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsPanel.Location = new System.Drawing.Point(0, 24);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(1844, 818);
            this.settingsPanel.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.87554F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.84335F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.281116F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.281116F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.84335F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.87554F));
            this.tableLayoutPanel3.Controls.Add(this.continuePaymentBtn, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.settingsBackBtn, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 718);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1844, 100);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // continuePaymentBtn
            // 
            this.continuePaymentBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continuePaymentBtn.Font = new System.Drawing.Font("Roboto", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continuePaymentBtn.Location = new System.Drawing.Point(1095, 3);
            this.continuePaymentBtn.Name = "continuePaymentBtn";
            this.continuePaymentBtn.Size = new System.Drawing.Size(507, 94);
            this.continuePaymentBtn.TabIndex = 0;
            this.continuePaymentBtn.Text = "CONTINUE";
            this.continuePaymentBtn.UseVisualStyleBackColor = true;
            this.continuePaymentBtn.Click += new System.EventHandler(this.proceedBtn_Click);
            // 
            // settingsBackBtn
            // 
            this.settingsBackBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsBackBtn.Font = new System.Drawing.Font("Roboto", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsBackBtn.Location = new System.Drawing.Point(240, 3);
            this.settingsBackBtn.Name = "settingsBackBtn";
            this.settingsBackBtn.Size = new System.Drawing.Size(507, 94);
            this.settingsBackBtn.TabIndex = 1;
            this.settingsBackBtn.TabStop = false;
            this.settingsBackBtn.Text = "BACK";
            this.settingsBackBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 818F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1844, 818);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.47826F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.47826F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.347826F));
            this.tableLayoutPanel4.Controls.Add(this.numericCopies, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.copiesLabel, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.selectPageLabel, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.totalPagesLabelLabel, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.totalPagesLabel, 3, 3);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.totalLabelLabel, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.totalLabel, 3, 6);
            this.tableLayoutPanel4.Controls.Add(this.paperColor, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel8, 3, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 8;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.024973F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.07492F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.07492F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.07492F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.07553F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.524458F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.12288F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.027386F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(916, 812);
            this.tableLayoutPanel4.TabIndex = 0;
            this.tableLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // numericCopies
            // 
            this.numericCopies.BackColor = System.Drawing.SystemColors.Window;
            this.numericCopies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericCopies.Location = new System.Drawing.Point(479, 43);
            this.numericCopies.Name = "numericCopies";
            this.numericCopies.Size = new System.Drawing.Size(392, 38);
            this.numericCopies.TabIndex = 0;
            this.numericCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // copiesLabel
            // 
            this.copiesLabel.AutoSize = true;
            this.copiesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copiesLabel.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copiesLabel.Location = new System.Drawing.Point(42, 40);
            this.copiesLabel.Name = "copiesLabel";
            this.copiesLabel.Size = new System.Drawing.Size(392, 122);
            this.copiesLabel.TabIndex = 0;
            this.copiesLabel.Text = "COPIES:";
            this.copiesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selectPageLabel
            // 
            this.selectPageLabel.AutoSize = true;
            this.selectPageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectPageLabel.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectPageLabel.Location = new System.Drawing.Point(42, 162);
            this.selectPageLabel.Name = "selectPageLabel";
            this.selectPageLabel.Size = new System.Drawing.Size(392, 122);
            this.selectPageLabel.TabIndex = 1;
            this.selectPageLabel.Text = "SELECT PAGE:";
            this.selectPageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalPagesLabelLabel
            // 
            this.totalPagesLabelLabel.AutoSize = true;
            this.totalPagesLabelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalPagesLabelLabel.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPagesLabelLabel.Location = new System.Drawing.Point(42, 284);
            this.totalPagesLabelLabel.Name = "totalPagesLabelLabel";
            this.totalPagesLabelLabel.Size = new System.Drawing.Size(392, 122);
            this.totalPagesLabelLabel.TabIndex = 2;
            this.totalPagesLabelLabel.Text = "TOTAL PAGES: ";
            this.totalPagesLabelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.totalPagesLabelLabel.Click += new System.EventHandler(this.totalPagesLabel_Click);
            // 
            // totalPagesLabel
            // 
            this.totalPagesLabel.AutoSize = true;
            this.totalPagesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalPagesLabel.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPagesLabel.Location = new System.Drawing.Point(479, 284);
            this.totalPagesLabel.Name = "totalPagesLabel";
            this.totalPagesLabel.Size = new System.Drawing.Size(392, 122);
            this.totalPagesLabel.TabIndex = 5;
            this.totalPagesLabel.Text = "1";
            this.totalPagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(479, 165);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(392, 116);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.radioPrintRange, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.radioSinglePage, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.radioPrintAll, 0, 2);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(190, 110);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // radioPrintRange
            // 
            this.radioPrintRange.AutoSize = true;
            this.radioPrintRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioPrintRange.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPrintRange.Location = new System.Drawing.Point(3, 3);
            this.radioPrintRange.Name = "radioPrintRange";
            this.radioPrintRange.Size = new System.Drawing.Size(184, 30);
            this.radioPrintRange.TabIndex = 0;
            this.radioPrintRange.TabStop = true;
            this.radioPrintRange.Text = "PRINT RANGE";
            this.radioPrintRange.UseVisualStyleBackColor = true;
            // 
            // radioSinglePage
            // 
            this.radioSinglePage.AutoSize = true;
            this.radioSinglePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioSinglePage.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioSinglePage.Location = new System.Drawing.Point(3, 39);
            this.radioSinglePage.Name = "radioSinglePage";
            this.radioSinglePage.Size = new System.Drawing.Size(184, 30);
            this.radioSinglePage.TabIndex = 1;
            this.radioSinglePage.TabStop = true;
            this.radioSinglePage.Text = "SINGLE PAGE";
            this.radioSinglePage.UseVisualStyleBackColor = true;
            // 
            // radioPrintAll
            // 
            this.radioPrintAll.AutoSize = true;
            this.radioPrintAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioPrintAll.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPrintAll.Location = new System.Drawing.Point(3, 75);
            this.radioPrintAll.Name = "radioPrintAll";
            this.radioPrintAll.Size = new System.Drawing.Size(184, 32);
            this.radioPrintAll.TabIndex = 2;
            this.radioPrintAll.TabStop = true;
            this.radioPrintAll.Text = "PRINT ALL PAGES";
            this.radioPrintAll.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Controls.Add(this.numericSinglePage, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.numericPageRange, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(199, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(190, 110);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // numericSinglePage
            // 
            this.numericSinglePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericSinglePage.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericSinglePage.Location = new System.Drawing.Point(3, 39);
            this.numericSinglePage.Name = "numericSinglePage";
            this.numericSinglePage.Size = new System.Drawing.Size(184, 28);
            this.numericSinglePage.TabIndex = 1;
            // 
            // numericPageRange
            // 
            this.numericPageRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericPageRange.Location = new System.Drawing.Point(3, 3);
            this.numericPageRange.Name = "numericPageRange";
            this.numericPageRange.Size = new System.Drawing.Size(184, 22);
            this.numericPageRange.TabIndex = 2;
            // 
            // totalLabelLabel
            // 
            this.totalLabelLabel.AutoSize = true;
            this.totalLabelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalLabelLabel.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabelLabel.Location = new System.Drawing.Point(42, 564);
            this.totalLabelLabel.Name = "totalLabelLabel";
            this.totalLabelLabel.Size = new System.Drawing.Size(392, 203);
            this.totalLabelLabel.TabIndex = 3;
            this.totalLabelLabel.Text = "TOTAL :";
            this.totalLabelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.totalLabelLabel.Click += new System.EventHandler(this.label7_Click);
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalLabel.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(479, 564);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(392, 203);
            this.totalLabel.TabIndex = 6;
            this.totalLabel.Text = "1";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paperColor
            // 
            this.paperColor.AutoSize = true;
            this.paperColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paperColor.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paperColor.Location = new System.Drawing.Point(42, 406);
            this.paperColor.Name = "paperColor";
            this.paperColor.Size = new System.Drawing.Size(392, 122);
            this.paperColor.TabIndex = 8;
            this.paperColor.Text = "PRINT TYPE:";
            this.paperColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Controls.Add(this.radioBlackWhite, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.radioColored, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(479, 409);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(392, 116);
            this.tableLayoutPanel8.TabIndex = 9;
            // 
            // radioBlackWhite
            // 
            this.radioBlackWhite.AutoSize = true;
            this.radioBlackWhite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioBlackWhite.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBlackWhite.Location = new System.Drawing.Point(3, 3);
            this.radioBlackWhite.Name = "radioBlackWhite";
            this.radioBlackWhite.Size = new System.Drawing.Size(386, 52);
            this.radioBlackWhite.TabIndex = 0;
            this.radioBlackWhite.TabStop = true;
            this.radioBlackWhite.Text = "BLACK AND WHITE";
            this.radioBlackWhite.UseVisualStyleBackColor = true;
            // 
            // radioColored
            // 
            this.radioColored.AutoSize = true;
            this.radioColored.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioColored.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioColored.Location = new System.Drawing.Point(3, 61);
            this.radioColored.Name = "radioColored";
            this.radioColored.Size = new System.Drawing.Size(386, 52);
            this.radioColored.TabIndex = 1;
            this.radioColored.TabStop = true;
            this.radioColored.Text = "COLORED";
            this.radioColored.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.previewPanel);
            this.panel1.Controls.Add(this.tableLayoutPanel10);
            this.panel1.Controls.Add(this.tableLayoutPanel9);
            this.panel1.Location = new System.Drawing.Point(925, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 712);
            this.panel1.TabIndex = 1;
            // 
            // previewPanel
            // 
            this.previewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPanel.Location = new System.Drawing.Point(0, 100);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(916, 512);
            this.previewPanel.TabIndex = 2;
            this.previewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.previewPanel_Paint);
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 3;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.Controls.Add(this.editBtn, 1, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 612);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 3;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(916, 100);
            this.tableLayoutPanel10.TabIndex = 1;
            this.tableLayoutPanel10.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel10_Paint);
            // 
            // editBtn
            // 
            this.editBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editBtn.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Location = new System.Drawing.Point(232, 28);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(452, 44);
            this.editBtn.TabIndex = 0;
            this.editBtn.Text = "EDIT";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Controls.Add(this.labelPreview, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(916, 100);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPreview.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreview.Location = new System.Drawing.Point(3, 0);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(910, 100);
            this.labelPreview.TabIndex = 0;
            this.labelPreview.Text = "FILE PREVIEW";
            this.labelPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paymentPanel
            // 
            this.paymentPanel.Controls.Add(this.tableLayoutPayment);
            this.paymentPanel.Controls.Add(this.paymentTableTitle);
            this.paymentPanel.Controls.Add(this.paymentRight);
            this.paymentPanel.Controls.Add(this.paymentLeft);
            this.paymentPanel.Controls.Add(this.paymentBottom);
            this.paymentPanel.Controls.Add(this.paymentTop);
            this.paymentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentPanel.Location = new System.Drawing.Point(0, 24);
            this.paymentPanel.Name = "paymentPanel";
            this.paymentPanel.Size = new System.Drawing.Size(1844, 818);
            this.paymentPanel.TabIndex = 4;
            // 
            // tableLayoutPayment
            // 
            this.tableLayoutPayment.ColumnCount = 5;
            this.tableLayoutPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.16558F));
            this.tableLayoutPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.6834F));
            this.tableLayoutPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.304811F));
            this.tableLayoutPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.68063F));
            this.tableLayoutPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.16558F));
            this.tableLayoutPayment.Controls.Add(this.balancePaymentLabel, 1, 2);
            this.tableLayoutPayment.Controls.Add(this.paymentTotalLabel, 1, 1);
            this.tableLayoutPayment.Controls.Add(this.cancelPrintBtn, 1, 4);
            this.tableLayoutPayment.Controls.Add(this.printBtn, 3, 4);
            this.tableLayoutPayment.Controls.Add(this.totalPayment, 3, 1);
            this.tableLayoutPayment.Controls.Add(this.paymentBalance, 3, 2);
            this.tableLayoutPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPayment.Location = new System.Drawing.Point(200, 200);
            this.tableLayoutPayment.Name = "tableLayoutPayment";
            this.tableLayoutPayment.RowCount = 5;
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPayment.Size = new System.Drawing.Size(1444, 518);
            this.tableLayoutPayment.TabIndex = 5;
            // 
            // balancePaymentLabel
            // 
            this.balancePaymentLabel.AutoSize = true;
            this.balancePaymentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.balancePaymentLabel.Font = new System.Drawing.Font("Roboto", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balancePaymentLabel.Location = new System.Drawing.Point(265, 206);
            this.balancePaymentLabel.Name = "balancePaymentLabel";
            this.balancePaymentLabel.Size = new System.Drawing.Size(393, 103);
            this.balancePaymentLabel.TabIndex = 1;
            this.balancePaymentLabel.Text = "BALANCE :";
            this.balancePaymentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // paymentTotalLabel
            // 
            this.paymentTotalLabel.AutoSize = true;
            this.paymentTotalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentTotalLabel.Font = new System.Drawing.Font("Roboto", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentTotalLabel.Location = new System.Drawing.Point(265, 103);
            this.paymentTotalLabel.Name = "paymentTotalLabel";
            this.paymentTotalLabel.Size = new System.Drawing.Size(393, 103);
            this.paymentTotalLabel.TabIndex = 0;
            this.paymentTotalLabel.Text = "TOTAL :";
            this.paymentTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cancelPrintBtn
            // 
            this.cancelPrintBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelPrintBtn.Font = new System.Drawing.Font("Roboto", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelPrintBtn.Location = new System.Drawing.Point(265, 415);
            this.cancelPrintBtn.Name = "cancelPrintBtn";
            this.cancelPrintBtn.Size = new System.Drawing.Size(393, 100);
            this.cancelPrintBtn.TabIndex = 2;
            this.cancelPrintBtn.Text = "CANCEL";
            this.cancelPrintBtn.UseVisualStyleBackColor = true;
            this.cancelPrintBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printBtn.Font = new System.Drawing.Font("Roboto", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtn.Location = new System.Drawing.Point(783, 415);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(393, 100);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "PRINT";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.proceedBtn_Click);
            // 
            // totalPayment
            // 
            this.totalPayment.AutoSize = true;
            this.totalPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalPayment.Font = new System.Drawing.Font("Roboto", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPayment.Location = new System.Drawing.Point(783, 103);
            this.totalPayment.Name = "totalPayment";
            this.totalPayment.Size = new System.Drawing.Size(393, 103);
            this.totalPayment.TabIndex = 4;
            this.totalPayment.Text = "[Total Payment]";
            this.totalPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // paymentBalance
            // 
            this.paymentBalance.AutoSize = true;
            this.paymentBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentBalance.Font = new System.Drawing.Font("Roboto", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentBalance.Location = new System.Drawing.Point(783, 206);
            this.paymentBalance.Name = "paymentBalance";
            this.paymentBalance.Size = new System.Drawing.Size(393, 103);
            this.paymentBalance.TabIndex = 5;
            this.paymentBalance.Text = "[Payment Balance]";
            this.paymentBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // paymentTableTitle
            // 
            this.paymentTableTitle.ColumnCount = 1;
            this.paymentTableTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentTableTitle.Controls.Add(this.paymentTitle, 0, 0);
            this.paymentTableTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.paymentTableTitle.Location = new System.Drawing.Point(200, 100);
            this.paymentTableTitle.Name = "paymentTableTitle";
            this.paymentTableTitle.RowCount = 1;
            this.paymentTableTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentTableTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.paymentTableTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.paymentTableTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.paymentTableTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.paymentTableTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.paymentTableTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.paymentTableTitle.Size = new System.Drawing.Size(1444, 100);
            this.paymentTableTitle.TabIndex = 4;
            // 
            // paymentTitle
            // 
            this.paymentTitle.AutoSize = true;
            this.paymentTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentTitle.Font = new System.Drawing.Font("Roboto", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentTitle.Location = new System.Drawing.Point(3, 0);
            this.paymentTitle.Name = "paymentTitle";
            this.paymentTitle.Size = new System.Drawing.Size(1438, 100);
            this.paymentTitle.TabIndex = 0;
            this.paymentTitle.Text = "PAYMENT";
            this.paymentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paymentRight
            // 
            this.paymentRight.ColumnCount = 1;
            this.paymentRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.paymentRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.paymentRight.Location = new System.Drawing.Point(1644, 100);
            this.paymentRight.Name = "paymentRight";
            this.paymentRight.RowCount = 1;
            this.paymentRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 618F));
            this.paymentRight.Size = new System.Drawing.Size(200, 618);
            this.paymentRight.TabIndex = 3;
            // 
            // paymentLeft
            // 
            this.paymentLeft.ColumnCount = 1;
            this.paymentLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.paymentLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.paymentLeft.Location = new System.Drawing.Point(0, 100);
            this.paymentLeft.Name = "paymentLeft";
            this.paymentLeft.RowCount = 1;
            this.paymentLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 618F));
            this.paymentLeft.Size = new System.Drawing.Size(200, 618);
            this.paymentLeft.TabIndex = 2;
            // 
            // paymentBottom
            // 
            this.paymentBottom.ColumnCount = 1;
            this.paymentBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.paymentBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paymentBottom.Location = new System.Drawing.Point(0, 718);
            this.paymentBottom.Name = "paymentBottom";
            this.paymentBottom.RowCount = 1;
            this.paymentBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.paymentBottom.Size = new System.Drawing.Size(1844, 100);
            this.paymentBottom.TabIndex = 1;
            this.paymentBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.paymentBottom_Paint);
            // 
            // paymentTop
            // 
            this.paymentTop.ColumnCount = 1;
            this.paymentTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.paymentTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paymentTop.Location = new System.Drawing.Point(0, 0);
            this.paymentTop.Name = "paymentTop";
            this.paymentTop.RowCount = 1;
            this.paymentTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.paymentTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.paymentTop.Size = new System.Drawing.Size(1844, 100);
            this.paymentTop.TabIndex = 0;
            // 
            // settingsTop
            // 
            this.settingsTop.ColumnCount = 1;
            this.settingsTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingsTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.settingsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsTop.Location = new System.Drawing.Point(0, 0);
            this.settingsTop.Name = "settingsTop";
            this.settingsTop.RowCount = 1;
            this.settingsTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.settingsTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.settingsTop.Size = new System.Drawing.Size(1844, 24);
            this.settingsTop.TabIndex = 0;
            this.settingsTop.Paint += new System.Windows.Forms.PaintEventHandler(this.settingsTop_Paint);
            // 
            // PrinterPhotoVendo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1844, 842);
            this.Controls.Add(this.printingSettingsPanel);
            this.Controls.Add(this.uploadPanel);
            this.Controls.Add(this.startPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PrinterPhotoVendo";
            this.Text = "Printer Vendo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Printer_Vendo_Load);
            this.startPanel.ResumeLayout(false);
            this.startText.ResumeLayout(false);
            this.startText.PerformLayout();
            this.startButtonLayout.ResumeLayout(false);
            this.startTitle.ResumeLayout(false);
            this.startTitle.PerformLayout();
            this.uploadPanel.ResumeLayout(false);
            this.uploadInstructionPanel.ResumeLayout(false);
            this.buttonLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qrPictureBox)).EndInit();
            this.instructions.ResumeLayout(false);
            this.instructions.PerformLayout();
            this.instructionTitle.ResumeLayout(false);
            this.instructionTitle.PerformLayout();
            this.uploadQrPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.qrInstructions.ResumeLayout(false);
            this.qrInstructions.PerformLayout();
            this.qrTitleLayout.ResumeLayout(false);
            this.qrTitleLayout.PerformLayout();
            this.continuePanel.ResumeLayout(false);
            this.printingSettingsPanel.ResumeLayout(false);
            this.settingsPanel.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCopies)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSinglePage)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.paymentPanel.ResumeLayout(false);
            this.tableLayoutPayment.ResumeLayout(false);
            this.tableLayoutPayment.PerformLayout();
            this.paymentTableTitle.ResumeLayout(false);
            this.paymentTableTitle.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel uploadLeft;
        private System.Windows.Forms.TableLayoutPanel uploadRight;
        private System.Windows.Forms.TableLayoutPanel uploadBottom;
        private System.Windows.Forms.TableLayoutPanel uploadTop;
        private System.Windows.Forms.TableLayoutPanel continuePanel;
        private System.Windows.Forms.Button continueBtn;
        private System.Windows.Forms.TableLayoutPanel instructionTitle;
        private System.Windows.Forms.Label uploadFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel instructions;
        private System.Windows.Forms.Label howToUpload;
        private System.Windows.Forms.Label instruction1;
        private System.Windows.Forms.Label instruction2;
        private System.Windows.Forms.Label instruction3;
        private System.Windows.Forms.TableLayoutPanel buttonLayoutTop;
        private System.Windows.Forms.TableLayoutPanel buttonLayout;
        private System.Windows.Forms.TableLayoutPanel buttonLayoutLeft;
        private System.Windows.Forms.TableLayoutPanel buttonLayoutRight;
        private System.Windows.Forms.TableLayoutPanel buttonLayoutBottom;
        private System.Windows.Forms.Label blueInstruction1;
        private System.Windows.Forms.Label blueInstruction2;
        private System.Windows.Forms.Label blueInstruction3;
        private System.Windows.Forms.Label blueInstruction4;
        private System.Windows.Forms.Label blueInstruction5;
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
        private FileSystemWatcher fileWatcher;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.RadioButton radioPrintRange;
        private System.Windows.Forms.RadioButton radioSinglePage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.NumericUpDown numericSinglePage;
        private System.Windows.Forms.RadioButton radioPrintAll;
        private System.Windows.Forms.TextBox numericPageRange;
        private System.Windows.Forms.TableLayoutPanel settingsTop;
        private System.Windows.Forms.Label paperColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.RadioButton radioBlackWhite;
        private System.Windows.Forms.RadioButton radioColored;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.Panel previewPanel;
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
    }
}