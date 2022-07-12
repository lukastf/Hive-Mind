using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using ProjetoBackEnd.Entity;

namespace ProjetoBackEnd.Data
{
    public class FuncionarioData : PessoaData
    {
        public FuncionarioData(string stringConexao)
            : base(stringConexao) { }
 
        public bool Inserir(Funcionario funcionario)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"exec cadFuncionario @nome,@rg,@cpf,@telefone,@endereco,@email,@usuario,@senha,@dataAdmissao,@dataDemissao,@statusAdmin";


                Cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                Cmd.Parameters.AddWithValue("@rg", funcionario.Rg);
                Cmd.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                Cmd.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                Cmd.Parameters.AddWithValue("@endereco", funcionario.Endereco);
                Cmd.Parameters.AddWithValue("@email", funcionario.Email);
                Cmd.Parameters.AddWithValue("@usuario", funcionario.Usuario);
                Cmd.Parameters.AddWithValue("@senha", funcionario.Senha);
                Cmd.Parameters.AddWithValue("@dataAdmissao", funcionario.DataAdmissao);
                Cmd.Parameters.AddWithValue("@dataDemissao", funcionario.DataDemissao);
                Cmd.Parameters.AddWithValue("@statusAdmin", funcionario.StatusAdmin);


                Cmd.ExecuteNonQuery();

                ok = true;
            }
            catch { }
            return ok;
        }

        public bool Editar(Funcionario funcionario)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @"exec editFuncionario @id_pessoa, @nome, @rg, @cpf,  @telefone, @endereco,  @email,  @usuario,  @senha, @dataAdmissao, @dataDemissao,  @statusAdmin";

                
                Cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                Cmd.Parameters.AddWithValue("@rg", funcionario.Rg);
                Cmd.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                Cmd.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                Cmd.Parameters.AddWithValue("@endereco", funcionario.Endereco);
                Cmd.Parameters.AddWithValue("@email", funcionario.Email);
                Cmd.Parameters.AddWithValue("@usuario", funcionario.Usuario);
                Cmd.Parameters.AddWithValue("@senha", funcionario.Senha);
                Cmd.Parameters.AddWithValue("@dataAdmissao", funcionario.DataAdmissao);
                Cmd.Parameters.AddWithValue("@dataDemissao", funcionario.DataDemissao);
                Cmd.Parameters.AddWithValue("@statusAdmin", funcionario.StatusAdmin);
                Cmd.Parameters.AddWithValue("@id_pessoa", funcionario.Codigo);


                Cmd.ExecuteNonQuery();

                ok = true;
            }
            catch { }

            return ok;
        }

        public bool Excluir(Funcionario funcionario)
        {
            bool ok = false;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" delete from funcionarios where id_pessoa=@id_pessoa";

                Cmd.Parameters.AddWithValue("@id_pessoa", funcionario.Codigo);

                Cmd.ExecuteNonQuery();
                ok = true;
            }
            catch { }

            return ok;
        }

        public Funcionario ObterAdmin(bool statusAdmin)
        {
            Funcionario funcionario = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from pessoas, funcionarios where id_pessoa=@id_pessoa and statusAdmin=@statusAdmin";

                Cmd.Parameters.AddWithValue("@statusAdmin", statusAdmin);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    //funcionario = CadastrarFuncionario(Dr);
                    funcionario = new Funcionario();
                    funcionario.Codigo = (int)Dr["id_pessoa"];
                    funcionario.Nome = (string)Dr["nome"];
                    funcionario.Rg = (string)Dr["rg"];
                    funcionario.Cpf = (string)Dr["cpf"];
                    funcionario.Telefone = (string)Dr["telefone"];
                    funcionario.Endereco = (string)Dr["endereco"];
                    funcionario.Email = (string)Dr["email"];
                    funcionario.Usuario = (string)Dr["usuario"];
                    funcionario.Senha = (string)Dr["senha"];
                    funcionario.DataAdmissao = (string)Dr["dataAdmissao"];
                    funcionario.DataDemissao = (string)Dr["dataDemissao"];
                    funcionario.StatusAdmin = (bool)Dr["statusAdmin"];

                }
            }
            catch { }

            return funcionario;

        }

        public Funcionario ObterFuncionarioLogin(string usuario, string senha)
        {
            Funcionario funcionario = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from pessoas p, funcionarios f where p.id_pessoa = f.id_pessoa and" +
                    " usuario = @usuario and" +
                    " senha = @senha";

                Cmd.Parameters.AddWithValue("@usuario", usuario);
                Cmd.Parameters.AddWithValue("@senha", senha);


                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    //funcionario = CadastrarFuncionario(Dr);
                    funcionario = new Funcionario();
                    funcionario.Codigo = (int)Dr["id_pessoa"];
                    funcionario.Nome = (string)Dr["nome"];
                    funcionario.Rg = (string)Dr["rg"];
                    funcionario.Cpf = (string)Dr["cpf"];
                    funcionario.Telefone = (string)Dr["telefone"];
                    funcionario.Endereco = (string)Dr["endereco"];
                    funcionario.Email = (string)Dr["email"];
                    funcionario.Usuario = (string)Dr["usuario"];
                    funcionario.Senha = (string)Dr["senha"];
                    funcionario.DataAdmissao = (string)Dr["dataAdmissao"];
                    funcionario.DataDemissao = (string)Dr["dataDemissao"];
                    funcionario.StatusAdmin = (bool)Dr["statusAdmin"];

                }
            }
            catch { }

            return funcionario;
        }

        public Funcionario ObterFuncionarioID(int id_pessoa)
        {
            Funcionario funcionario = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from v_funcionarios where id_pessoa=@id_pessoa";

                Cmd.Parameters.AddWithValue("@id_pessoa", id_pessoa);


                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    funcionario = CadastrarFuncionario(Dr);
                }
            }
            catch { }

            return funcionario;
        }

        private Funcionario CadastrarFuncionario(SqlDataReader Dr)
        {
            Funcionario funcionario = new Funcionario();
            funcionario.Codigo = Dr.GetInt32(0);
            funcionario.Nome = Dr.GetString(1);
            funcionario.Rg = Dr.GetString(2);
            funcionario.Cpf = Dr.GetString(3);
            funcionario.Telefone = Dr.GetString(4);
            funcionario.Endereco = Dr.GetString(5);
            funcionario.Email = Dr.GetString(6);
            funcionario.Usuario = Dr.GetString(7);
            funcionario.Senha = Dr.GetString(8);
            funcionario.DataAdmissao = Dr.GetString(9);
            funcionario.DataDemissao = Dr.GetString(10);
            funcionario.StatusAdmin = Dr.GetBoolean(11);

            return funcionario;
        }

        public List<Funcionario> ListarFuncionario()
        {
            List<Funcionario> funcionarios = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText = @" select * from v_funcionarios";

                Dr = Cmd.ExecuteReader();
                funcionarios = new List<Funcionario>();
                while (Dr.Read())
                {
                    funcionarios.Add(CadastrarFuncionario(Dr));
                }
            }
            catch { }

            return funcionarios;
        }

        public List<Funcionario> PesquisarFuncionario(int criterio, string pesquisa)
        {
            List<Funcionario> funcionarios = null;
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                string sql = "select * from funcionarios where ";
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
                funcionarios = new List<Funcionario>();

                while (Dr.Read())
                {
                    funcionarios.Add(CadastrarFuncionario(Dr));
                }
            }
            catch { }
            return funcionarios;
        }
    }
}