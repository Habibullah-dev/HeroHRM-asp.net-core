using HeroHRM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signinManager , RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SignupUserModel model)
        {
            var user = new IdentityUser
            {
                UserName = model.UserName,

            };

            var result = await _userManager.CreateAsync(user, model.Password);

            return result;
        }
        public async Task<List<IdentityUser>> GetAllUsers()
        {
            var result = await _userManager.Users.ToListAsync();

            return result;
        }

        public async Task<SignInResult> PasswordSignIn(SignInModel model)
        {
           var result =  await _signinManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signinManager.SignOutAsync();
        }

        public async Task<IdentityResult> AddUserToRoleAsync(string username , string role)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.UserName == username);

            var result = await _userManager.AddToRoleAsync(user, role);
            
            return result;
        }
        public async Task<IList<IdentityUser>> EmployeeUsers()
        {
             return await _userManager.GetUsersInRoleAsync("Employee");
        }
        public async Task<IList<IdentityUser>> AdminUsers()
        {
            return await _userManager.GetUsersInRoleAsync("Admin");
        }



    }
}
