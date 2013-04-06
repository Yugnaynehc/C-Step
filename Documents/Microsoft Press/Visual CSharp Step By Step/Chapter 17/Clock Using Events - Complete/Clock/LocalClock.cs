using System;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Timers;

namespace Delegates
{
	class LocalClock
	{
        private DispatcherTimer ticker = null;
        //private TextBox display = null;
        private TimeZoneInfo timeZoneForThisClock = null;
        public delegate void DisplayTime(string time);
        public event DisplayTime LocalClockTick;

        public LocalClock()
        {
            this.timeZoneForThisClock = TimeZoneInfo.Local;
            //this.display = displayBox;
        }

        public void StartLocalClock()
        {
            this.ticker = new DispatcherTimer();
            this.ticker.Tick += this.OnTimedEvent;
            this.ticker.Interval = new TimeSpan(0, 0, 1); // 1 second
            this.ticker.Start();
        }

        public void StopLocalClock()
        {
            this.ticker.Stop();
        }

        private void OnTimedEvent(object source, EventArgs args)
        {
            DateTime localTime = DateTime.Now;
            DateTime clockTime = TimeZoneInfo.ConvertTime(localTime, this.timeZoneForThisClock);
            int hh = clockTime.Hour;
            int mm = clockTime.Minute;
            int ss = clockTime.Second;
            this.RefreshTime(hh, mm, ss);
        }

		private void RefreshTime(int hh, int mm, int ss)
		{
            if (this.LocalClockTick != null)
            {
                this.LocalClockTick(String.Format("{0:D2}:{1:D2}:{2:D2}", hh, mm, ss));
            }
		}
    }
}
