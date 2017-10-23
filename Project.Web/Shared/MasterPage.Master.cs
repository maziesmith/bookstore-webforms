using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Entities;
using System.Web.Security;

namespace Project.Web.Shared
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
               
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["adm"] == null)
            {
                ddownAdministracao.Visible = false;
            }
            else
            {
                ddownAdministracao.Visible = true;
            }

            if (Session["cliente"] == null && Session["adm"] == null)
            {
                btnSair.Visible = false;
                btnEntrar.Visible = true;
            }
            else
            {
                btnSair.Visible = true;
                btnEntrar.Visible = false;
            }             
        }

       

        protected void btnCarrinho_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/CarrinhoCompras.aspx");
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session["cliente"] = null;
            Session["adm"] = null;
            btnSair.Visible = false;
            btnEntrar.Visible = true;

            Response.Redirect("/Default.aspx");
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/LoginCliente.aspx");
        }
    }
}