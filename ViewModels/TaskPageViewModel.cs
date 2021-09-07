using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Recycle.ViewModels
{
	public class TaskPageViewModel : PageViewModel
	{
		public override string Name => App.Current.Resources["strNaviTasks"] as string;

		public override string Description => null;

		public override Geometry PathData => App.Current.Resources["geoSink"] as Geometry;
	}
}
