<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="ListaSindicos.aspx.cs" Inherits="ProjetoFrontEnd.cadastros.ListaSindicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="corpo" runat="server">

    <h3>Lista de Sindicos</h3>

    <asp:Panel ID="PanelMensagens" runat="server" 
        CssClass="alert alert-success" Visible="false">
        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
    </asp:Panel>
    <%if(Session["admin"] != null){ %>
    <asp:HyperLink ID="hplNovo" runat="server"
        CssClass="btn btn-success" 
        NavigateUrl="~/cadastros/IncluiAlteraSindico.aspx">Novo Sindico</asp:HyperLink>
    <%} %>
    <br /><br />
    <asp:Repeater ID="listaSindicos" runat="server">
        
        <HeaderTemplate>
            <table class="table table-condensed">
                <tr>
                    <th>ID</th>
                    <th>Nome</th>
                    <%--<%if(Session["admin"] != null){ %>
                    <th>Rg</th>
                    <th>Cpf</th>
                    <%} %>--%>
                    <th>Telefone</th>
                    <th>Endereco</th>
                    <th>Email</th>
                    <%--<%if(Session["admin"] != null){ %>
                    <th>Usuario</th>
                    <th>Senha</th>
                    <%} %>--%>
                    <th>Informacao</th>

                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# DataBinder.Eval(Container.DataItem, "Codigo") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "Nome") %></td>
                <%--<%if(Session["admin"] != null){ %>
                <td><%# DataBinder.Eval(Container.DataItem, "Rg") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "Cpf") %></td>
                <%} %>--%>
                <td><%# DataBinder.Eval(Container.DataItem, "Telefone") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "Endereco") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "Email") %></td>
                <%--%if(Session["admin"] != null){ %>
                <td><%# DataBinder.Eval(Container.DataItem, "Usuario") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "Senha") %></td>
                <%} %>--%>
                <td><%# DataBinder.Eval(Container.DataItem, "Informacao") %></td>

                <td>                  
                    <asp:HyperLink ID="hplExibir" runat="server" CssClass="btn btn-info"
                        NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Codigo",
                            "ExibirSindico.aspx?IDsindico={0}") %>'>Exibir</asp:HyperLink>
                   
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
