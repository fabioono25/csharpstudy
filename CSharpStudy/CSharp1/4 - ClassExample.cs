using System;

namespace CSharpStudy.CSharp1
{
    /// <summary>
    /// Classes are the blueprint for the creation and use of objects
    /// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/classes
    /// </summary>
    public class ClassExamplePerson
    {
        //definition of a private fields
        private string name;

        //definition of property to expose the field
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        
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

        //method that returns a boolean value
        public bool HasName()
        {
            return !String.IsNullOrEmpty(this.Name);
        }
    }

    public class TestPerson
    {

        public static void ExecuteExample()
        {
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