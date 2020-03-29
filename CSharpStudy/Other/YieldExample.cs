using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CSharpStudy.CSharp1
{
    public class YieldExample
    {
        public static void ExecuteExample()
        {
            // Display powers of 2 up to the exponent of 8:
            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }

            var theGalaxies = new Galaxies();
            foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
            {
                Console.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
            }

            X();
        }

        //using attribute
        [Conditional("DEBUG")]
        public static void X() => Console.WriteLine("hi");

        public static IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                yield return result * number;
            }
        }

        public class Galaxies
        {

            public IEnumerable<Galaxy> NextGalaxy
            {
                get
                {
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                }
            }

        }

        public class Galaxy
        {
            public String Name { get; set; }
            public int MegaLightYears { get; set; }
        }
    }
}