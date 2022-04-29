namespace CSharpStudy.CSharp9
{
    public class RecordType
    {
        public record Person(string name, int age);

        // inheritance between records
        public record Employee(string register, string name, int age) :
            Person(name, age);

        public static void ExecuteExample()
        {
            var employee = new Employee("ABC", "John", 19);
            var employee2 = new Employee("ABC", "John", 19);

            var manager = employee with { age = 65 }; // nondestructive mutation
            // manager.name = "William"; // Error, readonly properties by default

            var person = new Person(age: 1, name: "Marie"); //all mandatory properties

            Console.WriteLine(employee == employee2); // True
            Console.WriteLine(employee == manager);    // False
            Console.WriteLine(ReferenceEquals(employee, employee2)); // False
        }
    }
}
