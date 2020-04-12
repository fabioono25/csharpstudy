using System;
using System.Collections.Generic;

namespace CSharpStudy.CSharp2_0
{
    public class CovarianceContravariance
    {
        public static void ExecuteExample()
        {
            //covariance: object of a more derived type is assigned to an object of a less derived type
            string str = "asd";
            object obj = str;
            IEnumerable<string> strings = new List<string>();

            //covariance in arrays occurs since version 1.0, but it's not safe
            object[] array = new String[10];

            //contravariance: An object that is instantiated with a less derived type argument
            // is assigned to an object instantiated with a more derived type argument.
            // Assignment compatibility is reversed
            Action<object> actObject = SetObject;
            Action<string> actString = actObject;
        }        

        static void SetObject(object o) { }        
    }
}
