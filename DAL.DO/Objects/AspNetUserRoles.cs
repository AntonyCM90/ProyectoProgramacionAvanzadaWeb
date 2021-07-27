using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class AspNetUserRoles
    {
        public int UserId { get; set; }
        public int RolId { get; set; }

        public virtual AspNetRoles Rol { get; set; }
        //public virtual AspNetUsers User { get; set; }
    }
}
