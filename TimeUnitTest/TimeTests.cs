using Microsoft.VisualStudio.TestTools.UnitTesting;
using Time;

namespace TimeUnitTest
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void Constructor_WithoutArguments_Default()
        {
            var defaultTime = new Time.Time(0, 0, 0);

            var time = new Time.Time();

            Assert.AreEqual(defaultTime, time);
        }
    }
}
