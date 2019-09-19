using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.AccessLayer.DAO;
using MoviesApi.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.AccessLayer.dao.sql
{
    public class MovieSql : IMovieDao
    {
        private readonly MoviesDBEntities _context;

        public MovieSql(MoviesDBEntities context)
        {
            _context = context;
        }

        public Task<IActionResult> EditMovie(int id, MovieDTO movieDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            return await _context.Movies
               .Where(x => x.Id == id)
               .Select(x => new MovieDTO
               {
                   Id = x.Id,
                   Title = x.Title,
                   DirectorId = x.Director.Id,
                   Genre = x.Genre,
                   Length = x.Length,
                   Year = x.Year,
                   CountryId = x.Country.Id,
                   MovieProducersId = x.MovieProducers.Select(y => y.ProducerId).ToList(),
                   MovieActorsId = x.MoviePerson.Select(y => y.PersonId).ToList()
               }).FirstOrDefaultAsync();
        }

        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            return await _context.Movies
                .Select(x => new MovieDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    DirectorId = x.Director.Id,
                    Genre = x.Genre,
                    Length = x.Length,
                    Year = x.Year,
                    CountryId = x.Country.Id,
                    MovieProducersId = x.MovieProducers.Select(y => y.ProducerId).ToList(),
                    MovieActorsId = x.MoviePerson.Select(y => y.PersonId).ToList()
                }).ToListAsync();
        }

        public Task<ActionResult<MovieDTO>> PostMovie(MovieDTO movieDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> RemoveMovie(int id)
        {
            throw new NotImplementedException();
        }
    }
}
