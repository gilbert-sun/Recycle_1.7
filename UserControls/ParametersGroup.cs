using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Recycle.UserControls
{
	public class ParametersGroup : Control
	{
		public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
			name: "Items",
			propertyType: typeof(IEnumerable<ILabel>),
			ownerType: typeof(ParametersGroup));

		public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
			name: "Header",
			propertyType: typeof(string),
			ownerType: typeof(ParametersGroup));

		public IEnumerable<ILabel> Items
		{
			get => (IEnumerable<ILabel>)GetValue(ItemsProperty);
			set => SetValue(ItemsProperty, value);
		}

		public string Header
		{
			get => GetValue(HeaderProperty) as string;
			set => SetValue(HeaderProperty, value);
		}
	}
}
