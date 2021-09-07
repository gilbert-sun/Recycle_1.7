using Recycle.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Recycle.UserControls
{
	public class StatusMark : Control
	{
		public static readonly DependencyProperty StatusProperty = DependencyProperty.Register(
			name: "Status",
			propertyType: typeof(ComponentStatus),
			ownerType: typeof(StatusMark));

		public ComponentStatus Status
		{
			get => (ComponentStatus)GetValue(StatusProperty);
			set => SetValue(StatusProperty, value);
		}
	}
}
