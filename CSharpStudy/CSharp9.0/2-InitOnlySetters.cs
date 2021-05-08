using System;

namespace CSharpStudy.CSharp9
{
    public class InitOnlySetters
    {
        public static void ExecuteExample()
        {
            //var testA = new Test(DateTime.Now, 120);
            
            // error: with the current structure, the atribution of values to the propertis is possible via constructor
            // var testB = new Test { 
            //     ReleaseDate = DateTime.Now,
            //     Duration = DateTime.Now,
            // };

            // with the init set property, the possibibility is expanded beyond the constructor
            var test2A = new Test2 {
                ReleaseDate = DateTime.Now,
                DurationMinutes = 60
            };

            //test2A.DurationMinutes = 20; // Error: just assigned on initialization
        }
    }

    // normal way
    internal class Test {
        public DateTime ReleaseDate {get;}
        public int DurationMinutes {get; }

        public Test(DateTime releaseDate, int duration)
        {
            ReleaseDate = releaseDate;
            DurationMinutes = duration;
        }        
    }

    // using init setter
    internal class Test2 {
        public DateTime ReleaseDate {get; init;}
        public int DurationMinutes {get; init; }

        public Test2(){}

        public Test2(DateTime releaseDate, int durationMinutes)
        {
            ReleaseDate = releaseDate;
            DurationMinutes = durationMinutes;
        }
    }    
}
