using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace LoL_Texter
{
	public static class PathFinder
	{
		public static string RADSPath;
		public static string Locale;
		public static string ProjectFolder;
		public static string FontConfigFolder;
		public static string FullPath;

		static PathFinder()
		{
			// Find install directory
			var openSubKey = Registry.CurrentUser.OpenSubKey(@"Software\Riot Games\RADS");
			if (openSubKey != null)
				RADSPath = openSubKey.GetValue("LocalRootFolder").ToString();

			// Parse Config file to get the locale
			string[] lines = File.ReadAllLines(RADSPath + @"\system\locale.cfg");
			string[] lineParts = lines[0].Split('=');
			Locale = lineParts[1].Trim();

			ProjectFolder = "lol_game_client_" + Locale;

			// Build the string to the latest release folder
			string pathToLatest = RADSPath + @"\projects\" + ProjectFolder;
			string[] dirs = Directory.GetDirectories(pathToLatest + @"\managedfiles");
			string latestVersion = dirs[dirs.Length - 1];
			FontConfigFolder = latestVersion + @"\Data\Menu";

			string file = Directory.GetFiles(FontConfigFolder)[0];
			FullPath = FontConfigFolder + @"\" + file;
		}
	}
}

