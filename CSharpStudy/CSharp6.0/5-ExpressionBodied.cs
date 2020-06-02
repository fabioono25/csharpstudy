using static System.Console;

namespace CSharpStudy.CSharp6
{
    public class ExpressionBodied
    {
        public static void ExecuteExample()
        {
            var car = new Car();

            car.PrintDescriptionComplete();
            WriteLine(car.ReturnDescriptionComplete());
        }
    }

    internal class Car {
        public string Brand { get; set; }
        public int Year { get; set; }
        private string DescriptionComplete => $"{Brand} {Year}";

        public void PrintDescriptionComplete() => WriteLine(DescriptionComplete);
        public string ReturnDescriptionComplete() => DescriptionComplete;
    }
}