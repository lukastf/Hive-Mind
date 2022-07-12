<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="ListaUnidades.aspx.cs" Inherits="ProjetoFrontEnd.cadastros.ListaUnidades" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="corpo" runat="server">

    <h3>Lista de Unidades</h3>

    <asp:Panel ID="PanelMensagens" runat="server" 
        CssClass="alert alert-success" Visible="False" meta:resourcekey="PanelMensagensResource1">
        <asp:Label ID="lblMensagem" runat="server" meta:resourcekey="lblMensagemResource1"></asp:Label>
    </asp:Panel>

    <%if(Session["admin"] != null){ %>
    <asp:HyperLink ID="hplNovo" runat="server"
        CssClass="btn btn-success" 
        NavigateUrl="~/cadastros/IncluiAlteraUnidade.aspx" meta:resourcekey="hplNovoResource1">Nova Unidade</asp:HyperLink>
    <%} %>
        <br /><br />
    <asp:Repeater ID="listaUnidades" runat="server">

        <HeaderTemplate>
            <table class="table table-condensed">
                <tr>
                    <th>ID Unidade</th>
                    <th>Morador</th>
                    <th>Proprietario</th>
                    <th>Local</th>

                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# DataBinder.Eval(Container.DataItem, "CodigoUnidade") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "NomeMorador") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "NomeProprietario") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "Localizacao") %></td>

                <td>                  
                    <asp:HyperLink ID="hplExibir" runat="server" CssClass="btn btn-info"
                        NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "CodigoUnidade",
                            "ExibirUnidade.aspx?IDunidade={0}") %>' meta:resourcekey="hplExibirResource1">Exibir</asp:HyperLink>
                   
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    
</asp:Content>
