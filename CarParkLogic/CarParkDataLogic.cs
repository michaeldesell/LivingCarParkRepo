using System;
using CarParkLogic.Factory;
using System.Threading.Tasks;
using WebApiModels.Model;
using System.Collections;


namespace CarParkLogic
{
    public static class CarParkDataLogic
    {
        /*
         * CarParkDataLogic contains all logic that is required for calculations.
         * We want to keep logic and calculations away from the controller to keep the code as clean
         * as possible.
         */
        public static UserCarPark CarsArrivingAndLeaving(UserCarPark carpark)
        {
            ArrayList arrivingque = null;
            ArrayList leavingque = null;
            bool CarsareArriving = false;
            bool CarsareLeaving = false;

            //Randomize cars arriving and leaving
            var carsarriving = CarParkFunctions.CarsArriving(carpark);
            var carsleaving = CarParkFunctions.CarsLeaving(carpark);

            //Initiate ques
            if (carsarriving > 0)
                arrivingque = new ArrayList(new int[carsarriving]);
            if (carpark.Amountofcars > 0 && carsleaving > 0)
                leavingque = new ArrayList(new int[carsleaving]);

            CarsareArriving = arrivingque != null;
            CarsareLeaving = leavingque != null;

            //Iterate through both ques

            while (CarsareArriving || CarsareLeaving)
            {
                if (CarsareLeaving)
                {
                    leavingque.RemoveAt(0);
                    carpark.Amountofcars -= carpark.Amountofcars;
                    if (carpark.Amountofcars < 0)
                        carpark.Amountofcars = 0;
                    CarsareLeaving = leavingque.Count > 0;
                }

                if (CarsareArriving)
                {
                    carpark = CarParkFunctions.AddCar(carpark);
                    arrivingque.RemoveAt(0);
                    CarsareArriving = arrivingque.Count > 0;
                }
            }

            //Check if car park needs another floor

            if ((carpark.develop_pressure + carpark.Floors) > 100)
            {
                carpark.Floors++;
                carpark.develop_pressure = 0;
                carpark.Parkingspace += 8;
                carpark.carpark_rating += 5;
            }

                                                  
            return carpark;
        }

    }
}
