using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarParkLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using WebApiModels;
using Microsoft.Extensions.Configuration;
using CarParkApi.Data.Entities;
using LivingCarPark.ViewModels;
using Microsoft.Extensions.Caching.Memory;
using WebApiModels.Model;
using WebApiModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LivingCarPark.Controllers
{
    [Authorize]
    public class AppController : Controller
    {

        private readonly IOptions<MySettingsModel> appSettings;
        private IConfiguration _config;
        private IMemoryCache _memory;
        
        
        public AppController(IOptions<MySettingsModel> app,IConfiguration config,IMemoryCache memory)
        {
            appSettings = app;
            _config = config;
            _memory = memory;
            
            Utility.ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            Utility.ApplicationSettings.WebApiUrl = config["MySettings:WebApiBaseUrl"];
            Utility.ApplicationSettings.username = config["MySettings:username"];
            Utility.ApplicationSettings.password = config["MySettings:password"];
            Factory.ApiClientFactory.InstanceMemory = _memory;

        }
        //// GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Index()
        {
            //return RedirectToAction("Login", "Account");
            return View();
        }

        [Authorize(Roles ="WebAdmin")]     
        public IActionResult ShowReport()
        {

            Factory.ApiClientFactory acf = new Factory.ApiClientFactory();
            var data = Factory.ApiClientFactory.Instance.GetUsers();
            List<ViewUserReport> users = data.Result.Select(x => new ViewUserReport() { UserId=x.UserId,Username = x.UserName, Firstname = x.FirstName,Roles=x.Role,ShowButton=x.Admin }).ToList();

            return View(users);
        }

        [Authorize(Roles = "WebAdmin")]
        public IActionResult KickAdmin(ViewUserReport user)
        {

            //Factory.ApiClientFactory acf = new Factory.ApiClientFactory();
            var data = Factory.ApiClientFactory.Instance.KickAdmin(new ChangeAdminPriviligies() { UserID = user.UserId });
            //List<ViewUserReport> users = data.Result.Select(x => new ViewUserReport() { Username = x.UserName, Firstname = x.FirstName, Roles = x.Role, ShowButton = x.Admin }).ToList();


            return RedirectToAction("ShowReport", "App"); 
        }

        [Authorize(Roles = "WebAdmin")]
        public IActionResult MakeAdmin(ViewUserReport user)
        {

            //Factory.ApiClientFactory acf = new Factory.ApiClientFactory();
            var data = Factory.ApiClientFactory.Instance.MakeAdmin(new ChangeAdminPriviligies()
            {
                UserID=user.UserId
            });
            //List<ViewUserReport> users = data.Result.Select(x => new ViewUserReport() { Username = x.UserName, Firstname = x.FirstName, Roles = x.Role, ShowButton = x.Admin }).ToList();
            return RedirectToAction("ShowReport", "App");

          
        }

        //[Authorize(Roles = "WebAdmin")]
        public IActionResult About()
        {

            Factory.ApiClientFactory acf = new Factory.ApiClientFactory();
            //var data = Factory.ApiClientFactory.Instance.GetUsers();
            //List<ViewUserReport> users = data.Result.Select(x => new ViewUserReport() { Username = x.Email, Firstname = x.FirstName }).ToList();

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
