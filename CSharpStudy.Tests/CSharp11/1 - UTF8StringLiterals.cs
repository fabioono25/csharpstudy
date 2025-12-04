namespace CSharpStudy.Tests.CSharp11
{
    public class UTF8StringLiterals
    {
        [Fact]
        public void UTF8Literals_Example()
        {
            // UTF-8 string literals with u8 suffix
            ReadOnlySpan<byte> utf8 = "Hello"u8;
            
            Assert.Equal(5, utf8.Length);
            Assert.Equal((byte)'H', utf8[0]);
        }

        [Fact]
        public void UTF8ByteArray_Example()
        {
            byte[] bytes = "World"u8.ToArray();
            
            Assert.Equal(5, bytes.Length);
            Assert.Equal((byte)'W', bytes[0]);
        }
    }
}
