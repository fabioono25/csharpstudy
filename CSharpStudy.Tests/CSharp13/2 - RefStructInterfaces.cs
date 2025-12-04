namespace CSharpStudy.Tests.CSharp13
{
    public class RefStructInterfaces
    {
        public interface IResettable<T> where T : ref struct
        {
            void Reset(ref T value);
        }

        // Ref struct implementing interface (C# 13 feature)
        public ref struct Counter : IResettable<Counter>
        {
            public int Value;
            
            public void Reset(ref Counter value)
            {
                value.Value = 0;
            }
        }

        [Fact]
        public void RefStructInterfaces_Example()
        {
            // Note: Boxing ref structs is still not allowed, but using them in generics with constraints is.
            // This test primarily verifies compilation of the new constraints.
            
            Counter c = new Counter { Value = 10 };
            c.Reset(ref c);
            Assert.Equal(0, c.Value);
        }
    }
}
