using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace LoL_Text_modder
{
	public static class PathFinder
	{
		public static string RADSpath;
		public static string Locale;

		static PathFinder()
		{
			var openSubKey = Registry.CurrentUser.OpenSubKey(@"Software\Riot Games\RADS");
			if (openSubKey != null)
				RADSpath = openSubKey.GetValue("LocalRootFolder").ToString();
		}

		public static string GetLocale()
		{
			string[] lines = File.ReadAllLines(RADSpath + @"\system\locale.cfg");
			string[] lineParts = lines[0].Split('=');
			Locale = lineParts[1].Trim();

			return Locale;
		}

		public static string GetLatestFilePath(string locale)
		{
			return "";
		}
	}
}
