using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TicketsPurchaseService.Data.Entites
{
    public class Flight
    {
        public Flight(Cities from, Cities to, DateTime dateAndTime)
        {
            CityFrom = from;
            CityTo = to;
            DateAndTime = dateAndTime;
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Cities? CityFrom { get; set; }
        public Cities? CityTo { get; set; }
        public DateTime? DateAndTime { get; set; }

        public List<Ticket>? Tickets { get; set; }               

        [JsonConstructor]
        public Flight() { }
    }
}
