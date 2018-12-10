using peek.Controller;
using peek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace peek.dist.screenSystem
{
    public partial class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
                Response.Redirect("infraDashboard.aspx");
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            User usuario = new UserController().Logar(txtEmail.Text, txtSenha.Text); //onde tem esse Email.Text e Senha.Text tu vai mudar pelo valor "ID" da tela de login em .aspx (vou mostrar)

            if (usuario != null)
            {
                Session["USUARIO"] = usuario;
                Response.Redirect("infraDashboard.aspx");
            }
            else
            {
                Response.Write("<script>alert('Usuário inválido!')</script>");
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../screenSite/home.aspx");
        }
    }
}