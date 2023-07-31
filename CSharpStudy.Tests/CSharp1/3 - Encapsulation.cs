namespace CSharpStudy.Tests.CSharp1
{

    /**
    * Encapsulation is the process of hiding the internal implementation details and showing only the necessary.
    * It helps to achieve data hiding in a class and prevents other classes from accessing the private members of the class.
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers
    **/
    class BankAccount
    {
        private decimal balance; // private field (controled access)
        public decimal Balance
        { // public property
            get { return balance; }
            set { balance = value; }
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            balance -= amount;
        }
    }

    public class EncapsulationTest
    {
        [Fact]
        public void ExecuteExample()
        {
            var bancAccount = new BankAccount();
            bancAccount.Balance = 1000;
            bancAccount.Deposit(500);
            bancAccount.Withdraw(200);
            Console.WriteLine(bancAccount.Balance);
        }
    }
}
