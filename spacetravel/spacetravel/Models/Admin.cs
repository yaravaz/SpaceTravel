using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetravel.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; } 
        public string Fname { get; set; }
        public string Sname { get; set; }

        public Admin(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
            Fname = string.Empty;
            Sname = string.Empty;
        }
    }
}
