using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CarParkApi.Model
{
    [DataContract]
    public class UserCarPark
    {
        //[DataMember(Name = "Id")]
        //public int Id { get; set; }
        //[DataMember(Name = "Username")]
        //public string Username { get; set; }
        //[DataMember(Name = "Password")]
        //public string Password { get; set; }
        //[DataMember(Name = "Carpark")]
        //public int Carpark { get; set; }
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        [DataMember(Name = "Fk_user")]
        public int Fk_user { get; set; }
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        [DataMember(Name = "Floors")]
        public int Floors { get; set; }
        [DataMember(Name = "occupiedspaces")]
        public int Parkingspace { get; set; }
        [DataMember(Name = "Amountofcars")]
        public int Amountofcars { get; set; }
    }


}