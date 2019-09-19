using MoviesApi.Model.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviesApi.AccessLayer.dao.sql
{
    public class MoviePersonSql : IMoviePersonDao
    {
        private readonly MoviesDBEntities _context;

        public MoviePersonSql(MoviesDBEntities context)
        {
            _context = context;
        }

        public void RemoveActorsFromMovie(int id)
        {
            IList<MoviePerson> actors = _context.MoviePersons.Where(x => x.MovieId == id).ToList();
            _context.MoviePersons.RemoveRange(actors);
            _context.SaveChangesAsync();
        }
    }
}
