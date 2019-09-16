using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoviesApi.Model;

namespace MoviesApi.AccessLayer
{
    public class MoviesDBEntities : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }


        public MoviesDBEntities()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsetting.json")
                .Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProducerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryEntityConfiguration());

        }
    }



}
