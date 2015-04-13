using System;

namespace PomodoroTimer
{
    class Clock
    {
        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public int Counter { get; set; }

        public string GetTime()
        {
            string TempString = String.Format("{0}:{1}", this.Minutes, this.Seconds);
            return TempString;
        }

        public void UpdateClock()
        {
            this.Seconds = this.Seconds + 1;
            if (this.Seconds >= 60)
            {
                this.Seconds = 0;
                this.Minutes = this.Minutes + 1;
            }
        }

        public void ResetClock()
        {
            this.Seconds = 0;
            this.Minutes = 0;
            this.Counter = 0;
        }
    }
}
