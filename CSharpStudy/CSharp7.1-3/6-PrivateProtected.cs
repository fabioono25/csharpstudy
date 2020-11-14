using System;
using System.Threading.Tasks;

namespace CSharpStudy.CSharp7123
{
    public static class PrivateProtected
    {
        public static void ExecuteExample()
        {
            var person = new Person { 
                Name = "James", 
                //Age = 20 //'PrivateProtected.Person.Age' is inaccessible due to its protection level
            };

            var person2 = new Person2
            {
                Name = "Josh",
            };
            person2.MyAge = 12; //accessible 
        }

        private class Person
        {
            public string Name { get; set; }
            private protected int Age { get; set; }
        }

        private class Person2 : Person
        {
            public int MyAge
            {
                get { return Age; } //property accessible
                set { Age = value; }
            }
        }
    }
}