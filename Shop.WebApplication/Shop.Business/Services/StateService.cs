using Shop.Data.Repositories;
using Shop.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Business.Services
{
    public class StateService
    {
        StateRepository _stateRepository = new StateRepository(); 

        public IReadOnlyCollection<State> GetAll()
        {
            return _stateRepository.GetAll();
        }
    }
}
