using TicketsPurchaseService.Data.Entites;

namespace TicketsPurchaseService.Interfaces.Repository
{
    public interface IUserRepository
    {
        bool AddUser(string login, string password, string email, int age, string phoneNumber);
        bool RemoveUserById(Guid userId);
        bool UpdateUserById(Guid userId);
        bool Save();
        IEnumerable<User> GetAllUsers();
        User GetById(Guid id);
    }
}
