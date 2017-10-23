using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Util;

namespace Project.Web.Pages
{
    public partial class Contato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnvio_Click(object sender, EventArgs e)
        {
            try
            {
                Email email = new Email();
                email.Contato(txtNome.Text, txtEmail.Text, txtAssunto.Text, txtMensagem.Text);

                lblMensagem.Text = "Sua mensagem foi enviada com sucesso.";
            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }
    }
}