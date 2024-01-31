

using System.Numerics;

/**
  * Operator overloading is a feature that allows user-defined types to redefine the operation of an operator for its instances.
  * For example, the + operator can be overloaded to perform string concatenation.
  * The overloading of operators is done by defining a function named operator op where op is the operator to be overloaded.
  **/
namespace CSharpStudy.Tests.CSharp1
{
  internal class MyPoint
  {
    public double X { get; set; }
    public double Y { get; set; }

    public MyPoint(double x, double y)
    {
      X = x;
      Y = y;
    }

    // Overload the addition operator (+)
    public static MyPoint operator +(MyPoint p1, MyPoint p2)
    {
      return new MyPoint(p1.X + p2.X, p1.Y + p2.Y);
    }
  }
  
  public class OperatorOverloadingTest
  {
    [Fact]
    public void ExampleOperatorOverloading() {
      // Use the overloaded operator (+)
      MyPoint p1 = new MyPoint(10, 20);
      MyPoint p2 = new MyPoint(5, 15);
      MyPoint p3 = p1 + p2;

      Assert.Equal(15, p3.X);
      Assert.Equal(35, p3.Y);
    }

    [Fact]
    public void ExecuteExample()
    {
      // operator overloading example
      var c1 = new Complex(1, 2);
      var c2 = new Complex(3, 4);
      var c3 = c1 + c2;
      Assert.Equal(4, c3.Real);
    }
  }
}