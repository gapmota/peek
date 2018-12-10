using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace peek.dist.screenSite
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            SmtpClient cliente = new SmtpClient();
            MailMessage msg = new MailMessage();
            System.Net.NetworkCredential smtpCreds = new System.Net.NetworkCredential("monitoringvision@gmail.com", "peek1234");

            try
            {
                cliente.Host = "smtp.gmail.com"; //SERVIDOR DO EMAIL
                cliente.Port = 587; //PORTA
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = smtpCreds;
                cliente.EnableSsl = true;

                string body = string.Concat("Nome: ", txtNome.Text, "\nE-mail: ", txtEmail.Text, "\nMensagem: ", txtMensagem.Text);
                msg.Subject = "Fale Conosco";
                msg.Body = body;
                msg.From = new MailAddress("monitoringvision@gmail.com"); //EMAIL PARA RECEBER A MENSAGEM
                msg.To.Add(new MailAddress("monitoringvision@gmail.com")); //IDEM AO DE CIMA

                cliente.Send(msg);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enviado com sucesso!')", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Erro ao enviar a mensagem')", true);
            }
        }
    }
}