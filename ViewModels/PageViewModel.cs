using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Recycle.ViewModels
{
	public abstract class PageViewModel : BaseViewModel
	{
		public abstract string Name { get; }

		public abstract string Description { get; }

		public abstract Geometry PathData { get; }

		public override string ToString() => Name;
	}
}
