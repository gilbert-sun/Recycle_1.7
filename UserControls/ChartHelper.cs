using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Recycle.UserControls
{
	public class ChartHelper
	{
		public static void DrawRowsLabel(ItemsControl rowsControl, double min, double max, double unit, double pixel)
		{
			if (rowsControl == null)
			{
				return;
			}
			var list = new List<double>();
			for (double i = min; i <= max; i += unit)
			{
				list.Add(i);
			}
			list.Reverse();
			rowsControl.ItemsSource = list;

			var length = max - min;
			var unitHeight = pixel / length;
			var rest = length % unit;
			rowsControl.Height = (length + unit - rest) * unitHeight;
			var offsetY = (rest - unit / 2) * unitHeight;
			rowsControl.RenderTransform = new TranslateTransform
			{
				Y = offsetY
			};
		}

		public static void DrawColumnsLabel(ItemsControl columnsControl, double min, double max, double unit, double pixel, Func<double, string> format)
		{
			if (columnsControl == null)
			{
				return;
			}
			var list = new List<string>();
			for (double i = unit + min; i <= max; i += unit)
			{
				list.Add(format(i));
			}
			columnsControl.ItemsSource = list;

			var length = max - min;
			var unitWidth = pixel / length;
			var offsetX = (length % unit) * unitWidth;
			columnsControl.Margin = new Thickness(0, 0, offsetX, 0);
			offsetX = unit * unitWidth / 2;
			columnsControl.RenderTransform = new TranslateTransform
			{
				X = offsetX
			};
		}
	}
}
