using System.Collections;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CSharpStudy.Tests.Mentoring.Fundamentals
{
    public class Fundamentals
    {
        private readonly ITestOutputHelper output;

        public Fundamentals(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void DataTypes()
        {
            // Value types
            int i = 0;
            double d = 0.0;
            decimal dec = 0.0m;
            bool b = false;
            char c = 'c';

            // Reference types
            string s = "string";
            object o = new object();

            // boxing
            int i2 = 1;
            object o2 = i2;

            // unboxing
            int i3 = (int)o2;
        }

        [Fact]
        public void Collections()
        {
            // ArrayLists 
            var car1 = new Car();
            car1.Make = "Make Test";
            car1.Model = "Model Test";

            var book1 = new Book();
            book1.Title = "Book Test";
            book1.Author = "Author Test";

            // ArrayLists: dynamically sized
            var arr1 = new ArrayList();
            arr1.Add(car1);
            arr1.Add(book1);
            arr1.Add(book1);

            output.WriteLine("Test Array: ", arr1.ToString());

            Assert.Equal(3, arr1.Count);
        }

        [Fact]
        public void WorkingWithArrays()
        {
            // Arrays: fixed size
            var arr2 = new object[3];
            arr2[0] = "Test";
            arr2[1] = 1;
            arr2[2] = new Car();

            //Assert.Equal(3, arr2.Length);

            // Arrays: multi-dimensional
            var arr3 = new int[2, 2];
            arr3[0, 0] = 1;
            arr3[0, 1] = 2;
            arr3[1, 0] = 3;
            arr3[1, 1] = 4;

            // Arrays: jagged
            var arr4 = new int[2][];
            arr4[0] = new int[2];
            arr4[1] = new int[3];
            arr4[0][0] = 1;
            arr4[0][1] = 2;
            arr4[1][0] = 3;
            arr4[1][1] = 4;
            arr4[1][2] = 5;
            
            var names = new string[] { "John", "Mary", "Bob" };

            // other way to declare an array
            var names2 = new[] { "John", "Mary", "Bob" };

            // create a local function
            string ReverseString(string message)
            {
                var messageArray = message.ToCharArray();
                Array.Reverse(messageArray);
                return new string(messageArray);
            }

            var x = ReverseString("Hello World");
        }

        [Fact]
        public void WorkingWithStrings()
        {
            var s1 = "Hello World";
            var s2 = "Hello World";

            Assert.True(s1 == s2);
            Assert.True(s1.Equals(s2));
            Assert.True(s1.Equals(s2, System.StringComparison.OrdinalIgnoreCase));

            var s3 = "Hello";
            var s4 = "World";

            var s5 = s3 + " " + s4;
            var s6 = string.Format("{0} {1}", s3, s4);
            var s7 = $"{s3} {s4}";

            Assert.Equal(s5, s6);
            Assert.Equal(s5, s7);

            var s8 = "Hello World";
            var s9 = s8.Substring(6);
            var s10 = s8.Substring(0, 5);

            Assert.Equal("World", s9);
            Assert.Equal("Hello", s10);

            var s11 = "Hello World";
            var s12 = s11.Replace("World", "C#");

            Assert.Equal("Hello C#", s12);

            var s13 = "Hello World";
            var s14 = s13.Remove(5);

            Assert.Equal("Hello", s14);

            var s15 = "Hello World";
            var s16 = s15.Remove(0, 6);

            Assert.Equal("World", s16);

            var s17 = "Hello World";
            var s18 = s17.Insert(5, "C#");

            Assert.Equal("HelloC# World", s18);

            var s19 = "Hello World";
            var s20 = s19.Insert(0, "C# ");

            Assert.Equal("C# Hello World", s20);

            var s21 = "Hello World";
            var s22 = s21.PadLeft(15);

            Assert.Equal("     Hello World", s22);

            var s23 = "Hello World";
            var s24 = s23.PadRight(15);

            Assert.Equal("Hello World     ", s24);

            var s25 = "Hello World";
            var s26 = s25.ToLower();

            Assert.Equal("hello world", s26);

            var s27 = "Hello World";
            var s28 = s27.ToUpper();

            Assert.Equal("HELLO WORLD", s28);

            var s29 = "Hello World";
            var s30 = s29.Trim();

            Assert.Equal("Hello World", s30);

            // Format string
            var brand = "Honda";
            var model = "Civic";
            var myString = string.Format("Make: {0}, Model: {1}", brand, model);  // old way
            var myString2 = $"Make: {brand}, Model: {model}";  // new way

            var formatCurrency = $"{123.45:C}";  // $123.45
            var formatDecimal = $"{123:D}";  // 123
            var formatExponential = $"{123.456789:E}";  // 1.234568E+002
            var formatFixedPoint = $"{123.456789:F}";  // 123.46
            var formatGeneral = $"{123.456789:G}";  // 123.456789
            var formatNumber = $"{123456789:N}";  // 123,456,789.00
            var formatPercent = $"{0.123:P}";  // 12.30 %
            var formatHexadecimal = $"{255:X}";  // FF
            var formatPhone = $"{1234567890:(###) ###-####}";  // (123) 456-7890

            // working with new buckets, when working with strings, it is heavy. Solution: StringBuilder
            var x = new StringBuilder();
            x.Append("Hello");
            x.Append(" ");
            x.Append("World");
        }

        [Fact]
        public void WorkingWithDatesAndTimes()
        {
            var now = DateTime.Now;         // local time
            var today = DateTime.Today;     // local time
            var utcNow = DateTime.UtcNow;   // UTC time

            // difference between UTC and local time: UTC is the time at the prime meridian (Greenwich, England)
            // UTC is 0 hours offset from Greenwich Mean Time (GMT)
            // UTC is the standard time used by most computers and networks

            var shortDate = now.ToShortDateString();
            var shortTime = now.ToShortTimeString();
            var longDate = now.ToLongDateString();
            var longTime = now.ToLongTimeString();

            var tomorrow = now.AddDays(1);
            var yesterday = now.AddDays(-1);

            var dayOfWeek = now.DayOfWeek;

            var day = now.Day;
            var month = now.Month;
            var year = now.Year;

            var hour = now.Hour;
            var minute = now.Minute;
            var second = now.Second;
            var millisecond = now.Millisecond;

            var date = new DateTime(2018, 1, 1);
            var date2 = new DateTime(2018, 1, 1, 9, 30, 0);

            var date3 = DateTime.Parse("1/1/2018");
            var date4 = DateTime.Parse("1/1/2018 9:30:00 AM");

            var date5 = DateTime.ParseExact("1/1/2018", "M/d/yyyy", null);
            var date6 = DateTime.ParseExact("1/1/2018 9:30:00 AM", "M/d/yyyy h:mm:ss tt", null);

            var date7 = DateTime.ParseExact("2018-01-01T09:30:00", "yyyy-MM-ddTHH:mm:ss", null);

            var date8 = DateTime.ParseExact("2018-01-01T09:30:00Z", "yyyy-MM-ddTHH:mm:ssK", null);

            var date9 = DateTime.ParseExact("2018-01-01T09:30:00-03:00", "yyyy-MM-ddTHH:mm:ssK", null);

            var date10 = DateTime.ParseExact("2018-01-01T09:30:00-03:00", "yyyy-MM-ddTHH:mm:sszzz", null);

            var date12 = DateTime.ParseExact("2018-01-01T09:30:00-03:00", "yyyy-MM-ddTHH:mm:sszzz", System.Globalization.CultureInfo.InvariantCulture);

            var date13 = DateTime.ParseExact("2018-01-01T09:30:00-03:00", "yyyy-MM-ddTHH:mm:sszzz",
                System.Globalization.CultureInfo.InvariantCulture);

            var myBirthDay = DateTime.Parse("06/06/1981 19:34");
            var myAge = DateTime.Now.Subtract(myBirthDay);
            var days = myAge.Days;
            var years = days / 365;
        }

        [Fact]
        public void WorkingWithLINQ()
        {
            var carModels = new string[] { "Civic", "Accord", "Camry", "Corolla", "Mustang", "F-150", "Cruze", "Malibu", "Altima", "Sentra" };
            var carMakes = new string[] { "Toyota", "Honda", "Ford", "Chevrolet", "Nissan" };

            var cars = new List<Car>();

            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                var car = new Car
                {
                    Model = carModels[random.Next(carModels.Length)],
                    Make = carMakes[random.Next(carMakes.Length)]
                };

                cars.Add(car);
            }

            // LINQ query:
            var mustang = from car in cars
                          where car.Make == "Mustang"
                              select car;

            // LINQ method:
            var mustang2 = cars.Where(c => c.Make == "Mustang").OrderBy(c => c.Model);
        }

        [Fact]
        public async Task WorkingWithEvents()
        {
            // Using TaskCompletionSource to synchronize the test with the timer
            var tcs = new TaskCompletionSource<bool>();

            var myTimer = new System.Timers.Timer(2000);
            myTimer.Elapsed += (sender, e) =>
            {
                output.WriteLine("Elapsed: {0:HH:mm:ss.fff}", e.SignalTime);

                // Set the task completion source to indicate that the asynchronous work is done
                tcs.SetResult(true);
            };

            myTimer.Start();

            // Wait for the timer to elapse or a timeout (e.g., 5 seconds)
            var timeoutTask = Task.Delay(5000);
            var completedTask = await Task.WhenAny(tcs.Task, timeoutTask);

            Assert.Equal(tcs.Task, completedTask); // Ensure the timer completed successfully
        }

        class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
        }

        class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
        }
    }
}
