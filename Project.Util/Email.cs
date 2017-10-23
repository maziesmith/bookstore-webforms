using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Entities;
using System.Net;
using System.Net.Mail;

namespace Project.Util
{
    public class Email
    {
        public void ConfirmarCadastro(Cliente c)
        {
            string email = "cotiexemplo@gmail.com";
            string senha = "@coticoti@";

            MailMessage msg = new MailMessage(email, c.Email);
            msg.Subject = "Confirmação de cadastro - BookStore";
            msg.IsBodyHtml = true;
            msg.Body = "Seja bem vindo(a) " + c.Nome + "<br/></br>"
                + "Seu cadastro na BookStore foi realizado com sucesso.<br/></br>"
                + "Att, Equipe BookStore.";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(email, senha);

            smtp.Send(msg);
        }

        public void ConfirmarVenda(Venda v)
        {
            string email = "cotiexemplo@gmail.com";
            string senha = "@coticoti@";

            MailMessage msg = new MailMessage(email, v.Cliente.Email);
            msg.Subject = "Confirmação de Pedido (Nº " + v.IdVenda + ")";
            msg.IsBodyHtml = true;
            msg.Body = "Prezado " + v.Cliente.Nome + ",<br/>"
                + "Informamos que o seu pedido em nosso site foi realizado com sucesso.<br/>"
                + "Logo você estará recebendo os seus novos livros em seu endereço.<br/></br>"
                + "Dados do Pedido:<br/>"
                + "Número: " + v.IdVenda + "<br/>"
                + "Data: " + v.DataVenda.ToString("dd/MM/yyyy") + "<br/>"
                + "Valor: " + v.Valor + "<br/></br>"
                + "Att, Equipe BookStore.";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(email, senha);

            smtp.Send(msg);
        }

        public void Contato(string nome, string emailCliente, string assunto, string mensagem)
        {
            string email = "cotiexemplo@gmail.com";
            string senha = "@coticoti@";
            string contato = "t.trefilio@gmail.com";

            MailMessage msg = new MailMessage(email, contato);
            msg.Subject = "BookStore - Contato: " + assunto;
            msg.IsBodyHtml = true;
            msg.Body = "Contato efetuado pelo cliente: " + nome + "<br/>"
                      + "E-mail: " + emailCliente + "<br/></br>"
                      + "Mensagem: <br/>" + mensagem;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(email, senha);

            smtp.Send(msg);

            MailMessage msgResposta = new MailMessage(email, emailCliente);
            msgResposta.Subject = "BookStore - Resposta automática (Não responder)";
            msgResposta.IsBodyHtml = true;
            msgResposta.Body = "Prezado(a) " + nome + ",<br/></br>"
                              + "Agradecemos o seu contato.</br>"
                              + "Em até 36 horas estaremos analisando e respondendo a sua solicitação. <br/></br></br>"
                              + "Dados do contato:<br/>"
                              + "Nome: " + nome + "</br>"
                              + "E-mail: " + emailCliente + "<br/>"
                              + "Assunto: " + assunto + "<br/>"
                              + "Mensagem: " + mensagem + "<br/></br>"
                              + "Atenciosamente,<br/>Equipe BookStore";


            smtp.Send(msgResposta);
        }
    }
}
