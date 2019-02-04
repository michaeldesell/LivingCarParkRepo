using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApiModels;
using CarParkApi.JwtModel;
using CarParkApi.Service;
using Microsoft.AspNetCore.Authorization;
using CarParkLogic;


namespace CarParkApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IOptions<MySettingsModel> appSettings;
        private LivingCarParkContext _context;
        private iapplicationservice _applicationservice;

        public UserController(IOptions<MySettingsModel> app, LivingCarParkContext context, iapplicationservice applicationservice)
        {
            appSettings = app;
            _context = context;
            _applicationservice = applicationservice;

        }

        // GET api/values
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("Authenticate")]
        //public IActionResult Authenticate(string username,string password)
        //{
        //    //[FromBody]applicationlogin appParam)
        //    applicationlogin appParam = new applicationlogin();
        //    var appslogins = _applicationservice.Authenticate(username, password);
        //    if (appslogins == null)
        //        return BadRequest(new { message ="you shall not pass!! wrong pass or user!"});

        //    return Ok(appslogins);

        //}

        // GET api/values
        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate([FromBody]JwtApplicationlogin appparam)
        {
            //[FromBody]applicationlogin appParam)

            UserDataLogic.Authenticate(appparam);
            JwtApplicationlogin appParam = new JwtApplicationlogin();
            var appslogins = _applicationservice.Authenticate(appparam.username, appparam.password);
            if (appslogins == null)
                return BadRequest(new { message = "you shall not pass!! wrong pass or user!" });

            var msg = new Message<JwtApplicationlogin>();
            msg.Data = appslogins;
            msg.DataExist = true;
            msg.IsSuccess = true;
            return Ok(msg);

        }
        // GET api/values
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            List<CarParkUserModel> users = _context.Users
                .Select(u => new CarParkUserModel()
                {
                    Id = u.Id,
                    Username = u.UserName,
                }

                )
                              .ToList();
            //users.ForEach
            foreach (CarParkUserModel cpu in users)
            {
                List<string> Rolesid = _context.UserRoles.Where(x => x.UserId == cpu.Id).Select(y => y.RoleId).ToList();

                cpu.Role = _context.Roles.Where(x => Rolesid.Contains(x.Id) == true).Select(y => y.Name).ToList();
                if (cpu.Role.Contains("WebAdmin"))
                    cpu.Admin = true;
                else
                    cpu.Admin = false;
            }


            //List<CarParkUser> usertest= _context.Users.ToList();

            return Ok(users);

        }



        [HttpPost]
        [Route("KickAdmin")]
        public IActionResult KickAdmin(ChangeAdminPriviligies login)
        {
            ChangeAdminPriviligies usm = login;
            var role = _context.UserRoles.FirstOrDefault(x => x.UserId == usm.UserID && x.RoleId == "1");
            if (role != null)
            {
                _context.Remove(role);
                _context.SaveChanges();
            }


            var msg = new Message<ChangeAdminPriviligies>();
            msg.IsSuccess = true;
            msg.Data = usm;
            msg.ReturnMessage = "your Admin priviliges has been removed";
            //var data = list;
            return Ok(msg);
        }

        [HttpPost]
        [Route("MakeAdmin")]
        public IActionResult MakeAdmin(ChangeAdminPriviligies login)
        {
            //return new string[] { "value1", "value2" };
            //UserModel Data = new UserModel()
            //{
            //    Id = 1,
            //    Carpark = 1,
            //    Password = "banan",
            //    Username = "bananarne"


            //};

            ChangeAdminPriviligies usm = login;
            var role = _context.UserRoles.FirstOrDefault(x => x.UserId == usm.UserID && x.RoleId == "1");
            //var role = _context..FirstOrDefault(x => x.UserId == usm.Id.ToString() && x.RoleId == "1");

            var msg = new Message<ChangeAdminPriviligies>();

            if (role != null)
            {

                msg.IsSuccess = true;
                msg.Data = usm;
                msg.ReturnMessage = "you already have admin priviliges";
            }
            else
            {
                _context.UserRoles.Add(new Microsoft.AspNetCore.Identity.IdentityUserRole<string>() { UserId = usm.UserID, RoleId = "1" });
                _context.SaveChanges();
                msg.ReturnMessage = "your admin priviligies has been added";
            }


            //var data = list;
            return Ok(msg);
        }

        [HttpPost]
        [Route("GetUserActiveCarPark")]
        public IActionResult GetUserActiveCarPark(CarParkModel carpark)
        {
            CarParkModel activecarpark = _context.Carparks
                .Where(x => x.User.Id == carpark.User.Id && x.Active)
                .Select(x => new CarParkModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Amountparkedcars = x.Amountparkedcars,
                    SpacesperFloor = x.SpacesperFloor,
                    carpark_rating = x.carpark_rating,
                    develop_pressure = x.develop_pressure

                }).FirstOrDefault();

            var msg = new Message<CarParkModel>();
            if (activecarpark != null)
            {

                msg.IsSuccess = true;
                msg.DataExist = true;
                msg.Data = activecarpark;
                msg.ReturnMessage = "your active CarPark has been retrieved successfully";
            }
            else
            {
                msg.IsSuccess = true;
                msg.DataExist = false;
                msg.ReturnMessage = "There are no active carparks for this user";
            }


            //var data = list;
            return Ok(msg);
        }

        [HttpPost]
        [Route("SaveCarPark")]
        public IActionResult SaveCarPark(CarParkModel carpark)
        {
            CarParkUser User = _context.Users.FirstOrDefault(x => x.Id == carpark.User.Id);


            Carpark newcarpark = new Carpark(carpark.Name, User);
            CarParkModel model = new CarParkModel() { Id = newcarpark.Id };
            var msg = new Message<CarParkModel>();

            if (User != null)
            {
                _context.Carparks.Add(newcarpark);
                _context.SaveChanges();

                msg.IsSuccess = true;
                msg.DataExist = true;
                msg.Data = model;
                msg.ReturnMessage = "your  CarPark has been retrieved succesfully";
            }
            else
            {
                msg.IsSuccess = true;
                msg.DataExist = false;
                msg.Data = model;
                msg.ReturnMessage = "Your user was not present";
            }


            //var data = list;
            return Ok(msg);
        }

        [HttpPost]
        [Route("ChangeCars")]
        public IActionResult ChangeCars(ChangeCars change_in_cars)
        {
            //return new string[] { "value1", "value2" };
            ChangeCars Data = change_in_cars;


            Carpark cp = _context.Carparks.FirstOrDefault(x => x.Id == change_in_cars.Fk_carpark);

            cp.Amountparkedcars = change_in_cars.change_in_cars;
            //cp.Floors = change_in_cars.Floors;
            cp.develop_pressure = change_in_cars.develop_pressure;
            cp.carpark_rating = change_in_cars.carpark_rating;

            _context.Update(cp);
            _context.SaveChanges();
            //_context.SaveChanges();
            var msg = new Message<ChangeCars>();
            msg.IsSuccess = true;
            msg.Data = Data;
            msg.ReturnMessage = "Your change in cars was successful";
            //var data = list;
            return Ok(msg);
        }

        [HttpPost]
        [Route("GetCarParkFloors")]
        public IActionResult GetCarParkFloors(Carpark carpark)
        {

            var floors = carpark.Floors;



            var msg = new Message<ICollection<Floor>>();
            if (floors != null)
            {

                msg.IsSuccess = true;
                msg.DataExist = true;
                msg.Data = floors;
                msg.ReturnMessage = "your CarPark has been retrieved succesfully";
            }
            else
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "No floors found";
            }


            return Ok(msg);
        }

        [HttpPost]
        [Route("UpdateCarPark")]
        public IActionResult UpdateCarPark(CarParkModel carpark)
        {
            carpark = CarParkDataLogic.CarsArrivingAndLeaving(carpark);
        }



    }
}
