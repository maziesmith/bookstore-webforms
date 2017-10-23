<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="ComprasCliente.aspx.cs" Inherits="Project.Web.AreaRestrita.MinhasCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div class="panel panel-primary">
                <div class="panel-heading bg-primary">
                    <h2>Minhas Compras</h2>
                </div>
                <div class="panel-body">

                    <asp:Label ID="lblMensagem" runat="server" />

                    <asp:GridView ID="gridCompras" runat="server" GridLines="None" CssClass="table table-hover" AutoGenerateColumns="false" >
                        <EmptyDataTemplate>
                            Você ainda não efetou nenhuma compra.
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField HeaderText="Código" DataField="IdVenda" />
                            <asp:BoundField HeaderText="Data da Compra" DataField="DataVenda" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField HeaderText="Valor" DataField="Valor" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
