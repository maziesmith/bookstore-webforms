using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Entities;


namespace Project.Web.Pages
{
    public partial class ConfirmacaoVenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Venda v = new Venda();
            if (!IsPostBack)
            {
                v = (Venda)Session["venda"];
                lblNúmero.Text = v.IdVenda.ToString();

                v = null;
                Session["venda"] = v;
            }
        }
    }
}