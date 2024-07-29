using Connectify.Entities.DbSet;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Connectify.DataService.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Comment>()
                .HasOne(p => p.AppUser)
                .WithMany(u => u.Comments)
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Post>()
              .HasMany(p => p.Comments)
              .WithOne(c => c.Post)
              .HasForeignKey(c => c.PostId)
              .OnDelete(DeleteBehavior.NoAction);

            SeedData(builder);
        }


        private void SeedData(ModelBuilder builder)
        {
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);

            var user = new AppUser
            {
                FirstName = "Davy",
                LastName = "Merlo",
                Email = "davymerlo@live.be",
                UserName = "davymerlo@live.be",
                BirthDay = new DateTime(1990, 5, 15),
                Gender = 'M',
                NormalizedUserName = "DAVYMERLO@LIVE.BE",
                NormalizedEmail = "DAVYMERLO@LIVE.BE",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                ConcurrencyStamp = Guid.NewGuid().ToString("D")
            };

            var passwordHasher = new PasswordHasher<AppUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Merlo2024");

            builder.Entity<AppUser>().HasData(user);


            var post = new Post
            {
                AppUserId = user.Id,
                Content = "Watch the movie Terminator 3 yesterday!",
            };
            builder.Entity<Post>().HasData(post);

            List<Comment> comments = new List<Comment>
            {
                new Comment
                {
                    PostId = post.Id,   
                    AppUserId = user.Id,
                    Content = "Nice! Very great movie"
                },
                new Comment
                {
                    PostId = post.Id,
                    AppUserId = user.Id,
                    Content = "I want to watch it also!!!"
                },
                new Comment
                {
                    PostId = post.Id,
                    AppUserId = user.Id,
                    Content = "Jelous!!!"
                },
            };
            builder.Entity<Comment>().HasData(comments);
        }
    }
}
