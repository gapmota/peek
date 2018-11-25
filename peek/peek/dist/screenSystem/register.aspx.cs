using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using peek.Models;
using peek.Controller;

namespace peek.dist.screenSystem
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            UserController uc = new UserController();
            if (uc.CompararSenha(txtSenha.Text, txtConfirmaSenha.Text))
            {

                User u = new User();
                u.Nome = txtNome.Text;
                u.Email = txtEmail.Text;
                u.Senha = txtSenha.Text;
                u.Telefone = txtTelefone.Text;

                //vai pegar o email e senha e fazer isso
                /*                                                              a sequencia é sempre essa passa o email dps a senha blz? gg
                                Usuario usuario = new UsuarioController().Logar(Email.Text, Senha.Text); //onde tem esse Email.Text e Senha.Text tu vai mudar pelo valo "ID" da tela de login em .aspx (vou mostrar)

                                if(usuario != null)
                                {
                                    Session["USUARIO"] = usuario;
                                }

                                isso vai no evento do click do botaão logar da tela de login

                    */
                if (uc.IsEmailNaoCadastrado(u))
                {

                    if (uc.CadastrarUsuario(u))
                    {
                        Response.Write("<script>alert('Cadastrado com sucesso')</script>");
                        Response.Redirect("login.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Não foi possível realizar o cadastro!')</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('E-mail já cadastrado')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Senhas diferentes')</script>");
            }
        }
    }
}