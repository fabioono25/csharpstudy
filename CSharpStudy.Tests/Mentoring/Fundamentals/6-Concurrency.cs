using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;

public class ConcurrencyTests
{

  private readonly ITestOutputHelper _output;

  public ConcurrencyTests(ITestOutputHelper output)
  {
    _output = output;
  }

  [Fact]
  public void ThreadTest()
  {
    Thread t = new Thread(WriteY);          // Kick off a new thread
    t.Start();                               // running WriteY()

    // Simultaneously, do something on the main thread.
    for (int i = 0; i < 1000; i++) Console.Write("x");

    void WriteY()
    {
      for (int i = 0; i < 1000; i++) Console.Write("y");
    }
  }

  [Fact]
  public void TasksTest()
  {
    // Create a task and supply a user delegate by using a lambda expression. 
    Task taskA = new Task(() => Console.WriteLine("Hello from taskA."));
    // Start the task.
    taskA.Start();

    // Output a message from the calling thread.
    Console.WriteLine("Hello from thread '{0}'.",
                      Thread.CurrentThread.Name);
    taskA.Wait();
  }

  Task<int> GetPrimesCount(int start, int count)
  {
    return
      Task.Run(() => ParallelEnumerable.Range(start, count).Count(n =>
        Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
  }

  [Fact]
  public async void DisplayPrimeCountsTest()
  {
    for (int i = 0; i < 10; i++)
      Console.WriteLine(await GetPrimesCount(i * 1000000 + 2, 1000000) +
        " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
    Console.WriteLine("Done!");
  }

  [Fact]
  public async void ParallelForEachAsync()
  {
    // Create a list of web addresses.
    var uris = new[] { "https://www.google.com", "https://www.microsoft.com", "https://www.apple.com" };
    await Parallel.ForEachAsync(uris,
    new ParallelOptions { MaxDegreeOfParallelism = 10 },
    async (uri, cancelToken) =>
    {
      var download = await new HttpClient().GetByteArrayAsync(uri);
      Console.WriteLine($"Downloaded {download.Length} bytes");
    });
  }

}