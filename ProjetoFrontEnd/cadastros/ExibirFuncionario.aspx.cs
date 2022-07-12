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
    public partial class ExibirFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            FuncionarioModel funcModel = new FuncionarioModel(strCnn);

            if (Request.QueryString["IDfuncionario"] != null)
            {
                int id_pessoa = Convert.ToInt32(Request.QueryString["IDfuncionario"].ToString());
                Funcionario funcionario = funcModel.ObterFuncionarioID(id_pessoa);

                lblNome.Text = funcionario.Nome;
                lblRg.Text = funcionario.Rg;
                lblCpf.Text = funcionario.Cpf;
                lblTelefone.Text = funcionario.Telefone;
                lblEndereco.Text = funcionario.Endereco;
                lblEmail.Text = funcionario.Email;
                lblUsuario.Text = funcionario.Usuario;
                lblSenha.Text = funcionario.Senha;
                lblDataAdmissao.Text = funcionario.DataAdmissao;
                lblDataDemissao.Text = funcionario.DataDemissao;
                lblStatusAdmin.Text = Convert.ToString(funcionario.StatusAdmin);

                //idPessoa.Value = Convert.ToString(pessoa.Codigo);
                idPessoa.Value = funcionario.Codigo.ToString();

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaFuncionarios.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncluiAlteraFuncionario.aspx?IDfuncionario=" + idPessoa.Value);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idPessoa.Value);
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

             FuncionarioModel funcModel = new FuncionarioModel(strCnn);

            string msg = "";
            if (funcModel.ExcluirFuncionario(funcModel.ObterFuncionarioID(id)))
            {
                msg = GetLocalResourceObject("msgsucesso").ToString();
            }
            else
            {
                msg = GetLocalResourceObject("msgerro").ToString();
            }

            Response.Redirect("ListaFuncionarios.aspx?msg=" + msg);
        }
    }
}