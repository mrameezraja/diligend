using Diligend.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diligend
{
    public static class IApplicationBuilderExtensions
    {
        public static async Task SeedDatabase(this IApplicationBuilder app, IConfiguration configuration)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var context = services.GetRequiredService<ApplicationDbContext>();
                // await context.Database.MigrateAsync();

                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new string[] { "admin", "student" };

                foreach (var role in roles)
                {
                    if(!(await roleManager.RoleExistsAsync(role)))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                var adminEmail = "admin@diligend.com";

                var admin = await userManager.FindByEmailAsync(adminEmail);

                if(admin == null)
                {
                    var user = new IdentityUser(adminEmail)
                    {
                        Email = adminEmail
                    };

                    var result = await userManager.CreateAsync(user, "p@ssW0rd??");

                    await userManager.AddToRoleAsync(user, "admin");
                }

                string studentEmail = "student@diligend.com";

                var student = await userManager.FindByEmailAsync(studentEmail);

                if (student == null)
                {
                    var user = new IdentityUser(studentEmail)
                    {
                        Email = studentEmail
                    };

                    await userManager.CreateAsync(user, "p@ssW0rd??");

                    await userManager.AddToRoleAsync(user, "student");
                }


                var college = await context.Colleges.FirstOrDefaultAsync(_ => _.Name == "MyCollege");

                if(college == null)
                {
                    await context.Colleges.AddAsync(new Data.Entities.College
                    {
                        Id = Guid.NewGuid(),
                        Name = "MyCollege",
                        CreationTime = DateTime.Now
                    });

                    await context.SaveChangesAsync();
                }

                var form = await context.Colleges.FirstOrDefaultAsync(_ => _.Name == "MyForm");

                if(form == null)
                {
                    await context.CollegeForms.AddAsync(new Data.Entities.CollegeForm
                    {
                        Id = Guid.NewGuid(),
                        CollegeId = college.Id,
                        Name = "MyForm",
                        CreationTime = DateTime.Now
                    });

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
