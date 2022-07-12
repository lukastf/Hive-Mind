using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using ProjetoBackEnd.Model;

namespace ProjetoFrontEnd.cadastros
{
    public partial class ListaMoradores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            MoradorModel moradorModel = new MoradorModel(strCnn);

            listaMoradores.DataSource = moradorModel.ListarMorador();
            listaMoradores.DataBind();

            if (Request.QueryString["msg"] != null)
            {
                PanelMensagens.Visible = true;
                lblMensagem.Text = Request.QueryString["msg"];
            }
        }
    }
}