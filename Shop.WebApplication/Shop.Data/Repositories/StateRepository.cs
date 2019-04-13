using Shop.Data.DataContext.Realization.MsSql;
using Shop.Shared.Entities;
using System.Collections.Generic;

namespace Shop.Data.Repositories
{
    public class StateRepository //реализовать интерфейс
    {
        StateContext _stateContext = new StateContext();
        public IReadOnlyCollection<State> GetAll()
        {
            return _stateContext.GetAll();
        }
    }
}
