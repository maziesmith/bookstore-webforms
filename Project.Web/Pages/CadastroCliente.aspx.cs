using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Entities;
using Project.DAL.Persistence;
using Project.Util;


namespace Project.Web.Pages
{
    public partial class CadastroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                ddlEstados.DataSource = Enum.GetNames(typeof(Estados));
                ddlEstados.DataBind();

                ddlEstados.Items.Insert(0, new ListItem("UF", ""));
            }
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteDAL dal = new ClienteDAL();

                if (!dal.EmailExistente(txtEmail.Text))
                {
                    Cliente c = new Cliente();
                    c.Endereco = new Endereco();

                    c.Nome = txtNome.Text;
                    c.Sobrenome = txtSobrenome.Text;
                    c.CPF = txtCpf.Text;
                    c.Email = txtEmail.Text;
                    c.Sexo = rblSexo.SelectedValue.ToString();
                    c.DataNascimento = DateTime.Parse(txtDataNascimento.Text);
                    c.Senha = txtSenha.Text;           

                    c.Endereco.Cep = txtCep.Text;
                    c.Endereco.Logradouro = txtLogradouro.Text;
                    c.Endereco.Numero = int.Parse(txtNumero.Text);
                    c.Endereco.Complemento = txtComplemento.Text;
                    c.Endereco.Bairro = txtBairro.Text;
                    c.Endereco.Cidade = txtCidade.Text;
                    c.Endereco.Estado = (Estados)Enum.Parse(typeof(Estados), ddlEstados.SelectedValue);

                    dal.Insert(c);

                    lblMensagem.Text = "Cliente " + c.Nome + " cadastrado com sucesso.";

                    Email email = new Email();
                    email.ConfirmarCadastro(c);

                    FieldsCleaner();
                }
                else
                {
                    lblMensagem.Text = "O e-mail informado já encontra-se cadastrado.";
                }

            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        private void FieldsCleaner()
        {
            txtNome.Text = string.Empty;
            txtSobrenome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCpf.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtSenha2.Text = string.Empty;
            rblSexo.SelectedIndex = -1;
            txtCep.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtLogradouro.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtDataNascimento.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            ddlEstados.SelectedIndex = 0;           
        }

        
    }
}