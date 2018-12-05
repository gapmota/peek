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

        public int PegarMediaUsoTodosLab(int idUsuario)
        {

            using (SqlConnection cnx = new Banco().PegarConexao())
            {
                Processador processador = new Processador();
                string sql = @"SELECT AVG(RAM.PORCENTAGEM_USO) AS USO_RAM FROM PEEK_MEMORIA_RAM RAM
                            INNER JOIN PEEK_COMPUTADOR PC ON PC.ID_COMPUTADOR = RAM.ID_COMPUTADOR
                            INNER JOIN PEEK_LAB L ON PC.ID_LAB = L.ID_LAB
                            INNER JOIN PEEK_USUARIO U ON U.ID_USUARIO = L.ID_USUARIO
                            WHERE U.ID_USUARIO = @ID
                                AND CONVERT(int, DATEDIFF(DAY, RAM.data_cadastro, getdate())) = 0
                                AND CONVERT(int, DATEDIFF(HOUR, RAM.data_cadastro, getdate()) % 24) = 0
                                AND CONVERT(int, DATEDIFF(MINUTE, RAM.data_cadastro, getdate()) % 60.0) <= 5
                                ;";
                using (SqlCommand cmd = new SqlCommand(sql, cnx))
                {
                    cmd.Parameters.AddWithValue("@ID", idUsuario);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            try
                            {
                                return (int)double.Parse(dr["USO_RAM"].ToString());
                            }
                            catch
                            {
                                return 0;
                            }


                        }
                        return 0;
                    }

                }

            }

        }


    }
}