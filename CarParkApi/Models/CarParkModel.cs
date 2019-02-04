using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Security.Principal;

namespace CarPark.WebAPI.Models
{
    [DataContract]
    public class CarParkModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "User")]
        public CarParkUserModel User { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Active")]
        public bool Active { get; set; }

        [DataMember(Name = "Floors")]
        public FloorModel Floors { get; set; }

        [DataMember(Name = "Amountparkedcars")]
        public int Amountparkedcars { get; set; }

        [DataMember(Name = "develop_pressure")]
        public int develop_pressure { get; set; }

        [DataMember(Name = "carpark_rating")]
        public int carpark_rating { get; set; }

        [DataMember(Name = "SpacesperFloor")]
        public int SpacesperFloor { get; set; }

        [DataMember(Name = "Carsarriving")]
        public int Carsarriving { get; set; }

        [DataMember(Name = "Carsleaving")]
        public int Carsleaving { get; set; }



    }


}