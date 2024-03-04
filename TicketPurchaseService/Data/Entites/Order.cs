using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketsPurchaseService.Data.Entites
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public float Price { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User? User { get; set; }
        
        public List<Ticket>? Tickets { get; set; }          

    }
}
