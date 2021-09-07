using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Recycle.Converters
{
	public class CountConverter : IValueConverter
	{
		public int Threshold { get; set; }

		public bool Inverse { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool result = (int)value > Threshold != Inverse;
			if (targetType == typeof(Visibility))
			{
				return result ? Visibility.Visible : Visibility.Collapsed;
			}
			return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
