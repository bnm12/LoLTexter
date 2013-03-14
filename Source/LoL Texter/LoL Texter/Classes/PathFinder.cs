using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LoL_Texter.Classes
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
			else
			{
				FolderBrowserDialog picker = new FolderBrowserDialog();
				picker.Description = "Locate your \"League of Legends\" folder (the one with the .exe files)";
				picker.RootFolder = Environment.SpecialFolder.MyComputer;
				picker.ShowNewFolderButton = false;
				DialogResult result = picker.ShowDialog();

				if(result == DialogResult.OK)
				{
					RADSPath = Path.Combine(picker.SelectedPath, "RADS");
				}
				else
				{
					MessageBox.Show("Exitting");
					Application.Exit();
				}
			}

			// Parse Config file to get the locale
			string[] lines = File.ReadAllLines(RADSPath + @"\system\locale.cfg");
			string[] lineParts = lines[0].Split('=');
			string[] lineparts = lineParts[1].Trim().Split('_');
			Locale = lineparts[0].ToLower() + "_" + lineparts[1].ToUpper();

			ProjectFolder = "lol_game_client_" + Locale.ToLower();

			// Build the string to the latest release folder
			string pathToLatest = RADSPath + @"\projects\" + ProjectFolder;

            var dirs = Directory.GetDirectories(pathToLatest + @"\managedfiles").OrderBy(d => new FileInfo(d).CreationTime).ToList();

            string latestVersion = dirs[dirs.Count - 1];
			FontConfigFolder = latestVersion + @"\Data\Menu";

			string file = "fontconfig_" + Locale + ".txt";
			FullPath = Path.Combine(FontConfigFolder, file);
		}
	}
}

