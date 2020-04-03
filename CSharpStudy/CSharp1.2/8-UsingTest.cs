using System;
using System.IO;

namespace CSharpStudy.CSharp1_2
{
    public class UsingTest {
        public static void ExecuteExample()
        {
            //without using
            {
                StreamReader testReader = new StreamReader(@"/home/ono/Documents/study/csharpstudy/CSharpStudy/CSharp1.2/test.txt");
                
                try
                {
                    Console.Write(testReader.ReadToEnd());
                }
                finally
                {
                    if (testReader != null)
                        testReader.Dispose();
                }
            }

            //with using
            using (var testReader = new StreamReader(@"/home/ono/Documents/study/csharpstudy/CSharpStudy/CSharp1.2/test.txt"))
            {
                Console.Write(testReader.ReadToEnd());
            }
        }
    }
}