using Redux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    public class Reducer
    {
        public static AppState ReduceAppState(AppState state, IAction action)
        {
            if (action is ComplexAction)
            {
                return ExecuteComplexAction(state);
            }
            if (action is SetProgress)
                return new AppState
                {
                    Progress = ((SetProgress)action).Progress,
                    Result=state.Result,
                    IsLoading=state.IsLoading,
                    Val=state.Val
                };
            if (action is SetVal)
                return new AppState
                {
                    Val = ((SetVal)action).Val,
                    IsLoading = state.IsLoading,
                    Result= state.Result,
                    Progress= state.Progress
                };
            if (action is SetResult)
                return new AppState
                {
                    Result = ((SetResult)action).Result,
                    Progress = state.Result,
                    IsLoading= state.IsLoading,
                    Val= state.Val
                };
            if (action is SetIsLoading)
                return new AppState
                {
                    IsLoading = ((SetIsLoading)action).IsLoading,
                    Val= state.Val,
                    Result= state.Result,
                    Progress= state.Progress
                };
            return state;
        }

        static AppState ExecuteComplexAction(AppState state)
        {
            Task.Run(async delegate
            {
                Program.Store.Dispatch(new SetIsLoading
                {
                    IsLoading = true
                });
                int result = await LoadSomeDataAsync();
                Program.Store.Dispatch(new SetResult
                {
                    Result = result
                });
            });
            return state;
        }

        static async Task<int> LoadSomeDataAsync()
        {
            return await Task<int>.Run(delegate
            {
                int sum = 0;
                for (int i = 0; i < 10; i++)
                {
                    sum += i;
                    Thread.Sleep(1000);
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
