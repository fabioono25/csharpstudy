using System.Collections.Generic;

namespace CSharpStudy.CSharp4_0
{
    public class CovariantContravariantGenericTypesTest
    {
        public static void ExecuteExample()
        {
            // It'll work because now, IEnumerable supports covariance
            IEnumerable<Manager> mg = GetManager();
            IEnumerable<Employee> em = mg;

            // List is not covariant in T
            List<Manager> mg2 = new List<Manager>();
            //List<Employee> em2 = mg2; // CS0029: error of implicit conversion
        }

        public static IEnumerable<Manager> GetManager()
        {
            IEnumerable<Manager> manager = null;

            return manager;
        }
    }

    public class Employee
    {
    }

    public class Manager : Employee
    {
    }
}