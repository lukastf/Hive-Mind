using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Model;


namespace ProjetoFrontEnd.cadastros
{
    public partial class IncluiAlteraFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["IDfuncionario"] != null && !IsPostBack)
            {
                string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

                int id_pessoa = Convert.ToInt32(Request.QueryString["IDfuncionario"].ToString());

                FuncionarioModel funcModel = new FuncionarioModel(stringConexao);

                Funcionario func = funcModel.ObterFuncionarioID(id_pessoa);


                txtNome.Text = func.Nome;
                txtRg.Text = func.Rg;
                txtCpf.Text = func.Cpf;
                txtTelefone.Text = func.Telefone;
                txtEndereco.Text = func.Endereco;
                txtEmail.Text = func.Email;
                txtUsuario.Text = func.Usuario;
                txtSenha.Text = func.Senha;
                txtDataAdmi.Text = func.DataAdmissao;
                txtDataDemi.Text = func.DataDemissao;
                cbxStatusAdmin.Checked = func.StatusAdmin;
            }

        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaFuncionarios.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            Funcionario funcionario = new Funcionario();

            funcionario.Nome = txtNome.Text;
            funcionario.Rg = txtRg.Text;
            funcionario.Cpf = txtCpf.Text;
            funcionario.Telefone = txtTelefone.Text;
            funcionario.Endereco = txtEndereco.Text;
            funcionario.Email = txtEmail.Text;
            funcionario.Usuario = txtUsuario.Text;
            funcionario.Senha = txtSenha.Text;
            funcionario.DataAdmissao = txtDataAdmi.Text;
            funcionario.DataDemissao = txtDataDemi.Text;
            funcionario.StatusAdmin = cbxStatusAdmin.Checked;

            String stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            FuncionarioModel model = new FuncionarioModel(stringConexao);

            string msg = "";

            //modificação para editar
            if (Request.QueryString["IDfuncionario"] != null)
            {
                funcionario.Codigo = Convert.ToInt32(Request.QueryString["IDfuncionario"].ToString());
                if (model.EditarFuncionario(funcionario))
                {
                    msg = "Funcionario " + funcionario.Nome + " editado com sucesso!";
                }
                else
                {
                    msg = "Erro ao editar  " + funcionario.Nome + " tente mais tarde!";
                }
            }
            else
            {
                if (model.InserirFuncionario(funcionario))
                {
                    msg = "Funcionario " + funcionario.Nome + " adicionado com sucesso!";
                }
                else
                {
                    msg = "Erro!";
                }
            }

            Response.Redirect("ListaFuncionarios.aspx?msg=" + msg);

        }

        protected void cbxStatusAdmin_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}