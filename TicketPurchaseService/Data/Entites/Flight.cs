using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketsPurchaseService.Data.Enumerations;

namespace TicketsPurchaseService.Data.Entites
{
    public class Flight
    {
        [Key]
        public Guid Id { get; set; }

        public Cities? Departure { get; set; }

        public Cities? Arrival { get; set; }

        public DateTime DateAndTimeOfDeparture { get; set; }

        public DateTime DateAndTimeOfArrival { get; set; }

        public TimeOnly TravelTime { get; set; }

        public List<Ticket>? Tickets { get; set;}

        [ForeignKey("Plane")]
        public Guid PlaneId { get; set; }
        public Plane? Plane { get; set; }
             

    }
}
