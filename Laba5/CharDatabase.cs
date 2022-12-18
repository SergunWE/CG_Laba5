using System;
using System.Collections.Generic;
using System.Drawing;
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

		public CharDatabase(Bitmap image, string charsString)
		{
			_charsImage = image;
			_charsString = charsString;


		}
	}
}
