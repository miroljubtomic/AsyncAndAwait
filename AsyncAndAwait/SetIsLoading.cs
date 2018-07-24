using Redux;

namespace AsyncAndAwait
{
    public class SetIsLoading : IAction
    {
        public bool IsLoading { get; set; }
    }
}