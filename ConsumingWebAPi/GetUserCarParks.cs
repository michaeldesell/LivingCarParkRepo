﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace WebApiModels
{
    [DataContract]
    public class GetUserCarParks
    {
        [DataMember(Name = "UserId")]
        public string UserId { get; set; }
        [DataMember(Name = "UserCarParks")]
        public List<CarParkModel> UserCarParks { get; set; }


    }
}
