namespace CSharpStudy.CSharp1
{
  /**
  * Inheritance allows you to create a new class (derived class) from an existing class (base class)
  * adding new members to derived class or modifying existing members from the base one
  **/
  class Animal
  {
    public string Name { get; set; }
    public void Eat()
    {
      Console.WriteLine("Eating...");
    }
  }

  class Dog : Animal
  {
    public void Bark()
    {
      Console.WriteLine("Barking...");
    }
  }

  public class InheritanceTest
  {
    public static void ExecuteExample()
    {
      var dog = new Dog();
      dog.Name = "Spike";
      dog.Eat();
      dog.Bark();
    }
  }
}
