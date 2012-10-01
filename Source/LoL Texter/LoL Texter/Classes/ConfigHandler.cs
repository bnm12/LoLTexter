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
		public Dictionary<string, string> Config = new Dictionary<string, string>();
		private List<string> _headder = new List<string>();
		private string _configFilePath;

		public ConfigHandler(string configFilePath)
		{
			_configFilePath = configFilePath;
			Config = readConfig(_configFilePath);
		}

		private Dictionary<string, string> readConfig(string path)
		{
			Dictionary<string, string> returnLines = new Dictionary<string, string>();
			FileStream fs = new FileStream(path, FileMode.Open);
			StreamReader reader = new StreamReader(fs);

			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				
				if(line.StartsWith("tr "))
				{
					int firstIndex = line.IndexOf('"');
					int secondIndex = line.IndexOf('"', firstIndex + 1);
					string key = line.Substring(firstIndex + 1, secondIndex - (firstIndex + 1));

					int thirdIndex = line.IndexOf('"', secondIndex + 1);
					int fourthindex = line.IndexOf('"', thirdIndex + 1);
					string value = line.Substring(thirdIndex + 1, fourthindex - (thirdIndex + 1));

					returnLines.Add(key, value);
				}
				else
				{
					_headder.Add(line);
				}
			}
			return returnLines;
		}

		public List<string> AssembleConfig()
		{
			List<string> returnList = new List<string>();
			returnList.AddRange(_headder);

			foreach (KeyValuePair<string, string> keyValuePair in Config)
			{
				returnList.Add("tr \"" + keyValuePair.Key + "\" = \"" + keyValuePair.Value + "\"");
			}

			return returnList;
		}
	}
}
