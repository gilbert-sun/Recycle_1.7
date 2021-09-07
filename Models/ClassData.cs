using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Models
{
	public struct ClassData : IResourceObject
	{
		public static ClassData Ch => new ClassData(ClassType.CH);
		public static ClassData Color => new ClassData(ClassType.COLOR);
		public static ClassData Oil => new ClassData(ClassType.OIL);
		public static ClassData P => new ClassData(ClassType.P);
		public static ClassData Soy => new ClassData(ClassType.SOY);
		public static ClassData Tray => new ClassData(ClassType.TRAY);
		public static ClassData Other => new ClassData(ClassType.OTHER);
		public static ClassData None => new ClassData(ClassType.NONE);

		private ClassData(ClassType type)
		{
			Type = type;
		}

		public ClassType Type { get; private set; }

		string IResourceObject.Key
		{
			get
			{
				switch (Type)
				{
					case ClassType.CH: return "strClassCh";
					case ClassType.COLOR: return "strClassColor";
					case ClassType.OIL: return "strClassOil";
					case ClassType.P: return "strClassP";
					case ClassType.SOY: return "strClassSoy";
					case ClassType.TRAY: return "strClassTray";
					case ClassType.NONE: return "strClassNone";
					case ClassType.OTHER:
					default: return "strClassOther";
				};
			}
		}
	}

	public enum ClassType
	{
		OTHER,
		CH,
		COLOR,
		OIL,
		P,
		SOY,
		TRAY,
		NONE
	}
}
