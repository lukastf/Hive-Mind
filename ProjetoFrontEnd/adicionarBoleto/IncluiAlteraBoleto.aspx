<%@ Page Title="" Language="C#" MasterPageFile="~/HiveMind.Master" AutoEventWireup="true" CodeBehind="IncluiAlteraBoleto.aspx.cs" Inherits="ProjetoFrontEnd.adicionarBoleto.IncluiAlteraBoleto" culture="auto" meta:resourcekey="PageResource2" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../res/js/mascaras.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="corpo" runat="server">

    <fieldset>
        <legend>Gerar Boleto</legend>

        <div class="form-group">
            <asp:Label ID ="lblUnidade" runat="server" Text="Unidade: " CssClass="control-label" meta:resourcekey="lblUnidadeResource2"></asp:Label>
            <asp:DropDownList ID="ddlUnidades"  DataValueField="CodigoUnidade" DataTextField="Localizacao" runat="server" OnSelectedIndexChanged="ddlUnidade_SelectedIndexChanged" meta:resourcekey="ddlUnidadesResource2" >          
            </asp:DropDownList>
        </div>



        <div class="form-group col-md-3">
            <asp:Label ID="lblvalor" runat="server" 
                Text="Valor" CssClass="control-label" meta:resourcekey="lblvalorResource2"></asp:Label>
            <asp:TextBox ID="txtvalor" CssClass="form-control"
                 runat="server" placeholder="Digite o valor" meta:resourcekey="txtvalorResource2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                Text="Campo requerido" ControlToValidate="txtvalor" ForeColor="Red" meta:resourcekey="RequiredFieldValidator1Resource2"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group col-md-6">
            
            <asp:Label ID="lblDataGeracao" runat="server" 
                Text="Data de Geração" CssClass="control-label" meta:resourcekey="lblDataGeracaoResource2"></asp:Label>

            <asp:TextBox ID="txtDataGeracao" CssClass="form-control" MaxLength="10" onkeypress="return Mascara(this, Data);"
                 runat="server" placeholder="DD/MM/AAAA ex:31/12/1999" meta:resourcekey="txtDataGeracaoResource2"></asp:TextBox>
        </div>

        <div class="form-group col-md-6">
            
            <asp:Label ID="lblDataValidade" runat="server" 
                Text="Data de Validade" CssClass="control-label" meta:resourcekey="lblDataValidadeResource2"></asp:Label>

            <asp:TextBox ID="txtDataValidade" CssClass="form-control" MaxLength="10" onkeypress="return Mascara(this, Data);"
                 runat="server" placeholder="DD/MM/AAAA ex:31/12/1999" meta:resourcekey="txtDataValidadeResource2"></asp:TextBox>
        </div>

        <div class="form-group col-md-6">
            
            <asp:Label ID="lblDataPagamento" runat="server" 
                Text="Data Pagamento" CssClass="control-label" meta:resourcekey="lblDataPagamentoResource2"></asp:Label>

            <asp:TextBox ID="txtDataPagamento" CssClass="form-control" MaxLength="10" onkeypress="return Mascara(this, Data);"
                 runat="server" placeholder="DD/MM/AAAA ex:31/12/1999" meta:resourcekey="txtDataPagamentoResource2"></asp:TextBox>
        </div>

        <div class="form-group col-md-6">
            <asp:Label ID="lblBancoReferente" runat="server" 
                Text="Banco" CssClass="control-label" meta:resourcekey="lblBancoReferenteResource2"></asp:Label>
            <asp:TextBox ID="txtBancoReferente" CssClass="form-control" MaxLength="12" 
                 runat="server" placeholder="Digite o nome do Banco" meta:resourcekey="txtBancoReferenteResource2"></asp:TextBox>
        </div>

        <div class="form-group  navbar-right">     
        <asp:Button ID="btnCancelar" CausesValidation="False" runat="server" Text="Cancelar"
            CssClass=" btn btn-danger btn-lg" OnClick="btnCancelar_Click" meta:resourcekey="btnCancelarResource2"/>        
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar"
            CssClass="btn btn-primary btn-lg" OnClick="btnSalvar_Click" meta:resourcekey="btnSalvarResource2"/>
        </div>

    </fieldset>

</asp:Content>
