using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class ProprietarioModel
    {
         private string strConexao;

        public ProprietarioModel(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public bool InserirProprietario(Proprietario proprietario)
        {
            using (ProprietarioData data = new ProprietarioData(strConexao))
            {
                return data.Inserir(proprietario);
            }
        }

        public bool EditarProprietario(Proprietario proprietario)
        {
            using (ProprietarioData data = new ProprietarioData(strConexao))
            {
                return data.Editar(proprietario);
            }
        }

        public bool ExcluirProprietario(Proprietario proprietario)
        {
            using (ProprietarioData data = new ProprietarioData(strConexao))
            {
                return data.Excluir(proprietario);
            }
        }

        public Proprietario ObterProprietarioLogin(string email,string senha)
        {
            using (ProprietarioData data = new ProprietarioData(strConexao))
            {
                return data.ObterProprietarioLogin(email, senha);
            }
        }

        public Proprietario ObterProprietarioID(int id_pessoa)
        {
            using(ProprietarioData data = new ProprietarioData(strConexao))
            {
                return data.ObterProprietarioID(id_pessoa);
            }
        }

        public List<Proprietario> ListarProprietario()
        {
            using (ProprietarioData data = new ProprietarioData(strConexao))
            {
                return data.ListarProprietario();
            }
        }

        public List<Proprietario> Pesquisar(int criterio, string pesquisa)
        {
            using (ProprietarioData data = new ProprietarioData(strConexao))
            {
                return data.PesquisarProprietario(criterio, pesquisa);
            }
        }
    }
}
