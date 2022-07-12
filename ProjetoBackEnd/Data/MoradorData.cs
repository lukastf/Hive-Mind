using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using ProjetoBackEnd.Entity;

namespace ProjetoBackEnd.Data
{
    public class MoradorData : PessoaData
    {
         public MoradorData(string strConexao)
            : base(strConexao) { }
        public bool Inserir(Morador morador)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"exec cadMorador @nome,@rg,@cpf,@telefone,@endereco,@email,@usuario,@senha,@dataEntrada,@dataSaida";


                Cmd.Parameters.AddWithValue("@nome", morador.Nome);
                Cmd.Parameters.AddWithValue("@rg", morador.Rg);
                Cmd.Parameters.AddWithValue("@cpf", morador.Cpf);
                Cmd.Parameters.AddWithValue("@telefone", morador.Telefone);
                Cmd.Parameters.AddWithValue("@endereco", morador.Endereco);
                Cmd.Parameters.AddWithValue("@email", morador.Email);
                Cmd.Parameters.AddWithValue("@usuario", morador.Usuario);
                Cmd.Parameters.AddWithValue("@senha", morador.Senha);
                Cmd.Parameters.AddWithValue("@dataEntrada", morador.DataEntrada);
                Cmd.Parameters.AddWithValue("@dataSaida", morador.DataSaida);

                Cmd.ExecuteNonQuery();

                ok = true;
            }
            catch { }
            return ok;
        }

        public bool Editar(Morador morador)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"exec editMorador @id_pessoa, @nome, @rg, @cpf, @telefone, @endereco, @email, @usuario, @senha, @dataEntrada, @dataSaida";

                Cmd.Parameters.AddWithValue("@nome", morador.Nome);
                Cmd.Parameters.AddWithValue("@rg", morador.Rg);
                Cmd.Parameters.AddWithValue("@cpf", morador.Cpf);
                Cmd.Parameters.AddWithValue("@telefone", morador.Telefone);
                Cmd.Parameters.AddWithValue("@endereco", morador.Endereco);
                Cmd.Parameters.AddWithValue("@email", morador.Email);
                Cmd.Parameters.AddWithValue("@usuario", morador.Usuario);
                Cmd.Parameters.AddWithValue("@senha", morador.Senha);
                Cmd.Parameters.AddWithValue("@dataEntrada", morador.DataEntrada);
                Cmd.Parameters.AddWithValue("@dataSaida", morador.DataSaida);
                Cmd.Parameters.AddWithValue("@id_pessoa", morador.Codigo);

                Cmd.ExecuteNonQuery();

                ok = true;
            }
            catch { }

            return ok;
        }

        public bool Excluir(Morador morador)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" delete from moradores where id_pessoa=@id_pessoa";

                Cmd.Parameters.AddWithValue("@id_pessoa", morador.Codigo);

                Cmd.ExecuteNonQuery();
                ok = true;
            }
            catch { }

            return ok;
        }

        public Morador ObterMoradorLogin(string usuario, string senha)
        {
            Morador morador = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from pessoas p, moradores m where p.id_pessoa = m.id_pessoa and" +
                    " usuario = @usuario and" +
                    " senha = @senha";

                Cmd.Parameters.AddWithValue("@usuario", usuario);
                Cmd.Parameters.AddWithValue("@senha", senha);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    morador = new Morador();
                    morador.Codigo = (int)Dr["id_pessoa"];
                    morador.Nome = (string)Dr["nome"];
                    morador.Rg = (string)Dr["rg"];
                    morador.Cpf = (string)Dr["cpf"];
                    morador.Telefone = (string)Dr["telefone"];
                    morador.Endereco = (string)Dr["endereco"];
                    morador.Email = (string)Dr["email"];
                    morador.Usuario = (string)Dr["usuario"];
                    morador.Senha = (string)Dr["senha"];
                    morador.DataEntrada = (string)Dr["dataEntrada"];
                    morador.DataSaida = (string)Dr["dataSaida"];
                }
            }
            catch { }

            return morador;
        }

        public Morador ObterMoradorID(int id_pessoa)
        {
            Morador morador = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from v_moradores where id_pessoa=@id_pessoa";

                Cmd.Parameters.AddWithValue("@id_pessoa", id_pessoa);


                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    morador = CadastrarMorador(Dr);
                }
            }
            catch { }

            return morador;
        }

        private Morador CadastrarMorador(SqlDataReader Dr)
        {
            Morador morador = new Morador();
            morador.Codigo = Dr.GetInt32(0);
            morador.Nome = Dr.GetString(1);
            morador.Rg = Dr.GetString(2);
            morador.Cpf = Dr.GetString(3);
            morador.Telefone = Dr.GetString(4);
            morador.Endereco = Dr.GetString(5);
            morador.Email = Dr.GetString(6);
            morador.Usuario = Dr.GetString(7);
            morador.Senha = Dr.GetString(8);
            morador.DataEntrada = Dr.GetString(9);
            morador.DataSaida = Dr.GetString(10);

            return morador;
        }

        public List<Morador> ListarMorador()
        {
            List<Morador> moradores = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from v_moradores ";

                Dr = Cmd.ExecuteReader();
                moradores = new List<Morador>();
                while (Dr.Read())
                {
                    moradores.Add(CadastrarMorador(Dr));
                }
            }
            catch { }

            return moradores;
        }

        public List<Morador> PesquisarMorador(int criterio, string pesquisa)
        {
            List<Morador> moradores = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                string sql = "select * from moradores where ";
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
                moradores = new List<Morador>();

                while (Dr.Read())
                {
                    moradores.Add(CadastrarMorador(Dr));
                }
            }
            catch { }
            return moradores;
        }
    }
}

