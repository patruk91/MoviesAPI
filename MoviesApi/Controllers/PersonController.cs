using Microsoft.AspNetCore.Mvc;
using MoviesApi.AccessLayer;
using MoviesApi.Model.DTO;
using MoviesApi.Model;
using MoviesApi.Model.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly MoviesDBEntities _context;

        public PersonController(MoviesDBEntities context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetPerson()
        {
            return await _context.People
                .Select(x => new PersonDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Type = x.Type,
                    DateOfBirth = x.DateOfBirth,
                    DateOfDeath = x.DateOfDeath,
                    Sex = x.Sex,
                    CountryId = x.Country.Id
                }).ToListAsync();
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<ActionResult<PersonDTO>> GetMovie(int id)
        {
            var personDTO = await _context.People
                .Where(x => x.Id == id)
                .Select(x => new PersonDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Type = x.Type,
                    DateOfBirth = x.DateOfBirth,
                    DateOfDeath = x.DateOfDeath,
                    Sex = x.Sex,
                    CountryId = x.Country.Id
                }).FirstOrDefaultAsync();
            if (personDTO == null)
            {
                return NotFound();
            }
            return personDTO;
        }
    }
}
