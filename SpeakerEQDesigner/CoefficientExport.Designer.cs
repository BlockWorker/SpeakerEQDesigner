namespace SpeakerEQDesigner {
    partial class CoefficientExport {
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.channel1Box = new System.Windows.Forms.TextBox();
            this.channel2Box = new System.Windows.Forms.TextBox();
            this.lineLengthSelect = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gain2Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gain1Box = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lineLengthSelect)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 228);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Channel 2:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 469);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Max line length:";
            // 
            // channel1Box
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.channel1Box, 2);
            this.channel1Box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channel1Box.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channel1Box.Location = new System.Drawing.Point(3, 33);
            this.channel1Box.Multiline = true;
            this.channel1Box.Name = "channel1Box";
            this.channel1Box.ReadOnly = true;
            this.channel1Box.Size = new System.Drawing.Size(852, 188);
            this.channel1Box.TabIndex = 3;
            this.channel1Box.WordWrap = false;
            // 
            // channel2Box
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.channel2Box, 2);
            this.channel2Box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channel2Box.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channel2Box.Location = new System.Drawing.Point(3, 257);
            this.channel2Box.Multiline = true;
            this.channel2Box.Name = "channel2Box";
            this.channel2Box.ReadOnly = true;
            this.channel2Box.Size = new System.Drawing.Size(852, 189);
            this.channel2Box.TabIndex = 4;
            this.channel2Box.WordWrap = false;
            // 
            // lineLengthSelect
            // 
            this.lineLengthSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lineLengthSelect.Location = new System.Drawing.Point(99, 467);
            this.lineLengthSelect.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.lineLengthSelect.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.lineLengthSelect.Name = "lineLengthSelect";
            this.lineLengthSelect.Size = new System.Drawing.Size(69, 20);
            this.lineLengthSelect.TabIndex = 5;
            this.lineLengthSelect.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.lineLengthSelect.ValueChanged += new System.EventHandler(this.lineLengthSelect_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gain2Box, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.channel1Box, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.channel2Box, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.gain1Box, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(858, 449);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // gain2Box
            // 
            this.gain2Box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gain2Box.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gain2Box.Location = new System.Drawing.Point(432, 227);
            this.gain2Box.Name = "gain2Box";
            this.gain2Box.ReadOnly = true;
            this.gain2Box.Size = new System.Drawing.Size(423, 23);
            this.gain2Box.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Channel1:";
            // 
            // gain1Box
            // 
            this.gain1Box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gain1Box.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gain1Box.Location = new System.Drawing.Point(432, 3);
            this.gain1Box.Name = "gain1Box";
            this.gain1Box.ReadOnly = true;
            this.gain1Box.Size = new System.Drawing.Size(423, 23);
            this.gain1Box.TabIndex = 6;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(771, 464);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(99, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // CoefficientExport
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(882, 499);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lineLengthSelect);
            this.Controls.Add(this.label3);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "CoefficientExport";
            this.Text = "Export coefficients";
            this.Load += new System.EventHandler(this.CoefficientExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lineLengthSelect)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox channel1Box;
        private System.Windows.Forms.TextBox channel2Box;
        private System.Windows.Forms.NumericUpDown lineLengthSelect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox gain2Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox gain1Box;
    }
}