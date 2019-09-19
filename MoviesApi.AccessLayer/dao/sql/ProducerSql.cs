using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Model;
using MoviesApi.Model.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.AccessLayer.dao.sql
{

    public class ProducerSql : IProducerDao
    {
        private readonly MoviesDBEntities _context;


        public ProducerSql(MoviesDBEntities context)
        {
            _context = context;
        }


        public async Task<ActionResult<ProducerDTO>> GetProducer(int id)
        {
            return await _context.Producers
                .Where(x => x.Id == id)
                .Select(x => new ProducerDTO
                {
                    Id = x.Id,
                    CompanyName = x.CompanyName,
                    YearEstablished = x.YearEstablished,
                    EstimatedCompanyValue = x.EstimatedCompanyValue,
                    CountryId = x.Country.Id

                }).FirstOrDefaultAsync();
        }

        public async Task<ActionResult<IEnumerable<ProducerDTO>>> GetProducers()
        {
            return await _context.Producers
                .Select(x => new ProducerDTO
                {
                    Id = x.Id,
                    CompanyName = x.CompanyName,
                    YearEstablished = x.YearEstablished,
                    EstimatedCompanyValue = x.EstimatedCompanyValue,
                    CountryId = x.Country.Id

                }).ToListAsync();
        }
    }
}
