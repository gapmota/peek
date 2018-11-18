using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using peekapi.Models;

namespace peekapi.Dao
{
    public class MemoriaRamDAO
    {
       public MemoriaRam PegarMemoriaRam(int idComputador)
        {

            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                MemoriaRam memoria = new MemoriaRam();
                string sql = "SELECT TOP 1 * FROM PEEK_MEMORIA_RAM WHERE ID_COMPUTADOR = @COD ORDER BY ID_MEMORIA_RAM DESC";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@COD", idComputador);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            memoria.IdComputador = int.Parse(dr["ID_COMPUTADOR"].ToString());
                            memoria.IdMemoriaRam = int.Parse(dr["ID_MEMORIA_RAM"].ToString());
                            memoria.Total = double.Parse(dr["TOTAL"].ToString());
                            memoria.Livre = double.Parse(dr["LIVRE"].ToString());
                            memoria.EmUso = double.Parse(dr["EM_USO"].ToString());
                            memoria.DataCadastro = dr["DATA_CADASTRO"].ToString();
                            
                            return memoria;
                        }
                        return null;
                    }


                }

            }

        }
    }
}