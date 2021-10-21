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
		//-------------------------------------------------------------------------------gilbert start 2021.09.05
		public double MaxSecond { get; private set; } =  MainViewModel.ConfigClass.MaxValue_Chart ;//35
		//-------------------------------------------------------------------------------gilbert end
		public void Add(double value)
		{
			var now = DateTime.Now;
			//-------------------------------------------------------------------------------gilbert start 2021.09.05
			// TODO: 第2頁 下拉選單
			MaxSecond = MainViewModel.ConfigClass.MaxValue_Chart;
			//-------------------------------------------------------------------------------gilbert end
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
