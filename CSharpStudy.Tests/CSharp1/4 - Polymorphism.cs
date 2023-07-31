namespace CSharpStudy.Tests.CSharp1
{

    /**
    * Polymorphism allows objects of different classes to be treated as objects of the same class in certain scenarios
    * It promotes flexibility and code reusability, working with objects at a more abstract level
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/polymorphism
    **/
    class Shape
    {
        public virtual void Draw()
        { // virtual method
            Console.WriteLine("Drawing a Shape...");
        }
    }

    class Circle : Shape
    {
        public override void Draw()
        { // override method
            Console.WriteLine("Drawing a Circle...");
        }
    }

    class Rectangle : Shape
    {
        public override void Draw()
        { // override method
            Console.WriteLine("Drawing a Rectangle...");
        }
    }

    public class PolymorphismTest
    {
        [Fact]
        public void ExecuteExample()
        {
            var shape1 = new Circle();
            var shape2 = new Rectangle();

            shape1.Draw();
            shape2.Draw();
        }
    }
}
