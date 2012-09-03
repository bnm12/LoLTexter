﻿namespace LoL_Texter
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.TS_Main = new System.Windows.Forms.ToolStrip();
			this.TSi_File = new System.Windows.Forms.ToolStripDropDownButton();
			this.TSmi_exit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.TSi_Options = new System.Windows.Forms.ToolStripDropDownButton();
			this.SS_Main = new System.Windows.Forms.StatusStrip();
			this.SS_Progress = new System.Windows.Forms.ToolStripProgressBar();
			this.SS_Status = new System.Windows.Forms.ToolStripStatusLabel();
			this.Container = new System.Windows.Forms.SplitContainer();
			this.LV_Files = new System.Windows.Forms.ListView();
			this.RT_EditArea = new System.Windows.Forms.RichTextBox();
			this.GB_EditorHeader = new System.Windows.Forms.GroupBox();
			this.GB_FileHeader = new System.Windows.Forms.GroupBox();
			this.BTN_LoadCurrent = new System.Windows.Forms.Button();
			this.TSmi_Restore = new System.Windows.Forms.ToolStripMenuItem();
			this.TS_Main.SuspendLayout();
			this.SS_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Container)).BeginInit();
			this.Container.Panel1.SuspendLayout();
			this.Container.Panel2.SuspendLayout();
			this.Container.SuspendLayout();
			this.GB_EditorHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// TS_Main
			// 
			this.TS_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSi_File,
            this.toolStripLabel1,
            this.TSi_Options});
			this.TS_Main.Location = new System.Drawing.Point(0, 0);
			this.TS_Main.Name = "TS_Main";
			this.TS_Main.Size = new System.Drawing.Size(868, 25);
			this.TS_Main.TabIndex = 0;
			this.TS_Main.Text = "toolStrip1";
			// 
			// TSi_File
			// 
			this.TSi_File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.TSi_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSmi_exit});
			this.TSi_File.Image = ((System.Drawing.Image)(resources.GetObject("TSi_File.Image")));
			this.TSi_File.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSi_File.Name = "TSi_File";
			this.TSi_File.Size = new System.Drawing.Size(38, 22);
			this.TSi_File.Text = "File";
			// 
			// TSmi_exit
			// 
			this.TSmi_exit.Name = "TSmi_exit";
			this.TSmi_exit.Size = new System.Drawing.Size(152, 22);
			this.TSmi_exit.Text = "Exit";
			this.TSmi_exit.Click += new System.EventHandler(this.TSmi_exit_Click);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
			// 
			// TSi_Options
			// 
			this.TSi_Options.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.TSi_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSmi_Restore});
			this.TSi_Options.Image = ((System.Drawing.Image)(resources.GetObject("TSi_Options.Image")));
			this.TSi_Options.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSi_Options.Name = "TSi_Options";
			this.TSi_Options.Size = new System.Drawing.Size(62, 22);
			this.TSi_Options.Text = "Options";
			this.TSi_Options.ToolTipText = "Options";
			// 
			// SS_Main
			// 
			this.SS_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SS_Progress,
            this.SS_Status});
			this.SS_Main.Location = new System.Drawing.Point(0, 418);
			this.SS_Main.Name = "SS_Main";
			this.SS_Main.Size = new System.Drawing.Size(868, 22);
			this.SS_Main.TabIndex = 1;
			this.SS_Main.Text = "statusStrip1";
			// 
			// SS_Progress
			// 
			this.SS_Progress.Name = "SS_Progress";
			this.SS_Progress.Size = new System.Drawing.Size(100, 16);
			this.SS_Progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// SS_Status
			// 
			this.SS_Status.Name = "SS_Status";
			this.SS_Status.Size = new System.Drawing.Size(46, 17);
			this.SS_Status.Text = "Loaded";
			// 
			// Container
			// 
			this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Container.Location = new System.Drawing.Point(0, 25);
			this.Container.Name = "Container";
			// 
			// Container.Panel1
			// 
			this.Container.Panel1.Controls.Add(this.GB_FileHeader);
			this.Container.Panel1.Controls.Add(this.LV_Files);
			// 
			// Container.Panel2
			// 
			this.Container.Panel2.Controls.Add(this.GB_EditorHeader);
			this.Container.Panel2.Controls.Add(this.RT_EditArea);
			this.Container.Size = new System.Drawing.Size(868, 393);
			this.Container.SplitterDistance = 289;
			this.Container.TabIndex = 2;
			// 
			// LV_Files
			// 
			this.LV_Files.AllowDrop = true;
			this.LV_Files.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LV_Files.FullRowSelect = true;
			this.LV_Files.Location = new System.Drawing.Point(0, 0);
			this.LV_Files.MultiSelect = false;
			this.LV_Files.Name = "LV_Files";
			this.LV_Files.Size = new System.Drawing.Size(289, 393);
			this.LV_Files.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.LV_Files.TabIndex = 0;
			this.LV_Files.UseCompatibleStateImageBehavior = false;
			this.LV_Files.View = System.Windows.Forms.View.Details;
			this.LV_Files.DragDrop += new System.Windows.Forms.DragEventHandler(this.LV_Files_DragDrop);
			this.LV_Files.DragEnter += new System.Windows.Forms.DragEventHandler(this.LV_Files_DragEnter);
			// 
			// RT_EditArea
			// 
			this.RT_EditArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RT_EditArea.Location = new System.Drawing.Point(0, 0);
			this.RT_EditArea.Name = "RT_EditArea";
			this.RT_EditArea.Size = new System.Drawing.Size(575, 393);
			this.RT_EditArea.TabIndex = 0;
			this.RT_EditArea.Text = "";
			this.RT_EditArea.WordWrap = false;
			// 
			// GB_EditorHeader
			// 
			this.GB_EditorHeader.Controls.Add(this.BTN_LoadCurrent);
			this.GB_EditorHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.GB_EditorHeader.Location = new System.Drawing.Point(0, 0);
			this.GB_EditorHeader.Name = "GB_EditorHeader";
			this.GB_EditorHeader.Size = new System.Drawing.Size(575, 48);
			this.GB_EditorHeader.TabIndex = 1;
			this.GB_EditorHeader.TabStop = false;
			// 
			// GB_FileHeader
			// 
			this.GB_FileHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.GB_FileHeader.Location = new System.Drawing.Point(0, 0);
			this.GB_FileHeader.Name = "GB_FileHeader";
			this.GB_FileHeader.Size = new System.Drawing.Size(289, 48);
			this.GB_FileHeader.TabIndex = 2;
			this.GB_FileHeader.TabStop = false;
			// 
			// BTN_LoadCurrent
			// 
			this.BTN_LoadCurrent.Location = new System.Drawing.Point(6, 19);
			this.BTN_LoadCurrent.Name = "BTN_LoadCurrent";
			this.BTN_LoadCurrent.Size = new System.Drawing.Size(77, 23);
			this.BTN_LoadCurrent.TabIndex = 0;
			this.BTN_LoadCurrent.Text = "Load Current";
			this.BTN_LoadCurrent.UseVisualStyleBackColor = true;
			this.BTN_LoadCurrent.Click += new System.EventHandler(this.BTN_LoadCurrent_Click);
			// 
			// TSmi_Restore
			// 
			this.TSmi_Restore.Name = "TSmi_Restore";
			this.TSmi_Restore.Size = new System.Drawing.Size(155, 22);
			this.TSmi_Restore.Text = "Restore Backup";
			this.TSmi_Restore.Click += new System.EventHandler(this.TSmi_Restore_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(868, 440);
			this.Controls.Add(this.Container);
			this.Controls.Add(this.SS_Main);
			this.Controls.Add(this.TS_Main);
			this.Name = "Form1";
			this.Text = "Form1";
			this.TS_Main.ResumeLayout(false);
			this.TS_Main.PerformLayout();
			this.SS_Main.ResumeLayout(false);
			this.SS_Main.PerformLayout();
			this.Container.Panel1.ResumeLayout(false);
			this.Container.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Container)).EndInit();
			this.Container.ResumeLayout(false);
			this.GB_EditorHeader.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip TS_Main;
		private System.Windows.Forms.ToolStripDropDownButton TSi_File;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.StatusStrip SS_Main;
		private System.Windows.Forms.ToolStripMenuItem TSmi_exit;
		private System.Windows.Forms.ToolStripDropDownButton TSi_Options;
		private System.Windows.Forms.ToolStripProgressBar SS_Progress;
		private System.Windows.Forms.ToolStripStatusLabel SS_Status;
		private System.Windows.Forms.SplitContainer Container;
		private System.Windows.Forms.ListView LV_Files;
		private System.Windows.Forms.RichTextBox RT_EditArea;
		private System.Windows.Forms.GroupBox GB_FileHeader;
		private System.Windows.Forms.GroupBox GB_EditorHeader;
		private System.Windows.Forms.Button BTN_LoadCurrent;
		private System.Windows.Forms.ToolStripMenuItem TSmi_Restore;
	}
}

