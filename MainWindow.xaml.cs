using Recycle.Models;
using Recycle.ViewModels;
using Recycle.Views;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Recycle
{
	/// <summary>
	/// MainWindow.xaml 的互動邏輯
	/// </summary>
	public partial class MainWindow : Window, ICommand
	{
		public const double WIDTH_THRESHOLD_1 = 1280;

		public const double WIDTH_THRESHOLD_2 = 1440;

		public const double TAB_ITEM_WIDTH_NARROW = 133;

		public const double TAB_ITEM_WIDTH_WIDE = 200;

		public const double TASK_BORDER_WIDTH_NARROW = 320;

		public const double TASK_BORDER_WIDTH_WIDE = 568;

		public const string HIDE_POPUP_COMMAND = "hidepopup";

		public readonly GridLength NAVI_COLUMN_WIDTH_NARROW = new GridLength(56);

		public readonly GridLength NAVI_COLUMN_WIDTH_WIDE = new GridLength(200);

		public MainViewModel MainViewModel => DataContext as MainViewModel;

		private bool fullScreen;

		public bool FullScreen
		{
			get => fullScreen;
			set
			{
				fullScreen = value;
				if (fullScreen)
				{
					WindowStyle = WindowStyle.None;
					WindowState = WindowState.Normal;
					WindowState = WindowState.Maximized;
					Topmost = true;
					iconFullScreen.Data = App.Current.Resources["geoUnfullScreen"] as Geometry;
				}
				else
				{
					WindowStyle = WindowStyle.SingleBorderWindow;
					Topmost = false;
					iconFullScreen.Data = App.Current.Resources["geoFullscreen"] as Geometry;
				}
			}
		}

		public event EventHandler CanExecuteChanged;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			MainViewModel.SelectPage(PageIndex.HOME);
		}

		private void NaviButton_Checked(object sender, RoutedEventArgs e)
		{
			if (Enum.TryParse((sender as FrameworkElement)?.Tag as string, out PageIndex value))
			{
				MainViewModel.SelectPage(value);
			}
		}

		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (e.WidthChanged)
			{
				var width = e.NewSize.Width;
				var resources = App.Current.Resources;
				if (width < WIDTH_THRESHOLD_2)
				{
					columnNavi.Width = NAVI_COLUMN_WIDTH_NARROW;
					resources["boolIconOnly"] = true;
					labRealTimeStatus.Visibility = Visibility.Hidden;
				}
				else
				{
					columnNavi.Width = NAVI_COLUMN_WIDTH_WIDE;
					resources["boolIconOnly"] = false;
					labRealTimeStatus.Visibility = Visibility.Visible;
				}
				if (width <= WIDTH_THRESHOLD_1)
				{
					resources["tabItemWidth"] = TAB_ITEM_WIDTH_NARROW;
					resources["taskBorderWidth"] = TASK_BORDER_WIDTH_NARROW;
					resources["gridRows"] = 0;
					resources["gridColumns"] = 1;
				}
				else
				{
					resources["tabItemWidth"] = TAB_ITEM_WIDTH_WIDE;
					resources["taskBorderWidth"] = TASK_BORDER_WIDTH_WIDE;
					resources["gridRows"] = 1;
					resources["gridColumns"] = 0;
				}
			}
		}

		private void btnFullScreen_Click(object sender, RoutedEventArgs e)
		{
			FullScreen = !FullScreen;
		}

		private void RobotStatus_Click(object sender, RoutedEventArgs e)
		{
			var robot = (sender as FrameworkElement).DataContext as RobotViewModel;
			if (robot != null)
			{
				btnHome.IsChecked = true;
				if (MainViewModel.CurrentContent is HomePageViewModel home)
				{
					home.SelectedItem = robot;
				}
			}
		}

		private void OpenContextMenu(object sender, RoutedEventArgs e)
		{
			var owner = sender as FrameworkElement;
			var menu = owner.ContextMenu;
			menu.PlacementTarget = owner;
			menu.IsOpen = true;
		}

		private void ChangeToOperator(object sender, RoutedEventArgs e)
		{
			if (!MainViewModel.IsAdmin)
			{
				return;
			}
			MainViewModel.SetRole(Role.OPERATOR);
		}

		private void ChangeToAdministrator(object sender, RoutedEventArgs e)
		{
			if (MainViewModel.IsAdmin)
			{
				return;
			}
			ShowPopup(new LoginView());
		}

		private void Storyboard_Completed(object sender, EventArgs e)
		{
			popup.Content = null;
		}

		private void ShowPopup(IPopup element)
		{
			element.CancelDelegate = HidePopup;
			popup.Content = element;
			popup.IsHitTestVisible = true;
			var story = Resources["storyShowPopup"] as Storyboard;
			popup.BeginStoryboard(story);
		}

		private void HidePopup()
		{
			popup.IsHitTestVisible = false;
			var story = Resources["storyHidePopup"] as Storyboard;
			popup.BeginStoryboard(story);
		}

		public bool CanExecute(object parameter) => true;

		public void Execute(object parameter)
		{
			switch (parameter as string)
			{
				case HIDE_POPUP_COMMAND:
					HidePopup();
					break;
			}
		}

		private void Language_Click(object sender, RoutedEventArgs e)
		{
			var language = (sender as FrameworkElement).Tag as string;
			MainViewModel.ChangeLanguage(language);
		}
	}
}
