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

            int[] CarData;
          
            CarData = CarParkFunctions.CarsSubtract(currentcarsinpark);
            //CarData
            //[0]=Current cars
            //[1]= Difference in arriving and leaving
            //[2]=arriving cars
            //[3]=leaving cars
            //[4]=Left because of no space
            //[5]=DevPoints 
            //[6]=ParkPoints
            currentcarsinpark.Amountofcars = CarData[0];
            currentcarsinpark.carpark_rating += CarData[6];
            currentcarsinpark.develop_pressure += CarData[5];

          
            return CarData;
        }
     
    }
}
