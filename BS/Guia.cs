using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Guia : ICRUD<data.Guia>
    {
        private SolutionDBContext context;

        public Guia(SolutionDBContext _context)
        {
            context = _context;
        }
        public void Delete(data.Guia t)
        {
            new DAL.Guia(context).Delete(t);
        }

        public IEnumerable<data.Guia> GetAll()
        {
            return new DAL.Guia(context).GetAll();
        }

        public Task<IEnumerable<data.Guia>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Guia GetOneByID(int id)
        {
            return new DAL.Guia(context).GetOneByID(id);
        }

        public Task<data.Guia> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Guia t)
        {
            new DAL.Guia(context).Insert(t);
        }

        public void Update(data.Guia t)
        {
            new DAL.Guia(context).Update(t);
        }
    }
}
