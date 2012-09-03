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
		private string _defaultPath;
		private string _defaultLocale;

		public FileHandler(string defaultPath)
		{
			_defaultPath = defaultPath;
		}

		public FileHandler(string defaultPath, string defaultLocale)
		{
			_defaultPath = defaultPath;
			_defaultLocale = defaultLocale;
		}

		public bool DoBackup()
		{
			return DoBackup(_defaultPath, _defaultLocale);
		}

		public bool DoBackup(string fullPath)
		{
			string filename = Path.GetFileName(fullPath);
			string locale = filename.Replace("fontconfig_", "");
			return DoBackup(fullPath.Replace(filename, ""), locale.Replace(".txt", ""));
		}

		public bool DoBackup(string rootPath, string locale)
		{
			File.Copy(rootPath + @"\fontconfig_" + locale + ".txt", rootPath + @"\backup.loltxt");
			if(File.Exists(_defaultPath+@"\backup.loltxt"))
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
			File.WriteAllLines(_defaultPath + @"\fontconfig_" + _defaultLocale + ".txt", lines);
			if(File.ReadAllLines(_defaultPath + @"\fontconfig_" + _defaultLocale + ".txt").Equals(lines))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
