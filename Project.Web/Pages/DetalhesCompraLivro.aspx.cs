using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.DAL.Persistence;
using Project.Entities;
using System.Drawing;

namespace Project.Web.Pages
{
    public partial class DetalhesCompraLivro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnContinuar.Visible = false;
            btnFinalizar.Visible = false;

            if (!IsPostBack)
            {
                try
                {
                    int idLivro = int.Parse(Request.QueryString["id"]);

                    LivroDAL d = new LivroDAL();
                    Livro l = d.FindById(idLivro);
                    lblTitulo.Text = l.Titulo;
                    lblCodigo.Text = "Código: "+l.IdLivro.ToString();
                    lblAutor.Text = "Autor: "+l.Autor;
                    lblCategoria.Text = "Categoria: "+l.Categoria.Nome;
                    lblEditora.Text = "Editora: "+l.Editora;
                    lblAnoEdicao.Text = "Ano: "+l.AnoEdicao;
                    lblPreco.Text = "Preco: "+l.Preco.ToString();
                    imgLivro.ImageUrl = "/Images/"+l.Foto;
                    txtQuantidade.Text = "1";
                    txtDescricao.Text = l.Descricao;
                    if (l.Quantidade < 1)
                    {
                        lblEsgotado.Text = "ESGOTADO";
                        txtQuantidade.Visible = false;
                        btnAdicionar.Visible = false;
                    }
                    

                }
                catch (Exception ex)
                {

                    lblMensagem.Text = ex.Message;
                }
                   
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                Venda v = null;

                if(Session["venda"] == null)
                {
                    v = new Venda();
                    v.Itens = new List<ItemVenda>();
                    v.Valor = 0;
                }
                else
                {
                    v = (Venda)Session["venda"];
                }                               

                int idLivro = int.Parse(Request.QueryString["id"]);

                LivroDAL ld = new LivroDAL();

                ItemVenda item = new ItemVenda();
                 
                item.Livro = ld.FindById(idLivro);           
                item.Quantidade = int.Parse(txtQuantidade.Text);

                if (item.Livro.Quantidade < item.Quantidade)
                {
                    lblMensagem.ForeColor = Color.Red;
                    throw new Exception("A quantidade selecionada não está disponível. Em estoque: "+item.Livro.Quantidade);
                }

                item.ValorTotal = item.Quantidade * item.Livro.Preco;

                v.Itens.Add(item);
                v.Valor += item.ValorTotal;

                Session["venda"] = v;

                btnAdicionar.Visible = false;
                btnContinuar.Visible = true;
                btnFinalizar.Visible = true;

                lblMensagem.ForeColor = Color.Blue;
                lblMensagem.Text = "Produto adicionado ao carrinho.";

                //Response.Write("<script>alert('Produto adicionado ao carrinho.')</script>");


            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/CarrinhoCompras.aspx");
        }
    }
}