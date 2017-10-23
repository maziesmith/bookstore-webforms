using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.DAL.Persistence;
using Project.Entities;
using Project.Util;

namespace Project.Web.Pages
{
    public partial class FecharVenda : System.Web.UI.Page
    {
        Venda v = new Venda();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //if (Session["venda"] == null)
                //{
                //    Response.Redirect("/Pages/CarrinhoCompras.aspx");
                //}
                //else if (Session["cliente"] == null)
                //{
                //    Response.Redirect("/Pages/LoginCliente.aspx");
                //}
                v.Itens = new List<ItemVenda>();

                v = (Venda)Session["venda"];
                v.Cliente = (Cliente)Session["cliente"];
                ClienteDAL cd = new ClienteDAL();
                v.Cliente = cd.FindById(v.Cliente.IdCliente);


                txtDestinatario.Text = v.Cliente.Nome + " " + v.Cliente.Sobrenome;
                txtCep.Text = v.Cliente.Endereco.Cep;
                txtLogradouro.Text = v.Cliente.Endereco.Logradouro;
                txtNumero.Text = v.Cliente.Endereco.Numero.ToString();
                txtComplemento.Text = v.Cliente.Endereco.Complemento;
                txtBairro.Text = v.Cliente.Endereco.Bairro;
                txtCidade.Text = v.Cliente.Endereco.Cidade;

                ddlEstados.DataSource = Enum.GetNames(typeof(Estados));
                ddlEstados.DataBind();
                ddlEstados.Items.Insert(0, new ListItem("UF", ""));

                ddlEstados.SelectedValue = v.Cliente.Endereco.Estado.ToString();

                gridCarrinho.DataSource = v.Itens;
                gridCarrinho.DataBind();

                lblValorTotal.Text = "Total da Compra: " + v.Valor;

            }
        }

        protected void btnConfimrma_Click(object sender, EventArgs e)
        {
            try
            {
                v.Itens = new List<ItemVenda>();

                v = (Venda)Session["venda"];
                v.DataVenda = DateTime.Now;
                v.Cliente = (Cliente)Session["cliente"];
                ClienteDAL cd = new ClienteDAL();
                v.Cliente = cd.FindById(v.Cliente.IdCliente);

                v.EnderecoEntrega = new EnderecoEntrega();                

                v.EnderecoEntrega.Destinatario = txtDestinatario.Text;
                v.EnderecoEntrega.Cep = txtCep.Text;
                v.EnderecoEntrega.Logradouro = txtLogradouro.Text;
                v.EnderecoEntrega.Numero = int.Parse(txtNumero.Text);
                v.EnderecoEntrega.Complemento = txtComplemento.Text;                
                v.EnderecoEntrega.Bairro = txtBairro.Text;
                v.EnderecoEntrega.Cidade = txtCidade.Text;
                v.EnderecoEntrega.Estado = (Estados)Enum.Parse(typeof(Estados), ddlEstados.SelectedValue);


                v.Pagamento = (txtTitular.Text + "-" + txtNumCartao.Text + "-" + txtCodigoSeguranca.Text + "-" + txtValidade.Text);

                VendaDAL vd = new VendaDAL();
                v.IdVenda = vd.Insert(v);
                Session["venda"] = v;

                Email email = new Email();
                email.ConfirmarVenda(v);                           
                                
                Response.Redirect("/AreaRestrita/ConfirmacaoVenda.aspx");
            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }
    }
}