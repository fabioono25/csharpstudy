using System;

namespace CSharpStudy.CSharp1
{
    public class ClassExamplePerson
    {
        //constructor that takes no arguments
        public ClassExamplePerson()
        {
            Name = "Unknown";
        }

        //constructor that takes one argument
        public ClassExamplePerson(string name)
        {
            Name = name;
        }

        //auto-implemented readonly property (C# 3.0)
        public string Name { get; }

        //method that overrides the base class (System.Object) implementation
        public override string ToString() => Name;
    }

    public class TestPerson{
        
        public static void ExecuteExample(){
            //call the constructor that has no parameters
            var person1 = new ClassExamplePerson();
            Console.WriteLine(person1.Name);

            //call the constructor that has one parameter
            var person2 = new ClassExamplePerson("John de Barro");
            Console.WriteLine(person2.Name);
            //string representation of the person2 instance
            Console.WriteLine(person2);
        }

    }
}