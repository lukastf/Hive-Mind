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
    public partial class IncluiAlteraUnidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;
                PessoaModel pModel = new PessoaModel(stringConexao);

                DropDownList1.DataSource = pModel.Listar();
                DropDownList1.DataBind();

                DropDownList2.DataSource = pModel.Listar();
                DropDownList2.DataBind();
            }

            if (Request.QueryString["IDunidade"] != null && !IsPostBack)
            {
                string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

                int id_unidade = Convert.ToInt32(Request.QueryString["IDunidade"].ToString());

                UnidadeModel uModel = new UnidadeModel(stringConexao);
                PessoaModel pModel = new PessoaModel(stringConexao);

               Unidade unidade = uModel.ObterUnidadeID(id_unidade);
               //Pessoa pessoa = pModel.ObterPessoa(id_pessoa);
                
                //List<String> lista1 = pModel.Listar();
                //DropDownList1.DataSource = pModel.Listar();
                //DropDownList1.DataSource = unidade.Morador;
                //DropDownList1.DataBind();

                //////List<String> lista2 = pModel.ListarNome();
                //DropDownList2.DataSource = pModel.Listar();
                //DropDownList2.DataSource = unidade.Proprietario;
                //DropDownList2.DataBind();

               
                txtlocalizacao.Text = unidade.Localizacao;

            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;
            Unidade unidade = new Unidade();
            PessoaModel pModel = new PessoaModel(stringConexao);


            unidade.Morador = pModel.ObterPessoa(int.Parse(DropDownList1.SelectedValue));
            unidade.Proprietario = pModel.ObterPessoa(int.Parse(DropDownList2.SelectedValue));
            unidade.Localizacao = txtlocalizacao.Text;

            UnidadeModel model = new UnidadeModel(stringConexao);
            string msg = "";

            //modificação para editar
            if (Request.QueryString["IDunidade"] != null)
            {
                unidade.CodigoUnidade = Convert.ToInt32(Request.QueryString["IDunidade"].ToString());
                if (model.EditarUnidade(unidade))
                {
                    msg = "Unidade " + unidade.CodigoUnidade + " editado com sucesso!";
                }
                else
                {
                    msg = "Erro ao editar  " + unidade.CodigoUnidade + " tente mais tarde!";
                }
            }
            else
            {
                if (model.InserirUnidade(unidade))
                {
                    msg = "Unidade " + unidade.CodigoUnidade + " adicionado com sucesso!";
                }
                else
                {
                    msg = "Erro!";
                }
            }
            Response.Redirect("ListaUnidades.aspx?msg=" + msg);
        }
 

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaUnidades.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}