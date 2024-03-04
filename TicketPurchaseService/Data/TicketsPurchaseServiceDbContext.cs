using Microsoft.EntityFrameworkCore;
using TicketsPurchaseService.Data.Entites;

namespace TicketsPurchaseService.Data
{
    public class TicketsPurchaseServiceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Seat> Seats { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-RL8A6KJ; Initial Catalog=TicketsPurchaseDb; Integrated Security=True; Connect Timeout=30 ;Encrypt=True; Trust Server Certificate=True; Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().Property(f => f.Departure).HasConversion<string>();
            modelBuilder.Entity<Flight>().Property(f => f.Arrival).HasConversion<string>();

            modelBuilder.Entity<Seat>().HasKey(x => new { x.Row, x.Location });       
        }
    }
}
