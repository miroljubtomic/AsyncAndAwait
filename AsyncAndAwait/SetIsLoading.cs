using System;
using Redux;

namespace AsyncAndAwait
{
    public class SetIsLoading : IAction, IPrintableAction
    {
        public bool IsLoading { get; set; }

        public string GetString()
        {
            if (IsLoading)
                return "SetIsLoading action, loading started";
            else
                return "SetIsLoading action, loading ended";
        }
    }
}