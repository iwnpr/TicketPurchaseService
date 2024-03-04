using TicketsPurchaseService.Data;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Data.Enumerations;
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

        public bool AddTicket(string firstName, string lastName, Genders gender, int age, IdDocuments idDocument, int row, char location, Guid flightId)
        {
            try
            {
                var flight = _context.Flights.Single(x => x.Id == flightId);
                var seat = flight.Plane.Seats.Single(y => y.Row == row && y.Location == location);

                var ticket = new Ticket
                {
                    Id = Guid.NewGuid(),
                    PassengerFirstName = firstName,
                    PassengerLastName = lastName,
                    PassengerGender = gender,
                    PassengerAge = age,
                    IdDocument = idDocument,
                    Seat = seat,
                    FlightId = flightId
                };

                _context.Tickets.Add(ticket);
                Save();
                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool RemoveTicketById(Guid ticketId)
        {
            var ticket = _context.Tickets.Single(x => x.Id == ticketId);

            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                Save();

                return true;
            }

            return false;
        }

        public bool SellTicketById(Guid ticketId)
        {
            var ticket = _context.Tickets.Single(p => p.Id == ticketId).ToSell();

            return ticket;
        }

        public bool ReturnTicketById(Guid ticketId)
        {
            var ticket = _context.Tickets.Single(p => p.Id == ticketId).Return();

            return ticket;
        }

        public bool ToBookTicketById(Guid ticketId)
        {
            var ticket = _context.Tickets.Single(p => p.Id == ticketId).ToBook();

            return ticket;
        }

        public bool AnnulBookingById(Guid ticketId)
        {
            var ticket = _context.Tickets.Single(p => p.Id == ticketId).AnnulBooking();

            return ticket;
        }

        public Ticket GetTicketById(Guid ticketId)
        {
            return _context.Tickets.SingleOrDefault(x => x.Id == ticketId);
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _context.Tickets.ToList();
        }

        public IEnumerable<Ticket> GetBookedTickets()
        {
            return _context.Tickets.Where(x => x.IsBooking == true);
        }

        public IEnumerable<Ticket> GetUnbookingTickets()
        {
            return _context.Tickets.Where(x => x.IsBooking == false);
        }

        public IEnumerable<Ticket> GetSoldTickets()
        {
            return _context.Tickets.Where(x => x.IsSelling == true);
        }

        public IEnumerable<Ticket> GetUnsoldTickets()
        {
            return _context.Tickets.Where(x => x.IsSelling == false);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0;
        }

    }
}
