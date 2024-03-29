﻿    using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI.Dtos;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext : IdentityDbContext<HousingUser>
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<City> Cities { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserSignUp> UserSignUps { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                //.AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
                ;
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.PropertyTypeId).IsFixedLength();
                entity.Property(e => e.FurnishingTypeId).IsFixedLength();
            });
            // Configure the User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username).IsRequired();
                entity.Property(u => u.PasswordHash).IsRequired();
            });
        }


    }

}
