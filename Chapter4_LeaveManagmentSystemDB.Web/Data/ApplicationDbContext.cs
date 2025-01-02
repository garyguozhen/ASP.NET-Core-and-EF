using Chapter4_LeaveManagementSystem.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Chapter4_LeaveManagmentSystemDB.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(w=>w.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id= "9120f1fb-cd1d-439e-a933-aa7b5680a2ca",
                    Name="Normal",
                    NormalizedName="NORMAL"
                }, new IdentityRole
                {
                    Id = "6ddb0e2f-2b9f-49be-b44e-5604e87601e6",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }, new IdentityRole
                {
                    Id = "a900f623-1ed0-4764-9b5c-9134a7a92eed",
                    Name = "Contributer",
                    NormalizedName = "CONTRIBUTER"
                }
                );

            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "0f3fdff1-3daa-4978-ad34-e7c43781a7f9",
                    Email = "me@test.com",
                    NormalizedEmail = "ME@TEST.COM",
                    NormalizedUserName = "ME@TEST.COM",
                    UserName = "me@test.com",
                    PasswordHash = hasher.HashPassword(null,"1qaz@WSX")
                }
                );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>{
                    RoleId= "6ddb0e2f-2b9f-49be-b44e-5604e87601e6",
                    UserId= "0f3fdff1-3daa-4978-ad34-e7c43781a7f9"
                }
                );
        }
        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
