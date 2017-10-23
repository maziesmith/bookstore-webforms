<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project.Web.Pages.CompraLivro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <nav class="navbar navbar-primary bg-defaultGrey" role="navigation">
        <div class="navbar-form">
            <div class="container">
                <div class="form-group col-md-2 col-md-offset-1 paddingLR0">
                    Filtros:
                            <asp:DropDownList ID="ddlPesquisa" runat="server" CssClass="form-control" Width="130px">
                                <asp:ListItem Value="1" Text="Título" />
                                <asp:ListItem Value="2" Text="Código" />
                                <asp:ListItem Value="3" Text="Autor" />
                                <asp:ListItem Value="4" Text="Categoria" />
                                <asp:ListItem Value="5" Text="Todos" />
                            </asp:DropDownList>
                </div>
                <div class="col-md-7">
                    <asp:TextBox ID="txtPesquisa" runat="server" CssClass="form-control" Width="625px" placeholder="Pesquisar..." />
                </div>
                <div class="col-md-1 paddingL0">
                    <asp:LinkButton ID="btnPesquisa3" runat="server" CssClass="btn btn-primary" OnClick="btnPesquisa3_Click"><i class="glyphicon glyphicon-search"></i></asp:LinkButton>
                </div>
            </div>
        </div>
    </nav>


    <asp:Label ID="lblMensagem" runat="server" Font-Bold="true" />

    <br />
    <br />

    

    <div class="row">
        <asp:ListView ID="listLivros" runat="server" DataKeyNames="IdLivro" GroupItemCount="4">
            <EmptyDataTemplate>
                <h3>Nenhum livro encontrado.</h3>
            </EmptyDataTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td id="td1" runat="server">
                    <table>
                        <tr>
                            <td>&nbsp; &nbsp;</td>
                            <td>
                                <a href="/Pages/DetalhesCompraLivro.aspx?id=<%#Eval("IdLivro") %>">
                                    <img src="/Images/<%#Eval("Foto") %>" height="110" width="75" />
                                </a>
                            </td>
                            <td>&nbsp; &nbsp;</td>
                            <td>
                                <a href="/Pages/DetalhesCompraLivro.aspx?id=<%#Eval("IdLivro") %>">
                                    <span>
                                        <h5 style="text-decoration: none;"><b><%#Eval("Titulo") %></b></h5>
                                    </span>
                                </a>                                                               
                                <span>
                                <br />
                                    <asp:Button ID="btnAut" runat="server" CssClass="text-primary" CommandArgument='<%#Eval("Autor") %>' Text='<%#Eval("Autor")%>' OnClick="btnAut_Click" BorderColor="Transparent" BackColor="Transparent" BorderStyle="None" />
                                </span>
                                <br />                                

                                <span>
                                    <b>Preço: </b><%#:String.Format("{0:c}", Eval("Preco")) %>
                                </span>
                                <br />
                            </td>
                        </tr>
                        <td>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</td>
                    </table>
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table id="tabelaLivros" runat="server">
                    <tr id="tr1" runat="server">
                        <td id="td3" runat="server">
                            <table id="groupPlaceholderContainer" runat="server">
                                <tr id="groupPlaceHolder" runat="server"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="tr2" runat="server">
                        <td id="td4" runat="server"></td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
    </div>

    <footer class="footerDefault"><b><a href="/Pages/LoginAdministrador.aspx">Entre</a> como administrador.</b></footer>
</asp:Content>
