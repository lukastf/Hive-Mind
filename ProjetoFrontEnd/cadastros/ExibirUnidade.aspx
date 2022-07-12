<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="ExibirUnidade.aspx.cs" Inherits="ProjetoFrontEnd.cadastros.ExibirUnidade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function confirma() {
            if (confirm("Deseja realmente apagar a unidade?")) {
                return true;
            } else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="corpo" runat="server">
    <asp:HiddenField ID="idUnidade" runat="server" />

    <div class="form-group">
        <asp:Label ID="lblCodUnidadeL" runat="server" Text="ID da Unidade: " />
        <asp:Label ID="lblCodUnidade" runat="server" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblMoradorL" runat="server" Text="Nome do Morador: " />
        <asp:Label ID="lblMorador" runat="server" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblProp" runat="server" Text="Nome do Proprietario: " />
        <asp:Label ID="lblProprietario" runat="server" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblLocalizacaoL" runat="server" Text="Localização: " />
        <asp:Label ID="lblLocalizacao" runat="server" />
    </div>
    <%if(Session["admin"] != null){ %>
    <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" runat="server" OnClick="btnCancelar_Click" />
    <asp:Button ID="btnEditar" Text="Editar" CssClass="btn btn-primary" runat="server" OnClick="btnEditar_Click" /> 
    <asp:Button ID="btnExcluir" Text="Excluir" CssClass="btn btn-warning"
         runat="server" OnClick="btnExcluir_Click" 
         OnClientClick="return confirma();"/>
    <%} %>
</asp:Content>
