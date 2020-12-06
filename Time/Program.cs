using System;

namespace Time
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(12,0,59);
            Time t11 = new Time(12);
            Time t2 = new Time(0,44,02);
            Time t22 = new Time("00:44:02");

            TimePeriod tp1 = new TimePeriod("1222:22:20");
            TimePeriod tp2 = new TimePeriod(8888000);
            Console.WriteLine(tp1);
            Console.WriteLine(tp2);
            var tt = t1.Equals(t11);
            var tr = t2.Equals(t22);

            Console.WriteLine(Time.Plus(t2, tp2));

            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Console.WriteLine(tt);
            Console.WriteLine(tr);
        }
    }
}
