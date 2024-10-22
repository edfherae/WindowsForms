﻿namespace Clock
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.cbShowDate = new System.Windows.Forms.CheckBox();
			this.btnHideControls = new System.Windows.Forms.Button();
			this.labelTime = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.notifyIconSystemTray = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.topmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.showDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.foregroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fontsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.loadOnWIndowsStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbShowDate
			// 
			resources.ApplyResources(this.cbShowDate, "cbShowDate");
			this.cbShowDate.Name = "cbShowDate";
			this.cbShowDate.UseVisualStyleBackColor = true;
			this.cbShowDate.CheckedChanged += new System.EventHandler(this.cbShowDate_CheckedChanged);
			// 
			// btnHideControls
			// 
			resources.ApplyResources(this.btnHideControls, "btnHideControls");
			this.btnHideControls.Name = "btnHideControls";
			this.btnHideControls.UseVisualStyleBackColor = true;
			this.btnHideControls.Click += new System.EventHandler(this.btnHideControls_Click);
			// 
			// labelTime
			// 
			resources.ApplyResources(this.labelTime, "labelTime");
			this.labelTime.Name = "labelTime";
			this.labelTime.DoubleClick += new System.EventHandler(this.labelTime_DoubleClick);
			this.labelTime.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelTime_MouseClick);
			this.labelTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTime_MouseDown);
			this.labelTime.MouseEnter += new System.EventHandler(this.labelTime_MouseEnter);
			this.labelTime.MouseLeave += new System.EventHandler(this.labelTime_MouseLeave);
			this.labelTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTime_MouseMove);
			this.labelTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelTime_MouseUp);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// notifyIconSystemTray
			// 
			this.notifyIconSystemTray.ContextMenuStrip = this.contextMenuStrip1;
			resources.ApplyResources(this.notifyIconSystemTray, "notifyIconSystemTray");
			this.notifyIconSystemTray.BalloonTipClicked += new System.EventHandler(this.notifyIconSystemTray_BalloonTipClicked);
			this.notifyIconSystemTray.DoubleClick += new System.EventHandler(this.notifyIconSystemTray_DoubleClick);
			this.notifyIconSystemTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconSystemTray_MouseClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topmostToolStripMenuItem,
            this.showControlsToolStripMenuItem,
            this.toolStripSeparator1,
            this.showDateToolStripMenuItem,
            this.toolStripSeparator2,
            this.colorsToolStripMenuItem,
            this.fontsToolStripMenuItem,
            this.toolStripSeparator3,
            this.loadOnWIndowsStartupToolStripMenuItem,
            this.toolStripSeparator4,
            this.closeToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			// 
			// topmostToolStripMenuItem
			// 
			this.topmostToolStripMenuItem.CheckOnClick = true;
			this.topmostToolStripMenuItem.Name = "topmostToolStripMenuItem";
			resources.ApplyResources(this.topmostToolStripMenuItem, "topmostToolStripMenuItem");
			this.topmostToolStripMenuItem.CheckedChanged += new System.EventHandler(this.topmostToolStripMenuItem_CheckedChanged);
			// 
			// showControlsToolStripMenuItem
			// 
			this.showControlsToolStripMenuItem.CheckOnClick = true;
			this.showControlsToolStripMenuItem.Name = "showControlsToolStripMenuItem";
			resources.ApplyResources(this.showControlsToolStripMenuItem, "showControlsToolStripMenuItem");
			this.showControlsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showControlsToolStripMenuItem_CheckedChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			// 
			// showDateToolStripMenuItem
			// 
			this.showDateToolStripMenuItem.CheckOnClick = true;
			this.showDateToolStripMenuItem.Name = "showDateToolStripMenuItem";
			resources.ApplyResources(this.showDateToolStripMenuItem, "showDateToolStripMenuItem");
			this.showDateToolStripMenuItem.CheckedChanged += new System.EventHandler(this.showDateToolStripMenuItem_CheckedChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
			// 
			// colorsToolStripMenuItem
			// 
			this.colorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.foregroundToolStripMenuItem,
            this.backgroundColorToolStripMenuItem});
			this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
			resources.ApplyResources(this.colorsToolStripMenuItem, "colorsToolStripMenuItem");
			// 
			// foregroundToolStripMenuItem
			// 
			this.foregroundToolStripMenuItem.Name = "foregroundToolStripMenuItem";
			resources.ApplyResources(this.foregroundToolStripMenuItem, "foregroundToolStripMenuItem");
			this.foregroundToolStripMenuItem.Click += new System.EventHandler(this.foregroundToolStripMenuItem_Click);
			// 
			// backgroundColorToolStripMenuItem
			// 
			this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
			resources.ApplyResources(this.backgroundColorToolStripMenuItem, "backgroundColorToolStripMenuItem");
			this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
			// 
			// fontsToolStripMenuItem
			// 
			this.fontsToolStripMenuItem.Name = "fontsToolStripMenuItem";
			resources.ApplyResources(this.fontsToolStripMenuItem, "fontsToolStripMenuItem");
			this.fontsToolStripMenuItem.Click += new System.EventHandler(this.fontsToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
			// 
			// loadOnWIndowsStartupToolStripMenuItem
			// 
			this.loadOnWIndowsStartupToolStripMenuItem.Name = "loadOnWIndowsStartupToolStripMenuItem";
			resources.ApplyResources(this.loadOnWIndowsStartupToolStripMenuItem, "loadOnWIndowsStartupToolStripMenuItem");
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Controls.Add(this.labelTime);
			this.Controls.Add(this.btnHideControls);
			this.Controls.Add(this.cbShowDate);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Name = "MainForm";
			this.Click += new System.EventHandler(this.MainForm_Click);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbShowDate;
		private System.Windows.Forms.Button btnHideControls;
		private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.NotifyIcon notifyIconSystemTray;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem topmostToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showControlsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem showDateToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fontsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem loadOnWIndowsStartupToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem foregroundToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
	}
}
