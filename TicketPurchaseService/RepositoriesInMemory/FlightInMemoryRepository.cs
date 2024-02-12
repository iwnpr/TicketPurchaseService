using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsPurchaseService.Data;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Interfaces.Repository;

namespace TicketsPurchaseService.RepositoriesInMemory
{
    public class FlightInMemoryRepository : IFlightRepository
    {
        private readonly List<Flight> _flights;
        public FlightInMemoryRepository()
        {
            _flights = new List<Flight>();
        }

        public Guid AddFlight(Cities from, Cities to, DateTime dateAndTime)
        {
            var flight = new Flight(from, to, dateAndTime);

            _flights.Add(flight);

            return flight.Id;
        }

        public void RemoveFlightById(Guid flightId)
        {
            var flight = _flights.Single(p => p.Id == flightId);

            if (flight != null)
            {
                _flights.Remove(flight);
            }
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return _flights;
        }

    }
}
