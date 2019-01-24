using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkApi.Data.Entities
{
    public class Parkingspace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Car Parkedcar { get; set; }
        public bool Available { get; set; }

        public Parkingspace(string Name)
        {
            this.Name = Name;
            Available = true;
        }

       public static void AddCar(string carname)
        {

            Car Parkedcar = new Car(carname);
            

        }
    }
}
