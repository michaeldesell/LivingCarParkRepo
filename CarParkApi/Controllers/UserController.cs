using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CarParkApi.Model;
using CarParkApi.Data;
using CarParkApi.Data.Entities;
using CarParkApi.JwtModel;
using CarParkApi.Service;
using Microsoft.AspNetCore.Authorization;

namespace CarParkApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IOptions<Model.MySettingsModel> appSettings;
        private LivingCarParkContext _context;
        private iapplicationservice _applicationservice;
        public UserController(IOptions<Model.MySettingsModel> app, LivingCarParkContext context,iapplicationservice applicationservice)
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
        public IActionResult Authenticate([FromBody]applicationlogin appparam)
        {
            //[FromBody]applicationlogin appParam)
            applicationlogin appParam = new applicationlogin();
            var appslogins = _applicationservice.Authenticate(appparam.username, appparam.password);
            if (appslogins == null)
                return BadRequest(new { message = "you shall not pass!! wrong pass or user!" });

            var msg = new Message<applicationlogin>();
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
            List<WebApiModels.CarParkUser> users = _context.Users
                .Select(u => new WebApiModels.CarParkUser()
                {
                    UserId = u.Id,
                    UserName = u.UserName,
                    FirstName=u.FirstName,
                    LastName=u.LastName,
                    
                }
                
                )
                              .ToList();
            //users.ForEach
            foreach(WebApiModels.CarParkUser cpu in users)
            {
                List<string> Rolesid = _context.UserRoles.Where(x => x.UserId == cpu.UserId).Select(y => y.RoleId).ToList();

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
        [Route("LoginUser")]
        public IActionResult LoginUser(string login)
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
        [Route("KickAdmin")]
        public IActionResult KickAdmin(ChangeAdminPriviligies login)
        {
            ////return new string[] { "value1", "value2" };
            //UserModel Data = new UserModel()
            //{
            //    Id = 1,
            //    Carpark = 1,
            //    Password = "banan",
            //    Username = "bananarne"


            //};
            ChangeAdminPriviligies  usm= login;
            var role = _context.UserRoles.FirstOrDefault(x => x.UserId == usm.UserID && x.RoleId=="1");
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
                _context.UserRoles.Add(new Microsoft.AspNetCore.Identity.IdentityUserRole<string>() { UserId=usm.UserID,RoleId="1"});
                _context.SaveChanges();
                msg.ReturnMessage = "your admin priviligies has been added";
            }
           
          
            //var data = list;
            return Ok(msg);
        }

        [HttpPost]
        [Route("GetUserCarPark")]
        public IActionResult GetUserCarPark(Carpark login)
        {
    
            Carpark userpark = _context.Carparks.FirstOrDefault(x => x.User.Id == login.User.Id);
           
            var msg = new Message<Carpark>();
            if (userpark!=null)
            {
            
                CarParkUser user = _context.Users.FirstOrDefault(x => x.Id == login.User.Id);

                userpark.User = user;

                msg.IsSuccess = true;
                msg.DataExist = true;
                msg.Data = userpark;
                msg.ReturnMessage = "your CarPark has been retrieved succesfully";
            }
            else
            {
                msg.IsSuccess = true;
                msg.DataExist = false;
                msg.Data = new Carpark();
                msg.ReturnMessage = "You must create a carpark";
            }
          
         
            //var data = list;
            return Ok(msg);
        }

        [HttpPost]
        [Route("SaveCarPark")]
        public IActionResult SaveCarPark(Tuple<Carpark,string> login)
        {

            Tuple<Carpark, string> retur = new Tuple<Carpark, string>(new Carpark(),login.Item2);


            //Carpark userpark = _context.Carparks.FirstOrDefault(x => x.User.Id == login.User.Id);
            var msg = new Message<Tuple<Carpark,string>>();
            CarParkUser User = _context.Users.FirstOrDefault(x => x.Id == login.Item2);
            if (User != null)
            {
                Carpark newcarpark = login.Item1;
                newcarpark.User = User;
                //newcarpark.Floors = 1;


                _context.Add(newcarpark);
                _context.SaveChanges();

                retur =new Tuple<Carpark, string>(newcarpark,login.Item2);
                msg.IsSuccess = true;
                msg.DataExist = true;
                msg.Data = retur;
                msg.ReturnMessage = "your CarPark has been retrieved succesfully";
            }
            else
            {
                msg.IsSuccess = true;
                msg.DataExist = false;
                msg.Data = retur;
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
