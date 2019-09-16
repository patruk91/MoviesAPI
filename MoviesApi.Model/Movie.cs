using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApi.Model
{
    public class Movie
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public Person Director { get; set; }
        public TypesOfGenre Genre { get; set; }
        public long Length { get; set; }
        public DateTime Year { get; set; }
        public Country CountryName { get; set; }
        public IList<Person> Actors { get; private set; }

        public Country Country { get; set; }

        public Movie(int id,
                    string title,
                    Person director,
                    TypesOfGenre genre,
                    long length,
                    DateTime year,
                    Country countryName)
        {
            Id = id;
            Title = title;
            Director = director;
            Genre = genre;
            Length = length;
            Year = year;
            CountryName = countryName;
            Actors = new List<Person>();
        }

        public void AddActor(Person actor)
        {
            Actors.Add(actor);
        }
    }
}
