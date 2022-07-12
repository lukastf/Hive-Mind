using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using ProjetoBackEnd.Model;
using ProjetoBackEnd.Entity;

namespace ProjetoFrontEnd.adicionarNotificacao
{
    public partial class ExibirNotificacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            NotificacaoModel notModel = new NotificacaoModel(strCnn);

            if (Request.QueryString["IDnotificacao"] != null)
            {
                int id_notificacao = Convert.ToInt32(Request.QueryString["IDnotificacao"].ToString());
                Notificacao notificacao = notModel.ObterNotificacao(id_notificacao);

                lblRemetente.Text = notificacao.Remetente.Nome;
                lblAssunto.Text = notificacao.Assunto;
                lblConteudo.Text = notificacao.Conteudo;
                lblDataEnvio.Text = notificacao.DataEnvio.ToString();

                idNotificacao.Value = notificacao.CodigoNotificacao.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaNotificacoes.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idNotificacao.Value);
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            NotificacaoModel nModel = new NotificacaoModel(strCnn);

            string msg = "";
            if (nModel.ExcluirNotificacao(nModel.ObterNotificacao(id)))
            {
                msg = GetLocalResourceObject("msgsucesso").ToString();
            }
            else
            {
                msg = GetLocalResourceObject("msgerro").ToString();
            }

            

            Response.Redirect("ListaNotificacoes.aspx?msg=" + msg);
        }

    }


}