using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using peekapi.Models;

namespace peekapi.Dao
{
    public class UsuarioDAO
    {
         public bool UsuarioExiste(int idUsuario)
        {
            using (SqlConnection cnx = new SqlConnection(new Banco().StringDeConexao))
            {
                cnx.Open();
                string sql = "SELECT * FROM PEEK_USUARIO WHERE ID_USUARIO = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID", idUsuario);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                            return true;
                        else
                            return false;
                    }
                }
            }
        }

    }
}