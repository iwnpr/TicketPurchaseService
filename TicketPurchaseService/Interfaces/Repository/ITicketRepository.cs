using TicketsPurchaseService.Data.Entites;

namespace TicketsPurchaseService.Interfaces.Repository
{
    public interface ITicketRepository
    {
        Guid AddTicket(string passengerName, Flight flight, Purchase purchase);
        void RemoveTicketById(Guid ticketId);
        void SellTicketById(Guid ticketId);
        void ReturnTicketById(Guid ticketId);
        IEnumerable<Ticket> GetAllTickets();
        IEnumerable<Ticket> GetSoldTickets();
        IEnumerable<Ticket> GetUnsoldTickets();

    }
}
