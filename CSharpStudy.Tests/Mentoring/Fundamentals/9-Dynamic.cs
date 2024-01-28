using System.Dynamic;
using Microsoft.CSharp.RuntimeBinder;

internal class Student
{
  public string Name { get; set; }
}

internal class Duck : DynamicObject
{
  public void Quack()
  {
    Console.WriteLine("Quack!");
  }


  public override bool TryGetMember(GetMemberBinder binder, out object result)
  {
    Console.WriteLine(binder.Name + " was called");
    result = null;
    return true;
  }
}

public class Dynamic
{

  static void Write(dynamic obj)
  {
    try
    {
      Console.WriteLine(obj.Value);
    }
    catch (RuntimeBinderException)
    {
      Console.WriteLine(obj.Name);
    }
  }

  [Fact]
  public void TestDynamicValue()
  {
    var student = new Student { Name = "Rey" };
    Write(student);
  }

  [Fact]
  public void TestDynamicObject()
  {
    dynamic duck = new Duck();
    duck.Quack();
    duck.Waddle();
  }

}