using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AbantwanaWebMaster.Data
{
    public class DbInitialize<T> : DropCreateDatabaseIfModelChanges<IdentityDbContext>
        {
            protected override void Seed(IdentityDbContext context)
            {
                var userManager = new UserManager<ApplicationUser>(new 
                                                UserStore<ApplicationUser>(context)); 

                var roleManager = new RoleManager<ApplicationRole>(new 
                                          RoleStore<ApplicationRole>(context));
     
                const string name = "abantwanaweb@gmail.com";
                const string rol = "admin";
                const string password = "#2019Azure";
 
                if (!roleManager.RoleExists(rol))
                {
                var roleresult = roleManager.Create(new ApplicationRole(rol));
                }

                if (!roleManager.RoleExists("Parent"))
                {
                var roleresult = roleManager.Create(new ApplicationRole("Parent"));
                }
                if (!roleManager.RoleExists("Teacher"))
                {
                var roleresult = roleManager.Create(new ApplicationRole("Teacher"));
                }
                if (!roleManager.RoleExists("Kitchen_Staff"))
                {
                var roleresult = roleManager.Create(new ApplicationRole("Kitchen_Staff"));
                }

                var userAdmin = new ApplicationUser();
                var userParent = new ApplicationUser();
                var userTeacher = new ApplicationUser();
                var userKitchenStaff = new ApplicationUser();
                userAdmin.UserName = name;
               // userAdmin.userStatus = "No";
                userParent.UserName = "Parent@gmail.com";
               // userParent.userStatus = "No";
                userTeacher.UserName = "Teacher@gmail.com";
               // userTeacher.userStatus = "No";
                userKitchenStaff.UserName = "KitchenStaff@gmail.com";
                ///userKitchenStaff.userStatus = "No";
                var adminresult = userManager.Create(userAdmin, password);
                var teacherresult = userManager.Create(userTeacher, password);
                var parentresult = userManager.Create(userParent, password);
                var kitchenStaffresult = userManager.Create(userKitchenStaff, password);

                if (adminresult.Succeeded)
                {
                    var result = userManager.AddToRole(userAdmin.Id, rol);
                }
                if (teacherresult.Succeeded)
                {
                    var result = userManager.AddToRole(userTeacher.Id, "Teacher");
                } if (parentresult.Succeeded)
                {
                    var result = userManager.AddToRole(userParent.Id, "Parent");
                } if (kitchenStaffresult.Succeeded)
                {
                    var result = userManager.AddToRole(userKitchenStaff.Id, "Kitchen_Staff");
                }
                base.Seed(context);
            }
        }
    }

