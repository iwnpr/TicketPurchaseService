using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Data;

namespace TicketsPurchaseService.Interfaces.Facade
{
    public interface ITicketFacade
    {
        void AddTicket(string passengerName);
        void RemoveTicketById(Guid ticketId);
        void SellTicketById(Guid ticketId);
        void ReturnTicketById(Guid ticketId);
        IEnumerable<Ticket> GetAllTickets();
        IEnumerable<Ticket> GetSoldTickets();
        IEnumerable<Ticket> GetUnsoldTickets();
    }
}
