using System;

namespace CSharpStudy.CSharp1
{
    /// <summary>
    /// A delegate in C# is similar to function pointers of C++, but C# delegates are type safe. 
    /// Delegates are used to define callback methods and implement event handling, and they are declared using the "delegate" keyword. 
    /// You can declare a delegate that can appear on its own or even nested inside a class.
    /// https://docs.microsoft.com/en-us/dotnet/csharp/delegates-overview
    /// </summary>
    public class DelegateExample
    {
        //defining a delegate type
        public delegate void Del(string message);

        //creating a method for a delegate
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        public static void ExecuteExample()
        {
            //instantiate the delegate
            Del handler = DelegateMethod;

            //call the delegate
            handler("hello!!");
        }
    }
}