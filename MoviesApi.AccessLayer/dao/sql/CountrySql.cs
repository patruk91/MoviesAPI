using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Model;
using MoviesApi.Model.DTO;

namespace MoviesApi.AccessLayer.dao.sql
{
    public class CountrySql : ICountryDao
    {
        private readonly MoviesDBEntities _context;

        public CountrySql(MoviesDBEntities context)
        {
            _context = context;
        }

        public async Task<Country> GetCountry(int countryId)
        {
            return await _context.Countries.FindAsync(countryId);

        }
    }
}
