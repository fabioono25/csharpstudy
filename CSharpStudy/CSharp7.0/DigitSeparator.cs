using System;

namespace CSharpStudy.CSharp7
{
    public class DigitSeparator
    {
        private const int LETRA_Y_BIN = 0b01_01_10_01; //01011001 (binario) - 89 (decimal)
        private const int LETRA_Z_HEX = 0X5A; //5A (hexa) - 80 (decimal)
        private const int POLULACAO_ESTIMADA_BRASIL = 204_500_500;
        private const double RENDA_PER_CAPITA_BRASIL_USD = 11_208.08;

        public static void ExecuteExample()
        {

            Console.WriteLine($"Y Bin = {LETRA_Y_BIN}");
            Console.WriteLine($"Z Hex = {LETRA_Z_HEX}");
            Console.WriteLine($"População = {POLULACAO_ESTIMADA_BRASIL}");
            Console.WriteLine($"Renda per capita = {RENDA_PER_CAPITA_BRASIL_USD}");

            var double_test = 10_123_123.99;
            Console.WriteLine($"Double value = {double_test}");
        }
    }
}