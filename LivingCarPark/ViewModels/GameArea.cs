using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using CarParkApi.Data.Entities;
using WebApiModels;

namespace LivingCarPark.ViewModels
{
    public class GameArea
    {
      public string user { get; set; }
        public CarParkModel carpark { get; set; }
        public byte[] backgroundimage { get; set; }
        public byte[] parkinggarage { get; set; }
        public byte[] redcar { get; set; }
    }
}
