using System;
using System.Threading.Tasks;

namespace CSharpStudy.CSharp71
{
    public static class InferredTupleNames
    {
        public static void ExecuteExample()
        {
            var name = "John";
            var age = 20;

            // define the tuple in an explicitly way 
            var tuple1 = (Name: name, Age: age);
            Console.WriteLine(tuple1.Name, tuple1.Age);

            // define the tuple in an implicitly way
            var tuple2 = (name, age);
            Console.WriteLine(tuple2.name, tuple2.age);
        }
    }
}