using Shop.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Services.Interfaces
{
    public interface IPurchaseService
    {
        IReadOnlyCollection<Purchase> GetAll();

        Purchase GetById(int id);

        void DeleteById(int id);

        void Save(Purchase purchase);
    }
}
