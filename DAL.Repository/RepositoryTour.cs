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
    public class RepositoryTour : Repository<data.Tour>, IRepositoryTour
    {
        public RepositoryTour(SolutionDBContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Tour>> GetAllWithAsAsync()
        {
            return await _db.Tour
                .Include(m => m.GuiaId)
                .ToListAsync();
        }

        public async Task<Tour> GetOneByIdAsAsync(int id)
        {
            return await _db.Tour
               .Include(m => m.GuiaId)
               .SingleOrDefaultAsync(m => m.TourId == id);
        }

        private SolutionDBContext _db
        {
            get { return dbContext as SolutionDBContext; }
        }
    }
}
