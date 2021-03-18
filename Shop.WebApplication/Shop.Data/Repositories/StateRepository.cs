using Shop.Data.DataContext.Realization.MsSql;
using Shop.Shared.Entities;
using System.Collections.Generic;
using Shop.Data.Repositories.Interfaces;
using Shop.Data.DataContext.Interfaces;

namespace Shop.Data.Repositories
{
    public class StateRepository : IProductDetailsRepository<State>
    {
        IProductDetailsContext<State> _stateContext;

        public StateRepository(IProductDetailsContext<State> state)
        {
            _stateContext = state;
        }

        public void DeleteById(int id)
        {
            _stateContext.DeleteById(id);
        }

        public IReadOnlyCollection<State> GetAll()
        {
            return _stateContext.GetAll();
        }

        public State GetById(int id)
        {
            return _stateContext.GetById(id);
        }

        public void Save(State state)
        {
            _stateContext.Save(state);
        }
    }
}
