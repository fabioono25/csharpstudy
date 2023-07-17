using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CSharpStudy.Tests.CSharp5
{
  /**
  * asynchronous methods allow you to write asynchronous code in a simpler way, using async and await keywords.
  * They simplify the handling of asynchronous operations without blocking the execution thread.
  * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/
  **/
  public class AsyncMethodsTest
  {
    [Fact]
    public async Task Example()
    {
      var client = new HttpClient();
      var data = await client.GetStringAsync("https://example.com/data");
      Console.WriteLine(data);
    }

    [Fact]
    public async Task Example2()
    {
      HttpClient client = new HttpClient();
      Uri address = new Uri("https://api.github.com/repos/fabioono25/");
      client.BaseAddress = address;

      HttpResponseMessage response = await client.GetAsync("csharpstudy");

      if (response.IsSuccessStatusCode)
      {
        //var list = await response.Content.ReadAsAsync<IEnumerable<Product>>();
        var result = await response.Content.ReadAsStringAsync();

        var ret = JsonConvert.DeserializeObject<Repository>(result);
        Console.WriteLine(ret.Name);
      }
      else
      {
        Console.WriteLine("null");
      }
    }

    internal class Repository
    {
      public string Name { get; set; }
      public string Description { get; set; }
    }
  }
}
