using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Entities;
using Project.DAL.Persistence;

namespace Project.Web.AreaRestritaAdm
{
    public partial class CadastroAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adm"] == null)
            {
                Response.Redirect("/Pages/LoginAdministrador.aspx");
            }
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                AdministradorDAL d = new AdministradorDAL();
                if (d.EmailExistente(txtEmail.Text))
                {
                    lblMensagem.Text = "O e-mail informado já encontra-se cadastrado.";
                }
                else
                {
                    Administrador a = new Administrador();
                    a.Nome = txtNome.Text;
                    a.Sobrenome = txtSobrenome.Text;
                    a.Email = txtEmail.Text;
                    a.Senha = txtSenha.Text;

                    d.Insert(a);

                    lblMensagem.Text = "Administrador "+a.Nome+" cadastrado com sucesso.";

                    FieldsCleaner();
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
            txtSenha.Text = string.Empty;
            txtSenha2.Text = string.Empty;
        }
    }
}