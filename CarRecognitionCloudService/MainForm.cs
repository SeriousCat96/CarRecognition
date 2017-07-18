using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace CarRecognitionCloudService
{
	public partial class MainForm : Form
	{

		ImageResizer _imageResizer;

		public MainForm()
		{
			InitializeComponent();

			_imageResizer = new ImageResizer();
			CallRequestResponseService.ConsoleTextbox = _tboxConsole;
		}

		public string FilePath { get; set; }

		private void DisplayImage(string path)
		{
			_picBoxOriginalImage.MaximumSize = new System.Drawing.Size(300, 250);
			_picBoxOriginalImage.Image = new Bitmap(path);

			var sizeX = _picBoxOriginalImage.Image.Width;
			var sizeY = _picBoxOriginalImage.Image.Height;

			_lblOriginal.Text = $"Original ({ sizeX }x{ sizeY })";
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Font = SystemFonts.MessageBoxFont;
			_tboxConsole.Font = new Font("Verdana", 14, System.Drawing.FontStyle.Regular);

			MinimumSize = Size;
			MaximumSize = Size;
		}

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//var dirPath = Directory.GetCurrentDirectory();
			var filter = "Image Files(*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png;";
			using(var fileDialog = new OpenFileDialog())
			{
				//fileDialog.InitialDirectory = dirPath;
				fileDialog.Filter = filter;
				if(fileDialog.ShowDialog(this) == DialogResult.OK)
				{
					FilePath = fileDialog.FileName;
					DisplayImage(FilePath);
				}

			}
		}

		private void OnButtonRecognize_Click(object sender, EventArgs e)
		{
			var filepath = _imageResizer.Resize(FilePath);
			_picBoxProcessedImage.Image = new Bitmap(filepath);

			var sizeX = _picBoxProcessedImage.Image.Width;
			var sizeY = _picBoxProcessedImage.Image.Height;

			_lblProcessed.Text = $"Processed ({ sizeX }x{ sizeY })";

			var openCvMat = new Mat(filepath, LoadMode.Color);

			Cv2.CvtColor(openCvMat, openCvMat, ColorConversion.BgrToHsv);

			CallRequestResponseService.Invoke(openCvMat);
		}
	}
}
