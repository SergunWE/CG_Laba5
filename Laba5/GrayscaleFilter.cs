using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
	internal class GrayscaleFilter : IFilter
	{
		public Bitmap ApplyFilter(Bitmap image)
		{
			Bitmap output = image;
			BitmapData bmpData = output.LockBits(new Rectangle(0, 0, output.Width, output.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
			unsafe
			{
				byte* ptr = (byte*)bmpData.Scan0.ToPointer();
				int stopAddress = (int)ptr + bmpData.Stride * bmpData.Height;

				while ((int)ptr <= stopAddress - 3)
				{
					int value = (ptr[0] + ptr[1] + ptr[2]) / 3;
					* ptr = (byte)(value);
					ptr[1] = *ptr;
					ptr[2] = *ptr;
					ptr += 4;
				}
			}
			output.UnlockBits(bmpData);
			return output;
		}
	}
}
