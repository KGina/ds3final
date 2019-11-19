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
using System.Configuration;

namespace AbantwanaWebMaster.BusinessLogic
{
    public class RegisterBusiness
    {
        public UserManager<AbantwanaWebMaster.Data.ApplicationUser> UserManager { get; set; }

        public RegisterBusiness()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DataContext()));
        }

        public bool FindUser(string userName, IAuthenticationManager authenticationManager)
        {
            var user = UserManager.FindByName(userName);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RegisterUser(RegisterModel objRegisterModel, IAuthenticationManager authenticationManager)
        {
            var newuser = new AbantwanaWebMaster.Data.ApplicationUser()
            {
                Id = objRegisterModel.UserName,
                UserName = objRegisterModel.UserName,
                Email = objRegisterModel.UserName,
                PasswordHash = UserManager.PasswordHasher.HashPassword(objRegisterModel.Password)
            };

            var result = await UserManager.CreateAsync(
               newuser, objRegisterModel.Password);

            if (result.Succeeded)
            {
                //await SignInAsync(newuser, false, authenticationManager);
                return true;
            }
            return false;
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent, IAuthenticationManager authenticationManager)
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public bool AddUserToRole(string user, string role)
        {
            var result = UserManager.AddToRole(user, role);

            return result.Succeeded;
        }
        public string GeneratePassword(int passLength)
        {
            var chars = "abcdefghijklmnopqrstuvwxyz@#$&ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, passLength)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return "#@password01";
        }

        //private void CreateAdminIfNeeded()
        //{
        //    // Get Admin Account
        //    string AdminUserName = ConfigurationManager.AppSettings["AdminUserName"];
        //    string AdminPassword = ConfigurationManager.AppSettings["AdminPassword"];

        //    // See if Admin exists
        //    var objAdminUser = UserManager.FindByEmail(AdminUserName);

        //    if (objAdminUser == null)
        //    {
        //        //See if the Admin role exists
        //        if (!RoleManager.RoleExists("Administrator"))
        //        {
        //            // Create the Admin Role (if needed)
        //            IdentityRole objAdminRole = new IdentityRole("Administrator");
        //            RoleManager.Create(objAdminRole);
        //            //IdentityRole objAdminRole1 = new IdentityRole("Parent");
        //            //RoleManager.Create(objAdminRole1);
        //            //IdentityRole objAdminRole2 = new IdentityRole("Staff");
        //            //RoleManager.Create(objAdminRole2);
        //        }

        //        // Create Admin user
        //        var objNewAdminUser = new ApplicationUser { UserName = AdminUserName, Email = AdminUserName, userStatus = "NO", EmailConfirmed = true };
        //        var AdminUserCreateResult = UserManager.Create(objNewAdminUser, AdminPassword);
        //        // Put user in Admin role
        //        UserManager.AddToRole(objNewAdminUser.Id, "Administrator");
        //    }
        //}
    }
}
