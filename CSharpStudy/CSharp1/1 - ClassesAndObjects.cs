namespace CSharpStudy.CSharp1
{

  /**
  * a class works as a blueprint for creating objects
  * and object is the instance of a class
  * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/classes
  **/
  class Person {
    public string Name { get; set; } // property
    public int Age { get; set; }

    //constructor that takes no arguments
    public Person()
    {
        Name = "Unknown";
    }

    //constructor that takes one argument
    public Person(string name)
    {
        Name = name;
    }

    public void SayHello() { // method
      Console.WriteLine("Hello, my name is " + Name + " and I'm " + Age + " years old.");
    }
  }

  public class ClassesAndObjectsTest
  {
    public static void ExecuteExample()
    {
      Person p1 = new Person(); // object: instance of a class
      p1.Name = "John";
      p1.Age = 42;
      p1.SayHello();
    }
  }
}
