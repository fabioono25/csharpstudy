using System;

namespace CSharpStudy.CSharp7
{
    public class OutVariables
    {
        public static void ExecuteExample(string input)
        {

            //old way: separate the declaration of the out variable into two different statements
            int numericResult;
            if (int.TryParse(input, out numericResult))
                Console.WriteLine($"Old way: {numericResult}");
            else
                Console.Write("Could not parse input");

            //new way: declare variables in the argument list of a method call
            if (int.TryParse(input, out int numericResultNew))
                Console.WriteLine($"New Way: {numericResultNew}");
            else
                Console.Write("Could not parse input");

            //we can use implicit typed local variable
            if (int.TryParse(input, out var numericResultVar))
                Console.WriteLine($"New Way with Var: {numericResultNew}");
            else
                Console.Write("Could not parse input");

            Console.WriteLine($"Using outside local scope: {numericResultNew}");
        }
    }
}