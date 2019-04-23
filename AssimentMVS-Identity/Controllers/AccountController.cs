using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssimentMVS_Identity.DataBase;
using AssimentMVS_Identity.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AssimentMVS_Identity.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager,
                                   UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var SingInResult = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);

                switch (SingInResult.ToString())
                {
                    case "Succeeded":
                        return RedirectToAction("Index", "Home");

                    case "Failed":
                        ViewBag.msg = "Failed - Username of/and Password is incorrect";
                        break;
                    case "Lockedout":
                        ViewBag.msg = "Locked Out";
                        break;
                    default:
                        ViewBag.msg = SingInResult.ToString();
                        break;
                }
            }
            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel createuser)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = createuser.UserName,
                    Email = createuser.Email
                };
                var result = await _userManager.CreateAsync(user, createuser.Password);

                if (result.Succeeded)
                {
                    ViewBag.msg = "User was created";
                    return RedirectToAction("CreateUser");
                }
                else
                {
                    ViewBag.errorlist = result.Errors;
                }
            }

            return View(createuser);
        }
    }
}