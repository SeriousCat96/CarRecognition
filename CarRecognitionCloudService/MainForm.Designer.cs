namespace CarRecognitionCloudService
{
	partial class MainForm
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
			if(disposing && (components != null))
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._picBoxOriginalImage = new System.Windows.Forms.PictureBox();
			this._lblOriginal = new System.Windows.Forms.Label();
			this._picBoxProcessedImage = new System.Windows.Forms.PictureBox();
			this._lblProcessed = new System.Windows.Forms.Label();
			this._tboxConsole = new System.Windows.Forms.TextBox();
			this._btnRecognize = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._picBoxOriginalImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._picBoxProcessedImage)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(784, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// _fileToolStripMenuItem
			// 
			this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openToolStripMenuItem});
			this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
			this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this._fileToolStripMenuItem.Text = "File";
			// 
			// _openToolStripMenuItem
			// 
			this._openToolStripMenuItem.Name = "_openToolStripMenuItem";
			this._openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this._openToolStripMenuItem.Text = "Open";
			this._openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// _picBoxOriginalImage
			// 
			this._picBoxOriginalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._picBoxOriginalImage.Location = new System.Drawing.Point(12, 44);
			this._picBoxOriginalImage.Name = "_picBoxOriginalImage";
			this._picBoxOriginalImage.Size = new System.Drawing.Size(332, 273);
			this._picBoxOriginalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this._picBoxOriginalImage.TabIndex = 1;
			this._picBoxOriginalImage.TabStop = false;
			// 
			// _lblOriginal
			// 
			this._lblOriginal.AutoSize = true;
			this._lblOriginal.Location = new System.Drawing.Point(13, 28);
			this._lblOriginal.Name = "label1";
			this._lblOriginal.Size = new System.Drawing.Size(42, 13);
			this._lblOriginal.TabIndex = 2;
			this._lblOriginal.Text = "Original";
			// 
			// _picBoxProcessedImage
			// 
			this._picBoxProcessedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._picBoxProcessedImage.Location = new System.Drawing.Point(440, 44);
			this._picBoxProcessedImage.Name = "_picBoxProcessedImage";
			this._picBoxProcessedImage.Size = new System.Drawing.Size(332, 273);
			this._picBoxProcessedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this._picBoxProcessedImage.TabIndex = 1;
			this._picBoxProcessedImage.TabStop = false;
			// 
			// _lblProcessed
			// 
			this._lblProcessed.AutoSize = true;
			this._lblProcessed.Location = new System.Drawing.Point(437, 28);
			this._lblProcessed.Name = "_lblProcessed";
			this._lblProcessed.Size = new System.Drawing.Size(57, 13);
			this._lblProcessed.TabIndex = 2;
			this._lblProcessed.Text = "Processed";
			// 
			// _tboxConsole
			// 
			this._tboxConsole.Location = new System.Drawing.Point(12, 332);
			this._tboxConsole.Multiline = true;
			this._tboxConsole.Name = "_tboxConsole";
			this._tboxConsole.ReadOnly = true;
			this._tboxConsole.Size = new System.Drawing.Size(760, 100);
			this._tboxConsole.TabIndex = 3;
			// 
			// _btnRecognize
			// 
			this._btnRecognize.Location = new System.Drawing.Point(12, 438);
			this._btnRecognize.Name = "_btnRecognize";
			this._btnRecognize.Size = new System.Drawing.Size(156, 33);
			this._btnRecognize.TabIndex = 4;
			this._btnRecognize.Text = "Recognize";
			this._btnRecognize.UseVisualStyleBackColor = true;
			this._btnRecognize.Click += new System.EventHandler(this.OnButtonRecognize_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 482);
			this.Controls.Add(this._btnRecognize);
			this.Controls.Add(this._tboxConsole);
			this.Controls.Add(this._lblProcessed);
			this.Controls.Add(this._lblOriginal);
			this.Controls.Add(this._picBoxProcessedImage);
			this.Controls.Add(this._picBoxOriginalImage);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "CarRecognizer";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._picBoxOriginalImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._picBoxProcessedImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem _openToolStripMenuItem;
		private System.Windows.Forms.PictureBox _picBoxOriginalImage;
		private System.Windows.Forms.Label _lblOriginal;
		private System.Windows.Forms.PictureBox _picBoxProcessedImage;
		private System.Windows.Forms.Label _lblProcessed;
		private System.Windows.Forms.TextBox _tboxConsole;
		private System.Windows.Forms.Button _btnRecognize;
	}
}

