namespace CSharpStudy.Tests.CSharp6
{
  /**
  * Dictionary initializers provide a concise way to initialize dictionaries with key-value pairs.
  * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-6#dictionary-initializers
  **/
  public class DictionaryInitializers
  {
    [Fact]
    public void Example()
    {
      // before C# 6.0
      var products1 = new Dictionary<int, Product>();
      products1.Add(1, new Product { Name = "Product 1" });
      products1.Add(2, new Product { Name = "Product 2" });
      products1.Add(3, new Product { Name = "Product 3" });

      // after C# 6.0
      var products2 = new Dictionary<int, Product>()
      {
        { 1, new Product { Name = "Product 1" }},
        { 2, new Product { Name = "Product 2" }},
        { 3, new Product { Name = "Product 3" }}
      };

      // another way with C# 6.0
      var products3 = new Dictionary<int, Product>()
      {
        [1] = new Product { Name = "Product 1" },
        [2] = new Product { Name = "Product 2" },
        [3] = new Product { Name = "Product 3" }
      };
    }
  }

  internal class Product
  {
    public string Name { get; set; }
  }
}
