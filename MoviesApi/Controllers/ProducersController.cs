using Microsoft.AspNetCore.Mvc;

namespace MoviesApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly ProducersDBEntities _context;

        public ProducersController(ProducersDBEntities context)
        {
            _context = context;
        }

    }
}