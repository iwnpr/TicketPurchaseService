using TicketsPurchaseService.Data;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Interfaces.Repository;

namespace TicketsPurchaseService.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly TicketsPurchaseServiceDbContext _context;
        public PurchaseRepository()
        {
            _context = new TicketsPurchaseServiceDbContext();
        }

        public Guid AddPurchase(User user)
        {
            var purchase = new Purchase { User = user };

            _context.Add(purchase);
            _context.SaveChanges();

            return purchase.Id;
        }

        public void RemovePurchaseById(Guid purchaseId)
        {
            var purchase = _context.Purchases.Single(p => p.Id == purchaseId);

            if (purchase != null)
            {
                _context.Purchases.Remove(purchase);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Purchase> GetAllPurchases()
        {
            return _context.Purchases;
        }

    }
}
