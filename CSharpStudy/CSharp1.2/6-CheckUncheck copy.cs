using System;

namespace CSharpStudy.CSharp1_2
{
    public class CheckUncheck {
        public static void ExecuteExample()
        {
            byte number = 255;

            Console.WriteLine(byte.MaxValue); //255
            
            number += 1;
            Console.WriteLine(number); //0

            number += 1;
            Console.WriteLine(number); //1

            try {
                unchecked
                {
                    number = byte.MaxValue;
                    number += 1; //0
                }

            } catch(OverflowException){
                Console.WriteLine("This exception will not be thrown");
            }

            try {
                checked
                {
                    number = byte.MaxValue;
                    number += 1; //0
                }

            } catch(OverflowException){
                Console.WriteLine("An overflow exception was just ocurred!");
            }
        }
    }
}