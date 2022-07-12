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
    public partial class IncluiAlteraSindico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IDsindico"] != null && !IsPostBack)
            {
                string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

                int id_pessoa = Convert.ToInt32(Request.QueryString["IDsindico"].ToString());

                SindicoModel sinModel = new SindicoModel(stringConexao);

                Sindico sindico = sinModel.ObterSindicoID(id_pessoa);


                txtNome.Text = sindico.Nome;
                txtRg.Text = sindico.Rg;
                txtCpf.Text = sindico.Cpf;
                txtTelefone.Text = sindico.Telefone;
                txtEndereco.Text = sindico.Endereco;
                txtEmail.Text = sindico.Email;
                txtUsuario.Text = sindico.Usuario;
                txtSenha.Text = sindico.Senha;
                txtDescricao.Text = sindico.Informacao;
            
            }
        }

        protected void cbxStatus_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;
            Sindico sindico = new Sindico();

            sindico.Nome = txtNome.Text;
            sindico.Rg = txtRg.Text;
            sindico.Cpf = txtCpf.Text;
            sindico.Telefone = txtTelefone.Text;
            sindico.Endereco = txtEndereco.Text;        
            sindico.Email = txtEmail.Text;
            sindico.Usuario = txtUsuario.Text;
            sindico.Senha = txtSenha.Text;       
            sindico.Informacao = txtDescricao.Text;


            SindicoModel model = new SindicoModel(stringConexao);

            string msg = "";

            //modificação para editar
            if (Request.QueryString["IDsindico"] != null)
            {
                sindico.Codigo = Convert.ToInt32(Request.QueryString["IDsindico"].ToString());
                if (model.EditarSindico(sindico))
                {
                    msg = "Sindico " + sindico.Nome + " editado com sucesso!";
                }
                else
                {
                    msg = "Erro ao editar  " + sindico.Nome + " tente mais tarde!";
                }
            }
            else
            {
                if (model.InserirSindico(sindico))
                {
                    msg = "Sindico " + sindico.Nome + " adicionado com sucesso!";
                }
                else
                {
                    msg = "Erro!";
                }
            }
            Response.Redirect("ListaSindicos.aspx?msg=" + msg);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaSindicos.aspx");
        }
    }
}