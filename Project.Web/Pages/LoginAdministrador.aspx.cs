using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Entities;
using Project.DAL.Persistence;
using System.Web.Security;

namespace Project.Web.Pages
{
    public partial class LoginAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                AdministradorDAL d = new AdministradorDAL();
                Administrador a = d.Autenticar(txtEmail.Text, txtSenha.Text);

                if (a != null)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(a.Email, false, 10);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

                    Response.Cookies.Add(cookie);

                    Session["cliente"] = null;

                    Session.Add("adm", a);

                    if (Request.QueryString["ReturnUrl"] != null)
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
                    Session["adm"] = null;
                    lblMensagem.Text = "Acesso Negado.";
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}