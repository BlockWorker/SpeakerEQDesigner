namespace SpeakerEQDesigner {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.sumPlotView = new OxyPlot.WindowsForms.PlotView();
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.s1Panel = new System.Windows.Forms.Panel();
            this.s1b0Select = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.s1SpkResponse = new System.Windows.Forms.Button();
            this.s1GainSelect = new System.Windows.Forms.NumericUpDown();
            this.s1QSelect = new System.Windows.Forms.NumericUpDown();
            this.s1FreqSelect = new System.Windows.Forms.NumericUpDown();
            this.s1TypeSelect = new System.Windows.Forms.ComboBox();
            this.s1FiltRemove = new System.Windows.Forms.Button();
            this.s1FiltAdd = new System.Windows.Forms.Button();
            this.s1FiltSelect = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.s1PlotView = new OxyPlot.WindowsForms.PlotView();
            this.label6 = new System.Windows.Forms.Label();
            this.s1b0Hex = new System.Windows.Forms.TextBox();
            this.s1b1Hex = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.s1b1Select = new System.Windows.Forms.NumericUpDown();
            this.s1b2Hex = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.s1b2Select = new System.Windows.Forms.NumericUpDown();
            this.s1a1Hex = new System.Windows.Forms.TextBox();
            this.s1a1Label = new System.Windows.Forms.Label();
            this.s1a1Select = new System.Windows.Forms.NumericUpDown();
            this.s1a2Hex = new System.Windows.Forms.TextBox();
            this.s1a2Label = new System.Windows.Forms.Label();
            this.s1a2Select = new System.Windows.Forms.NumericUpDown();
            this.s1NegBox = new System.Windows.Forms.CheckBox();
            this.s1SRSelect = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.s1Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s1b0Select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1GainSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1QSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1FreqSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1FiltSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1b1Select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1b2Select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1a1Select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1a2Select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1SRSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // sumPlotView
            // 
            this.sumPlotView.BackColor = System.Drawing.Color.White;
            this.sumPlotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sumPlotView.Location = new System.Drawing.Point(0, 0);
            this.sumPlotView.Name = "sumPlotView";
            this.sumPlotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.sumPlotView.Size = new System.Drawing.Size(922, 301);
            this.sumPlotView.TabIndex = 0;
            this.sumPlotView.Text = "plotView1";
            this.sumPlotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.sumPlotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.sumPlotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            this.mainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.sumPlotView);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.tableLayoutPanel);
            this.mainSplit.Size = new System.Drawing.Size(922, 667);
            this.mainSplit.SplitterDistance = 301;
            this.mainSplit.TabIndex = 2;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.s1Panel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.s1PlotView, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(922, 362);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // s1Panel
            // 
            this.s1Panel.Controls.Add(this.label9);
            this.s1Panel.Controls.Add(this.s1SRSelect);
            this.s1Panel.Controls.Add(this.s1NegBox);
            this.s1Panel.Controls.Add(this.s1a2Hex);
            this.s1Panel.Controls.Add(this.s1a2Label);
            this.s1Panel.Controls.Add(this.s1a2Select);
            this.s1Panel.Controls.Add(this.s1a1Hex);
            this.s1Panel.Controls.Add(this.s1a1Label);
            this.s1Panel.Controls.Add(this.s1a1Select);
            this.s1Panel.Controls.Add(this.s1b2Hex);
            this.s1Panel.Controls.Add(this.label8);
            this.s1Panel.Controls.Add(this.s1b2Select);
            this.s1Panel.Controls.Add(this.s1b1Hex);
            this.s1Panel.Controls.Add(this.label7);
            this.s1Panel.Controls.Add(this.s1b1Select);
            this.s1Panel.Controls.Add(this.s1b0Hex);
            this.s1Panel.Controls.Add(this.label6);
            this.s1Panel.Controls.Add(this.s1b0Select);
            this.s1Panel.Controls.Add(this.label5);
            this.s1Panel.Controls.Add(this.label4);
            this.s1Panel.Controls.Add(this.label3);
            this.s1Panel.Controls.Add(this.label2);
            this.s1Panel.Controls.Add(this.s1SpkResponse);
            this.s1Panel.Controls.Add(this.s1GainSelect);
            this.s1Panel.Controls.Add(this.s1QSelect);
            this.s1Panel.Controls.Add(this.s1FreqSelect);
            this.s1Panel.Controls.Add(this.s1TypeSelect);
            this.s1Panel.Controls.Add(this.s1FiltRemove);
            this.s1Panel.Controls.Add(this.s1FiltAdd);
            this.s1Panel.Controls.Add(this.s1FiltSelect);
            this.s1Panel.Controls.Add(this.label1);
            this.s1Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.s1Panel.Location = new System.Drawing.Point(4, 169);
            this.s1Panel.Name = "s1Panel";
            this.s1Panel.Size = new System.Drawing.Size(453, 189);
            this.s1Panel.TabIndex = 0;
            // 
            // s1b0Select
            // 
            this.s1b0Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.s1b0Select.DecimalPlaces = 15;
            this.s1b0Select.Enabled = false;
            this.s1b0Select.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.s1b0Select.Location = new System.Drawing.Point(260, 3);
            this.s1b0Select.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.s1b0Select.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            -2147483648});
            this.s1b0Select.Name = "s1b0Select";
            this.s1b0Select.Size = new System.Drawing.Size(120, 20);
            this.s1b0Select.TabIndex = 13;
            this.s1b0Select.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "G (dB):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Q:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "f (Hz):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Type:";
            // 
            // s1SpkResponse
            // 
            this.s1SpkResponse.Location = new System.Drawing.Point(56, 164);
            this.s1SpkResponse.Name = "s1SpkResponse";
            this.s1SpkResponse.Size = new System.Drawing.Size(120, 23);
            this.s1SpkResponse.TabIndex = 8;
            this.s1SpkResponse.Text = "Speaker Response...";
            this.s1SpkResponse.UseVisualStyleBackColor = true;
            // 
            // s1GainSelect
            // 
            this.s1GainSelect.DecimalPlaces = 1;
            this.s1GainSelect.Enabled = false;
            this.s1GainSelect.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.s1GainSelect.Location = new System.Drawing.Point(56, 138);
            this.s1GainSelect.Name = "s1GainSelect";
            this.s1GainSelect.Size = new System.Drawing.Size(120, 20);
            this.s1GainSelect.TabIndex = 7;
            // 
            // s1QSelect
            // 
            this.s1QSelect.DecimalPlaces = 2;
            this.s1QSelect.Enabled = false;
            this.s1QSelect.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.s1QSelect.Location = new System.Drawing.Point(56, 112);
            this.s1QSelect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.s1QSelect.Name = "s1QSelect";
            this.s1QSelect.Size = new System.Drawing.Size(120, 20);
            this.s1QSelect.TabIndex = 6;
            this.s1QSelect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // s1FreqSelect
            // 
            this.s1FreqSelect.Enabled = false;
            this.s1FreqSelect.Location = new System.Drawing.Point(56, 86);
            this.s1FreqSelect.Maximum = new decimal(new int[] {
            48000,
            0,
            0,
            0});
            this.s1FreqSelect.Name = "s1FreqSelect";
            this.s1FreqSelect.Size = new System.Drawing.Size(120, 20);
            this.s1FreqSelect.TabIndex = 5;
            this.s1FreqSelect.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // s1TypeSelect
            // 
            this.s1TypeSelect.FormattingEnabled = true;
            this.s1TypeSelect.Items.AddRange(new object[] {
            "Disabled",
            "EQ",
            "Lowpass",
            "Highpass",
            "Bandpass",
            "Notch",
            "LowShelf",
            "HighShelf",
            "Custom"});
            this.s1TypeSelect.Location = new System.Drawing.Point(56, 59);
            this.s1TypeSelect.Name = "s1TypeSelect";
            this.s1TypeSelect.Size = new System.Drawing.Size(120, 21);
            this.s1TypeSelect.TabIndex = 4;
            this.s1TypeSelect.Text = "Disabled";
            // 
            // s1FiltRemove
            // 
            this.s1FiltRemove.Location = new System.Drawing.Point(108, 29);
            this.s1FiltRemove.Name = "s1FiltRemove";
            this.s1FiltRemove.Size = new System.Drawing.Size(68, 23);
            this.s1FiltRemove.TabIndex = 3;
            this.s1FiltRemove.Text = "Remove";
            this.s1FiltRemove.UseVisualStyleBackColor = true;
            this.s1FiltRemove.Click += new System.EventHandler(this.s1FiltRemove_Click);
            // 
            // s1FiltAdd
            // 
            this.s1FiltAdd.Location = new System.Drawing.Point(56, 29);
            this.s1FiltAdd.Name = "s1FiltAdd";
            this.s1FiltAdd.Size = new System.Drawing.Size(46, 23);
            this.s1FiltAdd.TabIndex = 2;
            this.s1FiltAdd.Text = "Add";
            this.s1FiltAdd.UseVisualStyleBackColor = true;
            this.s1FiltAdd.Click += new System.EventHandler(this.s1FiltAdd_Click);
            // 
            // s1FiltSelect
            // 
            this.s1FiltSelect.Location = new System.Drawing.Point(56, 3);
            this.s1FiltSelect.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.s1FiltSelect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.s1FiltSelect.Name = "s1FiltSelect";
            this.s1FiltSelect.Size = new System.Drawing.Size(120, 20);
            this.s1FiltSelect.TabIndex = 1;
            this.s1FiltSelect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter #:";
            // 
            // s1PlotView
            // 
            this.s1PlotView.BackColor = System.Drawing.Color.White;
            this.s1PlotView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.s1PlotView.Location = new System.Drawing.Point(4, 4);
            this.s1PlotView.Name = "s1PlotView";
            this.s1PlotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.s1PlotView.Size = new System.Drawing.Size(453, 158);
            this.s1PlotView.TabIndex = 1;
            this.s1PlotView.Text = "plotView1";
            this.s1PlotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.s1PlotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.s1PlotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "b0:";
            // 
            // s1b0Hex
            // 
            this.s1b0Hex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.s1b0Hex.Location = new System.Drawing.Point(386, 2);
            this.s1b0Hex.Name = "s1b0Hex";
            this.s1b0Hex.ReadOnly = true;
            this.s1b0Hex.Size = new System.Drawing.Size(64, 20);
            this.s1b0Hex.TabIndex = 15;
            this.s1b0Hex.Text = "00800000";
            // 
            // s1b1Hex
            // 
            this.s1b1Hex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.s1b1Hex.Location = new System.Drawing.Point(386, 28);
            this.s1b1Hex.Name = "s1b1Hex";
            this.s1b1Hex.ReadOnly = true;
            this.s1b1Hex.Size = new System.Drawing.Size(64, 20);
            this.s1b1Hex.TabIndex = 18;
            this.s1b1Hex.Text = "00000000";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "b1:";
            // 
            // s1b1Select
            // 
            this.s1b1Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.s1b1Select.DecimalPlaces = 15;
            this.s1b1Select.Enabled = false;
            this.s1b1Select.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.s1b1Select.Location = new System.Drawing.Point(260, 29);
            this.s1b1Select.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.s1b1Select.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            -2147483648});
            this.s1b1Select.Name = "s1b1Select";
            this.s1b1Select.Size = new System.Drawing.Size(120, 20);
            this.s1b1Select.TabIndex = 16;
            // 
            // s1b2Hex
            // 
            this.s1b2Hex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.s1b2Hex.Location = new System.Drawing.Point(386, 54);
            this.s1b2Hex.Name = "s1b2Hex";
            this.s1b2Hex.ReadOnly = true;
            this.s1b2Hex.Size = new System.Drawing.Size(64, 20);
            this.s1b2Hex.TabIndex = 21;
            this.s1b2Hex.Text = "00000000";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(232, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "b2:";
            // 
            // s1b2Select
            // 
            this.s1b2Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.s1b2Select.DecimalPlaces = 15;
            this.s1b2Select.Enabled = false;
            this.s1b2Select.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.s1b2Select.Location = new System.Drawing.Point(260, 55);
            this.s1b2Select.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.s1b2Select.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            -2147483648});
            this.s1b2Select.Name = "s1b2Select";
            this.s1b2Select.Size = new System.Drawing.Size(120, 20);
            this.s1b2Select.TabIndex = 19;
            // 
            // s1a1Hex
            // 
            this.s1a1Hex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.s1a1Hex.Location = new System.Drawing.Point(386, 80);
            this.s1a1Hex.Name = "s1a1Hex";
            this.s1a1Hex.ReadOnly = true;
            this.s1a1Hex.Size = new System.Drawing.Size(64, 20);
            this.s1a1Hex.TabIndex = 24;
            this.s1a1Hex.Text = "00000000";
            // 
            // s1a1Label
            // 
            this.s1a1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.s1a1Label.AutoSize = true;
            this.s1a1Label.Location = new System.Drawing.Point(229, 83);
            this.s1a1Label.Name = "s1a1Label";
            this.s1a1Label.Size = new System.Drawing.Size(25, 13);
            this.s1a1Label.TabIndex = 23;
            this.s1a1Label.Text = "-a1:";
            // 
            // s1a1Select
            // 
            this.s1a1Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.s1a1Select.DecimalPlaces = 15;
            this.s1a1Select.Enabled = false;
            this.s1a1Select.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.s1a1Select.Location = new System.Drawing.Point(260, 81);
            this.s1a1Select.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.s1a1Select.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            -2147483648});
            this.s1a1Select.Name = "s1a1Select";
            this.s1a1Select.Size = new System.Drawing.Size(120, 20);
            this.s1a1Select.TabIndex = 22;
            // 
            // s1a2Hex
            // 
            this.s1a2Hex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.s1a2Hex.Location = new System.Drawing.Point(386, 106);
            this.s1a2Hex.Name = "s1a2Hex";
            this.s1a2Hex.ReadOnly = true;
            this.s1a2Hex.Size = new System.Drawing.Size(64, 20);
            this.s1a2Hex.TabIndex = 27;
            this.s1a2Hex.Text = "00000000";
            // 
            // s1a2Label
            // 
            this.s1a2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.s1a2Label.AutoSize = true;
            this.s1a2Label.Location = new System.Drawing.Point(229, 109);
            this.s1a2Label.Name = "s1a2Label";
            this.s1a2Label.Size = new System.Drawing.Size(25, 13);
            this.s1a2Label.TabIndex = 26;
            this.s1a2Label.Text = "-a2:";
            // 
            // s1a2Select
            // 
            this.s1a2Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.s1a2Select.DecimalPlaces = 15;
            this.s1a2Select.Enabled = false;
            this.s1a2Select.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.s1a2Select.Location = new System.Drawing.Point(260, 107);
            this.s1a2Select.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.s1a2Select.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            -2147483648});
            this.s1a2Select.Name = "s1a2Select";
            this.s1a2Select.Size = new System.Drawing.Size(120, 20);
            this.s1a2Select.TabIndex = 25;
            // 
            // s1NegBox
            // 
            this.s1NegBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.s1NegBox.AutoSize = true;
            this.s1NegBox.Checked = true;
            this.s1NegBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.s1NegBox.Location = new System.Drawing.Point(260, 134);
            this.s1NegBox.Name = "s1NegBox";
            this.s1NegBox.Size = new System.Drawing.Size(94, 17);
            this.s1NegBox.TabIndex = 28;
            this.s1NegBox.Text = "Negate a1, a2";
            this.s1NegBox.UseVisualStyleBackColor = true;
            // 
            // s1SRSelect
            // 
            this.s1SRSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.s1SRSelect.Enabled = false;
            this.s1SRSelect.Location = new System.Drawing.Point(330, 157);
            this.s1SRSelect.Maximum = new decimal(new int[] {
            400000,
            0,
            0,
            0});
            this.s1SRSelect.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.s1SRSelect.Name = "s1SRSelect";
            this.s1SRSelect.Size = new System.Drawing.Size(120, 20);
            this.s1SRSelect.TabIndex = 29;
            this.s1SRSelect.Value = new decimal(new int[] {
            96000,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(231, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Sample Rate (Hz):";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 667);
            this.Controls.Add(this.mainSplit);
            this.Name = "MainForm";
            this.Text = "Speaker EQ Designer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.s1Panel.ResumeLayout(false);
            this.s1Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s1b0Select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1GainSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1QSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1FreqSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1FiltSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1b1Select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1b2Select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1a1Select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1a2Select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.s1SRSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView sumPlotView;
        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel s1Panel;
        private System.Windows.Forms.NumericUpDown s1b0Select;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button s1SpkResponse;
        private System.Windows.Forms.NumericUpDown s1GainSelect;
        private System.Windows.Forms.NumericUpDown s1QSelect;
        private System.Windows.Forms.NumericUpDown s1FreqSelect;
        private System.Windows.Forms.ComboBox s1TypeSelect;
        private System.Windows.Forms.Button s1FiltRemove;
        private System.Windows.Forms.Button s1FiltAdd;
        private System.Windows.Forms.NumericUpDown s1FiltSelect;
        private System.Windows.Forms.Label label1;
        private OxyPlot.WindowsForms.PlotView s1PlotView;
        private System.Windows.Forms.TextBox s1b0Hex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox s1a2Hex;
        private System.Windows.Forms.Label s1a2Label;
        private System.Windows.Forms.NumericUpDown s1a2Select;
        private System.Windows.Forms.TextBox s1a1Hex;
        private System.Windows.Forms.Label s1a1Label;
        private System.Windows.Forms.NumericUpDown s1a1Select;
        private System.Windows.Forms.TextBox s1b2Hex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown s1b2Select;
        private System.Windows.Forms.TextBox s1b1Hex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown s1b1Select;
        private System.Windows.Forms.CheckBox s1NegBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown s1SRSelect;
    }
}

