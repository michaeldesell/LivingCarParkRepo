using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarParkApi.Data.Entities;
using LivingCarPark.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using LivingCarPark.Model;

namespace LivingCarPark.Controllers
{
    public class AccountController : Controller
    {
        private ILogger<AccountController> _logger;
        private SignInManager<CarParkUser> _signInManager;
        private UserManager<CarParkUser> _userManager;
        private CarParkSignInManager _carParkManager;
        private IMemoryCache _memory;

        public AccountController(ILogger<AccountController> logger, SignInManager<CarParkUser> signInManager, UserManager<CarParkUser> userManager,IMemoryCache  memory)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _memory = memory;
            _carParkManager = new CarParkSignInManager("blah");
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "CarPark");

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                //var result = await _signInManager.PasswordSignInAsync(model.Username,
                //    model.Password,
                //    model.RememberMe,
                //    false);

                
                CustomLogin cl=_carParkManager.SignIn(new CustomLogin() { Username = model.Username, Password = model.Password },true);
                Response.Cookies.Delete(cl.cookienameanti);
                Response.Cookies.Delete(cl.cookienameID);
                Response.Cookies.Append(cl.cookienameanti, cl.cookievalanti);
                Response.Cookies.Append(cl.cookienameID, cl.cookievalID);
             
                //var response = HttpContext.Current.Response;
                //response.Cookies.Remove("mycookie");
                //response.Cookies.Add(cookie);
                //if (result.Succeeded)
                //{
                return RedirectToAction("Index", "CarPark");

                //}
            }

            ModelState.AddModelError("", "Falied to login");
            return View();

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new CarParkUser { FirstName = model.FirstName,LastName = model.LastName, UserName = model.Email, Email = model.Email, PasswordHash = model.Password };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {


                    _logger.LogInformation("User created a new account with password");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password");
                    return RedirectToAction("Login", "App");
                }

                _logger.LogError(result.Errors.ToString());
                ModelState.AddModelError("", "Falied to create user");


            }

            return View(model);

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");


        }
    }
}