using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.ViewModels
{
	public static class RobotApi
	{
		public static void SetParameter(this SinkViewModel sink, int acc, ComponentStatus status)
		{
			sink.Accumulation = acc;
			sink.Status = status;
			sink.RaisePropertyChanged(nameof(SinkViewModel.Accumulation));
			sink.RaisePropertyChanged(nameof(SinkViewModel.Status));
		}

		/// <summary>
		/// 設定開機時間
		/// </summary>
		public static void SetStartTime(string robotID, DateTime dateTime)
		{
			Robot(robotID)?.SetStartTime(dateTime);
		}

		/// <summary>
		/// 設定運行時間
		/// </summary>
		public static void SetDuration(string robotID, TimeSpan duration)
		{
			Robot(robotID)?.SetDuration(duration);
		}

		public static void SetParameter<T>(string robotID, string paramter, T value, ComponentStatus status = ComponentStatus.GOOD)
		{
			Robot(robotID)?.Parameter(paramter).SetParameter(value, status);
		}

		public static void SetComponentStatus(this RobotParameter robot, ComponentStatus status)
		{
			string value;
			switch (status)
			{
				case ComponentStatus.ERROR:
					value = "Error";
					break;
				case ComponentStatus.WARNING:
					value = "Warning";
					break;
				case ComponentStatus.GOOD:
				default:
					value = "Good";
					break;
			}
			robot.SetParameter(value, status);
		}

		public static void SetParameter<T>(this RobotParameter robot, T value, ComponentStatus status = ComponentStatus.GOOD)
		{
			if (robot == null)
			{
				return;
			}
			robot.Value = value.ToString();
			robot.Status = status;
			robot.RaisePropertyChanged(nameof(RobotParameter.Status));
			robot.RaisePropertyChanged(nameof(RobotParameter.Title));
		}

		public static RobotParameter Parameter(this RobotViewModel robot, string key)
		{
			RobotParameter parameter = null;
			_ = (robot?.Parameters.TryGetValue(key, out parameter));
			return parameter;
		}

		private static RobotViewModel Robot(string id) => MainViewModel.Instance.GetRobot(id);
	}
}
