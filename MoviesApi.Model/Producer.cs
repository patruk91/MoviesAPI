using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApi.Model
{
    public class Producer
    {
        public int Id { get; private set; }
        public string CompanyName { get; set; }
        public DateTime YearEstablished { get; set; }
        public Country CountryName { get; set; }
        public long EstimatedCompanyValue { get; set; }
        public List<Movie> Movies { get; private set; }

        public Country Country { get; set; }

        public Producer(int id,
                    string companyName,
                    DateTime yearEstablished,
                    Country countryName,
                    long estimatedCompanyValue)
        {
            Id = id;
            CompanyName = companyName;
            YearEstablished = yearEstablished;
            CountryName = countryName;
            EstimatedCompanyValue = estimatedCompanyValue;
            Movies = new List<Movie>();
        }

        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }
    }
}
