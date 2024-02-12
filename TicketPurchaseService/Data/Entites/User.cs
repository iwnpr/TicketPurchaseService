using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TicketsPurchaseService.Data.Entites
{
    public class User
    {
        public User(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public List<Purchase>? Purchase { get; set; }               //юзер может содержать несколько покупок

        [JsonConstructor]
        public User() { }


    }
}
