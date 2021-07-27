using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioTotal { get; set; }
        public int CantPersonas { get; set; }
        public string Estado { get; set; }
        public int UserId { get; set; }

        public virtual Guia Guia { get; set; }
    }
}
