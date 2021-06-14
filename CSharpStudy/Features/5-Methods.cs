using System;

namespace CSharpStudy.CSharp9.Features
{
    public class Methods
    {
        public static void ExecuteExample()
        {
            /*Expression-bodied methods
             *local methods
             *
             */
            var rect = new Rectangle();
            var (width, height) = rect;
        }
    }

    internal class Rectangle
    {
        public readonly float Width, Height;

        public Rectangle()
        {
            this.Width = 10;
            this.Height = 20;
        }

        public void Deconstruct(out float width, out float height)
        {
            width = Width;
            height = Height;
        }
    }
}
