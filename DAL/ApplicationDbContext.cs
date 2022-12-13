using System;
using System.Collections.Generic;
using System.Text;
using DAL.Configuration;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);








            string userRoleId = "66b2703e-57fc-42ab-85d7-996ad1c0029b";
            string adminRoleId = "004f27b9-2aa1-4d9e-b704-0297892fc584";
            string userId = "2aa8379d-c3f0-47a9-b2f0-631787bb4970";

            string superAdminRoleId = "87b68954-9168-4d08-bd8a-a12a5dbc6f70";
            string superUserId = "ec7c8233-b171-4ce5-a2ca-d612e70f9658";
            string userLimitId = "0b35a2fa-6557-4bdf-9beb-409febcb6bae";

            modelBuilder.Entity<UserLimit>().HasData(
                new UserLimit
                {
                    Id = Guid.Parse(userLimitId),
                    MaxFilesNumber = 10,
                    MaxFileSize = 5 * 1024 * 1024, // 5 MB
                    MaxStorageSize = 50 * 1024 * 1024, //50 MB
                    UserId = null
                }
            );

            modelBuilder.Entity<IdentityRole>().HasData(
             new IdentityRole
             {
                 Id = userRoleId,
                 Name = Constants.REGISTEREDUSER,
                 NormalizedName = "REGISTEREDUSER"
             },
             new IdentityRole
             {
                 Id = adminRoleId,
                 Name = Constants.ADMINISTRATOR,
                 NormalizedName = "ADMINISTRATOR"
             },
            new IdentityRole
            {
                Id = superAdminRoleId,
                Name = Constants.SUPERADMIN,
                NormalizedName = "SUPERADMIN"
            });

            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = superUserId,
                    FirstName = "super",
                    LastName = "super",
                    UserName = "super@gmail.com",
                    Email = "super@gmail.com",
                    NormalizedUserName = "super@gmail.com".ToUpper(),
                    NormalizedEmail = "super@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "1111")
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId,
                    FirstName = "admin",
                    LastName = "admin",
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    NormalizedUserName = "admin@gmail.com".ToUpper(),
                    NormalizedEmail = "admin@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "1111")
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = userId
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = superAdminRoleId,
                UserId = superUserId
            }
        );
        }

        public DbSet<File> Files { get; set; }
        public DbSet<UserLimit> UserLimit { get; set; }
    }
}
