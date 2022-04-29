namespace CSharpStudy.CSharp1_2
{
    public class ConstructorsDestructors
    {
        public static void ExecuteExample()
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

        // Destructor
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