using System;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Timers;

namespace Delegates
{
	class AmericanClock
	{
        private DispatcherTimer ticker = null;
        private TextBox display = null;
        private TimeZoneInfo timeZoneForThisClock = null;
        private const string newYorkTimeZoneId = "Eastern Standard Time";

        public AmericanClock(TextBox displayBox)
        {
            this.timeZoneForThisClock = TimeZoneInfo.FindSystemTimeZoneById(newYorkTimeZoneId);
            this.display = displayBox;
        }

        public void StartAmericanClock()
        {
            this.ticker = new DispatcherTimer();
            this.ticker.Tick += this.OnTimedEvent;
            this.ticker.Interval = new TimeSpan(0, 0, 1); // 1 second
            this.ticker.Start();
        }

        public void StopAmericanClock()
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
