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
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Globalization;
using AxWMPLib;

namespace Clock
{
	public partial class MainForm : Form
	{
		//ColorDialog backgroundColorDialog; // это лишь ссылка на объект, при разыменовании будет null
		ColorDialog backgroundColorDialog;
		ColorDialog foregroundColorDialog;
		//FontDialog fontDialog;
		ChooseFont chooseFontDialog;
		AlarmList alarmList;
		SetTimer setTimerDialog;

		Alarm alarm;

		string FontFile { get; set; }

		public MainForm()
		{
			InitializeComponent();

			AllocConsole();  


			//RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			//if (!IsStartupItem())
			// Добавить значение в реестр для запуска напару с ОС
			//rkApp.SetValue("Clock.exe", Application.ExecutablePath.ToString());

			//RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

			//if (IsStartupItem())
			// Удаляем
			//rkApp.DeleteValue("Clock.exe", false);

			SetFontDirectory();
			this.TransparencyKey = Color.Empty;
			backgroundColorDialog = new ColorDialog();
			foregroundColorDialog = new ColorDialog();

			chooseFontDialog = new ChooseFont();
			LoadSettings();

			setTimerDialog = new SetTimer();
			alarmList = new AlarmList();

			//fontDialog = new FontDialog();
			//foregroundColorDialog.Color = Color.Black;
			//backgroundColorDialog.Color = Color.Green;
			
			SetVisibility(false);
			this.Location = new Point
				(
				System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - this.Width,
				50
				);
			
			this.Text += $" Location: {Location.X}x{Location.Y}";

			alarm = new Alarm();
			GetNextAlarm();

			this.axWindowsMediaPlayer1.Visible = false;
		}

		/// <summary>
		/// Settings
		/// </summary>

		void SaveSettings()
		{
			StreamWriter sw = new StreamWriter("settings.txt");
			sw.WriteLine(backgroundColorDialog.Color.ToArgb()); //to Argb возвр числовой код цвета
			sw.WriteLine(foregroundColorDialog.Color.ToArgb());
			sw.WriteLine(chooseFontDialog.FontFile.Split('\\').Last());
			sw.WriteLine(topmostToolStripMenuItem.Checked);
			sw.WriteLine(showDateToolStripMenuItem.Checked);
			sw.Close();
			Process.Start("notepad", "settings.txt");
		}
		void LoadSettings()
		{
			//SetFontDirectory();
			StreamReader sr = new StreamReader("settings.txt");
			try
			{
				//sr = new StreamReader("settings.txt");
			}
			catch (FileNotFoundException e)
			{

			}
			List<string> settings = new List<string>();
			while(!sr.EndOfStream)
			{
				settings.Add(sr.ReadLine());
			}
			sr.Close();
			backgroundColorDialog.Color = Color.FromArgb(Convert.ToInt32(settings.ToArray()[0]));
			foregroundColorDialog.Color = Color.FromArgb(Convert.ToInt32(settings.ToArray()[1]));
			FontFile = settings.ToArray()[2];
			labelTime.Font = chooseFontDialog.SetFontFile(FontFile);
			labelTime.ForeColor = foregroundColorDialog.Color;
			labelTime.BackColor = backgroundColorDialog.Color;
			topmostToolStripMenuItem.Checked = bool.Parse(settings.ToArray()[3]);
			showDateToolStripMenuItem.Checked = bool.Parse(settings.ToArray()[4]);

			RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);
			object run = rk.GetValue("Clock");
			if (run != null) loadOnWindowsStartupToolStripMenuItem.Checked = true;
			rk.Dispose();
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
		private void SetVisibility(bool visible)
		{
			WindowState = visible ? FormWindowState.Normal : FormWindowState.Maximized;
			this.TransparencyKey = visible ? Color.Empty : this.BackColor;
			this.FormBorderStyle = visible ? FormBorderStyle.Sizable : FormBorderStyle.None;
			this.ShowInTaskbar = visible;
			cbShowDate.Visible = visible;
			btnHideControls.Visible = visible;
			labelTime.BackColor = visible ? Color.Empty : backgroundColorDialog.Color;

			//Как это работает?
			//.Location
			//SetBounds(value.X, value.Y, width, height, BoundsSpecified.Location);
			Point labelpoint = new Point(18, 26);
			labelTime.Location = visible ? labelpoint : new Point(labelTime.Location.X, labelTime.Location.Y);

			axWindowsMediaPlayer1.Visible = visible;
			//Screen screen = Screen.PrimaryScreen;
			//labelTime.Location = new Point(System.Windows.Forms.Screen.GetBounds();

			//WindowState = FormWindowState.Maximized;
			//labelTime.Location = new Point(600, 100);
		}

		/// <summary>
		/// Event handling
		/// </summary>

		public void GetNextAlarm()
		{
			List<Alarm> alarms = new List<Alarm>();
			foreach (Alarm item in alarmList.ListBoxAlarms.Items)
			{
				if(item.Time.TimeOfDay > DateTime.Now.TimeOfDay)alarms.Add(item);
			}
			if(alarms.Min() != null)alarm = alarms.Min();
			//List<TimeSpan> intervals = new List<TimeSpan>();
			//foreach (Alarm item in alarmList.ListBoxAlarms.Items)
			//{
				//TimeSpan min = new TimeSpan(24,0,0);
				//if (DateTime.Now - item.Time < min) alarm = item;
			//}
            Console.WriteLine(alarm);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
			if (cbShowDate.Checked)labelTime.Text += $" {DateTime.Today.ToString("yyyy.MM.dd")}";
			if (showWeekdayToolStripMenuItem.Checked) labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
			notifyIconSystemTray.Text = "Current time: " + labelTime.Text;
			if (
				alarm != null &&
				alarm.Weekdays[DateTime.Now.DayOfWeek - 1 < 0 ? 6 : (int)DateTime.Now.DayOfWeek - 1] == true &&
				DateTime.Now.Hour == alarm.Time.Hour && 
				DateTime.Now.Minute == alarm.Time.Minute && 
				DateTime.Now.Second == alarm.Time.Second
				)
			{
				MessageBox.Show(alarm.Filename, "Alarm!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine("ALARM:----" + alarm.ToString());
				PlayAlarm();
                GetNextAlarm();
			}
			if(DateTime.Now.Second == 0)
			{
				GetNextAlarm();
                Console.WriteLine("Minute");
            }
		}
		void PlayAlarm()
		{
			//try
			//{
				axWindowsMediaPlayer1.URL = alarm.Filename;

			if(!File.Exists(alarm.Filename))
			{
                Console.WriteLine("Err: File not found");
				axWindowsMediaPlayer1.URL = "..\\Sound\\ДДТ - Это всё";

			}
				axWindowsMediaPlayer1.settings.volume = 30;
				axWindowsMediaPlayer1.Ctlcontrols.play();
				axWindowsMediaPlayer1.Visible = true;
                Console.WriteLine($"PlayAlarm:\t{Directory.GetCurrentDirectory()}");
   //         }
			//catch (Exception ex)
			//{
			//	MessageBox.Show(ex.Message, "Alarm file not found!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//	axWindowsMediaPlayer1.URL = alarm.Filename = "Sound\\ДДТ - Это всё";
			//	axWindowsMediaPlayer1.settings.volume = 30;
			//	axWindowsMediaPlayer1.Visible = true;
			//	axWindowsMediaPlayer1.Ctlcontrols.play();
			//}

			//Path.GetFullPath("music.mp3")
			//axWindowsMediaPlayer1.PLat
		}
		void SetPlayerInvisible(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
		{
			if(axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
				axWindowsMediaPlayer1.Visible = false;
		}

		#region labelTime
		private void labelTime_MouseClick(object sender, MouseEventArgs e)
		{

		}
		private void labelTime_DoubleClick(object sender, EventArgs e)
		{
			//SetVisibility(true); 
			showControlsToolStripMenuItem.Checked = true;

			//почему-то, кнопка Скрыть элементы не работает, если здесь стоит SetVisibility, а не .Checked = true
			//почему то вызывается на одинарный клик
		}
		private void labelTime_MouseEnter(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Maximized) labelTime.Cursor = Cursors.SizeAll;
			//this.Cursor = new Cursor()
		}
		private void labelTime_MouseLeave(object sender, EventArgs e)
		{
			labelTime.Cursor = Cursors.Default;
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
		private void labelTime_MouseDown(object sender, MouseEventArgs e)
		{

		}
		private void labelTime_MouseMove(object sender, MouseEventArgs e)
		{
			//int x = e.X < Screen.PrimaryScreen.Bounds.X ? Screen.PrimaryScreen.Bounds.X : e.X > Screen.PrimaryScreen.Bounds.Width ? Screen.PrimaryScreen.Bounds.Width : e.X;
			//int y = e.Y < Screen.PrimaryScreen.Bounds.Y ? Screen.PrimaryScreen.Bounds.Y : e.Y > Screen.PrimaryScreen.Bounds.Height ? Screen.PrimaryScreen.Bounds.Height : e.Y;
			if (WindowState != FormWindowState.Maximized) labelTime.Cursor = Cursors.Default;

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
		#endregion

		private void btnHideControls_Click(object sender, EventArgs e)
		{
			showControlsToolStripMenuItem.Checked = false;
			//SetVisibility(false); 
			notifyIconSystemTray.ShowBalloonTip(3, "Alerts!", "Для того чтобы вернуть как было, нужно ткнуть 2 раза мышей по часам, или по этой иконке", ToolTipIcon.Warning);
			//MessageBox.Show("Hide controls");
		}

		#region TrayIcon
		private void notifyIconSystemTray_MouseClick(object sender, MouseEventArgs e)
		{
			//contextMenuStrip1.
		}
		private void notifyIconSystemTray_DoubleClick(object sender, EventArgs e)
		{
			if (!TopMost)
			{
				TopMost = true;
				TopMost = false;
			}
		}
		private void notifyIconSystemTray_MouseMove(object sender, MouseEventArgs e)
		{
			notifyIconSystemTray.Text = "Current time:\n" + labelTime.Text;
		}
		private void notifyIconSystemTray_BalloonTipClicked(object sender, EventArgs e)
		{
			SetVisibility(true);
		} 
		#endregion

		#region MenuStrip
		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{

		}

		private void alarmToolStripMenuItem_Click(object sender, EventArgs e)
		{
			alarmList.ShowDialog(this);
			GetNextAlarm();
		}
		private void timerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (setTimerDialog.ShowDialog() == DialogResult.OK)
			{
				//setTimerDialog.
			}
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

		private void foregroundToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//ColorDialog омжно и через toolbox
			if (foregroundColorDialog.ShowDialog(this) == DialogResult.OK)
			{
				labelTime.ForeColor = foregroundColorDialog.Color;
			}
		}
		private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (backgroundColorDialog.ShowDialog(this) == DialogResult.OK)
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
		private void loadOnWindowsStartupToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{

			RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true); //regedit, стрелочки, короткий поиск через клавиатуру, copy key name
			if (loadOnWindowsStartupToolStripMenuItem.Checked) rk.SetValue("Clock", Application.ExecutablePath);
			else rk.DeleteValue("Clock", false);
			rk.Dispose();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveSettings();
			alarmList.SaveAlarmsToFile("alarms.csv");
		}



		[DllImport("kernel32.dll")]
		static extern bool AllocConsole();

		private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
		{

		}
	}
}
