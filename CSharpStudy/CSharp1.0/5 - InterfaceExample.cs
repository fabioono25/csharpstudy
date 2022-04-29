namespace CSharpStudy.CSharp1
{
    public class InterfaceExample
    {
        /// <summary>
        /// A interface contains definitions for a group or related functionalities that class or a struct can implement
        //  Can contain methods, properties, events, indexers
        //  Can't contain constants, fields, operators, instance constructors, finalizers, types
        //  No access modifiers
        //  To implement an interface member, the corresponding member of the implementing class must be public, non-static, and have the same name and signature as the interface member.
        /// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/
        /// </summary>
        public static void ExecuteExample()
        {
            Console.WriteLine("C# 1.0 - Interface Examples");

            Animal animal1 = new Animal();
            animal1.Name = "Dog1";
            animal1.IsHuman = false;

            Console.WriteLine("Name: " + animal1.Name + "Is Human: " + animal1.IsHuman);
        }
    }

    //interface: 
    interface IAnimal
    {
        string Name { get; set; }

        bool isHuman();
    }

    public class Animal : IAnimal
    {
        private string name;
        private bool human;

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

        public bool IsHuman
        {
            get
            {
                return human;
            }
            set
            {
                human = value;
            }
        }

        public bool isHuman()
        {
            return human;
        }
    }
}