using System.Collections.Generic;

namespace CSharpStudy.CSharp6
{
    public class InitializeCollectionsIndexes
    {
        public static void ExecuteExample()
        {

            //first way: compiles generating a call to Add for each of the pairs of int/Product2 values
            var products = new Dictionary<int, Product2>(){
                { 1, new Product2 { Name = "Product 1" }},
                { 2, new Product2 { Name = "Product 2" }},
                { 3, new Product2 { Name = "Product 3" }}
            };

            //second way: public read/write indexer method of Dictionary class
            var products2 = new Dictionary<int, Product2>(){
                [1] = new Product2 { Name = "Product 1" },
                [2] = new Product2 { Name = "Product 2" },
                [3] = new Product2 { Name = "Product 3" }
            };
        }
    }

    internal class Product2 {
        public string Name { get; set; }
    }
}