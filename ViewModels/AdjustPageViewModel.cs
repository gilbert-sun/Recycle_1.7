using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Recycle.ViewModels
{
	public class AdjustPageViewModel : PageViewModel
	{
		public override string Name => App.Current.Resources["strNaviAdjust"] as string;

		public override string Description => App.Current.Resources["strDesAdjust"] as string;

		public override Geometry PathData => App.Current.Resources["geoAdjust"] as Geometry;
	}
}
