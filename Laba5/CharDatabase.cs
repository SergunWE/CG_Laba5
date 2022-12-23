﻿using System;
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
		public Dictionary<char, int[,]> _chars { get; private set; }

		public CharDatabase()
		{
			_chars = new Dictionary<char, int[,]>();
		}

		public void AddImage(Bitmap image, string charsString)
		{
			var matrix = ImageHelper.ImageToMatrix(image);
			var markupMatrix = ImageHelper.MatrixMarkup(matrix);

			for (int i = 1; i <= charsString.Length; i++)
			{
				var p = ImageHelper.GetCharPositions(markupMatrix, i);

				Bitmap charImage = new Bitmap(p.Item2.X - p.Item1.X, p.Item2.Y - p.Item1.Y);
				using (Graphics g = Graphics.FromImage(charImage))
				{
					g.DrawImage(image, 0, 0, new Rectangle(p.Item1, new Size(p.Item2.X - p.Item1.X, p.Item2.Y - p.Item1.Y)), GraphicsUnit.Pixel);
				}
				charImage = new Bitmap(charImage, 8, 8);
				var c = ImageHelper.ImageToMatrix(charImage);
				_chars.Add(charsString[i - 1], c);

				for (int z = 0; z < c.GetUpperBound(0) + 1; z++)
				{
					for (int j = 0; j < c.Length / (c.GetUpperBound(0) + 1); j++)
					{
						Console.Write(c[z, j] + " ");
					}
					Console.WriteLine();
				}
				Console.WriteLine("-----------");
			}
		}

		public char GetChar(int[,] charMatrix)
		{
			char currentChar = '-';
			int coincidence = -1;

			


			foreach (var charDB in _chars)
			{
				int currentCoincidence = 0;
				for (int i = 0; i < 8; i++)
				{
					for(int j = 0; j < 8; j++)
					{
						if (charMatrix[i,j] != 0 && charDB.Value[i, j] == 1)
						{
							currentCoincidence++;
						}
					}
				}
				if(currentCoincidence > coincidence)
				{
					coincidence= currentCoincidence;
					currentChar = charDB.Key;
				}
				Console.WriteLine($"{charDB.Key} - {currentCoincidence}");
			}
			return currentChar;
		}
	}
}
