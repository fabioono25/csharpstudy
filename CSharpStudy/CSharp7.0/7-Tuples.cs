using System;
using static System.Console;

namespace CSharpStudy.CSharp7
{
    public class Tuples
    {
        public static void ExecuteExample()
        {
            //return tuple
            var author = FindAuthor();
            WriteLine($"Name: {author.Item1} - Age: {author.Item2} - Alive: {author.Item3}");            

            //naming the return of a tuple
            (string name, int age, bool isAlive) author2 = FindAuthor();
            WriteLine($"Name: {author2.name} - Age: {author2.age} - Alive: {author2.isAlive}");            

            //calling a method that will return a named tuple
            var author3 = FindAuthor3();
            WriteLine($"Name: {author3.name} - Age: {author3.age} - Alive: {author3.isAlive}");            
        }

        public static (double vezesDois, double elevadoDois, double maisVinte) CalcularValores(int valor)
        {
            return (valor * 2, System.Math.Pow(valor, 2), valor + 20);
        }

        //example of tuple return
        static (string, int, bool) FindAuthor() {
            
            var firstName = "John";
            var age = 32;
            var alive = true;

            //tuple literal
            return (firstName, age, alive); 
        }

        //example of tuple with named return
        static (string name, int age, bool isAlive) FindAuthor3() {
            
            var firstName = "John";
            var age = 32;
            var alive = true;

            return (firstName, age, alive); 
        }        
    }
}