namespace CSharpStudy.Tests.CSharp1
{
    public struct Complex
    {
        public double Real { get; }
        public double Imaginary { get; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }
    }

    public class OperatorOverloadingTest
    {
        [Fact]
        public void OperatorPlus_AddsComponents()
        {
            var c1 = new Complex(1, 2);
            var c2 = new Complex(3, 4);
            var result = c1 + c2;

            Assert.Equal(4, result.Real);
            Assert.Equal(6, result.Imaginary);
        }
    }
}