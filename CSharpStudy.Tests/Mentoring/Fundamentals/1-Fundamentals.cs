using System.Collections;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CSharpStudy.Tests.Mentoring._1_Fundamentals
{
    public class Fundamentals
    {
        private readonly ITestOutputHelper output;

        public Fundamentals(ITestOutputHelper output)
        {
            this.output = output;
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
