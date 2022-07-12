using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using ProjetoBackEnd.Entity;

namespace ProjetoBackEnd.Data
{
    class NotificacaoData : Conexao
    {
        string stringConexao = "";
        public NotificacaoData(string strConexao)
            : base(strConexao) 
        {
            this.stringConexao = strConexao;
        }

        public bool Inserir(Notificacao notificacao)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"exec addNotificacao @assunto, @conteudo, @id_remetente, @id_destinatario";

                Cmd.Parameters.AddWithValue("@id_remetente", notificacao.Remetente.Codigo);
                Cmd.Parameters.AddWithValue("@id_destinatario", notificacao.Destinatario.Codigo);
                Cmd.Parameters.AddWithValue("@assunto", notificacao.Assunto);
                Cmd.Parameters.AddWithValue("@conteudo", notificacao.Conteudo);

                Cmd.ExecuteNonQuery();

                ok = true;
            }
            catch { }
            return ok;
        }

        public bool Editar(Notificacao notificacao)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText =@"";

                Cmd.Parameters.AddWithValue("@assunto", notificacao.Assunto);

                Cmd.ExecuteNonQuery();

                ok = true;
            }
            catch { }

            return ok;
        }

        public bool Excluir(Notificacao notificacao)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" delete from notificacoes where id_notificacao = @id_notificacao";

                Cmd.Parameters.AddWithValue("@id_notificacao", notificacao.CodigoNotificacao);

                Cmd.ExecuteNonQuery();
                ok = true;
            }
            catch { }

            return ok;
        }

        public Notificacao ObterNotificacaoID(int codigo)
        {
            Notificacao notificacao = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from notificacoes where id_notificacao = @id_notificacao";

                Cmd.Parameters.AddWithValue("@id_notificacao", codigo);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    notificacao = CadastrarNotificacao(Dr);
                }
            }
            catch { }

            return notificacao;
        }

        private Notificacao CadastrarNotificacao(SqlDataReader Dr)
        {
            Notificacao notificacao = new Notificacao();

            Pessoa remetente = new Pessoa();
            Pessoa destinatario = new Pessoa();

            PessoaData pessoaData = new PessoaData(stringConexao);
            
            notificacao.CodigoNotificacao = Dr.GetInt32(0);
            notificacao.Remetente = pessoaData.ObterPessoaID(Dr.GetInt32(1));
            notificacao.NomeRemetente = notificacao.Remetente.Nome;
            //notificacao.Destinatario = pessoaData.ObterPessoa(Dr.GetInt32(2));
            notificacao.Assunto = Dr.GetString(3);
            notificacao.Conteudo = Dr.GetString(4);
            notificacao.DataEnvio = Dr.GetDateTime(5);


            return notificacao;
        }

        private Notificacao CadastrarNotificacao2(SqlDataReader Dr)
        {
            Notificacao notificacao = new Notificacao();

            Pessoa remetente = new Pessoa();
            Pessoa destinatario = new Pessoa();

            PessoaData pessoaData = new PessoaData(stringConexao);

            notificacao.CodigoNotificacao = Dr.GetInt32(0);
            notificacao.Destinatario = pessoaData.ObterPessoaID(Dr.GetInt32(2));
            notificacao.NomeDestinatario = notificacao.Destinatario.Nome;
            //notificacao.Destinatario = pessoaData.ObterPessoa(Dr.GetInt32(2));
            notificacao.Assunto = Dr.GetString(3);
            notificacao.Conteudo = Dr.GetString(4);
            notificacao.DataEnvio = Dr.GetDateTime(5);


            return notificacao;
        }

        public List<Notificacao> Listar()
        {
            List<Notificacao> notificacao = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from notificacoes ";

                Dr = Cmd.ExecuteReader();
                notificacao = new List<Notificacao>();
                while (Dr.Read())
                {
                    
                    notificacao.Add(CadastrarNotificacao(Dr));
                }
            }
            catch { }

            return notificacao;
        }

        public List<Notificacao>ListarDestinatario(int codigo)
        {
            List<Notificacao> notificacoes = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                string sql = "select * from notificacoes where id_destinatario = " + codigo;
                Cmd.CommandText = sql;
                Dr = Cmd.ExecuteReader();
                notificacoes = new List<Notificacao>();

                while (Dr.Read())
                {
                    notificacoes.Add(CadastrarNotificacao(Dr));
                }
            }
            catch { }
            return notificacoes;
        }

        public List<Notificacao> ListarRemetente(int codigo)
        {
            List<Notificacao> notificacoes = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                string sql = "select * from notificacoes where id_remetente = " + codigo;
                Cmd.CommandText = sql;
                Dr = Cmd.ExecuteReader();
                notificacoes = new List<Notificacao>();

                while (Dr.Read())
                {
                    notificacoes.Add(CadastrarNotificacao2(Dr));
                }
            }
            catch { }
            return notificacoes;
        }

        public List<Notificacao> Pesquisar(int criterio, string pesquisa)
        {
            List<Notificacao> notificacoes = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                string sql = "select * from notificacoes where ";
                if (criterio == 1)
                {
                    sql += " nome like '%" + pesquisa + "%'";
                }
                else if (criterio == 2)
                {
                    sql += " Codigo id = " + pesquisa;
                }

                Cmd.CommandText = sql;
                Dr = Cmd.ExecuteReader();
                notificacoes = new List<Notificacao>();

                while (Dr.Read())
                {
                    notificacoes.Add(CadastrarNotificacao(Dr));
                }
            }
            catch { }
            return notificacoes;
        }
    }
}
