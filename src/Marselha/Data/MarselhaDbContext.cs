using Marselha.Data.Mappings;
using Marselha.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Marselha.Data
{
    public class MarselhaDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<User> User { get; set; }

        public MarselhaDbContext(DbContextOptions<MarselhaDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Marselha");
            builder.ApplyConfiguration(new UserMap());

            builder.Entity<User>().ToTable("User");
            builder.Entity<Role>().ToTable("Role");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaim");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaim");
        }
    }
}
