using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Data;

namespace TicketsPurchaseService.Interfaces.Repository
{
    public interface IFlightRepository
    {
        Guid AddFlight(Cities from, Cities to, DateTime dateAndTime);
        void RemoveFlightById(Guid flightId);
        IEnumerable<Flight> GetAllFlights();
    }
}
