using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkApi.Data.Entities
{
    public class Floor
    {
        public int Id { get; set; }
        public int Floornumber { get; set; }
        public ICollection<Parkingspace> Parkingspaces { get; set; }

        public Floor(int Floornumber, int spaces)
        {
            ICollection<Parkingspace> ps = new List<Parkingspace>();

            this.Floornumber = Floornumber;


            for (int s = 1; s < spaces+1; s++)
            {

                ps.Add(new Parkingspace(Floornumber.ToString() +"-" + s.ToString()));
            }

            Parkingspaces = ps;




        }
    }
}
