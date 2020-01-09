namespace SpeakerEQDesigner {
    partial class SpeakerResponseForm {
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
            this.plotView = new OxyPlot.WindowsForms.PlotView();
            this.pointSelect = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splSelect = new System.Windows.Forms.NumericUpDown();
            this.freqSelect = new System.Windows.Forms.NumericUpDown();
            this.okButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.pointNumberLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pointSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freqSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // plotView
            // 
            this.plotView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotView.BackColor = System.Drawing.Color.White;
            this.plotView.Location = new System.Drawing.Point(12, 12);
            this.plotView.Name = "plotView";
            this.plotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView.Size = new System.Drawing.Size(769, 423);
            this.plotView.TabIndex = 0;
            this.plotView.Text = "plotView";
            this.plotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // pointSelect
            // 
            this.pointSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pointSelect.Location = new System.Drawing.Point(108, 467);
            this.pointSelect.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.pointSelect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pointSelect.Name = "pointSelect";
            this.pointSelect.Size = new System.Drawing.Size(57, 20);
            this.pointSelect.TabIndex = 2;
            this.pointSelect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pointSelect.ValueChanged += new System.EventHandler(this.pointSelect_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 443);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of points:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 469);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current point:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 469);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Current point SPL (dB):";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 443);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Current point frequency (Hz):";
            // 
            // splSelect
            // 
            this.splSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.splSelect.DecimalPlaces = 1;
            this.splSelect.Location = new System.Drawing.Point(336, 467);
            this.splSelect.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.splSelect.Name = "splSelect";
            this.splSelect.Size = new System.Drawing.Size(57, 20);
            this.splSelect.TabIndex = 6;
            this.splSelect.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.splSelect.ValueChanged += new System.EventHandler(this.splSelect_ValueChanged);
            // 
            // freqSelect
            // 
            this.freqSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.freqSelect.Enabled = false;
            this.freqSelect.Location = new System.Drawing.Point(336, 441);
            this.freqSelect.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.freqSelect.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.freqSelect.Name = "freqSelect";
            this.freqSelect.Size = new System.Drawing.Size(57, 20);
            this.freqSelect.TabIndex = 5;
            this.freqSelect.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.freqSelect.ValueChanged += new System.EventHandler(this.freqSelect_ValueChanged);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(706, 462);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // insertButton
            // 
            this.insertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.insertButton.Location = new System.Drawing.Point(411, 441);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(115, 23);
            this.insertButton.TabIndex = 10;
            this.insertButton.Text = "Insert point after this";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // pointNumberLabel
            // 
            this.pointNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pointNumberLabel.AutoSize = true;
            this.pointNumberLabel.Location = new System.Drawing.Point(108, 443);
            this.pointNumberLabel.Name = "pointNumberLabel";
            this.pointNumberLabel.Size = new System.Drawing.Size(13, 13);
            this.pointNumberLabel.TabIndex = 11;
            this.pointNumberLabel.Text = "2";
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(411, 467);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(115, 23);
            this.deleteButton.TabIndex = 12;
            this.deleteButton.Text = "Delete this point";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // SpeakerResponseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 497);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.pointNumberLabel);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.splSelect);
            this.Controls.Add(this.freqSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pointSelect);
            this.Controls.Add(this.plotView);
            this.Name = "SpeakerResponseForm";
            this.Text = "Edit Speaker Response";
            this.Load += new System.EventHandler(this.SpeakerResponseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pointSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freqSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OxyPlot.WindowsForms.PlotView plotView;
        private System.Windows.Forms.NumericUpDown pointSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown splSelect;
        private System.Windows.Forms.NumericUpDown freqSelect;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Label pointNumberLabel;
        private System.Windows.Forms.Button deleteButton;
    }
}