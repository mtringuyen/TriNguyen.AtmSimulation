using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriNguyen.AtmSimulation.Core.Entities;
using TriNguyen.AtmSimulation.Infrastructure.Data;

namespace TriNguyen.AtmSimulation.Web
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
            {
                // Look for any TODO items.
                if (dbContext.Users.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);


            }
        }
        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.Users)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();
            dbContext.Users.Add(new User
            {
                UserName = "tester01",
                PinNumber = "123123"
            });

            dbContext.Users.Add(new User
            {
                UserName = "tester02",
                PinNumber = "123456"
            });

            dbContext.Users.Add(new User
            {
                UserName = "tester03",
                PinNumber = "qweasd"
            });

            dbContext.SaveChanges();
        }
    }
}
