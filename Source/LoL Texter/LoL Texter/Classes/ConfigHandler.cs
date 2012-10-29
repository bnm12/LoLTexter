using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoL_Texter.Classes
{
	class ConfigHandler
	{
		public DataTable Config = new DataTable("Config");
		public string Name;
		private List<string> _headder = new List<string>();
		private string _configFilePath;

		public ConfigHandler(string configFilePath)
		{
			_configFilePath = configFilePath;
			Config = ReadConfig(_configFilePath);
		}

		private DataTable ReadConfig(string path)
		{
			DataTable returnData = new DataTable("Config");
			returnData.Columns.Add("Item", typeof (string));
			returnData.Columns.Add("Property", typeof (string));
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

					returnData.Rows.Add(key, value);
				}
				else if(line.StartsWith("#!"))
				{
					Name = line.Substring(2);
				}
				else
				{
					_headder.Add(line);
				}
			}
			return returnData;
		}

		public List<string> AssembleConfig()
		{
			List<string> returnList = new List<string>();
			returnList.AddRange(_headder);

			foreach (DataRow row in Config.Rows)
			{
				returnList.Add("tr \"" + row[0] + "\" = \"" + row[1] + "\"");
			}

			return returnList;
		}
	}
}
