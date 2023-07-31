namespace CSharpStudy.Tests.CSharp3
{
    /**
    * automatic properties allow us to declare a property without specifying a get and set.
    * the compiler creates a private, anonymous backing field that can only be accessed through the property's get and set accessors.
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
    **/
    public class AutomaticPropertiesTest
    {
        [Fact]
        public void Example()
        {
            var customer = new Customer();
            customer.Name = "Jean";
            customer.Age = 23;
            Console.WriteLine($"Name: {customer.Name}, Age: {customer.Age}");
        }

        protected class Customer
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
