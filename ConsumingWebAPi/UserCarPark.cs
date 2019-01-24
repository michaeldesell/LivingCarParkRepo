﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WebApiModels.Model
{
    [DataContract]
    public class UserCarPark
    {
        
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        [DataMember(Name = "Fk_user")]
        public int Fk_user { get; set; }
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Floors")]
        public int Floors { get; set; }
        [DataMember(Name = "Parkingspace")]
        public int Parkingspace { get; set; }
        [DataMember(Name = "Amountofcars")]
        public int Amountofcars { get; set; }
        [DataMember(Name = "develop_pressure")]
        public int develop_pressure { get; set; }
        [DataMember(Name = "carpark_rating")]
        public int carpark_rating { get; set; }

    }


}