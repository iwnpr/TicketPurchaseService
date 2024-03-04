using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsPurchaseService.Data;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Data.Enumerations;
using TicketsPurchaseService.Interfaces.Repository;

namespace TicketsPurchaseService.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly TicketsPurchaseServiceDbContext _context;
        public SeatRepository()
        {
            _context = new TicketsPurchaseServiceDbContext();
        }

        public bool AddSeat(Class seatClass, int row, char location)
        {
            try
            {
                var seat = new Seat
                {
                    SeatClass = seatClass,
                    Row = row,
                    Location = location
                };

                _context.Seats.Add(seat);
                Save();

                return true;

            }
            catch 
            {
                return false;
            }
        }

        public IEnumerable<Seat> GetAllSeats()
        {
            return _context.Seats.ToList();
        }

        public Seat GetByRowAndLocation(int row, char location)
        {
            var seat = _context.Seats.Single(x => x.Row == row && x.Location == location);
            
            return seat;
        }

        public bool RemoveSeatByRowAndLocation(int row, char location)
        {
            var seat = _context.Seats.Single(x => x.Row == row && x.Location == location);

            if (seat != null)
            {
                _context.Seats.Remove(seat);
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

        public bool UpdateSeatByRowAndLocation(int row, char location)
        {
            var seat = _context.Seats.Single(x => x.Row == row && x.Location == location);

            if (seat != null)
            {
                _context.Update(seat);

                return Save();
            }

            return false;
        }
    }
}
