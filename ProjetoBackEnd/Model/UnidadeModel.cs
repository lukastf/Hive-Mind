using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class UnidadeModel
    {
        private string strConexao;

        public UnidadeModel(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public bool InserirUnidade(Unidade unidade)
        {
            using (UnidadeData data = new UnidadeData(strConexao))
            {
                return data.Inserir(unidade);
            }
        }

        public bool EditarUnidade(Unidade unidade)
        {
            using (UnidadeData data = new UnidadeData(strConexao))
            {
                return data.Editar(unidade);
            }
        }

        public bool ExcluirUnidade(Unidade unidade)
        {
            using (UnidadeData data = new UnidadeData(strConexao))
            {
                return data.Excluir(unidade);
            }
        }

        public Unidade ObterUnidadeID(int id)
        {
            using (UnidadeData data = new UnidadeData(strConexao))
            {
                return data.ObterUnidadeID(id);
            }
        }

        public List<Unidade> ListarUnidade()
        {
            using (UnidadeData data = new UnidadeData(strConexao))
            {
                return data.ListarUnidade();
            }
        }
    }
}
