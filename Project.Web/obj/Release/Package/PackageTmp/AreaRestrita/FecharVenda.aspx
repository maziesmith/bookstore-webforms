<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="FecharVenda.aspx.cs" Inherits="Project.Web.Pages.FecharVenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row"></div>
    <div class="row font12">
        <div class="col-md-3" >
            <h4>Endereço de Enterga:</h4>
            <hr />

            <label>Destinatário:</label>
            <asp:TextBox ID="txtDestinatario" runat="server" CssClass="form-control required" />
            <br />

            <label>CEP:</label>
            <asp:TextBox ID="txtCep" runat="server" MaxLength="9" CssClass="form-control txtCep required" />
            <br />

            <label>Logradouro:</label>
            <asp:TextBox ID="txtLogradouro" runat="server" CssClass="form-control required" />
            <br />

            <label>Número:</label>
            <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control txtNumero required" />
            <br />

            <label>Complemento:</label>
            <asp:TextBox ID="txtComplemento" runat="server" CssClass="form-control" />
            <br />

            <label>Bairro:</label>
            <asp:TextBox ID="txtBairro" runat="server" CssClass="form-control required" />
            <br />

            <label>Cidade:</label>
            <asp:TextBox ID="txtCidade" runat="server" CssClass="form-control required" />
            <br />

            <label>UF:</label>
            <asp:DropDownList ID="ddlEstados" runat="server" CssClass="form-control txtNumero required" />
            <br />

        </div>
        <div class="col-md-4 col-md-offset-1">
            <div class="row">
                <h4>Livros:</h4>
                <asp:GridView ID="gridCarrinho" runat="server" GridLines="None" CssClass="table table-hover" AutoGenerateColumns="false" RowStyle-VerticalAlign="Middle" >
                        
                        <Columns>     
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <img src="/Images/<%#Eval("Livro.Foto") %>" width="30" height="45" />
                                </ItemTemplate>
                            </asp:TemplateField>                                             
                            
                            <asp:BoundField HeaderText="Título" DataField="Livro.Titulo" />
                            <asp:BoundField HeaderText="Quantidade" DataField="Quantidade" />
                            <asp:BoundField HeaderText="Valor" DataField="ValorTotal" />
                            
                        </Columns>
                    </asp:GridView>
            </div>            
        </div>
        <div class="col-md-3 col-md-offset-1">
            <div class="row" style="background-color:">
                <h4>Informações do Pagamento:</h4>
                <label>Nome do Titular:</label>
                <asp:TextBox ID="txtTitular" runat="server" CssClass="form-control required" />
                <br />

                <label>Número do Cartão:</label>
                <asp:TextBox ID="txtNumCartao" runat="server" CssClass="form-control required" />
                <br />

                <label>Validade:</label>
                <asp:TextBox ID="txtValidade" runat="server" CssClass="form-control txtNumero required"  />
                <br />

                <label>Código de Segurança:</label>
                <asp:TextBox ID="txtCodigoSeguranca" runat="server" CssClass="form-control txtNumero required" />
                <br />               
                
            </div>
            <div class="row">
                <h3><asp:Label ID="lblValorTotal" runat="server" /></h3>
                <br />

                <asp:Button ID="btnConfimrma" runat="server" Text="Confirmar Pedido" CssClass="btn btn-success" OnClick="btnConfimrma_Click" />
                <br />

                <asp:Label ID="lblMensagem" runat="server" />
            </div>
        </div>
    </div>
    
</asp:Content>
