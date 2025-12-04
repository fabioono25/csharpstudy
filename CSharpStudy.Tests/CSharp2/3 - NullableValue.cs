namespace CSharpStudy.Tests.CSharp2
{
    public class NullableValueTest
    {
        [Fact]
        public void NullCoalescing_ReturnsDefault_WhenNull()
        {
            int? nullable = null;
            int result = nullable ?? -1;

            Assert.Equal(-1, result);
        }

        [Fact]
        public void NullCoalescing_ReturnsValue_WhenNotNull()
        {
            int? nullable = 42;
            int result = nullable ?? -1;

            Assert.Equal(42, result);
        }

        [Fact]
        public void HasValue_ReturnsFalse_WhenNull()
        {
            int? nullable = null;
            Assert.False(nullable.HasValue);
        }

        [Fact]
        public void HasValue_ReturnsTrue_WhenSet()
        {
            int? nullable = 10;
            Assert.True(nullable.HasValue);
            Assert.Equal(10, nullable.Value);
        }
    }
}
