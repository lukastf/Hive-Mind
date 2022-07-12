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
    public partial class IncluiAlteraMorador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IDmorador"] != null && !IsPostBack)
            {
                string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

                int id_pessoa = Convert.ToInt32(Request.QueryString["IDmorador"].ToString());

                MoradorModel moradorModel = new MoradorModel(stringConexao);

                Morador morador = moradorModel.ObterMoradorID(id_pessoa);


                txtNome.Text = morador.Nome;
                txtRg.Text = morador.Rg;
                txtCpf.Text = morador.Cpf;
                txtTelefone.Text = morador.Telefone;
                txtEndereco.Text = morador.Endereco;
                txtEmail.Text = morador.Email;
                txtUsuario.Text = morador.Usuario;
                txtSenha.Text = morador.Senha;            
                txtDataEntrada.Text = morador.DataEntrada;
                txtDataSaida.Text = morador.DataSaida;

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaMoradores.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            Morador morador = new Morador();

            morador.Nome = txtNome.Text;
            morador.Rg = txtRg.Text;
            morador.Cpf = txtCpf.Text;
            morador.Telefone = txtTelefone.Text;
            morador.Endereco = txtEndereco.Text;
            morador.Email = txtEmail.Text;
            morador.Usuario = txtUsuario.Text;
            morador.Senha = txtSenha.Text;
            morador.DataEntrada = txtDataEntrada.Text;
            morador.DataSaida = txtDataSaida.Text;

            

            MoradorModel model = new MoradorModel(stringConexao);

            string msg = "";

            //modificação para editar
            if (Request.QueryString["IDmorador"] != null)
            {
                morador.Codigo = Convert.ToInt32(Request.QueryString["IDmorador"].ToString());
                if (model.EditarMorador(morador))
                {
                    msg = "Morador " + morador.Nome + " editado com sucesso!";
                }
                else
                {
                    msg = "Erro ao editar  " + morador.Nome + " tente mais tarde!";
                }
            }
            else
            {
                if (model.InserirMorador(morador))
                {
                    msg = "Morador " + morador.Nome + " adicionado com sucesso!";
                }
                else
                {
                    msg = "Erro!";
                }
            }

            Response.Redirect("ListaMoradores.aspx?msg=" + msg);

        }
    }
}