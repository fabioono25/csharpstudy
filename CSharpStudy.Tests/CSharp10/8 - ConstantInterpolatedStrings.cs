namespace CSharpStudy.Tests.CSharp10
{
    public class ConstantInterpolatedStrings
    {
        [Fact]
        public void ConstantInterpolation_Example()
        {
            // Constant interpolated strings (const with interpolation)
            const string Language = "C#";
            const string Version = "10";
            const string Message = $"{Language} version {Version}"; // Constant interpolation
            
            Assert.Equal("C# version 10", Message);
        }
    }
}
