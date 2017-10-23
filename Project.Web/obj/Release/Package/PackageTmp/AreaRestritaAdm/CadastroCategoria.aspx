<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="CadastroCategoria.aspx.cs" Inherits="Project.Web.Pages.CadastroCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
        

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">

    <h2>Adicionar Nova Categoria</h2><br /><br /><br />
    <hr />
    
    <div class="col-md-6 col-md-offset-5">
    
        <label>Nome:</label><br />
        <asp:TextBox id="txtNome" runat="server" placeholder="Digite aqui" CssClass="required" />
        <br /><br />
        <asp:Button ID="btnCadastro" runat="server" Text="Adicionar Categoria" CssClass="btn btn-primary btn-sm" OnClick="btnCadastro_Click" />
        <br /><br />
        <asp:Label ID="lblMensagem" runat="server" />
        <br /><br /> 

    </div>
   
</asp:Content>
