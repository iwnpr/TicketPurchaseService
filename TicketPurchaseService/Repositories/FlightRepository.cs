using TicketsPurchaseService.Data;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Interfaces.Repository;

namespace TicketsPurchaseService.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly TicketsPurchaseServiceDbContext _context;

        public FlightRepository()
        {
            _context = new TicketsPurchaseServiceDbContext();
        }

        public Guid AddFlight(Cities from, Cities to, DateTime dateAndTime)
        {
            var flight = new Flight(from, to, dateAndTime);

            _context.Flights.Add(flight);
            _context.SaveChanges();

            return flight.Id;
        }

        public void RemoveFlightById(Guid flightId)
        {
            var flight = _context.Flights.Single(x => x.Id == flightId);

            if (flight != null)
            {
                _context.Flights.Remove(flight);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return _context.Flights;
        }

    }
}
