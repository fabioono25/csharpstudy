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
            finally
            {
                await Logger.Info("finish execution");
            }
        }
    }

    public static class Logger {
        public static async Task Error(string message){}
        public static async Task Info(string message){}
    }

    internal class Test2{
        public int Property { get; set; }
    }    
}