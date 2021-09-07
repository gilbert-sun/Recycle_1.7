using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Recycle.ViewModels
{
	public class StatusPageViewModel : PageViewModel
	{
		public override string Name => App.Current.Resources["strNaviStatus"] as string;

		public override string Description => null;

		public override Geometry PathData => App.Current.Resources["geoStatus"] as Geometry;
	}
}
