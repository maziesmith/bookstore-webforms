<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConsultaCategoria.aspx.cs" Inherits="Project.Web.Pages.ConsultaCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">

    <h2 class="text-center">Categorias Cadastradas</h2><br /><br /><br />
    <hr />

    <div class="col-md-6 col-md-offset-3">
    

        <asp:Label ID="lblMensagem" runat="server" />

        <asp:GridView ID="gridCategorias" runat="server" GridLines="None" CssClass="table table-hover" AutoGenerateColumns="false">
            <Columns>

                <asp:BoundField HeaderText="Código" DataField="IdCategoria" />
                <asp:BoundField HeaderText="Nome" DataField="Nome" />
                <asp:HyperLinkField Text="Editar" DataNavigateUrlFormatString="/AreaRestritaAdm/DetalhesCategoria.aspx?id={0}" DataNavigateUrlFields="IdCategoria" ControlStyle-CssClass="btn btn-primary btn-sm" />
                

                <asp:TemplateField>
                    <ItemTemplate>

                        <asp:Button ID="btnExclusao" runat="server" Text="Excluir" CssClass="btn btn-danger btn-sm" 
                                    CommandArgument='<%# Eval("IdCategoria") %>' OnClick="btnExclusao_Click" />

                    </ItemTemplate>              
                   
                </asp:TemplateField>

                </Columns>
        </asp:GridView>
        <div class="spaceBotton100"></div>
   
    </div>
</asp:Content>
