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
    }
}
