using System;


namespace CarParkLogic
{
    public static class CarParkDataLogic
    {
        /*
         * CarParkDataLogic contains all logic that is required for calculations.
         * We want to keep logic and calculations away from the controller to keep the code as clean
         * as possible.
         */
        public static int CarsArrivingAndLeaving()
        {
           
            int CarAmount = 0;

            //currentcarsinpark should not be zero. WHen db is in place we need to actually fetch the current amount of cars from db.
            int currentcarsinpark = 0;

            int carsarriving = CarParkFunctions.CarsArriving();
            int carsleaving = CarParkFunctions.CarsLeaving();

            CarAmount = CarParkFunctions.CarsSubtract(carsarriving, carsleaving, currentcarsinpark);

            //Here we should subtract or add the number of cars from the carpark in db//
            return CarAmount;
        }
     
    }
}
