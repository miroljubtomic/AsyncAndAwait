using Redux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    public interface ICompositeAction<TState> : IAction
    {
        void Execute(Dispatcher dispatcher, Func<TState> getState);
    }
}
