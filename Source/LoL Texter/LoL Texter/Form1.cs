using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoL_Texter.Classes;

namespace LoL_Texter
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void TSmi_exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void LV_Files_DragDrop(object sender, DragEventArgs e)
		{
			MessageBox.Show("hmmm");
		}

		private void LV_Files_DragEnter(object sender, DragEventArgs e)
		{
			if ((e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link)
			{
				Array data = ((IDataObject)e.Data).GetData("FileName") as Array;
				if (data != null)
				{
					bool valid = false;

					foreach (var path in data)
					{
						string extension = Path.GetExtension((string) path);
						if (extension != null) valid = extension.ToLower() == ".LTX".ToLower();
					}

					if(valid)
					{
						e.Effect = DragDropEffects.Link;
					}
				}
			}
		}

		private void BTN_LoadCurrent_Click(object sender, EventArgs e)
		{
			Thread Loader = new Thread(new ParameterizedThreadStart(LoadFile));
			Loader.Start(PathFinder.FullPath);
		}

		private void LoadFile(object path)
		{
			ConfigHandler configHandler = new ConfigHandler((string)path);
			SetEditorLines(configHandler.Config);
		}

		private delegate void SetEditorLinesCallBack(Dictionary<string, string> allLines);
		private void SetEditorLines(Dictionary<string, string> allLines)
		{
			if (this.LW_Config.InvokeRequired)
			{
				SetEditorLinesCallBack d = new SetEditorLinesCallBack(SetEditorLines);
				this.Invoke(d, new object[] { allLines });
			}
			else
			{
				foreach (KeyValuePair<string, string> keyValuePair in allLines)
				{
					ListViewItem LI = new ListViewItem(keyValuePair.Key);
					LI.SubItems.Add(keyValuePair.Value);
					this.LW_Config.Items.Add(LI);
				}
			}
		}

		private void TSmi_Restore_Click(object sender, EventArgs e)
		{
			FileHandler fh = new FileHandler(PathFinder.FontConfigFolder, PathFinder.Locale);
			fh.Restore();
		}

		private void BTN_Save_Click(object sender, EventArgs e)
		{
//			FileHandler fh = new FileHandler(PathFinder.FontConfigFolder, PathFinder.Locale);
//			fh.SaveLines(RT_EditArea.Lines);
		}
	}
}
