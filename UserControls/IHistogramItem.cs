using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.UserControls
{
	public interface IHistogramItem
	{
		double Value { get; }

		double Percent { get; }

		object Header { get; }
	}
}
