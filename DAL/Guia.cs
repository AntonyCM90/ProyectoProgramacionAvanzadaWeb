using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL
{
    public class Guia : ICRUD<data.Guia>
    {
        private Repository<data.Guia> _repo = null;

        public Guia(SolutionDBContext solutionDbContext)
        {
            _repo = new Repository<data.Guia>(solutionDbContext);
        }
        public void Delete(data.Guia t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Guia> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Guia>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Guia GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public Task<data.Guia> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        // Hacer filtro por fechas para obtener data 
        //public IEnumerable<data.Groups> GetbyDate(Expression<Func<T, bool>> predicado)
        //{ 

        //}

        public void Insert(data.Guia t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Guia t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

    }
}
