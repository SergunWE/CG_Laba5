using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
		private readonly CharDatabase _database;

		public Form1()
		{
			_imageManager = new ImageManager();
			_database = new CharDatabase();
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

		private void morphologicalButton_Click(object sender, EventArgs e)
		{
			if (_imageManager.Image != null)
			{
				_imageManager.ApplyMorphologicalFilter();
				pictureBox.Image = _imageManager.Image;
			}
		}

		private void invertButton_Click(object sender, EventArgs e)
		{
			if (_imageManager.Image != null)
			{
				_imageManager.ApplyInvertFilter();
				pictureBox.Image = _imageManager.Image;
			}
		}

		private void Markbutton_Click(object sender, EventArgs e)
		{
			//CharDatabase db = new CharDatabase(_imageManager.Image, "ZYXWVUTSRQPONMLKJIHGFEDCBA");

			//var t = ImageHelper.ImageToMatrix(_imageManager.Image);
			//t = ImageHelper.MatrixMarkup(t);
			var matrix = ImageHelper.MatrixMarkup(ImageHelper.ImageToMatrix(_imageManager.Image));
			ImageHelper.OutlineColorChars(_imageManager.Image, matrix);
			pictureBox.Image = _imageManager.Image;

			Console.WriteLine(ImageHelper.LatestCharNumber - 1);

			string result = "";
			for (int i = 1; i <= ImageHelper.LatestCharNumber; i++)
			{
				var p = ImageHelper.GetCharPositions(matrix, i);

				Bitmap charImage = new Bitmap(p.Item2.X - p.Item1.X, p.Item2.Y - p.Item1.Y);
				using (Graphics g = Graphics.FromImage(charImage))
				{
					g.DrawImage(_imageManager.Image, 0, 0, new Rectangle(p.Item1, new Size(p.Item2.X - p.Item1.X, p.Item2.Y - p.Item1.Y)), GraphicsUnit.Pixel);
				}
				charImage = new Bitmap(charImage, 16, 16);
				var c = ImageHelper.ImageToMatrix(charImage);
				result += _database.GetChar(c);
			}
			label1.Text = result;
		}

		private void AddDBbutton_Click(object sender, EventArgs e)
		{
			if(textBox2.Text.Length > 0)
			{
				_database.AddImage(_imageManager.Image, textBox2.Text);
			}
		}
	}
}
