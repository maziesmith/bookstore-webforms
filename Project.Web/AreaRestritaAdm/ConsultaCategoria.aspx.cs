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
    public partial class ConsultaCategoria : System.Web.UI.Page
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
                    CategoriaDAL d = new CategoriaDAL();
                    List <Categoria> lista = d.FindAll();
                    gridCategorias.DataSource = lista;
                    gridCategorias.DataBind();

                    lblMensagem.Text = lista.Count + " categorias encontradas.";

                }
                catch (Exception ex)
                {

                    lblMensagem.Text = ex.Message;
                }
            }
        }

        protected void btnExclusao_Click(object sender, EventArgs e)
        {
            try
            {
                int IdCategoria = int.Parse(((Button)sender).CommandArgument);
                CategoriaDAL d = new CategoriaDAL();
                d.Delete(IdCategoria);

                lblMensagem.Text = "Categoria excluída com sucesso.";

                List<Categoria> lista = d.FindAll();
                gridCategorias.DataSource = lista;
                gridCategorias.DataBind();
            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }
    }
}