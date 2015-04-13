using System;
using System.Windows.Forms;
using System.Media;

namespace Pomodor_Timer
{
    public partial class Form1 : Form
    {
        Clock NewClock = new Clock();
        bool Stop = false;
        bool Break = false;
        public Form1()
        {
            InitializeComponent(); 
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (this.Stop)
            {
                this.StartBtn.Text = "Start";
                this.timer1.Stop();
                this.NewClock.ResetClock();
                this.Stop = false;
            }
            else
            {
                this.StartBtn.Text = "Stop";
                this.timer1.Start();
                this.Stop = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.NewClock.UpdateClock();
            this.TimerLabel.Text = this.NewClock.GetTime();
            
            if (this.Break)
            {
                if (this.NewClock.Minutes >= 4)
                {
                    this.NewClock.ResetClock();
                    this.Break = false;
                    using (var soundPlayer = new SoundPlayer(@"c:\Windows\Media\Alarm1.wav"))
                    {
                        soundPlayer.Play();
                    }
                }
            }
            else
            {
                if (this.NewClock.Minutes >= 25)
                {
                    this.NewClock.ResetClock();
                    this.Break = true;
                    using (var soundPlayer = new SoundPlayer(@"c:\Windows\Media\Alarm1.wav"))
                    {
                        soundPlayer.Play();
                    }
                }
            }
        }
    }
}
