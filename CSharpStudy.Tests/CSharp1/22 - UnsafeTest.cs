
/**
  * the unsafe keyword was introduced to allow developers to write unsafe and unverifiable code. The unsafe keyword enables the use of pointers, direct memory manipulation, and other low-level operations within a specific code block.
  * The unsafe keyword is used to declare a block of code that uses pointers. This block is called an unsafe context. The unsafe context is used to define an unsafe method, an unsafe type, or an unsafe code block.
  * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/unsafe
  **/

namespace CSharpStudy.Tests.CSharp1
{
  public class UnsafeTest
  {
    [Fact]
    public unsafe void ExecuteExample()
    {
      int var = 20;
      int* p = &var;

      Console.WriteLine("Data is: {0} ", var);        //20
      Console.WriteLine("Address is: {0}", (int)p);   //-428064772 (changes each execution)
    }
  }
}