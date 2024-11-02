using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackingCursorPosition
{
	public partial class TrackingCursorPosition : Form
	{
		List<Point> CursorPath = new List<Point>();
		public TrackingCursorPosition()
		{
			InitializeComponent();
		}

		private void StartTrackingButton_Click(object sender, EventArgs e)
		{
			timer1.Enabled = true;
			StopTrackingButton.Enabled = true;
			StartTrackingButton.Enabled = false;

			labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
			labelTime.Visible = true;
		}

		private void StopTrackingButton_Click(object sender, EventArgs e)
		{
			timer1.Enabled = false;
			StartButton.Enabled = true;


			labelTime.Visible = false;
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			timerSimulation.Enabled = true;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			CursorPath.Add(new Point(Cursor.Position.X, Cursor.Position.Y));
			labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
		}

		int i = 0;
		private void timerSimulation_Tick(object sender, EventArgs e)
		{
			Cursor.Position = CursorPath[i++];
			if (i >= CursorPath.Count) timerSimulation.Enabled = false;
		}
	}
}
