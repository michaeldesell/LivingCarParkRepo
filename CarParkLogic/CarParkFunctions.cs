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

            cars = Rgenerate.Next(carpark.Parkingspace-carpark.Amountofcars) + ratingmodifier(carpark.carpark_rating, false);

            return cars;
        }
        public static int CarsLeaving(UserCarPark carpark)
        {
            Random Rgenerate = new Random();
            int cars = 0;
            cars = Rgenerate.Next(carpark.Amountofcars) + ratingmodifier(carpark.carpark_rating, true); ;
            return cars;
        }

        public static int ratingmodifier(int carparkrating, bool negative_calculate)
        {
            int mod = 0;

            if ((carparkrating >= 0 && !negative_calculate))
                mod = carparkrating / 10;

            else if((carparkrating >= 0 && negative_calculate))
                mod = -(carparkrating / 10);

            return mod;

        }


        public static UserCarPark AddCar(UserCarPark carpark)
        {
            bool canpark = carpark.Amountofcars < carpark.Parkingspace;

            if (canpark)
            {
                carpark.Amountofcars++;
                carpark.carpark_rating++;
                if (carpark.Amountofcars < 0)
                    carpark.Amountofcars = 0;
            }
            else
            {
                carpark.carpark_rating = carpark.carpark_rating - 5;
                if (carpark.carpark_rating < 0)
                    carpark.carpark_rating = 0;
                carpark.develop_pressure++;
            }
            return carpark;
        }
        public static int Leftbecausenospace(int difference, int maxspaces, int totaltcars)
        {
            int left = 0;


            //int[] currentcars = { 0, 0, carparks.develop_pressure, carparks.carpark_rating};
            if (totaltcars > maxspaces)
            {
                left = (totaltcars - maxspaces);
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

        public static int DoesCarParkNeedDevelop(int currentcars, int currentspace, int difference)
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

        public static int DoesCarParkGoesUpInRating(int currentcars, int currentspace, int difference)
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
            else if (difference > 0)
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
