namespace Steganography
{
    partial class MainWindow
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
            this.mainTab = new System.Windows.Forms.TabControl();
            this.embedTab = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.destFileType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.destFile = new System.Windows.Forms.TextBox();
            this.bytesInPicture = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.embedButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.embedBitDepth = new System.Windows.Forms.ComboBox();
            this.embedPlane = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.embedContentType = new System.Windows.Forms.ComboBox();
            this.selectFileEmbed = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.embedFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.embedText = new System.Windows.Forms.TextBox();
            this.extractTab = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.extractedText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.extractBitDepth = new System.Windows.Forms.ComboBox();
            this.extractPlane = new System.Windows.Forms.ComboBox();
            this.extractButton = new System.Windows.Forms.Button();
            this.sourceFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectSourceFile = new System.Windows.Forms.Button();
            this.mainTab.SuspendLayout();
            this.embedTab.SuspendLayout();
            this.extractTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.embedTab);
            this.mainTab.Controls.Add(this.extractTab);
            this.mainTab.Enabled = false;
            this.mainTab.Location = new System.Drawing.Point(24, 91);
            this.mainTab.Margin = new System.Windows.Forms.Padding(6);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(1352, 792);
            this.mainTab.TabIndex = 0;
            // 
            // embedTab
            // 
            this.embedTab.Controls.Add(this.label12);
            this.embedTab.Controls.Add(this.destFileType);
            this.embedTab.Controls.Add(this.label11);
            this.embedTab.Controls.Add(this.destFile);
            this.embedTab.Controls.Add(this.bytesInPicture);
            this.embedTab.Controls.Add(this.label9);
            this.embedTab.Controls.Add(this.embedButton);
            this.embedTab.Controls.Add(this.label6);
            this.embedTab.Controls.Add(this.label5);
            this.embedTab.Controls.Add(this.embedBitDepth);
            this.embedTab.Controls.Add(this.embedPlane);
            this.embedTab.Controls.Add(this.label4);
            this.embedTab.Controls.Add(this.embedContentType);
            this.embedTab.Controls.Add(this.selectFileEmbed);
            this.embedTab.Controls.Add(this.label3);
            this.embedTab.Controls.Add(this.embedFile);
            this.embedTab.Controls.Add(this.label2);
            this.embedTab.Controls.Add(this.embedText);
            this.embedTab.Location = new System.Drawing.Point(4, 34);
            this.embedTab.Margin = new System.Windows.Forms.Padding(6);
            this.embedTab.Name = "embedTab";
            this.embedTab.Padding = new System.Windows.Forms.Padding(6);
            this.embedTab.Size = new System.Drawing.Size(1344, 754);
            this.embedTab.TabIndex = 0;
            this.embedTab.Text = "Embed";
            this.embedTab.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 136);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(212, 25);
            this.label12.TabIndex = 20;
            this.label12.Text = "Outbound file format:";
            // 
            // destFileType
            // 
            this.destFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destFileType.FormattingEnabled = true;
            this.destFileType.Items.AddRange(new object[] {
            "Bmp",
            "Png"});
            this.destFileType.Location = new System.Drawing.Point(34, 166);
            this.destFileType.Margin = new System.Windows.Forms.Padding(6);
            this.destFileType.Name = "destFileType";
            this.destFileType.Size = new System.Drawing.Size(396, 33);
            this.destFileType.TabIndex = 19;
            this.destFileType.SelectedIndexChanged += new System.EventHandler(this.destFileType_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 33);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 25);
            this.label11.TabIndex = 18;
            this.label11.Text = "Destination file:";
            // 
            // destFile
            // 
            this.destFile.Location = new System.Drawing.Point(34, 63);
            this.destFile.Margin = new System.Windows.Forms.Padding(6);
            this.destFile.Name = "destFile";
            this.destFile.Size = new System.Drawing.Size(1264, 31);
            this.destFile.TabIndex = 17;
            // 
            // bytesInPicture
            // 
            this.bytesInPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bytesInPicture.Location = new System.Drawing.Point(44, 599);
            this.bytesInPicture.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.bytesInPicture.Name = "bytesInPicture";
            this.bytesInPicture.Size = new System.Drawing.Size(336, 81);
            this.bytesInPicture.TabIndex = 16;
            this.bytesInPicture.Text = "N/A";
            this.bytesInPicture.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(80, 562);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(258, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "Bytes available in picture:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // embedButton
            // 
            this.embedButton.BackColor = System.Drawing.Color.Lime;
            this.embedButton.Location = new System.Drawing.Point(418, 520);
            this.embedButton.Margin = new System.Windows.Forms.Padding(6);
            this.embedButton.Name = "embedButton";
            this.embedButton.Size = new System.Drawing.Size(518, 212);
            this.embedButton.TabIndex = 14;
            this.embedButton.Text = "Embed >>";
            this.embedButton.UseVisualStyleBackColor = false;
            this.embedButton.Click += new System.EventHandler(this.embedButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(722, 409);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Embedding bit depth:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 409);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(332, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Color plane(s) in which to embed:";
            // 
            // embedBitDepth
            // 
            this.embedBitDepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.embedBitDepth.FormattingEnabled = true;
            this.embedBitDepth.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.embedBitDepth.Location = new System.Drawing.Point(716, 439);
            this.embedBitDepth.Margin = new System.Windows.Forms.Padding(6);
            this.embedBitDepth.Name = "embedBitDepth";
            this.embedBitDepth.Size = new System.Drawing.Size(582, 33);
            this.embedBitDepth.TabIndex = 11;
            this.embedBitDepth.SelectedIndexChanged += new System.EventHandler(this.inputEmbeddingChanged_SelectedIndexChanged);
            // 
            // embedPlane
            // 
            this.embedPlane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.embedPlane.FormattingEnabled = true;
            this.embedPlane.Items.AddRange(new object[] {
            "R",
            "G",
            "B",
            "RGB"});
            this.embedPlane.Location = new System.Drawing.Point(34, 439);
            this.embedPlane.Margin = new System.Windows.Forms.Padding(6);
            this.embedPlane.Name = "embedPlane";
            this.embedPlane.Size = new System.Drawing.Size(582, 33);
            this.embedPlane.TabIndex = 10;
            this.embedPlane.SelectedIndexChanged += new System.EventHandler(this.inputEmbeddingChanged_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 223);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(262, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Type of content to embed:";
            // 
            // embedContentType
            // 
            this.embedContentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.embedContentType.FormattingEnabled = true;
            this.embedContentType.Items.AddRange(new object[] {
            "Text",
            "File"});
            this.embedContentType.Location = new System.Drawing.Point(34, 254);
            this.embedContentType.Margin = new System.Windows.Forms.Padding(6);
            this.embedContentType.Name = "embedContentType";
            this.embedContentType.Size = new System.Drawing.Size(396, 33);
            this.embedContentType.TabIndex = 8;
            this.embedContentType.SelectedIndexChanged += new System.EventHandler(this.embedContentType_SelectedIndexChanged);
            // 
            // selectFileEmbed
            // 
            this.selectFileEmbed.Location = new System.Drawing.Point(1100, 346);
            this.selectFileEmbed.Margin = new System.Windows.Forms.Padding(6);
            this.selectFileEmbed.Name = "selectFileEmbed";
            this.selectFileEmbed.Size = new System.Drawing.Size(198, 42);
            this.selectFileEmbed.TabIndex = 7;
            this.selectFileEmbed.Text = "Select File >>";
            this.selectFileEmbed.UseVisualStyleBackColor = true;
            this.selectFileEmbed.Click += new System.EventHandler(this.selectFileEmbed_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 322);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "File to embed:";
            // 
            // embedFile
            // 
            this.embedFile.Location = new System.Drawing.Point(34, 352);
            this.embedFile.Margin = new System.Windows.Forms.Padding(6);
            this.embedFile.Name = "embedFile";
            this.embedFile.Size = new System.Drawing.Size(1054, 31);
            this.embedFile.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(476, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Text to embed:";
            // 
            // embedText
            // 
            this.embedText.Location = new System.Drawing.Point(470, 166);
            this.embedText.Margin = new System.Windows.Forms.Padding(6);
            this.embedText.Multiline = true;
            this.embedText.Name = "embedText";
            this.embedText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.embedText.Size = new System.Drawing.Size(828, 123);
            this.embedText.TabIndex = 3;
            // 
            // extractTab
            // 
            this.extractTab.Controls.Add(this.label13);
            this.extractTab.Controls.Add(this.label10);
            this.extractTab.Controls.Add(this.extractedText);
            this.extractTab.Controls.Add(this.label7);
            this.extractTab.Controls.Add(this.label8);
            this.extractTab.Controls.Add(this.extractBitDepth);
            this.extractTab.Controls.Add(this.extractPlane);
            this.extractTab.Controls.Add(this.extractButton);
            this.extractTab.Location = new System.Drawing.Point(4, 34);
            this.extractTab.Margin = new System.Windows.Forms.Padding(6);
            this.extractTab.Name = "extractTab";
            this.extractTab.Padding = new System.Windows.Forms.Padding(6);
            this.extractTab.Size = new System.Drawing.Size(1344, 754);
            this.extractTab.TabIndex = 1;
            this.extractTab.Text = "Extract";
            this.extractTab.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(418, 447);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(518, 55);
            this.label13.TabIndex = 24;
            this.label13.Text = "Note: If a file is extracted, it is placed in the directory of the source file";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 137);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 25);
            this.label10.TabIndex = 23;
            this.label10.Text = "Extracted text:";
            // 
            // extractedText
            // 
            this.extractedText.Location = new System.Drawing.Point(34, 167);
            this.extractedText.Margin = new System.Windows.Forms.Padding(6);
            this.extractedText.Multiline = true;
            this.extractedText.Name = "extractedText";
            this.extractedText.ReadOnly = true;
            this.extractedText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.extractedText.Size = new System.Drawing.Size(1264, 261);
            this.extractedText.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(722, 24);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 25);
            this.label7.TabIndex = 21;
            this.label7.Text = "Extracting bit depth:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(357, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "Color plane(s) from which to extract:";
            // 
            // extractBitDepth
            // 
            this.extractBitDepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.extractBitDepth.FormattingEnabled = true;
            this.extractBitDepth.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.extractBitDepth.Location = new System.Drawing.Point(716, 54);
            this.extractBitDepth.Margin = new System.Windows.Forms.Padding(6);
            this.extractBitDepth.Name = "extractBitDepth";
            this.extractBitDepth.Size = new System.Drawing.Size(582, 33);
            this.extractBitDepth.TabIndex = 19;
            // 
            // extractPlane
            // 
            this.extractPlane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.extractPlane.FormattingEnabled = true;
            this.extractPlane.Items.AddRange(new object[] {
            "R",
            "G",
            "B",
            "RGB"});
            this.extractPlane.Location = new System.Drawing.Point(34, 54);
            this.extractPlane.Margin = new System.Windows.Forms.Padding(6);
            this.extractPlane.Name = "extractPlane";
            this.extractPlane.Size = new System.Drawing.Size(582, 33);
            this.extractPlane.TabIndex = 18;
            // 
            // extractButton
            // 
            this.extractButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.extractButton.Location = new System.Drawing.Point(418, 520);
            this.extractButton.Margin = new System.Windows.Forms.Padding(6);
            this.extractButton.Name = "extractButton";
            this.extractButton.Size = new System.Drawing.Size(518, 212);
            this.extractButton.TabIndex = 15;
            this.extractButton.Text = "<< Extract";
            this.extractButton.UseVisualStyleBackColor = false;
            this.extractButton.Click += new System.EventHandler(this.extractButton_Click);
            // 
            // sourceFile
            // 
            this.sourceFile.Location = new System.Drawing.Point(24, 44);
            this.sourceFile.Margin = new System.Windows.Forms.Padding(6);
            this.sourceFile.Name = "sourceFile";
            this.sourceFile.Size = new System.Drawing.Size(1138, 31);
            this.sourceFile.TabIndex = 1;
            this.sourceFile.TextChanged += new System.EventHandler(this.sourceFile_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source file:";
            // 
            // selectSourceFile
            // 
            this.selectSourceFile.Location = new System.Drawing.Point(1174, 38);
            this.selectSourceFile.Margin = new System.Windows.Forms.Padding(6);
            this.selectSourceFile.Name = "selectSourceFile";
            this.selectSourceFile.Size = new System.Drawing.Size(198, 42);
            this.selectSourceFile.TabIndex = 3;
            this.selectSourceFile.Text = "Select File >>";
            this.selectSourceFile.UseVisualStyleBackColor = true;
            this.selectSourceFile.Click += new System.EventHandler(this.selectSourceFile_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1400, 892);
            this.Controls.Add(this.selectSourceFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sourceFile);
            this.Controls.Add(this.mainTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Steganography Tool by William M Mortl";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.mainTab.ResumeLayout(false);
            this.embedTab.ResumeLayout(false);
            this.embedTab.PerformLayout();
            this.extractTab.ResumeLayout(false);
            this.extractTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage embedTab;
        private System.Windows.Forms.TabPage extractTab;
        private System.Windows.Forms.TextBox sourceFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectSourceFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox embedText;
        private System.Windows.Forms.Button selectFileEmbed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox embedFile;
        private System.Windows.Forms.ComboBox embedContentType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox embedBitDepth;
        private System.Windows.Forms.ComboBox embedPlane;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button embedButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox extractBitDepth;
        private System.Windows.Forms.ComboBox extractPlane;
        private System.Windows.Forms.Button extractButton;
        private System.Windows.Forms.Label bytesInPicture;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox extractedText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox destFile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox destFileType;
        private System.Windows.Forms.Label label13;
    }
}

