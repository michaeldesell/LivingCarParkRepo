using System;
using System.Collections.Generic;
using System.Text;
using WebApiModels.Model;

namespace CarParkLogic
{
    static class CarParkFunctions
    {
       
        public static int CarsArriving(UserCarPark carpark)
        {
            Random Rgenerate = new Random();
            int cars = 0;

            cars=Rgenerate.Next(7)+ratingmodifier(carpark.carpark_rating,false);
            return cars;
        }
        public static int CarsLeaving(UserCarPark carpark)
        {
            Random Rgenerate = new Random();
            int cars = 0;
            cars=Rgenerate.Next(5)+ratingmodifier(carpark.carpark_rating,true);
            return cars;
        }

        public static int ratingmodifier(int carparkrating,bool negative_calculate)
        {
            int mod = 0;
            //carparkrating = 0;
            //carparkrating = -25;
            if ((carparkrating>=0 && !negative_calculate) || (carparkrating < 0 && negative_calculate))
            {

                 mod = carparkrating / 10;
            }
         
            return mod;

        }

        public static int[] IsCarparkFull(int cars,int difference,UserCarPark carparks)
        {
            int[] currentcars = { 0, 0, carparks.develop_pressure, carparks.carpark_rating};
            if (cars > (carparks.Floors * carparks.Parkingspace))
            {
                currentcars[0] = (carparks.Floors * carparks.Parkingspace);
                currentcars[1] = currentcars[0] - cars;
                currentcars[2] += currentcars[1];
                currentcars[3] += currentcars[2];
            }
            else if(difference>0)
            {
                currentcars[0] = cars;
                currentcars[3] += difference;
            }
            else if(difference<=0)
            {
                currentcars[3] += 1;
            }

            
            return currentcars;
        }

        public static int[] CarsSubtract(UserCarPark currentpark)
        {
            //int currentcars = currentpark.Amountofcars;
            int[] currentcars = { 0, 0,0,0,0,0 };
            int arriving = CarsArriving(currentpark);
            int leaving = CarsLeaving(currentpark);

            currentcars= IsCarparkFull((currentpark.Amountofcars + (arriving - leaving)), (arriving - leaving), currentpark);

            //[0]=Current cars
            //[1]= Difference in arriving and leaving
            //[2]=arriving cars
            //[3]=leaving cars
            //[4]=Left because of no space
            //[5]=ParkPoints 
            return new int[] {currentcars[0] , (arriving - leaving), arriving, leaving, currentcars[1], currentcars[2], currentcars[3] };
        }

        public static bool FloorNeedsBuild()
        {
            bool needsbuild = false;

            Random Rgenerate = new Random();
            int cars = 0;

            cars = Rgenerate.Next(6);
            return needsbuild;
           
        }
    }
}
