using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.EF;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        private readonly IMapper _mapper;

        public ToursController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Foci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Tour>>> GetTour()
        {
            var res = await new BS.Tour(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Tour>, IEnumerable<DataModels.Tour>>(res).ToList();

            return mapaux;

        }

        // GET: api/Foci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Tour>> GetTour(int id)
        {
            var tour = await new BS.Tour(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Tour, DataModels.Tour>(tour);
            if (tour == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Foci/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(int id, DataModels.Tour tour)
        {
            if (id != tour.TourId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Tour, data.Tour>(tour);
                new BS.Tour(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!TourExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Foci
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Tour>> PostTour(DataModels.Tour tour)
        {
            var mapaux = _mapper.Map<DataModels.Tour, data.Tour>(tour);
            new BS.Tour(_context).Insert(mapaux);
            return CreatedAtAction("GetFoci", new { id = tour.TourId }, tour);
        }

        // DELETE: api/Foci/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Tour>> DeleteTour(int id)
        {
            var tour = new BS.Tour(_context).GetOneByID(id);
            if (tour == null)
            {
                return NotFound();
            }

            new BS.Tour(_context).Delete(tour);
            var mapaux = _mapper.Map<data.Tour, DataModels.Tour>(tour);
            return mapaux;
        }

        private bool TourExists(int id)
        {
            return (new BS.Tour(_context).GetOneByID(id) != null);
        }
    }
}
