using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Data.Enumerations;

namespace TicketsPurchaseService.Interfaces.Repository
{
    public interface ITicketRepository
    {
        bool AddTicket(string passengerFirstName, string passengerLastName, Genders passengerGender, int passengerAge, IdDocuments idDocument, int row, char location, Guid flightId);
        bool RemoveTicketById(Guid ticketId);
        bool SellTicketById(Guid ticketId);
        bool ReturnTicketById(Guid ticketId);
        bool ToBookTicketById(Guid ticketId);
        bool AnnulBookingById(Guid ticketId);
        Ticket GetTicketById(Guid ticketId);
        bool Save();
        IEnumerable<Ticket> GetAllTickets();
        IEnumerable<Ticket> GetSoldTickets();
        IEnumerable<Ticket> GetBookedTickets();
        IEnumerable<Ticket> GetUnbookingTickets();
        IEnumerable<Ticket> GetUnsoldTickets();

    }
}
