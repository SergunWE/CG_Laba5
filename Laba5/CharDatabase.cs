using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
	internal class CharDatabase
	{
		public Dictionary<char, int[]> _chars { get; private set; }

		private Bitmap _charsImage;
		private string _charsString;

		public Bitmap CharImage;
		public int[,] Matrix;

		public CharDatabase(Bitmap image, string charsString)
		{
			_charsImage = image;
			_charsString = charsString;

			Matrix = ImageHelper.ImageToMatrix(image);
			Matrix = ImageHelper.MatrixMarkup(Matrix);

			for(int i = 1; i <= ImageHelper.LatestCharNumber; i++)
			{
				var p = ImageHelper.GetCharPositions(Matrix, i);

				Bitmap charImage = new Bitmap(p.Item2.X - p.Item1.X, p.Item2.Y - p.Item1.Y);
				using (Graphics g = Graphics.FromImage(charImage))
				{
					g.DrawImage(image,0,0,new Rectangle(p.Item1, new Size(p.Item2.X - p.Item1.X, p.Item2.Y - p.Item1.Y)), GraphicsUnit.Pixel);
				}
				charImage = new Bitmap(charImage, 8, 8);
				var c = ImageHelper.ImageToMatrix(charImage);

				//for (i = 0; i < c.GetUpperBound(0) + 1; i++)
				//{
				//	for (int j = 0; j < c.Length / (c.GetUpperBound(0) + 1); j++)
				//	{
				//		Console.Write(c[i, j] + " ");
				//	}
				//	Console.WriteLine();
				//}

				//CharImage = charImage;
			}
		}
	}
}
