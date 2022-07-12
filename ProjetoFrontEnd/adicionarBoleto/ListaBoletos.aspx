<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="ListaBoletos.aspx.cs" Inherits="ProjetoFrontEnd.adicionarBoleto.ListaBoletos" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="corpo" runat="server">

    <h3>
        <asp:Literal ID="Literal0" runat="server" Text="<%$ resources: tituloBoleto %>"></asp:Literal>

    </h3>
    

    <asp:Panel ID="PanelMensagens" runat="server" 
        CssClass="alert alert-success" Visible="False" meta:resourcekey="PanelMensagensResource1">
        <asp:Label ID="lblMensagem" runat="server" meta:resourcekey="lblMensagemResource1"></asp:Label>
    </asp:Panel>

    <asp:HyperLink ID="hplNovo" runat="server"
        CssClass="btn btn-success" 
        NavigateUrl="~/adicionarBoleto/IncluiAlteraBoleto.aspx" meta:resourcekey="hplNovoResource1" Text="Novo Boleto"></asp:HyperLink>

    <br /><br />
    <asp:Repeater ID="listaBoletos" runat="server">
        
        <HeaderTemplate>
            <table class="table table-condensed">
                <tr>
                    <th>
                        <asp:Literal ID="Literal1" runat="server" Text="<%$ resources: idBoleto %>"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal2" runat="server" Text="<%$ resources: unidade %>"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal3" runat="server" Text="<%$ resources: valor %>"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal4" runat="server" Text="<%$ resources: datageracao %>"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal5" runat="server" Text="<%$ resources: datavalidade %>"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal6" runat="server" Text="<%$ resources: datapagamento %>"></asp:Literal>
                    </th>
                    <th>
                        <asp:Literal ID="Literal7" runat="server" Text="<%$ resources: banco %>"></asp:Literal>
                    </th>


                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# DataBinder.Eval(Container.DataItem, "CodigoBoleto") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "Localizacao") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "Valor") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "DataGeracao") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "DataValidade") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "DataPagamento") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "BancoReferente") %></td>

                <td>                  
                    <asp:HyperLink ID="hplExibir" runat="server" CssClass="btn btn-info"
                        NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "CodigoBoleto",
                            "ExibirBoleto.aspx?IDboleto={0}") %>' meta:resourcekey="hplExibirResource1" Text="Exibir"></asp:HyperLink>
                   
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    
</asp:Content>
