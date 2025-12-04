namespace CSharpStudy.Tests.CSharp1
{
    public delegate void Notify(string message);

    public class Process
    {
        public event Notify OnCompleted;

        public void Start()
        {
            // Simulate work
            OnCompleted?.Invoke("Process finished!");
        }
    }

    public class EventsTest
    {
        [Fact]
        public void Event_Raised_WhenProcessCompletes()
        {
            var process = new Process();
            string receivedMessage = null;

            process.OnCompleted += msg => receivedMessage = msg;
            process.Start();

            Assert.Equal("Process finished!", receivedMessage);
        }
    }
}