namespace CSharpStudy.Tests.CSharp9
{
    /**
    * records are reference types that provide value semantics.
    * record types  are immutable by default. They provide a concise way to define immutable data classes with value semantics.
    * Advantages over classes: immutability by default, concise syntax, value semantics, generated methods.
    * Advantages over structs: reference semantics, inheritance, and interfaces.
    * Advantages over tuples: named fields, methods, and inheritance.
    * Where to use: DTOs, immutable objects, and data classes.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#record-types
    **/
    public class Records
    {
        [Fact]
        public void Example()
        {
            var person1 = new Person("John", "Doe");

            // using with expression to create a new record with modified LastName
            var person2 = person1 with { LastName = "Smith" }; // Creating a new record with modified LastName

            Console.WriteLine(person1.Equals(person2)); // Outputs: False (different reference)
            Console.WriteLine(person1.FirstName); // Outputs: John

            // Deconstruction
            var (firstName, lastName) = person1;
            Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}");

            // Comparison
            var person3 = new Person("John", "Doe");
            Console.WriteLine(person1 == person3); // Outputs: True
        }
    }

    internal record Person(string FirstName, string LastName);
}
