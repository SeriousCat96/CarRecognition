using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace CarRecognitionCloudService
{
	public class ImageResizer
	{
		private const int ImgWidth = 50;
		private const double Ratio = 1.15;
		private const int ImgHeight = (int)(ImgWidth * (1 / Ratio));

		/// <summary> If image hasn't already resized function saves resized image in working directory.
		/// Else it saves image in its directory. </summary>
		/// <param name="filename"> Full image file path. </param>
		/// <returns> Returns saved image file directory. </returns>
		public string Resize(string filename)
		{
			var mat = new Mat(filename);

			if(mat.Width != ImgWidth || mat.Height != ImgHeight)
			{
				mat = GetResizedMat(mat, ImgWidth, ImgHeight);
				var path = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(filename));

				mat.SaveImage(path);
				return path;
			}

			return filename;
		}

		private Mat GetResizedMat(Mat src, int width, int height)
		{
			return src.Resize(
				new Size(width, height),
				fx: 1.0,
				fy: 1.0,
				interpolation: Interpolation.Cubic);
		}
	}
}
