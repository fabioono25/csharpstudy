namespace CSharpStudy.Tests.CSharp4
{
  /**
  * covariance and contravariance enable implicit reference conversion for array types, delegate types, and generic type arguments.
  It allows more flexible assignment compatibility for generic types.
  Covariance enables assignment of a more derived type to a less derived type, and contravariance enables assignment of a less derived type to a more derived type.
  * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/
  **/
  public class CovariantContravariantTypeParametersTest
  {
    [Fact]
    public void Example()
    {
      // It'll work because now, IEnumerable supports covariance
      IEnumerable<Manager> mg = GetManager();
      IEnumerable<Employee> em = mg;

      // List is not covariant in T
      List<Manager> mg2 = new List<Manager>();
      //List<Employee> em2 = mg2; // CS0029: error of implicit conversion
    }
    
    public static IEnumerable<Manager> GetManager()
    {
      IEnumerable<Manager> manager = null;

      return manager;
    }

    public class Employee
    {
    }

    public class Manager : Employee
    {
    }
  }
}
