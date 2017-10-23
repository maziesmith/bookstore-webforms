using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.DAL.Persistence;
using Project.Entities;

namespace Project.Web.AreaRestrita
{
    public partial class MinhasCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Cliente c = (Cliente)Session["cliente"];
                    VendaDAL d = new VendaDAL();

                    gridCompras.DataSource = d.SelectByCliente(c.IdCliente);
                    gridCompras.DataBind();
                }
                catch (Exception ex)
                {

                    lblMensagem.Text = ex.Message;
                }
            }
        }
    }
}