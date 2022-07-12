<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="ListaNotificacoes.aspx.cs" Inherits="ProjetoFrontEnd.adicionarNotificacao.ListaNotificacoes" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="corpo" runat="server">

    <h3>
        <asp:Literal ID="Literal5" runat="server" Text="<%$ resources: notificacoes %>"></asp:Literal>
    </h3>

     <br /><br />
  
    <asp:Panel ID="PanelMensagens" runat="server" 
        CssClass="alert alert-success" Visible="False" meta:resourcekey="PanelMensagensResource1">
        <asp:Label ID="lblMensagem" runat="server" meta:resourcekey="lblMensagemResource1"></asp:Label>
    </asp:Panel>

    <asp:Repeater ID="listaNotificacoes" runat="server">
        
        <HeaderTemplate>
            <table class="table table-condensed">
                <tr>
                    <td>
                        <asp:Literal ID="Literal1" runat="server" Text="<%$ resources: codigo %>"></asp:Literal>
                    </td>
                    <th>
                        <asp:Literal ID="Literal2" runat="server" Text="<%$ resources: remetente %>"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal3" runat="server" Text="<%$ resources: assunto %>"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal4" runat="server" Text="<%$ resources: dataEnvio %>"></asp:Literal>
                    </th>

                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# DataBinder.Eval(Container.DataItem, "CodigoNotificacao") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "NomeRemetente") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "Assunto") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "DataEnvio") %></td>

                <td>                  
                    <asp:HyperLink ID="hplExibir" runat="server" CssClass="btn btn-info"
                        NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "CodigoNotificacao",
                            "ExibirNotificacao.aspx?IDnotificacao={0}") %>' meta:resourcekey="hplExibirResource1">Exibir</asp:HyperLink>
                   
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
