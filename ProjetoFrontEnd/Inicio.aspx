<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ProjetoFrontEnd.Inicio" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="corpo" runat="server">

    <%if(Session["admin"] != null){ %>
    <asp:Panel ID="Panel5" runat="server" class="alert alert-success" Visible="False" meta:resourcekey="Panel5Resource1">
        <i class="fa-lg fa fa-bullhorn"></i>
        <asp:Label ID="Label5" runat="server" meta:resourceKey="Label5Resource1"></asp:Label>
    </asp:Panel>

    <h3 style="color:blue;">
                <asp:Literal ID="Literal1" runat="server" Text="<%$ resources:admin %>"></asp:Literal>
            </h3>

    <%}else if(Session["sindico"] != null){ %>
    <asp:Panel ID="Panel1" runat="server" class="alert alert-success" Visible="False" meta:resourcekey="Panel1Resource1">
        <i class="fa-lg fa fa-bullhorn"></i>
        <asp:Label ID="Label1" runat="server" meta:resourceKey="Label1Resource1"></asp:Label>
    </asp:Panel>

    <h3 style="color:blue;">
                <asp:Literal ID="Literal2" runat="server" Text="<%$ resources:sindico %>"></asp:Literal>
            </h3>

    <%}else if(Session["morador"] != null){ %>
    <asp:Panel ID="Panel2" runat="server" class="alert alert-success" Visible="False" meta:resourcekey="Panel2Resource1">
        <i class="fa-lg fa fa-bullhorn"></i>
        <asp:Label ID="Label2" runat="server" meta:resourceKey="Label2Resource1"></asp:Label>
    </asp:Panel>

    <h3 style="color:blue;">
                <asp:Literal ID="Literal3" runat="server" Text="<%$ resources:morador %>"></asp:Literal>
            </h3>

    <%}else if(Session["funcionario"] != null){ %>
    <asp:Panel ID="Panel3" runat="server" class="alert alert-success" Visible="False" meta:resourcekey="Panel3Resource1">
        <i class="fa-lg fa fa-bullhorn"></i>
        <asp:Label ID="Label3" runat="server" meta:resourceKey="Label3Resource1"></asp:Label>
    </asp:Panel>

    <h3 style="color:blue;">
                <asp:Literal ID="Literal4" runat="server" Text="<%$ resources: funcionario %>"></asp:Literal>
            </h3>
    <%}else if(Session["proprietario"] != null){ %>
    <asp:Panel ID="Panel4" runat="server" class="alert alert-success" Visible="False" meta:resourcekey="Panel4Resource1">
        <i class="fa-lg fa fa-bullhorn"></i>
        <asp:Label ID="Label4" runat="server" meta:resourceKey="Label4Resource1"></asp:Label>
    </asp:Panel>

    <h3 style="color:blue;">
                <asp:Literal ID="Literal5" runat="server" Text="<%$ resources:proprietario %>"></asp:Literal>
            </h3>
    <%}else{ %>
    <h1><asp:Literal ID="Literal6" runat="server" Text="<%$ resources:hivemind %>"></asp:Literal></h1>
    <br /><br />
    <h4 style="color:red;"><asp:Literal ID="Literal7" runat="server" Text="<%$ resources:login %>"></asp:Literal></h4>

    <%} %>
</asp:Content>
