using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
	internal class ImageManager
	{
		public Bitmap Image { get; set; }

		private IFilter _conversionFilter;
		private IFilter _binarizationFilter;
		private IFilter _morphologicalFilter;

		public ImageManager()
		{
			_conversionFilter = new GrayscaleFilter();
			_binarizationFilter = new BinarizationFilter();
		}

		public void ApplyConversionFilter()
		{
			_conversionFilter.ApplyFilter(Image);
		}

		public void ApplyBinarization()
		{
			Image = _binarizationFilter.ApplyFilter(Image);
		}

		public void SetThreshold(int value)
		{
			((BinarizationFilter)_binarizationFilter).Threshold = value;
		}
	}
}

