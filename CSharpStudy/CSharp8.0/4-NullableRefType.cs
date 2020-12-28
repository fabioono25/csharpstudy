using System;
using System.Threading.Tasks;

namespace CSharpStudy.CSharp7123
{
    public static class NullableRefType
    {
        public static void ExecuteExample()
        {
            string? name = null;  // compile will show a warning here
            Console.WriteLine(name.Length);

            string surName = null; // No warning
            Console.WriteLine(surName);

            string? nickName = null; // warning again
            Console.WriteLine(nickName);

            #nullable enable    
            string? address = null; // no warning
            Console.Write(address);
        }
    }
}