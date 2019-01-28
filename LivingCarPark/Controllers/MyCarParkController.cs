using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarParkApi.Data;
using CarParkApi.Data.Entities;
using LivingCarPark.Factory;
using Microsoft.AspNetCore.Authorization;
using WebApiModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace LivingCarPark.Controllers
{
    [Authorize]
    public class MyCarParkController : Controller
    {
        public  LivingCarParkContext _ctx { get; set; }

        private readonly IOptions<MySettingsModel> appSettings;
        private IConfiguration _config;
        private IMemoryCache _memory;

        public MyCarParkController(LivingCarParkContext ctx, IOptions<MySettingsModel> app, IConfiguration config, IMemoryCache memory)
        {
            _ctx = ctx;
            appSettings = app;
            _config = config;
            _memory = memory;

            Utility.ApplicationSettings.WebApiUrl = app.Value.WebApiBaseUrl;
            Utility.ApplicationSettings.WebApiUrl = config["MySettings:WebApiBaseUrl"];
            Utility.ApplicationSettings.username = config["MySettings:username"];
            Utility.ApplicationSettings.password = config["MySettings:password"];
            Factory.ApiClientFactory.InstanceMemory = _memory;
        }
        
        public IActionResult MyCarPark()
        {
            GetUserCarParks usercp = new GetUserCarParks();
            usercp.UserId =  User.Claims.FirstOrDefault().Value;

            var carparks = ApiClientFactory.Instance.GetUserCarParks(usercp);


            return View();
        }
    }
}