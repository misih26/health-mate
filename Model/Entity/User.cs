using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class User
    {

        [Key]
        public string Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        public User() { }

        public User(string username, string passwordHash, string role)
        {
            Id = Guid.NewGuid().ToString();
            Username = username;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}
