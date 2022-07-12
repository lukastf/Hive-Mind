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
    public partial class ListaBoletos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            BoletoModel bModel = new BoletoModel(strCnn);

            listaBoletos.DataSource = bModel.ListarBoleto();
            listaBoletos.DataBind();



            if (Request.QueryString["msg"] != null)
            {
                PanelMensagens.Visible = true;
                lblMensagem.Text = Request.QueryString["msg"];
            }
        }
    }
}