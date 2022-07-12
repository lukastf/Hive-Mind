using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class SindicoModel
    {

        private string strConexao;

        public SindicoModel(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public bool InserirSindico(Sindico sindico)
        {
            using (SindicoData data = new SindicoData(strConexao))
            {
                return data.Inserir(sindico);
            }
        }

        public bool EditarSindico(Sindico sindico)
        {
            using (SindicoData data = new SindicoData(strConexao))
            {
                return data.Editar(sindico);
            }
        }

        public bool ExcluirSindico(Sindico sindico)
        {
            using (SindicoData data = new SindicoData(strConexao))
            {
                return data.Excluir(sindico);
            }
        }

        public Sindico ObterSindicoLogin(string email,string senha)
        {
            using (SindicoData data = new SindicoData(strConexao))
            {
                return data.ObterSindicoLogin(email, senha);
            }
        }

        public Sindico ObterSindicoID(int id_pessoa)
        {
            using(SindicoData data = new SindicoData(strConexao))
            {
                return data.ObterSindicoID(id_pessoa);
            }
        }

        public List<Sindico> ListarSindico()
        {
            using (SindicoData data = new SindicoData(strConexao))
            {
                return data.ListarSindico();
            }
        }

        public List<Sindico> Pesquisar(int criterio, string pesquisa)
        {
            using (SindicoData data = new SindicoData(strConexao))
            {
                return data.PesquisarSindico(criterio, pesquisa);
            }
        }

    }
}
