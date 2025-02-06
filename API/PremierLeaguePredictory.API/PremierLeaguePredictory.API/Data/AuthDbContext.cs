using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PremierLeaguePredictory.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "c923bb18-bb28-4125-8cb5-2fa281341588";
            var writerRoleId = "e44c9585-17fb-4037-847e-cb5053bc7a69";

            // Create Reader and Writer roles
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "READER",
                    ConcurrencyStamp = readerRoleId
                },
                new IdentityRole()
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "WRITER",
                    ConcurrencyStamp = writerRoleId
                }
            };

            //Seed roles
            builder.Entity<IdentityRole>().HasData(roles);

            // Create default admin user
            var adminUserId = "81d0ca6e-768c-4a59-8e5a-1d04be638425";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@plp.com",
                Email = "admin@plp.com",
                NormalizedEmail = "admin@plp.com".ToUpper(),
                NormalizedUserName = "admin@plp.com".ToUpper()
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

            builder.Entity<IdentityUser>().HasData(admin);

            // Give roles to admin user 
            var adminRoles = new List<IdentityUserRole<string>>() {
                new ()
                {
                    UserId = adminUserId,
                    RoleId = readerRoleId
                },
                new ()
                {
                    UserId = adminUserId,
                    RoleId = writerRoleId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
