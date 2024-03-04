using System.ComponentModel.DataAnnotations;

namespace TicketsPurchaseService.Data.Entites
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        private int _age;

        private const int MIN_AGE = 18;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= MIN_AGE)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public string? PhoneNumber { get; set; }

        public List<Order>? Orders { get; set; }
        public List<Booking>? Bookings { get; set; }

    }
}
