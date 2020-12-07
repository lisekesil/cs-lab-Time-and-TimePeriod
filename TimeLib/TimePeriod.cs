using System;
using System.Collections.Generic;
using System.Text;

namespace Time
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
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
            var minutes = 0;
            var seconds = 0;

            var hours = int.Parse(timePeriodArr[0]);
            if (hours < 0) throw new ArgumentException();
            
            if (timePeriodArr.Length > 1)
            {
                minutes = checkValue(byte.Parse(timePeriodArr[1]), 0, 59);
            }

            if(timePeriodArr.Length > 2)
            {
                seconds = checkValue(byte.Parse(timePeriodArr[2]), 0, 59);
            }

            this._seconds = hours * 3600 + minutes * 60 + seconds;
        }

        public TimePeriod(long seconds)
        {
            if (seconds < 0) throw new ArgumentException();
            this._seconds = seconds;
        }

        public TimePeriod(Time t1, Time t2)
        {
            var firstTime = ParseTimeToSeconds(t1);
            var secondTime = ParseTimeToSeconds(t2);
            this._seconds = Math.Abs(firstTime - secondTime);
        }

        public override string ToString()
        {
            var hours = Seconds / 3600;
            var minutes = (Seconds / 60) % 60;
            var seconds = Seconds % 60;

            return $"{hours.ToString("D2")}:{minutes.ToString("D2")}:{seconds.ToString("D2")}";
        }

        public bool Equals(TimePeriod other)
        {
            if (Object.ReferenceEquals(this, other)) return true;

            return Seconds == other.Seconds;
        }

        public override bool Equals(object obj)
        {
            if (obj is TimePeriod)
            {
                return Equals((TimePeriod)obj);
            }
            else
                return false;
        }

        public static bool Equals(TimePeriod t1, TimePeriod t2)
        {
            return t1.Equals(t2);
        }

        public override int GetHashCode() => Seconds.GetHashCode();

        public int CompareTo(TimePeriod other)
        {
            if (this.Equals(other)) return 0;

            return this.Seconds.CompareTo(other.Seconds);
        }

        public static bool operator ==(TimePeriod tp1, TimePeriod tp2) => Equals(tp1, tp2);
        public static bool operator !=(TimePeriod tp1, TimePeriod tp2) => !(tp1 == tp2);

        public static bool operator <(TimePeriod tp1, TimePeriod tp2) => tp1.CompareTo(tp2) < 0;
        public static bool operator >(TimePeriod tp1, TimePeriod tp2) => tp1.CompareTo(tp2) > 0;
        public static bool operator <=(TimePeriod tp1, TimePeriod tp2) => tp1.CompareTo(tp2) <= 0;
        public static bool operator >=(TimePeriod tp1, TimePeriod tp2) => tp1.CompareTo(tp2) >= 0;

        public static TimePeriod operator +(TimePeriod tp1, TimePeriod tp2) => tp1.Plus(tp2);
        public static TimePeriod operator -(TimePeriod tp1, TimePeriod tp2) => tp1.Minus(tp2);

        public TimePeriod Plus(TimePeriod otherTimePeriod) => new TimePeriod(this.Seconds + otherTimePeriod.Seconds);
        public static TimePeriod Plus(TimePeriod tp1, TimePeriod tp2) => new TimePeriod(tp1.Seconds + tp2.Seconds);

        public TimePeriod Minus(TimePeriod othertimePeriod)
        {
            var newSeconds = this.Seconds - othertimePeriod.Seconds;
            if (newSeconds < 0) throw new ArgumentException("Nie można odjąć większego przedziału od mniejszego");
            return new TimePeriod(newSeconds);
        }

        public static TimePeriod Minus(TimePeriod tp1, TimePeriod tp2) => tp1.Minus(tp2);

        private static byte checkValue(byte value, int min, int max)
        {
            if (value >= min && value <= max)
                return value;
            else
                throw new ArgumentException();
        }

        private static long ParseTimeToSeconds(Time t1) => t1.Hour * 3600 + t1.Minute * 60 + t1.Second;
    }
}
