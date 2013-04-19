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
		private ConfigHandler configHandler;
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
			Loader.Name = "File Loader";
			Loader.Start(PathFinder.FullPath);
		}

		private void LoadFile(object path)
		{
			configHandler = new ConfigHandler((string)path);
			Debug.Print(configHandler.Name);
			SetEditorLines(configHandler.Config);
		}

		private delegate void SetEditorLinesCallBack(DataTable data);
		private void SetEditorLines(DataTable data)
		{
			if (this.dataView.InvokeRequired)
			{
				SetEditorLinesCallBack d = new SetEditorLinesCallBack(SetEditorLines);
				this.Invoke(d, new object[] { data });
			}
			else
			{
				dataView.DataSource = data;
			}
		}

		private void TSmi_Restore_Click(object sender, EventArgs e)
		{
			FileHandler fh = new FileHandler(PathFinder.FontConfigFolder, PathFinder.Locale);
			fh.Restore();
		}

		private void BTN_Save_Click(object sender, EventArgs e)
		{		
			FileHandler fh = new FileHandler(PathFinder.FontConfigFolder, PathFinder.Locale);
			if(fh.SaveLines(configHandler.AssembleConfig().ToArray()))
			{
				MessageBox.Show("Saved!");
			}
			else
			{
				MessageBox.Show("Save Failed!");
			}
		}

		private void loadCurrentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Thread Loader = new Thread(new ParameterizedThreadStart(LoadFile));
			Loader.Name = "File Loader";
			Loader.Start(PathFinder.FullPath);
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileHandler fh = new FileHandler(PathFinder.FontConfigFolder, PathFinder.Locale);
			if (fh.SaveLines(configHandler.AssembleConfig().ToArray()))
			{
				MessageBox.Show("Saved!");
			}
			else
			{
				MessageBox.Show("Save Failed!");
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileHandler fh = new FileHandler(PathFinder.FontConfigFolder, PathFinder.Locale);
			SaveFileDialog SF = new SaveFileDialog();
			SF.AddExtension = true;
			SF.AutoUpgradeEnabled = true;
			SF.DefaultExt = ".LTX";
			SF.Title = "Choose where to save your file";

			DialogResult result = SF.ShowDialog();
			if (result == DialogResult.OK || result == DialogResult.Yes)
			{
				Stream myStream = SF.OpenFile();
				StreamWriter sw = new StreamWriter(myStream);
				configHandler.AssembleConfig().ForEach(sw.WriteLine);
				sw.Close();
			}
		}
	}
}
