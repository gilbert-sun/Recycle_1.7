using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Recycle.UserControls
{
	public class ButtonHelper
	{
		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached(
			   name: "CornerRadius",
			   propertyType: typeof(CornerRadius),
			   ownerType: typeof(ButtonHelper));

		public static CornerRadius GetCornerRadius(DependencyObject obj) => (CornerRadius)obj.GetValue(CornerRadiusProperty);

		public static void SetCornerRadius(DependencyObject obj, CornerRadius value) => obj.SetValue(CornerRadiusProperty, value);
	}
}
