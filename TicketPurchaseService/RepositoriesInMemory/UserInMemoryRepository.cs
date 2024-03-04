using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Interfaces.Repository;

namespace TicketsPurchaseService.RepositoriesInMemory
{
    public class UserInMemoryRepository : IUserRepository
    {
        public UserInMemoryRepository()
        {
                Users = new List<User>();
        }

        public List<User> Users { get; }
        public bool AddUser(string login, string password, string email, int age, string phoneNumber)
        {
            try
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Login = login,
                    Password = password,
                    Email = email,
                    Age = age,
                    PhoneNumber = phoneNumber
                };

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Users;
        }

        public User GetById(Guid id)
        {
            var user = Users.Single(x => x.Id == id);
            
            return user;

        }

        public bool RemoveUserById(Guid userId)
        {
            var user = Users.Single(x => x.Id == userId);

            if (user != null)
            {
                Users.Remove(user);

                return true;
            }

            return false;
        }

        public bool Save()
        {
            return true;
        }

        public bool UpdateUserById(Guid userId)
        {
            return true;
        }
    }
}
