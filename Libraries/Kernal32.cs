using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Recycle.Libraries
{
	public static class Kernal32
	{
		[DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern bool WritePrivateProfileString(string sectionName, string keyName, string keyValue, string filePath);

		[DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern int GetPrivateProfileString(string sectionName, string keyName, string defaultReturnString, StringBuilder returnString, int returnStringLength, string filePath);

		public static void ReadFromINI(this Dictionary<string, string> source, string section, string filename)
		{
			var length = 255;
			var sb = new StringBuilder(length);
			foreach (var key in source.Keys.ToArray())
			{
				GetPrivateProfileString(
					sectionName: section,
					keyName: key,
					defaultReturnString: string.Empty,
					returnString: sb,
					returnStringLength: length,
					filename);
				source[key] = sb.ToString();
			}
		}
	}
}
