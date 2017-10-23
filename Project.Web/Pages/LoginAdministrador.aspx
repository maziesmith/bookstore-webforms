<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginAdministrador.aspx.cs" Inherits="Project.Web.Pages.LoginAdministrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="height: 50px;"></div>
        <div class="col-md-4 col-md-offset-4">
            <div class="panel panel-primary">
                <div class="panel-heading bg-primary">
                    <h3>Login de Administrador</h3>
                </div>
                <div class="panel-body bg-lightgrey">
                    <label>Email:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control required" />

                    <label>Senha:</label>
                    <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control required" TextMode="Password" />
                    <br />
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success btn-block" Text="Entrar" OnClick="btnLogin_Click" />
                    
                    <br />
                    

                    <asp:Label ID="lblMensagem" runat="server" />
                </div>
            </div>
        </div>
</asp:Content>
