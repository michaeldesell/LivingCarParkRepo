using System;
using CarParkLogic.Factory;
using System.Threading.Tasks;
using WebApiModels;
using System.Collections;
using System.Collections.Generic;

namespace CarParkLogic
{
    public static class CarParkDataLogic
    {
        /*
         * CarParkDataLogic contains all logic that is required for calculations.
         * We want to keep logic and calculations away from the controller to keep the code as clean
         * as possible.
         */
        public static Carpark CarsArrivingAndLeaving(CarParkModel carpark)
        {

            carpark = CarParkFunctions.CarsLeaving(carpark);
            carpark = CarParkFunctions.CarsArriving(carpark);

            carpark = CarParkFunctions.DoesCarParkNeedDevelop(carpark);
            return carpark;
        }

    }
}
