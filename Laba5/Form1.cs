﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Laba5
{
	public partial class Form1 : Form
	{
		private readonly ImageManager _imageManager;

		public Form1()
		{
			_imageManager = new ImageManager();
			InitializeComponent();
		}

		private void openButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog()
			{
				Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"
			};
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					var t = new Bitmap(ofd.FileName);

					_imageManager.Image = RemoveAlphaChannel(t);
					pictureBox.Image = _imageManager.Image;
				}
				catch
				{
					MessageBox.Show("Unable to open the selected file", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		public static Bitmap RemoveAlphaChannel(Bitmap bitmap)
		{
			var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
			return bitmap.Clone(rect, PixelFormat.Format32bppRgb);
		}

		private void ConversionButton_Click(object sender, EventArgs e)
		{
			if (_imageManager.Image != null)
			{
				_imageManager.ApplyConversionFilter();
				pictureBox.Image = _imageManager.Image;
			}
		}

		private void buttonBinarization_Click(object sender, EventArgs e)
		{
			if (_imageManager.Image != null)
			{
				_imageManager.ApplyBinarization();
				pictureBox.Image = _imageManager.Image;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			try
			{
				int value = Convert.ToInt32(textBox1.Text);
				_imageManager.SetThreshold(value);
			}
			catch { }
		}
	}
}