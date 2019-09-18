using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApi.Model.DbModels
{
   public class MovieProducer
    {
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public MovieProducer(Movie movie, Producer producer)
        {
            this.Movie = movie;
            this.Producer = producer;
        }

        public MovieProducer()
        {
        }
    }
}
