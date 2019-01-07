using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Marselha.Data.Seed
{
    public class IdentityServerInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();

                foreach (var client in IdentityServerConfig.GetClients())
                {
                    if (context.Clients.Where(x => x.ClientId == client.ClientId).FirstOrDefault() == null)
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                }
                context.SaveChanges();

                foreach (var resource in IdentityServerConfig.GetResources())
                {
                    if (context.IdentityResources.Where(x => x.Name == resource.Name).FirstOrDefault() == null)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                }
                context.SaveChanges();

                foreach (var resource in IdentityServerConfig.GetApis())
                {
                    if (context.ApiResources.Where(x => x.Name == resource.Name).FirstOrDefault() == null)
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
