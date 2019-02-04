using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.ApplicationCore.Entities
{
    public class ApplicationSettings
    {
        public static string WebApiUrl { get; set; }
        public static string username { get; set; }
        public static string password { get; set; }
    }
}
