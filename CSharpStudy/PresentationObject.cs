namespace CSharpStudy
{
    public class PresentationObject
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public void Copy()
        {
            System.Console.WriteLine("copy");
        }

        public void Duplicate()
        {
            System.Console.WriteLine("duplicate");
        }
    }

}
