<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="IncluiAlteraMorador.aspx.cs" Inherits="ProjetoFrontEnd.cadastros.IncluiAlteraMorador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../res/js/mascaras.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="corpo" runat="server">

    <fieldset>
        <legend>Cadastro de Morador</legend>
    <div class="form-group col-md-3">
            <asp:Label ID="lblNome" runat="server" 
                Text="Nome" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtNome" CssClass="form-control"
                 runat="server" placeholder="Digite o nome"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="O campo nome é obrigatório!"
                Text="Campo requerido" ControlToValidate="txtNome" ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>

        <div class="form-group col-md-5">
            <asp:Label ID="lblRg" runat="server" 
                Text="Rg" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtRg" CssClass="form-control" MaxLength="12" onkeypress="return Mascara(this, Rg);"
                 runat="server" placeholder="Digite o Rg"></asp:TextBox>
        </div>

        <div class="form-group col-md-5">
            <asp:Label ID="lblCpf" runat="server" 
                Text="Cpf" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtCpf" CssClass="form-control" MaxLength="14" onkeypress="return Mascara(this, Cpf);"
                 runat="server" placeholder="Digite o cpf"></asp:TextBox>
        </div>

        <div class="form-group col-md-5">           
            <asp:Label ID="lblTelefone" runat="server" 
                Text="Telefone" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtTelefone" CssClass="form-control" onkeypress="return Mascara(this, Telefone);"
                 runat="server" placeholder="Insira o Telefone"></asp:TextBox>
        </div>

        <div class="form-group col-md-10">           
            <asp:Label ID="lblEndereco" runat="server" 
                Text="Endereco" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtEndereco" CssClass="form-control"
                 runat="server" placeholder="Digite o Endereco"></asp:TextBox>
        </div>

        <div class="form-group col-md-7">
            <asp:Label ID="lblEmail" runat="server" 
                Text="Email" CssClass="control-label"></asp:Label>

            <asp:TextBox ID="txtEmail" CssClass="form-control"
                 runat="server" placeholder="Digite o email"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="O campo nome é obrigatório!"
                Text="Campo requerido" ControlToValidate="txtEmail" ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>

        <div class="form-group col-md-3">
            <asp:Label ID="lblUsuario" runat="server" 
                Text="Usuario" CssClass="control-label"></asp:Label>

            <asp:TextBox ID="txtUsuario" CssClass="form-control"
                 runat="server" placeholder="Digite o usuario"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ErrorMessage="O campo usuario é obrigatório!"
                Text="Campo requerido" ControlToValidate="txtUsuario" ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>

        <div class="form-group col-md-3">
            <asp:Label ID="lblSenha" runat="server" 
                Text="Senha" CssClass="control-label"></asp:Label>

            <asp:TextBox ID="txtSenha" CssClass="form-control"
                 runat="server" placeholder="Digite a Senha"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ErrorMessage="O campo senha é obrigatório!"
                Text="Campo requerido" ControlToValidate="txtUsuario" ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>

        <div class="form-group col-md-3">
            
            <asp:Label ID="lblDataEntrada" runat="server" 
                Text="Data de Entrada: " CssClass="control-label"></asp:Label>

            <asp:TextBox ID="txtDataEntrada" CssClass="form-control" MaxLength="10" onkeypress="return Mascara(this, Data);"
                 runat="server" placeholder="DD/MM/AAAA ex:31/12/1999"></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            
            <asp:Label ID="lblDataSaida" runat="server" 
                Text="Data de Saida: " CssClass="control-label"></asp:Label>

            <asp:TextBox ID="txtDataSaida" CssClass="form-control" MaxLength="10" onkeypress="return Mascara(this, Data);"
                 runat="server" placeholder="DD/MM/AAAA Se houver"></asp:TextBox>
        </div>

        <div class="form-group navbar-right">     
        <asp:Button ID="btnCancelar" CausesValidation="false" runat="server" Text="Cancelar"
            CssClass=" btn btn-danger btn-lg" OnClick="btnCancelar_Click"/>        
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar"
            CssClass="btn btn-primary btn-lg" OnClick="btnSalvar_Click"/>
        </div>

    </fieldset>
</asp:Content>
