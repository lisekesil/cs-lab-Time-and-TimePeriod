using System;
using System.Collections.Generic;
using System.Text;

namespace Time
{
    struct TimePeriod
    {
        private long _seconds;
        public readonly long Seconds => _seconds;


        public TimePeriod(int hours, byte minutes, byte seconds = 0)
        {
            this._seconds = hours * 3600 + minutes * 60 + seconds;
        }

        public TimePeriod(string timePeriod)
        {
            string[] timePeriodArr = timePeriod.Split(":");

            this._seconds = int.Parse(timePeriodArr[0]) * 3600 + byte.Parse(timePeriodArr[1]) * 60 + byte.Parse(timePeriodArr[2]);
        }

        public TimePeriod(long seconds)
        {
            this._seconds = seconds;
        }

        /*public TimePeriod(Time t1, Time t2)
        {
            this._seconds = 
        }*/

        //public override string ToString() => $"{this.Hour.ToString("D2")}:{this.Minute.ToString("D2")}:{this.Second.ToString("D2")}";
    }
}
