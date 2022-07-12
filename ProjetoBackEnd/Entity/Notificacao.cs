using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Notificacao
    {
        public int CodigoNotificacao { get; set; }
        public Pessoa Remetente { get; set; }
        public Pessoa Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataEnvio { get; set; }

        //Variáveis de controle: feito por Adiposo
        /*Esta variavel foi criada pois no dataBind da lista de
         notificações, ela "puxava" o objeto inteiro e não o nome do
         remetente*/
        public string NomeRemetente { get; set; }

        public string NomeDestinatario { get; set; }

        public Notificacao() { }
        public Notificacao(int codigoNotificacao,Pessoa remetente, Pessoa destinatario, string assunto, string  conteudo, DateTime dataEnvio)
        {
            CodigoNotificacao = codigoNotificacao;
            Remetente = remetente;
            Destinatario = destinatario;
            Assunto = assunto;
            Conteudo = conteudo;
            DataEnvio = dataEnvio;
        }
    }
}
