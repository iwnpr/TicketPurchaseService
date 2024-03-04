using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Data.Enumerations;

namespace TicketsPurchaseService.Interfaces.Repository
{
    public interface ISeatRepository
    {
        bool AddSeat(Class seatClass, int row, char location);
        bool RemoveSeatByRowAndLocation(int row, char location);
        bool UpdateSeatByRowAndLocation(int row, char location);
        public bool Save();
        IEnumerable<Seat> GetAllSeats();
        Seat GetByRowAndLocation(int row, char location);



    }
}
