namespace Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Domain.Auth;
    using Microsoft.AspNetCore.Identity;

    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role
                    {
                        RoleName = "client",
                        RoleStatus = true
                    },
                    new Role
                    {
                        RoleName = "admin",
                        RoleStatus = true
                    },
                    new Role
                    {
                        RoleName = "seller",
                        RoleStatus = true
                    },
                    new Role
                    {
                        RoleName = "deliverer",
                        RoleStatus = true
                    },
                    new Role
                    {
                        RoleName = "owner",
                        RoleStatus = true
                    }

                };

                await context.Roles.AddRangeAsync(roles);
                await context.SaveChangesAsync();
            }


            if (!context.Users.Any())
            {
                var role = context.Roles.SingleOrDefault(x => x.RoleName == "admin");
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        UserName = "Admin",
                        Email = "admin.servipegaso@gmail.com",
                        PhoneNumber = "123456789",
                        RoleId = role.RoleId

                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
        }
    }
}
