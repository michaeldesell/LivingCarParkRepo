using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarParkLogic;
using LivingCarPark.Data.Entities;
using LivingCarPark.Model;
using Microsoft.Extensions.Options;

using LivingCarPark.Factory;

namespace LivingCarPark.Controllers
{
    public class CarParkController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;
        public CarParkController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            Utility.ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CarPark()
        {
            //MZ this is only here to b able to test the logic
            //CarParkDataLogic.CarsArrivingAndLeaving();
            var data = await ApiClientFactory.Instance.GetUsers();
            return View();
        }

        [HttpGet]
        public string[] CarsArrivingAndLeaving()
        {
            //LivingCarPark.Data.LivingCarParkContext db;
                        //using(var db= new LivingCarPark.Data.LivingCarParkContext())

            string[] messages = { "placeholder", "placeholder2", "placeholder3", "placeholder4" };
            
            return messages;
        }
    }
}