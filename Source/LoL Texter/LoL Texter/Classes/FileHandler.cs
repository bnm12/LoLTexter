using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoL_Texter.Classes
{
	class FileHandler
	{
		//Usefull paths
		private string _defaultPath;
		private string _defaultLocale;
		private string _appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

		public FileHandler(string defaultPath)
		{
			_defaultPath = defaultPath;
		}

		public FileHandler(string defaultPath, string defaultLocale) : this(defaultPath)
		{
			_defaultLocale = defaultLocale;
		}

		public bool DoBackup()
		{
			if (_defaultLocale != null)
			{
				return DoBackup(_defaultPath, _defaultLocale);
			}
			return false;
		}

		public bool DoBackup(string fullPath)
		{
			string filename = Path.GetFileName(fullPath);
			if (filename != null)
			{
				string locale = filename.Replace("fontconfig_", "");
				return DoBackup(fullPath.Replace(filename, ""), locale.Replace(".txt", ""));
			}

			return false;
		}

		public bool DoBackup(string rootPath, string locale)
		{

			File.Copy(Path.Combine(rootPath, "fontconfig_" + locale + ".txt"), Path.Combine(rootPath, "backup.LTX"));
			if(File.Exists(Path.Combine(_defaultPath, "backup.loltxt")))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool SaveLines(string [] lines)
		{
			if(_defaultLocale != null)
			{
				return SaveLines(lines, _defaultLocale);
			}
			return false;
		}

		public bool SaveLines(string[] lines, string locale)
		{
			if (!File.Exists(Path.Combine(_defaultPath, "backup.loltxt")))
			{
				DoBackup();
			}

			File.WriteAllLines(Path.Combine(_defaultPath, "fontconfig_" + locale + ".txt"), lines);
			return File.ReadAllLines(Path.Combine(_defaultPath, "fontconfig_" + locale + ".txt")).Equals(lines);
		}

		public bool Restore()
		{
			if (_defaultLocale != null)
			{
				return Restore(_defaultLocale);
			}
			return false;
		}

		public bool Restore(string locale)
		{
			return Restore(_defaultPath, locale);
		}

		public bool Restore(string path, string locale)
		{
			File.Copy(Path.Combine(path, "backup.loltxt"), Path.Combine(path, "fontconfig_" + locale + ".txt"), true);
			return File.ReadAllLines(Path.Combine(path, "fontconfig_" + locale + ".txt")).Equals(File.ReadAllLines(Path.Combine(path, "backup.loltxt")));
		}
	}
}
