using System;

namespace CSharpStudy.CSharp3_0
{
    public class AnonymousTypesTests
    {
        public static void ExecuteExample()
        {
            var product = new {Id = 1, Name = "Pen" };

            //product.Id = 2; //it's readonly property

            Console.WriteLine(product.Name); //Pen

            //the objects inside of an array must have the same properties and property-types
            var prodArray = new[] { 
                                    new { Id = 1, Name = "Pen" }, 
                                    new { Id = 2, Name = "Pencil" }
                                };  
        }        
    }
}