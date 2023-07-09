namespace CSharpStudy.CSharp1
{
  /**
  * Interfaces are used to define a contract that a class must implement.
  * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface
  **/

  public interface IShape
  {
    double CalculateArea();
    void Display();
  }
  public class InterfacesExample
  {
    public static void ExecuteExample()
    {
      IShape shape = new Circle(5.0);
      shape.Display();
      Console.WriteLine("Area: " + shape.CalculateArea());
    }

    // this class was defined inside the other class because there is a class Circle already defined in this namespace
    // this approach is not part of C# 1.0. It was added in C# 2.0
    public class Circle : IShape
    {
      private double radius;

      public Circle(double radius)
      {
        this.radius = radius;
      }

      public double CalculateArea()
      {
        return System.Math.PI * radius * radius;
      }

      public void Display()
      {
        Console.WriteLine("Circle with radius: " + radius);
      }
    }
  }
}