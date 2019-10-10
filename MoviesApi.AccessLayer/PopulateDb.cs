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
            Country country3 = new Country { Name = "France" };

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

            Person director2 = new Person
            {
                FirstName = "Coco",
                LastName = "Jambo",
                Type = TypeOfPeople.DIRECTOR,
                DateOfBirth = DateTime.Now,
                DateOfDeath = DateTime.Now,
                Sex = TypeOfSex.MALE,
                Country = country3
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

            Person actor3 = new Person
            {
                FirstName = "Seba",
                LastName = "Przykuc",
                Type = TypeOfPeople.ACTOR,
                DateOfBirth = DateTime.Now,
                DateOfDeath = DateTime.Now,
                Sex = TypeOfSex.MALE,
                Country = country3
            };

            Person actor4 = new Person
            {
                FirstName = "Karyna",
                LastName = "Bombelek",
                Type = TypeOfPeople.ACTOR,
                DateOfBirth = DateTime.Now,
                DateOfDeath = DateTime.Now,
                Sex = TypeOfSex.MALE,
                Country = country3
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

            Movie movie2 = new Movie
            {
                Title = "Kac Krakow",
                Director = director2,
                Genre = TypesOfGenre.DRAMA,
                Length = 101,
                Year = DateTime.Now,
                Country = country1
            };

            Movie movie3 = new Movie
            {
                Title = "Zycie ostre jak maczeta",
                Director = director2,
                Genre = TypesOfGenre.FANTASY,
                Length = 101,
                Year = DateTime.Now,
                Country = country1
            };

            Producer producer1 = new Producer
            {
                CompanyName = "Test Company",
                YearEstablished = DateTime.Now,
                EstimatedCompanyValue = 40000000,
                Country = country1,
            };

            Producer producer2 = new Producer
            {
                CompanyName = "Januszex POL",
                YearEstablished = DateTime.Now,
                EstimatedCompanyValue = 999999999999,
                Country = country2,
            };

            MoviePerson movie1Person1 = new MoviePerson(movie1, actor1);
            MoviePerson movie1Person2 = new MoviePerson(movie1, actor2);
            MoviePerson movie2Person1 = new MoviePerson(movie2, actor2);
            MoviePerson movie2Person2 = new MoviePerson(movie2, actor4);
            MoviePerson movie3Person1 = new MoviePerson(movie3, actor3);
            MoviePerson movie3Person2 = new MoviePerson(movie3, actor4);
            MovieProducer movie1Producer1 = new MovieProducer(movie1, producer1);
            MovieProducer movie2Producer1 = new MovieProducer(movie2, producer2);
            MovieProducer movie2Producer2 = new MovieProducer(movie2, producer1);
            MovieProducer movie3Producer1 = new MovieProducer(movie3, producer2);

            movie1.Add(movie1Person1);
            movie1.Add(movie1Person2);
            movie1.Add(movie1Producer1);

            movie2.Add(movie2Person1);
            movie2.Add(movie2Person2);
            movie2.Add(movie2Producer1);
            movie2.Add(movie2Producer2);


            movie3.Add(movie3Person1);
            movie3.Add(movie3Person2);
            movie3.Add(movie3Producer1);

            _context.Movies.Add(movie1);
            _context.Movies.Add(movie2);
            _context.Movies.Add(movie3);
            _context.SaveChanges();
        }
    }
}
