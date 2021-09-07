using Recycle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Recycle.Selectors
{
	public class TabTemplateSelector : DataTemplateSelector
	{
		public DataTemplate DefaultTemplate { get; set; }

		public DataTemplate OverallTemplate { get; set; }

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item is RobotViewModel)
			{
				return DefaultTemplate;
			}
			else
			{
				return OverallTemplate;
			}
		}
	}
}
