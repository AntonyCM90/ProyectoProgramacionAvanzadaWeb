using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Reserva : ICRUD<data.Reserva>
    {
    private SolutionDBContext context;

    public Reserva(SolutionDBContext _context)
    {
        context = _context;
    }
    public void Delete(data.Reserva t)
    {
        new DAL.Reserva(context).Delete(t);
    }

    public IEnumerable<data.Reserva> GetAll()
    {
        return new DAL.Reserva(context).GetAll();
    }

    public async Task<IEnumerable<data.Reserva>> GetAllWithAsync()
    {
        return await new DAL.Reserva(context).GetAllWithAsync();
    }

    public data.Reserva GetOneByID(int id)
    {
        return new DAL.Reserva(context).GetOneByID(id);
    }

    public async Task<data.Reserva> GetOneByIdWithAsync(int id)
    {
        return await new DAL.Reserva(context).GetOneByIdWithAsync(id);
    }

    public void Insert(data.Reserva t)
    {
        new DAL.Reserva(context).Insert(t);
    }

    public void Update(data.Reserva t)
    {
        new DAL.Reserva(context).Update(t);
    }
}
}
