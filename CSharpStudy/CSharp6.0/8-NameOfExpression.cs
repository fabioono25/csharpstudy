namespace CSharpStudy.CSharp6
{
    public class NameOfExpression
    {
        public static void ExecuteExample()
        {
            var category = new Category(null);
        }
    }

    internal class Category
    {
        private string Name { get; set; }

        public Category(string name)
        {
            //using nameof
            Name = name ?? throw new NullReferenceException(nameof(name));
        }
    }
}