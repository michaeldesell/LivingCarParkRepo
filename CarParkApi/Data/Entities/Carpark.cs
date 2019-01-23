using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkApi.Data.Entities
{
    public class Carpark
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floors { get; set; }
        public CarParkUser User { get; set; }
        public int Amountofcars { get; set; }
        public int develop_pressure { get; set; }
        public int carpark_rating { get; set; }
    }
}
