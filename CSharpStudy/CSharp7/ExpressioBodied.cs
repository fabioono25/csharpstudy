using System;

namespace CSharpStudy.CSharp7
{
    public class ExpressioBodied
    {
        // Expression-bodied constructor
        public ExpressioBodied(string label) => this.Label = label;

        // Expression-bodied finalizer
        ~ExpressioBodied() => Console.Error.WriteLine("Finalized!");

        private string label;

        // Expression-bodied get / set accessors.
        public string Label
        {
            get => label;
            set => this.label = value ?? "Default label";
        }
    }
}
