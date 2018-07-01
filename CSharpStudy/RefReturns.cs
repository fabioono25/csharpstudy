using System;

namespace CSharpStudy
{
    public class RefReturns
    {
        private int _contador = 0;

        public void Incrementar() => _contador++;        

        public int ObterValorContador() => _contador;

        public ref int ObterContador() => ref _contador;

        public static void ExecuteExample() {
            var refRet = new RefReturns();
            refRet.Incrementar();
            refRet.Incrementar();
            refRet.Incrementar();
            Console.WriteLine(refRet.ObterValorContador()); //3

            var teste = refRet.ObterValorContador();
            teste++;
            Console.WriteLine(refRet.ObterValorContador()); //remains 3

            //ref int teste2 = refRet.ObterValorContador(); //cannot initialize a by-reference variable with a value

            //ref int teste2 = ref refRet.ObterValorContador(); //error

            ref int teste2 = ref refRet.ObterContador();
            teste2++;
            teste2++;

            Console.WriteLine(refRet.ObterValorContador()); //up to 5            
        }
    }
}