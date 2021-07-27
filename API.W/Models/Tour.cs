using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Tour
    {
        public int TourId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public byte[] ImagenTour { get; set; }
        public decimal Precio { get; set; }
        public int CantPersonas { get; set; }
        public int GuiaId { get; set; }

        public virtual Guia Guia { get; set; }
    }
}
