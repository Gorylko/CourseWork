using System.Collections.Generic;
using Shop.Shared.Entities;
using Shop.Data.Repositories;
using Shop.Data.DataContext.Realization.MsSql;

namespace Shop.Business.Services
{
    class PurchaseService
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository(new PurchaseContext());

        public IReadOnlyCollection<Purchase> GetAll()
        {
            return _purchaseRepository.GetAll();
        }

        public Purchase GetById(int id)
        {
            return _purchaseRepository.GetById(id);
        }

        public void DeleteById(int id)
        {
            _purchaseRepository.DeleteById(id);
        }

        public void Save(Purchase purchase)
        {
            _purchaseRepository.Save(purchase);
        }
    }
}
