using Microsoft.EntityFrameworkCore;
using TicketsPurchaseService.Data.Entites;

namespace TicketsPurchaseService.Data
{
    public class TicketsPurchaseServiceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-RL8A6KJ; Initial Catalog=TicketsPurchaseDb; Integrated Security=True; Connect Timeout=30 ;Encrypt=True; Trust Server Certificate=True; Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().Property(f => f.CityFrom).HasConversion<string>();
            modelBuilder.Entity<Flight>().Property(f => f.CityTo).HasConversion<string>();
        }
    }
}
