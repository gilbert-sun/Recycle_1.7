using Recycle.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.ViewModels
{
	public class HistogramItemViewModel : BaseViewModel, IHistogramItem
	{
		public object Header { get; set; }

		public double Value { get; set; }

		public double Percent { get; set; }

		public void Refresh()
		{
			RaisePropertyChanged("Value");
			RaisePropertyChanged("Percent");
		}

		public override string ToString() => Header?.ToString();
	}
}
