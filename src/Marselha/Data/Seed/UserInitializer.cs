using Marselha.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Marselha.Data.Seed
{
    public class UserInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var context = serviceScope.ServiceProvider.GetRequiredService<MarselhaDbContext>();
                context.Database.Migrate();

                foreach (var (user, password) in GetUsers())
                {
                    if (userManager.FindByEmailAsync(user.Email).Result == null)
                    {
                        var result = userManager.CreateAsync(user, password).Result;
                    }
                }
            }
        }

        private static IEnumerable<(User, string)> GetUsers()
        {
            return new List<(User, string)>
            {
                (new User
                {
                    Email = "teste.dev@teste.com",
                    UserName = "teste.dev@teste.com",
                    FullName = "Teste Desenvolvimento",
                    Alias = "Teste Dev",
                    Cpf = "92415051845"
                }, "Teste.Dev$#1234")
            };
        }
    }
}
