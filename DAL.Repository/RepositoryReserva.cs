using DAL.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.DO;

namespace DAL.Repository
{
    public class RepositoryReserva : Repository<data.Reserva>, IRepositoryReserva
    {
        public RepositoryReserva(SolutionDBContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Reserva>> GetAllWithAsAsync()
        {
            return await _db.Reserva
                .Include(m => m.Guia)
                .ToListAsync();
        }

        public async Task<Reserva> GetOneByIdAsAsync(int id)
        {
            return await _db.Reserva
               .Include(m => m.Guia)
               .SingleOrDefaultAsync(m => m.ReservaId == id);
        }

        private SolutionDBContext _db
        {
            get { return dbContext as SolutionDBContext; }
        }
    }
}

