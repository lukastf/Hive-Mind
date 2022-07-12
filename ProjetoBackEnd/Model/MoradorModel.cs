using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class MoradorModel
    {
         private string strConexao;

        public MoradorModel(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public bool InserirMorador(Morador morador)
        {
            using (MoradorData data = new MoradorData(strConexao))
            {
                return data.Inserir(morador);
            }
        }

        public bool EditarMorador(Morador morador)
        {
            using (MoradorData data = new MoradorData(strConexao))
            {
                return data.Editar(morador);
            }
        }

        public bool ExcluirMorador(Morador morador)
        {
            using (MoradorData data = new MoradorData(strConexao))
            {
                return data.Excluir(morador);
            }
        }

        public Morador ObterMoradorLogin(string email,string senha)
        {
            using (MoradorData data = new MoradorData(strConexao))
            {
                return data.ObterMoradorLogin(email, senha);
            }
        }

        public Morador ObterMoradorID(int id_pessoa)
        {
            using(MoradorData data = new MoradorData(strConexao))
            {
                return data.ObterMoradorID(id_pessoa);
            }
        }

        public List<Morador> ListarMorador()
        {
            using (MoradorData data = new MoradorData(strConexao))
            {
                return data.ListarMorador();
            }
        }

        public List<Morador> Pesquisar(int criterio, string pesquisa)
        {
            using (MoradorData data = new MoradorData(strConexao))
            {
                return data.PesquisarMorador(criterio, pesquisa);
            }
        }
    }
}
