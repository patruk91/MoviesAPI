using MoviesApi.Model.DbModels;
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

        public Country Country { get; set; }
        public int DirectorId { get; set; }
        public IList<MovieProducer> MovieProducers { get; set; }
        public IList<MoviePerson> MoviePerson { get; set; }

        public Movie(int id,
                    string title,
                    Person director,
                    TypesOfGenre genre,
                    long length,
                    DateTime year,
                    Country country)
        {
            Id = id;
            Title = title;
            Director = director;
            Genre = genre;
            Length = length;
            Year = year;
            Country = country;
            MoviePerson = new List<MoviePerson>();
            MovieProducers = new List<MovieProducer>();
        }

        public Movie()
        {
            MoviePerson = new List<MoviePerson>();
            MovieProducers = new List<MovieProducer>();
        }

    }
}
