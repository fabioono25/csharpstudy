using System.Threading.Tasks;

namespace CSharpStudy.CSharp7
{
    //um valor inteiro sera calculado em um primeiro momento, associado ao atributo privado _tempoEsperaInicial e 
    //utilizado para um intervalo de espera (via operacao Delay da classe Task)

    //execucoes posteriores farao com que apenas se devolva o resultado vinculado previamente a _tempoEsperaInicial
    public class ValueTasks2
    {
        public static void ExecuteExample()
        {
            Console.WriteLine("Criando a primeira task");
            var task1 = EsperaAleatoria();
            Console.WriteLine($"Retorno da primeira task: {task1.Result}.");

            Console.WriteLine("Criando a segunda task");
            var task2 = EsperaAleatoria();
            Console.WriteLine($"Retorno da segunda task: {task2.Result}.");

            Console.WriteLine("Criando primeira task antiga");
            var task3 = EsperaAleatoriaOld();
            Console.WriteLine($"Retorno da terceira task (antiga): {task3.Result}");

            Console.WriteLine("Criando segunda task antiga");
            var task4 = EsperaAleatoriaOld();
            Console.WriteLine($"Retorno da terceira task (antiga): {task4.Result}");

            Console.ReadKey();
        }

        private static int _tempoEsperaInicial;
        private static int _tempoEspera2;

        private static async ValueTask<int> EsperaAleatoria()
        {
            if (_tempoEsperaInicial == 0)
            {
                _tempoEsperaInicial = new Random().Next(5000, 10000);
                await Task.Delay(_tempoEsperaInicial);
            }

            return _tempoEsperaInicial;
        }

        private static async Task<int> EsperaAleatoriaOld()
        {
            if (_tempoEspera2 == 0)
            {
                _tempoEspera2 = new Random().Next(5000, 10000);
                await Task.Delay(_tempoEspera2);
            }

            return _tempoEspera2;
        }
    }
}