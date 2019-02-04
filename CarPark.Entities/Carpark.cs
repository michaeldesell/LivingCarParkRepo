using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkApi.Data.Entities
{
    public class Carpark
    {
        public int Id { get; set; }
        public CarParkUser User { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public ICollection<Floor> Floors { get; set; }
        public int Amountparkedcars { get; set; }
        public int develop_pressure { get; set; }
        public int carpark_rating { get; set; }
        public int SpacesperFloor { get; set; }
        public int Carsarriving { get; set; }
        public int Carsleaving { get; set; }

        public Carpark()
        {

        }
        public Carpark(string name,CarParkUser user)
        {
            User = user;
            Name = name;
            SpacesperFloor = 4;
            ICollection<Floor> floors = new List<Floor>();
            Amountparkedcars = 0;
            floors.Add(new Floor(1, SpacesperFloor));
            Floors = floors;
            Active = true;
        }

        public void AddFloor()
        {
            int next = Floors.Count();
            next++;
            Floors.Add(new Floor(next, SpacesperFloor));
        }

    }
}
