using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Interfaces.Repository;

namespace TicketsPurchaseService.RepositoriesInMemory
{
    public class TicketInMemoryRepository : ITicketRepository
    {
        private readonly List<Ticket> _tickets;

        public TicketInMemoryRepository()
        {
            _tickets = new List<Ticket>();
        }

        public Guid AddTicket(string passengerName, Flight flight, Purchase purchase)
        {
            var ticket = new Ticket { PassengerName = passengerName, Flight = flight, Purchase = purchase };
            _tickets.Add(ticket);

            return ticket.Id;

        }

        public void RemoveTicketById(Guid ticketId)
        {
            var ticket = _tickets.Single(p => p.Id == ticketId);

            if (ticket != null)
            {
                _tickets.Remove(ticket);
            }
        }

        public void ReturnTicketById(Guid ticketId)
        {
            var ticket = _tickets.Single(x => x.Id == ticketId);

            if (ticket.IsSelling == true && ticket != null)
                ticket.Return();
        }

        public void SellTicketById(Guid ticketId)
        {
            var ticket = _tickets.Single(x => x.Id == ticketId);

            if (ticket.IsSelling == false && ticket != null)
                ticket.Sell(); 
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _tickets;
        }

        public IEnumerable<Ticket> GetSoldTickets()
        {
            return _tickets.Where(x => x.IsSelling == true);
        }

        public IEnumerable<Ticket> GetUnsoldTickets()
        {
            return _tickets.Where(x => x.IsSelling == false);
        }

    }
}
