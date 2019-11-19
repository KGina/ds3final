using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using AbantwanaWebMaster.Data;
using AbantwanaWebMaster.Model;

namespace AbantwanaWebMaster.BusinessLogic
{
    public class LoginBusiness
    {
        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;
        public UserManager<AbantwanaWebMaster.Data.ApplicationUser> UserManager { get; set; }

        public LoginBusiness()
        {
            UserManager = new UserManager<AbantwanaWebMaster.Data.ApplicationUser>(new UserStore<AbantwanaWebMaster.Data.ApplicationUser>(new DataContext()));
        }

        public async Task<bool> LogUserIn(LoginModel objLoginModel, IAuthenticationManager authenticationManager)
        {
            var user = await UserManager.FindAsync(objLoginModel.UserName, objLoginModel.Password);
            if (user != null)
            {
                await SignInAsync(user, objLoginModel.RememberMe, authenticationManager);
                return true;
            }
            return false;
        }

        private async Task SignInAsync(AbantwanaWebMaster.Data.ApplicationUser user, bool isPersistent, IAuthenticationManager authenticationManager)
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
    }
}
