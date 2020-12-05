using System;

namespace Time
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(12,0,59);
            Time t11 = new Time(12);
            Time t2 = new Time("00:44:02");
            Time t22 = new Time("00:44:02");
            

            var tt = t1.Equals(t11);
            var tr = t2.Equals(t2);

            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Console.WriteLine(tt);
            Console.WriteLine(tr);
        }
    }
}
