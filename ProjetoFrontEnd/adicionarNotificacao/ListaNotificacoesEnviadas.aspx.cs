using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Model;


namespace ProjetoFrontEnd.adicionarNotificacao
{
    public partial class ListaNotificacoesEnviadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pessoa pes = null;
            if (Session["morador"] != null)
            {
                pes = (Pessoa)Session["morador"];
            }
            else if (Session["funcionario"] != null)
            {
                pes = (Pessoa)Session["funcionario"];
            }
            else if (Session["admin"] != null)
            {
                pes = (Pessoa)Session["admin"];
            }
            else if (Session["proprietario"] != null)
            {
                pes = (Pessoa)Session["proprietario"];
            }
            else if (Session["sindico"] != null)
            {
                pes = (Pessoa)Session["sindico"];
            }

            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            NotificacaoModel notModel = new NotificacaoModel(strCnn);
            Notificacao notificacao = new Notificacao();

            //listaNotificacoes.DataSource = notModel.ListarNotificacao();
            //listaNotificacoes.DataBind();

            //if (pes == Session["sindico"])
            //{
            //    //pes.Nome = notificacao.Remetente.Nome;

            //    listaNotificacoesEnviadas.DataSource = notModel.ListarRemetente(pes.Codigo);
            //    listaNotificacoesEnviadas.DataBind();
            //}
            //else if (pes == Session["admin"])
            //{
            //    listaNotificacoesEnviadas.DataSource = notModel.ListarRemetente(pes.Codigo);
            //    listaNotificacoesEnviadas.DataBind();
            //}
            //else if (pes == Session["funcionario"])
            //{
            //    listaNotificacoesEnviadas.DataSource = notModel.ListarRemetente(pes.Codigo);
            //    listaNotificacoesEnviadas.DataBind();
            //}
            //else if (pes == Session["morador"])
            //{
            //    listaNotificacoesEnviadas.DataSource = notModel.ListarRemetente(pes.Codigo);
            //    listaNotificacoesEnviadas.DataBind();
            //}
            //else if (pes == Session["proprietario"])
            //{
            //    listaNotificacoesEnviadas.DataSource = notModel.ListarRemetente(pes.Codigo);
            //    listaNotificacoesEnviadas.DataBind();
            //}

            listaNotificacoesEnviadas.DataSource = notModel.ListarRemetente(pes.Codigo);
            listaNotificacoesEnviadas.DataBind();


            if (Request.QueryString["msg"] != null)
            {
                PanelMensagens.Visible = true;
                lblMensagem.Text = Request.QueryString["msg"];
            }
        }
    }
}