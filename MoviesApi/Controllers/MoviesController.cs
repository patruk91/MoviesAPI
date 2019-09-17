using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.AccessLayer;
using MoviesApi.Model;
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
            PopulateDb();
        }

        private void PopulateDb()
        {
            Country countryPoland = new Country("Poland");
            Country countryVietnam = new Country("Vietnam");

            _context.Countries.Add(countryPoland);
            _context.Countries.Add(countryVietnam);
            _context.SaveChanges();
        }

        [HttpGet]
        public string GetTodoItems()
        {
            return "strg";
        }
    }
}
