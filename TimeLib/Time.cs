using System;

namespace Time
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        private byte _hour, _minute, _second;
        public readonly byte Hour => _hour;
        public readonly byte Minute => _minute;
        public readonly byte Second => _second;

        /// <summary>
        ///  Zwraca godzinę złożoną z parametrów typu byte
        /// </summary>
        /// <param name="hour"> zakres 0-23</param>
        /// <param name="minute">zakres 0-59</param>
        /// <param name="second">zakres 0-59</param>
        public Time(byte hour = 0, byte minute = 0, byte second = 0)
        {
            this._hour = checkValue(hour, 0, 23);
            this._minute = checkValue(minute, 0, 59);
            this._second = checkValue(second, 0, 59);

            byte checkValue(byte value, int min, int max)
            {
                if (value >= min && value <= max)
                    return value;
                else
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// zwraca godzinę z podanego parametru typu string
        /// </summary>
        /// <param name="time">format: "hh:mm:ss"</param>
        public Time(string time)
        {
            string[] timeArr = time.Split(":");
            this._hour = checkValue(byte.Parse(timeArr[0]), 0, 23);
            this._minute = checkValue(byte.Parse(timeArr[1]),0,59);
            this._second = checkValue(byte.Parse(timeArr[2]),0,59);

        }

        public override string ToString() => $"{this.Hour.ToString("D2")}:{this.Minute.ToString("D2")}:{this.Second.ToString("D2")}";
        

        public bool Equals(Time other)
        {
            if (Object.ReferenceEquals(this, other)) return true;

            return (Hour, Minute, Second) == (other.Hour, other.Minute, other.Second);
        }

        public override bool Equals(object obj)
        {
            if (obj is Time)
            {
                return Equals((Time)obj);
            }
            else
                return false;
        }

        public static bool Equals(Time t1, Time t2)
        {
            return t1.Equals(t2);
        }

        public override int GetHashCode() => (Hour, Minute, Second).GetHashCode();


        public int CompareTo(Time other)
        {
            if (this.Equals(other)) return 0;

            if (this.Hour != other.Hour)
                return this.Hour.CompareTo(other.Hour);

            if (this.Minute != other.Minute)
                return this.Minute.CompareTo(other.Minute);

            return this.Second.CompareTo(other.Second);
        }

        public static bool operator ==(Time t1, Time t2) => Equals(t1, t2);
        public static bool operator !=(Time t1, Time t2) => !(t1 == t2);

        public static bool operator <(Time t1, Time t2) => t1.CompareTo(t2) < 0;
        public static bool operator >(Time t1, Time t2) => t1.CompareTo(t2) > 0;
        public static bool operator <=(Time t1, Time t2) => t1.CompareTo(t2) <= 0;
        public static bool operator >=(Time t1, Time t2) => t1.CompareTo(t2) >= 0;

        public static Time operator +(Time t1, TimePeriod tp1) => t1.Plus(tp1);

        public Time Plus (TimePeriod tp1)
        {
            var seconds = this.Hour * 3600 + this.Minute * 60 + this.Second + tp1.Seconds;
            var newHour = (byte)(seconds / 3600 > 23 ? (seconds / 3600) % 24 : seconds / 3600);
            var newMinute = (byte)((seconds / 60) % 60);
            var newSecond = (byte)(seconds % 60);

            return new Time(newHour, newMinute, newSecond);
        }

        public static Time Plus(Time t1, TimePeriod tp1) => t1.Plus(tp1);

     

        private static byte checkValue(byte value, int min, int max)
        {
            if (value >= min && value <= max)
                return value;
            else
                throw new ArgumentException();
        }
    }
}
