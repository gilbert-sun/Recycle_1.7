using Recycle.Models;
using Recycle.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Recycle.Views
{
	/// <summary>
	/// LoginView.xaml 的互動邏輯
	/// </summary>
	public partial class LoginView : UserControl, IPopup
	{
		public MainViewModel mainViewModel => DataContext as MainViewModel;

		public LoginView()
		{
			InitializeComponent();
		}

		public Action CancelDelegate { get; set; }

		private void Operator_Selected(object sender, RoutedEventArgs e)
		{
			CancelDelegate?.Invoke();
		}

		private void Login_Click(object sender, RoutedEventArgs e)
		{
			if (passwordBox.Password == "1234")
			{
				mainViewModel.SetRole(Role.ADMINISTRATOR);
				CancelDelegate?.Invoke();
			}
			else
			{
				txtError.Text = App.Current.Resources["strComWrongPw"] as string;
				passwordBox.BorderBrush = App.Current.Resources["brushNotiRed"] as Brush;
				passwordBox.PasswordChanged += passwordBox_PasswordChanged;
			}
		}

		private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
		{
			txtError.Text = string.Empty;
			passwordBox.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E4E4E4"));
			passwordBox.PasswordChanged -= passwordBox_PasswordChanged;
		}
	}
}
