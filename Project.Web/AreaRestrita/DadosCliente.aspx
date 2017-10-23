<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/MasterPage.Master" AutoEventWireup="true" CodeBehind="DadosCliente.aspx.cs" Inherits="Project.Web.Pages.DadosCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-8 col-md-offset-2">
        <div class="panel panel-primary">
            <div class="panel-heading bg-primary">
                <h3 class="text-center">Meus Dados</h3>
            </div>
            <div class="panel-body">
                <div class="col-md-4 col-md-offset-1">

                    <h4 class="grey">Dados Pessoais</h4>

                    <label>Nome:</label>
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control required" />
                    <br />

                    <label>Sobrenome:</label>
                    <asp:TextBox ID="txtSobrenome" runat="server" CssClass="form-control required" />
                    <br />

                    <label>CPF:</label>
                    <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control required" ReadOnly="true" />
                    <br />

                    <label>E-mail:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control required" ReadOnly="true" />
                    <br />

                    <label>Sexo:</label>
                    <asp:RadioButtonList ID="rblSexo" runat="server" CssClass="required">
                        <asp:ListItem Value="F" Text="Feminino" />
                        <asp:ListItem Value="M" Text="Masculino" />
                    </asp:RadioButtonList>
                    <br />

                    <label>Data de Nascimento:</label>
                    <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control required" TextMode="Date" />
                    <br />

                    <label>Nova Senha:</label>
                    <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Digite aqui" />
                    <br />

                    <label>Confirmar Nova Senha:</label>
                    <asp:TextBox ID="txtSenhaConfirm" runat="server" CssClass="form-control" TextMode="Password" placeholder="Digite aqui" />
                    <asp:CompareValidator ID="compareSenha" runat="server" ControlToCompare="txtSenhaConfirm" ControlToValidate="txtSenha" Text="As senhas não conferem." ForeColor="Red" Type="String" />
                    <br />
                </div>
                <div class="col-md-4 col-md-offset-2">

                    <h4 class="grey">Endereço:</h4>

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
                    
                        <asp:Button ID="btnAtualizar" runat="server" CssClass="btn btn-success" Text="Atualizar Dados" OnClick="btnAtualizar_Click" />
                    <br /><br />
                        <asp:Button ID="btnVoltar" runat="server" CssClass="btn btn-primary" Text="Pagina Inicial" PostBackUrl="/Default.aspx" />
                    
                </div>
            </div>
            <div class="panel-footer">
                <asp:Label ID="lblMensagem" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
