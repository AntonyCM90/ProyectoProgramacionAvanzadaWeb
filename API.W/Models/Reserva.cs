using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Reserva
    {
        public int ReservaId { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioTotal { get; set; }
        public int CantPersonas { get; set; }
        public string Estado { get; set; }
        public int UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
