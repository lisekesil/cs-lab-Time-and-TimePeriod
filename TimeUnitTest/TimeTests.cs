using Microsoft.VisualStudio.TestTools.UnitTesting;
using Time;

namespace TimeUnitTest
{
    [TestClass]
    public class TimeTests
    {
        #region -------Time Constructors-------
        [TestMethod]
        public void TimeConstructor_WithoutArguments_Default()
        {
            var defaultTime = new Time.Time(0, 0, 0);
            
            var time = new Time.Time();

            Assert.AreEqual(defaultTime, time);
        }

        [TestMethod]
        [DataRow("14:55:21", (byte)14, (byte)55, (byte)21)]
        [DataRow("1:11:59", (byte)1, (byte)11, (byte)59)]
        [DataRow("2:4:9", (byte)2, (byte)4, (byte)9)]
        public void TimeConstructor_StringArgument(string t, byte h, byte m, byte s)
        {
            var time = new Time.Time(t);

            Assert.AreEqual(time, new Time.Time(h, m, s));
        }

        [TestMethod]
        [DataRow((byte)12, (byte)12, (byte)0, (byte)0)]
        [DataRow((byte)23, (byte)23, (byte)0, (byte)0)]
        [DataRow((byte)1, (byte)1, (byte)0, (byte)0)]
        public void TimeConstructor_HourArgument(byte t, byte h, byte m, byte s)
        {
            var time = new Time.Time(t);

            Assert.AreEqual(time, new Time.Time(h, m, s));
        }    
        
        [TestMethod]
        [DataRow((byte)12, (byte)12, (byte)1, (byte)0)]
        [DataRow((byte)23, (byte)23, (byte)55, (byte)0)]
        [DataRow((byte)1, (byte)1, (byte)37, (byte)0)]
        public void TimeConstructor_HourMinuteArgument(byte t, byte h, byte m, byte s)
        {
            var time = new Time.Time(t, m);

            Assert.AreEqual(time, new Time.Time(h, m, s));
        }    

        [TestMethod]
        [DataRow( (byte)10, (byte)1, (byte)40)]
        [DataRow( (byte)3, (byte)55, (byte)9)]
        [DataRow( (byte)21, (byte)37, (byte)0)]
        public void TimeConstructor_HourMinuteSecondArgument( byte h, byte m, byte s)
        {
            var time = new Time.Time(h, m,s);

            Assert.AreEqual(time, new Time.Time(h, m, s));
        }

        #endregion

        #region -------TimePeriod Constructors-------

        [TestMethod]
        public void TimePeriodConstructor_Default()
        {
            var timePeriod = new TimePeriod();

            Assert.AreEqual(timePeriod, new TimePeriod(0, 0, 0));
        }

        [TestMethod]
        public void TimePeriodConstructor_OnlyHourString()
        {
            var timePeriod = new TimePeriod("1");

            Assert.AreEqual(timePeriod, new TimePeriod(1, 0, 0));
        }

        [TestMethod]
        [DataRow("14:55:21", (uint)14, (byte)55, (byte)21)]
        [DataRow("221:11:59", (uint)221, (byte)11, (byte)59)]
        [DataRow("2:4:9", (uint)2, (byte)4, (byte)9)]
        public void TimePeriodConstructor_StringArgument(string tp, uint h, byte m, byte s)
        {
            var timePeriod = new TimePeriod(tp);

            Assert.AreEqual(timePeriod, new TimePeriod(h, m, s));
        } 
        
        [TestMethod]
        [DataRow( (uint)14, (byte)55, (byte)21)]
        [DataRow( (uint)221, (byte)11, (byte)59)]
        [DataRow( (uint)555555552, (byte)4, (byte)9)]
        public void TimePeriodConstructor_HoursMinutesSecondsArgument( uint h, byte m, byte s)
        {
            var timePeriod = new TimePeriod(h,m,s);

            Assert.AreEqual(timePeriod, new TimePeriod(h, m, s));
        }

        [TestMethod]
        [DataRow( (long) 0)]
        [DataRow( (long)24242)]
        [DataRow( (long)211521371337)]
        public void TimePeriodConstructor_SecondsArgument( long s)
        {
            var timePeriod = new TimePeriod(s);

            Assert.AreEqual(timePeriod, new TimePeriod(s));
        }

        [TestMethod]
        [DataRow("12:22:22", (byte)12, (byte)22,(byte)22, (long) 0)]
        [DataRow("21:15:00", (byte)22, (byte)22,(byte)2, (long)4022)]
        public void TimePeriodConstructor_TimeArguments(string hms, byte h, byte m, byte s, long expectedSeconds)
        {
            var t1 = new Time.Time(hms);
            var t2 = new Time.Time(h, m, s);

            var tp = new TimePeriod(t1, t2);

            Assert.AreEqual(tp, new TimePeriod(expectedSeconds));
        }



        #endregion

        #region ------- ToString Method-------

        [TestMethod]
        public void TimeToString()
        {
            var time = new Time.Time(23, 9, 59);
            var stringTime = "23:09:59";

            Assert.AreEqual(stringTime, time.ToString());
        }
        [TestMethod]
        public void TimePeriodToString()
        {
            var timePeriod = new TimePeriod(222, 1);
            var stringTimePeriod = "222:01:00";

            Assert.AreEqual(stringTimePeriod, timePeriod.ToString());

        }
        #endregion

        #region ------- Equals Method -------

        [TestMethod]
        [DataRow((byte)10, (byte)1, (byte)40,(byte)10, (byte)1, (byte)40)]
        [DataRow((byte)3, (byte)55, (byte)9,(byte)3, (byte)55, (byte)9)]
        [DataRow((byte)21, (byte)37, (byte)0, (byte)21, (byte)37, (byte)0)]
        public void TimeEquals_OtherTime_True(byte h1,byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            var t1 = new Time.Time(h1, m1, s1);
            var t2 = new Time.Time(h2, m2, s2);
            

            Assert.IsTrue(t1 == t2);
        }  
        [TestMethod]
        [DataRow((byte)10, (byte)1, (byte)40,(byte)12, (byte)1, (byte)40)]
        [DataRow((byte)3, (byte)55, (byte)9,(byte)3, (byte)5, (byte)9)]
        [DataRow((byte)21, (byte)37, (byte)0, (byte)21, (byte)37, (byte)20)]
        public void TimeEquals_OtherTime_False(byte h1,byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            var t1 = new Time.Time(h1, m1, s1);
            var t2 = new Time.Time(h2, m2, s2);
            

            Assert.IsFalse(t1 == t2);
        }

        [TestMethod]
        [DataRow((uint)10, (byte)1, (byte)40, "10:1:40")]
        [DataRow((uint)3333, (byte)55, (byte)9, "3333:55:9")]
        [DataRow((uint)21, (byte)37, (byte)0, "21:37")]
        public void TimePeriodEquals_OtherTimePeriod_True(uint h1, byte m1, byte s1, string hms)
        {
            var tp1 = new Time.TimePeriod(h1, m1, s1);
            var tp2 = new Time.TimePeriod(hms);


            Assert.IsTrue(tp1 == tp2);
        }

        [TestMethod]
        [DataRow((uint)110, (byte)1, (byte)40, "10:1:40")]
        [DataRow((uint)13, (byte)55, (byte)9, "03:55:9")]
        [DataRow((uint)22221, (byte)37, (byte)0, "21:37")]
        public void TimePeriodEquals_OtherTimePeriod_False(uint h1, byte m1, byte s1, string hms)
        {
            var tp1 = new Time.TimePeriod(h1, m1, s1);
            var tp2 = new Time.TimePeriod(hms);


            Assert.IsFalse(tp1 == tp2);
        }

        #endregion

        #region -------Time Compare--------

        [TestMethod]
        [DataRow((byte)11, (byte)1, (byte)33, (byte)10, (byte)10, (byte)50)]
        [DataRow((byte)0, (byte)0, (byte)6, (byte)0, (byte)0, (byte)5)]
        public void TimeGreaterThanOtherTime(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            var t1 = new Time.Time(h1, m1, s1);
            var t2 = new Time.Time(h2, m2, s2);

            Assert.IsTrue( t1 > t2);
        }

        [TestMethod]
        [DataRow((byte)11, (byte)1, (byte)33, (byte)10, (byte)10, (byte)50)]
        [DataRow((byte)0, (byte)0, (byte)6, (byte)0, (byte)0, (byte)5)]
        [DataRow((byte)0, (byte)0, (byte)6, (byte)0, (byte)0, (byte)6)]
        public void TimeGreaterOrEqualThanOtherTime(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            var t1 = new Time.Time(h1, m1, s1);
            var t2 = new Time.Time(h2, m2, s2);

            Assert.IsTrue( t1 >= t2);
        }

        [TestMethod]
        [DataRow((byte)11, (byte)1, (byte)33, (byte)11, (byte)10, (byte)50)]
        [DataRow((byte)0, (byte)0, (byte)6, (byte)20, (byte)0, (byte)5)]
        public void TimeLesserThanOtherTime(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            var t1 = new Time.Time(h1, m1, s1);
            var t2 = new Time.Time(h2, m2, s2);

            Assert.IsTrue( t1 < t2);
        }

        [TestMethod]
        [DataRow((byte)11, (byte)1, (byte)33, (byte)11, (byte)10, (byte)50)]
        [DataRow((byte)0, (byte)0, (byte)6, (byte)20, (byte)0, (byte)5)]
        [DataRow((byte)0, (byte)0, (byte)6, (byte)0, (byte)0, (byte)6)]
        public void TimeLesserOrEqualThanOtherTime(byte h1, byte m1, byte s1, byte h2, byte m2, byte s2)
        {
            var t1 = new Time.Time(h1, m1, s1);
            var t2 = new Time.Time(h2, m2, s2);

            Assert.IsTrue(t1 <= t2);
        }

        #endregion

        #region -------TimePeriod Compare-------

        [TestMethod]
        [DataRow((long)2115, (long)2114)]
        [DataRow((long)21999999999915, (long)2112222224)]
        public void TimePeriodGreaterThanOtherTimePeriod(long s1, long s2)
        {
            var tp1 = new TimePeriod(s1);
            var tp2 = new TimePeriod(s2);

            Assert.IsTrue(tp1 > tp2);
        }

        [TestMethod]
        [DataRow((long)2115, (long)2114)]
        [DataRow((long)21999999999915, (long)2112222224)]
        [DataRow((long)0, (long)0)]
        public void TimePeriodGreaterOrEqualThanOtherTimePeriod(long s1, long s2)
        {
            var tp1 = new TimePeriod(s1);
            var tp2 = new TimePeriod(s2);

            Assert.IsTrue(tp1 >= tp2);
        }

        [TestMethod]
        [DataRow((long)215, (long)2114)]
        [DataRow((long)2199915, (long)2112222224)]
        public void TimePeriodLesserThanOtherTimePeriod(long s1, long s2)
        {
            var tp1 = new TimePeriod(s1);
            var tp2 = new TimePeriod(s2);

            Assert.IsTrue(tp1 < tp2);
        }   
        
        [TestMethod]
        [DataRow((long)215, (long)2114)]
        [DataRow((long)2199915, (long)2112222224)]
        [DataRow((long)0, (long)0)]
        public void TimePeriodLesserOrEqualThanOtherTimePeriod(long s1, long s2)
        {
            var tp1 = new TimePeriod(s1);
            var tp2 = new TimePeriod(s2);

            Assert.IsTrue(tp1 <= tp2);
        }
        #endregion

        #region -------Plus and Minus operators-------
        [TestMethod]
        [DataRow((byte)0, (byte)0,(byte)53, (long)3600, "1:00:53")]
        [DataRow((byte)23, (byte)0,(byte)0, (long)8000, "1:13:20")]
        public void TimePlusTimePeriod(byte h1,byte m1, byte s1, long s2, string expectedTime)
        {
            var time = new Time.Time(h1, m1, s1);
            var timePeriod = new TimePeriod(s2);

            Assert.AreEqual(time + timePeriod, new Time.Time(expectedTime));
        }

        [TestMethod]
        [DataRow((long)4000, (long)4000,(long) 8000)]
        [DataRow((long)4000, (long)2222000,(long) 2226000)]
        public void TimePeriodPlusTimePeriod(long s1, long s2, long s3)
        {
            var tp1 = new TimePeriod(s1);
            var tp2 = new TimePeriod(s2);

            Assert.AreEqual(tp1 + tp2, new TimePeriod(s3));
        }  
        
        [TestMethod]
        [DataRow((long)4000, (long)4000,(long) 0)]
        [DataRow((long)4000, (long)2000,(long) 2000)]
        public void TimePeriodMinusTimePeriod(long s1, long s2, long s3)
        {
            var tp1 = new TimePeriod(s1);
            var tp2 = new TimePeriod(s2);

            Assert.AreEqual(tp1 - tp2, new TimePeriod(s3));
        }
        #endregion
    }
}
