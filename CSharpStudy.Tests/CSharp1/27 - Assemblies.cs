



using System.Reflection;
using System.Reflection.Emit;

/**
  * Assemblies are the building blocks of .NET Framework applications; they form the fundamental unit of deployment, version control, reuse, activation scoping, and security permissions.
  * An assembly is a collection of types and resources that are built to work together and form a logical unit of functionality.
  * Assemblies take the form of executable (.exe) or dynamic link library (.dll) files, and are the building blocks of .NET applications.
  **/
namespace CSharpStudy.Tests.CSharp1
{
  internal class MyClass
  {
    public void MyMethod()
    {
      Console.WriteLine("Hello, World!");
    }
  }

  public class AssembliesTest
  {
    [Fact]
    public void AssemblyExample()
    {
      // Get the assembly that contains MyClass
      Assembly assembly = typeof(MyClass).Assembly;

      // Print the full name of the assembly
      Console.WriteLine($"Assembly Name: {assembly.FullName}");

      // Get the types defined in the assembly
      Type[] types = assembly.GetTypes();

      // Print the names of the types
      foreach (Type type in types)
      {
        Console.WriteLine($"Type Name: {type.FullName}");
      }
    }
  }
}