using System.Linq.Expressions;

namespace CSharpStudy.Tests.CSharp3
{
    /**
    * expression trees allows representing code as data structures. AST (Abstract Syntax Tree) is an example of expression tree, that enables manipulation and analysis of code at runtime.
    * Expression trees are particularly useful in scenarios where you need to dynamically generate and execute code, such as creating dynamic queries, building dynamic predicates, or generating dynamic SQL statements.
    * Expression trees provide a powerful mechanism for building and manipulating code at runtime. They are commonly used in advanced scenarios, such as LINQ providers, dynamic code generation, and query building frameworks.
    * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/expression-trees
    **/
    public class ExpressionTreeTest
    {
        [Fact]
        public void Example()
        {
            // Create an expression tree representing a simple addition
            Expression<Func<int, int, int>> addExpr = (a, b) => a + b;

            // Compile the expression tree into a delegate
            Func<int, int, int> addFunc = addExpr.Compile();

            // Execute the compiled delegate
            int result = addFunc(5, 3);
            Console.WriteLine(result); // Output: 8
        }

        [Fact]
        public void Example2()
        {
            //comparison between a simple lambda expression vs an expression tree
            Func<int, int> square = x => x * x;
            var x = square(2);

            Expression<Func<int, int>> square2 = x => x * x;
            var compiledExpression = square2.Compile(); //create a delegate
            var z = compiledExpression(2);              //invoke a delegate

            // While simple lambda expressions provide a concise syntax for defining delegates or inline functions, expression trees go beyond that 
            //  by representing code as data structures and providing dynamic code generation and manipulation capabilities. 
            // Expression trees are more suited for advanced scenarios that require runtime code analysis, modification, and generation.
        }
    }
}
