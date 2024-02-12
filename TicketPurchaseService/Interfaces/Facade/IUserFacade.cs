using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsPurchaseService.Data.Entites;

namespace TicketsPurchaseService.Interfaces.Facade
{
    public interface IUserFacade
    {
        void AddUser(string name);
        void RemoveUserById(Guid buyerId);
        IEnumerable<User> GetAllUsers();
    }
}
