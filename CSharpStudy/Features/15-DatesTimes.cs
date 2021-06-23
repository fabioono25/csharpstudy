using System;
using System.Globalization;

namespace CSharpStudy.CSharp9.Features
{
    public class DatesTimes
    {
        public static void ExecuteExample()
        {
            var x = DateTime.Now;
            var y = DateTime.UtcNow;
            var z = DateTimeOffset.Now;
            var w = DateTimeOffset.UtcNow;
            DateTime dt = new DateTime(2000, 2, 3,
                10, 20, 30);

            Console.WriteLine(dt.Year);         // 2000
            Console.WriteLine(dt.Month);        // 2
            Console.WriteLine(dt.Day);          // 3
            Console.WriteLine(dt.DayOfWeek);    // Thursday
            Console.WriteLine(dt.DayOfYear);    // 34

            Console.WriteLine(dt.Hour);         // 10
            Console.WriteLine(dt.Minute);       // 20
            Console.WriteLine(dt.Second);       // 30
            Console.WriteLine(dt.Millisecond);  // 0
            Console.WriteLine(dt.Ticks);        // 630851700300000000
            Console.WriteLine(dt.TimeOfDay);    // 10:20:30  (returns a TimeSpan)

            TimeSpan ts = TimeSpan.FromMinutes(90);
            Console.WriteLine(dt.Add(ts));
            Console.WriteLine(dt + ts);             // same as above

            DateTime thisYear = new DateTime(2015, 1, 1);
            DateTime nextYear = thisYear.AddYears(1);
            TimeSpan oneYear = nextYear - thisYear;

            DateTime dt11 = new DateTime(2000, 1, 1, 10, 20, 30, DateTimeKind.Local);
            DateTime dt22 = new DateTime(2000, 1, 1, 10, 20, 30, DateTimeKind.Utc);
            Console.WriteLine(dt11 == dt22);          // True
            DateTime local = DateTime.Now;
            DateTime utc = local.ToUniversalTime();
            Console.WriteLine(local == utc);        // False

            DateTime d = new DateTime(2015, 12, 12);  // Unspecified
            DateTime utc2 = DateTime.SpecifyKind(d, DateTimeKind.Utc);
            Console.WriteLine(utc);            // 12/12/2015 12:00:00 AM

            DateTimeOffset local2 = DateTimeOffset.Now;
            DateTimeOffset utc3 = local.ToUniversalTime();

            Console.WriteLine(local2.Offset);   // -06:00:00 (in Central America)
            Console.WriteLine(utc3.Offset);     // 00:00:00

            Console.WriteLine(local2 == utc3);                 // True
            Console.WriteLine(local2.EqualsExact(utc3));      // False

            TimeZoneInfo zone = TimeZoneInfo.Local;
            Console.WriteLine(zone.StandardName);      // Pacific Standard Time
            Console.WriteLine(zone.DaylightName);      // Pacific Daylight Time
            DateTime dt1 = new DateTime(2019, 1, 1);   // DateTimeOffset works, too
            DateTime dt2 = new DateTime(2019, 6, 1);
            Console.WriteLine(zone.IsDaylightSavingTime(dt1));     // True
            Console.WriteLine(zone.IsDaylightSavingTime(dt2));     // False
            Console.WriteLine(zone.GetUtcOffset(dt1));             // -08:00:00
            Console.WriteLine(zone.GetUtcOffset(dt2));             // -07:00:00

            DateTime.Now.IsDaylightSavingTime();
        }
    }
}
