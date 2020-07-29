using Microsoft.AspNetCore.Identity;
using Shop.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Database
{
    public class UserManager : IUserManager
    {

        private UserManager<IdentityUser> _userManager;

        public UserManager(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task CreateManagerUser(string username, string password)
        {
            var managerUser = new IdentityUser()
            {
                UserName = username
            };

            await _userManager.CreateAsync(managerUser,password);


            var managerClaim = new Claim("Role", "Manager");

            await _userManager.AddClaimAsync(managerUser, managerClaim);
           
        }
    }
}
