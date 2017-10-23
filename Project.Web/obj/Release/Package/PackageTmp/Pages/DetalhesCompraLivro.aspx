<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalhesCompraLivro.aspx.cs" Inherits="Project.Web.Pages.DetalhesCompraLivro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .quantidade {
            width: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-3">
        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn btn-sm btn-info" PostBackUrl="/Default.aspx" />
    </div>
    <div class="col-md-6">


        <div class="panel panel-primary">
            <div class="panel-heading bg-primary">
                <h4 class="text-center">
                    <asp:Label ID="lblTitulo" runat="server" />

                </h4>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-6">
                        <asp:Image ID="imgLivro" runat="server" BorderStyle="Solid" Height="305px" Width="210px" />
                    </div>
                    <div class="col-md-6">
                        <label>Informações:</label>
                        <hr />


                        <asp:Label ID="lblCodigo" runat="server" />
                        <br />

                        <asp:Label ID="lblAutor" runat="server" />
                        <br />

                        <asp:Label ID="lblCategoria" runat="server" />
                        <br />

                        <asp:Label ID="lblEditora" runat="server" />
                        <br />

                        <asp:Label ID="lblAnoEdicao" runat="server" />
                        <br />

                        <asp:Label ID="lblPreco" runat="server" />
                        <br />

                        <label>Quantidade:</label>
                        <asp:TextBox ID="txtQuantidade" runat="server" TextMode="Number" min="1" CssClass="quantidade" />
                        <br />   
                        <b><asp:Label ID="lblMensagem" runat="server" /></b>                     
                        <br />                        
                        <br />
                        <asp:Label ID="lblEsgotado" runat="server" Font-Bold="true" Font-Size="Larger" ForeColor="Red" />
                        
                        <asp:Button ID="btnContinuar" runat="server" Text="Continuar Comprando" CssClass="btn btn-sm btn-primary" Font-Size="Small" OnClick="btnContinuar_Click" />
                        <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar" CssClass="btn btn-sm btn-success" Font-Size="Small" OnClick="btnFinalizar_Click" />
                        
                        <asp:LinkButton ID="btnAdicionar" runat="server" CssClass="btn btn-primary" OnClick="btnAdicionar_Click"><i class="glyphicon glyphicon-plus"></i> Adicionar ao Carrinho</asp:LinkButton>
                        <br />
                        <br />
                        
                        
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-10 col-md-offset-1">
                        <hr />
                        <label>Descrição:</label><br />

                        <asp:Label ID="txtDescricao" runat="server" />
                        <br /><br />
                    </div>
                </div>
            </div>
        </div>


    </div>
    <div class="col-md-3"></div>
</asp:Content>
