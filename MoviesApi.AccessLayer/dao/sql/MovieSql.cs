using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.AccessLayer.DAO;
using MoviesApi.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            
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
