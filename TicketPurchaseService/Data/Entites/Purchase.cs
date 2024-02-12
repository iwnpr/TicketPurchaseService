using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketsPurchaseService.Data.Entites
{
    public class Purchase
    {
        public Purchase()
        {
            Id = Guid.NewGuid();    
        }

        [Key]
        public Guid Id { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User? User { get; set; }                     //каждая покупка может сожержать только одного юзера

        public List<Ticket>? Tickets { get; set; }          //одна покупка может содержать несколько билетов

    }
}
