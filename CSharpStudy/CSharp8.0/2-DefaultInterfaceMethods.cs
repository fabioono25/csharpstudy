using System;
using System.Threading.Tasks;

namespace CSharpStudy.CSharp7123
{
    public static class DefaultInterfaceMethods
    {
        public static void ExecuteExample()
        {
            
        }
    }

    public interface Account
    {
        void Deposit(decimal amount);
        void SpecificDeposit(decimal amount)
        {
            //default routine here
        }
    }

    public class AccountImplementation : Account
    {
        public void Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}