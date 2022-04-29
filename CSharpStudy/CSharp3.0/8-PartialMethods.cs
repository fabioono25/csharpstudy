namespace CSharpStudy.CSharp3_0
{
    public class PartialMethodsTest
    {
        public static void ExecuteExample()
        {
            var client = new Client();
            client.ExternedMethod(19);
        }
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