using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
	internal class CharInfo
	{
		//Последовательность яркостей
		public int[] _hsbSequence;

		//Кол-во областей, на которые будут разделены символы, для составления последовательности яркостей (по горизонтали и вертикали)
		private const int XPoints = 8;
		private const int YPoints = 8;

		//Символьное представление сущности
		public char Char { get; set; }

		//Графическое представление сущности
		public Bitmap CharBitmap { get; private set; }

		public CharInfo(Bitmap charBitmap, char letter)
		{
			Char = letter;

			CharBitmap = charBitmap;

			//Сжимаем наш символ в соответствии с кол-вом областей
			Bitmap resized = new Bitmap(charBitmap, XPoints, YPoints);

			_hsbSequence = new int[XPoints * YPoints];

			int i = 0;

			//И заполняем последовательность яркостями*10. Сама яркость, это double от 0.0(черное) до 1.0(белое)
			for (int y = 0; y < YPoints; y++)
				for (int x = 0; x < XPoints; x++)
					_hsbSequence[i++] = resized.GetPixel(x, y).R == 255 ? 1 : 0;

		}

		/// <summary>
		/// Метод сравнения с другим символом, сравнивает последовательности яркостей
		/// </summary>
		/// <param name="charInfo"></param>
		/// <returns>Количество совпадений</returns>
		public int Compare(CharInfo charInfo)
		{
			int matches = 0;

			for (int i = 0; i < _hsbSequence.Length; i++)
			{
				if (_hsbSequence[i] == charInfo._hsbSequence[i]) ++matches;
			}

			return matches;
		}
	}
}
