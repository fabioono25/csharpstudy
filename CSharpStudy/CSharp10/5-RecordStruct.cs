namespace CSharpStudy.CSharp10;

public class RecordStruct
{
    public static void ExecuteExample() {   }

    internal record struct Message
    {
        public int Type { get; set; }
        public string Value { get; set; }
    }

    internal readonly record struct StrictMessage
    {
        // Error (cannot have set):
        //public int Type { get; set; }
        public int Type { get; }
        public string Value { get; }
    }

}