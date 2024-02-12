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
        private readonly List<User> _users;

        public UserInMemoryRepository()
        {
            _users = new List<User>();
        }

        public Guid AddUser(string name)
        {
            var user = new User(name);
            _users.Add(user);

            return user.Id;
        }
        public void RemoveUserById(Guid userId)
        {
            var user = _users.Single(b => b.Id == userId);

            if (user != null)
            {
                _users.Remove(user);

            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

    }
}
