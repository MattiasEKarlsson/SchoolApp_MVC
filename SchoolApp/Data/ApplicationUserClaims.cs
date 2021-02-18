using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolApp.Data
{
    public class ApplicationUserClaims : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationUserClaims(
               UserManager<ApplicationUser> userManager, 
               RoleManager<IdentityRole> roleManager,
               IOptions<IdentityOptions> options)
               : base(userManager, roleManager, options)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var _identity = await base.GenerateClaimsAsync(user);
            var _userRoles = await UserManager.GetRolesAsync(user);
            var _userRole = _userRoles.FirstOrDefault();
            _identity.AddClaim(new Claim("FirstName", user.FirstName));
            _identity.AddClaim(new Claim("LastName", user.LastName));
            _identity.AddClaim(new Claim("Display", $"{user.GetDisplay()} ({_userRole})"));
            _identity.AddClaim(new Claim("Role", _userRole));

            return _identity;
        }
    }
}
