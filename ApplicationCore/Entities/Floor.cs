using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.ApplicationCore.Entities
{
    public class Floor
    {
        public int Id { get; set; }
        public int Floornumber { get; set; }
        public int spaces { get; set; }
        public ICollection<Parkingspace> Parkingspaces { get; set; }

        public Floor(int Floornumber, int spaces)
        {
            ICollection<Parkingspace> ps = new List<Parkingspace>();
            this.spaces = spaces;
            this.Floornumber = Floornumber;


            for (int s = 1; s < spaces+1; s++)
            {

                ps.Add(new Parkingspace(Floornumber.ToString() +"-" + s.ToString()));
            }

            Parkingspaces = ps;




        }
    }
}
