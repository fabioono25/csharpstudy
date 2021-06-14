using System;

namespace CSharpStudy.CSharp9.Features
{
    public class DefaultInterfaceMembers: ITest
    {
        public static void ExecuteExample()
        {
            /*using is and as
             *This is advantageous if you want to add a member to an interface defined in a popular library without breaking (potentially thousands of) implementations.


             *
             */
            var x = (ITest)new DefaultInterfaceMembers();
            x.Method("asdasdads");

            try
            {

            }
            catch (Exception e) when (e.Message.Contains("asdasd"))
            {
                Console.WriteLine(e);
                throw;
            }
        }

        void Foo(string? s)
        {
            Console.WriteLine(s.Length);
        }

        void Foo2(string? s) => Console.WriteLine(s!.Length); // null-forgiving operator (dangerous, consider if (s != null) )
    }

    internal interface ITest
    {
        void Method(string text) => Console.WriteLine(text);
    }
}
