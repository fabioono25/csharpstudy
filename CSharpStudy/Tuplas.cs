using System;

namespace CSharpStudy
{
    public class Tuplas
    {
        public static void ExecuteExample(){
            (int, int, int, string) parvalores = (1,2,3,"item 1");
            Console.WriteLine(parvalores.Item1);
            Console.WriteLine(parvalores.Item4);

            var coord = (eixoX: 10, eixoY: 14);
            Console.WriteLine($"Eixo X: {coord.eixoX}.");
            Console.WriteLine($"Eixo Y: {coord.eixoY}.");

            var calculados = CalcularValores(2);
            Console.WriteLine($"Valor 2 x 2 = {calculados.vezesDois}");
            Console.WriteLine($"Valor 2 elevado a 2 = {calculados.elevadoDois}");
            Console.WriteLine($"Valor 2 mais 20 = {calculados.maisVinte}");

            //tuple desconstruction example
            (double multiplicado, double elevado, double vinte) = CalcularValores(10);
            Console.WriteLine($"Valor 2 x 2 = {multiplicado}");
            Console.WriteLine($"Valor 2 elevado a 2 = {elevado}");
            Console.WriteLine($"Valor 2 mais 20 = {vinte}");                
        }

        public static (double vezesDois, double elevadoDois, double maisVinte) CalcularValores(int valor){
            return (valor * 2, System.Math.Pow(valor, 2), valor + 20);
        }
    }
}