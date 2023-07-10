using System.Collections.Generic;

namespace CSharpStudy.Tests.CSharp1
{

  /**
  * Structs are used to create lightweight data types. 
  * They are typically used to represent small, lightweight objects that have value-like semantics. 
  * They are suitable for situations where you need to encapsulate a small amount of data together and want to avoid the overhead associated with reference types.
  * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/struct
  **/

  public struct StructTest
  {
    [Fact]
    public void ExecuteExample()
    {
      Point point = new Point(3, 5);
      point.Display();
    }
  }

  public struct Point
  {
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
      X = x;
      Y = y;
    }

    public void Display()
    {
      Console.WriteLine($"X: {X}, Y: {Y}");
    }
  }
}
