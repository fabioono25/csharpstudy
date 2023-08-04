namespace CSharpStudy.Tests.CSharp8
{
    /**
    * default interface methods allow us to add new members to an interface without breaking existing implementations of that interface.
    * Allows defining default implementations for interface methods, enabling backward compatibility when extending interfaces.
    * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/default-interface-methods
    **/
    public class DefaultInterfaceMethods
    {
        [Fact]
        public void Example()
        {
           var account = new AccountImplementation();
            account.Deposit(100);
            // account.SpecificDeposit(100); //'AccountImplementation' does not contain a definition for 'SpecificDeposit' and no accessible extension method 'SpecificDeposit' accepting a first argument of type 'AccountImplementation' could be found (are you missing a using directive or an assembly reference?)
        }
    }

    internal interface ICalculator
    {
        int Add(int a, int b);
        int Subtract(int a, int b);

        // Default implementation for Multiply method
        public int Multiply(int a, int b) => a * b;
    }

    internal interface Account
    {
        void Deposit(decimal amount);
        void SpecificDeposit(decimal amount)
        {
            //default routine here
            Console.WriteLine("Default routine");
        }
    }

    internal class AccountImplementation : Account
    {
        public void Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
