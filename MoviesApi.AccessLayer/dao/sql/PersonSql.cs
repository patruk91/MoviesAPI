using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Model;

namespace MoviesApi.AccessLayer.dao.sql
{
    public class PersonSql : IPersonDao
    {
        private readonly MoviesDBEntities _context;

        public PersonSql(MoviesDBEntities context)
        {
            _context = context;
        }

        public async Task<Person> GetPerson(int id)
        {
            return await _context.People.FindAsync(id);
        }
    }
}
