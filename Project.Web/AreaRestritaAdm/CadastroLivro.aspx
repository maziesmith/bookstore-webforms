<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="CadastroLivro.aspx.cs" Inherits="Project.Web.Pages.CadastroLivro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-3"></div>
    <div class="col-md-6">



        <div class="panel panel-primary">
            <div class="panel-heading bg-primary">
                <h2 class="text-center">Cadastro de Livros</h2>
            </div>

            <div class="panel-body">
                Informe abaixo os dados do novo livro:
                    <hr />

                <label>Título:</label><br />
                <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control required" placeholder="Digite aqui" />
                <br />

                <label>Nome do Autor:</label><br />
                <asp:TextBox ID="txtAutor" runat="server" CssClass="form-control required" placeholder="Digite aqui" />
                <br />

                <label>Editora:</label><br />
                <asp:TextBox ID="txtEditora" runat="server" CssClass="form-control required" placeholder="Digite aqui" />
                <br />

                <label>Ano da Edição:</label><br />
                <asp:TextBox ID="txtAnoEdicao" runat="server" CssClass="form-control txtNumero required" placeholder="Digite aqui" />
                <asp:RegularExpressionValidator ID="regexAnoEdicao" runat="server" ControlToValidate="txtAnoEdicao" Text="Preencha com 4 caracteres numéricos." ForeColor="Red" ValidationExpression="\d{4}" />
                <br />

                <label>Preço:</label><br />
                <asp:TextBox ID="txtPreco" runat="server" CssClass="form-control required" placeholder="Digite aqui" />
                <br />

                <label>Categoria:</label><br />
                <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control required" />
                <br />

                <label>Quantidade:</label>
                <asp:TextBox ID="txtQuantidade" runat="server" TextMode="Number" min="1" CssClass="form-control quantidade required" />
                <br />

                <label>Descrição:</label>
                <asp:TextBox ID="txtDescricao" runat="server" TextMode="MultiLine" CssClass="form-control" />
                <br />

                <label>Imagem:</label>
                <asp:FileUpload ID="uplFoto" runat="server" />
                <br />
            </div>
            <div class="panel-footer">
                <br />
                <asp:Button ID="btnCadastro" runat="server" Text="Cadastrar Livro" CssClass="btn btn-success btn-block" OnClick="btnCadastro_Click" />
                <br />
                <br />

                <asp:Label ID="lblMensagem" runat="server" />
            </div>
        </div>
    </div>
    <div class="col-md-3"></div>

</asp:Content>
