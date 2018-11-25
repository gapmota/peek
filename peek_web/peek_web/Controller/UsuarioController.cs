using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using peek_web.Models;

namespace peek_web.Controller
{
    public class UsuarioController
    {

        public Usuario Logar(string email, string senha)
        {
            string sql = "SELECT * FROM PEEK_USUARIO WHERE EMAIL = @EMAIL AND SENHA = @SENHA";
            Usuario usuario = null; //recebe null por enquanto, pois ele vai ser instanciando no while. se não houver nenhum registro com a condição do sql ali em cima, ele vai continuar nulo. ou seja se esse metodo retornar null quer dizer que o email ou senha não tem cadastrado no bancoseu
            using (SqlConnection cnx = new Banco().GetConexao())
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@SENHA", senha);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            usuario = new Usuario();
                            usuario.Id = int.Parse(dr["ID_USUARIO"].ToString());
                            usuario.Nome = dr["NOME"].ToString();
                            usuario.Email = dr["EMAIL"].ToString();
                            usuario.Telefone = dr["TELEFONE"].ToString();
                        }

                    }


                }
            }

            return usuario;
        }


        public bool CadastrarUsuario(Usuario usuario)
        {

            string sql = "INSERT INTO PEEK_USUARIO(nome,email,senha,telefone) VALUES(@nome,@email,@senha,@telefone) ";

            using (SqlConnection cnx = new Banco().GetConexao())
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@email", usuario.Email);
                    cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                    cmd.Parameters.AddWithValue("@telefone", usuario.Telefone);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }

        }

        public bool IsEmailNaoCadastrado(Usuario usuario)
        {
            string sql = "SELECT * FROM PEEK_USUARIO WHERE EMAIL = @EMAIL";

            using (SqlConnection cnx = new Banco().GetConexao())
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            return false;
                        }
                    }

                }
            }
            return true;

        }

        public bool CompararSenha(string senha, string confirmarSenha)
        {
            return (senha == confirmarSenha) && (senha.Trim() != "");
        }

    }
}