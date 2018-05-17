namespace CSharpStudy
{
    public class Text : Shape
    {
        public Text(int fontSize, string fontName)
        {
            this.FontSize = fontSize;
            this.FontName = fontName;

        }
        public int FontSize { get; set; }
        public string FontName { get; set; }
    }

}