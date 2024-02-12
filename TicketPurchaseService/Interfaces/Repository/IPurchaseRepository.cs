using TicketsPurchaseService.Data.Entites;

namespace TicketsPurchaseService.Interfaces.Repository
{
    public interface IPurchaseRepository
    {
        Guid AddPurchase(User user);
        void RemovePurchaseById(Guid purchaseId);
        IEnumerable<Purchase> GetAllPurchases();
    }
}
