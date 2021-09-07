using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.ViewModels
{
	public class SinkViewModel : BaseViewModel
	{
		public string Label { get; set; }

		public int Accumulation { get; set; }

		public ComponentStatus Status { get; set; }
	}
}
