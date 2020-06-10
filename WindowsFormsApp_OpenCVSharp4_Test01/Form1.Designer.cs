namespace WindowsFormsApp_OpenCVSharp4_Test01 {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.picBoxSrc = new System.Windows.Forms.PictureBox();
            this.picBoxDst = new System.Windows.Forms.PictureBox();
            this.btnCaptureStart = new System.Windows.Forms.Button();
            this.btnCaptureEnd = new System.Windows.Forms.Button();
            this.btnGetStillImage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdBtn_CaptureEnd = new System.Windows.Forms.RadioButton();
            this.rdBtn_CaptureStart = new System.Windows.Forms.RadioButton();
            this.btnLoadPicture = new System.Windows.Forms.Button();
            this.btnSavePicture = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnCopyPicture = new System.Windows.Forms.Button();
            this.btnThreshold = new System.Windows.Forms.Button();
            this.grpThreshold = new System.Windows.Forms.GroupBox();
            this.btnLabelling = new System.Windows.Forms.Button();
            this.trackBarThreshold = new System.Windows.Forms.TrackBar();
            this.picBoxLive = new System.Windows.Forms.PictureBox();
            this.picBoxSrcGray = new System.Windows.Forms.PictureBox();
            this.picBoxSrcGreen = new System.Windows.Forms.PictureBox();
            this.picBoxSrcRed = new System.Windows.Forms.PictureBox();
            this.picBoxSrcBlue = new System.Windows.Forms.PictureBox();
            this.btn_tesseract_ocr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDst)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpThreshold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSrcGray)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSrcGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSrcRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSrcBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // picBoxSrc
            // 
            this.picBoxSrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.picBoxSrc.Location = new System.Drawing.Point(639, 59);
            this.picBoxSrc.Name = "picBoxSrc";
            this.picBoxSrc.Size = new System.Drawing.Size(320, 240);
            this.picBoxSrc.TabIndex = 0;
            this.picBoxSrc.TabStop = false;
            // 
            // picBoxDst
            // 
            this.picBoxDst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.picBoxDst.Location = new System.Drawing.Point(1327, 59);
            this.picBoxDst.Name = "picBoxDst";
            this.picBoxDst.Size = new System.Drawing.Size(320, 240);
            this.picBoxDst.TabIndex = 1;
            this.picBoxDst.TabStop = false;
            // 
            // btnCaptureStart
            // 
            this.btnCaptureStart.Location = new System.Drawing.Point(18, 89);
            this.btnCaptureStart.Name = "btnCaptureStart";
            this.btnCaptureStart.Size = new System.Drawing.Size(93, 37);
            this.btnCaptureStart.TabIndex = 2;
            this.btnCaptureStart.Text = "キャプチャ開始";
            this.btnCaptureStart.UseVisualStyleBackColor = true;
            this.btnCaptureStart.Click += new System.EventHandler(this.btnCaptureStart_Click);
            // 
            // btnCaptureEnd
            // 
            this.btnCaptureEnd.Location = new System.Drawing.Point(19, 132);
            this.btnCaptureEnd.Name = "btnCaptureEnd";
            this.btnCaptureEnd.Size = new System.Drawing.Size(92, 37);
            this.btnCaptureEnd.TabIndex = 3;
            this.btnCaptureEnd.Text = "キャプチャ終了";
            this.btnCaptureEnd.UseVisualStyleBackColor = true;
            this.btnCaptureEnd.Click += new System.EventHandler(this.btnCaptureEnd_Click);
            // 
            // btnGetStillImage
            // 
            this.btnGetStillImage.Location = new System.Drawing.Point(117, 89);
            this.btnGetStillImage.Name = "btnGetStillImage";
            this.btnGetStillImage.Size = new System.Drawing.Size(92, 79);
            this.btnGetStillImage.TabIndex = 4;
            this.btnGetStillImage.Text = "静止画取込";
            this.btnGetStillImage.UseVisualStyleBackColor = true;
            this.btnGetStillImage.Click += new System.EventHandler(this.btnGetStillImage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdBtn_CaptureEnd);
            this.groupBox1.Controls.Add(this.btnGetStillImage);
            this.groupBox1.Controls.Add(this.btnCaptureEnd);
            this.groupBox1.Controls.Add(this.rdBtn_CaptureStart);
            this.groupBox1.Controls.Add(this.btnCaptureStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 199);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // rdBtn_CaptureEnd
            // 
            this.rdBtn_CaptureEnd.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdBtn_CaptureEnd.AutoSize = true;
            this.rdBtn_CaptureEnd.Location = new System.Drawing.Point(139, 29);
            this.rdBtn_CaptureEnd.Name = "rdBtn_CaptureEnd";
            this.rdBtn_CaptureEnd.Size = new System.Drawing.Size(83, 22);
            this.rdBtn_CaptureEnd.TabIndex = 1;
            this.rdBtn_CaptureEnd.TabStop = true;
            this.rdBtn_CaptureEnd.Text = "キャプチャ終了";
            this.rdBtn_CaptureEnd.UseVisualStyleBackColor = true;
            // 
            // rdBtn_CaptureStart
            // 
            this.rdBtn_CaptureStart.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdBtn_CaptureStart.AutoSize = true;
            this.rdBtn_CaptureStart.Location = new System.Drawing.Point(20, 29);
            this.rdBtn_CaptureStart.Name = "rdBtn_CaptureStart";
            this.rdBtn_CaptureStart.Size = new System.Drawing.Size(83, 22);
            this.rdBtn_CaptureStart.TabIndex = 0;
            this.rdBtn_CaptureStart.TabStop = true;
            this.rdBtn_CaptureStart.Text = "キャプチャ開始";
            this.rdBtn_CaptureStart.UseVisualStyleBackColor = true;
            // 
            // btnLoadPicture
            // 
            this.btnLoadPicture.Location = new System.Drawing.Point(639, 17);
            this.btnLoadPicture.Name = "btnLoadPicture";
            this.btnLoadPicture.Size = new System.Drawing.Size(81, 36);
            this.btnLoadPicture.TabIndex = 6;
            this.btnLoadPicture.Text = "画像読込";
            this.btnLoadPicture.UseVisualStyleBackColor = true;
            this.btnLoadPicture.Click += new System.EventHandler(this.btnLoadPicture_Click);
            // 
            // btnSavePicture
            // 
            this.btnSavePicture.Location = new System.Drawing.Point(1414, 17);
            this.btnSavePicture.Name = "btnSavePicture";
            this.btnSavePicture.Size = new System.Drawing.Size(81, 36);
            this.btnSavePicture.TabIndex = 7;
            this.btnSavePicture.Text = "画像保存";
            this.btnSavePicture.UseVisualStyleBackColor = true;
            this.btnSavePicture.Click += new System.EventHandler(this.btnSavePicture_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // btnCopyPicture
            // 
            this.btnCopyPicture.Location = new System.Drawing.Point(1327, 17);
            this.btnCopyPicture.Name = "btnCopyPicture";
            this.btnCopyPicture.Size = new System.Drawing.Size(81, 36);
            this.btnCopyPicture.TabIndex = 8;
            this.btnCopyPicture.Text = "pic1からコピー";
            this.btnCopyPicture.UseVisualStyleBackColor = true;
            this.btnCopyPicture.Click += new System.EventHandler(this.btnCopyPicture_Click);
            // 
            // btnThreshold
            // 
            this.btnThreshold.Location = new System.Drawing.Point(21, 31);
            this.btnThreshold.Name = "btnThreshold";
            this.btnThreshold.Size = new System.Drawing.Size(77, 32);
            this.btnThreshold.TabIndex = 9;
            this.btnThreshold.Text = "2値化";
            this.btnThreshold.UseVisualStyleBackColor = true;
            this.btnThreshold.Click += new System.EventHandler(this.btnThreshold_Click);
            // 
            // grpThreshold
            // 
            this.grpThreshold.Controls.Add(this.btnLabelling);
            this.grpThreshold.Controls.Add(this.trackBarThreshold);
            this.grpThreshold.Controls.Add(this.btnThreshold);
            this.grpThreshold.Location = new System.Drawing.Point(12, 222);
            this.grpThreshold.Name = "grpThreshold";
            this.grpThreshold.Size = new System.Drawing.Size(230, 249);
            this.grpThreshold.TabIndex = 10;
            this.grpThreshold.TabStop = false;
            this.grpThreshold.Text = "2値化";
            // 
            // btnLabelling
            // 
            this.btnLabelling.Location = new System.Drawing.Point(32, 164);
            this.btnLabelling.Name = "btnLabelling";
            this.btnLabelling.Size = new System.Drawing.Size(98, 30);
            this.btnLabelling.TabIndex = 11;
            this.btnLabelling.Text = "ラベリング";
            this.btnLabelling.UseVisualStyleBackColor = true;
            this.btnLabelling.Click += new System.EventHandler(this.btnLabelling_Click);
            // 
            // trackBarThreshold
            // 
            this.trackBarThreshold.Location = new System.Drawing.Point(30, 87);
            this.trackBarThreshold.Maximum = 255;
            this.trackBarThreshold.Name = "trackBarThreshold";
            this.trackBarThreshold.Size = new System.Drawing.Size(178, 45);
            this.trackBarThreshold.TabIndex = 10;
            this.trackBarThreshold.Value = 127;
            this.trackBarThreshold.ValueChanged += new System.EventHandler(this.trackBarThreshold_ValueChanged);
            // 
            // picBoxLive
            // 
            this.picBoxLive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.picBoxLive.Location = new System.Drawing.Point(299, 59);
            this.picBoxLive.Name = "picBoxLive";
            this.picBoxLive.Size = new System.Drawing.Size(320, 240);
            this.picBoxLive.TabIndex = 11;
            this.picBoxLive.TabStop = false;
            // 
            // picBoxSrcGray
            // 
            this.picBoxSrcGray.BackColor = System.Drawing.Color.Silver;
            this.picBoxSrcGray.Location = new System.Drawing.Point(639, 309);
            this.picBoxSrcGray.Name = "picBoxSrcGray";
            this.picBoxSrcGray.Size = new System.Drawing.Size(320, 240);
            this.picBoxSrcGray.TabIndex = 12;
            this.picBoxSrcGray.TabStop = false;
            // 
            // picBoxSrcGreen
            // 
            this.picBoxSrcGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.picBoxSrcGreen.Location = new System.Drawing.Point(984, 59);
            this.picBoxSrcGreen.Name = "picBoxSrcGreen";
            this.picBoxSrcGreen.Size = new System.Drawing.Size(320, 240);
            this.picBoxSrcGreen.TabIndex = 13;
            this.picBoxSrcGreen.TabStop = false;
            // 
            // picBoxSrcRed
            // 
            this.picBoxSrcRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.picBoxSrcRed.Location = new System.Drawing.Point(984, 309);
            this.picBoxSrcRed.Name = "picBoxSrcRed";
            this.picBoxSrcRed.Size = new System.Drawing.Size(320, 240);
            this.picBoxSrcRed.TabIndex = 14;
            this.picBoxSrcRed.TabStop = false;
            // 
            // picBoxSrcBlue
            // 
            this.picBoxSrcBlue.BackColor = System.Drawing.Color.Aqua;
            this.picBoxSrcBlue.Location = new System.Drawing.Point(984, 567);
            this.picBoxSrcBlue.Name = "picBoxSrcBlue";
            this.picBoxSrcBlue.Size = new System.Drawing.Size(320, 240);
            this.picBoxSrcBlue.TabIndex = 15;
            this.picBoxSrcBlue.TabStop = false;
            // 
            // btn_tesseract_ocr
            // 
            this.btn_tesseract_ocr.Location = new System.Drawing.Point(43, 506);
            this.btn_tesseract_ocr.Name = "btn_tesseract_ocr";
            this.btn_tesseract_ocr.Size = new System.Drawing.Size(71, 42);
            this.btn_tesseract_ocr.TabIndex = 16;
            this.btn_tesseract_ocr.Text = "tesseract OCR";
            this.btn_tesseract_ocr.UseVisualStyleBackColor = true;
            this.btn_tesseract_ocr.Click += new System.EventHandler(this.btn_tesseract_ocr_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1666, 770);
            this.Controls.Add(this.btn_tesseract_ocr);
            this.Controls.Add(this.picBoxSrcBlue);
            this.Controls.Add(this.picBoxSrcRed);
            this.Controls.Add(this.picBoxSrcGreen);
            this.Controls.Add(this.picBoxSrcGray);
            this.Controls.Add(this.picBoxLive);
            this.Controls.Add(this.grpThreshold);
            this.Controls.Add(this.btnCopyPicture);
            this.Controls.Add(this.btnSavePicture);
            this.Controls.Add(this.btnLoadPicture);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picBoxDst);
            this.Controls.Add(this.picBoxSrc);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDst)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpThreshold.ResumeLayout(false);
            this.grpThreshold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSrcGray)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSrcGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSrcRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSrcBlue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox picBoxSrc;
        private System.Windows.Forms.PictureBox picBoxDst;
        private System.Windows.Forms.Button btnCaptureStart;
        private System.Windows.Forms.Button btnCaptureEnd;
        private System.Windows.Forms.Button btnGetStillImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdBtn_CaptureEnd;
        private System.Windows.Forms.RadioButton rdBtn_CaptureStart;
        private System.Windows.Forms.Button btnLoadPicture;
        private System.Windows.Forms.Button btnSavePicture;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnCopyPicture;
        private System.Windows.Forms.Button btnThreshold;
        private System.Windows.Forms.GroupBox grpThreshold;
        private System.Windows.Forms.TrackBar trackBarThreshold;
        private System.Windows.Forms.PictureBox picBoxLive;
        private System.Windows.Forms.PictureBox picBoxSrcGray;
        private System.Windows.Forms.PictureBox picBoxSrcGreen;
        private System.Windows.Forms.PictureBox picBoxSrcRed;
        private System.Windows.Forms.PictureBox picBoxSrcBlue;
        private System.Windows.Forms.Button btnLabelling;
        private System.Windows.Forms.Button btn_tesseract_ocr;
    }
}

