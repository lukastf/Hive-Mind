<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="IncluiNotificacao.aspx.cs" Inherits="ProjetoFrontEnd.adicionarNotificacao.IncluiNotificacao" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../res/js/mascaras.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="corpo" runat="server">

    <fieldset>
        <legend>
            <asp:Literal ID="Literal1" runat="server" Text="<%$ resources: enviarNotif %>"></asp:Literal>
        </legend>

        <asp:Panel ID="PanelMensagens" runat="server" 
        CssClass="alert alert-success" Visible="False" meta:resourcekey="PanelMensagensResource1">
        <asp:Label ID="lblMensagem" runat="server" meta:resourcekey="lblMensagemResource1"></asp:Label>
    </asp:Panel>

        <div class="form-group col-md-3">
            
            <asp:Label ID="lblRemetenteL" runat="server" 
                Text="Seu Nome: " CssClass="control-label" meta:resourcekey="lblRemetenteLResource1"></asp:Label>

            <asp:Label ID="lblRemetente" CssClass="control-label" 
                 runat="server" meta:resourcekey="lblRemetenteResource1" ></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID ="lblDestinatario" runat="server" Text="Destinatário: " CssClass="control-label" meta:resourcekey="lblDestinatarioResource1"></asp:Label>
            <asp:DropDownList ID="ddlDestinatario"  DataValueField="Codigo" DataTextField="Nome" runat="server" OnSelectedIndexChanged="ddlDestinatario_SelectedIndexChanged" meta:resourcekey="ddlDestinatarioResource1" >          
            </asp:DropDownList>
        </div>

        <div class="form-group col-md-7">
            
            <asp:Label ID="lblAssunto" runat="server" 
                Text="Assunto: " CssClass="control-label" meta:resourcekey="lblAssuntoResource1"></asp:Label>

            <asp:TextBox ID="txtAssunto" CssClass="form-control" 
                 runat="server" placeholder="<%$ resources: digiteAssunto %>" meta:resourcekey="txtAssuntoResource1"></asp:TextBox>
        </div>

        <div class="form-group col-md-10">
            
            <asp:Label ID="lblConteudo" runat="server" 
                Text="Conteudo: " CssClass="control-label" meta:resourcekey="lblConteudoResource1"></asp:Label>

            <asp:TextBox ID="txtConteudo" CssClass="form-control" 
                 runat="server" placeholder="<%$ resources: digiteConteudo %>" TextMode="MultiLine" meta:resourcekey="txtConteudoResource1"></asp:TextBox>
        </div>

        
        <div class="form-group navbar-right">
        <asp:Button ID="btnCancelar" CausesValidation="False" runat="server" Text="Cancelar"
            CssClass=" btn btn-danger btn-lg" OnClick="btnCancelar_Click" meta:resourcekey="btnCancelarResource1"/>
        <asp:Button ID="btnSalvar" runat="server" Text="Enviar"
            CssClass="btn btn-primary btn-lg" OnClick="btnSalvar_Click" meta:resourcekey="btnSalvarResource1"/>
        </div>

    </fieldset>

</asp:Content>
