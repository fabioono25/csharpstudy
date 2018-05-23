using System;

namespace CSharpStudy
{
    public class MailService{

        public void OnVideoEncoded(object source, VideoEventArgs args){
            System.Console.WriteLine("MailService: sending an email - Title: " + args.Video.Title);
        }

    }

    public class MessageService {

        public void OnVideoEncoded(object source, VideoEventArgs args){
            System.Console.WriteLine("MessageService: sending a text message - Title: " + args.Video.Title);    
        }

    }
}
