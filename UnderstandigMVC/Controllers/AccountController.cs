using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderstandigMVC.Models;

namespace UnderstandigMVC.Controllers
{
    public class AccountController: Controller
    {
        private readonly SignInManager<IdentityUser> _singnInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _singnInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            //Tjekker om modelstaten overholdes
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            

            //Finder ud af om der en user med det username
            var user = await _userManager.FindByNameAsync(viewModel.UserName);

            //Hvis den finder en user prøver den at logge ind
            if(user != null)
            {
                var result = await _singnInManager.PasswordSignInAsync(user, viewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "bruger ikke fundet");

            return View(viewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = viewModel.UserName };

                var result = await _userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "noget gik galt");

            return View(viewModel);
        }



        
        public async Task<IActionResult> Logout()
        {
            await _singnInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
