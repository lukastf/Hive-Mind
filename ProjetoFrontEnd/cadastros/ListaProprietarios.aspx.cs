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
    public partial class ListaProprietarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strCnn = ConfigurationManager.
                           ConnectionStrings["stringConexao"].ConnectionString;
            ProprietarioModel pModel = new ProprietarioModel(strCnn);

            listaProprietarios.DataSource = pModel.ListarProprietario();
            listaProprietarios.DataBind();

            if (Request.QueryString["msg"] != null)
            {
                PanelMensagens.Visible = true;
                lblMensagem.Text = Request.QueryString["msg"];
            }
        }
    }
}