using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using ProjetoBackEnd.Entity;

namespace ProjetoBackEnd.Data
{
    public class SindicoData : PessoaData
    {
        public SindicoData(string stringConexao)
            : base(stringConexao) { }

        public bool Inserir(Sindico sindico)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"exec cadSindico @nome,@rg,@cpf,@telefone, @endereco,@email,@usuario,@senha,@informacao";


                Cmd.Parameters.AddWithValue("@nome", sindico.Nome);
                Cmd.Parameters.AddWithValue("@rg", sindico.Rg);
                Cmd.Parameters.AddWithValue("@cpf", sindico.Cpf);
                Cmd.Parameters.AddWithValue("@telefone", sindico.Telefone);
                Cmd.Parameters.AddWithValue("@endereco", sindico.Endereco);
                Cmd.Parameters.AddWithValue("@email", sindico.Email);
                Cmd.Parameters.AddWithValue("@usuario", sindico.Usuario);
                Cmd.Parameters.AddWithValue("@senha", sindico.Senha);
                Cmd.Parameters.AddWithValue("@informacao", sindico.Informacao);

                Cmd.ExecuteNonQuery();

                ok = true;
            }
            catch { }
            return ok;
        }

        public bool Editar(Sindico sindico)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"exec editSindico @id_pessoa, @nome, @rg, @cpf, @telefone, @endereco, @email, @usuario, @senha, @informacao";

                Cmd.Parameters.AddWithValue("@nome", sindico.Nome);
                Cmd.Parameters.AddWithValue("@rg", sindico.Rg);
                Cmd.Parameters.AddWithValue("@cpf", sindico.Cpf);
                Cmd.Parameters.AddWithValue("@telefone", sindico.Telefone);
                Cmd.Parameters.AddWithValue("@endereco", sindico.Endereco);
                Cmd.Parameters.AddWithValue("@email", sindico.Email);
                Cmd.Parameters.AddWithValue("@usuario", sindico.Usuario);
                Cmd.Parameters.AddWithValue("@senha", sindico.Senha);
                Cmd.Parameters.AddWithValue("@informacao", sindico.Informacao);
                Cmd.Parameters.AddWithValue("@id_pessoa", sindico.Codigo);

                Cmd.ExecuteNonQuery();

                ok = true;
            }
            catch { }

            return ok;
        }

        public bool Excluir(Sindico sindico)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" delete from sindicos where id_pessoa = @id_pessoa";

                Cmd.Parameters.AddWithValue("@id_pessoa", sindico.Codigo);

                Cmd.ExecuteNonQuery();
                ok = true;
            }
            catch { }

            return ok;
        }

        public Sindico ObterSindicoLogin(string usuario, string senha)
        {
            Sindico sindico = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from pessoas p, sindicos s where p.id_pessoa = s.id_pessoa and" +
                    " usuario = @usuario and" +
                    " senha = @senha";

                Cmd.Parameters.AddWithValue("@usuario", usuario);
                Cmd.Parameters.AddWithValue("@senha", senha);


                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    sindico = new Sindico();
                    sindico.Codigo = (int)Dr["id_pessoa"];
                    sindico.Nome = (string)Dr["nome"];
                    sindico.Rg = (string)Dr["rg"];
                    sindico.Cpf = (string)Dr["cpf"];
                    sindico.Telefone = (string)Dr["telefone"];
                    sindico.Endereco = (string)Dr["endereco"];
                    sindico.Email = (string)Dr["email"];
                    sindico.Usuario = (string)Dr["usuario"];
                    sindico.Senha = (string)Dr["senha"];
                    sindico.Informacao = (string)Dr["informacao"];

                }
            }
            catch { }

            return sindico;
        }

        public Sindico ObterSindicoID(int codigo)
        {
            Sindico sindico = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from v_sindicos where id_pessoa=@id_pessoa ";

                Cmd.Parameters.AddWithValue("@id_pessoa", codigo);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    sindico = CadastrarSindico(Dr);
                }
            }
            catch { }

            return sindico;
        }

        private Sindico CadastrarSindico(SqlDataReader Dr)
        {
            Sindico sindico = new Sindico();
            sindico.Codigo = Dr.GetInt32(0);
            sindico.Nome = Dr.GetString(1);
            sindico.Rg = Dr.GetString(2);
            sindico.Cpf = Dr.GetString(3);
            sindico.Telefone = Dr.GetString(4);
            sindico.Endereco = Dr.GetString(5);
            sindico.Email = Dr.GetString(6);
            sindico.Usuario = Dr.GetString(7);
            sindico.Senha = Dr.GetString(8);
            sindico.Informacao = Dr.GetString(9);


            return sindico;
        }

        public List<Sindico> ListarSindico()
        {
            List<Sindico> produtos = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from v_sindicos";

                Dr = Cmd.ExecuteReader();
                produtos = new List<Sindico>();
                while (Dr.Read())
                {
                    produtos.Add(CadastrarSindico(Dr));
                }
            }
            catch { }

            return produtos;
        }

        public List<Sindico> PesquisarSindico(int criterio, string pesquisa)
        {
            List<Sindico> sindicos = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                string sql = "select * from sindicos where ";
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
                sindicos = new List<Sindico>();

                while (Dr.Read())
                {
                    sindicos.Add(CadastrarSindico(Dr));
                }
            }
            catch { }
            return sindicos;
        }
    }
}