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
    public partial class IncluiAlteraProprietario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["IDproprietario"] != null && !IsPostBack)
            {
                string stringConexao = ConfigurationManager.
                        ConnectionStrings["stringConexao"].ConnectionString;

                int id_pessoa = Convert.ToInt32(Request.QueryString["IDproprietario"].ToString());

                ProprietarioModel pModel = new ProprietarioModel(stringConexao);

                Proprietario p = pModel.ObterProprietarioID(id_pessoa);



                txtNome.Text = p.Nome;
                txtRg.Text = p.Rg;
                txtCpf.Text = p.Cpf;
                txtTelefone.Text = p.Telefone;
                txtEndereco.Text = p.Endereco;
                txtEmail.Text = p.Email;
                txtUsuario.Text = p.Usuario;
                txtSenha.Text = p.Senha;
                txtInformacao.Text = p.Informacao;
              
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaProprietarios.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            //recupera a string de conexao do arquivo web.config
            string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;
            //declara um objeto produto
            Proprietario proprietario = new Proprietario();
            //preenche o objeto produto
            proprietario.Nome = txtNome.Text;
            proprietario.Rg = txtRg.Text;
            proprietario.Cpf = txtCpf.Text;
            proprietario.Telefone = txtTelefone.Text;
            proprietario.Endereco = txtEndereco.Text;
            proprietario.Email = txtEmail.Text;
            proprietario.Usuario = txtUsuario.Text;
            proprietario.Senha = txtSenha.Text;
            proprietario.Informacao = txtInformacao.Text;
          
            //objeto model
            ProprietarioModel pModel = new ProprietarioModel(stringConexao);

            string msg = "";

            if (Request.QueryString["IDproprietario"] != null)
            {
                //edição
                proprietario.Codigo = Convert.ToInt32(Request.QueryString["IDproprietario"].ToString());
                if (pModel.EditarProprietario(proprietario))
                {
                    msg = "Proprietario: " + proprietario.Nome + " editado com sucesso!";
                }
                else
                {
                    msg = "Erro ao editar proprietario, tente novamente mais tarde!";
                }
            }
            else
            {
                //invoca metodo Inserir
                if (pModel.InserirProprietario(proprietario))
                {
                    msg = "Proprietario: " + proprietario.Nome + " salvo com sucesso!";
                }
                else
                {
                    msg = "Erro ao salvar a proprietario!";
                }
            }

            Response.Redirect("ListaProprietarios.aspx?msg=" + msg);
        }

        protected void cbxStatus_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}