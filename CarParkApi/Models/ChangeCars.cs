using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace CarPark.WebAPI.Models
{
    [DataContract]
    public class ChangeCars
    {
        [DataMember(Name = "Fk_carpark")]
        public int Fk_carpark { get; set; }

        [DataMember(Name = "change_in_cars")]
        public int change_in_cars { get; set; }
        [DataMember(Name = "Floors")]
        public int Floors { get; set; }
        [DataMember(Name = "develop_pressure")]
        public int develop_pressure { get; set; }
        [DataMember(Name = "carpark_rating")]
        public int carpark_rating { get; set; }

    }
}
