using System;

namespace CSharpStudy.CSharp7
{
    public class ExpressionBodied
    {
        // Expression-bodied constructor
        public ExpressionBodied(string label) => this.Label = label;

        // Expression-bodied finalizer
        ~ExpressionBodied() => Console.Error.WriteLine("Finalized!");

        private string label;

        // Expression-bodied get / set accessors.
        public string Label
        {
            get => label;
            set => this.label = value ?? "Default label";
        }
    }
}
