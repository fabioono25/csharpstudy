using System.Globalization;

namespace CSharpStudy.Tests.CSharp3
{
  /**
  * extension methods enable you to "add" methods to existing types without creating a new derived type,
  * recompiling, or otherwise modifying the original type.
  * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
  **/
  public class ExtensionMethodsTest
  {
    [Fact]
    public void ExampleStringExtension()
    {
      string str = "JOHN NASH";

      var x = str.Trim2();

      if (!str.IsEmpty())
      {
        Console.WriteLine(str.ToTitleCase());
      }
    }

    [Fact]
    public static void ExampleCustomExtension()
    {
      var customer = new Customer();
      customer.Name = "John";

      Console.WriteLine(customer.Name.AddHi(", are you good?")); //Hi John, are you good?

      customer.ReverseName();
      Console.WriteLine(customer.Name); //nhoJ
    }
  }
  public static class StringExtensions
  {
    public static bool IsEmpty(this string str)
    {
      return string.IsNullOrEmpty(str);
    }

    public static string Trim2(this string str)
    {
        return "execute um outro tipo de trim";
    }

    public static string ToTitleCase(this string str)
    {
      return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
    }
  }

  internal class Customer
  {
    public string Name { get; set; }
  }

  internal static class CustomerExtensions
  {
    public static string AddHi(this string name, string complement)
    {
      return string.Concat("Hi ", name, complement);
    }

    public static void ReverseName(this Customer customer)
    {

      var array = customer.Name.ToCharArray();
      Array.Reverse(array);
      customer.Name = new String(array);
    }
  }
}
