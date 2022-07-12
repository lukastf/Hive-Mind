using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Model;

namespace ProjetoFrontEnd.adicionarBoleto
{
    public partial class IncluiAlteraBoleto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;
                UnidadeModel uModel = new UnidadeModel(stringConexao);

                ddlUnidades.DataSource = uModel.ListarUnidade();
                ddlUnidades.DataBind();
            }

            if (Request.QueryString["IDboleto"] != null && !IsPostBack)
            {
                string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

                int id_boleto = Convert.ToInt32(Request.QueryString["IDboleto"].ToString());

                BoletoModel bModel = new BoletoModel(stringConexao);

                Boleto boleto = bModel.ObterBoleto(id_boleto);

                
                txtvalor.Text = boleto.Valor.ToString();
                txtDataGeracao.Text = boleto.DataGeracao;
                txtDataValidade.Text = boleto.DataValidade;
                txtDataPagamento.Text = boleto.DataPagamento;
                txtBancoReferente.Text = boleto.BancoReferente;

                //lista unidades
                //UnidadeModel uModel = new UnidadeModel(stringConexao);
                //ddlUnidades.DataSource = uModel.ListarUnidade();
                //ddlUnidades.DataBind();

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaBoletos.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;
            Boleto boleto = new Boleto();        
            UnidadeModel uModel = new UnidadeModel(stringConexao);

            boleto.Valor = Convert.ToDecimal(txtvalor.Text);
            boleto.DataGeracao = txtDataGeracao.Text;
            boleto.DataValidade = txtDataValidade.Text;
            boleto.DataPagamento = txtDataPagamento.Text;
            boleto.BancoReferente = txtBancoReferente.Text;

            boleto.Unidade = uModel.ObterUnidadeID(int.Parse(ddlUnidades.SelectedValue));

            BoletoModel model = new BoletoModel(stringConexao);

            string msg = "";

            //modificação para editar
            if (Request.QueryString["IDboleto"] != null)
            {
                boleto.CodigoBoleto = Convert.ToInt32(Request.QueryString["IDboleto"].ToString());
                if (model.EditarBoleto(boleto))
                {
                    msg = "Boleto " + boleto.CodigoBoleto + " editado com sucesso!";
                }
                else
                {
                    msg = "Erro ao editar  " + boleto.CodigoBoleto + " tente mais tarde!";
                }
            }
            else
            {
                if (model.InserirBoleto(boleto))
                {
                    msg = "Boleto " + boleto.CodigoBoleto + " adicionado com sucesso!";
                }
                else
                {
                    msg = "Erro!";
                }
            }
            Response.Redirect("ListaBoletos.aspx?msg=" + msg);
        }

        protected void ddlUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}