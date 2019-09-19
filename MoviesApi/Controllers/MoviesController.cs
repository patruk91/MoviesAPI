﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.AccessLayer;
using MoviesApi.AccessLayer.dao;
using MoviesApi.AccessLayer.DAO;
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
        private IMovieDao _movieDao;
        private ICountryDao _countryDao;
        private IPersonDao _personDao;
        private IMoviePersonDao _moviePersonDao;
        private IMovieProducerDao _movieProducerDao;

        public MoviesController(MoviesDBEntities context,
                                IMovieDao movieDao,
                                ICountryDao countryDao,
                                IPersonDao personDao,
                                IMoviePersonDao moviePersonDao,
                                IMovieProducerDao movieProducerDao)
        {
            _context = context;
            _movieDao = movieDao;
            _countryDao = countryDao;
            _personDao = personDao;
            _moviePersonDao = moviePersonDao;
            _movieProducerDao = movieProducerDao;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            return await _movieDao.GetMovies();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            ActionResult<MovieDTO> movieDTO = await _movieDao.GetMovie(id);
            if (movieDTO == null)
            {
                return NotFound();
            }
            return movieDTO;
        }

        [HttpPost]
        public async Task<ActionResult<MovieDTO>> PostMovie(MovieDTO movieDTO)
        {
            Person director = _personDao.GetPerson(movieDTO.DirectorId).Result;
            Country country = _countryDao.GetCountry(movieDTO.CountryId).Result;

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
                Person actor = _personDao.GetPerson(actorId).Result;
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
            _moviePersonDao.RemoveActorsFromMovie(id);
            _movieProducerDao.RemoveProducersFromMovie(id);

            Person director = _personDao.GetPerson(movie.DirectorId).Result;
            Country country = _countryDao.GetCountry(movieDTO.CountryId).Result;

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
