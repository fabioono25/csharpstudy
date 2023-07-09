using System.Collections.Generic;

namespace CSharpStudy.CSharp1
{

  /**
  * Iteration statements are used to execute a block of statements repeatedly.
  * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/iteration-statements
  **/


  public class IterationStatementsTest
  {
    public static void ExecuteExample()
    {
      for (int i = 0; i < 10; i++)
      {
          // Code to be executed repeatedly
      }

      foreach (var item in new List<string>() { "a", "b", "c" })
      {
          // Code to be executed for each item in the collection
      }

      while (true)
      {
          // Code to be executed while the condition is true
      }
    }
  }
}
