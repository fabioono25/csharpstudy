using System;

namespace CSharpStudy.CSharp9.Features
{
    public class TargetTypedNew
    {
        public static void ExecuteExample()
        {
            /*
             *System.Text.StringBuilder sb1 = new();
System.Text.StringBuilder sb2 = new ("Test");
 
            The principle is that you can call new without specifying a type name if the compiler is able to unambiguously infer it. Target-typed new expressions are particularly useful when the variable declaration and initialization are in different parts of your code. A common example is when you want to initialize a field in a constructor:
            class Foo
{
  System.Text.StringBuilder sb;
  
  public Foo (string initialValue)
  {
    sb = new (initialValue);
  }
}
             *
             */
        }
    }
}
