using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.DAL.Persistence;
using Project.Entities;
using System.Text.RegularExpressions;

namespace Project.Web.Pages
{
    public partial class CompraLivro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LivroDAL d = new LivroDAL();
                    listLivros.DataSource = d.FindAll();
                    listLivros.DataBind();
                }
                catch (Exception ex)
                {

                    lblMensagem.Text = ex.Message;
                }
            }

        }

        

        protected void btnPesquisa3_Click(object sender, EventArgs e)
        {
            try
            {

                string entrada = txtPesquisa.Text;
                int opcao = int.Parse(ddlPesquisa.SelectedValue);

                if (opcao != 5)
                {
                    if (string.IsNullOrWhiteSpace(entrada))
                    {
                        throw new Exception("O preenchimento do campo é obrigatório");

                    }
                }

                LivroDAL d = new LivroDAL();
                List<Livro> lista;
                Livro l = null;

                if (opcao == 1)
                {
                    lista = d.FindByTitulo(entrada);

                    listLivros.DataSource = lista;
                    listLivros.DataBind();

                    lblMensagem.Text = "Sua pesquisa retornou " + lista.Count + " resultado(s).";
                    txtPesquisa.Text = string.Empty;
                }

                else if (opcao == 2)
                {

                    try
                    {
                        Regex r = new Regex("^[0-9]{1,3}$");
                        if (r.IsMatch(entrada))
                        {
                            int codigo = int.Parse(entrada);
                            l = d.FindById(codigo);

                            if (l != null)
                            {
                                lista = new List<Livro>();
                                lista.Add(l);

                                listLivros.DataSource = lista;
                                listLivros.DataBind();

                                lblMensagem.Text = "Produto encontrado";
                                txtPesquisa.Text = string.Empty;
                            }
                            else
                            {
                                throw new Exception("Produto não encontrado");
                            }
                        }
                        else
                        {
                            throw new Exception("Para consultar por Código, deve ser fornecido um número inteiro.");
                        }
                    }
                    catch (Exception ex)
                    {

                        lblMensagem.Text = ex.Message;
                    }

                }

                else if (opcao == 3)
                {
                    lista = d.FindByAutor(entrada);

                    listLivros.DataSource = lista;
                    listLivros.DataBind();

                    lblMensagem.Text = "Sua pesquisa retornou " + lista.Count + " resultado(s).";
                    txtPesquisa.Text = string.Empty;

                }

                else if (opcao == 4)
                {
                    lista = d.FindByCategoria(entrada);

                    listLivros.DataSource = lista;
                    listLivros.DataBind();

                    lblMensagem.Text = "Sua pesquisa retornou " + lista.Count + " resultado(s).";
                    txtPesquisa.Text = string.Empty;

                }

                else if (opcao == 5)
                {
                    lista = d.FindByAnything(entrada);

                    listLivros.DataSource = lista;
                    listLivros.DataBind();

                    lblMensagem.Text = "Sua pesquisa retornou " + lista.Count + " resultado(s).";
                    txtPesquisa.Text = string.Empty;

                }



            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        protected void btnAut_Click(object sender, EventArgs e)
        {
            string Autor = (((Button)sender).CommandArgument).ToString();
            LivroDAL d = new LivroDAL();
            

            listLivros.DataSource = d.FindByAutor(Autor);
            listLivros.DataBind();
        }
    }
}