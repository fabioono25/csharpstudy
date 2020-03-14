using System;
using System.Threading;

namespace CSharpStudy
{
    // public class Text: PresentationObject{
    //     public int FontSize { get; set; }
    //     public string FontName { get; set; }

    //     public void AddHyperlink(string url){
    //         System.Console.WriteLine("add link to {0}", url);
    //     }
    // }

    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    public class VideoEncoder
    {

        //1 - define a delegate (signature of the method in the subscriber)
        //2 - define an event based on that delegate
        //3 - raise the event

        //public delegate void VideoEncondedEventHandler(object source, EventArgs e);
        //public delegate void VideoEncondedEventHandler(object source, VideoEventArgs e);

        //EventHandler or EventHandler<TEventArgs>
        //public event VideoEncondedEventHandler VideoEncoded;
        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            System.Console.WriteLine("encoding video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        //to raise an event, we need a method protected, void, virtual, and with On - good practice
        protected virtual void OnVideoEncoded(Video video)
        {

            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() { Video = video });
            //VideoEnconded(this, EventArgs.Empty);
        }
    }

}
