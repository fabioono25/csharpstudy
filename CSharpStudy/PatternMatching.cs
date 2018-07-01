using System;

namespace CSharpStudy
{
    public class PatternMatching
    {
        public static void ExecuteExample(){
            
            var dolar = new CotacaoDolar();
            dolar.DataCotacao = new DateTime(2018, 4, 29);
            dolar.ValorComercial = 3.444;
            dolar.ValorTurismo = 3.568;
            ExibirInformacoesCotacao(dolar);

            var euro = new CotacaoEuro();
            euro.DataCotacao = new DateTime(2018, 5, 22);
            euro.ValorCotacao = 4.555;
            ExibirInformacoesCotacao(euro);
        }

        public static void ExibirInformacoesCotacao(Cotacao cotacao){
            double valorCotacao = 0;

            if (cotacao is CotacaoDolar dolar)
                valorCotacao = dolar.ValorComercial;
            else if (cotacao is CotacaoEuro euro)
                valorCotacao = euro.ValorCotacao;

            Console.WriteLine(new String('-', 40));
            Console.WriteLine($"Data: {cotacao.DataCotacao:dd/MM/yyyy}");
            Console.WriteLine($"Sigla: {cotacao.SiglaMoeda}");
            Console.WriteLine($"Moeda: {cotacao.NomeMoeda}");
            Console.WriteLine($"Valor: {valorCotacao:0.0000}");
        }
    }

    public abstract class Cotacao{
        public DateTime DataCotacao { get; set; }
        public virtual string SiglaMoeda { get; set; }
        public virtual string NomeMoeda { get; set; }
    }

    public class CotacaoDolar : Cotacao
    {
        public override string SiglaMoeda { get => "USD"; }
        public override string NomeMoeda { get => "Dólar Americano"; }
        public double ValorComercial {get; set;}
        public double ValorTurismo {get; set;}
    }

    public class CotacaoEuro : Cotacao
    {
        public override string SiglaMoeda { get => "EUR"; }
        public override string NomeMoeda { get => "Euro"; }

        public double ValorCotacao {get; set;}
    }

}