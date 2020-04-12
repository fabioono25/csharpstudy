using System;
using System.Collections;

namespace CSharpStudy.CSharp1
{
    public class BoxingUnboxing
    {
        /// <summary>
        /// Boxing: convert a value type into a type object (reference type).
        /// Unboxing: conversion from the type object (reference type) to a value type.
        /// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing
        /// </summary>
        public static void ExecuteExample()
        {
            Console.WriteLine("C# 1.0 - Boxing and Unboxing Examples");

            int i = 123;
            object o = i; //boxing
            int x = (int) o; //unboxing

            int valueTest = 10;
            ArrayList arrayTest = new ArrayList();
            arrayTest.Add(valueTest); //boxing
            int outArray = (int)arrayTest[0]; //unboxing

            Console.ReadKey();
        }
    }
}
