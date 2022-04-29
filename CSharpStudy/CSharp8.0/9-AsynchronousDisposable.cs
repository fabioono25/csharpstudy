using System.Threading.Tasks;

namespace CSharpStudy.CSharp7123
{
    public static class AsynchronousDisposable
    {
        public static async void ExecuteExample()
        {
            var userAsyncDisposable = new UserAsyncDisposable();
            await using (userAsyncDisposable.ConfigureAwait(false)) // old way
            {
            }

            await using var userAsyncDisposable2 = new UserAsyncDisposable();

        }
    }

    internal class UserAsyncDisposable : IAsyncDisposable
    {
        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}