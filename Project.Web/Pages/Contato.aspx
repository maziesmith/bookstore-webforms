<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contato.aspx.cs" Inherits="Project.Web.Pages.Contato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6 col-md-offset-3">
        <div class="panel panel-primary">
            <div class="panel-heading bg-primary">
                <h3 class="text-center">Contato</h3>
            </div>
            <div class="panel-body">
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control required" placeholder="Digite seu nome" />
                <br />

                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control required" placeholder="Digite seu e-mail" />
                <br />

                <asp:TextBox ID="txtAssunto" runat="server" CssClass="form-control required" placeholder="Digite o assunto" />
                <br />

                <asp:TextBox ID="txtMensagem" runat="server" CssClass="form-control required" TextMode="MultiLine" placeholder="Digite sua mensagem" Height="200px" />
                <br />
                <asp:Label ID="lblMensagem" runat="server" />
            </div>
            <div class="panel-footer">
                <asp:Button ID="btnEnvio" runat="server" CssClass="btn btn-success form-control" Text="Enviar" OnClick="btnEnvio_Click" />
            </div>
        </div>
    </div>
</asp:Content>
