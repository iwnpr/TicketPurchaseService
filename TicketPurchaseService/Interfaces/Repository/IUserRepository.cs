using TicketsPurchaseService.Data.Entites;

namespace TicketsPurchaseService.Interfaces.Repository
{
    public interface IUserRepository
    {
        Guid AddUser(string name);
        void RemoveUserById(Guid userId);
        IEnumerable<User> GetAllUsers();
    }
}
