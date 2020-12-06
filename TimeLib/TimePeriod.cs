using System;
using System.Collections.Generic;
using System.Text;

namespace Time
{
    public struct TimePeriod
    {
        private long _seconds;
        public readonly long Seconds => _seconds;


        public TimePeriod(uint hours, byte minutes, byte seconds = 0)
        {
            this._seconds = hours * 3600 + checkValue(minutes, 0, 59) * 60 + checkValue(seconds,0,59);
            


        }

        public TimePeriod(string timePeriod)
        {
            string[] timePeriodArr = timePeriod.Split(":");

            var hours = int.Parse(timePeriodArr[0]);
            if (hours < 0) throw new ArgumentException();
            var minutes = checkValue(byte.Parse(timePeriodArr[1]), 0, 59);
            var seconds = checkValue(byte.Parse(timePeriodArr[2]), 0, 59);

            this._seconds = hours * 3600 + minutes * 60 + seconds;
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

        private static byte checkValue(byte value, int min, int max)
        {
            if (value >= min && value <= max)
                return value;
            else
                throw new ArgumentException();
        }
    }
}
