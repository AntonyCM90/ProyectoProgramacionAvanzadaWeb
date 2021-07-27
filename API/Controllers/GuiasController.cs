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
    public class GuiasController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public GuiasController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Guia>>> GetGuia()
        {
            var res = new BS.Guia(_context).GetAll();
            var mapaux = _mapper.Map<IEnumerable<data.Guia>, IEnumerable<DataModels.Guia>>(res).ToList();

            return mapaux;
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Guia>> GetGuia(int id)
        {
            var guia = new BS.Guia(_context).GetOneByID(id);
            var mapaux = _mapper.Map<data.Guia, DataModels.Guia>(guia);


            if (guia == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuia(int id, DataModels.Guia guia)
        {
            if (id != guia.GuiaId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<DataModels.Guia, data.Guia>(guia);
                new BS.Guia(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!GuiaExists(id))
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

        // POST: api/Groups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Guia>> PutGuia(DataModels.Guia guia)
        {
            var mapaux = _mapper.Map<DataModels.Guia, data.Guia>(guia);
            new BS.Guia(_context).Insert(mapaux);

            return CreatedAtAction("GetGroups", new { id = guia.GuiaId }, guia);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Guia>> DeleteGuia(int id)
        {
            var guia = new BS.Guia(_context).GetOneByID(id);
            if (guia == null)
            {
                return NotFound();
            }

            new BS.Guia(_context).Delete(guia);
            var mapaux = _mapper.Map<data.Guia, DataModels.Guia>(guia);

            return mapaux;
        }

        private bool GuiaExists(int id)
        {
            return (new BS.Guia(_context).GetOneByID(id) != null);
        }
    }
}
