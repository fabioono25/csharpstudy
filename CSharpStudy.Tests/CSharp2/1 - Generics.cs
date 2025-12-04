namespace CSharpStudy.Tests.CSharp2
{
    public class GenericStack<T>
    {
        private T[] _items = new T[100];
        private int _index = 0;

        public void Push(T item) => _items[_index++] = item;
        public T Pop() => _items[--_index];
    }

    public class GenericsTest
    {
        [Fact]
        public void GenericStack_EnforcesTypeSafety()
        {
            var stack = new GenericStack<string>();
            stack.Push("Hello");
            // stack.Push(123); // Compile error!

            string item = stack.Pop();
            Assert.Equal("Hello", item);
        }

        [Fact]
        public void GenericStack_WorksWithValueTypes_WithoutBoxing()
        {
            var stack = new GenericStack<int>();
            stack.Push(10);
            stack.Push(20);

            int sum = stack.Pop() + stack.Pop();
            Assert.Equal(30, sum);
        }
    }
}
