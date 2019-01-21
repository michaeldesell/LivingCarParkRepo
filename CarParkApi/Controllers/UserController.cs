using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CarParkApi.Model;
using CarParkApi.Data;
using CarParkApi.Data.Entities;


namespace CarParkApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IOptions<Model.MySettingsModel> appSettings;
        private LivingCarParkContext _context;

        public UserController(IOptions<Model.MySettingsModel> app, LivingCarParkContext context)
        {
            appSettings = app;
            _context = context;

        }
        // GET api/values
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Email
                }
                )
                              .ToList();

            List<CarParkUser> usertest= _context.Users.ToList();

            return Ok(users);

        }

        [HttpPost]
        [Route("LoginUser")]
        public IActionResult LoginUser(UserModel login)
        {
            //return new string[] { "value1", "value2" };
            UserModel Data = new UserModel()
            {
                Id = 1,
                Carpark = 1,
                Password = "banan",
                Username = "bananarne"


            };
            var msg = new Message<UserModel>();
            msg.IsSuccess = true;
            msg.Data = Data;
            msg.ReturnMessage = "your user has been logged in succesful";
            //var data = list;
            return Ok(msg);
        }

        [HttpPost]
        [Route("GetUserCarPark")]
        public IActionResult GetUserCarPark(UserModel login)
        {
            //return new string[] { "value1", "value2" };
            UserCarPark Data = new UserCarPark()
            {
                Id = 1,
                Floors = 1,
                Parkingspace = 4,
                Name = " min carpark",
                Amountofcars = 0


            };
            var msg = new Message<UserCarPark>();
            msg.IsSuccess = true;
            msg.Data = Data;
            msg.ReturnMessage = "your CarPark has been retrieved succesfully";
            //var data = list;
            return Ok(msg);
        }

        [HttpPost]
        [Route("ChangeCars")]
        public IActionResult ChangeCars(ChangeCars change_in_cars)
        {
            //return new string[] { "value1", "value2" };
            ChangeCars Data = change_in_cars;

            var msg = new Message<ChangeCars>();
            msg.IsSuccess = true;
            msg.Data = Data;
            msg.ReturnMessage = "Your change in cars was successful";
            //var data = list;
            return Ok(msg);
        }
        //[HttpPost]
        //[Route("SaveCars")]
        //public IActionResult SaveCars(UserModel login)
        //{
        //    //return new string[] { "value1", "value2" };
        //    UserModel Data = new UserModel()
        //    {
        //        Id = 1,
        //        Carpark = 1,
        //        Password = "banan",
        //        Username = "bananarne"


        //    };
        //    var msg = new Message<UserModel>();
        //    msg.IsSuccess = true;
        //    msg.Data = Data;
        //    msg.ReturnMessage = "your user has been logged in succesful";
        //    //var data = list;
        //    return Ok(msg);
        //}

        //[HttpPost]
        //[Route("DeleteCars")]
        //public IActionResult DeleteCars(UserModel login)
        //{
        //    //return new string[] { "value1", "value2" };
        //    UserModel Data = new UserModel()
        //    {
        //        Id = 1,
        //        Carpark = 1,
        //        Password = "banan",
        //        Username = "bananarne"


        //    };
        //    var msg = new Message<UserModel>();
        //    msg.IsSuccess = true;
        //    msg.Data = Data;
        //    msg.ReturnMessage = "your user has been logged in succesful";
        //    //var data = list;
        //    return Ok(msg);
        //}

    }
}
