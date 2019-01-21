using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarParkLogic;
using CarParkApi.Data.Entities;
using LivingCarPark.Model;
using Microsoft.Extensions.Options;
using WebApiModels.Model;
using TextHelper;

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
        public async Task<int[]> CarsArrivingAndLeaving()
        {
            TestingRepo.init();
            //if(Testing==null)
            //{
            //    Testing = new UserCarPark();
            //    Testing.Id = 1;
            //    Testing.Fk_user = 1;
            //    Testing.Floors = 1;
            //    Testing.Name = "Testing CarPark";
            //    Testing.Parkingspace = 4;
            //    Testing.Amountofcars = 0;
            //}
          
          

            int[] CarData= CarParkDataLogic.CarsArrivingAndLeaving(TestingRepo.TestingCarPark);
            if(CarData[1]!=0)
            {
                var data4 = await ApiClientFactory.Instance.ChangeCars(new WebApiModels.ChangeCars() { Fk_carpark = TestingRepo.TestingCarPark.Id, change_in_cars = CarData[1] });
            }
           
            
            return Functions.TellWhatHappends(CarData);
        }
    }
}