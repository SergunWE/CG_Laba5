using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
	internal interface IFilter
	{
		Bitmap ApplyFilter(Bitmap image);
	}
}
