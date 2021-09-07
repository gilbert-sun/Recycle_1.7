using Recycle.ViewModels;
using System.Windows;
using System.Windows.Data;

namespace Recycle.UserControls
{
	public class AdvLabel : StatusLabel
	{
		public static readonly DependencyProperty ParameterKeyProperty = DependencyProperty.RegisterAttached(
			name: "ParameterKey",
			propertyType: typeof(string),
			ownerType: typeof(AdvLabel),
			defaultMetadata: new PropertyMetadata(OnParameterKeyChanged));

		public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
			name: "Description",
			propertyType: typeof(object),
			ownerType: typeof(AdvLabel));

		private static void OnParameterKeyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			var label = sender as AdvLabel;
			if (args.NewValue != args.OldValue &&
				label.DataContext is RobotViewModel robot &&
				robot.Parameters.TryGetValue(args.NewValue as string, out RobotParameter parameter))
			{
				SetBindings(label, parameter);
			}
		}

		private static void SetBindings(AdvLabel label, RobotParameter source)
		{
			Binding bindingText = new Binding(nameof(RobotParameter.Title))
			{
				Source = source
			};
			Binding bindingSubtitle = new Binding(nameof(RobotParameter.Subtitle))
			{
				Source = source
			};
			Binding bindingStatus = new Binding(nameof(RobotParameter.Status))
			{
				Source = source
			};
			label.SetBinding(TextProperty, bindingText);
			label.SetBinding(DescriptionProperty, bindingSubtitle);
			label.SetBinding(StatusProperty, bindingStatus);
		}

		public static string GetParameterKey(DependencyObject obj) => obj.GetValue(ParameterKeyProperty) as string;

		public static void SetParameterKey(DependencyObject obj, object value) => obj.SetValue(ParameterKeyProperty, value);

		public object Description
		{
			get => GetValue(DescriptionProperty);
			set => SetValue(DescriptionProperty, value);
		}
	}
}
