using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarParkLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using CarParkApi.Model;
using Microsoft.Extensions.Configuration;
using CarParkApi.Data.Entities;
using LivingCarPark.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LivingCarPark.Controllers
{
    public class AppController : Controller
    {

        private readonly IOptions<MySettingsModel> appSettings;
        private IConfiguration _config;

        public AppController(IOptions<MySettingsModel> app,IConfiguration config)
        {
            appSettings = app;
            _config = config;
            Utility.ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            Utility.ApplicationSettings.WebApiUrl = config["MySettings:WebApiBaseUrl"];
            
        }
        //// GET: /<controller>/
        [Authorize]
        public IActionResult Index()
        {


            var data=Factory.ApiClientFactory.Instance.GetUsers();
            List<ViewUserReport> users = data.Result.Select(x => new ViewUserReport() { Username = x.Email, Firstname = x.FirstName }).ToList();

            return View(users);
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
