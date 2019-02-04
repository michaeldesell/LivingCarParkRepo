using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace CarPark.WebAPI.Models
{

    class CreateCarPark
    {
        [DataMember(Name = "Carpark")]
        public CarParkModel Carpark { get; set; }

    }
}
