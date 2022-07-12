using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Model;
using System.Configuration;

namespace ProjetoFrontEnd
{
    public partial class controlLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            Sindico sindico = Session["sindico"] as Sindico;
            if (sindico == null)
            {
                panelNaoLogado.Visible = true;
                panelloginSindico.Visible = false;
            }
            else
            {
                panelNaoLogado.Visible = false;
                panelloginAdmin.Visible = false;
                panelloginFuncionario.Visible = false;
                panelloginMorador.Visible = false;
                panelloginProprietario.Visible = false;

                panelloginSindico.Visible = true;
                lblNomeSin.Text = sindico.Nome;
                return;
            }

            Proprietario proprietario = Session["proprietario"] as Proprietario;
            if (proprietario == null)
            {
                panelNaoLogado.Visible = true;
                panelloginProprietario.Visible = false;
            }
            else
            {
                panelNaoLogado.Visible = false;
                panelloginAdmin.Visible = false;
                panelloginFuncionario.Visible = false;
                panelloginMorador.Visible = false;
                panelloginSindico.Visible = false;

                panelloginProprietario.Visible = true;
                lblNomeProprietario.Text = proprietario.Nome;
                return;
            }

            Morador morador = Session["morador"] as Morador;
            if (morador == null)
            {
                panelNaoLogado.Visible = true;
                panelloginMorador.Visible = false;
            }
            else
            {
                panelNaoLogado.Visible = false;
                panelloginAdmin.Visible = false;
                panelloginFuncionario.Visible = false;
                panelloginProprietario.Visible = false;
                panelloginSindico.Visible = false;

                panelloginMorador.Visible = true;
                lblNomeMorador.Text = morador.Nome;
                return;
            }

            Funcionario funcionario = Session["funcionario"] as Funcionario;
            if (funcionario == null)
            {
                panelNaoLogado.Visible = true;
                panelloginFuncionario.Visible = false;
            }
            else
            {
                panelNaoLogado.Visible = false;
                panelloginAdmin.Visible = false;
                panelloginProprietario.Visible = false;
                panelloginSindico.Visible = false;
                panelloginMorador.Visible = false;

                panelloginFuncionario.Visible = true;
                lblNomeFun.Text = funcionario.Nome;
                return;
            }

            Funcionario admin = Session["admin"] as Funcionario;
            if (admin == null)
            {
                panelNaoLogado.Visible = true;
                panelloginAdmin.Visible = false;
            }
            else
            {
                panelNaoLogado.Visible = false;
                panelloginFuncionario.Visible = false;
                panelloginMorador.Visible = false;
                panelloginSindico.Visible = false;
                panelloginProprietario.Visible = false;
                

                panelloginAdmin.Visible = true;
                lblNomeAdmin.Text = admin.Nome;
                return;
            }
        }

        protected void lnkSair_Click(object sender, EventArgs e)
        {
            Session.Remove("sindico");
            Session.Remove("proprietario");
            Session.Remove("morador");
            Session.Remove("funcionario");
            Session.Remove("admin");
            Response.Redirect("/Inicio.aspx");
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {

            string strCnn = ConfigurationManager.
                ConnectionStrings["stringConexao"].ConnectionString;

            FuncionarioModel funcmodel = new FuncionarioModel(strCnn);
            Funcionario funcionario = funcmodel.ObterFuncionarioLogin(txtUsuario.Text, txtSenha.Text);

            if (funcionario != null )
            {
                if (funcionario.StatusAdmin == true)
                {
                    Session["admin"] = funcionario;
                    Response.Redirect("/Inicio.aspx");
                }
                else
                {
                    Session["funcionario"] = funcionario;
                    Response.Redirect("/Inicio.aspx");
                }
            }
            

            SindicoModel sinModel = new SindicoModel(strCnn);
            Sindico sindico = sinModel.ObterSindicoLogin(txtUsuario.Text, txtSenha.Text);

            if(sindico != null)
            {
                Session["sindico"] = sindico;
                Response.Redirect("/Inicio.aspx");
            }

            ProprietarioModel propModel = new ProprietarioModel(strCnn);
            Proprietario proprietario = propModel.ObterProprietarioLogin(txtUsuario.Text, txtSenha.Text);

            if(proprietario != null)
            {
                Session["proprietario"] = proprietario;
                Response.Redirect("/Inicio.aspx");
            }

            MoradorModel moradorModel = new MoradorModel(strCnn);
            Morador morador = moradorModel.ObterMoradorLogin(txtUsuario.Text, txtSenha.Text);

            if(morador != null)
            {
                Session["morador"] = morador;
                Response.Redirect("/Inicio.aspx");
            }

            else
            {
                lblErro.Text = GetLocalResourceObject("loginInvalido").ToString();
            }

        }
    }
}