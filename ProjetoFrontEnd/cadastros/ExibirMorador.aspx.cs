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
    public partial class ExibirMorador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            MoradorModel moradorModel = new MoradorModel(strCnn);

            if (Request.QueryString["IDmorador"] != null)
            {
                int id_pessoa = Convert.ToInt32(Request.QueryString["IDmorador"].ToString());
                Morador morador = moradorModel.ObterMoradorID(id_pessoa);

                lblNome.Text = morador.Nome;
                lblRg.Text = morador.Rg;
                lblCpf.Text = morador.Cpf;
                lblTelefone.Text = morador.Telefone;
                lblEndereco.Text = morador.Endereco;
                lblEmail.Text = morador.Email;
                lblUsuario.Text = morador.Usuario;
                lblSenha.Text = morador.Senha;
               
                lblDataEntrada.Text = morador.DataEntrada;
                lblDataSaida.Text = morador.DataSaida;

                //idPessoa.Value = Convert.ToString(pessoa.Codigo);
                idPessoa.Value = morador.Codigo.ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaMoradores.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncluiAlteraMorador.aspx?IDmorador=" + idPessoa.Value);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idPessoa.Value);
            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            MoradorModel mModel = new MoradorModel(strCnn);

            string msg = "";
            if (mModel.ExcluirMorador(mModel.ObterMoradorID(id)))
            {
                msg = GetLocalResourceObject("msgsucesso").ToString();
            }
            else
            {
                msg = GetLocalResourceObject("msgerro").ToString();
            }

            Response.Redirect("ListaMoradores.aspx?msg=" + msg);
        }
           

     }
}