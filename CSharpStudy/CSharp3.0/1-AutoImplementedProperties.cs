namespace CSharpStudy.CSharp3_0
{
    public class AutoImplementedPropertiesTest
    {
        public static void ExecuteExample()
        {
            var customer = new Customer();
            customer.Name = "Jean";
            customer.Age = 23;
        }
    }

    internal class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}