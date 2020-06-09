using System;
using System.Threading.Tasks;

namespace CSharpStudy.CSharp6
{
    public class AwaitCatchFinally
    {
        public static async void ExecuteExample()
        {
            Test2 test = null;

            try 
            {	        
                var x = test.Property;
            }
            catch (Exception)
            {
                await Logger.Error("exception logging");
            }
        }
    }

    public static class Logger {
        public static async Task Error(string message){}
    }

    internal class Test2{
        public int Property { get; set; }
    }    
}