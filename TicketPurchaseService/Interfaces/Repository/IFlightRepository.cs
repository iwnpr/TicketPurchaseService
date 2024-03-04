using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Data.Enumerations;

namespace TicketsPurchaseService.Interfaces.Repository
{
    public interface IFlightRepository
    {
        bool AddFlight(Cities from, Cities to, DateTime dateAndTimeOfDeparture, TimeOnly TravelTime, Guid PlaneId);
        bool RemoveFlightById(Guid flightId);
        bool UpdateFlightById(Guid flightId);
        bool Save();
        IEnumerable<Flight> GetAllFlights();
        Flight GetById(Guid id);
    }
}
