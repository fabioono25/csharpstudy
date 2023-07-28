namespace CSharpStudy.Tests.CSharp7
{
  /**
  * C# 7.1 - inferred tuple element names allows the compiler to infer element names for tuple types based on the names of the variables used to initialize them.
  * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-1#inferred-tuple-element-names
  **/
  public class InferredTypleElemNames
  {
    [Fact]
    public void Example()
    {
      var name = "John";
      var age = 20;

      // define the tuple in an explicitly way 
      var tuple1 = (Name: name, Age: age);
      Console.WriteLine(tuple1.Name, tuple1.Age);

      // define the tuple in an implicitly way
      var tuple2 = (name, age);
      Console.WriteLine(tuple2.name, tuple2.age);
    }
  }
}
