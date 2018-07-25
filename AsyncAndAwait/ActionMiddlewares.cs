using Redux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    public class ActionMiddlewares
    {
        public static Func<Dispatcher, Dispatcher> CompositeActons<TState>(IStore<TState> store)
        {
            return (Dispatcher next) => (IAction action) =>
            {
                var thunkAction = action as ICompositeAction<TState>;
                if (thunkAction != null)
                {
                    thunkAction.Execute(store.Dispatch, store.GetState);
                    return thunkAction;
                }
                //return action;
                return next(action);
            };
        }

        public static Func<Dispatcher, Dispatcher> PrintActons<TState>(IStore<TState> store)
        {
            return (Dispatcher next) => (IAction action) =>
            {
                if(action is IPrintableAction)
                    Console.WriteLine(((IPrintableAction)action).GetString());
                return next(action);
            };
        }


    }
}
