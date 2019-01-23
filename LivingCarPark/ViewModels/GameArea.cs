using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarParkApi.Data.Entities;

namespace LivingCarPark.ViewModels
{
    public class GameArea
    {
      public CarParkUser user { get; set; }
        public Carpark carpark { get; set; }
    }
}
