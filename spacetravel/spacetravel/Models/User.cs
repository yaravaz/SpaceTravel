using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spacetravel.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        //[RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d).{5,15}$", ErrorMessage= "the password must be between 5 and 15 characters long and contain at least one letter and a number")]
        public string Password { get; set; }
        //[EmailAddress(ErrorMessage= "incorrect mail format")]
        public string Email { get; set; }
        //[RegularExpression(@"^[a-zA-Z-]{3,20}$", ErrorMessage= "the name can be from 3 to 20 characters")]
        public string Fname { get; set; }
        //[RegularExpression(@"^[a-zA-Z-]{3,20}$", ErrorMessage = "the surname can be from 3 to 20 characters")]
        public string Sname { get; set; }

        public User(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
            Fname = string.Empty;
            Sname = string.Empty;
        }
    }
}
