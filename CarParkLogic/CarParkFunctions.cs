using System;
using System.Collections.Generic;
using System.Text;

namespace CarParkLogic
{
    static class CarParkFunctions
    {
       
        public static int CarsArriving()
        {
            Random Rgenerate = new Random();
            int cars = 0;

            cars=Rgenerate.Next(6);
            return cars;
        }
        public static int CarsLeaving()
        {
            Random Rgenerate = new Random();
            int cars = 0;
            cars=Rgenerate.Next(4);
            return cars;
        }

        public static int CarsSubtract(int arriving,int leaving,int currentcars)
        {
            return (currentcars+(arriving - leaving));
        }

        public static bool FloorNeedsBuild()
        {
            bool needsbuild = false;

            return needsbuild;
        }
    }
}
