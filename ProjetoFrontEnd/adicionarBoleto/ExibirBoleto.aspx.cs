using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using ProjetoBackEnd.Model;
using ProjetoBackEnd.Entity;

namespace ProjetoFrontEnd.adicionarBoleto
{
    public partial class ExibirBoleto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            BoletoModel bModel = new BoletoModel(strCnn);

            if (Request.QueryString["IDboleto"] != null)
            {
                int id_boleto = Convert.ToInt32(Request.QueryString["IDboleto"].ToString());
                Boleto boleto = bModel.ObterBoleto(id_boleto);

                lblUnidade.Text = boleto.Unidade.Localizacao;
                lblValor.Text = boleto.Valor.ToString();
                lblDataGeracao.Text = boleto.DataGeracao;
                lblDataValidade.Text = boleto.DataValidade;
                lblDataPagamento.Text = boleto.DataPagamento;
                lblBancoReferente.Text = boleto.BancoReferente;



                idBoleto.Value = boleto.CodigoBoleto.ToString();

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaBoletos.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncluiAlteraBoleto.aspx?IDboleto=" + idBoleto.Value);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idBoleto.Value);
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            BoletoModel bModel = new BoletoModel(strCnn);

            string msg = "";
            if (bModel.ExcluirBoleto(bModel.ObterBoleto(id)))
            {
                msg = GetLocalResourceObject("msgsucesso").ToString();
            }
            else
            {
                msg = GetLocalResourceObject("msgerro").ToString();
            }

            Response.Redirect("ListaBoletos.aspx?msg=" + msg);
        }
    }
}