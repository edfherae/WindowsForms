namespace TrackingCursorPosition
{
	partial class TrackingCursorPosition
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
			this.StartTrackingButton = new System.Windows.Forms.Button();
			this.StopTrackingButton = new System.Windows.Forms.Button();
			this.StartButton = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timerSimulation = new System.Windows.Forms.Timer(this.components);
			this.labelTime = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// StartTrackingButton
			// 
			this.StartTrackingButton.Location = new System.Drawing.Point(10, 332);
			this.StartTrackingButton.Name = "StartTrackingButton";
			this.StartTrackingButton.Size = new System.Drawing.Size(112, 54);
			this.StartTrackingButton.TabIndex = 0;
			this.StartTrackingButton.Text = "StartTracking";
			this.StartTrackingButton.UseVisualStyleBackColor = true;
			this.StartTrackingButton.Click += new System.EventHandler(this.StartTrackingButton_Click);
			// 
			// StopTrackingButton
			// 
			this.StopTrackingButton.Enabled = false;
			this.StopTrackingButton.Location = new System.Drawing.Point(12, 392);
			this.StopTrackingButton.Name = "StopTrackingButton";
			this.StopTrackingButton.Size = new System.Drawing.Size(110, 46);
			this.StopTrackingButton.TabIndex = 1;
			this.StopTrackingButton.Text = "StopTracking";
			this.StopTrackingButton.UseVisualStyleBackColor = true;
			this.StopTrackingButton.Click += new System.EventHandler(this.StopTrackingButton_Click);
			// 
			// StartButton
			// 
			this.StartButton.Enabled = false;
			this.StartButton.Location = new System.Drawing.Point(688, 392);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(100, 46);
			this.StartButton.TabIndex = 2;
			this.StartButton.Text = "Start";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timerSimulation
			// 
			this.timerSimulation.Interval = 10;
			this.timerSimulation.Tick += new System.EventHandler(this.timerSimulation_Tick);
			// 
			// labelTime
			// 
			this.labelTime.AutoSize = true;
			this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTime.Location = new System.Drawing.Point(332, 32);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(100, 37);
			this.labelTime.TabIndex = 3;
			this.labelTime.Text = "label1";
			this.labelTime.Visible = false;
			// 
			// TrackingCursorPosition
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.labelTime);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.StopTrackingButton);
			this.Controls.Add(this.StartTrackingButton);
			this.Name = "TrackingCursorPosition";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button StartTrackingButton;
		private System.Windows.Forms.Button StopTrackingButton;
		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timerSimulation;
		private System.Windows.Forms.Label labelTime;
	}
}

