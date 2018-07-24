using Redux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    public class PrintActionsMiddleware
    {
        public static Func<Dispatcher, Dispatcher> PrintActions<TState>(IStore<TState> store)
        {
            return (Dispatcher next) => (IAction action) =>
            {
                var thunkAction = action as IAsyncAction<TState>;
                if (thunkAction != null)
                {
                    thunkAction.Execute(store);
                    return thunkAction;
                }
                //return action;
                return next(action);
            };
        }
    }
}
