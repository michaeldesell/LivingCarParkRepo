using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
//using CarParkApi.Model;
using WebApiModels;
using CarParkApi.Data;
using CarParkApi.Data.Entities;
using CarParkApi.JwtModel;
using CarParkApi.Service;
using Microsoft.AspNetCore.Authorization;

using System.Security.Cryptography;

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
        [AllowAnonymous]
        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn(CustomLogin appparam)
        {
            ////[FromBody]applicationlogin appParam)
            //applicationlogin appParam = new applicationlogin();
            //var appslogins = _applicationservice.Authenticate(appparam.username, appparam.password);
            //if (appslogins == null)
            //    return BadRequest(new { message = "you shall not pass!! wrong pass or user!" });

            //_context.Us

            //string hash = appparam.Password.ToHashSet();
            var noUser = _context.Users.FirstOrDefault(x => x.UserName == appparam.Username && VerifyHashedPassword(x.PasswordHash, appparam.Password));
            //if()
            string anticookename = ".AspNetCore.Antiforgery.fzGezjtqJAY";
                string anticookeval = "CfDJ8FTBwlukAMlMqMnV87ZWL9kixQl6vYZVAfwGfCvPwE7hZ3bZ5bv952f8DHi0jyu-Cu7tsnM2uMffxjr6jSINUuN3hMDsfiH6vQEooRacNicQxg__w3G9hddwaFISCh94TIOqFh4l24wn8VtPZ4oDTo8";
            string IDentcookename = ".AspNetCore.Identity.Application";
            string IDentcookeval = "CfDJ8FTBwlukAMlMqMnV87ZWL9kvGhYXjZyI9I3NqPtCQfTy_ea8OGNrvwCUMVbxY3FZOXRcInvU8R5a6WDEfLtLQkm52Lyb6UNj-bJsffT66nb9nL_DQUK-z1RKHfQd0Ww3ffzMPlc2GYu9dvWcHiFqPT6H1Vqk8KOHM507YLdgCoeS6L4LJrd1SBjOoa2BMCwMD85j-KZv-7Kx1L0PjsWf8eh6YQrr433dDo9eIX_dRpZj2MB7Hso-8dw-ERlBpR_a8qwGC6ys6xbtem5Eb2Vtc2ZxxJQnkpByxpsunA_RFCC0qGNEMS4oOmBWnTve8aLOSiEaKpDzSIvhK0FWlDBMmhf8_T5cgIG_btSF5c8ET--ny5pZkgQHWRrDUUtk8Da3_p-VpRwOYFP1OamnSGGtNq8nOs43fVerEfqv3FblXhEjdcDNfzM_gYBhgg905T70t3gXrkZmbUei5lOg79bJxda2IrUXBlGSy2i-n4Ily83VwtOmlIKAFwb__o1V0BpMbW4BWdqYgBN4fV6wb61lkTZo336Vo51lYUHxVuS5jEHtwsBf9FyqjJuhXKxmlMqWfUn_IKfPhiQLXWYIknJM0BWEEAljee1DjPzSKWG6H8X6rHCM5DB6Ms-RVXrrA2KmrGg6StRIZxovDQ97JCPmQOIp0SzM_GmZlIaq7Z08UWKk_D-LBJOeprr7hz5v2MXCJA";

            appparam.cookienameanti = anticookename;
            appparam.cookievalanti = anticookeval;
            appparam.cookienameID = IDentcookename;
            appparam.cookievalID = IDentcookeval;
            var msg = new Message<CustomLogin>();
            msg.Data = appparam;
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
            ////return new string[] { "value1", "value2" };
            //UserModel Data = new UserModel()
            //{
            //    Id = 1,
            //    Carpark = 1,
            //    Password = "banan",
            //    Username = "bananarne"


            //};
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
        [Route("GetUserCarPark")]
        public IActionResult GetUserCarPark(CarParkModel carpark)
        {
            List<CarParkModel> carparks = _context.Carparks
                .Where(x => x.User.Id.Equals(carpark.User))
                .Select(x => new CarParkModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Amountparkedcars = x.Amountparkedcars,
                    SpacesperFloor = x.SpacesperFloor,
                    carpark_rating = x.carpark_rating,
                    develop_pressure = x.develop_pressure

                }).ToList();

            var msg = new Message<CarParkModel>();
            if (carpark != null)
            {

                msg.IsSuccess = true;
                msg.DataExist = true;
                msg.Data = carpark;
                msg.ReturnMessage = "your CarPark has been retrieved succesfully";
            }
            else
            {
                msg.IsSuccess = true;
                msg.DataExist = false;
                msg.ReturnMessage = "You must create a carpark";
            }


            //var data = list;
            return Ok(msg);
        }

        [HttpPost]
        [Route("SaveCarPark")]
        public IActionResult SaveCarPark(CarParkModel carpark)
        {
            CarParkUser User = _context.Users.FirstOrDefault(x => x.Id.Equals(carpark.User));


            Carpark newcarpark = new Carpark(carpark.Name, User);
            CarParkModel model = new CarParkModel() { Id = newcarpark.Id };
            var msg = new Message<CarParkModel>();

            if (User != null)
            {
                _context.Add(newcarpark);
                _context.SaveChanges();

                msg.IsSuccess = true;
                msg.DataExist = true;
                msg.Data = model;
                msg.ReturnMessage = "your CarPark has been retrieved succesfully";
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


        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }


        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        private static bool ByteArraysEqual(byte[] firstHash, byte[] secondHash)
        {
            int _minHashLength = firstHash.Length <= secondHash.Length ? firstHash.Length : secondHash.Length;
            var xor = firstHash.Length ^ secondHash.Length;
            for (int i = 0; i < _minHashLength; i++)
                xor |= firstHash[i] ^ secondHash[i];
            return 0 == xor;
        }

    }
}
