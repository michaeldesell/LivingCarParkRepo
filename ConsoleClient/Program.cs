using System;
using CarParkLogic;
using System.Diagnostics;
using System.Timers;


namespace ConsoleClient
{
    class Program
    {

       
        public static int currentcars = 0;
        static void Main(string[] args)
        {
             Timer watch = new Timer();

        watch.Interval = 10000;
            watch.Enabled = true;
            watch.Elapsed += new ElapsedEventHandler(CarsArrivingAndLeaving);
            watch.AutoReset = true;
            watch.Start();

            Console.ReadKey();
          
        }

        public  static void CarsArrivingAndLeaving(object o,ElapsedEventArgs e)
        {
            Console.WriteLine("Timer was raised");
            currentcars=CarParkDataLogic.CarsArrivingAndLeaving(currentcars);

            Console.WriteLine(" Current cars in carpark is " + currentcars.ToString());
        }
    }
}
