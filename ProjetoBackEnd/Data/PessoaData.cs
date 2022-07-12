using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using ProjetoBackEnd.Entity;

namespace ProjetoBackEnd.Data
{
    public class PessoaData : Conexao
    {
        public PessoaData(string strConexao)
            : base(strConexao) { }
 
        public bool Inserir(Pessoa pessoa)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText =
                    @"insert into pessoas values (@nome,@rg,@cpf,@telefone,@endereco,@email,@usuario,@senha,@statusBDTable)";


                Cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                Cmd.Parameters.AddWithValue("@rg", pessoa.Rg);
                Cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);
                Cmd.Parameters.AddWithValue("@telefone", pessoa.Telefone);
                Cmd.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                Cmd.Parameters.AddWithValue("@email", pessoa.Email);
                Cmd.Parameters.AddWithValue("@usuario", pessoa.Usuario);
                Cmd.Parameters.AddWithValue("@senha", pessoa.Senha);

                Cmd.ExecuteNonQuery();

                ok = true;
            }
            catch { }
            return ok;
        }

        public bool Editar(Pessoa pessoa)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" update pessoas set nome = @nome, rg = @rg, cpf = @cpf, telefone = @telefone, endereco = @endereco, email = @email, usuario = @usuario, senha = @senha, statusBDTable = @statusBDTable where id_pessoa=@id_pessoa";

                Cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                Cmd.Parameters.AddWithValue("@rg", pessoa.Rg);
                Cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);
                Cmd.Parameters.AddWithValue("@telefone", pessoa.Telefone);
                Cmd.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                Cmd.Parameters.AddWithValue("@email", pessoa.Email);
                Cmd.Parameters.AddWithValue("@usuario", pessoa.Usuario);
                Cmd.Parameters.AddWithValue("@senha", pessoa.Senha);
                Cmd.Parameters.AddWithValue("@id_pessoa", pessoa.Codigo);

                Cmd.ExecuteNonQuery();

                ok = true;
            }
            catch { }

            return ok;
        }

        public bool Excluir(Pessoa pessoa)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" delete from pessoas where id_pessoa=@id_pessoa";

                Cmd.Parameters.AddWithValue("@id_pessoa", pessoa.Codigo);

                Cmd.ExecuteNonQuery();
                ok = true;
            }
            catch { }

            return ok;
        }

        public Pessoa ObterPessoaID(int codigo)
        {
            Pessoa pessoa = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from pessoas where id_pessoa=@id_pessoa ";

                Cmd.Parameters.AddWithValue("@id_pessoa", codigo);

                Dr = Cmd.ExecuteReader();
                if (Dr.Read())
                {
                    pessoa = CadastrarPessoa(Dr);
                }
                Dr.Close();
            }
            catch { }

            return pessoa;
        }

        private Pessoa CadastrarPessoa(SqlDataReader Dr)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Codigo = Dr.GetInt32(0);
            pessoa.Nome = Dr.GetString(1);
            pessoa.Rg = Dr.GetString(2);
            pessoa.Cpf = Dr.GetString(3);
            pessoa.Telefone = Dr.GetString(4);
            pessoa.Endereco = Dr.GetString(5);
            pessoa.Email = Dr.GetString(6);
            pessoa.Usuario = Dr.GetString(7);
            pessoa.Senha = Dr.GetString(8);

            return pessoa;
        }

        public List<String> ListarNome()
        {
            List<String> pessoas = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select nome from pessoas";

                Dr = Cmd.ExecuteReader();
                pessoas = new List<String>();

                while (Dr.Read())
                {
                    String pessoa;
                    pessoa = Dr.GetString(0);
                    pessoas.Add(pessoa);
                }
            }
            catch
            {

            }
            return pessoas;
        }

        public List<Pessoa> Listar()
        {
            List<Pessoa> produtos = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from pessoas ";

                Dr = Cmd.ExecuteReader();
                produtos = new List<Pessoa>();
                while (Dr.Read())
                {
                    produtos.Add(CadastrarPessoa(Dr));
                }
            }
            catch { }

            return produtos;
        }

        public List<Pessoa> Pesquisar(int criterio, string pesquisa)
        {
            List<Pessoa> pessoas = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                string sql = "select * from pessoas where ";
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
                pessoas = new List<Pessoa>();

                while (Dr.Read())
                {
                    pessoas.Add(CadastrarPessoa(Dr));
                }
            }
            catch { }
            return pessoas;
        }
    }
}
