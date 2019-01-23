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

        public static int AddCars(int difference, int maxspaces, int totaltcars)
        {
            int currentcars = 0;
           

            //int[] currentcars = { 0, 0, carparks.develop_pressure, carparks.carpark_rating};
            if (totaltcars > maxspaces)
            {
                currentcars = maxspaces;
                //currentcars[1] = currentcars[0] - cars;
                //currentcars[2] += currentcars[1];
                //currentcars[3] += currentcars[2];
            }
            else
            {
                currentcars += difference;
            }

            //Current cars cannot be less than zero
            if (currentcars < 0)
                currentcars = 0;
            //else if (difference > 0)
            //{
            //    currentcars[0] = cars;
            //    currentcars[3] += difference;
            //}
            //else if (difference <= 0)
            //{
            //    currentcars[0] = cars;
            //    currentcars[3] += 1;
            //}


            return currentcars;
        }
        public static int Leftbecausenospace(int difference, int maxspaces, int totaltcars)
        {
            int left = 0;


            //int[] currentcars = { 0, 0, carparks.develop_pressure, carparks.carpark_rating};
            if (totaltcars > maxspaces)
            {
                left = (totaltcars-maxspaces);
                //currentcars[1] = currentcars[0] - cars;
                //currentcars[2] += currentcars[1];
                //currentcars[3] += currentcars[2];
            }
            else
            {
                left = 0;
            }

            

            return left;
        }

        public static int DoesCarParkNeedDevelop(int currentcars,int currentspace, int difference)
        {
            int Developoints = 0;
            if (currentcars > currentspace)
            {
                Developoints += (currentcars - currentspace);
                //currentcars[0] = (carparks.Floors * carparks.Parkingspace);
                //currentcars[1] = currentcars[0] - cars;
                //currentcars[2] += currentcars[1];
                //currentcars[3] += currentcars[2];
            }
            //else if (difference > 0)
            //{

            //    //currentcars[0] = cars;
            //    //currentcars[3] += difference;
            //}
            //else if (difference <= 0)
            //{
            //    //currentcars[0] = cars;
            //    //currentcars[3] += 1;
            //}


            return Developoints;
        }

        public static int DoesCarParkGoesUpInRating(int currentcars,int currentspace, int difference)
        {

            int CarParkRating = 0;
            if (currentcars > currentspace)
            {
                //there is not enoug parkingspace. Subtract for each car that does not fit
                CarParkRating -= (currentcars - currentspace);
                //currentcars[0] = (carparks.Floors * carparks.Parkingspace);
                //currentcars[1] = currentcars[0] - cars;
                //currentcars[2] += currentcars[1];
                //currentcars[3] += currentcars[2];
            }
            else if(difference>0)
            {
                //there is enoug parkingspace. add for each car that does fit
                CarParkRating += difference;
            }
            else
            {
                //no new car arrived. add +1 rating so the rating slowly starts returning
                CarParkRating += 1;
            }


            return CarParkRating;
        }

        public static int[] CarsSubtract(UserCarPark currentpark)
        {
            //int currentcars = currentpark.Amountofcars;
            int[] currentcars = { 0, 0,0,0,0,0 };
            int arriving = CarsArriving(currentpark);
            int leaving = CarsLeaving(currentpark);
            int difference = (arriving - leaving);
            int carsneedspacek = (currentpark.Amountofcars + difference);
            //int allcars = (currentpark.Amountofcars + (arriving - leaving))>=0 ? (currentpark.Amountofcars + (arriving - leaving)):0;
            int maxspaces = (currentpark.Floors * currentpark.Parkingspace);
            int totaltcars = (currentpark.Amountofcars + difference);
           
            int devpoints = DoesCarParkNeedDevelop(carsneedspacek, maxspaces, difference);
            int rating=DoesCarParkGoesUpInRating(carsneedspacek, maxspaces, difference);
            int leftbecauseofnospace = Leftbecausenospace(difference, maxspaces, totaltcars);
            int currcars = AddCars(difference, maxspaces, totaltcars);
            int floors = 1;
            //currentcars = IsCarparkFull(allcars, (arriving - leaving), currentpark);


            //[0]=Current cars
            //[1]= Difference in arriving and leaving
            //[2]=arriving cars
            //[3]=leaving cars
            //[4]=Left because of no space
            //[5]=DevPoints 
            //[6]=ParkPoints 
            return new int[] { currcars, difference, arriving, leaving, leftbecauseofnospace, devpoints, rating,floors};
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
