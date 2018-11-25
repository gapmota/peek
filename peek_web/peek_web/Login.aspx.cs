using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using peek_web.Models;
using peek_web.Controller;

namespace peek_web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }//pqp

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new UsuarioController().Logar(txtEmail.Text, txtSenha.Text); //onde tem esse Email.Text e Senha.Text tu vai mudar pelo valo "ID" da tela de login em .aspx (vou mostrar)

            if (usuario != null)
            {
                Session["USUARIO"] = usuario;
                Response.Redirect("caminhaDoDashboard.aspx");
            }
            else
            {
                Response.Write("<script>alert('Usuário inválido!')</script>");
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {

        }
    }
}