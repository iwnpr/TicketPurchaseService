using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using TicketsPurchaseService.Data.Entites;
using TicketsPurchaseService.Interfaces.Repository;

namespace TicketsPurchaseService.RepositoriesInMemory
{
    public class PurchaseInMemoryRepository : IPurchaseRepository
    {
        private readonly List<Purchase> _purchases;
        public PurchaseInMemoryRepository()
        {
            _purchases = new List<Purchase>();
        }

        public Guid AddPurchase(User user)
        {
            var purchase = new Purchase { User = user };
            _purchases.Add(purchase);

            return purchase.Id;
        }

        public void RemovePurchaseById(Guid purchaseId)
        {
            var purchase = _purchases.Single(b => b.Id == purchaseId);

            if (purchase != null)
            {
                _purchases.Remove(purchase);

            }
        }

        public IEnumerable<Purchase> GetAllPurchases()
        {
            return _purchases;
        }

    }
}
