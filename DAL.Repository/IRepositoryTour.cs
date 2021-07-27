using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryTour : IRepository<data.Tour>
    {
        Task<IEnumerable<data.Tour>> GetAllWithAsAsync();
        Task<data.Tour> GetOneByIdAsAsync(int id);
    }
}
