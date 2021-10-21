using Recycle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Recycle.Views
{
	/// <summary>
	/// AdjustPage.xaml 的互動邏輯
	/// </summary>
	public partial class AdjustPage : UserControl
	{
		public static MainViewModel Instance => App.Current.Resources["mainViewModel"] as MainViewModel;

		public AdjustPage()
		{
			InitializeComponent();			
		}

        private void Button_ClickHome(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickHome(sender, e);
        }

        private void Button_ClickDemo(object sender, RoutedEventArgs e)
        {          
            Instance.delegateClickDemo(sender, e);
        }

        private void Button_ClickCircle2D(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickCircle2D(sender, e);
        }

        private void Button_ClickArc(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickArc(sender, e);
        }

        private void Button_ClickRect(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickRect(sender, e);
        }

        private void Button_ClickMoveU(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickMoveU(sender, e);
        }

        private void RepeatButtonXp_Click(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickXp(sender, e);
        }

        private void RepeatButtonXn_Click(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickXn(sender, e);
        }

        private void RepeatButtonYp_Click(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickYp(sender, e);
        }

        private void RepeatButtonYn_Click(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickYn(sender, e);
        }

        private void RepeatButtonZp_Click(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickZp(sender, e);
        }

        private void RepeatButtonZn_Click(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickZn(sender, e);
        }

        private void Button_ClickCameraPauseResume(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickCameraPauseResume(sender, e);            
        }

        private void Button_ClickAbort(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickAbort(sender, e);
        }

        private void Button_ClickServoOn(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickServoOn(sender, e);
        }

        private void Button_ClickServoOff(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickServoOff(sender, e);
        }

        private void Button_ClickCleanError(object sender, RoutedEventArgs e)
        {
            Instance.delegateClickCleanError(sender, e);
        }
    }
}
