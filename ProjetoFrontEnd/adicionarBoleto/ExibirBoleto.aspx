<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="ExibirBoleto.aspx.cs" Inherits="ProjetoFrontEnd.adicionarBoleto.ExibirBoleto" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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

    <asp:HiddenField ID="idBoleto" runat="server" />

    <div class="form-group">
        <asp:Label ID="lblUnidadeL" runat="server" Text="Unidade: " meta:resourcekey="lblUnidadeLResource1" />
        <asp:Label ID="lblUnidade" runat="server" meta:resourcekey="lblUnidadeResource1" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblValorL" runat="server" Text="Valor: " meta:resourcekey="lblValorLResource1" />
        <asp:Label ID="lblValor" runat="server" meta:resourcekey="lblValorResource1" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblDataGeracaoL" runat="server" Text="Data de geração: " meta:resourcekey="lblDataGeracaoLResource1" />
        <asp:Label ID="lblDataGeracao" runat="server" meta:resourcekey="lblDataGeracaoResource1" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblDataValidadeL" runat="server" Text="Validade: " meta:resourcekey="lblDataValidadeLResource1" />
        <asp:Label ID="lblDataValidade" runat="server" meta:resourcekey="lblDataValidadeResource1" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblDataPagamentoL" runat="server" Text="Data de pagamento: " meta:resourcekey="lblDataPagamentoLResource1" />
        <asp:Label ID="lblDataPagamento" runat="server" meta:resourcekey="lblDataPagamentoResource1" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblBancoReferenteL" runat="server" Text="Banco: " meta:resourcekey="lblBancoReferenteLResource1" />
        <asp:Label ID="lblBancoReferente" runat="server" meta:resourcekey="lblBancoReferenteResource1" />
    </div>

    <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-danger" runat="server" OnClick="btnCancelar_Click" meta:resourcekey="btnCancelarResource1" />
    <asp:Button ID="btnEditar" Text="Editar" CssClass="btn btn-primary" runat="server" OnClick="btnEditar_Click" meta:resourcekey="btnEditarResource1" Visible="false" /> 
    <asp:Button ID="btnExcluir" Text="Excluir" CssClass="btn btn-warning"
         runat="server" OnClick="btnExcluir_Click" 
         OnClientClick="return confirma();" meta:resourcekey="btnExcluirResource1"/>

</asp:Content>
