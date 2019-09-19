using Microsoft.AspNetCore.Mvc;
using MoviesApi.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.AccessLayer.DAO
{
    public interface IMovieDao
    {
        Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies();
        Task<ActionResult<MovieDTO>> GetMovie(int id);
        Task<ActionResult<MovieDTO>> PostMovie(MovieDTO movieDTO);
        Task<IActionResult> EditMovie(int id, MovieDTO movieDTO);
        Task<IActionResult> RemoveMovie(int id);
    }
}
