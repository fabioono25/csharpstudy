namespace CSharpStudy.Tests.CSharp14
{
    /**
     * Simplified Lambda Expressions - C# 14 improvements
     * Fewer modifiers needed, more natural syntax
     * https://github.com/dotnet/csharplang/issues/3948
     **/
    public class SimplifiedLambdas
    {
        [Fact]
        public void SimplifiedLambda_BasicExample()
        {
            // C# 14 aims to simplify lambda syntax
            Func<int, int> double1 = x => x * 2;
            Func<int, int, int> add = (x, y) => x + y;
            
            Assert.Equal(10, double1(5));
            Assert.Equal(15, add(7, 8));
        }

        [Fact]
        public void SimplifiedLambda_AsyncScenarios()
        {
            // Simplified async lambdas
            Func<Task<int>> getValueAsync = async () => 
            {
                await Task.Delay(1);
                return 42;
            };
            
            var result = getValueAsync().Result;
            Assert.Equal(42, result);
        }

        [Fact]
        public void SimplifiedLambda_WithAttributes()
        {
            // C# 14 may further simplify attribute syntax on lambdas
            // Building on C# 10's lambda attributes
            var items = new[] { 1, 2, 3, 4, 5 };
            var filtered = items.Where(x => x > 2).ToList();
            
            Assert.Equal(3, filtered.Count);
        }
    }
}
