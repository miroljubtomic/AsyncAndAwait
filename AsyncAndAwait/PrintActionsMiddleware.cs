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

        public delegate int del1(int a);

        public delegate del1 del2(string s);

        public static del1 vratiDelegat()
        {
            return (int a) =>
            {
                return a;
            };
        }

        public static del2 vratiDel2()
        {
            return (string s) => (int a) =>
            {
                return a;
            };
        }

        public static Func<string, int> vratiDel3()
        {
            return (string a) =>
            {
                return 1;
            };
        }

        public static Func<Func<IAction, IAction>, Func<IAction, IAction>> PrintActions1<TState>(IStore<TState> store)
        {
            return (Func<IAction, IAction> next) => (IAction action) =>
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
