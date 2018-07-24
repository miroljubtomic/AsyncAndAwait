using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redux;
using System.Threading;

namespace AsyncAndAwait
{
    public class AsyncAction1 : IAsyncAction<AppState>
    {
        public async void Execute(IStore<AppState> store)
        {
            store.Dispatch(new SetIsLoading
            {
                IsLoading = true
            });

            int resul  = await LoadSomeDataAsync();

            store.Dispatch(new SetIsLoading
            {
                IsLoading = false
            });
        }
        static async Task<int> LoadSomeDataAsync()
        {
            return await Task<int>.Run(delegate
            {
                int sum = 0;
                for (int i = 0; i < 10; i++)
                {
                    sum += i;
                    Thread.Sleep(3000);
                    Program.Store.Dispatch(new SetProgress
                    {
                        Progress = i
                    });
                }
                return sum;
            });
        }
    }
}
