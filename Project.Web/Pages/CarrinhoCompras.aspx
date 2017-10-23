<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="CarrinhoCompras.aspx.cs" Inherits="Project.Web.Pages.CarrinhoCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="panel panel-primary">
                <div class="panel-heading bg-primary">
                    <h2>Carrinho de Compras</h2>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gridCarrinho" runat="server" GridLines="None" CssClass="table table-hover" AutoGenerateColumns="false" RowStyle-VerticalAlign="Middle" >
                        <EmptyDataTemplate>
                            Seu carrinho está vazio.
                        </EmptyDataTemplate>
                        <Columns>     
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <img src="/Images/<%#Eval("Livro.Foto") %>" width="60" height="80" />
                                </ItemTemplate>
                            </asp:TemplateField>                                                 
                            <asp:BoundField HeaderText="Código" DataField="Livro.IdLivro" />
                            <asp:BoundField HeaderText="Título" DataField="Livro.Titulo" />
                            <asp:BoundField HeaderText="Quantidade" DataField="Quantidade" />
                            <asp:BoundField HeaderText="Valor" DataField="ValorTotal" />
                            <asp:TemplateField>
                    <ItemTemplate>

                        <asp:LinkButton ID="btnExclusao" runat="server" CssClass="btn btn-danger btn-sm" 
                                    CommandArgument='<%# Eval("Livro.IdLivro") %>' OnClick="btnExclusao_Click">   <i class="glyphicon glyphicon-trash"></i></asp:LinkButton>

                    </ItemTemplate>              
                   
                </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="panel-footer">
                    <asp:Button ID="btnFinaliza" runat="server" Text="Finalizar Compra" CssClass="btn btn-success" OnClick="btnFinaliza_Click" />
                    <asp:Button ID="btnVoltar" runat="server" Text="Página Inicial" CssClass="btn btn-primary" PostBackUrl="/Default.aspx" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
