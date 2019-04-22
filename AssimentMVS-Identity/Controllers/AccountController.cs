using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SingIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SingIn(LoginViewModel loginViewModel)
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
        
    }
}