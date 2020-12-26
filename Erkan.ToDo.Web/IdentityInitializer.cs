using Erkan.ToDo.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Erkan.ToDo.Web
{
    public class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole==null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }
            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }
            var adminUser = await userManager.FindByNameAsync("erkan");
            if (adminUser==null)
            {
                AppUser user= new AppUser{ 
                    Name="Erkan",
                    SurName="Çömez",
                    UserName="erkan",
                    Email="Erkan@erkancomez.com.tr"

                };
                await userManager.CreateAsync(user,"1");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
