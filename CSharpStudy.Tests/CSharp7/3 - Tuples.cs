namespace CSharpStudy.Tests.CSharp7
{
  /**
  * tuples are a lightweight data structure that contain multiple fields to represent the data members.
  * tuples are value types, immutable.
  * tuples are useful when you want to return multiple values from a method without using out parameters.
  * tuples are also useful when you want to pass multiple values to a method through a single parameter.
  * tuples are also useful when you want to hold a database record in memory.
  * tuples are also useful when you want to return multiple values from a LINQ query.
  * https://docs.microsoft.com/en-us/dotnet/csharp/tuples
  **/
  public class Test3
  {
    [Fact]
    public void Example()
    {
      // Tuple type
      (string, int) person = ("Alice", 30);

      // Tuple literals
      var (name, age) = person;
    }

    [Fact]
    public void Example2()
    {
      //return tuple
      var author = FindAuthor();
      Console.WriteLine($"Name: {author.Item1} - Age: {author.Item2} - Alive: {author.Item3}");

      //naming the return of a tuple
      (string name, int age, bool isAlive) author2 = FindAuthor();
      Console.WriteLine($"Name: {author2.name} - Age: {author2.age} - Alive: {author2.isAlive}");

      //calling a method that will return a named tuple
      var author3 = FindAuthor3();
      Console.WriteLine($"Name: {author3.name} - Age: {author3.age} - Alive: {author3.isAlive}");

    }

    public static (double vezesDois, double elevadoDois, double maisVinte) CalcularValores(int valor)
    {
      return (valor * 2, System.Math.Pow(valor, 2), valor + 20);
    }

    //example of tuple return
    static (string, int, bool) FindAuthor()
    {
      var firstName = "John";
      var age = 32;
      var alive = true;

      //tuple literal
      return (firstName, age, alive);
    }

    //example of tuple with named return
    static (string name, int age, bool isAlive) FindAuthor3()
    {
      var firstName = "John";
      var age = 32;
      var alive = true;

      return (firstName, age, alive);
    }
  }
}
