namespace CSharpStudy.Tests.CSharp1
{

    /**
    * Garbage collection is an automatic memory management feature in C# that relieves developers from manually allocating and deallocating memory for objects. 
    * It tracks and identifies objects that are no longer in use and frees up their memory so that it can be reused by other objects in the program.
    * https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals
    **/

    public class GarbageCollectionTest
    {
        public static List<string> GlobalList = new List<string>(); // Generation 0 static list object

        [Fact]
        public void ExecuteExample()
        {
            /// EXAMPLES OF GENERATION 0:
            for (int i = 0; i < 1000; i++)
            {
                var obj1 = new object(); // object created and used in each interaction
            }

            // another example of Gen 0:
            var obj2 = new object();
            obj2 = null; // object created and not used anymore

            // Creating and collecting objects in Generation 0
            for (int i = 0; i < 10000; i++)
            {
                var obj = new int[100]; // Generation 0 array object
                                        // Use the object...
            }

            /// EXAMPLES OF GENERATION 1:
            var obj3 = new object(); // Gen 0 object
                                     // some operation in obj3
            var obj4 = new object(); // Gen 0 object
                                     // some operation in obj4

            // obj3 and obj4 are no longer used, but have not been collected yet. They can be promoted to Generation 1.

            // another example of Gen 1:
            List<int> list = new List<int>(); // Generation 0 list object

            for (int i = 0; i < 10000; i++)
            {
                list.Add(i); // Adding elements to the list
            }
            // After some time, the list object may be promoted to Generation 1

            /// EXAMPLES OF GENERATION 1:
            var longLivedObj = new object(); // Generation 0 object
                                             // Perform operations on longLivedObj repeatedly...
                                             // After multiple garbage collection cycles, longLivedObj may be promoted to Generation 2

            // another example of Gen 2:
            SomeMethod();
            // After multiple garbage collection cycles, GlobalList may be promoted to Generation 2

            /// COLLECTING:

            // Forcing the GC to collect some object:
            var obj5 = new object();
            // obj3 is no longer used, but has not been collected yet.
            obj5 = null;
            GC.Collect(1); // collect objects in generation 1

            // using Dispose method
            var obj6 = new BinaryReader(null);
            obj6.Dispose(); // dispose the object
            GC.SuppressFinalize(obj6); // suppress the finalization of the object

            // using using statement
            using (var obj7 = new BinaryReader(null))
            {
                // use the object
            } // dispose the object
        }

        public static void SomeMethod()
        {
            // Adding elements to the global list
            for (int i = 0; i < 100000; i++)
            {
                GlobalList.Add("Item " + i);
            }
        }
    }
}
