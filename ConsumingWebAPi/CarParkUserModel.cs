using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Security.Principal;

namespace WebApiModels
{
    [DataContract]
    public class CarParkUserModel
    {
        [DataMember(Name = "Id")]
        public string Id { get; set; }
        [DataMember(Name = "Username")]
        public string Username { get; set; }
        [DataMember(Name = "Password")]
        public string Password { get; set; }
        [DataMember(Name = "Carpark")]
        public CarParkModel Carpark { get; set; }
        [DataMember(Name = "Role")]
        public List<string> Role { get; set; }
        [DataMember(Name = "Admin")]
        public bool Admin { get; set; }
    }


}
