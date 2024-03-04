using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsPurchaseService.Data.Entites;

namespace TicketsPurchaseService.Interfaces.Repository
{
    public interface IBookingRepository
    {
        bool AddBooking(Guid userId, Guid ticketId);
        bool RemoveBookingById(Guid bookingId);
        bool UpdateBookingById(Guid bookingId);
        public bool Save();
        IEnumerable<Booking> GetAllBooking();
        Booking GetById(Guid id);

    }
}
