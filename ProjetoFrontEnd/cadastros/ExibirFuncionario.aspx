<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="ExibirFuncionario.aspx.cs" Inherits="ProjetoFrontEnd.cadastros.ExibirFuncionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function confirma() {
            if (confirm("Deseja realmente apagar a pessoa?")) {
                return true;
            } else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="corpo" runat="server">

       <asp:HiddenField ID="idPessoa" runat="server" />

    <div class="form-group">
        <asp:Label ID="lblNomeL" runat="server" Text="Nome: " />
        <asp:Label ID="lblNome" runat="server" />
    </div>
    <%if(Session["admin"] != null){ %>
    <div class="form-group">
        <asp:Label ID="lblRgL" runat="server" Text="RG: " />
        <asp:Label ID="lblRg" runat="server" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblCpfL" runat="server" Text="CPF: " />
        <asp:Label ID="lblCpf" runat="server" />
    </div>
    <%} %>
    <div class="form-group">
        <asp:Label ID="lblTelefoneL" runat="server" Text="Telefone:" />
        <asp:Label ID="lblTelefone" runat="server" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblEnderecoL" runat="server" Text="Endereco:" />
        <asp:Label ID="lblEndereco" runat="server" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblEmailL" runat="server" Text="Email: " />
        <asp:Label ID="lblEmail" runat="server" />
    </div>
    <%if(Session["admin"] != null){ %>
    <div class="form-group">
        <asp:Label ID="lblUsuarioL" runat="server" Text="Usuario: " />
        <asp:Label ID="lblUsuario" runat="server" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblSenhaLabel" runat="server" Text="Senha: " />
        <asp:Label ID="lblSenha" runat="server" />
    </div>
    <%} %>
    <div class="form-group">
        <asp:Label ID="lblDataAdmissaoL" runat="server" Text="Data de Admissao:" />
        <asp:Label ID="lblDataAdmissao" runat="server" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblDataDemissaoL" runat="server" Text="Data de Demissao:" />
        <asp:Label ID="lblDataDemissao" runat="server" />
    </div>


    <div class="form-group">
        <asp:Label ID="lblStatusAdminL" runat="server" Text="Administrador: "  />
        <asp:Label ID="lblStatusAdmin" runat="server" />
    </div>

    <%if(Session["admin"] != null){ %>
    <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" runat="server" OnClick="btnCancelar_Click" />
    <asp:Button ID="btnEditar" Text="Editar" CssClass="btn btn-primary" runat="server" OnClick="btnEditar_Click" /> 
    <asp:Button ID="btnExcluir" Text="Excluir" CssClass="btn btn-warning"
         runat="server" OnClick="btnExcluir_Click" 
         OnClientClick="return confirma();"/>
    <%} %>
</asp:Content>
