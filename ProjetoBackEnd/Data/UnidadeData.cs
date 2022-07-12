using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using ProjetoBackEnd.Entity;

namespace ProjetoBackEnd.Data
{
    public class UnidadeData : Conexao
    {
        string stringConexao = "";
        public UnidadeData(string stringConexao)
            : base(stringConexao) 
        {
            this.stringConexao = stringConexao;
        }

        public bool Inserir(Unidade unidade)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"exec addUnidade @id_morador,@id_proprietario,@localizacao";

                Cmd.Parameters.AddWithValue("@id_morador", unidade.Morador.Codigo);
                Cmd.Parameters.AddWithValue("@id_proprietario", unidade.Proprietario.Codigo);
                Cmd.Parameters.AddWithValue("@localizacao", unidade.Localizacao);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch { }
            return ok;
        }

        public bool Editar(Unidade unidade)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"exec editUnidade @id_unidade,@id_morador,@id_proprietario,@localizacao";

                Cmd.Parameters.AddWithValue("@id_morador", unidade.Morador.Codigo);
                Cmd.Parameters.AddWithValue("@id_proprietario", unidade.Proprietario.Codigo);
                Cmd.Parameters.AddWithValue("@localizacao", unidade.Localizacao);
                Cmd.Parameters.AddWithValue("@id_unidade", unidade.CodigoUnidade);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch { }

            return ok;
        }

        public bool Excluir(Unidade unidade)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" delete from unidades where id_unidade = @id_unidade";

                Cmd.Parameters.AddWithValue("@id_unidade", unidade.CodigoUnidade);

                Cmd.ExecuteNonQuery();
                ok = true;
            }
            catch { }

            return ok;
        }

        public Unidade ObterUnidadeID(int codigo)
        {
            Unidade unidade = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from v_unidades where id_unidade = @id_unidade ";

                Cmd.Parameters.AddWithValue("@id_unidade", codigo);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    unidade = CadastrarUnidade(Dr);
                }
                Dr.Close();
            }
            catch { }

            return unidade;
        }

        private Unidade CadastrarUnidade(SqlDataReader Dr)
        {
            PessoaData pessoaData = new PessoaData(stringConexao);

            Unidade unidade = new Unidade();
            unidade.CodigoUnidade = Dr.GetInt32(0);
            unidade.Morador = pessoaData.ObterPessoaID(Dr.GetInt32(1));
            unidade.NomeMorador = unidade.Morador.Nome;
            unidade.Proprietario = pessoaData.ObterPessoaID(Dr.GetInt32(2));
            unidade.NomeProprietario = unidade.Proprietario.Nome;
            unidade.Localizacao = Dr.GetString(3);


            return unidade;
        }

        public List<Unidade> ListarUnidade()
        {
            List<Unidade> unidades = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from unidades";

                Dr = Cmd.ExecuteReader();
                unidades = new List<Unidade>();
                while (Dr.Read())
                {
                    unidades.Add(CadastrarUnidade(Dr));
                }
            }
            catch { }

            return unidades;
        }

    }
}
