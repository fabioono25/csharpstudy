namespace CSharpStudy.Tests.CSharp3
{
    /**
    * partial methods allow you to define a method declaration in one part of a partial class or struct, and optionally provide an implementation in the same part or another part.
    * the implementation for a partial method is optional. if the implementation is not supplied, then the compiler optimizes away both the defining declaration and all calls to the method.
    * partial methods are especially useful as a way to customize generated code.
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-methods
    **/
    public class PartialMethodsTest
    {
        [Fact]
        public void Example()
        {
            var client = new Client();
            client.ExternedMethod(19);
        }

        internal partial class Client
        {

            //Partial methods must have a void return type
            //partial bool CalculateCredit(int id);

            //A partial method cannot have access modifiers or the 
            //virtual, abstract, override, new, sealed, or extern modifiers
            //public partial void CalculateCredit(int id);

            //No defining declaration found for implementing declaration of partial method
            //partial void CalculateCredit(int id) {}

            public void ExternedMethod(int id)
            {
                Console.WriteLine("Calculate credit not called!");
                CalculateCredit(id);
                Console.WriteLine("Calculate credit called!");
            }

            partial void CalculateCredit(int id);
        }

        internal partial class Client
        {

            //A partial method may not have multiple defining declarations
            // partial void CalculateCredit(int id);

            //this is allowed
            partial void CalculateCredit(int id)
            {
                Console.WriteLine("Calculate credit");
            }
        }
    }
}
