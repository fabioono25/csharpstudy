namespace CSharpStudy.Tests.CSharp7
{
  /**
  * Ref Local Reassignment allows you to reassign a ref local variable.
  * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-3#ref-local-reassignment
  **/
  public class RefLocalReassignment
  {
    [Fact]
    public void Example()
    {
      int x = 10;
      ref int y = ref x; // y is a reference to x
      y = 20; // Changes the value of x to 20
    }
  }
}
