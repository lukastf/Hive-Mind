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
    public partial class ExibirProprietario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            ProprietarioModel propModel = new ProprietarioModel(strCnn);

            if (Request.QueryString["IDproprietario"] != null)
            {
                int id_pessoa = Convert.ToInt32(Request.QueryString["IDproprietario"].ToString());
                Proprietario proprietario = propModel.ObterProprietarioID(id_pessoa);

                lblNome.Text = proprietario.Nome;
                lblRg.Text = proprietario.Rg;
                lblCpf.Text = proprietario.Cpf;
                lblTelefone.Text = proprietario.Telefone;
                lblEndereco.Text = proprietario.Endereco;
                lblEmail.Text = proprietario.Email;
                lblUsuario.Text = proprietario.Usuario;
                lblSenha.Text = proprietario.Senha;
                lblInformacao.Text = proprietario.Informacao;
            

                //idPessoa.Value = Convert.ToString(pessoa.Codigo);
                idPessoa.Value = proprietario.Codigo.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaProprietarios.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncluiAlteraProprietario.aspx?IDproprietario=" + idPessoa.Value);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idPessoa.Value);
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            ProprietarioModel pModel = new ProprietarioModel(strCnn);

            string msg = "";
            if (pModel.ExcluirProprietario(pModel.ObterProprietarioID(id)))
            {
                msg = GetLocalResourceObject("msgsucesso").ToString();
            }
            else
            {
                msg = GetLocalResourceObject("msgerro").ToString();
            }

            Response.Redirect("ListaProprietarios.aspx?msg=" + msg);
        }
    }
}