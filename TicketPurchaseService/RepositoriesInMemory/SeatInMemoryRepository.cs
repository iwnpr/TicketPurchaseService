using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Data.Enumerations;
using TicketsPurchaseService.Interfaces.Repository;

namespace TicketsPurchaseService.RepositoriesInMemory
{
    public class SeatInMemoryRepository : ISeatRepository
    {
        public SeatInMemoryRepository()
        {
            Users = new List<User>();
        }
        public List<User> Users { get; }

        public bool AddSeat(Class seatClass, int row, char location)
        {
            return true;
        }

        public IEnumerable<Seat> GetAllSeats()
        {
            throw new NotImplementedException();
        }

        public Seat GetByRowAndLocation(int row, char location)
        {
            throw new NotImplementedException();
        }

        public bool RemoveSeatByRowAndLocation(int row, char location)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateSeatByRowAndLocation(int row, char location)
        {
            throw new NotImplementedException();
        }
    }
}
