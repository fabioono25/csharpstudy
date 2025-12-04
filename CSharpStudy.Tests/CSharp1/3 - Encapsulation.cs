namespace CSharpStudy.Tests.CSharp1
{
    public class BankAccount
    {
        private decimal _balance;

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value >= 0)
                    _balance = value;
                else
                    throw new ArgumentException("Balance cannot be negative");
            }
        }
    }

    public class EncapsulationTest
    {
        [Fact]
        public void SettingNegativeBalance_ThrowsException()
        {
            var account = new BankAccount();
            Assert.Throws<ArgumentException>(() => account.Balance = -100);
        }

        [Fact]
        public void SettingPositiveBalance_UpdatesBalance()
        {
            var account = new BankAccount();
            account.Balance = 100;
            Assert.Equal(100, account.Balance);
        }
    }
}
