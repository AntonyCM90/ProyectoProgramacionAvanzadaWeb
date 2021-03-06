using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class Tour
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
