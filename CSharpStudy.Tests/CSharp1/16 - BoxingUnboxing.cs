using System.Collections;

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
        public void Boxing_CreatesCopy()
        {
            int original = 42;
            object boxed = original; // Box

            original = 99; // Change stack value

            int unboxed = (int)boxed; // Unbox

            Assert.Equal(42, unboxed); // Boxed copy remained 42
        }

        [Fact]
        public void Unboxing_WrongType_ThrowsException()
        {
            int i = 123;
            object o = i; // boxing

            // Unboxing to incompatible type throws InvalidCastException
            Assert.Throws<InvalidCastException>(() =>
            {
                double d = (double)o;
            });
        }
    }
}
