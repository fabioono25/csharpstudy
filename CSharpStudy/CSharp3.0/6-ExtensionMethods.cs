using System;

public class ExtensionMethodsTest
    {
        public static void ExecuteExample()
        {
            var customer = new Customer();
            customer.Name = "John";

            Console.WriteLine(customer.Name.AddHi(", are you good?")); //Hi John, are you good?
            
            customer.ReverseName();
            Console.WriteLine(customer.Name); //nhoJ
        }        
    }

    internal class Customer {
        public string Name { get; set; }
    }

    internal static class CustomerExtensions{
        public static string AddHi(this string name, string complement){
            return string.Concat("Hi ", name, complement);
        }

        public static void ReverseName(this Customer customer){
            
            var array = customer.Name.ToCharArray();
            Array.Reverse(array);
            customer.Name = new String(array);
        }
    }