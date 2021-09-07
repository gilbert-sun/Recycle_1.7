using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Recycle.UserControls
{
	public class ResourceHelper
	{
		public static readonly DependencyProperty TextProperty = DependencyProperty.RegisterAttached(
			name: "Text",
			propertyType: typeof(object),
			ownerType: typeof(ResourceHelper),
			defaultMetadata: new PropertyMetadata(OnTextChanged));

		private static void OnTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			if (sender is TextBlock textblock)
			{
				SetValue(textblock, TextBlock.TextProperty, args.NewValue);
			}
			else if (sender is Run run)
			{
				SetValue(run, Run.TextProperty, args.NewValue);
			}
		}

		private static void SetValue(FrameworkElement element, DependencyProperty property, object value)
		{
			if (value is IResourceObject obj)
			{
				element.SetResourceReference(property, obj.Key);
			}
			else
			{
				element.SetValue(property, value?.ToString());
			}
		}

		private static void SetValue(FrameworkContentElement element, DependencyProperty property, object value)
		{
			if (value is IResourceObject obj)
			{
				element.SetResourceReference(property, obj.Key);
			}
			else
			{
				element.SetValue(property, value?.ToString());
			}
		}

		public static object GetText(DependencyObject obj) => obj.GetValue(TextProperty);

		public static void SetText(DependencyObject obj, object value) => obj.SetValue(TextProperty, value);

	}
}
