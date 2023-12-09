/**
* Top-level statements allow C# programs to be defined without a containing type declaration.
* https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#top-level-statements
**/
/*
BEFORE C# 9

using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
*/

// AFTER C# 9
Console.WriteLine("Hello World!");