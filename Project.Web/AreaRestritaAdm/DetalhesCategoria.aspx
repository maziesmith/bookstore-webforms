<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalhesCategoria.aspx.cs" Inherits="Project.Web.Pages.DetalhesCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">

    <h2>Edição de Categoria</h2>
    <br />
    <br />
    <hr />
    <div class="col-md-6 col-md-offset-5">
        

            <label>Codigo:</label><br />
            <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="true" />
            <br /><br />

            <label>Nome:</label><br />
        <asp:TextBox id="txtNome" runat="server" placeholder="Digite aqui" CssClass="required" />           
            <br /><br />

            <asp:Button ID="btnEdicao" runat="server" Text="Concluir Edição" CssClass="btn btn-primary" OnClick="btnEdicao_Click" />
            <br /><br />
            
            <asp:Label ID="lblMensagem" runat="server" />
            <br /><br />
        
    </div>
        
</asp:Content>
