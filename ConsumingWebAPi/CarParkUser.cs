using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiModels
{
    public class CarParkUser
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Role { get; set; }
        public bool Admin { get; set; }
    }
}
