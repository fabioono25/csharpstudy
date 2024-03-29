﻿using System.Collections;

namespace CSharpStudy.Tests.CSharp1
{
    public class BoxingUnboxing
    {
        /// <summary>
        /// Boxing: convert a value type into a reference type.
        /// Unboxing: conversion from the reference type to a value type.
        /// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing
        /// </summary>
        [Fact]
        public void ExecuteExample()
        {
            Console.WriteLine("C# 1.0 - Boxing and Unboxing Examples");

            int i = 123;
            object o = i; //boxing
            int x = (int)o; //unboxing

            int valueTest = 10;
            ArrayList arrayTest = new ArrayList();
            arrayTest.Add(valueTest); //boxing
            int outArray = (int)arrayTest[0]; //unboxing

            Console.ReadKey();
        }
    }
}
