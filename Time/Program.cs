using System;

namespace Time
{
    class Program
    {
        static void Main(string[] args)
        {

            Time t1 = new Time();
            Console.WriteLine("Time bez podania argumentów: " + t1);

            Time t2 = new Time("12:00:59");
            Console.WriteLine("Time po podaniu stringa do konstruktora: " + t2);

            Time t3 = new Time(22, 0, 33);
            Console.WriteLine("Time po podaniu trzech argumentów do konstruktora: " + t3);

            TimePeriod tp1 = new TimePeriod();
            Console.WriteLine("TimePeriod bez podania argumentów: " + tp1);

            TimePeriod tp2 = new TimePeriod(8000);
            Console.WriteLine("TimePeriod po podaniu liczby sekund do konstruktora: "+tp2);

            TimePeriod tp3 = new TimePeriod("3432:19");
            Console.WriteLine("TimePeriod po podaniu stringa do konstruktora: " + tp3);

            TimePeriod tp4 = new TimePeriod(432412, 22, 55);
            Console.WriteLine("TimePeriod po podaniu trzech argumentów do konstruktora: " + tp4);

            TimePeriod tp5 = new TimePeriod(t1, t2);
            Console.WriteLine("TimePeriod po podaniu argumentów w postaci struktury Time do konstruktora: " + tp5);


            Console.WriteLine("Dodawanie TimePeriod do Time: " + t1.Plus(tp2));
            Console.WriteLine("Dodawanie TimePeriod do TimePeriod: " + tp3.Plus(tp4));
            Console.WriteLine("Odejmowanie TimePeriod od TimePeriod: " + tp3.Minus(tp2));
        }
    }
}
