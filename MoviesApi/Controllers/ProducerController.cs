using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.AccessLayer;
using MoviesApi.Model;
using MoviesApi.Model.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly MoviesDBEntities _context;


        public ProducersController(MoviesDBEntities context)
        {
            _context = context;

        }

        [HttpGet]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ProducerDTO>> GetProducer(int id)
        {
            var producerDTO = await _context.Producers
                .Where(x => x.Id == id)
                .Select(x => new ProducerDTO
                {
                    Id = x.Id,
                    CompanyName = x.CompanyName,
                    YearEstablished = x.YearEstablished,
                    EstimatedCompanyValue = x.EstimatedCompanyValue,
                    CountryId = x.Country.Id
                }).FirstOrDefaultAsync();

            if (producerDTO == null)
            {
                return NotFound();
            }
            return producerDTO;
        }

        [HttpPost]
        public async Task<ActionResult<ProducerDTO>> PostProducer(ProducerDTO producerDTO)
        {
            Country country = await _context.Countries.FindAsync(producerDTO.CountryId);

            Producer producer = new Producer
            {
                CompanyName = producerDTO.CompanyName,
                YearEstablished = producerDTO.YearEstablished,
                EstimatedCompanyValue = producerDTO.EstimatedCompanyValue,
                Country = country

            };


            _context.Producers.Add(producer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProducer), new { id = producerDTO.Id }, producerDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProducer(int id, ProducerDTO producerDTO)
        {
            if (id != producerDTO.Id)
            {
                return BadRequest();
            }
            Producer producer = await _context.Producers.FindAsync(id);

            Country country = await _context.Countries.FindAsync(producerDTO.CountryId);

            producer.CompanyName = producerDTO.CompanyName;
            producer.YearEstablished = producerDTO.YearEstablished;
            producer.EstimatedCompanyValue = producerDTO.EstimatedCompanyValue;
            producer.Country = country;

            _context.Entry(producer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProducer(int id)
        {
            Producer producer = _context.Producers.Find(id);
            if (producer == null)
            {
                return NotFound();
            }
            _context.Producers.Remove(producer);
            await _context.SaveChangesAsync();
            return NoContent();
        }




    }
}