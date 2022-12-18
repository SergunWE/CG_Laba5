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
					matrix[j, i] = ptr[0] == 255 ? 1 : 0;

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

		public static int[,] MatrixMarkup(int[,] img)
		{
			int H = img.GetUpperBound(0) + 1;
			int W = img.Length / H;

			int[,] labels = new int[H, W];

			int L = 1;
			for (int y = 0; y < H; y++)
			{
				for (int x = 0; x < W; x++)
				{
					if (Fill(img, labels, x, y, L, W, H))
					{
						L++;
					}
				}
			}
			return labels;
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
