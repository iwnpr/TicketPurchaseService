using TicketsPurchaseService.Data;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Interfaces.Repository;

namespace TicketsPurchaseService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TicketsPurchaseServiceDbContext _context;

        public UserRepository()
        {
            _context = new TicketsPurchaseServiceDbContext();
        }

        public Guid AddUser(string name)
        {
            var user = new User(name);

            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        public void RemoveUserById(Guid userId)
        {
            var user = _context.Users.Single(x => x.Id == userId);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

    }
}
