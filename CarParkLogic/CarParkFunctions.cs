using System;
using System.Collections.Generic;
using System.Text;
using WebApiModels.Model;
using CarParkApi.Data.Entities;

namespace CarParkLogic
{
    static class CarParkFunctions
    {

        public static Carpark CarsArriving(Carpark carpark)
        {
            List<Car> que = new List<Car>();
            Random Rgenerate = new Random();

            int cars = Rgenerate.Next(10);

            for (int i = 0; i < cars; i++)
            {
                carpark = ParkCar(carpark, new Car(Guid.NewGuid().ToString()));
            }
            carpark.Carsarriving = cars;
            return carpark;
        }
        public static Carpark CarsLeaving(Carpark carpark)
        {
            Random Rgenerate = new Random();

            int cars = Rgenerate.Next(carpark.Amountparkedcars);

            for (int i = 0; i < cars; i++)
            {
                foreach (Floor f in carpark.Floors)
                {
                    foreach (Parkingspace ps in f.Parkingspaces)
                    {
                        if (!ps.Available && new Random().Next(2) == 1)
                        {
                            ps.Parkedcar = null;
                            ps.Available = true;
                            carpark.Amountparkedcars--;
                        }
                    }
                }
            }

            carpark.Carsleaving = cars;
            return carpark;
        }

        public static int ratingmodifier(int carparkrating, bool negative_calculate)
        {
            int mod = 0;

            if ((carparkrating >= 0 && !negative_calculate))
                mod = carparkrating / 10;

            else if ((carparkrating >= 0 && negative_calculate))
                mod = -(carparkrating / 10);

            return mod;

        }


        public static Carpark ParkCar(Carpark carpark, Car car)
        {
            /*Function that tries to find the first available parking space in the carpark.
            If an available parking space is found, the car is parked and the rating goes up.
            If no space is found, decrease rating and increase development pressure.*/

            bool foundparking = false;
            foreach (Floor f in carpark.Floors)
            {
                foreach (Parkingspace ps in f.Parkingspaces)
                {
                    if (ps.Available)
                    {

                        ps.Parkedcar = car;
                        ps.Available = false;
                        foundparking = true;
                        carpark.carpark_rating++;
                        carpark.Amountparkedcars++;
                        break;
                    }
                    if (foundparking)
                        break;
                }
            }

            if (!foundparking)
            {
                carpark.carpark_rating--;
                carpark.develop_pressure++;
            }

            return carpark;
        }
        public static Carpark DoesCarParkNeedDevelop(Carpark carpark)
        {

            if (carpark.develop_pressure >= 100)
            {
                carpark.Floors.Add(new Floor(carpark.Floors.Count + 1, carpark.SpacesperFloor));
                carpark.carpark_rating = carpark.carpark_rating + 5;
                carpark.develop_pressure = 0;
            }
            return carpark;
        }

       
    }
}
