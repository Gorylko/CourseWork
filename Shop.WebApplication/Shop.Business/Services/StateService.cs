using Shop.Data.DataContext.Realization.MsSql;
using Shop.Data.Repositories;
using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Business.Services
{
    public class StateService 
    {
        StateRepository _stateRepository = new StateRepository(new StateContext()); 

        public IReadOnlyCollection<State> GetAll()
        {
            return _stateRepository.GetAll();
        }
    }
}
