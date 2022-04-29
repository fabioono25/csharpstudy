namespace CSharpStudy.CSharp9
{
    public class HalfClass
    {
        public static void ExecuteExample()
        {
            Half half = Half.MaxValue; // 65500
            var max = nint.MaxValue; // 0x7fffffffffffffff

            nint x = 123;
            nint y = 234;
            nint product = x * y;

            IntPtr pt = x;
            pt += 1;
            Console.WriteLine($"x: {x} - pt: {pt}."); // x: 123 - pt: 124.
        }
    }
}
