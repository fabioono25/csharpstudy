namespace CSharpStudy.CSharp_1
{

  /**
  * a class works as a blueprint for creating objects
  **/
  class Person {
    public string Name { get; set; } // property
    public int Age { get; set; }

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
