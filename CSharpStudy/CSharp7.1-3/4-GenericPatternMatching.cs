using System;
using System.Threading.Tasks;

namespace CSharpStudy.CSharp7123
{
    public static class GenericPatternMatching
    {
        public static void ExecuteExample()
        {
            var person = new Person { Age = 20 };
            Print<Person>(person);
        }

        // now, it's possible to evaluate generic types via pattern matching
        private static void Print<T>(T type) where T : Person
        {
            switch (type)
            {
                case null:
                    break;
                case Person person:
                    Console.WriteLine(person.Age);
                    break;
            }
        }

        class Person
        {
            public int Age { get; set; }
        }
    }
}