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
	public class NavigationButton : RadioButton
	{
		public static readonly DependencyProperty PathDataProperty = DependencyProperty.Register(
			name: "PathData",
			propertyType: typeof(Geometry),
			ownerType: typeof(NavigationButton));

		public static readonly DependencyProperty IconOnlyProperty = DependencyProperty.Register(
			name: "IconOnly",
			propertyType: typeof(bool),
			ownerType: typeof(NavigationButton));

		public Geometry PathData
		{
			get => GetValue(PathDataProperty) as Geometry;
			set => SetValue(PathDataProperty, value);		
		}

		public bool IconOnly
		{
			get => (bool)GetValue(IconOnlyProperty);
			set => SetValue(IconOnlyProperty, value);
		}
	}
}
