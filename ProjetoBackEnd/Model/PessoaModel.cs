using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class PessoaModel
    {
        private string strConexao;

        public PessoaModel(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public bool Inserir(Pessoa pessoa)
        {
            using (PessoaData data = new PessoaData(strConexao))
            {
                return data.Inserir(pessoa);
            }
        }

        public bool Editar(Pessoa pessoa)
        {
            using (PessoaData data = new PessoaData(strConexao))
            {
                return data.Editar(pessoa);
            }
        }

        public bool Excluir(Pessoa pessoa)
        {
            using (PessoaData data = new PessoaData(strConexao))
            {
                return data.Excluir(pessoa);
            }
        }

        public Pessoa ObterPessoa(int codigo)
        {
            using (PessoaData data = new PessoaData(strConexao))
            {
                return data.ObterPessoaID(codigo);
            }
        }

        public List<String> ListarNome()
        {
            using (PessoaData data = new PessoaData(strConexao))
            {
                return data.ListarNome();
            }
        }

        public List<Pessoa> Listar()
        {
            using (PessoaData data = new PessoaData(strConexao))
            {
                return data.Listar();
            }
        }

        public List<Pessoa> Pesquisar(int criterio, string pesquisa)
        {
            using (PessoaData data = new PessoaData(strConexao))
            {
                return data.Pesquisar(criterio, pesquisa);
            }
        }
    }
}
