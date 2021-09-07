using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Recycle.UserControls
{
	public class TextBoxHelper
	{
		public static readonly DependencyProperty UseOskProperty = DependencyProperty.RegisterAttached(
			name: "UseOsk",
			propertyType: typeof(bool),
			ownerType: typeof(TextBoxHelper),
			defaultMetadata: new PropertyMetadata(OnUseOskChanged));

		public static readonly DependencyProperty IsMonitoringProperty = DependencyProperty.RegisterAttached(
			name: "IsMonitoring",
			propertyType: typeof(bool),
			ownerType: typeof(TextBoxHelper),
			defaultMetadata: new PropertyMetadata(OnIsMonitoringChanged));

		public static readonly DependencyProperty HasTextProperty = DependencyProperty.RegisterAttached(
			name: "HasText",
			propertyType: typeof(bool),
			ownerType: typeof(TextBoxHelper));

		public static readonly DependencyProperty NumericProperty = DependencyProperty.RegisterAttached(
			name: "Numeric",
			propertyType: typeof(bool),
			ownerType: typeof(TextBoxHelper),
			defaultMetadata: new PropertyMetadata(OnNumericChanged));

		public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached(
			name: "Watermark",
			propertyType: typeof(string),
			ownerType: typeof(TextBoxHelper));

		private static Process oskExe;

		private static Regex numericRegex = new Regex("[^0-9.-]+");

		private static void OnUseOskChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is TextBox textBox)
			{
				if ((bool)e.NewValue)
				{
					textBox.GotFocus += OpenOskWhenGotFocus;
					textBox.LostFocus += CloseOskWhenLostFocus;
				}
				else
				{
					textBox.GotFocus -= OpenOskWhenGotFocus;
					textBox.LostFocus -= CloseOskWhenLostFocus;
				}
			}
			else if (d is PasswordBox passwordBox)
			{
				if ((bool)e.NewValue)
				{
					passwordBox.GotFocus += OpenOskWhenGotFocus;
					passwordBox.LostFocus += CloseOskWhenLostFocus;
				}
				else
				{
					passwordBox.GotFocus -= OpenOskWhenGotFocus;
					passwordBox.LostFocus -= CloseOskWhenLostFocus;
				}
			}
		}

		private static readonly Lazy<string> oskFilename = new Lazy<string>(() =>
		{
			if (Environment.Is64BitOperatingSystem)
			{
				var path = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
				path = Path.Combine(path, "winsxs");
				path = Directory.GetDirectories(path, "amd64_microsoft-windows-osk_*").FirstOrDefault();
				return Path.Combine(path, "osk.exe");
			}
			else
			{
				return @"C:\windows\system32\osk.exe";
			}
		});

		private static void CloseOskWhenLostFocus(object sender, RoutedEventArgs e)
		{
			var element = FocusManager.GetFocusedElement(App.Current.MainWindow);
			if (element is TextBox || element is PasswordBox)
			{
				return;
			}
			if (oskExe?.HasExited == false)
			{
				oskExe.Kill();
				oskExe = null;
			}
		}

		private static void OpenOskWhenGotFocus(object sender, RoutedEventArgs e)
		{
			if (oskExe?.HasExited == false ||
				(sender as TextBoxBase)?.IsReadOnly == true)
			{
				return;
			}
			oskExe = new Process();
			oskExe.StartInfo.FileName = oskFilename.Value;
			oskExe.Start();
		}

		private static void OnIsMonitoringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is TextBox textBox)
			{
				if ((bool)e.NewValue)
				{
					TextChanged(d, new TextChangedEventArgs(TextBoxBase.TextChangedEvent, UndoAction.None));
					textBox.TextChanged += TextChanged;
				}
				else
				{
					textBox.TextChanged -= TextChanged;
				}
			}
			else if (d is PasswordBox passwordBox)
			{
				if ((bool)e.NewValue)
				{
					passwordBox.PasswordChanged += PasswordChanged;
				}
				else
				{
					passwordBox.PasswordChanged -= PasswordChanged;
				}
			}
		}

		private static void OnNumericChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is TextBox textBox)
			{
				if ((bool)e.NewValue)
				{
					textBox.PreviewTextInput += NumberValidationTextBox;
				}
				else
				{
					textBox.PreviewTextInput -= NumberValidationTextBox;
				}
			}
		}

		private static void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			e.Handled = numericRegex.IsMatch(e.Text);
		}

		private static void TextChanged(object sender, TextChangedEventArgs e)
		{
			var textBox = sender as TextBox;
			textBox.SetValue(HasTextProperty, !string.IsNullOrEmpty(textBox.Text));
		}

		private static void PasswordChanged(object sender, RoutedEventArgs e)
		{
			var passwordBox = sender as PasswordBox;
			passwordBox.SetValue(HasTextProperty, !string.IsNullOrEmpty(passwordBox.Password));
		}

		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		public static bool GetUseOsk(DependencyObject obj) => (bool)obj.GetValue(UseOskProperty);

		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		public static void SetUseOsk(DependencyObject obj, bool value) => obj.SetValue(UseOskProperty, value);

		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		public static bool GetIsMonitoring(DependencyObject obj) => (bool)obj.GetValue(IsMonitoringProperty);

		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		public static void SetIsMonitoring(DependencyObject obj, bool value) => obj.SetValue(IsMonitoringProperty, value);

		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		public static bool GetHasText(DependencyObject obj) => (bool)obj.GetValue(HasTextProperty);

		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		public static void SetHasText(DependencyObject obj, bool value) => obj.SetValue(HasTextProperty, value);

		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		public static bool GetNumeric(DependencyObject obj) => (bool)obj.GetValue(NumericProperty);

		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		public static void SetNumeric(DependencyObject obj, bool value) => obj.SetValue(NumericProperty, value);

		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		public static string GetWatermark(DependencyObject obj) => obj.GetValue(WatermarkProperty) as string;

		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		public static void SetWatermark(DependencyObject obj, string value) => obj.SetValue(WatermarkProperty, value);
	}
}
