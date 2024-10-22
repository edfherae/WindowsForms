using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace Clock
{
	public partial class MainForm : Form
	{
		//ColorDialog backgroundColorDialog; // это лишь ссылка на объект, при разыменовании будет null
		ColorDialog backgroundColorDialog;
		ColorDialog foregroundColorDialog;
		//FontDialog fontDialog;
		ChooseFont chooseFontDialog;
		public MainForm()
		{
			InitializeComponent();
			SetFontDirectory();

			this.TransparencyKey = Color.Empty;
			backgroundColorDialog = new ColorDialog();
			foregroundColorDialog = new ColorDialog();

			chooseFontDialog = new ChooseFont();

			//fontDialog = new FontDialog();
			foregroundColorDialog.Color = Color.Black;
			backgroundColorDialog.Color = Color.Green;
			this.Location = new Point
				(
				System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - this.Width,
				50
				);
			SetVisibility(false);
			
			this.Text += $" Location: {Location.X}x{Location.Y}";
		}
		private void SetFontDirectory()
		{
			string location = Assembly.GetEntryAssembly().Location; //получаем полный адрес .exe
			//MessageBox.Show(location);
			string path = Path.GetDirectoryName( location ); //из адреса извлекаем путь к файлу
			//MessageBox.Show(Directory.GetCurrentDirectory()); //System.IO
			//Directory.SetCurrentDirectory($"{Assembly.GetEntryAssembly().Location}\\..\\..\\..\\fonts");
			Directory.SetCurrentDirectory($"{path}\\..\\..\\fonts");// \\.. - переход на уровень выше
			//MessageBox.Show(Directory.GetCurrentDirectory()); //System.IO
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
			if (cbShowDate.Checked)
			{
				labelTime.Text += $" {DateTime.Today.ToString("yyyy.MM.dd")}";
			}
			notifyIconSystemTray.Text = "Current time: " + labelTime.Text;
		}
		private void SetVisibility(bool visible)
		{
			this.TransparencyKey = visible ? Color.Empty : this.BackColor;
			this.FormBorderStyle = visible ? FormBorderStyle.Sizable : FormBorderStyle.None;
			this.ShowInTaskbar = visible;
			cbShowDate.Visible = visible;
			btnHideControls.Visible = visible;
			labelTime.BackColor = visible ? Color.Empty : Color.Coral;
			WindowState = visible ? FormWindowState.Normal : FormWindowState.Maximized;

			//Как это работает?
			//.Location
			//SetBounds(value.X, value.Y, width, height, BoundsSpecified.Location);
			Point labelpoint = new Point(18, 26);
			labelTime.Location = visible ? labelpoint : new Point(labelTime.Location.X, labelTime.Location.Y);

			//Screen screen = Screen.PrimaryScreen;
			//labelTime.Location = new Point(System.Windows.Forms.Screen.GetBounds();

			//WindowState = FormWindowState.Maximized;
			//labelTime.Location = new Point(600, 100);
		}
		private void labelTime_DoubleClick(object sender, EventArgs e)
		{
			//SetVisibility(true); 
			showControlsToolStripMenuItem.Checked = true;

			//почему-то, кнопка Скрыть элементы не работает, если здесь стоит SetVisibility, а не .Checked = true
			//почему то вызывается на одинарный клик
		}

		private void btnHideControls_Click(object sender, EventArgs e)
		{
			showControlsToolStripMenuItem.Checked = false;
			//SetVisibility(false); 
			notifyIconSystemTray.ShowBalloonTip(3, "Alerts!", "Для того чтобы вернуть как было, нужно ткнуть 2 раза мышей по часам, или по этой иконке", ToolTipIcon.Warning);
			//MessageBox.Show("Hide controls");
		}
		private void notifyIconSystemTray_MouseMove(object sender, MouseEventArgs e)
		{
			notifyIconSystemTray.Text = "Curret time:\n" + labelTime.Text;
		}

		private void notifyIconSystemTray_BalloonTipClicked(object sender, EventArgs e)
		{
			SetVisibility(true);
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{

		}

		private void notifyIconSystemTray_MouseClick(object sender, MouseEventArgs e)
		{
			//contextMenuStrip1.
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void topmostToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			this.TopMost = this.TopMost ? this.TopMost = false : TopMost = true;
		}
		private void showControlsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			//if (showControlsToolStripMenuItem.Checked) { SetVisibility(false); this.showControlsToolStripMenuItem.Checked = false; }
			//else { SetVisibility(true); this.showControlsToolStripMenuItem.Checked = true; }
			SetVisibility(((ToolStripMenuItem)sender).Checked);
		}

		private void showDateToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			cbShowDate.Checked = ((ToolStripMenuItem)sender).Checked;
		}

		private void cbShowDate_CheckedChanged(object sender, EventArgs e)
		{
			showDateToolStripMenuItem.Checked = ((CheckBox)sender).Checked;
		}

		private void notifyIconSystemTray_DoubleClick(object sender, EventArgs e)
		{
			if(!TopMost) 
			{
				TopMost = true;
				TopMost = false;
			}
		}

		private void foregroundToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//ColorDialog омжно и через toolbox
			if(foregroundColorDialog.ShowDialog(this) == DialogResult.OK) 
			{
				labelTime.ForeColor = foregroundColorDialog.Color;
			}
		}

		private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(backgroundColorDialog.ShowDialog(this) == DialogResult.OK) 
			{
				labelTime.BackColor = backgroundColorDialog.Color;
			}
		}
		private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (chooseFontDialog.ShowDialog() == DialogResult.OK)
			{
				labelTime.Font = chooseFontDialog.ChosenFont;
			}
		}

		private void labelTime_MouseEnter(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Maximized)labelTime.Cursor = Cursors.SizeAll;
			//this.Cursor = new Cursor()
		}
		private void labelTime_MouseClick(object sender, MouseEventArgs e)
		{
			
		}

		private void labelTime_MouseDown(object sender, MouseEventArgs e)
		{
			
		}
		private void labelTime_MouseUp(object sender, MouseEventArgs e)
		{
			//labelTime.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
			//MessageBox.Show($"Label X: {labelTime.Location.X} Y: {labelTime.Location.Y}\nCursor X:{Cursor.Position.X}, Y:{Cursor.Position.Y}");

			//int x = e.X < Screen.PrimaryScreen.Bounds.X ? Screen.PrimaryScreen.Bounds.X : e.X > Screen.PrimaryScreen.Bounds.Width ? Screen.PrimaryScreen.Bounds.Width : e.X;
			//int y = e.Y < Screen.PrimaryScreen.Bounds.Y ? Screen.PrimaryScreen.Bounds.Y : e.Y > Screen.PrimaryScreen.Bounds.Height ? Screen.PrimaryScreen.Bounds.Height : e.Y;
			//labelTime.Location = new Point(x, y);

			//MessageBox.Show($"Label X: {labelTime.Location.X} Y: {labelTime.Location.Y}\n" +
				//$"Cursor X:{e.X}, Y:{e.Y}\n");
		}

		private void MainForm_Click(object sender, EventArgs e)
		{
			//MessageBox.Show($"{Cursor.Position.X}, {Cursor.Position.Y}");
		}

		private void labelTime_MouseLeave(object sender, EventArgs e)
		{
			labelTime.Cursor = Cursors.Default;
		}
		//static int labelX = Button.MouseButtons == Mou
		private void labelTime_MouseMove(object sender, MouseEventArgs e)
		{
			//int x = e.X < Screen.PrimaryScreen.Bounds.X ? Screen.PrimaryScreen.Bounds.X : e.X > Screen.PrimaryScreen.Bounds.Width ? Screen.PrimaryScreen.Bounds.Width : e.X;
			//int y = e.Y < Screen.PrimaryScreen.Bounds.Y ? Screen.PrimaryScreen.Bounds.Y : e.Y > Screen.PrimaryScreen.Bounds.Height ? Screen.PrimaryScreen.Bounds.Height : e.Y;
			if (WindowState != FormWindowState.Maximized)labelTime.Cursor = Cursors.Default;

			if (Button.MouseButtons == MouseButtons.Left)
			{
				//if (WindowState == FormWindowState.Normal)
				//{
					//int x = Cursor.Position.X < this.Location.X ? this.Location.X : Cursor.Position.X > this.Width ? this.Width : Cursor.Position.X;
					//int y = Cursor.Position.Y < this.Location.Y ? this.Location.Y : Cursor.Position.Y > this.Height ? this.Height : Cursor.Position.Y;
					//labelTime.Location = new Point(x - 50, y - 50);
					//this.Text = $"x: {x}, y: {y}";
				//}
				//else 
				//{
				if (WindowState == FormWindowState.Maximized)
				{
					int x = Cursor.Position.X < Screen.PrimaryScreen.Bounds.X ? Screen.PrimaryScreen.Bounds.X : Cursor.Position.X > Screen.PrimaryScreen.Bounds.Width ? Screen.PrimaryScreen.Bounds.Width : Cursor.Position.X;
					int y = Cursor.Position.Y < Screen.PrimaryScreen.Bounds.Y ? Screen.PrimaryScreen.Bounds.Y : Cursor.Position.Y > Screen.PrimaryScreen.Bounds.Height ? Screen.PrimaryScreen.Bounds.Height : Cursor.Position.Y;
					labelTime.Location = new Point(x - 50, y - 35);
					this.Text = $"x: {x}, y: {y}";
				}
				//}
			}
		}
	}
}
