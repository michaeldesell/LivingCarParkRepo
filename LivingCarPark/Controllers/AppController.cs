using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarParkLogic;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LivingCarPark.Controllers
{
    public class AppController : Controller
    {
        // GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        
        //public IActionResult CarPark()
        //{          
        //    //MZ this is only here to b able to test the logic
        //    CarParkDataLogic.CarsArrivingAndLeaving();
        //    return View();
        //}

        //[HttpGet]
        //public string[] CarsArrivingAndLeaving()
        //{
        //    string[] messages= { "placeholder", "placeholder2", "placeholder3", "placeholder4" };

        //    return messages;
        //}

       
    }
}
