using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class AspNetUsers
    {
        public AspNetUsers()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}

