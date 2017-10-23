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
    public partial class CadastroLivro : System.Web.UI.Page
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
                    CategoriaDAL cd = new CategoriaDAL();
                    ddlCategorias.DataSource = cd.FindAll();
                    ddlCategorias.DataValueField = "IdCategoria";
                    ddlCategorias.DataTextField = "Nome";
                    ddlCategorias.DataBind();

                    ListItem item = new ListItem("- Escolha uma opção -", "");
                    ddlCategorias.Items.Insert(0, item);
                }
                catch (Exception ex)
                {
                    lblMensagem.Text = ex.Message;
                }
            }
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                Livro l = new Livro();
                l.Categoria = new Categoria();

                l.Titulo = txtTitulo.Text;
                l.Autor = txtAutor.Text;
                l.Editora = txtEditora.Text;
                l.AnoEdicao = txtAnoEdicao.Text;
                l.Preco = decimal.Parse(txtPreco.Text);
                l.Categoria.IdCategoria = int.Parse(ddlCategorias.SelectedValue);
                l.Quantidade = int.Parse(txtQuantidade.Text);
                l.Descricao = txtDescricao.Text;

                if (uplFoto.HasFile)
                {
                    if (uplFoto.PostedFile.FileName.EndsWith(".jpg") && uplFoto.PostedFile.ContentLength < (1024 * 1024))
                    {
                        l.Foto = Guid.NewGuid().ToString() + ".jpg";
                    }
                    else
                    {                        
                        throw new Exception("A imagem não atende aos requisitos. Envie apenas imagens de até 1MB de tamanho e no formato \".jpg\".");
                    }
                }
                else
                {
                    l.Foto = "sem-imagem.jpg";
                }


                LivroDAL ld = new LivroDAL();
                ld.Insert(l);

                string pasta = HttpContext.Current.Server.MapPath("/Images/");
                uplFoto.PostedFile.SaveAs(pasta + l.Foto);

                lblMensagem.Text = "Livro " + l.Titulo + " cadastrado com sucesso.";

                txtTitulo.Text = string.Empty;
                txtAutor.Text = string.Empty;
                txtEditora.Text = string.Empty;
                txtAnoEdicao.Text = string.Empty;
                txtPreco.Text = string.Empty;
                txtQuantidade.Text = string.Empty;
                txtDescricao.Text = string.Empty;
                ddlCategorias.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
                lblMensagem.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}