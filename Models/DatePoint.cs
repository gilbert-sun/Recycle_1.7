using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Models
{
	public struct DatePoint
	{
		public DatePoint(DateTime time, double value)
		{
			Time = time;
			Value = value;
		}

		public DateTime Time { get; set; }

		public double Value { get; set; }
	}
}
