using System;
using System.Linq.Expressions;

namespace CSharpStudy.CSharp3_0
{
    public class ExpressionTreesTest
    {
        public static void ExecuteExample()
        {
            //comparison between a simple lambda expression vs an expression tree
            Func<int, int> square = x => x * x;
            var x = square(2);

            Expression<Func<int, int>> square2 = x => x * x;
            var compiledExpression = square2.Compile(); //create a delegate
            var z = compiledExpression(2);              //invoke a delegate
        }        
    }
}