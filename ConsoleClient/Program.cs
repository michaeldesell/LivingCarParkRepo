using System;
using CarParkLogic;
using System.Diagnostics;
using System.Timers;
using WebApiModels.Model;
using System.Threading;

namespace ConsoleClient
{
    class Program
    {


        public static UserCarPark carpark = null;
        static void Main(string[] args)
        {
            bool run = true;
            UserCarPark carpark = new UserCarPark();
            carpark.Amountofcars = 0;
            carpark.Floors = 0;
            carpark.Parkingspace = 8;
            Console.WriteLine("Amount of cars: " + carpark.Amountofcars);
            Console.WriteLine("Floors: " + carpark.Floors);
            Console.WriteLine("Parking space: " + carpark.Parkingspace);
            Console.WriteLine("Rating: " + carpark.carpark_rating);
            Console.WriteLine("Dev. pressure: " + carpark.develop_pressure);

            do
            {
                Thread.Sleep(1000);
                CarsArrivingAndLeaving(carpark);
                Console.Clear();
                Console.WriteLine("Amount of cars: " + carpark.Amountofcars);
                Console.WriteLine("Floors: " + carpark.Floors);
                Console.WriteLine("Parking space: " + carpark.Parkingspace);
                Console.WriteLine("Rating: " + carpark.carpark_rating);
                Console.WriteLine("Dev. pressure: " + carpark.develop_pressure);


            }

            while (run);


        }

        public static void CarsArrivingAndLeaving(UserCarPark carpark)
        {
            Console.WriteLine("Timer was raised");

            carpark = CarParkDataLogic.CarsArrivingAndLeaving(carpark);

            
        }
    }
}
