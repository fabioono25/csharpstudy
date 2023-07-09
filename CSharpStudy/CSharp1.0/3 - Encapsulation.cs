namespace CSharpStudy.CSharp1
{

  /**
  * Encapsulation is the process of hiding the internal implementation details and showing only the necessary
  **/
  class BankAccount {
    private decimal balance; // private field (controled access)
    public decimal Balance { // public property
      get { return balance; }
      set { balance = value; }
    }

    public void Deposit(decimal amount) {
      balance += amount;
    }

    public void Withdraw(decimal amount) {
      balance -= amount;
    }
  }

  public class EncapsulationTest
  {
    public static void ExecuteExample()
    {
      var bancAccount = new BankAccount();
      bancAccount.Balance = 1000;
      bancAccount.Deposit(500);
      bancAccount.Withdraw(200);
      Console.WriteLine(bancAccount.Balance);
    }
  }
}
