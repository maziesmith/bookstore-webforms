<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="CadastroAdministrador.aspx.cs" Inherits="Project.Web.AreaRestritaAdm.CadastroAdministrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6 col-md-offset-3">
        <div class="panel panel-info">
            <div class="panel-heading bg-info">
                <h3>Cadastro Admnistrador</h3>
            </div>
            <div class="panel-body">

                <h4 class="h4Grey">Dados:</h4>

                <label>Nome:</label>
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control required" />
                <br />

                <label>Sobrenome:</label>
                <asp:TextBox ID="txtSobrenome" runat="server" CssClass="form-control required" />
                <br />                

                <label>Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control required" />
                <br />

                <label>Senha:</label>
                <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control required" TextMode="Password" />
                <br />

                <label>Confirmar Senha:</label>
                <asp:TextBox ID="txtSenha2" runat="server" CssClass="form-control required" TextMode="Password" />
                <asp:CompareValidator ID="compareSenha" runat="server" ControlToCompare="txtSenha" ControlToValidate="txtSenha2" Text="As senhas não conferem." ForeColor="red" Type="String" />
                <hr />
                

                <asp:Button ID="btnCadastro" runat="server" CssClass="btn btn-success btn-block" Text="Cadastrar Administrador" OnClick="btnCadastro_Click" />
                <br />
                <br />

                <asp:Label ID="lblMensagem" runat="server" />
            </div>
        </div>

    </div>    

</asp:Content>
