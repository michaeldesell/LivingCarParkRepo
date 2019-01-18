using System;
using CarParkLogic.Factory;
using System.Threading.Tasks;
using WebApiModels.Model;

namespace CarParkLogic
{
    public static class CarParkDataLogic
    {
        /*
         * CarParkDataLogic contains all logic that is required for calculations.
         * We want to keep logic and calculations away from the controller to keep the code as clean
         * as possible.
         */
        public static int[] CarsArrivingAndLeaving(UserCarPark currentcarsinpark=null)
        {

            //currentcarsinpark should not be zero. WHen db is in place we need to actually fetch the current amount of cars from db.
            //int currentcarsinpark = 0;
            int[] CarData;
            //int carsarriving = CarParkFunctions.CarsArriving();
            //int carsleaving = CarParkFunctions.CarsLeaving();
            //int cardiff=
            CarData = CarParkFunctions.CarsSubtract(currentcarsinpark);
            currentcarsinpark.Amountofcars = CarData[0];
            currentcarsinpark.develop_pressure += CarData[5];
            currentcarsinpark.carpark_rating = CarData[6];
            //if(CarData[1]!=0)
            //{
            //    //Call the api to make the changes//
            //    //CarData[1] is difference in cars
            //    var data4 = await ApiClientFactory.Instance.ChangeCars(new WebApiModels.ChangeCars() { Fk_carpark = currentcarsinpark.Id, change_in_cars = CarData[1] });

            //    currentcarsinpark.Amountofcars = CarData[0];
            //}
            //else
            //{
            //    // THe change in cars were zero so no update needed.
            //}


            ////Here we should subtract or add the number of cars from the carpark in db//

            ////currentcarsinpark.Amountofcars = CarAmount;
            return CarData;
        }
     
    }
}
