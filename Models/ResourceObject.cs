using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Models
{
	public struct ResourceObject : IResourceObject
	{
		public ResourceObject(string key)
		{
			Key = key;
		}

		public string Key { get; private set; }
	}
}
