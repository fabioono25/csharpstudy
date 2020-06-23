using System;

namespace CSharpStudy.CSharp6
{
    public class ReadOnlyAutoPropety
    {
        public static void ExecuteExample()
        {
            var product = new Product("Product 1");

            Console.WriteLine($"{product.Name} {product.InStock}");

            //product.InStock = true; //error - readonly property
        }
    }

    internal class Product {
        //readonly properties 
        public string Name { get; }
        public bool InStock { get; }

        public Product(string name)
        {
            this.Name = name;
        }
    }
}