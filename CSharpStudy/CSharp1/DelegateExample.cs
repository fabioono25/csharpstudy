using System;
using System.Collections.Generic;

namespace CSharpStudy.CSharp1
{
    public class DelegateExample
    {
        //defining a delegate type
        public delegate void Del(string message);

        //creating a method for a delegate
        public static void DelegateMethod(string message) => Console.WriteLine(message);

        public static void ExecuteExample(){

            //instantiate the delegate
            Del handler = DelegateMethod;

            //call the delegate
            handler("hello!!");
        }
    }
}