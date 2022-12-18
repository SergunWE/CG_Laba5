using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
	internal class DilationFilter : IFilter
	{
		public Bitmap ApplyFilter(Bitmap image)
		{
			int w = image.Width;
			int h = image.Height;
			int se_dim = 3;

			BitmapData image_data = image.LockBits(
				new Rectangle(0, 0, w, h),
				ImageLockMode.ReadOnly,
				PixelFormat.Format32bppRgb);

			int bytes = image_data.Stride * image_data.Height;
			byte[] buffer = new byte[bytes];
			byte[] result = new byte[bytes];

			Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
			image.UnlockBits(image_data);

			int o = (se_dim - 1) / 2;
			for (int i = o; i < w - o; i++)
			{
				for (int j = o; j < h - o; j++)
				{
					int position = i * 4 + j * image_data.Stride;
					for (int k = -o; k <= o; k++)
					{
						for (int l = -o; l <= o; l++)
						{
							int se_pos = position + k * 4 + l * image_data.Stride;
							for (int c = 0; c < 4; c++)
							{
								result[se_pos + c] = Math.Max(result[se_pos + c], buffer[position]);
							}
						}
					}
				}
			}

			Bitmap res_img = image;
			BitmapData res_data = res_img.LockBits(
				new Rectangle(0, 0, w, h),
				ImageLockMode.WriteOnly,
				PixelFormat.Format32bppRgb);
			Marshal.Copy(result, 0, res_data.Scan0, bytes);
			res_img.UnlockBits(res_data);
			return res_img;
		}
	}
}
