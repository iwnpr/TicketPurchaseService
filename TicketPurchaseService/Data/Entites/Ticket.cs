using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TicketsPurchaseService.Data.Entites
{
    public class Ticket
    {
        public Ticket(string passengerName)
        {
            IsSelling = false;
            PassengerName = passengerName;
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public string? PassengerName { get; set; }


        [ForeignKey("Flight")]
        public Guid FlightId { get; set; }
        public Flight? Flight { get; set; }                     //билет может содержать только один маршрут


        [ForeignKey("Purchase")]
        public Guid PurchaseId { get; set; }
        public Purchase? Purchase { get; set; }                 //билет может храниться только в одной покупке


        public bool IsSelling { get; private set; }

        public void Sell()
        {
            IsSelling = true;
        }
        public void Return()
        {
            IsSelling = false;
        }
        

        [JsonConstructor]
        public Ticket() { }

    }
}
