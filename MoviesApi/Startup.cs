using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MoviesApi.AccessLayer;
using MoviesApi.AccessLayer.dao;
using MoviesApi.AccessLayer.dao.sql;
using MoviesApi.AccessLayer.DAO;

namespace MoviesApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<MoviesDBEntities>(
                context => context.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));

            MovieSql moviesSql = new MovieSql(new MoviesDBEntities(new DbContextOptions<MoviesDBEntities>()));
            ICountryDao countryDao = new CountrySql(new MoviesDBEntities(new DbContextOptions<MoviesDBEntities>()));
            IPersonDao personDao = new PersonSql(new MoviesDBEntities(new DbContextOptions<MoviesDBEntities>()));
            IMovieProducerDao movieProducerDao = new MovieProducerSql(new MoviesDBEntities(new DbContextOptions<MoviesDBEntities>()));
            IMoviePersonDao moviePersonDao = new MoviePersonSql(new MoviesDBEntities(new DbContextOptions<MoviesDBEntities>()));
            services.Add(new ServiceDescriptor(typeof(IMovieDao), moviesSql));
            services.Add(new ServiceDescriptor(typeof(IPersonDao), personDao));
            services.Add(new ServiceDescriptor(typeof(ICountryDao), countryDao));
            services.Add(new ServiceDescriptor(typeof(IMoviePersonDao), moviePersonDao));
            services.Add(new ServiceDescriptor(typeof(IMovieProducerDao), movieProducerDao));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
