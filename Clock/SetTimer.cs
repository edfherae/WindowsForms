using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
	public partial class SetTimer : Form
	{
		DateTime Time { get; set; }
		public SetTimer()
		{
			InitializeComponent();
		}

		private void ButtonHourPlus_Click(object sender, EventArgs e)
		{
			labelHours.Text = Convert.ToString(Convert.ToInt32(labelHours.Text) + 1);
			Time = Time.AddHours(Convert.ToDouble(labelHours.Text));
		}

		private void ButtonMinutePlus_Click(object sender, EventArgs e)
		{
			labelMinutes.Text = Convert.ToString(Convert.ToInt32(labelMinutes.Text) + 1);
			Time = Time.AddMinutes(Convert.ToDouble(labelMinutes.Text));
		}

		private void ButtonSecondPlus_Click(object sender, EventArgs e)
		{
			labelSeconds.Text = Convert.ToString(Convert.ToInt32(labelSeconds.Text) + 1);
			Time = Time.AddSeconds(Convert.ToDouble(labelSeconds.Text));
		}

		private void ButtonHourMinus_Click(object sender, EventArgs e)
		{
			labelHours.Text = Convert.ToString(
				(Convert.ToInt32(labelHours.Text) - 1) < 0 ? 0 : Convert.ToInt32(labelHours.Text) - 1
				);
			Time = Time.AddHours(Convert.ToDouble(labelHours.Text));
		}

		private void ButtonMinuteMinus_Click(object sender, EventArgs e)
		{
			labelMinutes.Text = Convert.ToString(
				(Convert.ToInt32(labelMinutes.Text) - 1) < 0 ? 0 : Convert.ToInt32(labelMinutes.Text) - 1
				);
			Time = Time.AddMinutes(Convert.ToDouble(labelMinutes.Text));
		}

		private void ButtonSecondMinus_Click(object sender, EventArgs e)
		{
			labelSeconds.Text = Convert.ToString(
				(Convert.ToInt32(labelSeconds.Text) - 1) < 0 ? 0 : Convert.ToInt32(labelSeconds.Text) - 1
				);
			Time = Time.AddSeconds(Convert.ToDouble(labelSeconds.Text));
			//Time.
		}

		private void ButtonOk_Click(object sender, EventArgs e)
		{
			timer1.Enabled = true;
			string hours = labelHours.Text == "0" ? "" : labelHours.Text + "ч ";
			string minutes = labelMinutes.Text == "0" ? "" : labelMinutes.Text + "м ";
			string seconds = labelSeconds.Text == "0" ? "" : labelSeconds.Text + "с ";
			MessageBox.Show($"Таймер прозвонит через {hours}{minutes}{seconds}");
			labelHours.Text = "0";
			labelMinutes.Text = "0";
			labelSeconds.Text = "0";
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			//labelSeconds.Text = 
			//if(Convert.ToInt32(labelSeconds.Text) == 0)
			//{
			//	if(Convert.ToInt32(labelMinutes.Text) == 0)
			//	{
			//		if(Convert.ToInt32(labelHours.Text) != 0)
			//	}
			//}
			if(Time.Second > 0)Time = Time.AddSeconds(-1);
			else
			{
				timer1.Enabled = false;
				MessageBox.Show("My time has come");
			}
		}
	}
}
