using Microsoft.AspNetCore.Mvc;
using MoviesApi.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi.AccessLayer.dao
{
    public interface IProducerDao
    {
        Task<ActionResult<ProducerDTO>> GetProducer(int id);
        Task<ActionResult<IEnumerable<ProducerDTO>>> GetProducers();
    }
}
