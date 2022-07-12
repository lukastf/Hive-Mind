using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Boleto
    {
        public int CodigoBoleto { get; set; }
        public Unidade Unidade { get; set; }
        public decimal Valor { get; set; }
        public string DataGeracao { get; set; }
        public string DataValidade { get; set; }
        public string DataPagamento { get; set; }
        public string BancoReferente { get; set; }

        public string Localizacao { get; set; }

        public Boleto() { }
        public Boleto(int codigoBoleto, Unidade unidade, decimal valor, string dataGeracao, string dataValidade, string dataPagamento, string bancoReferente)
        {
            CodigoBoleto = codigoBoleto;
            Unidade = unidade;
            Valor = valor;
            DataGeracao = dataGeracao;
            DataValidade = dataValidade;
            DataPagamento = dataPagamento;
            BancoReferente = bancoReferente;
        }
    }
}
