using System.Reflection;

namespace CSharpStudy.CSharp1_2
{
    public class ReflectionTest
    {
        public static void ExecuteExample()
        {
            int age = 29;
            Type ageType = age.GetType();
            Console.WriteLine(ageType); //System.Int32

            //Gets the location regarding the process executable in the default application domain
            string path = Assembly.GetEntryAssembly().Location;

            //Gets the assembly that contains the code that is currently executing.
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                Console.WriteLine($"Class {type.Name}"); //print all class names
            }
        }
    }
}