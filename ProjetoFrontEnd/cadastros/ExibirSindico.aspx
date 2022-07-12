<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="ExibirSindico.aspx.cs" Inherits="ProjetoFrontEnd.cadastros.ExibirSindico" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function confirma() {
            if (confirm("Deseja realmente apagar o sindico?")) {
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
        <asp:Label ID="lblNomeL" runat="server" Text="Nome: " meta:resourcekey="lblNomeLResource1" />
        <asp:Label ID="lblNome" runat="server" meta:resourcekey="lblNomeResource1" />
    </div>
    <%if(Session["admin"] != null){ %>
    <div class="form-group">
        <asp:Label ID="lblRgL" runat="server" Text="RG: " meta:resourcekey="lblRgLResource1" />
        <asp:Label ID="lblRg" runat="server" meta:resourcekey="lblRgResource1" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblCpfL" runat="server" Text="CPF: " meta:resourcekey="lblCpfLResource1" />
        <asp:Label ID="lblCpf" runat="server" meta:resourcekey="lblCpfResource1" />
    </div>
    <%} %>
    <div class="form-group">
        <asp:Label ID="lblTelefoneL" runat="server" Text="Telefone: " meta:resourcekey="lblTelefoneLResource1" />
        <asp:Label ID="lblTelefone" runat="server" meta:resourcekey="lblTelefoneResource1" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblEnderecoL" runat="server" Text="Endereco: " meta:resourcekey="lblEnderecoLResource1" />
        <asp:Label ID="lblEndereco" runat="server" meta:resourcekey="lblEnderecoResource1" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblEmailL" runat="server" Text="Email: " meta:resourcekey="lblEmailLResource1" />
        <asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmailResource1" />
    </div>
    <%if(Session["admin"] != null){ %>
    <div class="form-group">
        <asp:Label ID="lblUsuarioL" runat="server" Text="Usuario: " meta:resourcekey="lblUsuarioLResource1" />
        <asp:Label ID="lblUsuario" runat="server" meta:resourcekey="lblUsuarioResource1" />
    </div>
    <div class="form-group">
        <asp:Label ID="lblSenhaLabel" runat="server" Text="Senha: " meta:resourcekey="lblSenhaLabelResource1" />
        <asp:Label ID="lblSenha" runat="server" meta:resourcekey="lblSenhaResource1" />
    </div>
    <%} %>
    <div class="form-group">
        <asp:Label ID="lblinfo" runat="server" Text="Informação: " meta:resourcekey="lblinfoResource1"  />
        <asp:Label ID="lblInformacao" runat="server" meta:resourcekey="lblInformacaoResource1" />
    </div>
    <%if(Session["admin"] != null){ %>
    <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" runat="server" OnClick="btnCancelar_Click" meta:resourcekey="btnCancelarResource1" />
    <asp:Button ID="btnEditar" Text="Editar" CssClass="btn btn-primary" runat="server" OnClick="btnEditar_Click" meta:resourcekey="btnEditarResource1" /> 
    <asp:Button ID="btnExcluir" Text="Excluir" CssClass="btn btn-warning"
         runat="server" OnClick="btnExcluir_Click" 
         OnClientClick="return confirma();" meta:resourcekey="btnExcluirResource1"/>
    <%} %>
</asp:Content>
