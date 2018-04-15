using System;

namespace CSharpStudy
{
    public class Person{
        public Person()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Introduce(){
            System.Console.WriteLine("my name is: " + FirstName + " " + LastName);
        }
    }
}