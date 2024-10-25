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
			Time.AddHours(Convert.ToDouble(labelHours.Text));
		}

		private void ButtonMinutePlus_Click(object sender, EventArgs e)
		{
			labelMinutes.Text = Convert.ToString(Convert.ToInt32(labelMinutes.Text) + 1);
			Time.AddMinutes(Convert.ToDouble(labelMinutes.Text));
		}

		private void ButtonSecondPlus_Click(object sender, EventArgs e)
		{
			labelSeconds.Text = Convert.ToString(Convert.ToInt32(labelSeconds.Text) + 1);
			Time.AddSeconds(Convert.ToDouble(labelSeconds.Text));
		}

		private void ButtonHourMinus_Click(object sender, EventArgs e)
		{
			labelHours.Text = Convert.ToString(
				(Convert.ToInt32(labelHours.Text) - 1) < 0 ? 0 : Convert.ToInt32(labelHours.Text) - 1
				);
			Time.AddHours(Convert.ToDouble(labelHours.Text));
		}

		private void ButtonMinuteMinus_Click(object sender, EventArgs e)
		{
			labelMinutes.Text = Convert.ToString(
				(Convert.ToInt32(labelMinutes.Text) - 1) < 0 ? 0 : Convert.ToInt32(labelMinutes.Text) - 1
				);
			Time.AddMinutes(Convert.ToDouble(labelMinutes.Text));
		}

		private void ButtonSecondMinus_Click(object sender, EventArgs e)
		{
			labelSeconds.Text = Convert.ToString(
				(Convert.ToInt32(labelSeconds.Text) - 1) < 0 ? 0 : Convert.ToInt32(labelSeconds.Text) - 1
				);
			Time.AddSeconds(Convert.ToDouble(labelSeconds.Text));
			//Time.
		}
	}
}
