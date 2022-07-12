using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using ProjetoBackEnd.Entity;

namespace ProjetoBackEnd.Data
{
    public class ProprietarioData : PessoaData
    {
         public ProprietarioData(string strConexao)
            : base(strConexao) { }

        public bool Inserir(Proprietario proprietario)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"exec cadProprietario @nome,@rg,@cpf,@telefone,@endereco,@email,@usuario,@senha,@informacao";


                Cmd.Parameters.AddWithValue("@nome", proprietario.Nome);
                Cmd.Parameters.AddWithValue("@rg", proprietario.Rg);
                Cmd.Parameters.AddWithValue("@cpf", proprietario.Cpf);
                Cmd.Parameters.AddWithValue("@telefone", proprietario.Telefone);
                Cmd.Parameters.AddWithValue("@endereco", proprietario.Endereco);
                Cmd.Parameters.AddWithValue("@email", proprietario.Email);
                Cmd.Parameters.AddWithValue("@usuario", proprietario.Usuario);
                Cmd.Parameters.AddWithValue("@senha", proprietario.Senha);
                Cmd.Parameters.AddWithValue("@informacao", proprietario.Informacao);

                Cmd.ExecuteNonQuery();

                ok = true;
            }
            catch { }
            return ok;
        }

        public bool Editar(Proprietario proprietario)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"exec editProprietario @id_pessoa, @nome, @rg, @cpf, @telefone, @endereco, @email, @usuario, @senha, @informacao";

                Cmd.Parameters.AddWithValue("@nome", proprietario.Nome);
                Cmd.Parameters.AddWithValue("@rg", proprietario.Rg);
                Cmd.Parameters.AddWithValue("@cpf", proprietario.Cpf);
                Cmd.Parameters.AddWithValue("@telefone", proprietario.Telefone);
                Cmd.Parameters.AddWithValue("@endereco", proprietario.Endereco);
                Cmd.Parameters.AddWithValue("@email", proprietario.Email);
                Cmd.Parameters.AddWithValue("@usuario", proprietario.Usuario);
                Cmd.Parameters.AddWithValue("@senha", proprietario.Senha);
                Cmd.Parameters.AddWithValue("@informacao", proprietario.Informacao);
                Cmd.Parameters.AddWithValue("@id_pessoa", proprietario.Codigo);

                Cmd.ExecuteNonQuery();

                ok = true;
            }
            catch { }

            return ok;
        }

        public bool Excluir(Proprietario prop)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" delete from proprietarios where id_pessoa=@id_pessoa";

                Cmd.Parameters.AddWithValue("@id_pessoa", prop.Codigo);

                Cmd.ExecuteNonQuery();
                ok = true;
            }
            catch { }

            return ok;
        }

        public Proprietario ObterProprietarioLogin(string usuario, string senha)
        {
            Proprietario proprietario = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from pessoas p, proprietarios pr where p.id_pessoa = pr.id_pessoa and" +
                    " usuario = @usuario and" +
                    " senha = @senha";

                Cmd.Parameters.AddWithValue("@usuario", usuario);
                Cmd.Parameters.AddWithValue("@senha", senha);


                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    proprietario = new Proprietario();
                    proprietario.Codigo = (int)Dr["id_pessoa"];
                    proprietario.Nome = (string)Dr["nome"];
                    proprietario.Rg = (string)Dr["rg"];
                    proprietario.Cpf = (string)Dr["cpf"];
                    proprietario.Telefone = (string)Dr["telefone"];
                    proprietario.Endereco = (string)Dr["endereco"];
                    proprietario.Email = (string)Dr["email"];
                    proprietario.Usuario = (string)Dr["usuario"];
                    proprietario.Senha = (string)Dr["senha"];
                    proprietario.Informacao = (string)Dr["informacao"];
                }
            }
            catch { }

            return proprietario;
        }

        public Proprietario ObterProprietarioID(int codigo)
        {
            Proprietario proprietario = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from v_proprietarios where id_pessoa=@id_pessoa";

                Cmd.Parameters.AddWithValue("@id_pessoa", codigo);


                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    proprietario = CadastrarProprietario(Dr);
                }
            }
            catch { }

            return proprietario;
        }

        private Proprietario CadastrarProprietario(SqlDataReader Dr)
        {
            Proprietario proprietario = new Proprietario();
            proprietario.Codigo = Dr.GetInt32(0);
            proprietario.Nome = Dr.GetString(1);
            proprietario.Rg = Dr.GetString(2);
            proprietario.Cpf = Dr.GetString(3);
            proprietario.Telefone = Dr.GetString(4);
            proprietario.Endereco = Dr.GetString(5);
            proprietario.Email = Dr.GetString(6);
            proprietario.Usuario = Dr.GetString(7);
            proprietario.Senha = Dr.GetString(8);
            proprietario.Informacao = Dr.GetString(9);



            return proprietario;
        }

        public List<Proprietario> ListarProprietario()
        {
            List<Proprietario> proprietario = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from v_proprietarios";

                Dr = Cmd.ExecuteReader();
                proprietario = new List<Proprietario>();
                while (Dr.Read())
                {
                    proprietario.Add(CadastrarProprietario(Dr));
                }
            }
            catch { }

            return proprietario;
        }

        public List<Proprietario> PesquisarProprietario(int criterio, string pesquisa)
        {
            List<Proprietario> proprietarios = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                string sql = "select * from proprietarios where ";
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
                proprietarios = new List<Proprietario>();

                while (Dr.Read())
                {
                    proprietarios.Add(CadastrarProprietario(Dr));
                }
            }
            catch { }
            return proprietarios;
        }
    }
}
