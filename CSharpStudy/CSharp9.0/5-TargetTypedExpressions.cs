using System;
using System.Text;

namespace CSharpStudy.CSharp9
{
    public class TargetTypedExpressions
    {
        StringBuilder sb1 = new();
        StringBuilder sb2 = new ("Test");
        StringBuilder sb;
        
        public TargetTypedExpressions (string initialValue)
        {
            sb = new (initialValue);

            MyMethod (new ("test"));

            Person person = new("James");
        }
        
        void MyMethod (StringBuilder sb) {  }
    }

    internal class Person {
        public Person(string name)
        {
            Console.WriteLine(name);
        }
    }
}
