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
                    CountryId = x.Country.Id,
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
                    CountryId = x.Country.Id,
                    MovieProducersId = x.MovieProducers.Select(y => y.ProducerId).ToList(),
                    MovieActorsId = x.MoviePerson.Select(y => y.PersonId).ToList()
                }).FirstOrDefaultAsync();
            if (movieDTO == null)
            {
                return NotFound();
            }
            return movieDTO;
        }

        [HttpPost]
        public async Task<ActionResult<MovieDTO>> PostMovie(MovieDTO movieDTO)
        {
            Person director = await _context.People.FindAsync(movieDTO.DirectorId);
            Country country = await _context.Countries.FindAsync(movieDTO.CountryId);
            Movie movie = new Movie
            {
                Title = movieDTO.Title,
                Director = director,
                Genre = movieDTO.Genre,
                Length = movieDTO.Length,
                Year = movieDTO.Year,
                Country = country

            };
            foreach (int actorId in movieDTO.MovieActorsId)
            {
                Person actor = await _context.People.FindAsync(actorId);
                MoviePerson moviePerson = new MoviePerson(movie, actor);
                movie.Add(moviePerson);
            }

            foreach (int producerId in movieDTO.MovieProducersId)
            {
                Producer producer = await _context.Producers.FindAsync(producerId);
                MovieProducer movieProducer = new MovieProducer(movie, producer);
                movie.Add(movieProducer);
            }

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovie), new { id = movieDTO.Id }, movieDTO);
        }
    }
}
