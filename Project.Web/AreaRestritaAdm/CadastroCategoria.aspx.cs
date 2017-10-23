using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.DAL.Persistence;
using Project.Entities;

namespace Project.Web.Pages
{
    public partial class CadastroCategoria : System.Web.UI.Page
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
                CategoriaDAL d = new CategoriaDAL();
                d.Insert(txtNome.Text);

                lblMensagem.Text = "Categoria cadastrada com sucesso.";

                txtNome.Text = string.Empty;
            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }
    }
}