using HeroHRM.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateUserAsync(SignupUserModel model);
        Task<List<IdentityUser>> GetAllUsers();
        Task<SignInResult> PasswordSignIn(SignInModel model);
        Task SignOutAsync();
        Task<IdentityResult> AddUserToRoleAsync(string username, string role);
        Task<IList<IdentityUser>> EmployeeUsers();
        Task<IList<IdentityUser>> AdminUsers();
    }
}