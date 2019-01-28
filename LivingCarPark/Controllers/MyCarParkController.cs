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



namespace LivingCarPark.Controllers
{
    [Authorize]
    public class MyCarParkController : Controller
    {
        public  LivingCarParkContext _ctx { get; set; }

        public MyCarParkController(LivingCarParkContext ctx)
        {
            _ctx = ctx;
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