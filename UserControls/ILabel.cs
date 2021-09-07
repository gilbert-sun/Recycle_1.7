using Recycle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.UserControls
{
	public interface ILabel
	{
		string Title { get; }
		object Subtitle { get; }
		ComponentStatus Status { get; }
	}
}
