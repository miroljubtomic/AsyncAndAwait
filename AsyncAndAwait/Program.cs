using Redux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class Program
    {
        public static IStore<AppState> Store = null;
        static void Main(string[] args)
        {

            Store = new Store<AppState>(Reducer.ReduceAppState, new AppState(), ActionMiddlewares.CompositeActons, ActionMiddlewares.PrintActons);
            Store.Subscribe(x => Console.WriteLine(
                string.Format("Val = {0}, Progress = {1}, IsLoading = {2}, Result = {3}", x.Val, x.Progress, x.IsLoading, x.Result)));

            //Store.Dispatch(new ComplexAction());
            Store.Dispatch(new AsyncAction1());

            Console.WriteLine("Main thread finished dispatchiung, you can type while async action is running....");
            Console.WriteLine(Console.ReadLine());
            Console.ReadLine();






            /*
            Console.WriteLine("Main, threadId = " + Thread.CurrentThread.ManagedThreadId);
            var task = DoSomeWork(10);
            Console.WriteLine("Main thread continues after call DoSomeWork, threadId = " + Thread.CurrentThread.ManagedThreadId);
            task.Wait();
            Console.WriteLine("Main thread waited call to DoSomeWork, threadId = " + Thread.CurrentThread.ManagedThreadId);
            Console.ReadLine();*/
        }

        static async Task<int> DoSomeWork(int secounds)
        {
            Console.WriteLine("Start of DoSomeWork, threadId = " + Thread.CurrentThread.ManagedThreadId);
            var task = Task.Run<int>(delegate
            {
                var id = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine("Start of Task, thread id = " + id.ToString());
                Thread.Sleep(secounds * 1000);
                return 0;
            });
            Console.WriteLine("Some work after run of Task, threadId = " + Thread.CurrentThread.ManagedThreadId);
            int result = await task;
            Console.WriteLine("End of Task, threadId = " + Thread.CurrentThread.ManagedThreadId);
            return result;
        }

        static async void Fja()
        {
            await DoSomeWork(10);
        }
    }
}
