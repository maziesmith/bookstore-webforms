using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Entities;
using Project.DAL.Persistence;

namespace Project.Web.Pages
{
    public partial class DadosCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                    ClienteDAL d = new ClienteDAL();
                    Cliente c = (Cliente)Session["cliente"];
                    c = d.FindById(c.IdCliente);

                    txtNome.Text = c.Nome;
                    txtSobrenome.Text = c.Sobrenome;
                    txtCpf.Text = c.CPF;
                    txtEmail.Text = c.Email;
                    rblSexo.SelectedValue = c.Sexo;
                    txtDataNascimento.Text = c.DataNascimento.ToString("yyyy-MM-dd");

                    txtCep.Text = c.Endereco.Cep;
                    txtLogradouro.Text = c.Endereco.Logradouro;
                    txtNumero.Text = c.Endereco.Numero.ToString();
                    txtComplemento.Text = c.Endereco.Complemento;
                    txtBairro.Text = c.Endereco.Bairro;
                    txtCidade.Text = c.Endereco.Cidade;

                    ddlEstados.DataSource = Enum.GetNames(typeof(Estados));
                    ddlEstados.DataBind();
                    ddlEstados.Items.Insert(0, new ListItem("UF", ""));
                    ddlEstados.SelectedValue = c.Endereco.Estado.ToString();
                
            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente c = (Cliente)Session["cliente"];
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

                ClienteDAL d = new ClienteDAL();
                if (string.IsNullOrWhiteSpace(c.Senha))
                {
                    d.UpdateSemSenha(c);
                }
                else
                {
                    d.UpdateComSenha(c);
                }

                lblMensagem.Text = "Dados atualizados com sucesso.";
            }

            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }
    }
}