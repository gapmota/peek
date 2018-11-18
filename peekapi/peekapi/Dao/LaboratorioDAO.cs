using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace peekapi.Dao
{
    public class LaboratorioDAO
    {
         public int QuantidadeDeLaboratorio(int idUsuario)
        {

            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                string sql = "SELECT COUNT(ID_LAB) AS QNT FROM PEEK_LAB WHERE ID_USUARIO = @ID";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID", idUsuario);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return int.Parse(dr["QNT"].ToString());
                        }
                        return -1;
                    }


                }

            }

        }

    }
}