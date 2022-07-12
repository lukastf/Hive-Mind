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
    public partial class ExibirSindico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            SindicoModel sinModel = new SindicoModel(strCnn);

            if (Request.QueryString["IDsindico"] != null)
            {
                int id_pessoa = Convert.ToInt32(Request.QueryString["IDsindico"].ToString());
                Sindico sindico = sinModel.ObterSindicoID(id_pessoa);

                lblNome.Text = sindico.Nome;
                lblRg.Text = sindico.Rg;
                lblCpf.Text = sindico.Cpf;
                lblTelefone.Text = sindico.Telefone;
                lblEndereco.Text = sindico.Endereco;
                lblEmail.Text = sindico.Email;
                lblUsuario.Text = sindico.Usuario;
                lblSenha.Text = sindico.Senha;
                lblInformacao.Text = sindico.Informacao;


                //idPessoa.Value = Convert.ToString(pessoa.Codigo);
                idPessoa.Value = sindico.Codigo.ToString();

            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaSindicos.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncluiAlteraSindico.aspx?IDsindico=" + idPessoa.Value);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idPessoa.Value);
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            SindicoModel sinModel = new SindicoModel(strCnn);

            string msg = "";
            if (sinModel.ExcluirSindico(sinModel.ObterSindicoID(id)))
            {
                msg = GetLocalResourceObject("msgsucesso").ToString();
            }
            else
            {
                msg = GetLocalResourceObject("msgerro").ToString();
            }

            Response.Redirect("ListaSindicos.aspx?msg=" + msg);
        }
    }
}