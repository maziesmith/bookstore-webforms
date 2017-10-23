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
    public partial class CarrinhoCompras : System.Web.UI.Page
    {

        Venda v = new Venda();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                if (Session["venda"] != null)
                {
                    v.Itens = new List<ItemVenda>();
                    v = (Venda)Session["venda"];
                }
                gridCarrinho.DataSource = v.Itens;
                gridCarrinho.DataBind();

                if(v.Itens == null)
                {
                    btnFinaliza.Visible = false;                    
                }
            }
        }

        protected void btnFinaliza_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AreaRestrita/FecharVenda.aspx");
        }

        protected void btnExclusao_Click(object sender, EventArgs e)
        {
            v.Itens = new List<ItemVenda>();
            v = (Venda)Session["venda"];

            LinkButton btn = (LinkButton)(sender);
            int idLivro = int.Parse(btn.CommandArgument);

            ItemVenda deletar = v.Itens.Find(x => x.Livro.IdLivro == idLivro);
            v.Itens.Remove(deletar);

            Session["venda"] = v;

            gridCarrinho.DataSource = v.Itens;
            gridCarrinho.DataBind();

        }
    }
}