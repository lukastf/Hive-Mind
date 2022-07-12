using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using ProjetoBackEnd.Model;
using ProjetoBackEnd.Entity;

namespace ProjetoFrontEnd.cadastros
{
    public partial class ExibirUnidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            UnidadeModel unModel = new UnidadeModel(strCnn);

            if (Request.QueryString["IDunidade"] != null)
            {
                int un = Convert.ToInt32(Request.QueryString["IDunidade"].ToString());
                Unidade unidade = unModel.ObterUnidadeID(un);

                lblCodUnidade.Text = unidade.CodigoUnidade.ToString();
                lblMorador.Text = unidade.Morador.Nome;
                lblProprietario.Text = unidade.Proprietario.Nome;
                lblLocalizacao.Text = unidade.Localizacao;

                //idPessoa.Value = Convert.ToString(pessoa.Codigo);
                idUnidade.Value = unidade.CodigoUnidade.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaUnidades.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncluiAlteraUnidade.aspx?IDunidade=" + idUnidade.Value);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idUnidade.Value);
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            UnidadeModel uModel = new UnidadeModel(strCnn);

            string msg = "";
            if (uModel.ExcluirUnidade(uModel.ObterUnidadeID(id)))
            {
                msg = GetLocalResourceObject("msgsucesso").ToString();
            }
            else
            {
                msg = GetLocalResourceObject("msgerro").ToString();
            }

            Response.Redirect("ListaUnidades.aspx?msg=" + msg);
        }
    }
}