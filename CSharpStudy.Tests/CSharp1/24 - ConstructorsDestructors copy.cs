/**
  * Constructors and destructors are special methods in C# that are used for initializing and cleaning up objects, respectively.
    * https://www.tutorialsteacher.com/csharp/csharp-constructor
  **/

namespace CSharpStudy.Tests.CSharp1_2
{
    public class ConstructorsDestructorsTest
    {
        [Fact]
        public void ExecuteExample()
        {
            ClassExample ex = new ClassExample(); //using the default cosntructor
            ClassExample ex2 = new ClassExample("Using the parameterized constructor"); //using the default cosntructor
            ex.Dispose();
            ex2.Dispose();
        }
    }

    class ClassExample : IDisposable
    {
        // Default constructor
        public ClassExample()
        {
            Console.WriteLine("This is de the default constructor...");
        }

        public ClassExample(string message)
        {
            Console.WriteLine("This is de the constructor with the message: " + message);
        }

        // Destructor (cannot be called explicitly)
        ~ClassExample()
        {
            Console.WriteLine("Destructor called");
        }

        public void Dispose()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("Disposed called");
        }
    }
}