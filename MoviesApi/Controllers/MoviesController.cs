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

        [HttpGet("{id:int}")]
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

        [HttpGet("title/{title}")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovieByTitle(string title)
        {
            return await _context.Movies
                .Where(x => x.Title.Contains(title))
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
            await AddActorsToMovie(movieDTO, movie);
            await AddProducersToMovie(movieDTO, movie);

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovie), new { id = movieDTO.Id }, movieDTO);
        }

        private async Task AddProducersToMovie(MovieDTO movieDTO, Movie movie)
        {
            foreach (int producerId in movieDTO.MovieProducersId)
            {
                Producer producer = await _context.Producers.FindAsync(producerId);
                MovieProducer movieProducer = new MovieProducer(movie, producer);
                movie.Add(movieProducer);
            }
        }

        private async Task AddActorsToMovie(MovieDTO movieDTO, Movie movie)
        {
            foreach (int actorId in movieDTO.MovieActorsId)
            {
                Person actor = await _context.People.FindAsync(actorId);
                MoviePerson moviePerson = new MoviePerson(movie, actor);
                movie.Add(moviePerson);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditMovie(int id, MovieDTO movieDTO)
        {
            if(id != movieDTO.Id)
            {
                return BadRequest();
            }
            Movie movie = await _context.Movies.FindAsync(id);
            IList<MoviePerson> actors = _context.MoviePersons.Where(x => x.MovieId == id).ToList();
            IList<MovieProducer> producers = _context.MovieProducers.Where(x => x.MovieId == id).ToList();

            _context.MoviePersons.RemoveRange(actors);
            _context.MovieProducers.RemoveRange(producers);

            Person director = await _context.People.FindAsync(movieDTO.DirectorId);
            Country country = await _context.Countries.FindAsync(movieDTO.CountryId);
            movie.Title = movieDTO.Title;
            movie.Director = director;
            movie.Genre = movieDTO.Genre;
            movie.Length = movieDTO.Length;
            movie.Year = movieDTO.Year;
            movie.Country = country;
            await AddActorsToMovie(movieDTO, movie);
            await AddProducersToMovie(movieDTO, movie);

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMovie(int id)
        {
            Movie movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
