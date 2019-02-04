using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkApi.Data.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Car(string name)
        {
            Name = name;
        }

    }
}
