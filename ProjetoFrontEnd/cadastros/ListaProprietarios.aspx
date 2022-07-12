<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="ListaProprietarios.aspx.cs" Inherits="ProjetoFrontEnd.cadastros.ListaProprietarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="corpo" runat="server">

     <h3>Lista de Proprietarios</h3>

    <asp:Panel ID="PanelMensagens" runat="server" 
        CssClass="alert alert-success" Visible="false">
        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
    </asp:Panel>
    <%if(Session["admin"] != null){ %>
    <asp:HyperLink ID="hplNovo" runat="server"
        CssClass="btn btn-success" 
        NavigateUrl="~/cadastros/IncluiAlteraProprietario.aspx">Novo Proprietario</asp:HyperLink>
    <%} %>
    <br /><br />

    <asp:Repeater ID="listaProprietarios" runat="server">
        <HeaderTemplate>
            <table class="table table-responsive">
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
                <%--<%if(Session["admin"] != null){ %>
                <td><%# DataBinder.Eval(Container.DataItem, "Usuario") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "Senha") %></td>
                <%} %>--%>
                <td><%# DataBinder.Eval(Container.DataItem, "Informacao") %></td>

                <td>
                    <asp:HyperLink ID="hplExibir" runat="server" CssClass="btn btn-info"
                        NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Codigo",
                            "ExibirProprietario.aspx?IDproprietario={0}") %>'>Exibir</asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
