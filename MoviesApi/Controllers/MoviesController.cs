using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.AccessLayer;
using MoviesApi.Model;
using MoviesApi.Model.DbModels;
using MoviesApi.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesDBEntities _context;

        public MoviesController(MoviesDBEntities context)
        {
            _context = context;
        }

        [HttpGet]
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
                    CountryName = x.Country.Name,
                    MovieProducersId = x.MovieProducers.Select(y => y.ProducerId).ToList(),
                    MovieActorsId = x.MoviePerson.Select(y => y.PersonId).ToList()
                }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            var movieDTO = await _context.Movies
                .Where(x => x.Id == id)
                .Select(x => new MovieDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    DirectorId = x.Director.Id,
                    Genre = x.Genre,
                    Length = x.Length,
                    Year = x.Year,
                    CountryName = x.Country.Name,
                    MovieProducersId = x.MovieProducers.Select(y => y.ProducerId).ToList(),
                    MovieActorsId = x.MoviePerson.Select(y => y.PersonId).ToList()
                }).FirstOrDefaultAsync();
            if (movieDTO == null)
            {
                return NotFound();
            }
            return movieDTO;
        }
    }
}
