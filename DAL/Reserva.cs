using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL
{
    public class Reserva : ICRUD<data.Reserva>
    { 
        private RepositoryReserva _repo = null;

        public Reserva(SolutionDBContext solutionDbContext)
        {
            _repo = new RepositoryReserva(solutionDbContext);
        }
        public void Delete(data.Reserva t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }


        public IEnumerable<data.Reserva> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Reserva>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public data.Reserva GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public async Task<data.Reserva> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdAsAsync(id);
        }

        public void Insert(data.Reserva t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Reserva t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

    }
}
