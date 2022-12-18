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
			int[,] matrix = new int[image.Width, image.Height];

			int iStop = image.Width - 1;
			int i = 0, j = 0;

			BitmapData bmpData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			unsafe
			{
				byte* ptr = (byte*)bmpData.Scan0.ToPointer();
				int stopAddress = (int)ptr + bmpData.Stride * bmpData.Height;

				while ((int)ptr < stopAddress)
				{
					matrix[i, j] = ptr[0] == 255 ? 1 : 0;

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

		private static int H;
		private static int W;
		private static bool isChar;

		public static int[,] MatrixMarkup(int[,] img)
		{
			W = img.GetUpperBound(0) + 1;
			H = img.Length / W;

			int[,] labels = new int[W, H];

			int L = 1;
			for (int y = 0; y < H; y++)
			{
				for (int x = 0; x < W; x++)
				{
					isChar = false;
					Fill(img, labels, x, y, L);
					if (isChar)
					{
						L++;
					}

				}
			}
			return labels;
		}

		private static void Fill(int[,] img, int[,] labels, int x, int y, int L)
		{
			if ((labels[x, y] == 0) && (img[x, y] == 1))
			{
				isChar = true;
				labels[x, y] = L;
				if (x > 0)
					Fill(img, labels, x - 1, y, L);
				if (x < W - 1)
					Fill(img, labels, x + 1, y, L);
				if (y > 0)
					Fill(img, labels, x, y - 1, L);
				if (y < H - 1)
					Fill(img, labels, x, y + 1, L);
			}
		}
	}
}
