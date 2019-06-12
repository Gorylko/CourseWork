using Shop.Business.Services.Interfaces;
using Shop.Data.DataContext.Realization.MsSql;
using Shop.Data.Repositories;
using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Business.Services
{
    public class PurchaseService : IPurchaseService
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
