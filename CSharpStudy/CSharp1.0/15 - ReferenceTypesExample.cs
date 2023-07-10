namespace CSharpStudy.CSharp1
{
  public class ReferenceTypesExample
  {
    //a variable of a reference type contains a reference to an instance of the type, also known as an object
    //when you assing a new vaue to a variable of reference type, the reference is copied, not the object itself
    //these variables are stored in the heap. When it's no longer used, it can be marked for garbage collection

    ////Reference types includes:
    ///String
    ///Class
    ///Delegates
    ///Arrays (even with value type elements)
    ///dynamic

    public static void ExecuteExample()
    {
      Console.WriteLine("C# 1.0 - Reference Types Examples");

      Person person1 = new Person() { Name = "John" };
      Person person2 = person1;
      person2.Name = "Joaquim";

      Console.WriteLine(person1.Name); //Joaquim
      Console.WriteLine(person2.Name); //Joaquim

      string a = "hello";
      string b = "h";
      // Append to contents of 'b'
      b += "ello";
      Console.WriteLine(a == b);
      Console.WriteLine(object.ReferenceEquals(a, b));
    }

    private class Person
    {
      public string Name;
    }
  }


}
