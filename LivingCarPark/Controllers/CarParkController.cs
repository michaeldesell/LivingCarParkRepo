using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarParkLogic;
using LivingCarPark.Data.Entities;
using LivingCarPark.Model;
using Microsoft.Extensions.Options;
using WebApiModels.Model;

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
            //var data = await ApiClientFactory.Instance.GetUsers();

            //UserModel login = new UserModel()
            //{
            //    Username = "Goran",
            //    Password = "Gurka",
            //};
            //var data2 = await ApiClientFactory.Instance.LoginUser(login);

            //UserCarPark logincarpark = new UserCarPark()
            //{
            //    Fk_user=login.Id
            //};

            //var data3 = await ApiClientFactory.Instance.GetUserCarPark(logincarpark);

            
            //var data4 = await ApiClientFactory.Instance.ChangeCars(new WebApiModels.ChangeCars() { Fk_carpark=data3.Data.Id,change_in_cars=3});
            return View();
        }

        [HttpGet]
        public async Task<string[]> CarsArrivingAndLeaving()
        {
          
            var data4 = await ApiClientFactory.Instance.ChangeCars(new WebApiModels.ChangeCars() { Fk_carpark = 1, change_in_cars = 3 });
            string[] messages = { "placeholder", "placeholder2", "placeholder3", "placeholder4" };
            
            return messages;
        }
    }
}