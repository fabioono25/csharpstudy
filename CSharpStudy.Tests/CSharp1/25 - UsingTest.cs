/**
  * The using keyword in C# is used to define a scope within which an object or resource is used and automatically disposed of when it is no longer needed. It simplifies the management of resources that need to be explicitly released or cleaned up, such as file handles, database connections, network sockets, and more.
    * https://www.tutorialsteacher.com/csharp/csharp-using-statement
  **/

namespace CSharpStudy.Tests.CSharp1
{
    public class UsingTest
    {
        [Fact]
        public void ExecuteExample()
        {
            //without using
            {
                StreamReader testReader = new StreamReader(@"/home/ono/Documents/study/csharpstudy/CSharpStudy/CSharp1/test.txt");

                try
                {
                    Console.Write(testReader.ReadToEnd());
                }
                finally
                {
                    if (testReader != null)
                        testReader.Dispose();
                }
            }

            //with using
            using (var testReader = new StreamReader(@"/home/ono/Documents/study/csharpstudy/CSharpStudy/CSharp1.2/test.txt"))
            {
                Console.Write(testReader.ReadToEnd());
            }
            // Resource will be automatically disposed at the end of the using block
        }
    }
}