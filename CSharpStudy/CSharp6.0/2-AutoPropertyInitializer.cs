namespace CSharpStudy.CSharp6
{
    public class AutoPropertyInitializer
    {
        public static void ExecuteExample()
        {
            var customer = new Customer();

            Console.WriteLine($"{customer.Name} {customer.LastName} - {customer.Age}.");

            customer.Name = "David";

            // customer.LastName = "Beckham"; //error: readonly property
            // customer.Age = 48;             //error: readonly property 
        }
    }

    internal class Customer
    {
        //initializing property with values
        public string Name { get; set; } = "John";
        public string LastName { get; } = "Nash";
        public int Age { get; } = 55;
    }
}