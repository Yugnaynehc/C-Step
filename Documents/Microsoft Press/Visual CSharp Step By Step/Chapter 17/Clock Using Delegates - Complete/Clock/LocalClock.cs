using System;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Timers;

namespace Delegates
{
	class LocalClock
	{
        private DispatcherTimer ticker = null;
        private TextBox display = null;
        private TimeZoneInfo timeZoneForThisClock = null;

        public LocalClock(TextBox displayBox)
        {
            this.timeZoneForThisClock = TimeZoneInfo.Local;
            this.display = displayBox;
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
            DateTime clockTIme = TimeZoneInfo.ConvertTime(localTime, this.timeZoneForThisClock);
            int hh = clockTIme.Hour;
            int mm = clockTIme.Minute;
            int ss = clockTIme.Second;
            this.RefreshTime(hh, mm, ss);
        }

		private void RefreshTime(int hh, int mm, int ss)
		{
			this.display.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", hh, mm, ss);
		}
    }
}
