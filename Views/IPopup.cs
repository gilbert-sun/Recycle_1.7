using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Views
{
	public interface IPopup
	{
		Action CancelDelegate { get; set; }
	}
}
