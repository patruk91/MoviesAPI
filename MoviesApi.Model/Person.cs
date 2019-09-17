using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApi.Model
{
    public class Person
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TypeOfPeople Type { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public TypeOfSex Sex { get; set; }
        public Country CountryName { get; set; }
        public IList<Movie> Movies { get; set; }

        public Country Country { get; set; }

        public Person(int id,
                    string firstName,
                    string lastName,
                    TypeOfPeople type,
                    DateTime dateOfBirth,
                    DateTime dateOfDeath,
                    TypeOfSex sex,
                    Country countryName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Type = type;
            DateOfBirth = dateOfBirth;
            DateOfDeath = dateOfDeath;
            Sex = sex;
            CountryName = countryName;
            Movies = new List<Movie>();
        }

        public Person()
        {
        }

        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }
    }
}
