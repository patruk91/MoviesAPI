using MoviesApi.AccessLayer;
using MoviesApi.Model;
using MoviesApi.Model.DbModels;
using System;

namespace MoviesApi.AccessLayer
{
    public class PopulateDb
    {
        private readonly MoviesDBEntities _context;

        public PopulateDb(MoviesDBEntities context)
        {
            _context = context;
        }

        public void FillDbWithData()
        {
            Country country1 = new Country { Name = "Poland" };
            Country country2 = new Country { Name = "Vietnam" };

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

            Producer producer1 = new Producer
            {
                CompanyName = "Test Company",
                YearEstablished = DateTime.Now,
                EstimatedCompanyValue = 40000000,
                Country = country1,
            };

            MoviePerson moviePerson1 = new MoviePerson(movie1, actor1);
            MoviePerson moviePerson2 = new MoviePerson(movie1, actor2);
            MovieProducer movieProducer1 = new MovieProducer(movie1, producer1);

            movie1.Add(moviePerson1);
            movie1.Add(moviePerson2);
            movie1.Add(movieProducer1);

            _context.Movies.Add(movie1);
            _context.SaveChanges();
        }
    }
}
