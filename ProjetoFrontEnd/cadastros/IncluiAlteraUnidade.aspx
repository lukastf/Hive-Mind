<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="IncluiAlteraUnidade.aspx.cs" Inherits="ProjetoFrontEnd.cadastros.IncluiAlteraUnidade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../res/js/mascaras.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="corpo" runat="server">
    <fieldset>
        <legend>Cadastro de Unidade</legend>

        <div class="form-group">
            <asp:Label ID ="lblNomePessoa" runat="server" Text="Nome do Morador: " CssClass="control-label"></asp:Label>
            <asp:DropDownList ID="DropDownList1" DataValueField="Codigo" DataTextField="Nome" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">          
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID ="lblNomeProprietario" runat="server" Text="Nome do Proprietario: " CssClass="control-label"></asp:Label>
            <asp:DropDownList ID="DropDownList2" DataValueField="Codigo" DataTextField="Nome" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">          
            </asp:DropDownList>
        </div>

        <div class="form-group col-md-3">
            <asp:Label ID="lblLocalizacao" runat="server" 
                Text="Localização" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtlocalizacao" CssClass="form-control"
                 runat="server" placeholder="Digite o local da unidade"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="O campo é obrigatório!"
                Text="Campo requerido" ControlToValidate="txtlocalizacao" ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>

        <div class="form-group navbar-right">     
        <asp:Button ID="btnCancelar" CausesValidation="false" runat="server" Text="Cancelar"
            CssClass=" btn btn-danger btn-lg" OnClick="btnCancelar_Click"/>        
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar"
            CssClass="btn btn-primary btn-lg" OnClick="btnSalvar_Click"/>
        </div>

    </fieldset>
</asp:Content>
