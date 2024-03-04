using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketsPurchaseService.Data.Enumerations;

namespace TicketsPurchaseService.Data.Entites
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }

        public string PassengerFirstName { get; set; }
        public string PassengerLastName { get; set; }
        public Genders PassengerGender { get; set; }
        public int PassengerAge { get; set; }
        public IdDocuments? IdDocument { get; set; }

        public Seat Seat { get; set; }
        public Booking? Booking { get; set; }
        public Order? Order { get; set; }

        [ForeignKey("Flight")]
        public Guid FlightId { get; set; }
        public Flight Flight { get; set; }

        public bool IsSelling { get;  private set; } = false;
        public bool IsBooking { get;  private set; } = false;

        public bool ToSell()
        {
            if (IsSelling == false) 
            {
                if (IsBooking == true)
                    IsBooking = false;

                IsSelling = true;
                return true;
            }

            return false;
        }
       
        public bool ToBook()
        {
            if (IsBooking == false && IsSelling == false)
            {
                IsBooking = true;

                return true;
            }
            return false;
        }
        
        public bool AnnulBooking()
        {
            if (IsBooking == true)
            {
                IsBooking = false;
                return true;
            }
            return false;
        }
       
        public bool Return()
        {
            if (IsSelling == true)
            {
                IsSelling = false;
                return true;
            }

            return false;
        }

    }
}
