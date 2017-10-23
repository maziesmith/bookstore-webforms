<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConfirmacaoVenda.aspx.cs" Inherits="Project.Web.Pages.ConfirmacaoVenda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="col-md-6 col-md-offset-3 spaceTop80">
    <div class="panel panel-primary">
        <div class="panel-heading bg-primary">
            <h3>Confimação de Compra</h3>
        </div>
        <div class="panel-body">
            <h4 style="text-align:center;">Sua compra foi efetuada com sucesso.</h4>
            Dentro de alguns instantes você receberá um e-mail com os dados transação.
            <br />
            <br />
            <label>Nº da Compra:</label>&nbsp;<asp:Label ID="lblNúmero" runat="server" ForeColor="Blue" Font-Bold="true" />
            <br /> A BookStore agradece a sua preferência.
            <br /><br />

            <asp:LinkButton ID="btnVoltar" PostBackUrl="/Default.aspx" runat="server" Text="Voltar a página inicial" CssClass="btn btn-primary" />

        </div>
    </div>
</div>
</asp:Content>
