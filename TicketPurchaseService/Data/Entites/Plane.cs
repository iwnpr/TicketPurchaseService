using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsPurchaseService.Data.Entites
{
    public class Plane
    {
        [Key]
        public Guid Id { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public Flight? Flight { get; set; }
        public List<Seat>? Seats { get; set; }
        


    }
}
