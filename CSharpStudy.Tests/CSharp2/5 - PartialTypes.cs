namespace CSharpStudy.Tests.CSharp2
{
    /**
    * Partial Types allow you to split the definition of a class or a struct, or an interface over two or more source files.
    Two or more developers can work on a single class at the same time.
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods
    **/
    public class PartialTypesTest
    {
        [Fact]
        public void UsingClassesExample()
        {
            MyClass myClass = new MyClass();
            myClass.Method1();
            myClass.Method2();
        }

        [Fact]
        public void UsingInterfacesExample()
        {
            PartialTest testPartial = new PartialTest();
            testPartial.Method1();
            testPartial.Method2();
            testPartial.Method3();
        }

        protected partial class MyClass
        {
            public void Method1()
            {
                // Implementation of Method1
                System.Console.WriteLine("Method1");
            }
        }

        protected partial class MyClass
        {

            // public void Method1() // Error: A partial method may not have multiple defining declarations
            // {
            //   // Implementation of Method1
            // }

            public void Method2()
            {
                // Implementation of Method2
                System.Console.WriteLine("Method2");
            }
        }

        protected partial class PartialTest : ITest
        {
            public void Method1()
            {
                System.Console.WriteLine("Method1");
            }

            public void Method2()
            {
                System.Console.WriteLine("Method2");
            }

            public void Method3()
            {
                System.Console.WriteLine("Method3");
            }
        }

        protected partial interface ITest
        {
            void Method1();
        }


        protected partial interface ITest
        {
            void Method2();
        }


        protected partial interface ITest
        {
            void Method3();
        }
    }

}
