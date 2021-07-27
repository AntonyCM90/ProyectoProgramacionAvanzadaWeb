using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Tour : ICRUD<data.Tour>
    {
        private SolutionDBContext context;

        public Tour(SolutionDBContext _context)
        {
            context = _context;
        }
        public void Delete(data.Tour t)
        {
            new DAL.Tour(context).Delete(t);
        }

        public IEnumerable<data.Tour> GetAll()
        {
            return new DAL.Tour(context).GetAll();
        }

        public async Task<IEnumerable<data.Tour>> GetAllWithAsync()
        {
            return await new DAL.Tour(context).GetAllWithAsync();
        }

        public data.Tour GetOneByID(int id)
        {
            return new DAL.Tour(context).GetOneByID(id);
        }

        public async Task<data.Tour> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Tour(context).GetOneByIdWithAsync(id);
        }

        public void Insert(data.Tour t)
        {
            new DAL.Tour(context).Insert(t);
        }

        public void Update(data.Tour t)
        {
            new DAL.Tour(context).Update(t);
        }
    }
}