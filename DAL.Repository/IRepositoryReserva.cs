using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryReserva : IRepository<data.Reserva>
    {
        Task<IEnumerable<data.Reserva>> GetAllWithAsAsync();
        Task<data.Reserva> GetOneByIdAsAsync(int id);
    }
}
