using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using peekapi.Models;
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
                string sql = "SELECT * FROM PEEK_USUARIOS";

                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        Usuario user = new Usuario();
                        user.Email = dr["EMAIL"].ToString();
                        user.Nome = dr["NOME"].ToString();
                        user.Id = int.Parse(dr["ID"].ToString());

                        userList.Add(user);

                    }
                }
            }
            return userList;
        }

        public int cadastrarUsuarios()
        {
            using (SqlConnection cnx = Banco.getConexao())
            {
                string sql = "INSERT INTO PEEK_USUARIOS VALUES()";

                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("","");

                    return cmd.ExecuteNonQuery();
                }
            }
        }



    }
}