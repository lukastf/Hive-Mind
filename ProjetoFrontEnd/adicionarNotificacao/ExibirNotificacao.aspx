<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="ExibirNotificacao.aspx.cs" Inherits="ProjetoFrontEnd.adicionarNotificacao.ExibirNotificacao" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function confirma() {
            if (confirm("Deseja realmente apagar a notificação?")) {
                return true;
            } else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="corpo" runat="server">

    <asp:HiddenField ID="idNotificacao" runat="server" />

    <div class="form-group">
        <asp:Label ID="lblRemetenteL" runat="server" Text="Remetente: " meta:resourcekey="lblRemetenteLResource1" />
        <asp:Label ID="lblRemetente" runat="server" meta:resourcekey="lblRemetenteResource1" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblAssuntoL" runat="server" Text="Assunto: " meta:resourcekey="lblAssuntoLResource1" />
        <asp:Label ID="lblAssunto" runat="server" meta:resourcekey="lblAssuntoResource1" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblConteudoL" runat="server" Text="Conteudo: " meta:resourcekey="lblConteudoLResource1" />
        <asp:Label ID="lblConteudo" runat="server" meta:resourcekey="lblConteudoResource1" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblDataEnvioL" runat="server" Text="Data de Envio: " meta:resourcekey="lblDataEnvioLResource1" />
        <asp:Label ID="lblDataEnvio" runat="server" meta:resourcekey="lblDataEnvioResource1" />
    </div>

    <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" runat="server" OnClick="btnCancelar_Click" meta:resourcekey="btnCancelarResource1" />
    <asp:Button ID="btnExcluir" Text="Excluir" CssClass="btn btn-warning" runat="server" OnClick="btnExcluir_Click" 
         OnClientClick="return confirma();" meta:resourcekey="btnExcluirResource1"/>

</asp:Content>
