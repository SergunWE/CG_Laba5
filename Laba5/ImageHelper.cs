using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
	internal class ImageHelper
	{
		public static int[,] ImageToMatrix(Bitmap image)
		{
			int[,] matrix = new int[image.Height, image.Width];

			int iStop = image.Width - 1;
			int i = 0, j = 0;

			BitmapData bmpData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			unsafe
			{
				byte* ptr = (byte*)bmpData.Scan0.ToPointer();
				int stopAddress = (int)ptr + bmpData.Stride * bmpData.Height;

				while ((int)ptr < stopAddress)
				{
					matrix[j, i] = ptr[0] == 0 ? 0 : 1;

					if (i >= iStop)
					{
						j++;
						i = 0;
					}
					else
					{
						i++;
					}

					ptr += 4;
				}
			}
			image.UnlockBits(bmpData);
			return matrix;
		}

		public static int LatestCharNumber = 0;

		public static int[,] MatrixMarkup(int[,] img)
		{
			int H = img.GetUpperBound(0) + 1;
			int W = img.Length / H;

			int[,] labels = new int[H, W];
			LatestCharNumber = 0;

			for (int y = 0; y < H; y++)
			{
				for (int x = 0; x < W; x++)
				{
					if (Fill(img, labels, x, y, LatestCharNumber + 1, W, H))
					{
						LatestCharNumber++;
					}
				}
			}
			return labels;
		}

		public static void OutlineColorChars(Bitmap image, int[,] labels)
		{
			for(int i = 1; i <= LatestCharNumber; i++)
			{
				var t = GetCharPositions(labels, i);
				using (Graphics g = Graphics.FromImage(image))
				{
					g.DrawRectangle(new Pen(Color.FromKnownColor(KnownColor.Red), 1), 
						new Rectangle(t.Item1, new Size(t.Item2.X - t.Item1.X, t.Item2.Y - t.Item1.Y)));
				}
			}
		}

		public static (Point,Point) GetCharPositions(int[,] img, int charsNumber)
		{
			int H = img.GetUpperBound(0) + 1;
			int W = img.Length / H;

			int minX = int.MaxValue, minY = int.MaxValue, maxX = 0, maxY = 0;

			for (int y = 0; y < H; y++)
			{
				for (int x = 0; x < W; x++)
				{
					if (img[y, x] == charsNumber)
					{
						minX = Math.Min(minX, x);
						minY = Math.Min(minY, y);
						maxX = Math.Max(maxX, x);
						maxY = Math.Max(maxY, y);
					}
				}
			}

			return (new Point(minX, minY), new Point(maxX, maxY));
		}

		private static bool Fill(int[,] img, int[,] labels, int x, int y, int L, int W, int H)
		{
			if ((labels[y, x] == 0) && (img[y, x] == 1))
			{
				labels[y, x] = L;
				if (x > 0)
					Fill(img, labels, x - 1, y, L, W, H);
				if (x < W - 1)
					Fill(img, labels, x + 1, y, L, W, H);
				if (y > 0)
					Fill(img, labels, x, y - 1, L, W, H);
				if (y < H - 1)
					Fill(img, labels, x, y + 1, L, W, H);
				return true;
			}
			return false;
		}
	}
}
