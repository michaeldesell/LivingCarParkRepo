using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivingCarPark.ViewModels
{
    public class ViewUserReport
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public List<string> Roles { get; set; } 
        public bool ShowButton { get; set; }
    }
}
