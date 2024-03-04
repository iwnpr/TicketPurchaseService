using System.ComponentModel.DataAnnotations.Schema;
using TicketsPurchaseService.Data.Enumerations;

namespace TicketsPurchaseService.Data.Entites
{
    public class Seat
    {
        public Class SeatClass { get; set; }
        public int Row { get; set; }
        public char Location { get; set; }

        public List<Plane>? Planes { get; set; }

    }
}
