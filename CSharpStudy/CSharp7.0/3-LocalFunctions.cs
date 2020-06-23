using System;
using System.Threading;

namespace CSharpStudy.CSharp7
{
    public class LocalFunctions
    {
        public static void ExecuteExample()
        {

            var result = Fibonacci(10);
        }

        public static int Fibonacci(int value)
        {
            if (value < 0) throw new ArgumentException("Invalid value", nameof(value));
            
            return Fib(value).current;

            (int current, int previous) Fib(int i)
            {
                if (i == 0) return (1, 0);
                
                var (p, pp) = Fib(i - 1);
                return (p + pp, p);
            }
        }        
    }
}