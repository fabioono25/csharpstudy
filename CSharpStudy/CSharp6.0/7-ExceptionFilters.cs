namespace CSharpStudy.CSharp6
{
    public class ExceptionFilters
    {
        public static void ExecuteExample()
        {
            Test test = null;

            try
            {

                var x = test.Property;

            }
            catch (Exception e) when (e.Message.Contains("Object reference"))
            {
                Console.WriteLine("You can use NullReferenceException, but it's just an example");
            }
        }
    }

    internal class Test
    {
        public int Property { get; set; }
    }
}