using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CSharpStudy.Tests.Mentoring.Fundamentals
{
    public class Types
    {
        class Person(string firstName, string lastName)
        {
            public readonly string FirstName = firstName;
            public string LastName { get; } = lastName;

            public void Print() => Console.WriteLine(firstName + " " + lastName);

        }

        [Fact]
        public void PrimaryConstructors()
        {
            var person = new Person("John", "Doe");

            // console write the person as string
            person.Print();
        }

        [Fact]
        public void AccessModifiersTest()
        {
            // public: access is not restricted
            // private: access is restricted to the containing type
            // protected: access is limited to the containing class or types derived from the containing class
            // internal: access is limited to the current assembly
            // protected internal: access is limited to the current assembly or types derived from the containing class
            // private protected: access is limited to the containing class or types derived from the containing class within the current assembly

        }
        
        // define a simple delegate
        delegate int Operation(int x, int y);

        [Fact]
        public void DelegatesTest()
        {
            // define a delegate instance
            Operation operation = (x, y) => x + y;

            // invoke the delegate
            var result = operation(1, 2);

            // console write the result
            Console.WriteLine(result);
        }

        [Fact]
        public void PassingDelegateParameterFunction()
        {
            // define a delegate instance
            Operation operation = (x, y) => x + y;

            // define a function that takes a delegate as parameter
            int Calculate(Operation operation, int x, int y) => operation(x, y);

            // invoke the function
            var result = Calculate(operation, 1, 2);

            // console write the result
            Console.WriteLine(result);
        }

        [Fact]
        public void LambdaExpressionsTest()
        {
            // define a lambda expression
            Func<int, int, int> operation = (x, y) => x + y;

            // invoke the lambda expression
            var result = operation(1, 2);
        }

        void Print(string message) => Console.WriteLine(message);


        [Fact]
        public void DefaultLambdaParameter()
        {
            var print = (string message = "Hello World") => Console.WriteLine(message);

            print("Hello World");
        }

        [Fact]
        public void YieldBreakTest()
        {
            // yield definition: it is used to return each element one at a time
            // advantage: it is more efficient than returning a collection
            // disadvantage: it is not possible to modify the collection while iterating over it

            // define a function that returns an IEnumerable
            IEnumerable<int> GetNumbers()
            {
                yield return 1;
                yield return 2;
                yield return 3;
                yield break;
                yield return 4;
            }

            // invoke the function
            var numbers = GetNumbers();

            // iterate over the numbers
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }   
    }
}
