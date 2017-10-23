using Project.DAL.Persistence;
using Project.Entities;
using Project.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.Web.Pages
{
    public partial class LoginCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {                          

                ClienteDAL d = new ClienteDAL();
                Cliente c = d.Autenticar(txtEmail.Text, txtSenha.Text);

                if(c != null)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(c.Email, false, 10);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, 
                                                       FormsAuthentication.Encrypt(ticket));
                    Response.Cookies.Add(cookie);

                    Session.Add("cliente", c);

                    //redirecionamento..
                    if(Request.QueryString["ReturnUrl"] != null)
                    {
                        Response.Redirect(Request.QueryString["ReturnUrl"]);
                    }
                    else
                    {
                        Response.Redirect("/Default.aspx");
                    }
                    
                }
                else
                {
                    Session["cliente"] = null;
                    lblMensagem.Text = "Acesso Negado.";
                }
            }
            catch(Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}