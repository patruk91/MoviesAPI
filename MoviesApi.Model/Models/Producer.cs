using MoviesApi.Model.DbModels;
using System;
using System.Collections.Generic;

namespace MoviesApi.Model
{
    public class Producer
    {
        public int Id { get; private set; }
        public string CompanyName { get; set; }
        public DateTime YearEstablished { get; set; }
        public long EstimatedCompanyValue { get; set; }

        public Country Country { get; set; }
        public IList<MovieProducer> MovieProducers { get; set; }

        public Producer(int id,
                    string companyName,
                    DateTime yearEstablished,
                    Country country,
                    long estimatedCompanyValue)
        {
            Id = id;
            CompanyName = companyName;
            YearEstablished = yearEstablished;
            Country = country;
            EstimatedCompanyValue = estimatedCompanyValue;
            MovieProducers = new List<MovieProducer>();
        }

        public Producer()
        {
            MovieProducers = new List<MovieProducer>();
        }

    }
}
