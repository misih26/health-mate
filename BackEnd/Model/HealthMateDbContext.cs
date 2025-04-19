using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HealthMateDbContext: DbContext //IdentityDbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> Users { get; set; }
        public HealthMateDbContext(DbContextOptions<HealthMateDbContext> ctx)
            : base(ctx)
        {
           this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasMany(c => c.Recipes)
                .WithOne(r => r.Category)
                .HasForeignKey(r => r.CategoryId);

            User customer = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Username = "testcustomer",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                Role = "customer"
            };

            User admin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Username = "testadmin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("test"),
                Role = "admin"
            };

            Category category = new Category();
            category.Id = Guid.NewGuid().ToString();
            category.Name = "Big";

            Recipe recipe = new Recipe();
            recipe.Id = Guid.NewGuid().ToString();
            recipe.CategoryId = category.Id;
            recipe.Name = "Fat";
            recipe.Description = "Fatter";

            builder.Entity<Category>().HasData(category);
            builder.Entity<Recipe>().HasData(recipe);
            builder.Entity<User>().HasData(admin, customer);
        }
    }
}
