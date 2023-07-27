using System.Threading.Tasks;

namespace CSharpStudy.Tests.CSharp7
{
  /**
  * async methods to return any type, not just Task or Task<T>.
  * ValueTask<T> is a lightweight alternative to Task<T> that avoids unnecessary allocations in some situations.
  * The use of ValueTask<T> should be considered judiciously, as it is more suitable for specific scenarios where performance improvement is essential. In most cases, using regular Task<T> is sufficient and offers excellent performance for asynchronous operations.
  * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7#generalized-async-return-types
  **/
  public class Test6
  {
    [Fact]
    public void Example()
    {
      ExecuteExampleAsync().Wait();
    }

    public async Task ExecuteExampleAsync()
    {
      Console.WriteLine("Fetching data asynchronously...");

      // Simulate an asynchronous operation with delay
      int data = await FetchDataAsync();

      // Display the fetched data
      Console.WriteLine($"Fetched data: {data}");
    }

    // Simulate an asynchronous operation that returns data
    // The ValueTask<T> type is particularly useful when dealing with potentially synchronous operations that might complete quickly. It offers better performance in scenarios where the operation is likely to complete synchronously, avoiding the overhead of creating and managing a separate Task<T> object.
    private async ValueTask<int> FetchDataAsync()
    {
      await Task.Delay(1000); // Simulate asynchronous delay

      // Returning the fetched data
      return 42;
    }

  }
}
