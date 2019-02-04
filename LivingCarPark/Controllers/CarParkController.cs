using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarParkLogic;
using CarParkApi.Data.Entities;
using LivingCarPark.Model;
using Microsoft.Extensions.Options;
using WebApiModels;
using TextHelper;
using LivingCarPark.ViewModels;
using Microsoft.AspNetCore.Authorization;
using LivingCarPark.Factory;
using LivingCarPark.Properties;
using Microsoft.Extensions.Caching.Memory;
using System.Timers;

namespace LivingCarPark.Controllers
{


    [Authorize]
    public class CarParkController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;
        private IMemoryCache _memory;
        private static Timer timer;

        public CarParkController(IOptions<MySettingsModel> app, IMemoryCache memory)
        {
            appSettings = app;
            _memory = memory;
            Utility.ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            Utility.ApplicationSettings.username = appSettings.Value.username;
            Utility.ApplicationSettings.password = appSettings.Value.password;
            Factory.ApiClientFactory.InstanceMemory = _memory;

        }

        //[authorize]
        public async Task<IActionResult> Index()
        {
            CarParkModel cpm = new CarParkModel()
            {
                User = new CarParkUserModel() { Id = User.Claims.FirstOrDefault().Value }
            };

            var data2 = await ApiClientFactory.Instance.GetUserActiveCarPark(cpm);
            if (data2.DataExist)
            {
                return RedirectToAction("MyCarPark", "CarPark");
            }
            else if (!data2.DataExist)
            {
                return RedirectToAction("NewCarPark", "CarPark");
            }


            return View(cpm);
        }

        public async Task<IActionResult> MyCarPark()
        {

            CarParkModel carpark = new CarParkModel();

            carpark.User = new CarParkUserModel() { Id = User.Claims.FirstOrDefault().Value };



            var data = ApiClientFactory.Instance.GetUserActiveCarPark(carpark);

            carpark = data.Result.Data;

            carpark = CarParkDataLogic.CarsArrivingAndLeaving(carpark);

            return View(carpark);


        }
        public async Task<IActionResult> CarPark()
        {

            //CarParkModel usercp = new CarParkModel();
            //usercp.User = new CarParkUserModel() { Id = User.Claims.FirstOrDefault().Value };

            //var data2 = ApiClientFactory.Instance.GetUserActiveCarPark(usercp);


            //GameArea ga = new GameArea();
            //ga.carpark = data2.Result.Data;
            //ga.user = data2.Result.Data.User;
            //ga.backgroundimage = Resources.gamebackground1;
            //ga.parkinggarage = Resources.parkinggarage_entrence_empty1;
            //ga.redcar = Resources.gamebackground1;
            ////var info= Resources.Red_car1;
            ////var redcar = Resources.Red_car1;
            ////var garage = Resources.parkinggarage_entrence_empty1;
            return View();
        }

        public IActionResult NewCarPark()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCarPark(CreateCarpark carpark)
        {

            if (ModelState.IsValid)
            {
                CarParkModel model = new CarParkModel()
                {
                    User = new CarParkUserModel() { Id = User.Claims.FirstOrDefault().Value },
                    Name = carpark.CarParkName
                };
                var data = await ApiClientFactory.Instance.SaveCarpark(model);

                if (data.IsSuccess)
                {
                    return RedirectToAction("MyCarPark", "CarPark");
                }
            }

            return View();
        }


        [HttpGet]
        public async Task<int[]> CarsArrivingAndLeaving()
        {
            TestingRepo.init();


            //int[] CarData= CarParkDataLogic.CarsArrivingAndLeaving(TestingRepo.TestingCarPark);
            int[] CarData = new int[10];
            if (CarData[1] != 0)
            {

                WebApiModels.ChangeCars carsupdate = new WebApiModels.ChangeCars()
                {
                    Fk_carpark = TestingRepo.TestingCarPark.Id,
                    change_in_cars = CarData[1],
                    Floors = CarData[7],
                    develop_pressure = CarData[5],
                    carpark_rating = CarData[6]

                };
                var data4 = await ApiClientFactory.Instance.ChangeCars(carsupdate);
            }


            return Functions.TellWhatHappends(CarData);
        }


        public async Task<IActionResult> Display(CarParkModel model)
        {

            return PartialView();

        }


    }
}