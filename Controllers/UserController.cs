using HeroHRM.Models;
using HeroHRM.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Controllers
{
  
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(IUserRepository userRepository , RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _userRepository = userRepository;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [Route("signup")]
        [Authorize(Roles = "Admin")]
        public IActionResult SignUp()
        {

            return View();
        }
        [Route("signup")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SignUp(SignupUserModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userRepository.CreateUserAsync(model);
                if(!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                   
                    return View(model);
                }

                var resultRole = await _userRepository.AddUserToRoleAsync(model.UserName, "Employee");
                ModelState.Clear();
                return  RedirectToAction("CreatePersonal","Employee",new {username = model.UserName});
            }
            return View(model);

        }
        [Route("login")]
        public IActionResult Login()
        {

            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel model,string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var result = await _userRepository.PasswordSignIn(model);

                if(result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Credential");

            }
            return View(model);
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userRepository.SignOutAsync();
            return RedirectToAction("login", "User");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllUsers()
        {
          
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AddAdmin()
        {

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAdmin(SignupUserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.CreateUserAsync(model);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View(model);
                }

                var resultRole = await _userRepository.AddUserToRoleAsync(model.UserName, "Admin");
                ModelState.Clear();
                return RedirectToAction("AllUsers", "User");
            }
            return View(model);

    
        }




    }
}
