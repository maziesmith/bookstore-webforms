using Project.DAL.Persistence;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Web.Pages
{
    public partial class DetalhesCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adm"] == null)
            {
                Response.Redirect("/Pages/LoginAdministrador.aspx");
            }
            if (!IsPostBack)
            {
                try
                {
                    int IdCategoria = int.Parse(Request.QueryString["id"]);
                    CategoriaDAL d = new CategoriaDAL();
                    Categoria c = d.FindById(IdCategoria);

                    txtCodigo.Text = c.IdCategoria.ToString();
                    txtNome.Text = c.Nome;
                }
                catch (Exception ex)
                {

                    lblMensagem.Text = ex.Message;
                }
            }
        }

        protected void btnEdicao_Click(object sender, EventArgs e)
        {
            Categoria c = new Categoria();
            c.IdCategoria = int.Parse(txtCodigo.Text);
            c.Nome = txtNome.Text;

            CategoriaDAL d = new CategoriaDAL();
            d.Update(c);

            lblMensagem.Text = "Alterações gravadas com sucesso.";
        }
    }
}