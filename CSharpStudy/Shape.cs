namespace CSharpStudy
{
    public abstract class Shape{
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        // public virtual void Draw(){
        // }
         //if you maintaint, it's a risk, because you don't have implementation in shape
        public abstract void Draw(); //abstract force implementation
    }

    public class Circle : Shape{

        public override void Draw(){
            //base.Draw();

            System.Console.WriteLine("drawing a circle");
        }
    }
}
