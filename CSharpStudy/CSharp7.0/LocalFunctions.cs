using System;
using System.Threading;

namespace CSharpStudy.CSharp7
{
    public class LocalFunctions
    {
        public static void ExecuteExample()
        {

            //cannot use access modifiers in local functions
            void ExibirHorarioAtual()
            {
                Console.WriteLine($"Horário atual: {DateTime.Now.ToString("HH:mm:ss")}");
            }

            ExibirHorarioAtual();

            Thread.Sleep(4000);

            ExibirHorarioAtual();
        }
    }
}