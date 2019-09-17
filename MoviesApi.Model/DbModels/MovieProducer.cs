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

       
    }
}
