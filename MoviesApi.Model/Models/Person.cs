using MoviesApi.Model.DbModels;
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

        public Country Country { get; set; }
        public IList<MoviePerson> MoviePerson { get; set; }

        public Person(int id,
                    string firstName,
                    string lastName,
                    TypeOfPeople type,
                    DateTime dateOfBirth,
                    DateTime dateOfDeath,
                    TypeOfSex sex,
                    Country country)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Type = type;
            DateOfBirth = dateOfBirth;
            DateOfDeath = dateOfDeath;
            Sex = sex;
            Country = country;
            MoviePerson = new List<MoviePerson>();
        }

        public Person()
        {
            MoviePerson = new List<MoviePerson>();
        }
    }
}
