using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoviesApi.Model;
using MoviesApi.Model.DbModels;

namespace MoviesApi.AccessLayer
{
    public class MoviesDBEntities : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<MovieProducer> MovieProducers { get; set; }
        public virtual DbSet<MoviePerson> MoviePersons { get; set; }


        public MoviesDBEntities(DbContextOptions<MoviesDBEntities> options) : base(options)
        {
            if (Database.EnsureCreated())
            {
                PopulateDb populateDb = new PopulateDb(this);
                populateDb.FillDbWithData();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProducerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MovieProducerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MoviePersonEntityConfiguration());
        }
    }



}
