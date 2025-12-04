namespace CSharpStudy.Tests.CSharp1
{
    public interface IShape
    {
        double Area { get; }
    }

    public struct Point
    {
        public int X, Y;
        public Point(int x, int y) { X = x; Y = y; }
    }

    public class Circle : IShape
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public double Area => Math.PI * Radius * Radius;
    }

    public class ClassesAndObjectsTest
    {
        [Fact]
        public void ClassAndStructBehavior()
        {
            var center = new Point(0, 0);
            var circle = new Circle(center, 5);

            Assert.Equal(78.53981633974483, circle.Area);
        }
    }
}
