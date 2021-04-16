using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using ItemStore.Logic.Interfaces;
using ItemStore.Logic.Salt;
using ItemStore.Presentation.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItemStore.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserContainer _userContainer;
        private static string _salt; 

        public AccountController(IUserContainer userContainer, PasswordSalt passSalt)
        {
            _userContainer = userContainer;
            _salt = passSalt.Salt; 
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET: Account/Login
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //POST: Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var User = _userContainer.GetUserByEmail(model.EmailAddress);

                if (Crypto.VerifyHashedPassword(User.Password, model.Password + _salt))
                {
                    model.Password = null; 
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.Name, User.Email));
                    identity.AddClaim(new Claim(ClaimTypes.GivenName, User.UserName));

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = model.RememberMe });

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login.");
                return View();
            }

            return View();
        }

        //GET: 
        [HttpGet]
        public IActionResult Register()
        {
            return View(); 
        }

        //POST: 
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var hash = Crypto.HashPassword(model.Password + _salt);    // Hash and Salt the password
                model.Password = hash;

                _userContainer.CreateUser(model.UserName, model.EmailAddress, model.Password, model.FirstName, model.LastName, 0);
                return RedirectToAction("Login","Account"); 
            }
            
            return View(model); 
        }

        //GET:Account/Profile
        [HttpGet]
        public IActionResult Profile()
        {
            var user = _userContainer.GetUserByEmail(User.Identity.Name);

            return View(new ProfileViewModel() { EmailAddress = user.Email, Username = user.UserName, FirstName  = user.FirstName, LastName = user.LastName, Password = user.Password });
        }

        //POST:Account/Profile
        [HttpPost]
        public IActionResult Profile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userContainer.GetUserByEmail(User.Identity.Name);

                _userContainer.UpdateProfile(user.ID, model.EmailAddress, model.Username, model.FirstName, model.LastName, model.Password);

                return View();
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }
    }
}
