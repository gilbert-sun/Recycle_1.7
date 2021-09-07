using Recycle.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.ViewModels
{
	public class RobotParameter : BaseViewModel, ILabel
	{
		public string Value { get; set; }

		public object Subtitle { get; set; }

		public ComponentStatus Status { get; set; }

		public string Title => Value;
	}
}
