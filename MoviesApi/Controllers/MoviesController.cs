using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.AccessLayer;
using MoviesApi.Model;
using MoviesApi.Model.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesDBEntities _context;

        public MoviesController(MoviesDBEntities context)
        {
            _context = context;
            PopulateDb();
        }

        private void PopulateDb()
        {
            Country country1 = new Country { Name = "Poland" };
            Country country2 = new Country {Name = "Vietnam" };

            Person director1 = new Person
            {
                FirstName = "Joe",
                LastName = "Doe",
                Type = TypeOfPeople.DIRECTOR,
                DateOfBirth = DateTime.Now,
                DateOfDeath = DateTime.Now,
                Sex = TypeOfSex.MALE,
                Country = country1
            };

            Person actor1 = new Person
            {
                FirstName = "Stefa",
                LastName = "Rychu",
                Type = TypeOfPeople.ACTOR,
                DateOfBirth = DateTime.Now,
                DateOfDeath = DateTime.Now,
                Sex = TypeOfSex.FEMALE,
                Country = country2
            };

            Person actor2 = new Person
            {
                FirstName = "Rychu",
                LastName = "Peja",
                Type = TypeOfPeople.ACTOR,
                DateOfBirth = DateTime.Now,
                DateOfDeath = DateTime.Now,
                Sex = TypeOfSex.MALE,
                Country = country1
            };

            Movie movie1 = new Movie
            {
                Title = "Snoop doog",
                Director = director1,
                Genre = TypesOfGenre.COMEDY,
                Length = 127,
                Year = DateTime.Now,
                Country = country2
            };

            MoviePerson moviePerson1 = new MoviePerson();
            moviePerson1.Person = actor1;
            moviePerson1.Movie = movie1;

            MoviePerson moviePerson2 = new MoviePerson();
            moviePerson2.Person = actor2;
            moviePerson2.Movie = movie1;

            movie1.MoviePerson.Add(moviePerson1);
            movie1.MoviePerson.Add(moviePerson2);

            Producer producer1 = new Producer
            {
                CompanyName = "Test Company",
                YearEstablished = DateTime.Now,
                EstimatedCompanyValue = 40000000,
                Country = country1,
            };

            MovieProducer movieProducer1 = new MovieProducer();
            movieProducer1.Movie = movie1;
            movieProducer1.Producer = producer1;

            movie1.MovieProducers.Add(movieProducer1);



            _context.People.Add(actor1);
            _context.People.Add(actor2);
            _context.Movies.Add(movie1);
            _context.Producers.Add(producer1);

            _context.Countries.Add(country1);
            _context.Countries.Add(country2);
            _context.SaveChanges();
        }

        [HttpGet]
        public string GetTodoItems()
        {
            return "strg";
        }
    }
}
