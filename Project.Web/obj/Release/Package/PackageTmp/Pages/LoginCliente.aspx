<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginCliente.aspx.cs" Inherits="Project.Web.Pages.LoginCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="row height50"></div>
        <div class="col-md-4 col-md-offset-4">
            <div class="panel panel-primary">
                <div class="panel-heading bg-primary">
                    <h3>Autenticação de Clientes</h3>
                </div>
                <div class="panel-body">
                    <label>Email:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control required" />

                    <label>Senha:</label>
                    <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control required" TextMode="Password" />
                    <br />
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success btn-block" Text="Entrar" OnClick="btnLogin_Click" />
                    <p class="text-center font12">Ainda não é cliente? <a href="/Pages/CadastroCliente.aspx">Cadastre-se aqui.</a></p>
                    <br />
                    

                    <asp:Label ID="lblMensagem" runat="server" />
                </div>
            </div>
        </div>
  
</asp:Content>
