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
	public class VisibilityConverter : IValueConverter
	{
		public bool Inverse { get; set; }

		public Visibility Hidden { get; set; } = Visibility.Collapsed;

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value != Inverse ? Visibility.Visible : Hidden;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
