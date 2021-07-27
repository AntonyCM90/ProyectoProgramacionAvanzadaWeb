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
    public class ReservasController : ControllerBase
    {
        private readonly SolutionDBContext _context;

        private readonly IMapper _mapper;

        public ReservasController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Foci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Reserva>>> GetReserva()
        {
            var res = await new BS.Reserva(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Reserva>, IEnumerable<DataModels.Reserva>>(res).ToList();

            return mapaux;

        }

        // GET: api/Foci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Reserva>> GetReserva(int id)
        {
            var reserva = await new BS.Reserva(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Reserva, DataModels.Reserva>(reserva);
            if (reserva == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Foci/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, DataModels.Reserva reserva)
        {
            if (id != reserva.ReservaId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Reserva, data.Reserva>(reserva);
                new BS.Reserva(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ReservaExists(id))
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
        public async Task<ActionResult<DataModels.Reserva>> PostReserva(DataModels.Reserva reserva)
        {
            var mapaux = _mapper.Map<DataModels.Reserva, data.Reserva>(reserva);
            new BS.Reserva(_context).Insert(mapaux);
            return CreatedAtAction("GetFoci", new { id = reserva.ReservaId }, reserva);
        }

        // DELETE: api/Foci/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Reserva>> DeleteReserva(int id)
        {
            var reserva = new BS.Reserva(_context).GetOneByID(id);
            if (reserva == null)
            {
                return NotFound();
            }

            new BS.Reserva(_context).Delete(reserva);
            var mapaux = _mapper.Map<data.Reserva, DataModels.Reserva>(reserva);
            return mapaux;
        }

        private bool ReservaExists(int id)
        {
            return (new BS.Reserva(_context).GetOneByID(id) != null);
        }
    }
}
