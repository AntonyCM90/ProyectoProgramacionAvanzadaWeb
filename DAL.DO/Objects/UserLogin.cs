using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public class UserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public int UserId { get; set; }

        //public virtual AspNetUsers User { get; set; }
    }
}
