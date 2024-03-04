using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsPurchaseService.Data;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Interfaces.Repository;

namespace TicketsPurchaseService.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TicketsPurchaseServiceDbContext _context;
        public BookingRepository()
        {
            _context = new TicketsPurchaseServiceDbContext();
        }

        public bool AddBooking(Guid userId, Guid ticketId)
        {
            var user = _context.Users.Single(x => x.Id == userId);
            var ticket = _context.Tickets.Single(x => x.Id == ticketId);

            if (user != null && ticket == null)
            {
                try
                {
                    var booking = new Booking
                    {
                        Id = Guid.NewGuid(),
                        User = user
                    };

                    ticket.ToBook();
                    booking.Tickets.Add(ticket);

                    _context.Add(booking);
                    Save();

                    return true;
                }
                catch
                {
                    return false;
                }

            }

            return false;
        }

        public IEnumerable<Booking> GetAllBooking()
        {
            return _context.Bookings.ToList();
        }

        public Booking? GetById(Guid id)
        {
            var booking = _context.Bookings.Single(x => x.Id == id);

            if (booking != null)
            {
                return booking;
            }

            return null;
        }

        public bool RemoveBookingById(Guid bookingId)
        {
            var booking = _context.Bookings.Single(x => x.Id == bookingId);

            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                Save();

                return true;
            }

            return false;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0;
        }

        public bool UpdateBookingById(Guid bookingId)
        {
            var booking = _context.Bookings.Single(x => x.Id == bookingId);

            if (booking != null)
            {
                _context.Update(booking);
                return Save();
            }

            return false;
        }
    }
}
