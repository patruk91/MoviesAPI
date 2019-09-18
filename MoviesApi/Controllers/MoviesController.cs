using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.AccessLayer;
using MoviesApi.Model;
using MoviesApi.Model.DbModels;
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
        public string GetTodoItems()
        {
            return "strg";
        }
    }
}
