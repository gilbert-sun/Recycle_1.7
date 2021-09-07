using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle
{
	public static class TimeUnit
	{
		public const string SECOND = "second";

		public const string MINUTE = "minute";

		public const string HOUR = "hour";

		public const string DAY = "day";

		public static string SecondFormat(double value) => value.ToString();

		public static string MinuteFormat(double value) => (value / 60).ToString();

		public static string HourFormat(double value) => (value / 3600).ToString();

		public static string DayFormat(double value) => (value / 86400).ToString();

		public static Func<double, string> GetFormatFunction(string unit)
		{
			switch (unit)
			{
				case MINUTE: return MinuteFormat;
				case HOUR: return MinuteFormat;
				case DAY: return DayFormat;
				default: return SecondFormat;
			}
		}
	}
}
