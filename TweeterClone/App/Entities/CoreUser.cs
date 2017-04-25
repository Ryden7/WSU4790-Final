using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TweeterClone.App.Entities
{
    public class CoreUser
    {
        [Key]
        public string Username { get; set; }
        private string Password { get; set; }
        private string Email { get; set; }

        public CoreUser(String username, String Password, string Email)
        {
            this.Username = username;
            this.Password = Password;
            this.Email = Email;
        }

    }

 
}
