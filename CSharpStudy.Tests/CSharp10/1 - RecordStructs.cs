namespace CSharpStudy.Tests.CSharp10
{
    /**
    * Record structs are value type members that can be used to create immutable data types. They have an value-based equity.
    * https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#record-structs
    **/
    public class RecordStructs
    {
        [Fact]
        public void Example()
        {
            var message = new Message { Type = 1, Value = "Hello" };
            var message2 = new Message { Type = 1, Value = "Hello" };
            Console.WriteLine(message.Equals(message2)); // True
            Console.WriteLine(message == message2); // True

            var message3 = new MessageRec { Type = 1, Value = "Hello" };
            var message4 = new MessageRec { Type = 1, Value = "Hello" };
            Console.WriteLine(message3.Equals(message4)); // True
            Console.WriteLine(message3 == message4); // True

            // var strictMessage = new StrictMessage { Type = 1, Value = "Hello" }; // Error: cannot provide arguments when creating an instance of a read-only record struct
            message.Type = 2;
            var person = new Person { FirstName = "Mads", LastName = "Torgersen" };
        }

        internal record struct Message
        {
            public int Type { get; set; }
            public string Value { get; set; }
        }

        internal record  MessageRec
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

        public readonly record struct Person
        {
            public string FirstName { get; init; }
            public string LastName { get; init; }
        }

    }
}
