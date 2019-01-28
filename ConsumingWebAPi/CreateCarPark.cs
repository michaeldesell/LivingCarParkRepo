using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace WebApiModels
{

    class CreateCarPark
    {
        [DataMember(Name = "Carpark")]
        public CarParkModel Carpark { get; set; }

    }
}
