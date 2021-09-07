using Recycle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Recycle.UserControls
{
	public class StatusLabel : StatusMark
	{
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
			name: "Text",
			propertyType: typeof(string),
			ownerType: typeof(StatusLabel));

		public string Text
		{
			get => GetValue(TextProperty) as string;
			set => SetValue(TextProperty, value);
		}
	}
}
