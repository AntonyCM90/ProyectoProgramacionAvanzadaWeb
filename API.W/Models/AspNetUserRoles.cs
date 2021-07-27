using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class AspNetUserRoles
    {
        public int UserId { get; set; }
        public int RolId { get; set; }

        public virtual AspNetRoles Rol { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
