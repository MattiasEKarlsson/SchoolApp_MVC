using Microsoft.AspNetCore.Identity;
using SchoolApp.Data;
using SchoolApp.Models;
using SchoolApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Services.Identity
{
    public interface IIdentityService 
    {
        Task CreateRootAccountAsync();

        Task CreateNewRole(string roleName);
        Task<IdentityResult> CreateNewUserAsync(ApplicationUser user, string password);
        Task AddUserToRole(ApplicationUser user, string roleName);
        IEnumerable<ApplicationUser> GetAllUsers();

        IEnumerable<IdentityRole> GetAllRoles();

        Task<IEnumerable<UserViewModel>> GetAllUsersWithRolesAsync();


    }
}
