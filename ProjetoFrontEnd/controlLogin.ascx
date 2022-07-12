<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="controlLogin.ascx.cs" Inherits="ProjetoFrontEnd.controlLogin" %>

<asp:Panel ID="panelNaoLogado" runat="server" meta:resourcekey="panelNaoLogadoResource1">
    <div class="navbar-form pull-right">
        <asp:TextBox ID="txtUsuario" runat="server"
            placeholder="<%$ resources: usuario %>" CssClass="form-control" meta:resourcekey="txtUsuarioResource1"></asp:TextBox>

        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"
            placeholder="<%$ resources: senha %>" CssClass="form-control" meta:resourcekey="txtSenhaResource1"></asp:TextBox>

        <asp:Button ID="btnEntrar" runat="server" CssClass="btn btn-info"
            Text="Entrar" OnClick="btnEntrar_Click" style="height: 30px" meta:resourcekey="btnEntrarResource1" />

        <asp:Label ID="lblErro" runat="server" ForeColor="Red" meta:resourcekey="lblErroResource1"></asp:Label>
    </div>
</asp:Panel>

<asp:Panel ID="panelloginSindico" runat="server" meta:resourcekey="panelloginSindicoResource1">

    <div class="btn-group navbar-form navbar-right">
        <button type="button" class="btn btn-info">
            <span class="glyphicon glyphicon-user"></span>
            <asp:Label ID="lblNomeSin" runat="server" meta:resourcekey="lblNomeSinResource1"></asp:Label>
        </button>
        <button type="button" class="btn btn-info dropdown-toggle"
            data-toggle="dropdown">
            <span class="caret"></span>
            <span class="sr-only">Toggle Dropdown</span>
        </button>
        <ul class="dropdown-menu" role="menu">
            <li>
                <asp:LinkButton ID="lnkAlterarSenhaSin" runat="server" meta:resourcekey="lnkAlterarSenhaSinResource1">
                    <span class="glyphicon glyphicon-cog"></span> Alterar Senha
                </asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="lnkSairSin" runat="server" OnClick="lnkSair_Click" meta:resourcekey="lnkSairSinResource1">
                    <span class="glyphicon glyphicon-off"></span> Sair
                </asp:LinkButton>
            </li>
        </ul>
    </div>

</asp:Panel>

<asp:Panel ID="panelloginFuncionario" runat="server" meta:resourcekey="panelloginFuncionarioResource1">
    <div class="btn-group navbar-form navbar-right">
    <button type="button" class="btn btn-info">
            <span class="glyphicon glyphicon-user"></span>
            <asp:Label ID="lblNomeFun" runat="server" meta:resourcekey="lblNomeFunResource1"></asp:Label>
        </button>
        <button type="button" class="btn btn-info dropdown-toggle"
            data-toggle="dropdown">
            <span class="caret"></span>
            <span class="sr-only">Toggle Dropdown</span>
        </button>
        <ul class="dropdown-menu" role="menu">
            <li>
                <asp:LinkButton ID="lnkAlterarFunc" runat="server" meta:resourcekey="lnkAlterarFuncResource1">
                    <span class="glyphicon glyphicon-cog"></span> Alterar Senha
                </asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="lnkSairFunc" runat="server" OnClick="lnkSair_Click" meta:resourcekey="lnkSairFuncResource1">
                    <span class="glyphicon glyphicon-off"></span> Sair
                </asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Panel>

<asp:Panel ID="panelloginMorador" runat="server" meta:resourcekey="panelloginMoradorResource1">
    <div class="btn-group navbar-form navbar-right">
    <button type="button" class="btn btn-info">
            <span class="glyphicon glyphicon-user"></span>
            <asp:Label ID="lblNomeMorador" runat="server" meta:resourcekey="lblNomeMoradorResource1"></asp:Label>
        </button>
        <button type="button" class="btn btn-info dropdown-toggle"
            data-toggle="dropdown">
            <span class="caret"></span>
            <span class="sr-only">Toggle Dropdown</span>
        </button>
        <ul class="dropdown-menu" role="menu">
            <li>
                <asp:LinkButton ID="lnkAlterarMorador" runat="server" meta:resourcekey="lnkAlterarMoradorResource1">
                    <span class="glyphicon glyphicon-cog"></span> Alterar Senha
                </asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="lnkSairMorador" runat="server" OnClick="lnkSair_Click" meta:resourcekey="lnkSairMoradorResource1">
                    <span class="glyphicon glyphicon-off"></span> Sair
                </asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Panel>

<asp:Panel ID="panelloginProprietario" runat="server" meta:resourcekey="panelloginProprietarioResource1">

    <div class="btn-group navbar-form navbar-right">
        <button type="button" class="btn btn-info">
            <span class="glyphicon glyphicon-user"></span>
            <asp:Label ID="lblNomeProprietario" runat="server" meta:resourcekey="lblNomeProprietarioResource1"></asp:Label>
        </button>
        <button type="button" class="btn btn-info dropdown-toggle"
            data-toggle="dropdown">
            <span class="caret"></span>
            <span class="sr-only">Toggle Dropdown</span>
        </button>
        <ul class="dropdown-menu" role="menu">
            <li>
                <asp:LinkButton ID="lnkAlteraProprietario" runat="server" meta:resourcekey="lnkAlteraProprietarioResource1">
                    <span class="glyphicon glyphicon-cog"></span> Alterar Senha
                </asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="lnkSairProprietario" runat="server" OnClick="lnkSair_Click" meta:resourcekey="lnkSairProprietarioResource1">
                    <span class="glyphicon glyphicon-off"></span> Sair
                </asp:LinkButton>
            </li>
        </ul>
    </div>

</asp:Panel>

<asp:Panel ID="panelloginAdmin" runat="server" meta:resourcekey="panelloginAdminResource1">
    <div class="btn-group navbar-form navbar-right">
    <button type="button" class="btn btn-info">
            <span class="glyphicon glyphicon-user"></span>
            <asp:Label ID="lblNomeAdmin" runat="server" meta:resourcekey="lblNomeAdminResource1"></asp:Label>
        </button>
        <button type="button" class="btn btn-info dropdown-toggle"
            data-toggle="dropdown">
            <span class="caret"></span>
            <span class="sr-only">Toggle Dropdown</span>
        </button>
        <ul class="dropdown-menu" role="menu">
            <li>
                <asp:LinkButton ID="lnkAlterarAdmin" runat="server" meta:resourcekey="lnkAlterarAdminResource1">
                    <span class="glyphicon glyphicon-cog"></span> Alterar Senha
                </asp:LinkButton>
            </li>
            <li>
                <asp:LinkButton ID="lnkSairAdmin" runat="server" OnClick="lnkSair_Click" meta:resourcekey="lnkSairAdminResource1">
                    <span class="glyphicon glyphicon-off"></span> Sair
                </asp:LinkButton>
            </li>
        </ul>
    </div>
</asp:Panel>
