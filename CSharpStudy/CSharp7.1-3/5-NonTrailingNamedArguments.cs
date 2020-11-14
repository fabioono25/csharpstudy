using System;
using System.Threading.Tasks;

namespace CSharpStudy.CSharp7123
{
    public static class NonTrailingNamedArguments
    {
        public static void ExecuteExample()
        {
            // if the order is ok, you can send a un
            Print("message", name: "John", 10);
        }

        private static void Print(string message, string name, int age)
        {
            Console.WriteLine($"Message: {message} - Name: {name} - Age: {age}.");
        }
    }
}