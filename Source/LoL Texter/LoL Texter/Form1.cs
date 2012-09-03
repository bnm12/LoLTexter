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
			Debug.Print(PathFinder.FullPath);
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
						if (extension != null) valid = extension.ToLower() == ".LOLTXT";
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
			SetEditorLines(File.ReadAllLines((string)path));

		}

		private delegate void SetEditorLinesCallBack(string[] readAllLines);
		private void SetEditorLines(string[] readAllLines)
		{
			if (this.RT_EditArea.InvokeRequired)
			{
				SetEditorLinesCallBack d = new SetEditorLinesCallBack(SetEditorLines);
				this.Invoke(d, new object[] { readAllLines });
			}
			else
			{
				this.RT_EditArea.Lines = readAllLines;
			}
		}

		private void TSmi_Restore_Click(object sender, EventArgs e)
		{

		}

		private void BTN_Save_Click(object sender, EventArgs e)
		{
			FileHandler fh = new FileHandler(PathFinder.FontConfigFolder, PathFinder.Locale);
			fh.SaveLines(RT_EditArea.Lines);
		}
	}
}
