using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using peekapi.models;
using System.Data;
using System.Data.SqlClient;

namespace peekapi.controller
{
    public class EntidadeUsuario
    {
        public List<Usuario> getUsuarios()
        {
            List<Usuario> userList = new List<Usuario>();
            using (SqlConnection cnx = Banco.getConexao())
            {
                try
                {
                    cnx.Open();
                    string sql = "SELECT * FROM PEEK_USUARIO";

                    using (SqlCommand cmd = new SqlCommand(sql, cnx))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Usuario user = new Usuario();
                                user.Email = dr["EMAIL"].ToString();
                                user.Nome = dr["NOME"].ToString();
                                user.Id = int.Parse(dr["ID"].ToString());

                                userList.Add(user);
                            }
                        }
                    }
                }
                catch { return null; }                
            }
            return userList;
        }

        public int cadastrarUsuarios(Usuario user)
        {
            using (SqlConnection cnx = Banco.getConexao())
            {
                string sql = "INSERT INTO PEEK_USUARIOS VALUES(@NOME,@EMAIL,@ID)";

                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@NOME",user.Nome);
                    cmd.Parameters.AddWithValue("@EMAIL",user.Email);
                    cmd.Parameters.AddWithValue("@ID",user.Id);

                    return cmd.ExecuteNonQuery();
                }
            }
        }



    }
}