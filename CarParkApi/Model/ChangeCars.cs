using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace CarParkApi
{
    [DataContract]
    public class ChangeCars
    {
        [DataMember(Name = "Fk_carpark")]
        public int Fk_carpark { get; set; }

        [DataMember(Name = "change_in_cars")]
        public int change_in_cars { get; set; }


    }
}
