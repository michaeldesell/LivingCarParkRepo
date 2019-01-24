using System;
using CarParkLogic;
using System.Diagnostics;
using System.Timers;
using WebApiModels.Model;
using System.Threading;
using CarParkApi.Data.Entities;

namespace ConsoleClient
{
    class Program
    {


        public static Carpark carpark = null;
        static void Main(string[] args)
        {
            Carpark carpark = new Carpark();
            CarsArrivingAndLeaving(carpark);


        }

        public static void CarsArrivingAndLeaving(Carpark carpark)
        {
            while (true == true)
            {
                carpark = CarParkDataLogic.CarsArrivingAndLeaving(carpark);
                foreach (Floor f in carpark.Floors)
                {
                    Console.WriteLine("Floor: " + f.Floornumber);

                    foreach (Parkingspace ps in f.Parkingspaces)
                    {
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Parking space: " + ps.Name);
                        Console.WriteLine("Available: " + ps.Available);
                        if (ps.Parkedcar != null)
                            Console.WriteLine("Parked car: " + ps.Parkedcar.Name);
                    }

                }
                Console.WriteLine("Cars arriving: " + carpark.Carsarriving);
                Console.WriteLine("Cars leaving: " + carpark.Carsleaving);
                Console.WriteLine("Floors: " + carpark.Floors.Count);
                Console.WriteLine("Parked cars: " + carpark.Amountparkedcars);
                Console.WriteLine("Rating: " + carpark.carpark_rating);
                Console.WriteLine("Dev. pressure: " + carpark.develop_pressure);

                Console.ReadKey();
            }





        }
    }
}
