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

                _context.Users.Add(user);
                Save();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool RemoveUserById(Guid userId)
        {
            var user = _context.Users.Single(x => x.Id == userId);

            if (user != null)
            {
                _context.Users.Remove(user);
                Save();

                return true;
            }

            return false;
        }

        public bool UpdateUserById(Guid userId)
        {
            var user = _context.Users.Single(x => x.Id == userId);

            if (user != null)
            {
                _context.Update(user);
                return Save();
            }

            return false;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetById(Guid id)
        {
            var user = _context.Users.Single(x => x.Id == id);

            if (user != null)
            {
                return user;
            }

            return null;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0;
        }

    }
}
