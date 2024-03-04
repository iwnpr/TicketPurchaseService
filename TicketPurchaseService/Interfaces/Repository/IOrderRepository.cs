using TicketsPurchaseService.Data.Entites;

namespace TicketsPurchaseService.Interfaces.Repository
{
    public interface IOrderRepository
    {
        bool AddOrder(Guid userId, Guid ticketId, int price);
        bool RemoveOrderById(Guid orderId);
        bool UpdateOrderById(Guid userId);
        bool Save();
        IEnumerable<Order> GetAllOrders();
        Order GetById(Guid id);
    }
}
