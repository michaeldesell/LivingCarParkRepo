using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace CarParkApi.Data.Entities
{
    public class CustomLogin
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public string cookienameanti { get; set; }
        public string cookievalanti { get; set; }
        public string cookienameID { get; set; }
        public string cookievalID { get; set; }
    }
}
