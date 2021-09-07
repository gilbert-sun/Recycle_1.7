using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Recycle.ViewModels
{
	public class HomePageViewModel : PageViewModel
	{
		public const string OVERALL = "overall";

		public HomePageViewModel(IEnumerable<RobotViewModel> robots)
		{
			ItemsSource = new List<object>();
			if (robots.Count() > 1)
			{
				ItemsSource.Add(OVERALL);
				SelectedItem = OVERALL;
			}
			else
			{
				SelectedItem = robots.FirstOrDefault();
			}
			ItemsSource.AddRange(robots);
		}

		private object selectedItem;

		public override string Name => App.Current.Resources["strNaviHome"] as string;

		public override string Description => null;

		public override Geometry PathData => App.Current.Resources["geoHome"] as Geometry;

		public List<object> ItemsSource { get; private set; }

		public object SelectedItem
		{
			get => selectedItem;
			set
			{
				selectedItem = value;
				if (selectedItem is RobotViewModel roboto)
				{
					(App.Current.Resources["mainViewModel"] as MainViewModel).SelectedRobot = roboto;
				}
				RaisePropertyChanged(nameof(SelectedItem));
			}
		}
	}
}
