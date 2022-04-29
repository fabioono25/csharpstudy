namespace CSharpStudy.CSharp7123
{
    public static class PatternMatchingNew
    {
        public static void ExecuteExample()
        {
            Console.Write(getColor(Color.Blue));
            Console.Write(ComputeDiscount(10, new User { Age = 18 }));
            Console.Write(getCongratsPhrase("Clarice", "Linspector"));
        }

        public enum Color
        {
            Red,
            Green,
            Blue
        }

        public static string getColor(Color color) =>
            color switch
            {
                Color.Red => "Red",
                Color.Green => "Green",
                Color.Blue => "Blue",
                _ => throw new NotImplementedException()
            };

        internal class User
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }

        internal static decimal ComputeDiscount(decimal price, User user) =>
            user switch
            {
                { Age: 10 } => price * 0.6M,
                { Age: 18 } => price * 0.5M,
                { Age: 80 } => price * 0.7M,
                _ => price
            };

        public static string getCongratsPhrase(string firstName, string surName)
            => (firstName, surName) switch
            {
                ("Jane", "Austen") => "Jane Austen is awesome",
                ("Clarice", "Linspector") => "Jane Austen is awesome",
                _ => "I don't know who are you, but welcome."
            };
    }

}