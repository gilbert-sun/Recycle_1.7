using Recycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.ViewModels
{
	public class TimelineChartViewModel : BaseViewModel
	{
		public ObservableQueue<DatePoint> Points { get; private set; } = new ObservableQueue<DatePoint>();

		public DateTime Now { get; private set; }

		public double MaxSecond { get; private set; } = 35;

		public void Add(double value)
		{
			var now = DateTime.Now;
			while (Points.Count > 0 && (now - Points.Peek().Time).TotalSeconds > MaxSecond)
			{
				Points.Dequeue();
			}
			Points.Enqueue(new DatePoint(now, value));
			Now = now;
			RaisePropertyChanged("Now");
		}
	}
}
