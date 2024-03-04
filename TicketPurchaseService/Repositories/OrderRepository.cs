using TicketsPurchaseService.Data;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Interfaces.Repository;

namespace TicketsPurchaseService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TicketsPurchaseServiceDbContext _context;
        public OrderRepository()
        {
            _context = new TicketsPurchaseServiceDbContext();
        }

        public bool AddOrder(Guid userId, Guid ticketId, int price)
        {
            var user = _context.Users.Single(x => x.Id == userId);
            var ticket = _context.Tickets.Single(x => x.Id == ticketId);

            if (user != null && ticket == null)
            {
                try
                {
                    var order = new Order
                    {
                        Id = Guid.NewGuid(),
                        Price = price,
                        User = user
                    };
                    ticket.ToSell();
                    order.Tickets.Add(ticket);

                    _context.Add(order);
                    Save();

                    return true;
                }
                catch
                {
                    return false;
                }

            }

            return false;
        }

        public bool RemoveOrderById(Guid orderId)
        {
            var order = _context.Orders.Single(p => p.Id == orderId);

            if (order != null)
            {
                _context.Orders.Remove(order);
                Save();

                return true;
            }

            return false;
        }
        public bool UpdateOrderById(Guid orderId)
        {
            var order = _context.Orders.Single(x => x.Id == orderId);

            if (order != null)
            {
                _context.Update(order);
                return Save();
            }

            return false;
        }
        public Order? GetById(Guid id)
        {
            var order = _context.Orders.Single(x => x.Id == id);

            if (order != null)
            {
                return order;
            }

            return null;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0;
        }
    }
}
