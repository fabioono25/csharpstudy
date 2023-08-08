using System.Text;

namespace CSharpStudy.Tests.CSharp9
{
    /**
    * TargetTyped New expression allows you to omit the type of the object being created when the type can be inferred from the context.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#target-typed-new-expressions
    **/
    public class TargetTypedNew
    {
        [Fact]
        public void Example()
        {
            // old way
            var list = new List<int>();

            // new way
            List<int> list2 = new(); // type can be inferred from the context
        }

        [Fact]
        public void Example2()
        {
            Person person = new("James");
        }

        [Fact]
        public void Example3()
        {
            // old way
            var sb = new StringBuilder();
            MyMethod(sb);

            // new way
            MyMethod(new()); // type can be inferred from the context
        }

        void MyMethod(StringBuilder sb) { }

        internal class Person
        {
            public Person(string name)
            {
                Console.WriteLine(name);
            }
        }
    }
}
