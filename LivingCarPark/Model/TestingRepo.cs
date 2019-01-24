using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiModels.Model;

namespace LivingCarPark.Model
{
    public class TestingRepo
    {

        public static UserCarPark TestingCarPark { get; set; }
        public static IMemoryCache cache { get; set; }
        public TestingRepo()
        {
            
        }

        public static void init()
        {
            if(TestingCarPark == null)
            {
                TestingCarPark = new UserCarPark();
                TestingCarPark.Id = 1;
                TestingCarPark.Floors = 1;
                TestingCarPark.Parkingspace = 4;
                TestingCarPark.Name = " min carpark";
                TestingCarPark.Amountofcars = 0;
            }
            else
            {
                // and just go ahed for testing
                string test = "";
            }

            //if (cache == null)
            //{
               
            //}

        }


    }
}
