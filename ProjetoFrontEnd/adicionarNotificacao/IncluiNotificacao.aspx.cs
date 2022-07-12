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
    public partial class IncluiNotificacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            

                string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

                NotificacaoModel nModel = new NotificacaoModel(stringConexao);

                lblRemetente.Text = pes.Nome;

                //lista destinatarios
                PessoaModel pModel = new PessoaModel(stringConexao);
                ddlDestinatario.DataSource = pModel.Listar();
                ddlDestinatario.DataBind();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Notificacao notificacao = new Notificacao();

            Pessoa pes = null;
            if(Session["morador"] != null)
            {
                pes = (Pessoa)Session["morador"];
            }
            else if (Session["sindico"] != null)
            {
                pes = (Pessoa)Session["sindico"];
            }
            else if (Session["funcionario"] != null)
            {
                pes = (Pessoa)Session["funcionario"];
            }
            else if (Session["admin"] != null)
            {
                pes = (Pessoa)Session["admin"];
            }
            else if (Session["sindico"] != null)
            {
                pes = (Pessoa)Session["sindico"];
            }
            else if (Session["proprietario"] != null)
            {
                pes = (Pessoa)Session["proprietario"];
            }

            String stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            PessoaModel pModel = new PessoaModel(stringConexao);

            notificacao.Assunto = txtAssunto.Text;
            notificacao.Conteudo = txtConteudo.Text;
            notificacao.Remetente = pModel.ObterPessoa(pes.Codigo);
            notificacao.Destinatario = pModel.ObterPessoa(int.Parse(ddlDestinatario.SelectedValue));

            NotificacaoModel model = new NotificacaoModel(stringConexao);
            string msg = "";

                if (model.InserirNotificacao(notificacao))
                {
                    msg = GetLocalResourceObject("notifEnviada").ToString();
                }
                else
                {
                    msg = GetLocalResourceObject("notifErro").ToString();
                }



                if (msg != null)
                {
                    PanelMensagens.Visible = true;
                    lblMensagem.Text = msg;
                }

                //Response.Redirect("../adicionarNotificacao/ListaNotificacoes.aspx" + msg);
        }



        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Inicio.aspx");
        }

        protected void ddlDestinatario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}