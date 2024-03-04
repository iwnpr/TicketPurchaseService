using System.Numerics;
using TicketsPurchaseService.Data;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Data.Enumerations;
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

        public bool AddFlight(Cities from, Cities to, DateTime dateAndTimeOfDeparture, TimeOnly travelTime, Guid planeId)
        {
            try
            {
                var flight = new Flight
                {
                    Id = Guid.NewGuid(),
                    Departure = from,
                    Arrival = to,
                    DateAndTimeOfDeparture = dateAndTimeOfDeparture,
                    TravelTime = travelTime,
                    PlaneId = planeId
                };

                _context.Flights.Add(flight);
                Save();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool RemoveFlightById(Guid flightId)
        {
            var flight = _context.Flights.Single(x => x.Id == flightId);

            if (flight != null)
            {
                _context.Flights.Remove(flight);
                Save();

                return true;
            }

            return false;
        }
        public bool UpdateFlightById(Guid flightId)
        {
            var flight = _context.Flights.Single(x => x.Id == flightId);

            if (flight != null)
            {
                _context.Update(flight);
                return Save();
            }

            return false;
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0;
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return _context.Flights;
        }

        public Flight GetById(Guid id)
        {
            var flight = _context.Flights.Single(x => x.Id == id);

            return flight;

        }

    }
}
