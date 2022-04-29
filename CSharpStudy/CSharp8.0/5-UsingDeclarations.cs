namespace CSharpStudy.CSharp7123
{
    public static class UsingDeclarations
    {
        public static void ExecuteExample()
        {
            using var stream1 = new StreamReader(Path.GetTempFileName());
            using var stream2 = new StreamReader(Path.GetTempFileName());
        }

    }
}