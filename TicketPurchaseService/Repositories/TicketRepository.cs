using TicketsPurchaseService.Data;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Interfaces.Repository;

namespace TicketsPurchaseService.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketsPurchaseServiceDbContext _context;

        public TicketRepository()
        {
            _context = new TicketsPurchaseServiceDbContext();
        }

        public Guid AddTicket(string passengerName, Flight flight, Purchase purchase)
        {
            var ticket = new Ticket { PassengerName = passengerName, Flight = flight, Purchase = purchase };

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return ticket.Id;
        }

        public void RemoveTicketById(Guid ticketId)
        {
            var ticket = _context.Tickets.Single(x => x.Id == ticketId);

            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                _context.SaveChanges();
            }
        }

        public void ReturnTicketById(Guid ticketId)
        {
            var ticket = _context.Tickets.Single(x => x.Id == ticketId);

            if (ticket.IsSelling == true && ticket != null)
            {
                ticket.Return();
                _context.Tickets.Update(ticket);
                _context.SaveChanges();
            }
        }

        public void SellTicketById(Guid ticketId)
        {
            var ticket = _context.Tickets.Single(x => x.Id == ticketId);

            if (ticket.IsSelling == false && ticket != null)
            {
                ticket.Sell();
                _context.Tickets.Update(ticket);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _context.Tickets;
        }

        public IEnumerable<Ticket> GetSoldTickets()
        {
            var tickets = _context.Tickets.Where(t => t.IsSelling == true);

            return tickets;
        }

        public IEnumerable<Ticket> GetUnsoldTickets()
        {
            var tickets = _context.Tickets.Where(t => t.IsSelling == false);

            return tickets;
        }

    }
}
