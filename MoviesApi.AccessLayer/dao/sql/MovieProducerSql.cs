using MoviesApi.AccessLayer;
using MoviesApi.Model.DbModels;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApi
{
    public class MovieProducerSql : IMovieProducerDao
    {
        private MoviesDBEntities _context;

        public MovieProducerSql(MoviesDBEntities context)
        {
            this._context = context;
        }

        public void RemoveProducersFromMovie(int id)
        {
            IList<MovieProducer> producers = _context.MovieProducers.Where(x => x.MovieId == id).ToList();
            _context.MovieProducers.RemoveRange(producers);
        }
    }
}