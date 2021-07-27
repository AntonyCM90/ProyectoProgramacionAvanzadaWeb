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
    public class Tour : ICRUD<data.Tour>
    { 
    private RepositoryTour _repo = null;

        public Tour(SolutionDBContext solutionDbContext)
        {
            _repo = new RepositoryTour(solutionDbContext);
        }
        public void Delete(data.Tour t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }


        public IEnumerable<data.Tour> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Tour>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public data.Tour GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public async Task<data.Tour> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdAsAsync(id);
        }

        public void Insert(data.Tour t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Tour t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

    }
}
