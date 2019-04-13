using Shop.Data.Repositories;
using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Business.Services
{
    public class StateService //реализовать интерфейс
    {
        StateRepository _stateRepository = new StateRepository(); 

        public IReadOnlyCollection<State> GetAll()
        {
            return _stateRepository.GetAll();
        }
    }
}
