using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using peekapi.models;
using peekapi.controller;
using System.Data.SqlClient;
using System.Data;


namespace peekapi.controller
{
    public class EntidadeMemoria
    {
        public Memoria getMemoria()
        {
            using (SqlConnection cnx = Banco.getConexao())
            {
                cnx.Open();
                string sql = "SELECT TOTAL, LIVRE, EMUSO FROM PEEK_MEMORIA";
                using (SqlCommand cmd = new SqlCommand(sql,cnx))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Memoria m = new Memoria();
                            m.Total = int.Parse(dr["TOTAL"].ToString());
                            m.Livre = int.Parse(dr["LIVRE"].ToString());
                            m.EmUso = int.Parse(dr["EMUSO"].ToString());

                            return m;
                        }
                    }
                }
            }
            return null;
        }

        public int UpdateMemoria(Memoria m)
        {
            using (SqlConnection cnx = Banco.getConexao())
            {
                cnx.Open();
                string sql = "UPDATE PEEK_MEMORIA SET TOTAL = @TOTAL, LIVRE = @LIVRE, EMUSO = @EMUSO";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@TOTAL",m.Total);
                    cmd.Parameters.AddWithValue("@LIVRE",m.Livre);
                    cmd.Parameters.AddWithValue("@EMUSO",m.EmUso);

                    return cmd.ExecuteNonQuery();

                }
            }
        }
    }
}