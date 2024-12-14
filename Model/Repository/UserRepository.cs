using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Model.Repository
{
    public class UserRepository
    {
        HealthMateDbContext HealthMateDbContext { get; }

        public UserRepository(HealthMateDbContext healthMateDbContext)
        {
            HealthMateDbContext = healthMateDbContext;
        }

        public User GetUserByNameAndPassword(string userName, string hashedPassword)
        {
            User user = HealthMateDbContext.Users
                .Where(u => u.Username == userName /*&& BCrypt.Net.BCrypt.Verify(hashedPassword , u.PasswordHash)*/)
                .FirstOrDefault();

            if ( user != null && BCrypt.Net.BCrypt.Verify(hashedPassword, user.PasswordHash)) {
                return user;
            } else
            {
                return null;
            }
        }

        public List<User> GetAllUsers()
        {
            return HealthMateDbContext.Users.ToList();
        }

        public bool SaveUser(User user)
        {
            HealthMateDbContext.Users.Add(user);
            HealthMateDbContext.SaveChanges();

            return true;
        }

        public bool DeleteUser(string userId)
        {
            User user = HealthMateDbContext.Users.Where(u => u.Id == userId ).FirstOrDefault();
            HealthMateDbContext.Users.Remove(user);
            HealthMateDbContext.SaveChanges();


            return true;
        }

        public bool ModifyUser(User user)
        {
            HealthMateDbContext.SaveChanges();

            return true;

        }

        public User GetUserById(string id) 
        {
            return HealthMateDbContext.Users.FirstOrDefault(u => u.Id == id); 
        }
    }
}
