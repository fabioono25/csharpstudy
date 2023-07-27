namespace CSharpStudy.Tests.CSharp6
{
  /**
  * auto-property initializers let you declare the initial value for auto-properties as part of the property declaration
  * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-6#auto-property-initializers
  **/
  public class AutoPropertyInitializers
  {
    [Fact]
    public void Example()
    {
      var customer = new Customer("abc");

      Console.WriteLine($"{customer.Name} {customer.LastName} - {customer.Age} - {customer.Test}.");

      customer.Name = "David";


      // customer.LastName = "Beckham"; //error: readonly property
      // customer.Age = 48;             //error: readonly property 
    }

    internal class Customer
    {
      public Customer(string test)
      {
        this.Test = test;
      }

      //initializing property with values
      public string Name { get; set; } = "John";
      public string LastName { get; } = "Nash"; // readonly property
      public int Age { get; } = 55;
      public string Test { get; set; }
    }
  }
}
