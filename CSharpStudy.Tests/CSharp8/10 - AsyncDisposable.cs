using System.Threading.Tasks;

namespace CSharpStudy.Tests.CSharp8
{
    /**
    * async disposable allows defining asynchronous cleanup logic for types that implement IAsyncDisposable.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#asynchronous-disposable-types
    **/
    public class AsyncDisposable
    {
        [Fact]
        public static async void Example()
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

/***
The ConfigureAwait method is used to control how an await operation behaves when it resumes after the awaited asynchronous task completes. It is particularly useful when you want to optimize performance and avoid potential deadlocks in certain scenarios.

The ConfigureAwait method accepts a boolean argument that determines whether the await operation should continue on the captured context (true) or without capturing the context (false).

When ConfigureAwait(true) is used, the await operation continues on the captured context, which is typically the context from which the asynchronous operation was initiated. This means that after the awaited task completes, the code following the await will run on the same context (e.g., UI thread, ASP.NET request context) as the original caller. This can be beneficial for scenarios where the continuation requires access to the original context, such as updating UI elements in a Windows Forms or WPF application.

However, using ConfigureAwait(true) can also lead to potential deadlocks in certain situations, particularly in UI-based applications or ASP.NET applications. If the awaited task involves blocking operations that wait for the original context, and the original context is blocked waiting for the task to complete, you may encounter a deadlock.

To avoid such deadlocks, you can use ConfigureAwait(false). When ConfigureAwait(false) is used, the await operation will continue on a thread pool thread instead of the original context. This is generally more efficient because it prevents unnecessary context switches and can improve the overall performance of the application.

In summary, you use ConfigureAwait to control how an await operation behaves with respect to the captured context. Use ConfigureAwait(true) when you need access to the original context after the await, and use ConfigureAwait(false) when you want to optimize performance and avoid potential deadlocks, especially in scenarios involving UI-based applications or ASP.NET.
***/