using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class BoletoModel
     {
        private string strConexao;

        public BoletoModel(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public bool InserirBoleto(Boleto boleto)
        {
            using (BoletoData data = new BoletoData(strConexao))
            {
                return data.Inserir(boleto);
            }
        }

        public bool EditarBoleto(Boleto boleto)
        {
            using (BoletoData data = new BoletoData(strConexao))
            {
                return data.Editar(boleto);
            }
        }

        public bool ExcluirBoleto(Boleto boleto)
        {
            using (BoletoData data = new BoletoData(strConexao))
            {
                return data.Excluir(boleto);
            }
        }

        public Boleto ObterBoleto(int codigo)
        {
            using (BoletoData data = new BoletoData(strConexao))
            {
                return data.ObterBoleto(codigo);
            }
        }

        public List<Boleto> ListarBoleto()
        {
            using (BoletoData data = new BoletoData(strConexao))
            {
                return data.Listar();
            }
        }

        public List<Boleto> Pesquisar(int criterio, string pesquisa)
        {
            using (BoletoData data = new BoletoData(strConexao))
            {
                return data.Pesquisar(criterio, pesquisa);
            }
        }
    }
}
