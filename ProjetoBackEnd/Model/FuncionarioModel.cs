using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class FuncionarioModel
    {
        private string strConexao;

        public FuncionarioModel(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public bool InserirFuncionario(Funcionario funcionario)
        {
            using (FuncionarioData data = new FuncionarioData(strConexao))
            {
                return data.Inserir(funcionario);
            }
        }

        public bool EditarFuncionario(Funcionario funcionario)
        {
            using (FuncionarioData data = new FuncionarioData(strConexao))
            {
                return data.Editar(funcionario);
            }
        }

        public bool ExcluirFuncionario(Funcionario funcionario)
        {
            using (FuncionarioData data = new FuncionarioData(strConexao))
            {
                return data.Excluir(funcionario);
            }
        }

        public Funcionario ObterFuncionarioLogin(string email,string senha)
        {
            using (FuncionarioData data = new FuncionarioData(strConexao))
            {
                return data.ObterFuncionarioLogin(email, senha);
            }
        }

        public Funcionario ObterFuncionarioID(int id_pessoa)
        {
            using(FuncionarioData data = new FuncionarioData(strConexao))
            {
                return data.ObterFuncionarioID(id_pessoa);
            }
        }

        public List<Funcionario> ListarFuncionario()
        {
            using (FuncionarioData data = new FuncionarioData(strConexao))
            {
                return data.ListarFuncionario();
            }
        }

        public List<Funcionario> Pesquisar(int criterio, string pesquisa)
        {
            using (FuncionarioData data = new FuncionarioData(strConexao))
            {
                return data.PesquisarFuncionario(criterio, pesquisa);
            }
        }
    }
}
