using Shop.Data.DataContext.Interfaces;
using Shop.Data.Repositories.Interfaces;
using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Data.Repositories
{
    public class PurchaseRepository : IRepository<Purchase>
    {
        IDataContext<Purchase> _purchaseContext;

        public PurchaseRepository(IDataContext<Purchase> categoryContext)
        {
            this._purchaseContext = categoryContext;
        }

        public IReadOnlyCollection<Purchase> GetAll()
        {
            return _purchaseContext.GetAll();
        }

        public Purchase GetById(int id)
        {
            return _purchaseContext.GetById(id);
        }

        public void DeleteById(int id)
        {
            _purchaseContext.DeleteById(id);
        }

        public void Save(Purchase purchase)
        {
            _purchaseContext.Save(purchase);
        }
    }
}
