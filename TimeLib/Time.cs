using System;

namespace Time
{
    public struct Time : IEquatable<Time>
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

            byte checkValue(byte value, int min, int max)
            {
                if (value >= min && value <= max)
                    return value;
                else
                    throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            return $"{this.Hour.ToString("D2")}:{this.Minute.ToString("D2")}:{this.Second.ToString("D2")}";
        }

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

        /* private byte checkValue(byte value, int min, int max)
         {
             if (value >= min && value <= max)
                 return value;
             else
                 throw new ArgumentException();
         }*/
    }
}
