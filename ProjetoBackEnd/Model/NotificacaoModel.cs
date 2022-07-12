using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class NotificacaoModel
    {
        private string strConexao;

        public NotificacaoModel(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public bool InserirNotificacao(Notificacao notificacao)
        {
            using (NotificacaoData data = new NotificacaoData(strConexao))
            {
                return data.Inserir(notificacao);
            }
        }

        public bool Editar(Notificacao notificacao)
        {
            using (NotificacaoData data = new NotificacaoData(strConexao))
            {
                return data.Editar(notificacao);
            }
        }

        public bool ExcluirNotificacao(Notificacao notificacao)
        {
            using (NotificacaoData data = new NotificacaoData(strConexao))
            {
                return data.Excluir(notificacao);
            }
        }

        public Notificacao ObterNotificacao(int codigo)
        {
            using (NotificacaoData data = new NotificacaoData(strConexao))
            {
                return data.ObterNotificacaoID(codigo);
            }
        }

        public List<Notificacao> ListarNotificacao()
        {
            using (NotificacaoData data = new NotificacaoData(strConexao))
            {
                return data.Listar();
            }
        }

        public List<Notificacao> ListarDestinatario(int codigo)
        {
            using (NotificacaoData data = new NotificacaoData(strConexao))
            {
                return data.ListarDestinatario(codigo);
            }
        }

        public List<Notificacao> ListarRemetente(int codigo)
        {
            using (NotificacaoData data = new NotificacaoData(strConexao))
            {
                return data.ListarRemetente(codigo);
            }
        }

        public List<Notificacao> Pesquisar(int criterio, string pesquisa)
        {
            using (NotificacaoData data = new NotificacaoData(strConexao))
            {
                return data.Pesquisar(criterio, pesquisa);
            }
        }
    }
}
