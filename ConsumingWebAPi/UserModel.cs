using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WebApiModels.Model
{
    [DataContract]
    public class UserModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        [DataMember(Name = "Username")]
        public string Username { get; set; }
        [DataMember(Name = "Password")]
        public string Password { get; set; }
        [DataMember(Name = "Carpark")]
        public int Carpark { get; set; }
    }


}
