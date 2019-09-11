using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApp1.Models
{
    public class Registration
    {
        //public string UserID { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IPAddress { get; set; }

        public string Department { get; set; }


    }
}