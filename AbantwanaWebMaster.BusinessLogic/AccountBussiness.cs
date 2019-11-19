using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Data;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

using AbantwanaWebMaster.Model;


namespace AbantwanaWebMaster.BusinessLogic
{
   public class AccountBussiness
    {
       // public ApplicationSignInManager SignInManager { get; set; }
        //DataContext DataContextdb = new DataContext();
        //var userStore = new UserStore<IdentityUser>(DataContextdb.Users);
        // private ApplicationUserManager UserManager;
        public UserManager<AbantwanaWebMaster.Data.ApplicationUser> UserManager { get; set; }

        public AccountBussiness()
        {
            UserManager = new UserManager<AbantwanaWebMaster.Data.ApplicationUser>(new UserStore<AbantwanaWebMaster.Data.ApplicationUser>(new DataContext()));
        }
        public async Task<bool> signIn(LoginViewModel model, IAuthenticationManager authenticationManager)
        {
            var user = await UserManager.FindAsync(model.Email, model.Password);
            if (user != null)
            {
                await SignInAsync(user, model.RememberMe, authenticationManager);
                return true;
            }
            return false;
        }
        //public async Task<SignInStatus>checkCredentails(LoginViewModel model)
        //{
        //    var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
        //    return (result);
        //}

        public async Task<bool> checkCredentails(LoginViewModel model, IAuthenticationManager authenticationManager)
        {
            var user = await UserManager.FindAsync(model.Email, model.Password);
            if (user != null)
            {
                await SignInAsync(user,model.RememberMe, authenticationManager);
                return true;
            }
            return false;
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordViewModel model)
        {
            var user = await UserManager.FindByNameAsync(model.Email);
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            return (result);
        }

        public async Task<IdentityResult> Register(RegisterViewModel model)
        {

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, AccountType="Temp", EmailConfirmed = true };
            //Here we pass the byte array to user context to store in db

            var result = await UserManager.CreateAsync(user, model.Password);
            return (result);
        }

        
        public async Task<string> FindUser(string email)
        {
            var user = await UserManager.FindByNameAsync(email);
            bool y = (user != null);
            return (user.Id);
        }
        public async Task<string> GratePasswordResetToken(string userid)
        {
            string code = await UserManager.GeneratePasswordResetTokenAsync(userid);
            return (code);
        }

        public async Task sendResetPassWordLink(string user,string tit,string message)
        {
            await UserManager.SendEmailAsync(user,tit,message);
        }

        private async Task SignInAsync(AbantwanaWebMaster.Data.ApplicationUser user, bool isPersistent, IAuthenticationManager authenticationManager)
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
        public ApplicationRoleManager roleManager;
        
        // Add CreateAdminIfNeeded
        #region private void CreateAdminIfNeeded()
        public void CreateAdminIfNeeded()
        {
            // Get Admin Account
            string AdminUserName = "abantwanaweb@gmail.com";
            string AdminPassword = "#Azure{2019}";

            // See if Admin exists
            var objAdminUser = UserManager.FindByEmail(AdminUserName);

            if (objAdminUser == null)
            {
                //See if the Admin role exists
                if (!roleManager.RoleExists("Administrator"))
                {
                    // Create the Admin Role (if needed)
                    IdentityRole objAdminRole = new IdentityRole("Administrator");
                    roleManager.Create(objAdminRole);
                    //IdentityRole objAdminRole1 = new IdentityRole("Parent");
                    //RoleManager.Create(objAdminRole1);
                    //IdentityRole objAdminRole2 = new IdentityRole("Staff");
                    //RoleManager.Create(objAdminRole2);
                }

                // Create Admin user
                var objNewAdminUser = new ApplicationUser { UserName = AdminUserName, Email = AdminUserName,  EmailConfirmed = true };
                var AdminUserCreateResult = UserManager.Create(objNewAdminUser, AdminPassword);
                // Put user in Admin role
                UserManager.AddToRole(objNewAdminUser.Id, "Administrator");
            }
        }
        #endregion
    }
}
