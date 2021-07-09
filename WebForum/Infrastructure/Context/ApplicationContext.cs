using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WebForum.Domain.Entities;

namespace WebForum.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Comment> Comment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Environment.GetEnvironmentVariable("DATABASE_CONN") != null)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_CONN"), npgsqlOptionsAction: options =>
                {
                    options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                    options.MigrationsHistoryTable("_MigrationHistory", "postgres");
                });
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase("InMemoryProvider");
            }

        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User("Teste", "email@email.com", "testetesteteste")
                ); 
            /*
            //DEIXAR PARA FAZER O MIGRATION SEM OS MAPS
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new TopicMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new UserTypeMap());
*/
            /* modelBuilder.Entity<UserType>().HasData(
                 new UserType(1, "SuperAdmin"),
                 new UserType(2, "Admin"),
                 new UserType(3, "Moderator"),
                 new UserType(4, "Common"),
                 new UserType(5, "Visitor"));*/

            /* modelBuilder.Entity<User>().HasData(
                 new User("SuperAdmin", "superadmin@superadmin.com", "password", 1));

 *//*         modelBuilder.Entity<UserType>().HasData(
                new UserType("Admin"));*/

            base.OnModelCreating(modelBuilder);
        }

    }
}
