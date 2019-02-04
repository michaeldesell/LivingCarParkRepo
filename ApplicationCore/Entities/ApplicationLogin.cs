using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.ApplicationCore.Entities
{
    public class ApplicationLogin
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Token { get; set; }
    }
}

