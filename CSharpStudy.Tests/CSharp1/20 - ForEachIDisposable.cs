using System.Collections;

namespace CSharpStudy.Tests.CSharp1
{
    public class ForEachIDisposable
    {
        [Fact]
        public void UsingStatement_CallsDispose()
        {
            bool disposed = false;
            var disposable = new DisposableAction(() => disposed = true);

            using (disposable)
            {
                // Do work
            }

            Assert.True(disposed);
        }

        [Fact]
        public void Foreach_IteratesCollection()
        {
            var names = new[] { "Alice", "Bob" };
            var result = new System.Collections.Generic.List<string>();

            foreach (var name in names)
            {
                result.Add(name);
            }

            Assert.Equal(2, result.Count);
            Assert.Equal("Alice", result[0]);
        }
    }

    public class DisposableAction : IDisposable
    {
        private readonly Action _onDispose;

        public DisposableAction(Action onDispose)
        {
            _onDispose = onDispose;
        }

        public void Dispose()
        {
            _onDispose?.Invoke();
        }
    }
}