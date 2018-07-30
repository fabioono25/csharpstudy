using System;

namespace CSharpStudy.CSharp1
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/event-pattern
    public class EventExample
    {
        public event EventHandler<FileListArgs> Progress;

        public static void ExecuteExample(){
            //Progress?.Invoke(this, new FileListArgs());

            EventHandler<FileListArgs> onProgress = (sender, EventArgs) => Console.WriteLine(EventArgs.FoundFile);

            //lister
        }
    }

    public class FileListArgs
    {
    }
}