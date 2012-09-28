using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoL_Texter.Classes
{
	class ConfigHandler
	{
		public Dictionary<string, string> Config;
		private string _configFilePath;

		public ConfigHandler(string configFilePath)
		{
			_configFilePath = configFilePath;
		}
	}
}
