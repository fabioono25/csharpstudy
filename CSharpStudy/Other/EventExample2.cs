namespace CSharpStudy.CSharp1
{
    public class EventExample2
    {
        //definindo um EventHandler para especificar o tipo do EventHandler
        public delegate void EventHandler();
        //cria uma instancia de um evento que pode armazenar metodos na sua lista de invocacao
        public static event EventHandler OnCalcular;
        public static void ExecuteExample()
        {
            //manipuladores de eventos
            OnCalcular += new EventHandler(Somar);
            OnCalcular += new EventHandler(Subtrair);
            OnCalcular += new EventHandler(Multiplicar);
            OnCalcular += new EventHandler(Multiplicar);

            //invoca o metodo
            OnCalcular.Invoke();
            Console.ReadLine();
        }

        private static void Multiplicar()
        {
            Console.WriteLine($"Multiplicacao 5 * 5 = {5 * 5}.");
        }

        private static void Subtrair()
        {
            Console.WriteLine($"Subtracao 5 - 5 = {5 - 5}.");
        }

        private static void Somar()
        {
            Console.WriteLine($"Soma 5 + 5 = {5 + 5}.");
        }
    }
}