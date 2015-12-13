using EVA_backend.Adapters;
using EVA_backend.Entities;
using EVA_backend.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EVA_backend.DataLayer
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;
        private UserBusinessComponentAdapter _userBCA;
        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
            _userBCA = new UserBusinessComponentAdapter();
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };
            IdentityResult result = null;
            try {
                result = await _userManager.CreateAsync(user, userModel.Password);
            }catch(Exception e)
            {
                var b = true;
            }
            if (result.Succeeded)
            {
                _userBCA.InsertUser(userModel);
            }         
             
            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}